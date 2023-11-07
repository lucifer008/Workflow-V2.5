using System;
using System.Collections;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Encrypt;
using Workflow.Action.Membercard;
/// <summary>
/// 名    称: RepairMemberCard
/// 功能概要: 补卡
/// 作    者: liuwei
/// 创建时间: 2007-10-05
/// 修正履历: 张晓林
/// 修正时间: 2008-11-06
///             完善补卡功能
///           2009-01-17
///             增加捕获异常处理,调整页面
/// </summary>
public partial class RepairMemberCard : Workflow.Web.PageBase
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

            if (Request.Form["checkTag"] == "T")
            {
                long memberCardId = NumericUtils.ToLong(OldMemberCardId.Value);
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
	/// 通过IdentityCard查询会员卡(补卡)
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-5
    /// 修正履历:Tag=2
    /// 修正时间:2008-11-25
    /// </remarks>	
    private void SearchMemberCardInfo()
    {
        try
        {
            searchTag = true;
            Hashtable hashtable = new Hashtable();
            if ("" != identityCardNo.Text.Trim())
            {
                hashtable.Add("IdentityCardNo", identityCardNo.Text);
            }
            if ("" != txtMemberCardNo.Value.Trim())
            {
                hashtable.Add("MemberCardNo", "%" + txtMemberCardNo.Value.Trim() + "%");
            }
            hashtable.Add("Tag", 2);//状态为注销的卡
            hashtable.Add("MemberState", Constants.MEMBER_CARD_STATE_REPORTLOSS_KEY);
            searchMemberCardAction.SearchMemberCardByIdentityCard(hashtable);
        }
        catch (Exception ex) 
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
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-5
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void SearchMemberCardAndNameInfo(long Id)
    {
        try
        {
           reportLessTag = true;
           model.Id = Id;
           searchMemberCardAction.SearchMemberCardById();
         }
        catch (Exception ex) 
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
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
    /// 创建时间: 2007-10-5
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void SearchMemberCardInfo(object sender, EventArgs e)
    {
        try
        {
           SearchMemberCardInfo();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //补卡
    /// <summary>
    /// 插入补卡信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-5
    /// 修正履历:
    /// 修正时间:2008-12-18
    /// </remarks>	
    protected void InsertLogoffMemberCard(object sender, EventArgs e)
    {
        try
        {
            model.Id = NumericUtils.ToLong(OldMemberCardId.Value);
            model.ChangeMemberCard = new ChangeMemberCard();

            model.ChangeMemberCard.NewMemberCardNo = newMemberCardNo.Value;
            model.ChangeMemberCard.OldMemberCardNo = Request.Form.Get("memberCardNo");
            model.PassWord = "";//EncryptUtils.HexMD5(passWord.Text);

            //获取操作记录
            model.MemberOperateLog = new MemberOperateLog();
            model.MemberOperateLog.MemberCardId = NumericUtils.ToLong(OldMemberCardId.Value);
            model.MemberOperateLog.Memo = "补卡";
            model.MemberOperateLog.OperateType = Constants.MEMBER_CARD_OPERATE_REISSUE_KEY;

            action.Model.MemberOperateLog = model.MemberOperateLog;
            action.Model.ChangeMemberCard = model.ChangeMemberCard;
            action.Model.Id = model.Id;
            action.Model.PassWord = model.PassWord;
            action.RepairNewMemberCard();

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
