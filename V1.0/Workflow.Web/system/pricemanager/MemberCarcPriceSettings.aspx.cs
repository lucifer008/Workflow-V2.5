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
using Workflow.Action.Model;


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
    #region 类成员
    protected long lngBusinessTypeId = -1;
    protected long lngMemberCardLevel = -1;
    protected int intAction = Constants.ACTION_INIT;
    protected BusinessTypePriceSetModel model;
    private string PhookPager_CurrentPageKey = "pageid";

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

        }
        else
        {
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

        }


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


        //查询
        businessTypePriceSetAction.GetOnlyBusinessTypePriceSetList(businessTypePriceSetAction.Model);

    }
    #endregion
}
