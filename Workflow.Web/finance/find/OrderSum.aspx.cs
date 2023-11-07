using System;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support;
using Workflow.Support.Report.Finance;
using iTextSharp.text;
public partial class FinanceFindOrderSum : Workflow.Web.PageBase
{
    private string balanceDateTime = "";
    private string insertDateTime = "";
    public FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
    }
    protected FindFinanceModel model;
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
        }
        model.BalanceDateTimeString = balanceDateTime;
        model.InsertDateTimeString = insertDateTime;
    }
    protected void Search(object sender, EventArgs e)
    {
		QueryNextData(1);
    }

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
		model.Order = order;
		findFinanceAction.GetCustomerConsume();

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

		findFinanceAction.PrintCustomerConsume();

		ReportOrderSum print = new ReportOrderSum();
		string reportFileName = "DebtOrderSum" + DateTime.Now.Ticks.ToString() + ".pdf";
		print.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
		print.CreateReport(model, "客户消费统计报表", "客户消费统计报表", PageSize.A4, 10, 10, 10, 10);
		Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('/reports/" + reportFileName + "', '客户消费统计报表', 1024, 1024 , false, false, null);</script>");
	}

	#endregion

}
