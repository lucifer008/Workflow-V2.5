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
/// 名    称: LogOutMemberCard
/// 功能概要: 注销
/// 作    者: liuwei
/// 创建时间: 2007-10-06
/// 修正履历: 张晓林
/// 修正时间: 2008-11-04
///             完善注销功能
///           2009-01-17
///             增加捕获异常处理,调整页面
/// </summary>
public partial class LogOutMemberCard : Workflow.Web.PageBase
{

	#region   //Class Member

	private MemberCardAction action;
    protected MemberCardModel model;

    //private ReportLossMemberCardAction rlmcAction;
    //protected ReportLossMemberCardModel rlmcModel;

    protected bool SearchTag = false;
    protected bool ReportLessTag = false;

    public MemberCardAction MemberCardAction
    {
        set { action = value; }
    }

    private SearchMemberCardAction searchMemberCardAction;
    public SearchMemberCardAction SearchMemberCardAction 
    {
        set { searchMemberCardAction = value; }
    }

    //public ReportLossMemberCardAction ReportLossMemberCardAction
    //{
    //    set { rlmcAction = value; }
    //}

	#endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = searchMemberCardAction.Model;
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
    #endregion

    #region //通过IdentityCard查询会员卡
    /// <summary>
    /// 通过IdentityCard查询会员卡(注销)
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-6
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void SearchMemberCardInfo()
    {
        SearchTag = true;
        Hashtable hashtable = new Hashtable();
        if ("" != identityCardNo.Value.Trim()) 
        {
            hashtable.Add("IdentityCardNo", identityCardNo.Value.Trim());
        }
		 if(""!=txtMemberCardNo.Value.Trim())
        {
            hashtable.Add("MemberCardNo", "%"+txtMemberCardNo.Value.Trim()+"%");
        }
		hashtable.Add("Tag",3);//能注销的卡，包括正常卡和挂失卡
		hashtable.Add("MemberState", Constants.MEMBER_CARD_STATE_LOGOUT_KEY);
       searchMemberCardAction.SearchMemberCardByIdentityCard(hashtable);
    }
    #endregion

    #region //查询会员卡信息
    /// <summary>
    /// 查询会员卡和会员卡客户信息
    /// </summary>
    /// <param name="Id">会员卡Id</param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-6
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void SearchMemberCardAndNameInfo(long Id)
    {
        ReportLessTag = true;

        model.Id = Id;
        searchMemberCardAction.SearchMemberCardAndCustomerById();
    }
    #endregion

    #region //检索
    /// <summary>
    /// 检索
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-6
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void SearchMemberCard(object sender, EventArgs e)
    {
        try
        {
            SearchMemberCardInfo();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //注销
    /// <summary>
    /// 插入新注销卡
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-6
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void InsertLogoffMemberCard(object sender, EventArgs e)
    {
        try
        {
            model.LogoffMemberCard.MemberCardId = NumericUtils.ToLong(Request.Form.Get("membercardid"));
            model.LogoffMemberCard.Name = ThreadLocalUtils.CurrentUserContext.CurrentUser.UserName; //logoffMan.Text;
            model.LogoffMemberCard.Memo = memo.Text;
            model.LogoffMemberCard.LogoffDateTime = DateTime.Now;//Convert.ToDateTime(txtFrom.Value);
            action.Model.LogoffMemberCard=model.LogoffMemberCard;

            model.MemberOperateLog.MemberCardId = NumericUtils.ToLong(Request.Form.Get("membercardid"));
            model.MemberOperateLog.OperateType = Workflow.Support.Constants.MEMBER_CARD_OPERATE_LOGOUT_KEY;//注销
            model.MemberOperateLog.Memo = "注销";
            action.Model.MemberOperateLog = model.MemberOperateLog;

            action.InsertLogoffMemberCard();

            SearchMemberCardInfo();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
