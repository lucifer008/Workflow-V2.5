using System;
using System.Web.UI.WebControls;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support.Report.Finance;
/// <summary>
///  功能概要: 统计报红订单，输出报红订单
///  作    者: 张晓林
///  创建时间: 2009年12月5日9:26:37
///  修正履历：
///  修正时间:
/// </summary>

public partial class finance_SearchMatureOrder : System.Web.UI.Page
{
    #region //Class Member
    private string queryCondition = "";
    protected FinanceModel model;
    private FinanceAction financeAction;
    public FinanceAction FinanceAction
    {
        set { financeAction = value; }
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
        model = financeAction.Model;
        if(!IsPostBack)
        {
            ViewState.Add("InBeginDateTime", DateTime.Now.ToShortDateString());
            ViewState.Add("InEndDateTime", DateTime.Now.AddDays(+1).ToShortDateString());
            QueryNextPageData(1);
        }
    }
    #endregion

    #region//Search
    protected void Search(object sender, EventArgs e)
    {
        Order order = new Order();
        if ("" != txtOrderNo.Value.Trim())
        {
            order.No = txtOrderNo.Value.Trim();
        }
        if ("" != txtInBeginDateTime.Value.Trim())
        {
            order.InsertDateTimeString = txtInBeginDateTime.Value;
        }
        if ("" != txtInEndDateTime.Value.Trim())
        {
            order.BalanceDateTimeString = txtInEndDateTime.Value;
        }
        if ("" != txtBaBeginDateTime.Value)
        {
            order.CustomerTypeName = txtBaBeginDateTime.Value;
        }
        if ("" != txtBaEndDateTime.Value)
        {
            order.LinkManName = txtBaEndDateTime.Value;
        }
        order.EveryPageCount = Constants.ROW_COUNT_FOR_PAGER;
        order.Status4 =0;
        financeAction.Model.Orders = order;
        financeAction.SearchMatureOrderList();

        AspNetPager1.CurrentPageIndex = 1;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = Convert.ToInt32(model.CustomerId);
        ViewState.Add("orderNo",order.No);
        ViewState.Add("InBeginDateTime",order.InsertDateTimeString);
        ViewState.Add("InEndDateTime",order.BalanceDateTimeString);
        ViewState.Add("BaBeginDateTime",order.CustomerTypeName);
        ViewState.Add("BaEndDateTime",order.LinkManName);
    }
    #endregion

    #region//Print
    protected void Print(object sender, EventArgs e)
    {
        QueryNextPageData(1);
        financeAction.SearchMatureOrderPrintList();

        ReportSearchMatureOrder rMatureOrder = new ReportSearchMatureOrder();
        rMatureOrder.QueryString += queryCondition;
        string reportFileName = "SearchMatureOrder" + DateTime.Now.Ticks.ToString() + ".pdf";
        rMatureOrder.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
        rMatureOrder.CreateReport(model, "报红订单统计", "报红订单统计", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '报红订单统计', 1024, 1024 , false, false, null);</script>");
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex)
    {
        try
        {
            Order order = new Order();
            if (null != ViewState["orderNo"] && ""!=ViewState["orderNo"].ToString())
            {
                order.No = ViewState["orderNo"].ToString();
                queryCondition += " 订单号:" + order.No;
            }
            if (null != ViewState["InBeginDateTime"] && "" != ViewState["InBeginDateTime"].ToString())
            {
                order.InsertDateTimeString = ViewState["InBeginDateTime"].ToString();
                queryCondition += " 开单时间>=" + order.InsertDateTimeString;
            }
            if (null != ViewState["InEndDateTime"] && "" != ViewState["InEndDateTime"].ToString())
            {
                order.BalanceDateTimeString = ViewState["InEndDateTime"].ToString();
                queryCondition += " 开单时间<=" + order.BalanceDateTimeString;
            }
            if (null != ViewState["BaBeginDateTime"] && "" != ViewState["BaBeginDateTime"].ToString())
            {
                order.CustomerTypeName = ViewState["BaBeginDateTime"].ToString();
                queryCondition += " 结算时间>=" + order.CustomerTypeName;
            }
            if (null != ViewState["BaEndDateTime"] && "" != ViewState["BaEndDateTime"].ToString())
            {
                order.LinkManName = ViewState["BaEndDateTime"].ToString();
                queryCondition += " 结算时间<="+order.LinkManName;
            }
            order.EveryPageCount = Constants.ROW_COUNT_FOR_PAGER;
            order.Status4 = Convert.ToInt32(currentPageIndex - 1);
            financeAction.Model.Orders = order;
            financeAction.SearchMatureOrderList();

            AspNetPager1.CurrentPageIndex = currentPageIndex;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(model.CustomerId);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
