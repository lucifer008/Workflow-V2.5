using System;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Support.Report.Finance;
using Workflow.Action.Finance.Model;
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
    #region Class Member

    //private string pStrQueryString="";
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
		model.Order = new Order();
		if (!IsPostBack)
		{
			// 默认查询当前月的所有数据
			model.Order.BeginBalanceDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-01";
			model.Order.EndBalanceDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-30";
			
		}
    }
    #endregion

    #region Search

    protected void Search(object sender, EventArgs e)
    {
		QueryNextPageData(1);
    }
    #endregion

    #region 分页处理程序

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }

    protected void QueryNextPageData(int currentPageIndex)
    {
		model.Order.BeginRow = (currentPageIndex - 1) * Constants.ROW_COUNT_FOR_PAGER + 1;
		model.Order.EndRow = currentPageIndex * Constants.ROW_COUNT_FOR_PAGER;

        if (!string.IsNullOrEmpty(Request.Form["CustomerName"]))
			model.Order.CustomerName = string.Format("%{0}%", Request.Form["CustomerName"]);

		if (!string.IsNullOrEmpty(Request.Form["txtBeginDateTime"]))
			model.Order.BeginBalanceDate = Request.Form["txtBeginDateTime"];

		if (!string.IsNullOrEmpty(Request.Form["txtTo"]))
			model.Order.EndBalanceDate = Request.Form["txtTo"];

		if (!string.IsNullOrEmpty(Request.Form["orderNo"]))
			model.Order.No = string.Format("%{0}%", Request.Form["orderNo"]); 

        findFinanceAction.GetCustomerPrepay();

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
			findFinanceAction.GetPrintPrepay();
			ReportPrepay rart = new ReportPrepay();
			//rart.QueryString += pStrQueryString;
			string reportFileName = "PrepayTotal" + DateTime.Now.Ticks.ToString() + ".pdf";
			rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

			rart.CreateReport(findFinanceAction.Model, "预付款查询", "预付款查询", PageSize.A4, 10, 10, 10, 10);
			Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '预付款查询', 1024, 1024 , false, false, null);</script>");
			
		}
		catch (Exception ex)
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
		}
	}

	#endregion
}
