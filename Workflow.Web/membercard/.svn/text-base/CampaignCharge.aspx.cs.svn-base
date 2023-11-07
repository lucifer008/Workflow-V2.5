using System;
using System.Web.UI.WebControls;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Membercard;
using System.Text.RegularExpressions;
/// <summary>
/// 名    称: CampaignCharge
/// 功能概要: 会员充值
/// 作    者: liuwei
/// 创建时间: 2007-10-08
/// </summary>
/// <remarks>
/// 修正履历: 陈汝胤
/// 修正时间: 2009.5.13
/// 修正描述: 功能完善,需求变更的功能修改
/// </remarks>
public partial class CampaignCharge : Workflow.Web.PageBase
{

    #region ClassMember
    protected MemberCardModel model;
    private MemberCardAction action;
    public MemberCardAction MemberCardAction
    {
        set { action = value; }
    }
    private CampaignAction campaignAction;
    protected CampaignModel campaignModel;
    public CampaignAction CampaignAction
    {
        set { campaignAction = value; }
    }
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = action.Model;
        campaignModel = campaignAction.Model;

        if (!IsPostBack)
        {
            
        }
        InitData();
    }
    #endregion

    #region 初始化页面
    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-8
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void InitData()
    {
        try
        {
            campaignAction.SearchAllCampaign();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region 充值
    /// <summary>
    /// 插入会员卡的充值信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-8
	/// 修正履历: 陈汝胤
	/// 修正时间: 2009.5.13
	/// 修正描述: 功能完善,需求变更的功能修改
	/// </remarks>	
    protected void InsertCampaign(object sender, EventArgs e)
    {
        try
        {
			string campaignType = Request.Form["hidCampaignType"];
			decimal chargeAmount = decimal.Parse(Request.Form["txtChargeAmount"]);
			decimal paperCount = decimal.Parse(Request.Form["hidPaperCount"]);
			decimal activityPrice = decimal.Parse(Request.Form["hidActivityPrice"]);
			string joinDate = Request.Form["txtJoinDate"];
			long memberCardId = long.Parse(Request.Form["hiddMemberCardId"]);
			long campaignId = long.Parse(Request.Form["hidCampaignId"]);
			if (!string.IsNullOrEmpty(campaignType))
			{
				model.MemberCardConcessionGathering = new MemberCardConcessionGathering();
				model.MemberCardConcessionGathering.ChargeAmount = chargeAmount;
				model.MemberCardConcessionGathering.PayType = Constants.CAMPAIGN_PAY_TYPE_PAYMENT;
				model.MemberCardConcessionGathering.MemberCardId = memberCardId;
                #region //充值记录
                model.OtherGatheringAndRefundmentRecord = new OtherGatheringAndRefundmentRecord();
                model.OtherGatheringAndRefundmentRecord.Amount = chargeAmount;
                model.OtherGatheringAndRefundmentRecord.TicketAmountSum = 0;
                model.OtherGatheringAndRefundmentRecord.OrdersId = 0;
                model.OtherGatheringAndRefundmentRecord.MemberCardId = memberCardId;
                if ("1" == campaignType)
                {
                    model.OtherGatheringAndRefundmentRecord.PayKind = Constants.CAMPAIGN_TYPE_CONCESSION_CHARGE_KEY.ToString();
                    model.OtherGatheringAndRefundmentRecord.Memo = Constants.CAMPAIGN_TYPE_CONCESSION_CHARGE_TEXT;
                }
                else if ("2" == campaignType)
                {
                    model.OtherGatheringAndRefundmentRecord.PayKind = Constants.CAMPAIGN_TYPE_DISCOUNT_CONCESSION_KEY.ToString();
                    model.OtherGatheringAndRefundmentRecord.Memo = Constants.CAMPAIGN_TYPE_DISCOUNT_CONCESSION_TEXT;
                }
                #endregion
                switch (campaignType)
				{
					case "1" : //送印章活动
						model.MemberCardConcession = new MemberCardConcession();
						model.MemberCardConcession.MemberCardId = memberCardId;
						model.MemberCardConcession.Concession = new Concession();
						model.MemberCardConcession.Concession.Id = campaignId;
						model.MemberCardConcession.JoinDateTime = DateTime.Parse(joinDate);
						model.MemberCardConcession.PaperCount = Math.Floor(chargeAmount / activityPrice + paperCount);
						model.MemberCardConcession.RestPaperCount = model.MemberCardConcession.PaperCount;
						model.MemberCardConcession.Amount = chargeAmount;
						action.InsertMemberCardConcession();
						break;
					case "2": //打折活动
						model.MemberCardDiscountConcession = new MemberCardDiscountConcession();
						model.MemberCardDiscountConcession.MemberCardId = memberCardId;
						model.MemberCardDiscountConcession.DiscountConcessionId = campaignId;
						model.MemberCardDiscountConcession.JoinDateTime = DateTime.Parse(joinDate);
						model.MemberCardDiscountConcession.Amount = chargeAmount;
						model.MemberCardDiscountConcession.RestAmount = chargeAmount;
						model.MemberCardDiscountConcession.DiffAmount = 0;
						model.MemberCardDiscountConcession.CounteractTimes = 0;
						action.InsertMemberCardDiscountConcession();
						break;
				}
			}
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
