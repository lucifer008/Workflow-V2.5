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
    protected bool closeFlag=false;
    protected long permissionGroupOpterateId = 0;//各店挂账权限Id
    public UserAction userAciton;
    public UserAction UserAction
    {
        set { userAciton = value; }
    }
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        string accreditFlag = Request.Form["accreditType"];
        long branchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
        permissionGroupOpterateId = Constants.PERMISSION_GROUP_OPERATE(branchShopId);
        if (!string.IsNullOrEmpty(accreditFlag))
        {
            Save(accreditFlag);
        }
    }
    #endregion

    #region Save
    public void Save(string accreditType)
    {
        if (string.IsNullOrEmpty(accreditType))
        {
            return;
        }
        if (string.IsNullOrEmpty(Request.Form["userName"]))
        {
            return;
        }
        userAciton.Model.User = new Workflow.Da.Domain.User();
        userAciton.Model.User.UserName = Request.Form["userName"];
        userAciton.Model.User.Password = EncryptUtils.HexMD5(Request.Form["password"]);
        userAciton.Model.User.PermissionType = long.Parse(accreditType);
        userAciton.Model.User.IsUsed = Constants.TRUE;
        userAciton.CheckPermissionByUserNameAndPassword();

        if (null != userAciton.Model.User)
        {
            closeFlag = true;
        }
    }
    #endregion
}
