using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Workflow.Support;
using Workflow.Web;
using Workflow.Action;
using Workflow.Support.Log;

public partial class LoginOut : PageBase
{
    public LoginAction loginAction;
    public LoginAction LoginAction
    {
        set { loginAction = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //loginAction.LoginModel.LoginUser = new Workflow.Da.Domain.User();
        //loginAction.LoginModel.LoginUser.Id = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
        //loginAction.LoginModel.LoginUser.IsLogin = Constants.FALSE;
        //loginAction.LogoutUser();
        Session.Abandon();
//        LogHelper.WriteInfo("用户 " + ThreadLocalUtils.CurrentUserContext.CurrentUser.UserName + " 已注销登陆.注销时间 " + DateTime.Now.ToString(), Constants.LOGGER_NAME);
        Response.Redirect("~/Login.aspx");
       
    }
}
