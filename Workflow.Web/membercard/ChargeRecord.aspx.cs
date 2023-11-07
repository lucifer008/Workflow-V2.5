using System;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Membercard;
/// <summary>
/// 名    称：ChargeRecord
/// 功能概要:会员充值记录
/// 作    者:
/// 创建时间:2007-10-23
/// 修正履历：张晓林
/// 修正时间:2009年4月3日10:21:23
/// 修正描述:完成统计充值记录功能
/// </summary>
public partial class ChargeRecord : Workflow.Web.PageBase
{
    #region //ClassMember
    protected string[] CampaignNames;
    protected MemberCardModel model;

    private SearchMemberCardAction searchMemberCardAction;
    public SearchMemberCardAction SearchMemberCardAction
    {
        set { searchMemberCardAction = value; }
    }
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchMemberCardAction.Model;
    }
    #endregion

    #region //查询
    /// <summary>
    /// 查询会员卡充值纪录
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-23
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void SearchChargeRecord(object sender, EventArgs e)
    {
        try
        {
            model.BeginDate = txtFrom.Value;
            model.EndDate = txtTo.Value;
            model.MemberCardNo = txtMemberCardNo.Value;
            model.CurrentPageIndex = 1;
            model.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            searchMemberCardAction.SearchChargeRecord();

            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = (int)searchMemberCardAction.Model.MemberCardConcessionRecordCount;

            ViewState.Add("BeginDate", model.BeginDate);
            ViewState.Add("EndDate", model.EndDate);
            ViewState.Add("MemberCardNo", model.MemberCardNo);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //分页处理程序
    private void QueryNextData(int currentPageIndex) 
    {
        try
        {
            if (null != ViewState["BeginDate"] && "" != ViewState["BeginDate"].ToString())
            {
                model.BeginDate = ViewState["BeginDate"].ToString();
            }

            if (null != ViewState["EndDate"] && "" != ViewState["EndDate"].ToString())
            {
                model.EndDate = ViewState["EndDate"].ToString();
            }

            if (null != ViewState["MemberCardNo"] && "" != ViewState["MemberCardNo"].ToString())
            {
                model.MemberCardNo = ViewState["MemberCardNo"].ToString();
            }

            model.CurrentPageIndex = currentPageIndex;
            model.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            searchMemberCardAction.SearchChargeRecord();

            AspNetPager1.CurrentPageIndex = currentPageIndex;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = (int)searchMemberCardAction.Model.MemberCardConcessionRecordCount;

            ViewState.Add("BeginDate", model.BeginDate);
            ViewState.Add("EndDate", model.EndDate);
            ViewState.Add("MemberCardNo", model.MemberCardNo);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        
        QueryNextData(e.NewPageIndex);
    }
    #endregion
}
