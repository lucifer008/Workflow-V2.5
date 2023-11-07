using System;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Permission;
/// <summary>
/// 名    称: NewPermission
/// 功能概要: 新增操作
/// 作    者: 张晓林
/// 创建时间: 2009-01-15
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// 
public partial class popedomManagement_NewPermission : System.Web.UI.Page
{

    #region Class Member
    protected long permissionId;
    protected string permissionIdentity="";
    protected string memo = "";
    protected string strTitle = "操作添加";
    private PermissionAction permissionAction;
    public PermissionAction PermissionAction 
    {
        set { permissionAction = value; }
    }
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //添加操作
            AddPermissionInfo();

            //编辑操作
            BingEdmitPermissionInfo();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    private void BingEdmitPermissionInfo() 
    {
        Response.Expires = -1;//清除页面缓存
        if (null != Request.QueryString["PermissionId"] && "0" != Request.QueryString["PermissionId"])
        {
            Permission permission = new Permission();
            permission.CurrentPageIndex = 0;
            permission.Memo = Request.QueryString["PermissionId"];
            permission.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            permissionAction.Model.Permission = permission;
            permissionAction.SearchPermissionInfo();
            if(permissionAction.Model.PermissionList.Count>0)
            {
                permissionId = Convert.ToInt32(Request.QueryString["PermissionId"]);
                permissionIdentity = permissionAction.Model.PermissionList[0].PermissionIdentity;
                memo = permissionAction.Model.PermissionList[0].Memo;
            }
            strTitle = "编辑操作";
        }
    }
    #endregion

    #region Save
    private void AddPermissionInfo() 
    {
        try
        {
            if (null != Request.Form["hiddTag"] && "Add" == Request.Form["hiddTag"])
            {
                Permission permission = new Permission();
                permission.PermissionIdentity = Request.Form["txtPermissionName"].ToString();
                permission.Memo = Request.Form["txtMemo"].ToString();
                if (null != Request.Form["hiddPermissionId"] && "" == Request.Form["hiddPermissionId"])//插入 
                {
                    permission.PermissionType = Constants.TRUE;
                    permissionAction.Model.Permission = permission;
                    permissionAction.AddPermissionInfo();
                }
                else if (null != Request.Form["hiddPermissionId"] && "0" != Request.Form["hiddPermissionId"])//更新
                {
                    permission.Id = Convert.ToInt32(Request.Form["hiddPermissionId"]);
                    permissionAction.Model.Permission = permission;
                    permissionAction.UpdatePermissionInfo();
                    Response.Write("<script>window.returnValue=true</script>");
                    Response.Write("<script>window.close()</script>");
                }
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
