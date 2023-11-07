using System;
using System.Collections.Generic;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using System.Collections;
/// <summary>
/// 名    称: SelectStandardPrice
/// 功能概要: 选择标准的门市价格
/// 作    者: 麻少华
/// 创建时间: 2007-9-27
/// 修正履历: 付强
/// 修正时间: 2009-1-17
///           代码整理
///           张晓林 完善功能 
///           2009年12月31日11:48:35
/// </summary>
public partial class SelectOnePrice : Workflow.Web.PageBase
{

    #region //ClassMember
    protected int intPageType = 0;////当前价格处理的类型
    protected string strPageTypeName = "";////当前取得的页面类型名称
    protected long sltBusinessTypeId = -1;
    protected long sltTradeId = -1;
    protected int intAction = Constants.ACTION_INIT;
    private static Hashtable currentmap;

    protected BusinessTypePriceSetModel model;
    private BusinessTypePriceSetAction businessTypePriceSetAction;
    public BusinessTypePriceSetAction BusinessTypePriceSetAction
    {
        set { businessTypePriceSetAction = value; }
    }
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        int currentPageIndex = 0;
        model = businessTypePriceSetAction.Model;
        businessTypePriceSetAction.InitDataPriceTypeTrade(intAction);
        if ("-1" != Request.Form["sltBusinessType"])
        {
            sltBusinessTypeId = Convert.ToInt32(Request.Form["sltBusinessType"]);
        }
        if ("-1" != Request.Form["sltSecondaryTrade"])
        {
            sltTradeId = Convert.ToInt32(Request.Form["sltSecondaryTrade"]);
        }
        if (!string.IsNullOrEmpty(Request.Form["actionTag"]))
        {
            intAction = Convert.ToInt32(Request.Form["actionTag"].Substring(0, 1));
        }

        if (null == currentmap)
        {
            currentmap = new Hashtable();

        }
        else
        {
            
            if (intAction == Constants.ACTION_INIT
                || intAction == Constants.ACTION_SEARCH)
            {
                currentmap.Clear();
                currentPageIndex = 1;
            }
        }
        if (!currentmap.Contains("businesstype"))
        {
            currentmap.Add("businesstype", sltBusinessTypeId);

        }
        else
        {
            if (intAction == Constants.ACTION_INIT
                || intAction == Constants.ACTION_SEARCH)
                currentmap["businesstype"] = sltBusinessTypeId;
        }

