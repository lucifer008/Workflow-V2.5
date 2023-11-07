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
using Workflow.Action.LogCounters;
using Workflow.Support.Report.Logcounters;
using iTextSharp.text;
/// <summary>
/// 名    称：SearchCounter
/// 功能概要: 计数器查询结果
/// 作    者: 陈汝胤
/// 创建时间: 2009.12.17
/// </summary>
public partial class logcounters_SearchResult : System.Web.UI.Page
{
	protected SearchCounterModel model;
	private SearchCounterAction action;
	public SearchCounterAction SearchCounterAction
	{
		set { action = value; }
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		model = action.Model;
		model.RecordMachineWatchId = long.Parse(Request.QueryString["id"]);
		action.GetRecordMachineWatchResult();
		if(IsPostBack)
			PrintDate();
	}

	#region print

	private void PrintDate()
	{
		ReportSearchCounter rsSearchCounter = new ReportSearchCounter();
		string reportFileName = "rsSearchCounter" + DateTime.Now.Ticks.ToString() + ".pdf";
		rsSearchCounter.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
		rsSearchCounter.CreateReport(model, "计数器查询报表", "计数器查询报表", PageSize.A4, 10, 10, 10, 10);
		Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '机器数查询', 1024, 1024 , false, false, null);</script>");
	} 
	#endregion

}
