using System;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Encrypt;
/// <summary>
/// 名    称: UpdatePassword
/// 功能概要: 密码修改
/// 作    者: 崔肖
/// 创建时间: 2008-12-11
/// 修正履历: 张晓林
/// 修正时间: 2009-02-04
/// </summary>
public partial class UpdatePassword : System.Web.UI.Page
{
    private UserAction userAction;
    public UserAction UserAction
    {
        set { userAction = value; }
        get { return userAction; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {}

    public void Password()
    {
        string password = Request.Form["txtPassword"];
        string newpwd = Request.Form["Password1"];
        string confirmpwd = Request.Form["Password2"];
        string oldpassword = EncryptUtils.HexMD5(password);


        if (ThreadLocalUtils.CurrentUserContext.CurrentUser.Password == oldpassword)
        {
            if (newpwd == confirmpwd)
            {
                User user = new User();
                user.Password = EncryptUtils.HexMD5(confirmpwd);
                user.Id = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
                userAction.Model.User = user;
                userAction.UpdatePasswordByUserId();
                Response.Write("<script language=javascript>alert('密码修改成功！')</script>");
                Response.Write("<script>parent.location.href='index.html';</script>");

            }

        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Password();
    }
}
