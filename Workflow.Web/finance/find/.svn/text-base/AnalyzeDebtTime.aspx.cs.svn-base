using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Workflow.Action.Finance;
using Workflow.Da.Domain;
using Workflow.Util;
using Workflow.Support.Report.Finance;
using iTextSharp.text;

public partial class FinanceAnalyzeDebtTime : Workflow.Web.PageBase
{
	protected DebtAnalyzeModel model;
	private DebtAnalyzeAction action;
	public DebtAnalyzeAction DebtAnalyzeAction
	{
		set { action = value; }
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		model = action.Model;
		model.UserName = Request.Form["UserName"];
		if (IsPostBack)
		{
			action.GetDebtAnalyze();
		}
	}

	#region print

	private void PrintDate()
	{
		ReportDebtAnalyze print = new ReportDebtAnalyze();
		string reportFileName = "DebtAnalyze" + DateTime.Now.Ticks.ToString() + ".pdf";
		print.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
		print.CreateReport(model, "帐龄分析报表", "帐龄分析报表", PageSize.A4, 10, 10, 10, 10);
		Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('/reports/" + reportFileName + "', '帐龄分析报表', 1024, 1024 , false, false, null);</script>");
	}

	#endregion

	protected void Button1_ServerClick(object sender, EventArgs e)
	{
		PrintDate();
	}
}
