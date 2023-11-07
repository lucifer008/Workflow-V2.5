using System;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Permission;
/// <summary>
/// 名    称: UsersList
/// 功能概要: 用户一览
/// 作    者: 张晓林
/// 创建时间: 2009-01-12
/// 修正履历: 
/// 修正时间: 
/// </summary>
///
 
public partial class popedomManagement_UsersList : Workflow.Web.PageBase
{

    #region Class Member
    private UserAction userAction;
    public UserAction UserAction
    {
        set { userAction = value; }
        get { return userAction; }
    }
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                InItData();
                QueryNextPageData(1);
            }
            DeleteUserInfo();
            EdmitUserInfo();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
	private void InItData() 
	{
        userAction.GetAllRole();
        sltUserRole.DataSource = userAction.Model.RoleList;
        sltUserRole.DataTextField = "permissionvalues";
        sltUserRole.DataValueField = "roleID";
        sltUserRole.DataBind();
    }
    #endregion

    #region Search
    protected void btnSearch_ServerClick(object sender, EventArgs e)
    {
        try
        {
            User user = new User();
            if (null != Request.Form["txtUserName"] && "" != Request.Form["txtUserName"])
            {
                user.UserName = Request.Form["txtUserName"].ToString().Trim();//用户名
            }
            if (null != sltUserRole && "-1" != sltUserRole.SelectedValue)
            {
                user.UserRole = sltUserRole.SelectedValue;//用户角色Id
            }
            user.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            user.CurrentPageIndex = 0;
            userAction.Model.User = user;
            userAction.SearchUserInfo();
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(userAction.GetAllUserRowCount());
            AspNetPager1.CurrentPageIndex = 1;

            ViewState.Add("UserName", Request.Form["txtUserName"]);
            ViewState.Add("UserRole",sltUserRole.SelectedValue);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region Edmit User
    private void EdmitUserInfo() 
    {
        if (null!=hiddTag.Value && "Edmit" ==hiddTag.Value.Trim())//Request.Form["hiddTag"] && "Edmit" == Request.Form["hiddTag"]) 
        {
            Response.Expires = -1;//清除页面缓存
            User user = new User();
            user.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            user.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;
            userAction.Model.User = user;
            userAction.SearchUserInfo();
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(userAction.GetAllUserRowCount());
            AspNetPager1.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex;
        }
    }
    #endregion

    #region Delete User
    private void DeleteUserInfo() 
    {
        if (null != Request.Form["hiddTag"] && "Delete" == Request.Form["hiddTag"])
        {
            User user = new User();
            user.UserName = hiddUserId.Value;//Request.Form["hiddUserId"].ToString();
            //user.PermissionName = hiddRoleId.Value;// Request.Form["hiddRoleId"].ToString();
            userAction.Model.User = user;
            userAction.DeleteUserInfo();
            QueryNextPageData(1);
        }
    }
    #endregion

    #region //分页处理
    private void QueryNextPageData(int currentPageIndex) 
    {
        User user = new User();
        if(null!=ViewState["UserName"] && ""!=ViewState["UserName"].ToString())
        {
            user.UserName = ViewState["UserName"].ToString();
        }
        if (null != ViewState["UserRole"] && "" != ViewState["UserRole"].ToString())
        {
            user.UserRole = ViewState["UserRole"].ToString();
        }
        user.RowCount = Constants.ROW_COUNT_FOR_PAGER;
        user.CurrentPageIndex = currentPageIndex - 1;
        userAction.Model.User = user;
        userAction.SearchUserInfo();
        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = Convert.ToInt32(userAction.GetAllUserRowCount());
        ViewState.Add("UserName", ViewState["UserName"]);
        ViewState.Add("UserRole", ViewState["UserRole"]);
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
