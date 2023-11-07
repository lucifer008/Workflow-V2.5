using System;
using iTextSharp.text;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support.Report.Finance;
/// <summary>
///  功能概要：应收款付款记录
///  作    者：张晓林
///  创建时间: 2009年12月15日17:36:15
///  修正履历：
///  修正时间:
/// </summary>
public partial class finance_find_SearchPaidedAccountRecord : System.Web.UI.Page
{
    #region//ClassMember
    private string queryString = "";
    protected FindFinanceModel model;
    public FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction 
    {
        set { findFinanceAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
        if (!IsPostBack) 
        {
            ViewState.Add("StartTime", DateTime.Now.ToShortDateString());
            ViewState.Add("EndTime", DateTime.Now.AddDays(+1).ToShortDateString());
            queryNextPageData(1);
        }
    }
    #endregion

    #region//Search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        queryNextPageData(1);
    }
    #endregion

    #region//Print
    protected void btnDispatchPrint_Click(object sender, EventArgs e)
    {
        model.IsPrint = true;
        queryNextPageData(1);

        ReportSearchPaidedAccountRecord rSearchAcc = new ReportSearchPaidedAccountRecord();
        rSearchAcc.QueryString = queryString;
        string reportFileName = "SearchPaidedAccountRecord" + DateTime.Now.Ticks.ToString() + ".pdf";
        rSearchAcc.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
        rSearchAcc.CreateReport(model, "应收款付款记录", "应收款付款记录", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '应收款付款记录', 1024, 1024 , false, false, null);</script>");
    }
    #endregion

    #region//分页处理程序
    private void queryNextPageData(int currentPageIndex) 
    {
        try
        {
            if ("" != txtMemberCardNo.Value.Trim())
            {
                model.MemberCardNo = txtMemberCardNo.Value.Trim();
                queryString += " 卡号:"+model.MemberCardNo;
                ViewState["StartTime"] = null;
                ViewState["EndTime"] = null;
            }
            if ("" != txtCustomerName.Value.Trim())
            {
                model.CustomerName = txtCustomerName.Value.Trim();
                queryString += " 客户名称:" + model.CustomerName;
                ViewState["StartTime"] = null;
                ViewState["EndTime"] = null;
            }

            if (null != ViewState["StartTime"] && "" != ViewState["StartTime"].ToString()) 
            {
                model.InsertDateTimeString = ViewState["StartTime"].ToString();
                queryString += " 收款日期>=" + model.InsertDateTimeString;
            }
            if (null != ViewState["EndTime"] && "" != ViewState["EndTime"].ToString())
            {
                model.BalanceDateTimeString = ViewState["EndTime"].ToString();
                queryString += " 收款日期<=" + model.BalanceDateTimeString;
            }
            if ("" != txtBeginDateTime.Value.Trim())
            {
                model.InsertDateTimeString = txtBeginDateTime.Value;
                queryString += " 收款日期>=" + model.InsertDateTimeString;
                ViewState["StartTime"] = null;
                ViewState["EndTime"] = null;
            }
            if ("" != txtEndDateTime.Value.Trim())
            {
                model.BalanceDateTimeString = txtEndDateTime.Value;
                queryString += " 收款日期<=" + model.BalanceDateTimeString;
                ViewState["StartTime"] = null;
                ViewState["EndTime"] = null;
            }
            model.Operator1 = currentPageIndex.ToString();
            model.Operator2 = Constants.ROW_COUNT_FOR_PAGER.ToString();
            findFinanceAction.SearchAccountRecord();

            AspNetPager1.CurrentPageIndex = currentPageIndex;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount =Convert.ToInt32(model.BusinessTypeId);

            ViewState.Add("StartTime", ViewState["StartTime"]);
            ViewState.Add("EndTime", ViewState["EndTime"]);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        queryNextPageData(e.NewPageIndex);
    }
    #endregion
}
