using System;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Web;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Support.Encrypt;
using System.Collections.Specialized;
/// <summary>
/// 名    称: finance_Accredit
/// 功能概要: 通用权限验证页面
/// 作    者: 付强
/// 创建时间: 200-12-20
/// 修正履历: 张晓林
/// 修正时间: 2009年8月7日9:59:15
/// 修正描述: 修正授权权限适应各分店的应用
/// </summary>
public partial class finance_Accredit : PageBase
{
    #region Class Member
    protected decimal maxConcession, maxZero, maxRendUp;
    protected bool closeFlag=false,isReturn=false;
    public UserAction userAciton;
    public UserAction UserAction
    {
        set { userAciton = value; }
    }
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (null != Request.QueryString["AccreditTypeText"])
            {
                accreditTypeText.Value = Request.QueryString["AccreditTypeText"];//授权类型描述
            }
            if (null != Request.QueryString["AccreditTypeId"] && "" != Request.QueryString["AccreditTypeId"])
            {
                accreditTypeId.Value = Request.QueryString["AccreditTypeId"];//授权类型
            }
            if (null != Request.QueryString["AccreditTypeLabel"] && "" != Request.QueryString["AccreditTypeLabel"]) 
            {
                accreditTypeLabel.Value = Request.QueryString["AccreditTypeLabel"];
            }
            if (null != Request.QueryString["IsCallBack"] && "" != Request.QueryString["IsCallBack"]) 
            {
                IsCallBackAction.Value = Request.QueryString["IsCallBack"];
            }
        }
        if (!string.IsNullOrEmpty(Request.Form["userName"]) && !string.IsNullOrEmpty(Request.Form["password"]))
        {
            Save();
        }
    }
    #endregion

    #region Save
    public void Save()
    {
        try
        {
            Workflow.Da.Domain.User user = new Workflow.Da.Domain.User();
            user.UserName = Request.Form["userName"];
            user.Password = EncryptUtils.HexMD5(Request.Form["password"]);
            user.ConcessionTypeZero = Constants.CONCESSION_TYPE_ZERO_VALUE;
            user.ConcessionTypeCon = Constants.CONCESSION_TYPE_CONCESSION_VALUE;
            user.ConcessionTypeRenderUp = Constants.CONCESSION_TYPE_RENDERUP_VALUE;
            user.EmployeeName = Constants.PERMISSION_GROUP_OPERATE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId).ToString();//授权操作Id
            if ("" != accreditTypeId.Value.Trim())
            {
                user.UpdateUserString = accreditTypeId.Value;//授权类型Id
            }
            if ("" != accreditTypeLabel.Value.Trim())
            {
                user.InsertUserString = accreditTypeLabel.Value;//授权类型描述
            }
            if ("True" == IsCallBackAction.Value.Trim())
            {
                isReturn = true;
            }
            userAciton.Model.User = user;
            userAciton.GetAccreditUserInfo();
            if (null != userAciton.Model.User)
            {
                closeFlag = true;
                maxConcession = userAciton.Model.User.ConcessionMax;
                maxZero = userAciton.Model.User.ZeroMax;
                maxRendUp = userAciton.Model.User.RenderUpMax;
                //插入用户授权记录
                Workflow.Da.Domain.AccreditRecord accreditRecord = new Workflow.Da.Domain.AccreditRecord();
                accreditRecord.UsersId = userAciton.Model.User.Id;
                accreditRecord.UserName = Request.Form["userName"];
                accreditRecord.Memo = accreditTypeText.Value;
                accreditRecord.InsertDateTime = DateTime.Now;
                accreditRecord.UpdateDateTime = DateTime.Now;
                accreditRecord.InsertUser = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
                accreditRecord.Version = ThreadLocalUtils.CurrentUserContext.CurrentUser.Version;
                accreditRecord.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
                accreditRecord.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
                userAciton.Model.AccreditRecord = accreditRecord;
                userAciton.InsertAccreditRecord();
            }
        }
        catch (Exception ex) 
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
