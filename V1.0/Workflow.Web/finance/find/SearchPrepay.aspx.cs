using System;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Support.Report.Finance;
/// <summary>
/// 名    称: FinanceFindSearchPrepay
/// 功能概要: 预付款查询
/// 作    者: 付强
/// 创建时间: 2007-10-26
/// 修正履历: 张晓林
/// 修正时间: 2008-12-24
///             完成：查询；打印；分页功能
/// </summary>
public partial class FinanceFindSearchPrepay : Workflow.Web.PageBase
{
    #region //Class Member
    private string pStrQueryString="";
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction 
    {
        set { findFinanceAction = value; }
        get { return findFinanceAction; }
    }
    #endregion

    #region //Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 默认查询当前月的所有数据
            //string strNowBeginDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-01";
            //string strNowEndDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-30";
            //ViewState.Add("BeginBalanceDate", strNowBeginDate);
            //ViewState.Add("EndBalanceDate", strNowEndDate);
            QueryNextPageData(1);
        }
    }
    #endregion

    #region //Search
    protected void Search(object sender, EventArgs e)
    {
        try
        {
            Order order = new Order();
            if (!StringUtils.IsEmpty(Request.Form["txtBeginDateTime"]))
            {
                order.BeginBalanceDate = Request.Form["txtBeginDateTime"];
            }

            if (!StringUtils.IsEmpty(Request.Form["txtTo"]))
            {
                order.EndBalanceDate = Request.Form["txtTo"];
            }

            if (!StringUtils.IsEmpty(Request.Form["CustomerName"]))
            {
                order.CustomerName = Request.Form["CustomerName"];
            }
            if (!StringUtils.IsEmpty(Request.Form["orderNo"]))
            {
                order.No = Request.Form["orderNo"];
            }
            this.AspNetPager1.CurrentPageIndex = 1;
            findFinanceAction.Model.Order = order;
            findFinanceAction.GetCustomerPrepay(0);
            this.AspNetPager1.RecordCount = (int)findFinanceAction.GetCustomerPrepayRowsCount();//总记录数
            this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;//每页显示条数
            ViewState.Add("CustomerName", Request.Form["customerName"]);
            ViewState.Add("BeginBalanceDate", Request.Form["txtBeginDateTime"]);
            ViewState.Add("EndBalanceDate", Request.Form["txtTo"]);
            ViewState.Add("No", Request.Form["orderNo"]);
            ViewState.Add("currentPageIndex", this.AspNetPager1.CurrentPageIndex);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion

    #region //Print
    protected void btnDispatchPrint_Click(object sender, EventArgs e)
    {
        try
        {
            SearchPrepayInfo();
            ReportPrepay rart = new ReportPrepay();
            rart.QueryString += pStrQueryString;
            string reportFileName = "PrepayTotal" + DateTime.Now.Ticks.ToString() + ".pdf";
            rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

            rart.CreateReport(findFinanceAction.Model, "预付款查询", "预付款查询", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '预付款查询', 1024, 1024 , false, false, null);</script>");
            QueryNextPageData(Convert.ToInt32(ViewState["currentPageIndex"]));
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    private void SearchPrepayInfo() 
    {
        pStrQueryString = "";
        Order order = new Order();
        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["CustomerName"])))
        {
                order.CustomerName = ViewState["CustomerName"].ToString();
            pStrQueryString += " 顾客姓名 " + ViewState["CustomerName"].ToString();
        }

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["No"])))
        {
                order.No= ViewState["No"].ToString();
            pStrQueryString += " 工单号 " + ViewState["No"].ToString();
        }

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["BeginBalanceDate"])))
        {
            order.BeginBalanceDate= ViewState["BeginBalanceDate"].ToString();
            pStrQueryString += " 开始日期 " + ViewState["BeginBalanceDate"].ToString();
        }

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["EndBalanceDate"])))
        {
            order.EndBalanceDate= ViewState["EndBalanceDate"].ToString();
            pStrQueryString += " 结束日期 " + ViewState["EndBalanceDate"].ToString();
        }
        findFinanceAction.Model.Order = order;
        findFinanceAction.GetCustomerPrepayPrint();
    }
    #endregion

    #region //分页处理程序
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    protected void QueryNextPageData(int currentPageIndex)
    {
        try
        {
            Order order = new Order();
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["CustomerName"])))
            {
                order.CustomerName = ViewState["CustomerName"].ToString();
            }

            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["BeginBalanceDate"])))
            {
                order.BeginBalanceDate = ViewState["BeginBalanceDate"].ToString();
            }

            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["EndBalanceDate"])))
            {
                order.EndBalanceDate = ViewState["EndBalanceDate"].ToString();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["No"])))
            {
                order.No = ViewState["No"].ToString();
            }
            findFinanceAction.Model.Order = order;
            findFinanceAction.GetCustomerPrepay(currentPageIndex - 1);
            this.AspNetPager1.RecordCount = (int)findFinanceAction.GetCustomerPrepayRowsCount();//总记录数
            this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;//每页显示条数
            ViewState.Add("CustomerName", ViewState["CustomerName"]);
            ViewState.Add("BeginBalanceDate", ViewState["BeginBalanceDate"]);
            ViewState.Add("EndBalanceDate", ViewState["EndBalanceDate"]);
            ViewState.Add("No", Request.Form["orderNo"]);
            ViewState.Add("currentPageIndex", currentPageIndex.ToString());
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion

}
