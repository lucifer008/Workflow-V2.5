using System;
using System.Web.UI.WebControls;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Membercard;
/// <summary>
/// 名    称: CampaignCharge
/// 功能概要: 会员充值
/// 作    者: liuwei
/// 创建时间: 2007-10-08
/// 修正履历: 张晓林
/// 修正时间: 2009年3月19日16:38:26        
/// </summary>
public partial class CampaignCharge : Workflow.Web.PageBase
{

    #region //ClassMember
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

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = action.Model;
        //concessionModel = concessionAction.Model;
        campaignModel = campaignAction.Model;

        if (!IsPostBack)
        {
            
        }
        InitData();
    }
    #endregion

    #region //初始化页面
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

    #region //充值
    /// <summary>
    /// 插入会员卡的充值信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-8
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    protected void InsertCampaign(object sender, EventArgs e)
    {
        try
        {
            MemberCardConcession memberCardConcession = new MemberCardConcession();

            memberCardConcession.MemberCardId = NumericUtils.ToLong(hiddMemberCardId.Value);
            memberCardConcession.Concession = new Concession();
            memberCardConcession.Concession.Id = NumericUtils.ToLong(Request.Form["ConcessionId"]);
            memberCardConcession.Amount = Convert.ToInt64(txtChargeSum.Value);
            //优惠得到的印章数:
            long concePaperCount = Convert.ToInt32(Convert.ToDecimal(Request.Form["ChargeCount"]) / Convert.ToDecimal(Request.Form["unitPrice"]));
            decimal diffChargeAmount = memberCardConcession.Amount - Convert.ToDecimal(Request.Form["ChargeCount"]);
            //计算剩余金额所得到的印章数
            if (0 < diffChargeAmount)
            {
                //计算方案门市价格
                long theoryCount = concePaperCount - Convert.ToInt32(Request.Form["presentCount"]);//优惠方案的理论上得到的印章数
                decimal roomPrice = Convert.ToDecimal(Request.Form["ChargeCount"]) / theoryCount;
                concePaperCount += Convert.ToInt32(diffChargeAmount / roomPrice);
            }
            memberCardConcession.PaperCount = Convert.ToDecimal(concePaperCount);
            memberCardConcession.RestPaperCount = Convert.ToDecimal(concePaperCount);
            memberCardConcession.PaperCount = Convert.ToDecimal(concePaperCount);
            memberCardConcession.JoinDateTime = Convert.ToDateTime(txtJoinDate.Value);
            model.MemberCardConcession = memberCardConcession;
            action.InsertMemberCardConcession();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
