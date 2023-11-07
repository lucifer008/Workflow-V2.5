using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Support.Log;

/// <summary>
/// 名    称: MemberCarcPriceSettings
/// 功能概要: 会员卡价格一览显示/追加/修改/删除
/// 作    者: 麻少华
/// 创建时间: 2007-9-25
/// 修正履历: 付强
/// 修正时间: 2009-1-17
///           代码整理
/// </summary>
public partial class MemberCarcPriceSettings : Workflow.Web.PageBase
{
    #region //类成员
    protected long lngBusinessTypeId = -1;
    protected long lngMemberCardLevel = -1;
    protected int intAction = Constants.ACTION_INIT;
    protected BusinessTypePriceSetModel model;
    private string PhookPager_CurrentPageKey = "pageid";
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
        if (this.IsPostBack)
        {
            #region 第一次
            if (Request.QueryString[PhookPager_CurrentPageKey] != null)
            {
                pageID = long.Parse(Request.QueryString[PhookPager_CurrentPageKey]);
            }

            if (Request.Form["sltBusinessType"] != null)
            {
                lngBusinessTypeId = long.Parse(Request.Form["sltBusinessType"]);
            }
            if (Request.Form["sltMemberCardLevel"] != null)
            {
                lngMemberCardLevel = long.Parse(Request.Form["sltMemberCardLevel"]);
            }

            if (pageID != 1)        //虽然指定的页数不是1,但是很可能要查询的内容已经变了
            {
                if (Request.QueryString["lastBusinessTypeId"] != null)
                {
                    long tmplngBusinessTypeId = long.Parse(Request.QueryString["lastBusinessTypeId"]);
                    if (tmplngBusinessTypeId != lngBusinessTypeId)
                    {
                        this.PhookPager1.RecoveryPageIndex = true;
                        pageID = 1;
                    }
                }
            }

            if (pageID != 1)
            {
                if (Request.QueryString["lastMemberCardLevel"] != null)
                {
                    long tmplngMemberCardLevel = long.Parse(Request.QueryString["lastMemberCardLevel"]);
                    if (tmplngMemberCardLevel != lngMemberCardLevel)
                    {
                        this.PhookPager1.RecoveryPageIndex = true;
                        pageID = 1;
                    }
                }
            }
            #endregion
        }
        else
        {
            #region 非第一次
            //如果是翻页后的新一页
            if (Request.QueryString[PhookPager_CurrentPageKey] != null)
            {
                pageID = long.Parse(Request.QueryString[PhookPager_CurrentPageKey]);
            }

            if (Request.QueryString["lastBusinessTypeId"] != null)
            {
                lngBusinessTypeId = long.Parse(Request.QueryString["lastBusinessTypeId"]);
            }

            if (Request.QueryString["lastMemberCardLevel"] != null)
            {
                lngMemberCardLevel = long.Parse(Request.QueryString["lastMemberCardLevel"]);
            }
            #endregion
        }

        if (null == currentmap)
        {
            currentmap = new Hashtable();
            this.isQuery.Value = "1";

        }
        else
        {
            if (this.isQuery.Value == "1")
            {
                currentmap.Clear();
            }
        }
        if (!currentmap.Contains("businesstype"))
        {
            currentmap.Add("businesstype", lngBusinessTypeId);

        }
        else
        {
            currentmap["businesstype"] = lngBusinessTypeId;
        }

        if (!currentmap.Contains("memberCardLevel"))
        {
            currentmap.Add("memberCardLevel", lngMemberCardLevel);
        }
        else
        {
            currentmap["memberCardLevel"] = lngMemberCardLevel;
        }

        DeleteMembercardPrice();

        //获得页面动作
        if (Request.Form["txtAction"] != null)
        {
            intAction = int.Parse(Request.Form["txtAction"]);
        }
        //判断页面动作执行不同的处理
        if (intAction == Constants.ACTION_INIT)
        {
            QueryProcess();
            //初始化显示
            businessTypePriceSetAction.InitDataPriceTypeMember(intAction);
        }
        else if(intAction == Constants.ACTION_SEARCH)
        {
            //查询
            this.isQuery.Value = "1";
            pageID = 1;
            QueryProcess();
            businessTypePriceSetAction.InitDataPriceTypeMember(intAction);
        }


