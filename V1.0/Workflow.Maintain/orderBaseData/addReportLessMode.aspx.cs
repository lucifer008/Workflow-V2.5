using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;

/// <summary>
///  名    称：addReportLessMode
///  功能概要: 挂失方式操作
///  作    者: 张晓林
///  创建时间: 2009年5月27日9:59:10
///  修正履历:
///  修正时间:
/// </summary>
public partial class orderBaseData_addReportLessMode : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "挂失方式";
    protected OrderBaseDataModel model;
    private OrderBaseDataAction orderBaseDataAction;
    public OrderBaseDataAction OrderBaseDataAction
    {
        set { orderBaseDataAction = value; }
    }
    private SearchOrderBaseDataAction searchOrderBaseDataAction;
    public SearchOrderBaseDataAction SearchOrderBaseDataAction
    {
        set { searchOrderBaseDataAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchOrderBaseDataAction.Model;
        if (!IsPostBack)
        {
            BindEdmitData();
        }
        DeleteData();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BindEdmitData()
    {
        if (null != Request.QueryString["action"] && "edmit" == Request.QueryString["action"])
        {
            Response.Expires = -1;
            btnCancel.Visible = true;
            tr1.Visible = false;
            strTitle = "编辑挂失方式";
            txtReportLessModeName.Value = Request.QueryString["ReportLessModeName"];
            hidReportLessId.Value = Request.QueryString["ReportLessModeId"];
        }
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    private void DeleteData()
    {
        if ("delete" == Request.Form["actionTag"])
        {
            orderBaseDataAction.Model.ReportLessMode.Id = Convert.ToInt32(hidReportLessId.Value);
            orderBaseDataAction.LogicDeleteReportLessMode();
            hidReportLessId.Value = "";
        }
    }
     #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            orderBaseDataAction.Model.ReportLessMode.Name = txtReportLessModeName.Value;
            if ("" != hidReportLessId.Value.Trim())
            {
                orderBaseDataAction.Model.ReportLessMode.Id = Convert.ToInt32(hidReportLessId.Value);
                orderBaseDataAction.UpdateReportLessMode();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else 
            {
                orderBaseDataAction.AddReportLessMode();
                txtReportLessModeName.Value = "";
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
    public void QueryNextPageData(int currentPageIndex) 
    {
        model.ReportLessMode.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.ReportLessMode.UpdateUser = Convert.ToInt32(currentPageIndex-1);
        searchOrderBaseDataAction.SearchReportLessMode();

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
