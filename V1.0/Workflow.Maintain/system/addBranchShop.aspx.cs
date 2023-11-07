using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;

/// <summary>
/// 名    称: addBranchShop
/// 功能概要: 分店信息信息维护
/// 作    者: 张晓林
/// 创建时间: 2009年6月11日11:21:44
/// 修正履历:
/// 修正时间:
/// </summary>

public partial class system_addBranchShop : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "分店信息维护",strCompany;
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
        DeleteBranchShop();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BingEdmitData()
    {
        if (null != Request.QueryString["action"] && "edmit" == Request.QueryString["action"])
        {
            hidId.Value = Request.QueryString["BranchShopId"];
            strTitle = "编辑分店信息";
            tr1.Visible = false;
            btnCancel.Visible = true;
            txtBranchShopName.Value = Request.QueryString["BranchShopName"];
            txtMemo.Value = Request.QueryString["Memo"];
            strCompany = Request.QueryString["CompanyId"];
        }
    }
    private void DeleteBranchShop()
    {
        if ("delete" == Request.Form["actionTag"])
        {
            systemAction.Model.BranchShop.Id = Convert.ToInt32(hidId.Value);
            systemAction.LogicDeleteBranchShop();
            hidId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            systemAction.Model.BranchShop.Name = txtBranchShopName.Value;
            systemAction.Model.BranchShop.Memo = txtMemo.Value;
            systemAction.Model.BranchShop.CompanyId = Convert.ToInt32(Request.Form["company"]);
            if ("" != hidId.Value.Trim())//更新
            {
                systemAction.Model.BranchShop.Id = Convert.ToInt32(hidId.Value);
                systemAction.UpdateBranchShop();
                Response.Write("<script>window.returnValue=true</script>");
                Response.Write("<script>window.close();</script>");
            }
            else//插入 
            {
                systemAction.AddBranchShop();
                txtBranchShopName.Value = "";
                txtMemo.Value = "";
                QueryNextPageData(1);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageindex) 
    {
        model.BranchShop.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.BranchShop.UpdateUser = Convert.ToInt32(currentPageindex-1);
        searchSystemAction.SearchBranchShop();

        AspNetPager1.CurrentPageIndex = currentPageindex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.RowCount;

        model.Company.InsertUser = 200;
        model.Company.UpdateUser = 0;
        searchSystemAction.SearchCompany();
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
