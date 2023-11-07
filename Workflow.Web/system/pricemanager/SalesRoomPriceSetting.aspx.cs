using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Da.Domain;
using Workflow.Action.Model;

/// <summary>
/// 名    称: SalesRoomPriceSetting
/// 功能概要: 门市价格设置一览显示,追加,删除,编辑
/// 作    者: 麻少华
/// 创建时间: 2007-9-19
/// 修正履历: 付强
/// 修正时间: 2009-1-17
///           代码整理
/// </summary>
public partial class SalesRoomPriceSetting : Workflow.Web.PageBase
{
    #region 类成员
    //业务类型ID
    protected long lngBusinessTypeId = -1;
    protected BaseBusinessTypePriceSetModel model;
    protected long pageID = 1;
    private Hashtable currentmap;
    protected BaseBusinessTypePriceSetAction baseBusinessTypePriceSetAction;
    public BaseBusinessTypePriceSetAction BaseBusinessTypePriceSetAction
    {
        set { baseBusinessTypePriceSetAction = value; }
    }
    #endregion

    #region 页面加载
    /// <summary>
    /// 页面加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// 2008-11-08
    /// 朱静程
    /// Modify:Cry
    /// Date:2009-1-12
    /// 换分页
    /// </remarks>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.AspNetPager1.CurrentPageIndex = 1;
            BindData(0);
        }
        string txtAction = Request.Form["txtAction"];

        if (null != txtAction && txtAction == "5")
        {
            DeleteProcess();
        }
        BatchDeletePrice();
    }
    #endregion

    #region 分页控件事件
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        BindData(e.NewPageIndex - 1);
    }
    #endregion

    #region 数据初始化
    /// <summary>
    /// 方法名称: BindData
    /// 功能概要: 初始化页面
    /// 作    者: 陈汝胤
    /// 创建时间: 2009-1-9
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void BindData(int pageIndex)
    {
        model = baseBusinessTypePriceSetAction.Model;
        long tmplngBusinessTypeId = -1;
        model.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
        model.BaseBusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
        model.BaseBusinessTypePriceSet.BusinessType.Id = tmplngBusinessTypeId;
        if (this.isQuery.Value == "1")
        {
            if (null != Request.Form["sltBusinessType"])
            {
                tmplngBusinessTypeId = long.Parse(Request.Form["sltBusinessType"]);
            }
            model.BaseBusinessTypePriceSet.BusinessType.Id = tmplngBusinessTypeId;

            currentmap = new Hashtable();

			ViewState.Add(ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString(), currentmap);

            currentmap.Add("businesstype", tmplngBusinessTypeId);
        }
        else
        {
			if(ViewState[ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString()]!=null)
			{
				currentmap = (Hashtable)ViewState[ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString()];

                model.BaseBusinessTypePriceSet.BusinessType.Id = (long)currentmap["businesstype"];
            }
        }

        //获取价格因素
        baseBusinessTypePriceSetAction.GetPriceFactor();
        //获取价格因素的条件
        GetQueryPriceCondition();

        this.AspNetPager1.RecordCount = baseBusinessTypePriceSetAction.GetBaseBusinessTypePriceSetListCustomQueryCount(model);
        this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        model.BaseBusinessTypePriceSet.BeginRow = pageIndex * Constants.ROW_COUNT_FOR_PAGER + 1;
        model.BaseBusinessTypePriceSet.EndRow = pageIndex * Constants.ROW_COUNT_FOR_PAGER + Constants.ROW_COUNT_FOR_PAGER;
        baseBusinessTypePriceSetAction.InitCustomQuery_Page();
    }
    #endregion

    #region 操作保存
    /// <summary>
    /// 方法名称: DeleteProcess
    /// 功能概要: 获得ID,并删除当前的价格设置
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-06
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void DeleteProcess()
    {
        model = baseBusinessTypePriceSetAction.Model;
        model.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
        //获取当前需要处理的ID
        if (Request.Form["txtId"] != null)
        {
            model.BaseBusinessTypePriceSet.Id = long.Parse(Request.Form["txtId"]);
        }
        //删除
        try
        {
            baseBusinessTypePriceSetAction.Delete(model);
        }
        catch (Exception ex)
        {
            Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            Response.Write("<script>var message='此数据有特殊的价格,请先删除特殊价格';</script>");
        }
        BindData(this.AspNetPager1.CurrentPageIndex-1);
    }
    #endregion

    #region 获取价格因素的条件
    /// <summary>
    /// 方法名称: GetQueryPriceCondition
    /// 功能概要: 获取查询门市价格的条件
    /// 作    者: 陈汝胤
    /// 创建时间: 2009-1-12
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void GetQueryPriceCondition()
    {
        if (null != model.PriceFactor && model.PriceFactor.Count > 0)
        {
			int intFoundPos = 0;
            foreach(PriceFactor priceFactor in model.PriceFactor)
            {
                if(currentmap!=null && this.isQuery.Value == "0")
                {
                    //int key=int.Parse(priceFactor.Id.ToString()) - 1;
					if (currentmap.ContainsKey(intFoundPos))
                    {
						model.BaseBusinessTypePriceSet[intFoundPos] = (long)currentmap[intFoundPos];
						intFoundPos++;
                    }
                }
                else
                {
                    string factorValue = Request.Form["factorValuex" + priceFactor.Id];
                    if (null != factorValue)
                    {
						if (factorValue.Trim().Equals("-1"))
						{
							intFoundPos++;
							continue;
						}
						try
                        {
							model.BaseBusinessTypePriceSet[intFoundPos] = long.Parse(factorValue);
							currentmap.Add(intFoundPos, long.Parse(factorValue));
                        }
                        catch (Exception ex)
                        {
                            Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                        }
						intFoundPos++;
                    }
                }
				
            }
            this.isQuery.Value = "0";
        }
    }

    #endregion

    #region Button 事件
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.isQuery.Value = "1";
        this.AspNetPager1.CurrentPageIndex = 1;
        BindData(0);
    }
    #endregion

    #region//批量删除
    /// <summary>
    /// 功    能: 批量删除价格
    /// 作    者: 张晓林
    /// 创建时间：2010年1月15日10:32:16
    /// </summary>
    private void BatchDeletePrice()
    {
        try
        {
            if ("Delete" == Request.Form["Action"])
            {
                string[] strArrBBTPSL = Request.Form["bbtplId"].Split(',');
                foreach (string str in strArrBBTPSL)
                {
                    string strSele = Request.Form["cbBBTPSL" + str];
                    if (strSele == "on")
                    {
                        baseBusinessTypePriceSetAction.Model.StrBaseBusinessTypePriceList.Add(str);
                    }
                }
                baseBusinessTypePriceSetAction.BatchDeletePrice();
                //int currentPage = AspNetPager1.CurrentPageIndex - 1;
                BindData(0);
                AspNetPager1.CurrentPageIndex = 1;
            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
