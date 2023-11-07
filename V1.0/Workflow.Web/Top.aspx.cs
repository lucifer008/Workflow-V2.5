using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Da;
using Workflow.Web;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;

/// <summary>
/// 名    称: Top
/// 功能概要: 
/// 作    者: 付强
/// 创建时间: 2007-10-13
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class Top : PageBase
{
    #region 类成员
    public LoginAction loginAction;
    public LoginAction LoginAction
    {
        set { loginAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ThreadLocalUtils.CurrentUserContext == null || ThreadLocalUtils.CurrentUserContext.CurrentUser == null)
        {
            Response.Redirect("Login.aspx");
            Response.End();
        }
        
        loginAction.LoginModel.LoginUser =  ThreadLocalUtils.CurrentUserContext.CurrentUser;
    }
    #endregion
}
