using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Membercard;
/// <summary>
/// 名    称: SearchMemberCard
/// 功能概要: 会员详情查询
/// 作    者: liuwei
/// 创建时间: 2007-10-23
/// 修正履历: 张晓林
/// 修正时间: 2009年4月3日9:20:47
///             完善查询功能；
///             增加捕获异常处理；
///             调整页面
/// </summary>
public partial class SearchMemberCard : Workflow.Web.PageBase
{
    #region //ClassMember
    protected string[] Campaigns;
    protected bool DataShowTag = false;
    private SearchMemberCardAction searchMemberCardAction;
    protected MemberCardModel model;

    public SearchMemberCardAction SearchMemberCardAction
    {
        set { searchMemberCardAction = value; }
    }

    private NewOrderAction orderAction;
    protected OrderModel orderModel;

    public NewOrderAction NewOrderAction
    {
        set { orderAction = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchMemberCardAction.Model;
        orderModel = orderAction.Model;
    }

    #endregion

    #region //查询
    /// <summary>
    /// 查询会员卡
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-23
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void SearchMemberCardInfo(object sender, EventArgs e)
    {
        try
        {
            model.MemberCardNo = Request.Form.Get("txtMemberCardNo");

            //会员卡信息，会员卡客户信息
            searchMemberCardAction.SearchAllMemberCardByCardNo();

            //会员卡刷卡次数
            orderModel.NewOrder = new Order();
            orderModel.NewOrder.MemberCardNo = model.MemberCardNo;
            orderAction.SearchMemberCardBrushNumber();

            //会员卡参与的营销活动
            searchMemberCardAction.SearchCampaignNameByMemberCardNo();
            Campaigns = model.CampaignNames.Split(new char[] { ',' });
            DataShowTag = true;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