        if (!currentmap.Contains("trade"))
        {
            currentmap.Add("trade", sltTradeId);
        }
        else
        {
            if (intAction == Constants.ACTION_INIT
                || intAction == Constants.ACTION_SEARCH)
                currentmap["trade"] = sltTradeId;
        }
        if (!string.IsNullOrEmpty(Request.Form["actionTag"]) && Constants.ACTION_INSERT.ToString() == Request.Form["actionTag"].Substring(0, 1)) 
        {
            Save();
            QueryPageData(AspNetPager1.CurrentPageIndex);
        }
        if (!string.IsNullOrEmpty(Request.Form["actionTag"]) && Constants.ACTION_INIT.ToString() == Request.Form["actionTag"].Substring(0, 1))
        {
            currentPageIndex = AspNetPager1.CurrentPageIndex;
            if (0 != sltBusinessTypeId)
            {
                ViewState.Add("BusinessType", sltBusinessTypeId);
            }
            if (0 != sltTradeId)
            {
                ViewState.Add("Trade", sltTradeId);
            }
            sltBusinessTypeId = long.Parse(ViewState["BusinessType"].ToString());
            sltTradeId = long.Parse(ViewState["Trade"].ToString());
            QueryPageData(currentPageIndex);
        }
  
    }
    #endregion 

    #region //Search
    /// <summary>
    /// 根据业务类型与行业类型获取存在的行业价格及门市价格
    /// </summary>
    /// <param name="currentPageIndex"></param>
    /// <remarks>
    ///  作    者：张晓林
    ///  创建时间: 2009年12月31日17:06:14
    ///  修正履历:
    ///  修正时间:
    /// </remarks>
    private void QueryPageData(int currentPageIndex)
    {
        BusinessTypePriceSet busTyPr = new BusinessTypePriceSet();

        if (null != ViewState["BusinessType"] && "" != ViewState["BusinessType"].ToString()) 
        {
            busTyPr.BusinessType = new Workflow.Da.Domain.BusinessType();
            busTyPr.BusinessType.Id = Convert.ToInt32(ViewState["BusinessType"].ToString());
        }
        if (null != ViewState["Trade"] && "" != ViewState["Trade"].ToString())
        {
            busTyPr.TargetId = Convert.ToInt32(ViewState["Trade"].ToString());
        }
        busTyPr.PriceType = Constants.PRICE_TYPE_TRADE;
        busTyPr.CurrentPageID = currentPageIndex;
        busTyPr.EveryPageRows = Constants.ROW_COUNT_FOR_PAGER;
        model.BusinessTypePriceSet = busTyPr;
        GetQueryPriceCondition();

        businessTypePriceSetAction.GetAllBusinessTypePriceSetList(businessTypePriceSetAction.Model);
        long rowCount=businessTypePriceSetAction.GetAllBusinessTypePriceSetListCount(businessTypePriceSetAction.Model);

        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = Convert.ToInt32(rowCount);

        List<Workflow.Support.ClientShowData> showdatas = new List<ClientShowData>();
        for (int i = 0; i < model.BusinessTypePriceSetList.Count; i++)
        {
            ClientShowData sd = new ClientShowData(model.BusinessTypePriceSetList[i]);
            showdatas.Add(sd);
        }
        Session["SelectStandardPrice_aspx_showdatas"] = null;
        Session["SelectStandardPrice_aspx_showdatas"] = showdatas;
        sltBusinessTypeId = long.Parse(ViewState["BusinessType"].ToString());
        sltTradeId = long.Parse(ViewState["Trade"].ToString());
       // intAction = Constants.ACTION_OTHER;
    }

    private void GetQueryPriceCondition()
    {
        if (null != model.PriceFactor && model.PriceFactor.Count > 0)
        {
			int intFoundPos = 0;
            foreach (PriceFactor priceFactor in model.PriceFactor)
            {
                if (currentmap != null && intAction!=Constants.ACTION_INIT)
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
            //intAction = Constants.ACTION_OTHER;
            ClientScript.RegisterHiddenField("actionTag",Constants.ACTION_OTHER.ToString());
        }
    }

    #endregion

    #region//分页处理程序
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        sltBusinessTypeId = long.Parse(ViewState["BusinessType"].ToString());
        sltTradeId = long.Parse(ViewState["Trade"].ToString());
        QueryPageData(e.NewPageIndex);
    }
    #endregion

    #region//Save
    /// <summary>
    /// 添加或者更新行业价格
    /// </summary>
    /// <param name="currentPageIndex"></param>
    /// <remarks>
    ///  作    者：张晓林
    ///  创建时间: 2009年12月31日17:06:14
    ///  修正履历:
    ///  修正时间:
    /// </remarks>
    private void Save()
    {

        //如果找不到了,重新加载.
        if (Session["SelectStandardPrice_aspx_showdatas"] == null)
        {
            Response.Write("<script>alert('在指定时间内没有操作,需重新加载数据.请重新操作!')</script>");
            QueryPageData(1);
            return;
        }

        try
        {
            List<Workflow.Support.ClientShowData> showdatas = new List<ClientShowData>();
            showdatas = (List<Workflow.Support.ClientShowData>)Session["SelectStandardPrice_aspx_showdatas"];
            foreach (ClientShowData sd in showdatas)
            {
                decimal tmpd, d1 = 0, d2 = 0;
                tmpd = 0;
                decimal.TryParse(Request.Form["input1" + sd.BaseBusinessTypePriceSetId], out tmpd);
                if (tmpd <= 0)
                {
                    string err = "<script> alert('行业价格输入错误')</script>";
                    Response.Write(err);
                    return;
                }
                else
                {
                    d1 = tmpd;
                }
                tmpd = 0;
                decimal.TryParse(Request.Form["input2" + sd.BaseBusinessTypePriceSetId], out tmpd);
                if (tmpd <= 0 || tmpd > 100)
                {
                    string err = "<script> alert('行业折扣输入错误')</script>";
                    Response.Write(err);
                    return;
                }
                else
                {
                    d2 = tmpd;
                }

                if (Request.Form[sd.ChkName] != null)        //如果存在这个控件的值
                {
                    if (sd.IsCheck == false)                 //如果原来没有,而现在有了,增加
                    {
                        //增加处理
                        savePriceSet(sd.BusinessTypePriceSet, sd.BaseBusinessTypePriceSetId, d1, d2);
                    }
                    else
                    {
                        //原来也有,现在也有,看看值是否改变
                        if (!(d1.Equals(sd.NewPrice) && d2.Equals(sd.PriceConcession)))
                        {
                            //先删除
                            deleteByID(sd.BusinessTypePriceSetListId);
                            //后增加.
                            savePriceSet(sd.BusinessTypePriceSet, sd.BaseBusinessTypePriceSetId, d1, d2);

                        }
                    }
                }
                else                                         //如果指定的控件的值不存在, 
                {
                    if (sd.IsCheck == true)                  //而且原来的值选定,需要删除
                    {
                        //删除
                        deleteByID(sd.BusinessTypePriceSetListId);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }
    private void deleteByID(long BaseBusinessTypePriceSetId)
    {
        try
        {
            model.BusinessTypePriceSet = new BusinessTypePriceSet();
            model.BusinessTypePriceSet.Id = BaseBusinessTypePriceSetId;
            //删除
            businessTypePriceSetAction.Delete(model);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }

    private void savePriceSet(BusinessTypePriceSet bizTypePriceSet, string baseBizTypePriceSetId, decimal newPrice, decimal priceConcession)
    {
        try
        {
            BusinessTypePriceSetModel saveModel = new BusinessTypePriceSetModel();
            saveModel.BusinessTypePriceSetList = new List<BusinessTypePriceSet>();

            bizTypePriceSet.BaseBusinessTypePriceSetId = long.Parse(baseBizTypePriceSetId);
            bizTypePriceSet.NewPrice = newPrice;
            bizTypePriceSet.PriceConcession = priceConcession;

            saveModel.BusinessTypePriceSetList.Add(bizTypePriceSet);

            businessTypePriceSetAction.Add(saveModel);

        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
