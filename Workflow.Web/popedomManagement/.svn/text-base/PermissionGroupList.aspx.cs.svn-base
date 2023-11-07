using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Permission;
using Workflow.Action.Permission.Model;

/// <summary>
/// 名    称: PermissionGtoupList
/// 功能概要: 权限组一览 
/// 作    者:
/// 创建时间:
/// 修正履历: 张晓林
/// 修正时间: 2009年5月15日10:12:00
/// 修正描述: 完成编辑，删除，查询功能
/// </summary>
/// 
public partial class popedomManagement_PermissionGroupList : System.Web.UI.Page
{
    #region//ClassMember
    protected PermissionModel model;
    private PermissionAction permissionAction;
    public PermissionAction PermissionAction
    {
        set { permissionAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = permissionAction.Model;
        if (!IsPostBack)
        {
            
        }
        DeletePermissionGroup();
        QueryNextPageData(1);
    }

    private void DeletePermissionGroup() 
    {
        if(""!=hidPermissionGroupId.Value.Trim())
        {
            permissionAction.Model.PermissionGroup.Id = Convert.ToInt32(hidPermissionGroupId.Value);
            permissionAction.LogicDeletePermissionGroup();
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        permissionAction.Model.PermissionGroup.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        permissionAction.Model.PermissionGroup.UpdateUser = Convert.ToInt32(currentPageIndex-1);
        permissionAction.GetPermissionGroup();

        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.RecordCount = (int)model.RowCount;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
