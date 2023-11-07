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
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;


/// <summary>
/// 名    称: TradePriceSetting
/// 功能概要: 行业价格设置一览
/// 作    者: 麻少华
/// 创建时间: 2007-9-27
/// 修正履历: 付强
/// 修正时间: 2009-1-17 
///           代码整理
/// </summary>
public partial class TradePriceSetting : Workflow.Web.PageBase
{
    #region 类成员
    private long lngBusinessTypeId = -1;
    private long lngSecondaryTrade = -1;
    protected int intAction = Constants.ACTION_INIT;
    protected BusinessTypePriceSetModel model;
    //private string PhookPager_CurrentPageKey = "pageid";
    private static Hashtable currentmap;
    protected long pageID = 1;
    protected BusinessTypePriceSetAction businessTypePriceSetAction;
    public BusinessTypePriceSetAction BusinessTypePriceSetAction
    {
        set { businessTypePriceSetAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        model = businessTypePriceSetAction.Model;
        businessTypePriceSetAction.InitDataPriceTypeTrade(intAction);
        if (!string.IsNullOrEmpty(Request.Form["sltBusinessType"]))
        {
            lngBusinessTypeId = long.Parse(Request.Form["sltBusinessType"]);
        }
        if (!string.IsNullOrEmpty(Request.Form["sltSecondaryTrade"]))
        {
            lngSecondaryTrade = long.Parse(Request.Form["sltSecondaryTrade"]);
        } 
        if (null == currentmap)
        {
            currentmap = new Hashtable();
            this.txtAction.Value = Constants.ACTION_INIT.ToString();

        }
        else
        {
            if (this.txtAction.Value == Constants.ACTION_INIT.ToString()
                || this.txtAction.Value == Constants.ACTION_SEARCH.ToString())
            {
                currentmap.Clear();
                pageID = 1;
            }
        }
        if (!currentmap.Contains("businesstype"))
        {
            currentmap.Add("businesstype", lngBusinessTypeId);

        }
        else
        {
            if (this.txtAction.Value == Constants.ACTION_INIT.ToString()
                || this.txtAction.Value == Constants.ACTION_SEARCH.ToString())
                currentmap["businesstype"] = lngBusinessTypeId;
        }

        if (!currentmap.Contains("trade"))
        {
            currentmap.Add("trade", lngSecondaryTrade);
        }
        else
        {
            if (this.txtAction.Value == Constants.ACTION_INIT.ToString()
                || this.txtAction.Value == Constants.ACTION_SEARCH.ToString())
                currentmap["trade"] = lngSecondaryTrade;
        }        
        //获得页面动作
        if (Request.Form["txtAction"] != null)
        {
            intAction = int.Parse(Request.Form["txtAction"]);
        }
        //判断页面动作执行不同的处理
        if (intAction == Constants.ACTION_INIT)
        {
            //查询
            QueryProcess();
        }
        else if (intAction == Constants.ACTION_SEARCH || intAction==Constants.ACTION_OTHER)
        {
            //查询
            QueryProcess();
            //businessTypePriceSetAction.InitDataPriceTypeTrade(intAction);
        }
        else if (intAction == Constants.ACTION_DELETE)
        {
            //删除
            DeleteProcess();
            //businessTypePriceSetAction.InitDataPriceTypeTrade(intAction);
            //再检索一遍
            QueryProcess();
        }
        else if (intAction == Constants.ACTION_UPDATE)
        {
            //编辑后再重新检索一遍
            QueryProcess();
        }
        this.AspNetPager1.CurrentPageIndex = int.Parse(pageID.ToString());
        this.AspNetPager1.RecordCount = int.Parse(model.RecordCount.ToString());
        this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
    }
    #endregion

    #region 查询
    /// <summary>
    /// 方法名称: QueryProcess
    /// 功能概要: 自定义查询
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-19
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void QueryProcess()
    {
        //获得查询条件
        //if (Request.Form["sltBusinessType"] != null)
        //{
        //    lngBusinessTypeId = long.Parse(Request.Form["sltBusinessType"]);
        //}
        //if (Request.Form["sltSecondaryTrade"] != null)
        //{
        //    lngSecondaryTrade = long.Parse(Request.Form["sltSecondaryTrade"]);
        //}
        //设定查询条件
        model.BusinessTypePriceSet = new BusinessTypePriceSet();
        model.BusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
        //取得业务类型ID
        model.BusinessTypePriceSet.BusinessType.Id = lngBusinessTypeId;
        //取得卡级别类型ID
        model.BusinessTypePriceSet.TargetId = lngSecondaryTrade;
        //设定价格类型
        model.BusinessTypePriceSet.PriceType = Constants.PRICE_TYPE_TRADE;
        model.BusinessTypePriceSet.CurrentPageID = pageID;
        model.BusinessTypePriceSet.EveryPageRows = Constants.ROW_COUNT_FOR_PAGER;

        GetQueryPriceCondition();


        //查询
        businessTypePriceSetAction.InitCustomQuery(businessTypePriceSetAction.Model);
    }

    private void GetQueryPriceCondition()
    {
        if (null != model.PriceFactor && model.PriceFactor.Count > 0)
        {
			int intFoundPos = 0;
            foreach (PriceFactor priceFactor in model.PriceFactor)
            {
                if (currentmap != null && (intAction != Constants.ACTION_INIT && intAction != Constants.ACTION_SEARCH))
                {
					//int key=int.Parse(priceFactor.Id.ToString()) - 1;
					if (currentmap.ContainsKey(intFoundPos))
					{
						model.BusinessTypePriceSet[intFoundPos] = (long)currentmap[intFoundPos];
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
							model.BusinessTypePriceSet[intFoundPos] = long.Parse(factorValue);
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
            if (null != currentmap)
            {
                model.BusinessTypePriceSet.BusinessType.Id = long.Parse(currentmap["businesstype"].ToString());
                model.BusinessTypePriceSet.TargetId = long.Parse(currentmap["trade"].ToString());
            }
            txtAction.Value = Constants.ACTION_OTHER.ToString();
        }
    }
    #endregion

    #region 操作保存

    /// <summary>
    /// 方法名称: DeleteProcess
    /// 功能概要: 删除价格
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-19
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void DeleteProcess()
    {
        try
        {

        model.BusinessTypePriceSet = new BusinessTypePriceSet();
        model.BusinessTypePriceSet.Id = int.Parse(txtId.Value);
        businessTypePriceSetAction.Delete(model);
    }
    catch (Exception ex)
    {
        LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        throw;
    }

    }
    #endregion

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.txtAction.Value = Constants.ACTION_OTHER.ToString();
        pageID = e.NewPageIndex;
        QueryProcess();
    }
}
