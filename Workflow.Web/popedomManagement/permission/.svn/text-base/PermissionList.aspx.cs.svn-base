using System;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Permission;
using Workflow.Action.Permission.Model;
/// <summary>
/// 名    称: PermissionList
/// 功能概要: 操作一览
/// 作    者: 张晓林
/// 创建时间: 2009-01-15
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class popedomManagement_PermissionList : System.Web.UI.Page
{
    #region Class Member
    private PermissionAction permissionAction;
    public PermissionAction PermissionAction
    {
        set { permissionAction = value; }
    }
    protected PermissionModel model;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = permissionAction.Model;
            if (!IsPostBack)
            {
                QueryNextPageData(1);
            }

            EdmitPermissionRefreshData();
            DeletePermissionInfo();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region 分页处理
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }

    private void QueryNextPageData(int currentPageIndex)
    {
        try
        {
            Permission permission = new Permission();
            permission.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            permission.CurrentPageIndex = currentPageIndex - 1;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            permissionAction.Model.Permission = permission;
            AspNetPager1.RecordCount = Convert.ToInt32(permissionAction.SearchPermissionInfoRowCount());
            //AspNetPager1.CurrentPageIndex = currentPageIndex;
            permissionAction.SearchPermissionInfo();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region 编辑后刷新数据
    private void EdmitPermissionRefreshData() 
    {
        if(null!=Request.Form["hiddTag"] && "Edmit"==Request.Form["hiddTag"].ToString())
        {
            QueryNextPageData(AspNetPager1.CurrentPageIndex);
        }
    }

    public void DeletePermissionInfo() 
    {
        if (null != Request.Form["hiddTag"] && "Delete" == Request.Form["hiddTag"].ToString())
        {
            long permissionId = Convert.ToInt32(Request.Form["hiddPermissionId"]);
            permissionAction.DeletePermissionInfo(permissionId);
            QueryNextPageData(AspNetPager1.CurrentPageIndex);
        }
    }
    #endregion
}
