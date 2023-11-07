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
using Workflow.Support.Report;
using iTextSharp.text;

public partial class finance_PrintVoucher : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack)
		{
			Print();
		}
	}

	private void Print()
	{
		ReportPrintVoucher printVoucher = new ReportPrintVoucher();
		//ro.IsDisplayBarCode = true;
		string reportName = "RecepPrintVoucher" + DateTime.Now.Ticks.ToString() + ".pdf";
		printVoucher.FileName = Server.MapPath("~") + @"\reports\" + reportName;
		printVoucher.CreateReport(null, "接待订单", "接待订单", PageSize.A4, 0, 0, 30, 30);
		Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script>showPage('../reports/" + reportName + "', '_blank', 1024, 1024 , false, false, null);</script>");
	}
}
