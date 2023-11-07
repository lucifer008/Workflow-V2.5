using System;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support;
using Workflow.Support.Report.Finance;
using iTextSharp.text;
using Workflow.Support.Log;
public partial class SearchRepayHistory :Workflow.Web.PageBase
{
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction 
    {
        set { findFinanceAction = value; }
    }
    protected FindFinanceModel model;
    protected void Page_Load(object sender, EventArgs e)
    {
        model=findFinanceAction.Model;
        if (IsPostBack)
        {
			model.MemberCardNo = Request.Form["MemberCardNo"];
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
		model.MemberCardNo = Request.Form["MemberCardNo"];
		model.CustomerName = Request.Form["CustomerName"];
		if (string.IsNullOrEmpty(model.MemberCardNo) && string.IsNullOrEmpty(model.CustomerName))
			return;
		findFinanceAction.GetCustomerHistory();

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
			findFinanceAction.GetPrintCustomerHistory();
			ReportRepayHistory rart = new ReportRepayHistory();
			string reportFileName = "PrepayRepayHistory" + DateTime.Now.Ticks.ToString() + ".pdf";
			rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

			rart.CreateReport(model, "客户对帐表", "客户对帐表", PageSize.A4, 10, 10, 10, 10);
			Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '客户对帐表', 1024, 1024 , false, false, null);</script>");

		}
		catch (Exception ex)
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
		}
	}

	#endregion
}
