using System;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support.Report.Finance;
using iTextSharp.text;
using Workflow.Support.Log;
public partial class SearchNewAndOldCustomer : Workflow.Web.PageBase
{
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction 
    {
        set { findFinanceAction = value; }
    }
    protected FindFinanceModel model;
    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
        findFinanceAction.GetOperatorList();
        if (!IsPostBack)
        {
            model.BalanceDateTimeString = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            model.InsertDateTimeString = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else
        {
			model.BalanceDateTimeString = Request.Form["BeginDateTime"];
			model.InsertDateTimeString = Request.Form["EndDateTime"];
			model.Operator1 = Request.Form["sltSumAmount"];
			model.Operator2 = Request.Form["sltPaperCount"];
			model.Amount1 = decimal.Parse(Request.Form["SumAmount"]);
			model.Amount2 = decimal.Parse(Request.Form["PaperCount"]);
        }
    }

    protected void Search(object sender, EventArgs e)
    {
        findFinanceAction.GetNewAndOldCustomerConsumeCount();
    }

	#region Print

	protected void btnDispatchPrint_Click(object sender, EventArgs e)
	{
		try
		{
			findFinanceAction.GetNewAndOldCustomerConsumeCount();
			ReportNewAndOldCustomer rart = new ReportNewAndOldCustomer();
			string reportFileName = "PrepayNewAndOldCustomer" + DateTime.Now.Ticks.ToString() + ".pdf";
			rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

			rart.CreateReport(model, "新老客户消费统计", "新老客户消费统计", PageSize.A4, 10, 10, 10, 10);
			Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '新老客户消费统计', 1024, 1024 , false, false, null);</script>");

		}
		catch (Exception ex)
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
		}
	}

	#endregion
}
