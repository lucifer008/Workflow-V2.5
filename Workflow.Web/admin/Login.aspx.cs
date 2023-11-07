using System;
using Workflow.Web;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Encrypt;

/// <summary>
/// 名    称: Login
/// 功能概要: 登陆后台维护
/// 作    者: 张晓林
/// 创建时间: 2009年4月28日11:29:20
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class WorkFlowLogin : PageBase
{
    #region //ClassMember
    private string ip;
    public string IPString
    {
        get { return ip; }
        set { ip = value; }
    }
    public LoginAction loginAction;
    public LoginAction LoginAction
    {
        set { loginAction = value; }
    }
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindData();
        }
        this.IPString = Request.ServerVariables["REMOTE_ADDR"];
        Response.Write("<script>var ip='"+ this.IPString +"';</script>");
    }
    #endregion

    #region //数据绑定
    protected void BindData()
    {
        loginAction.GetCurrentBranchShop();
        this.sltBranchShop.DataSource = loginAction.LoginModel.BranchShopList;
        this.sltBranchShop.DataTextField = "Name";
        this.sltBranchShop.DataValueField = "ID";
        this.sltBranchShop.DataBind();
    }
    #endregion
}
