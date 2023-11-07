﻿using System;
using Workflow.Web;
using Workflow.Da;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;

/// <summary>
/// 名    称: Top
/// 功能概要: 
/// 作    者: 张晓林
/// 创建时间: 2009年4月28日13:54:28
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class Top : PageBase
{
    #region //ClassMember
    public LoginAction loginAction;
    public LoginAction LoginAction
    {
        set { loginAction = value; }
    }
    #endregion

    #region //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ThreadLocalUtils.CurrentUserContext == null || ThreadLocalUtils.CurrentUserContext.CurrentUser == null)
        {
            Response.Redirect("Login.aspx");
            Response.End();
        }

        loginAction.LoginModel.LoginUser = ThreadLocalUtils.CurrentUserContext.CurrentUser;
    }
    #endregion
}