        this.PhookPager1.ShowRecordCount = Constants.ROW_COUNT_FOR_PAGER;
        this.PhookPager1.ShowPageNumberCount = Constants.SHOW_PAGE_COUNT;
        this.PhookPager1.TotalRecordCount = Convert.ToInt32(businessTypePriceSetAction.GetOnlyBusinessTypePriceSetListCount(businessTypePriceSetAction.Model));
        this.PhookPager1.QueryStringKeyWord = PhookPager_CurrentPageKey;// "pageid";        
        this.PhookPager1.QueryString = "lastBusinessTypeId=" + lngBusinessTypeId.ToString() + "&lastMemberCardLevel=" + lngMemberCardLevel.ToString() + "&" + PhookPager_CurrentPageKey;


    }
    #endregion

    #region 查询
    /// <summary>
    /// 查询
    /// </summary>
    private void QueryProcess()
    {
        //设定查询条件
        model.BusinessTypePriceSet = new BusinessTypePriceSet();
        model.BusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
        //取得业务类型ID
        model.BusinessTypePriceSet.BusinessType.Id = lngBusinessTypeId;
        //取得卡级别类型ID
        model.BusinessTypePriceSet.TargetId = lngMemberCardLevel;
        //设定价格类型
        model.BusinessTypePriceSet.PriceType = Constants.PRICE_TYPE_MEMBER;

        //页数和每页行数
        model.BusinessTypePriceSet.CurrentPageID = pageID;
        model.BusinessTypePriceSet.EveryPageRows = Constants.ROW_COUNT_FOR_PAGER;

        businessTypePriceSetAction.GetPriceFactor();
        //获取价格因素的条件
        GetQueryPriceCondition();
        
        //查询
        businessTypePriceSetAction.GetOnlyBusinessTypePriceSetList(businessTypePriceSetAction.Model);

    }
    private void GetQueryPriceCondition()
    {
        if (null != model.PriceFactor && model.PriceFactor.Count > 0)
        {
			int intFoundPos = 0;
            foreach (PriceFactor priceFactor in model.PriceFactor)
            {
                if (currentmap != null && this.isQuery.Value == "0")
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
                model.BusinessTypePriceSet.TargetId = long.Parse(currentmap["memberCardLevel"].ToString());
            }
            this.isQuery.Value = "0";
        }
    }
    #endregion

    #region//删除与编辑会员价格

    /// <summary>
    /// 功能概要: 删除与编辑会员价格
    /// 作    者: 张晓林
    /// 创建时间: 2010年1月29日17:18:23
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    private void DeleteMembercardPrice()
    {
        string deleteAction = Request.Form["deleteAction"];
        switch (deleteAction)
        {
            case "PatchDelete":
                PatchDelete();
                break;
            case "Delete":
                SoleDelete();
                break;
            case "Edmit":
                EdmitPrice();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 功能概要: 批量删除会员价格
    /// 作    者: 张晓林
    /// 创建时间: 2010年1月29日17:18:23
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    private void PatchDelete() 
    {
        try 
        {
            string[] btsMembercardId = Request.Form["mebercardPriceId"].Split(',');
            BusinessTypePriceSet businessTypePriceSet = null;
            model.BusinessTypePriceSetList = new List<BusinessTypePriceSet>();
            foreach (string str in btsMembercardId)
            {
                string strSele = Request.Form["chky" + str];
                if (strSele == "on")
                {
                    businessTypePriceSet = new BusinessTypePriceSet();
                    businessTypePriceSet.BaseBusinessTypePriceSetId = Convert.ToInt32(str);
                    businessTypePriceSet.PriceType = Convert.ToInt32(Constants.PRICE_TYPE_MEMBER);
                    //long membercardLevelTypeId = Convert.ToInt32(Request.Form["sltMemberCardLevel"]);
                    //long branchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
                    businessTypePriceSet.TargetId = Convert.ToInt32(Request.Form["sltMemberCardLevel"]);//Constants.getBusinessTypePriceSetTargetId(branchShopId, membercardLevelTypeId);
                    model.BusinessTypePriceSetList.Add(businessTypePriceSet);
                }
            }
            businessTypePriceSetAction.DeleteMembercardPrice();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }

    /// <summary>
    /// 功能概要: 单个删除会员价格
    /// 作    者: 张晓林
    /// 创建时间: 2010年1月29日17:18:23
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    private void SoleDelete()
    {
        try
        {
            BusinessTypePriceSet businessTypePriceSet = new BusinessTypePriceSet();
            businessTypePriceSet.BaseBusinessTypePriceSetId = Convert.ToInt32(deleteId.Value);
            businessTypePriceSet.PriceType = Convert.ToInt32(Constants.PRICE_TYPE_MEMBER);
            long membercardLevelTypeId=Convert.ToInt32(Request.Form["sltMemberCardLevel"]);
            //long branchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            businessTypePriceSet.TargetId = membercardLevelTypeId;// Constants.getBusinessTypePriceSetTargetId(branchShopId, membercardLevelTypeId);
            model.BusinessTypePriceSetList = new List<BusinessTypePriceSet>();
            model.BusinessTypePriceSetList.Add(businessTypePriceSet);
            businessTypePriceSetAction.DeleteMembercardPrice();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    /// <summary>
    /// 功能概要: 编辑会员价格
    /// 作    者: 张晓林
    /// 创建时间: 2010年1月30日15:41:01
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    private void EdmitPrice() 
    {
        try 
        {
            BusinessTypePriceSet businessTypePriceSet = new BusinessTypePriceSet();
            decimal price = decimal.Parse(Request.Form["edmitPrice"]);
            long businessTypePriceSetId = Convert.ToInt32(Request.Form["deleteId"]);
            long membercardLevelTypeId = Convert.ToInt32(Request.Form["sltMemberCardLevel"]);
            //long branchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            businessTypePriceSet.NewPrice = price;
            businessTypePriceSet.BaseBusinessTypePriceSetId = businessTypePriceSetId;
            businessTypePriceSet.PriceType = Convert.ToInt32(Constants.PRICE_TYPE_MEMBER);
            businessTypePriceSet.TargetId = membercardLevelTypeId;//Constants.getBusinessTypePriceSetTargetId(branchShopId, membercardLevelTypeId);
            model.BusinessTypePriceSet = businessTypePriceSet;
            businessTypePriceSetAction.UpdateMembercardPrice();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
