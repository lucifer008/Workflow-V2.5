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
using Workflow.Web;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Encrypt;

/// <summary>
/// 名    称: Login
/// 功能概要: 登陆
/// 作    者: 付强
/// 创建时间: 2009-11-1
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class WorkFlowLogin : PageBase
{
    #region 类成员
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

    #region 页面加载
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

    #region 数据绑定
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
