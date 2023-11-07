using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Permission;
using Workflow.Action.Permission.Model;
/// <summary>
/// 名    称: NewPermissionGtoup
/// 功能概要: 权限组添加 
/// 作    者:
/// 创建时间:
/// 修正履历: 张晓林
/// 修正时间: 2009年5月15日10:12:00
/// 修正描述: 完成新增编辑功能
/// </summary>
public partial class popedomManagement_NewPermissionGroup : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "权限组添加";
    private PermissionModel model;
    private PermissionAction permissionAction;
    public PermissionAction PermissionAction 
    {
        set { permissionAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BingEdmitData();
        }
    }
    private void BingEdmitData() 
    {
        if (null != Request.QueryString["PermissionGroupId"] && "" != Request.QueryString["PermissionGroupId"])
        {
            btnClose.Visible = true;
            strTitle = "编辑权限组";
            hidPermissionGroupId.Value = Request.QueryString["PermissionGroupId"];
            txtName.Value = Request.QueryString["Name"];
            txtMemo.Value = Request.QueryString["Memo"];
        }
    }
    #endregion

    #region//Save
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            model = permissionAction.Model;
            model.PermissionGroup.Name = txtName.Value;
            model.PermissionGroup.Memo = txtMemo.Value;
            if ("" != hidPermissionGroupId.Value.Trim())
            {
                model.PermissionGroup.Id = Convert.ToInt32(hidPermissionGroupId.Value);
                permissionAction.UpdatePermissionGroup();
                Response.Write("<script>window.returnValue='yes'</script>");
                Response.Write("<script>window.close();</script>");
            }
            else
            {
                permissionAction.AddPermissionGroup();
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion
}
