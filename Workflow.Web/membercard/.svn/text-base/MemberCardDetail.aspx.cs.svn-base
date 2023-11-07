using System;
using Workflow.Web;
using Workflow.Util;
using Workflow.Action.Model;
using Workflow.Action.Membercard;

/// <summary>
/// 名    称:MemberCardDetail
/// 功能概要:会员详细资料
/// 作    者:liuwei
/// 创建时间:2007-10-6
/// 修正履历:张晓lin
/// 修正时间:2009年4月3日17:32:11
/// 修正描述:
/// </summary>
public partial class MemberCardDetail : Workflow.Web.PageBase
{
    #region //ClassMember
    protected string[] Campaigns;
    private SearchMemberCardAction searchMemberCardAction;
    protected MemberCardModel model;

    public SearchMemberCardAction SearchMemberCardAction
    {
        set { searchMemberCardAction = value; }
    }
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchMemberCardAction.Model;
        Response.Expires = -1;
        InitData();
    }
    #endregion

    #region //LoadData
    /// <summary>
    /// 显示页面数据
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-6
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void InitData()
    {
        long Id = NumericUtils.ToLong(Request.QueryString["Id"]);
        model.Id = Id;
        searchMemberCardAction.SearchMemberCardAndCustomerById();
        model.MemberCardNo = model.MemberCard.MemberCardNo;
        searchMemberCardAction.SearchCampaignNameByMemberCardNo();
        Campaigns = model.CampaignNames.Split(new char[] { ','});
    }
    #endregion
}
