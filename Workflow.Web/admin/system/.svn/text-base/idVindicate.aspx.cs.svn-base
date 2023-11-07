using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;

/// <summary>
/// 名    称:idVindicate
/// 功能概要:Id维护
/// 作    者:张晓林
/// 创建时间:2009年6月6日9:30:21
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class system_idVindicate : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "Id维护";
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
        DeleteIdGenerator();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 删除Id生成器
    /// </summary>
    private void DeleteIdGenerator() 
    {
        Response.Expires = -1;
        if(""!=hiddIdKey.Value.Trim())
        {
            systemAction.Model.IdGenerator.Id = Convert.ToInt32(hiddIdKey.Value);
            systemAction.DeleteIdGenerator();
        }
    }
    #endregion

    #region//Init
    protected void btnInit_Click(object sender, EventArgs e)
    {
        try 
        {
            systemAction.InitIdData();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        model.IdGenerator.Id = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.IdGenerator.Size = currentPageIndex - 1;
        searchSystemAction.SearchIdGenerator();

        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.RowCount;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
