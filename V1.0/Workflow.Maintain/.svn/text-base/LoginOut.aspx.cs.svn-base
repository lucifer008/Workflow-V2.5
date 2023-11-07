using System;
using Workflow.Web;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;

/// <summary>
/// 名    称: LoginOut
/// 功能概要: 注销用户
/// 作    者: 张晓林
/// 创建时间: 2009年4月28日14:06:38
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class LoginOut : PageBase
{

    #region //ClassMember
    public LoginAction loginAction;
    public LoginAction LoginAction
    {
        set { loginAction = value; }
    }
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        loginAction.LoginModel.LoginUser = new Workflow.Da.Domain.User();
        loginAction.LoginModel.LoginUser.Id = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
        loginAction.LoginModel.LoginUser.IsLogin = Constants.FALSE;
        loginAction.ExitLogoutUser();
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
    #endregion
}
