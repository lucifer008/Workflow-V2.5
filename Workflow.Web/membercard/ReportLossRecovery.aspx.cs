using System;
using System.Collections;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Membercard;

/// <summary>
/// 名    称: ReportLossRecovery
/// 功能概要: 恢复/挂失
/// 作    者: liuwei
/// 创建时间: 2007-10-06
/// 修正履历: 张晓林
/// 修正时间: 2008-11-08
///             完善恢复/挂失功能
///           2009-01-17
///             增加捕获异常处理,调整页面
/// </summary>
/// 
public partial class ReportLossRecovery : Workflow.Web.PageBase
{
	#region //Class Member
    protected MemberCardModel model;
    protected bool searchTag = false;
    protected bool reportLessTag = false;

    private MemberCardAction action;
    public MemberCardAction MemberCardAction
    {
        set { action = value; }
    }

    private SearchMemberCardAction searchMemberCardAction;
    public SearchMemberCardAction SearchMemberCardAction 
    {
        set { searchMemberCardAction = value; }
    }
	#endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = searchMemberCardAction.Model;
            //model = rlmcAction.Model;
            if (!IsPostBack)
            {
                InitData();
            }
            if (Request.Form["checkTag"] == "T")
            {
                long memberCardId = NumericUtils.ToLong(Request.Form["searchTag"]);
                SearchMemberCardInfo();
                SearchMemberCardAndNameInfo(memberCardId);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }

    /// <summary>
    /// 初始化页面
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
        searchMemberCardAction.GetReportLessMode();

        reportLessMode.DataSource = model.ReportLessModeList;
        reportLessMode.DataTextField = "Name";
        reportLessMode.DataValueField = "Id";
        reportLessMode.DataBind();
    }
    #endregion

    #region  //检索
    /// <summary>
    /// 检索会员卡信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-6
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void SearchMemberCardByIdentityCard(object sender, EventArgs e)
    {
        try
        {
            SearchMemberCardInfo();
        }
        catch (Exception ex) 
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //通过IdentityCard查询会员卡
    /// <summary>
    /// 通过IdentityCard查询会员卡(挂失/恢复)
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-6
    /// 修正履历:
    /// 修正时间:2008-12-1
    /// </remarks>
    private void SearchMemberCardInfo()
    {
        try
        {
            searchTag = true;
            Hashtable hashtable = new Hashtable();
            if ("" != identityCardNo.Value.Trim())
            {
                hashtable.Add("IdentityCardNo", identityCardNo.Value.Trim());
            }
            if ("" != txtMemberCardNo.Value.Trim()) 
            {
                hashtable.Add("MemberCardNo", "%"+txtMemberCardNo.Value.Trim()+"%");
            }
            hashtable.Add("Tag", 3);//能挂失的卡：不包括注销卡
            hashtable.Add("MemberState", Constants.MEMBER_CARD_STATE_LOGOUT_KEY);
            searchMemberCardAction.SearchMemberCardByIdentityCard(hashtable);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //查询会员卡和会员卡客户信息
    /// <summary>
    /// 查询会员卡和会员卡客户信息
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-6
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private  void SearchMemberCardAndNameInfo(long Id)
    {
        try
        {
            reportLessTag = true;
            model.Id = Id;
            searchMemberCardAction.SearchMemberCardAndCustomerById();
        }
        catch (Exception ex) 
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //挂失
    /// <summary>
    /// 执行挂失信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-6
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void InsertReportLossMemberCard(object sender, EventArgs e)
    {
		try
		{
				
			model.ReportLossMemberCard = new Workflow.Da.Domain.ReportLossMemberCard();
			model.ReportLossMemberCard.MemberCardId = NumericUtils.ToLong(Request.Form.Get("membercardid"));
			model.ReportLossMemberCard.ReportLessMode = new Workflow.Da.Domain.ReportLessMode();
			model.ReportLossMemberCard.ReportLessMode.Id = NumericUtils.ToLong(reportLessMode.SelectedValue);

			model.ReportLossMemberCard.Name =Request.Form["reportLessName"];
			model.ReportLossMemberCard.TelNo = Request.Form["telNo"];
            action.Model.ReportLossMemberCard = model.ReportLossMemberCard;

            model.MemberOperateLog.MemberCardId = NumericUtils.ToLong(Request.Form.Get("membercardid"));
            model.MemberOperateLog.OperateType = Workflow.Support.Constants.MEMBER_CARD_OPERATE_REPORTLOSS_KEY;
            model.MemberOperateLog.Memo = "挂失";
            action.Model.MemberOperateLog = model.MemberOperateLog;
			action.InsertReportLessMemberCard();

			SearchMemberCardInfo();
		}
		catch(Exception ex)
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
			throw ex;
		}
    }
    #endregion

    #region //恢复
    /// <summary>
    /// 恢复卡状态
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-6
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void RecoveryReportLossMemberCard(object sender, EventArgs e)
    {
		try
		{
		    model.MemberCardId = NumericUtils.ToLong(Request.Form.Get("membercardid"));
            model.MemberOperateLog.MemberCardId = model.MemberCardId;
            model.MemberOperateLog.OperateType = Workflow.Support.Constants.MEMBER_CARD_OPERATE_RECOVERY_KEY;//恢复
            model.MemberOperateLog.Memo = "恢复";
            action.Model.MemberCardId = model.MemberCardId;
            action.Model.MemberOperateLog = model.MemberOperateLog;

			action.DeleteByMemberCardId();

			SearchMemberCardInfo();
		}
		catch (Exception ex) 
		{
			Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
			throw ex;
		}
    }
    #endregion
}
