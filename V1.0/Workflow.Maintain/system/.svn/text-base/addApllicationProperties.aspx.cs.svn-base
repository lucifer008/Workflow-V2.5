using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;

/// <summary>
/// 名    称:edmitId
/// 功能概要:编辑Id生成器
/// 作    者:张晓林
/// 创建时间:2009年6月7日
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class system_addApllicationProperties : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "应用程序参数维护";
    protected SystemModel model;
    private SystemAction systemAction;
    public SystemAction SystemAction
    {
        set { systemAction = value; }
    }
    private SearchSystemAction searchSystemAction;
    public SearchSystemAction SearchSystemAction
    {
        set { searchSystemAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchSystemAction.Model;
        Response.Expires = -1;
        if(!IsPostBack)
        {
            BingEdmitData();
        }
        DeleteApplicationProperty();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BingEdmitData() 
    {
        if(null!=Request.QueryString["action"] && "edmit"==Request.QueryString["action"])
        {
            hidId.Value = Request.QueryString["ApplictionPropertyId"];
            strTitle = "编辑应用参数";
            tr1.Visible = false;
            btnInit.Visible = false;
            btnCancel.Visible = true;
            txtPropertyId.Value = Request.QueryString["PropertyId"];
            txtPropertyValue.Value = Request.QueryString["PropertyValue"];
        }
    }
    private void DeleteApplicationProperty() 
    {
        if ("delete" == Request.Form["actionTag"])
        {
            systemAction.Model.ApplicationProperty.Id = Convert.ToInt32(hidId.Value);
            systemAction.LogicDeleteApplicationProperty();
            hidId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            systemAction.Model.ApplicationProperty.PropertyId = txtPropertyId.Value;
            systemAction.Model.ApplicationProperty.PropertyValue = txtPropertyValue.Value;
            if ("" != hidId.Value.Trim())//更新
            {
                systemAction.Model.ApplicationProperty.Id = Convert.ToInt32(hidId.Value);
                systemAction.UpdateApplicationProperty();
                Response.Write("<script>window.returnValue=true</script>");
                Response.Write("<script>window.close();</script>");
            }
            else 
            {
                systemAction.AddApplicationProperty();
                txtPropertyId.Value = "";
                txtPropertyValue.Value = "";
                QueryNextPageData(1);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        model.ApplicationProperty.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.ApplicationProperty.UpdateUser = Convert.ToInt32(currentPageIndex-1);
        searchSystemAction.SearchApplictionPeroptery();

        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.RowCount;
        AspNetPager1.CurrentPageIndex = currentPageIndex;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion

    #region//InitData
    protected void btnInit_Click(object sender, EventArgs e)
    {
        try
        {
            systemAction.InitApplicationPropertyData();
            QueryNextPageData(1);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion
}
