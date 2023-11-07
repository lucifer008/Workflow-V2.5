using System;
using Workflow.Da.Domain;
using Workflow.Util;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support;
using Workflow.Support.Report.Finance;
using iTextSharp.text;

/// <summary>
/// 功能概要: 客户付款明细
/// 作    者：付强
/// 创建时间:
/// 修正履历：陈汝胤
/// 修正时间: 2010.1.4
/// </summary>
public partial class FinanceFindSearchPayment : Workflow.Web.PageBase
{
    #region ClassMember
    private string balanceDateTime = "";
    private string insertDateTime = "";
    private string customerName = "";
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
    }
    protected FindFinanceModel model;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
        if (!IsPostBack)
        {
			//model.BalanceDateTimeString = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
			//model.InsertDateTimeString = DateTime.Now.ToString("yyyy-MM-dd");
			//balanceDateTime = model.BalanceDateTimeString;
			//insertDateTime = model.InsertDateTimeString;
        }
        else
        {
            balanceDateTime = Request.Form["BeginDateTime"];
            insertDateTime = Request.Form["EndDateTime"];
            customerName = Request.Form["CustomerName"];
        }
        model.BalanceDateTimeString = balanceDateTime;
        model.InsertDateTimeString = insertDateTime;
        model.CustomerName = customerName;
    }
    #endregion

    #region Search

    protected void Search(object sender, EventArgs e)
    {
		QueryNextData(1);
    }

    #endregion

	#region 分页处理程序

	private void QueryNextData(int currentPageIndex)
	{
		Order order = new Order();

		order.BeginRow = (currentPageIndex - 1) * Constants.ROW_COUNT_FOR_PAGER + 1;
		order.EndRow = currentPageIndex * Constants.ROW_COUNT_FOR_PAGER;
		
		if (!StringUtils.IsEmpty(Request.Form["BeginDateTime"]))
		{
			order.BalanceDateTimeString = Request.Form["BeginDateTime"];
		}
		if (!StringUtils.IsEmpty(Request.Form["EndDateTime"]))
		{
			order.InsertDateTimeString = Request.Form["EndDateTime"];
		}
		if (!StringUtils.IsEmpty(Request.Form["CustomerName"]))
		{
			order.CustomerName = Request.Form["CustomerName"];
		}
		model.Order = order;
		findFinanceAction.GetCustomerPayment();

		AspNetPager1.CurrentPageIndex = currentPageIndex;
		AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
		AspNetPager1.RecordCount = model.RecordCount;
	}

	protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
	{
		QueryNextData(e.NewPageIndex);
	}

	#endregion

	#region print

	protected void Print(object sender, EventArgs e)
	{
		QueryNextData(1);
		findFinanceAction.PrintCustomerPayment();

		ReportCustomerPayment print = new ReportCustomerPayment();
		string reportFileName = "DebtCustomerPayment" + DateTime.Now.Ticks.ToString() + ".pdf";
		print.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
		print.CreateReport(model, "客户付款明细报表", "客户付款明细报表", PageSize.A4, 10, 10, 10, 10);
		Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('/reports/" + reportFileName + "', '客户付款明细报表', 1024, 1024 , false, false, null);</script>");
	}

	#endregion
}
