using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;

/// <summary>
/// 名    称: addCompany
/// 功能概要: 公司信息维护
/// 作    者: 张晓林
/// 创建时间: 2009年6月9日12:58:07
/// 修正履历:
/// 修正时间:
/// </summary>

public partial class system_addCompany : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "公司信息维护";
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
        if (!IsPostBack)
        {
            BingEdmitData();
        }
        DeleteCompany();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BingEdmitData()
    {
        if (null != Request.QueryString["action"] && "edmit" == Request.QueryString["action"])
        {
            hidId.Value = Request.QueryString["CompanyId"];
            strTitle = "编辑公司信息";
            tr1.Visible = false;
            btnCancel.Visible = true;
            txtCompanyName.Value = Request.QueryString["CompanyName"];
            txtMemo.Value = Request.QueryString["Memo"];
        }
    }
    private void DeleteCompany()
    {
        if ("delete" == Request.Form["actionTag"])
        {
            systemAction.Model.Company.Id = Convert.ToInt32(hidId.Value);
            systemAction.LogicDeleteCompany();
            hidId.Value = "";
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex)
    {
        model.Company.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.Company.UpdateUser = Convert.ToInt32(currentPageIndex - 1);
        searchSystemAction.SearchCompany();

        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.RowCount;
        AspNetPager1.CurrentPageIndex = currentPageIndex;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            systemAction.Model.Company.Name = txtCompanyName.Value;
            systemAction.Model.Company.Memo =txtMemo.Value;
            if (""!=hidId.Value.Trim())//更新
            {
                systemAction.Model.Company.Id = Convert.ToInt32(hidId.Value);
                systemAction.UpdateCompany();
                Response.Write("<script>window.returnValue=true</script>");
                Response.Write("<script>window.close();</script>");
            }
            else 
            {
                systemAction.AddCompany();
                QueryNextPageData(1);
                txtCompanyName.Value = "";
                txtMemo.Value = "";
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion
}
