using System;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Util;
using Workflow.Support.Report.Finance;
using iTextSharp.text;
using Workflow.Support.Log;

public partial class ExceptionPriceOrderView : Workflow.Web.PageBase
{
    private FindFinanceAction action;
    public FindFinanceAction FindFinanceAction
    {
		set { action = value; }
    }
    protected FindFinanceModel model;
    protected void Page_Load(object sender, EventArgs e)
    {
		model = action.Model;
        if (!IsPostBack)
        {
            model.BalanceDateTimeString = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            model.InsertDateTimeString = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else
        {
            model.BalanceDateTimeString = Request.Form["BeginDateTime"];
			model.InsertDateTimeString = Request.Form["EndDateTime"];
			model.Operator1 = Request.Form["SltZero"];
			model.Operator2 = Request.Form["SltConcession"];
			model.Operator3 = Request.Form["sltGiveAway"];
            model.Amount1 = decimal.Parse(Request.Form["Zero"]);
            model.Amount2 = decimal.Parse(Request.Form["Concession"]);
            model.Amount3 = decimal.Parse(Request.Form["GiveAway"]);
            model.CustomerName = Request.Form["CustomerName"];
        }
    }
    protected void Search(object sender, EventArgs e)
    {
		QueryNextPageData(1);
    }

	#region 分页处理程序

	protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
	{
		QueryNextPageData(e.NewPageIndex);
	}


	private void QueryNextPageData(int currentPageIndex)
	{
		model.BeginRow = (currentPageIndex - 1) * Constants.ROW_COUNT_FOR_PAGER + 1;
		model.EndRow = currentPageIndex * Constants.ROW_COUNT_FOR_PAGER;

		action.GetExceptionPriceOrdersCount();

		AspNetPager1.CurrentPageIndex = currentPageIndex;
		AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
		AspNetPager1.RecordCount = model.RecordCount;
	}

	#endregion

	#region Print

	protected void btnDispatchPrint_Click(object sender, EventArgs e)
	{
		try
		{
			QueryNextPageData(1);
			action.PrintExceptionPriceOrders();
			ReportExceptionPriceOrders rart = new ReportExceptionPriceOrders();
			string reportFileName = "PrepayExceptionPriceOrders" + DateTime.Now.Ticks.ToString() + ".pdf";
			rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

			rart.CreateReport(model, "异常价格订单汇总", "异常价格订单汇总", PageSize.A4, 10, 10, 10, 10);
			Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '异常价格订单汇总', 1024, 1024 , false, false, null);</script>");

		}
		catch (Exception ex)
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
		}
	}

	#endregion
}


