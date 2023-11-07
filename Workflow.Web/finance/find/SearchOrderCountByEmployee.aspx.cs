using System;
using System.Data;

using Workflow.Action;
using iTextSharp.text;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Employee;
using Workflow.Action.Achievement;
using Workflow.Action.Finance.Model;
using Workflow.Support.Report.Finance;
/// <summary>
///  名    称: SearchOrderCountByEmployee
///  功能概要: 按照人员统计订单量
///  作    者: 张晓林
///  创建时间: 2009年11月11日10:36:49
///  修正履历: 张晓林 将查询条件:开单时间  修正为结算时间的交班时间查询
///  修正时间:
/// </summary>
public partial class finance_find_SearchOrderCountByEmployee : System.Web.UI.Page
{
    #region //ClassMember
    protected FindFinanceModel model;
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction 
    {
        set { findFinanceAction = value; }
    }
    private CashHandOverAction cashHandOverAction;
    public CashHandOverAction CashHandOverAction
    {
        set { cashHandOverAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
        if (!IsPostBack){}
        InitData();
    }
    private void InitData() 
    {
        findFinanceAction.SearchPositionOrEmployee();
    }
    #endregion

    #region//Search
    protected void btnSearch_ServerClick(object sender, EventArgs e)
    {
        if (null != Request.Form["position"] && "" != Request.Form["position"])
        {
            ViewState.Add("position", Request.Form["position"]);
        }
        else
        {
            ViewState["position"] = null;
        }
        if (null != Request.Form["employee"] && "" != Request.Form["employee"])
        {
            ViewState.Add("employee", Request.Form["employee"]);
            if (null == Request.Form["position"] || "" == Request.Form["position"])
            {
                long poitionId=findFinanceAction.SearchPositionByEmployeeId(Convert.ToInt32(Request.Form["employee"].Split(',')[0]));
                ViewState.Add("position", poitionId);
            }
        }
        else 
        {
            ViewState["employee"]=null;
        }
        QueryNextPageData(1);
    }
    private void QueryNextPageData(int currentPageIndex) 
    {
        try
        {
            model.Employee = new Workflow.Da.Domain.Employee();
            if (null!=ViewState["position"] && "" != ViewState["position"].ToString())
            {
                model.Employee.PositionName = ViewState["position"].ToString();
            }
            if (null != ViewState["employee"] && "" != ViewState["employee"].ToString())
            {
                model.Employee.ArrayEmployee = ViewState["employee"].ToString().Split(',');
            }
            if ("" != txtBeginDateTime.Value)
            {
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(txtBeginDateTime.Value).ToString("yyyy-MM-dd");
                model.Employee.PositionIdString = cashHandOverAction.DailyPaperMinHandOverDateTime;
            }
            if ("" != txtTo.Value)
            {
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(txtTo.Value).ToString("yyyy-MM-dd");
                model.Employee.No = cashHandOverAction.DailyPaperMinHandOverDateTime;
            }
            model.Employee.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            model.Employee.CurrentPageIndex = currentPageIndex-1;
            model.Employee.AnaphseNum = Convert.ToInt32(Constants.ORDER_STATUS_SUCCESSED_VALUE);//已完成
            findFinanceAction.Model = model;
            findFinanceAction.SearchOrderCount();

            AspNetPager1.CurrentPageIndex = currentPageIndex;
            AspNetPager1.RecordCount = Convert.ToInt32(model.Operator1);
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//Print
    protected void btnPrint_ServerClick(object sender, EventArgs e)
    {
        QueryNextPageData(AspNetPager1.CurrentPageIndex);
        ReportSearchOrderCountByEmployee rart = new ReportSearchOrderCountByEmployee();
        rart.QueryString = queryString.Value;
        string reportFileName = "SearchOrderCountByEmployee" + DateTime.Now.Ticks.ToString() + ".pdf";
        rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

        rart.CreateReport(model, "按人员统计订单量", "按人员统计订单量", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '按人员统计订单量', 1024, 1024 , false, false, null);</script>");
    }
    #endregion

    #region//分页处理程序
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
