
using System;
using iTextSharp.text;
using Workflow.Support;
using Workflow.Action.Model;
using Workflow.Support.Log;
using Workflow.Support.Report;
using Workflow.Action.Finance;

/// <summary>
/// 名    称: AccountReceivableAccordingToTimeSectTotal
/// 功能概要: 应收款按时间段合计
/// 作    者: 张晓林
/// 创建时间: 2008-11-26
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class finance_find_AccountReceivableAccordingToTimeSectTotal : System.Web.UI.Page
{

	#region Class Member
    protected OrderModel model;
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
        get { return findFinanceAction; }
    }

	private string pStrQueryString="查询条件 ";
	#endregion

	#region Page_Load

	protected void Page_Load(object sender, EventArgs e)
	{
        model = findFinanceAction.OrderModel;
        if (!IsPostBack)
        {
            // 默认查询当前月的所有数据
            //string strNowBeginDate =DateTime.Now.Year+"-"+DateTime.Now.Month+"-01";
            //string strNowEndDate =DateTime.Now.Year + "-" + DateTime.Now.Month + "-31";
            //ViewState.Add("BeginBalanceDate", strNowBeginDate);
            //ViewState.Add("EndBalanceDate", strNowEndDate);
            QueryNextPageData(1);
        }
	}
	#endregion

	#region Search

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
            findFinanceAction.OrderModel.NewOrder.CustomerName = Request.Form["CustomerName"];
            findFinanceAction.OrderModel.NewOrder.BeginBalanceDate = Request.Form["txtBeginDateTime"];
            findFinanceAction.OrderModel.NewOrder.EndBalanceDate = Request.Form["txtTo"];
           this.AspNetPager1.CurrentPageIndex = 1;
           findFinanceAction.SearchAccountReceivableAccordingToTime(this.AspNetPager1.CurrentPageIndex - 1);
           this.AspNetPager1.RecordCount = (int)findFinanceAction.GetSearchAccountReceviableInfoCount();//总记录数
           this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;//每页显示条数
           ViewState.Add("CustomerName", Request.Form["CustomerName"]);
           ViewState.Add("BeginBalanceDate", Request.Form["txtBeginDateTime"]);
           ViewState.Add("EndBalanceDate", Request.Form["txtTo"]);
           ViewState.Add("currentPageIndex", this.AspNetPager1.CurrentPageIndex);
		}
		catch (Exception ex)
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
			//throw ex;
		}
	}

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }

    protected void QueryNextPageData(int currentPageIndex)
    {
        try
        {
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["CustomerName"])))
            {
                findFinanceAction.OrderModel.NewOrder.CustomerName = ViewState["CustomerName"].ToString();
            }

            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["BeginBalanceDate"])))
            {
                findFinanceAction.OrderModel.NewOrder.BeginBalanceDate = ViewState["BeginBalanceDate"].ToString();
            }

            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["EndBalanceDate"])))
            {
                findFinanceAction.OrderModel.NewOrder.EndBalanceDate = ViewState["EndBalanceDate"].ToString();
            }

            findFinanceAction.SearchAccountReceivableAccordingToTime(currentPageIndex - 1);
            this.AspNetPager1.RecordCount = (int)findFinanceAction.GetSearchAccountReceviableInfoCount();//总记录数
            this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;//每页显示条数
            ViewState.Add("CustomerName", ViewState["CustomerName"]);
            ViewState.Add("BeginBalanceDate", ViewState["BeginBalanceDate"]);
            ViewState.Add("EndBalanceDate", ViewState["EndBalanceDate"]);
            ViewState.Add("currentPageIndex", currentPageIndex.ToString());
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
        }
    }
	#endregion

	#region Print
	protected void btnDispatchPrint_Click(object sender, EventArgs e)
	{
		try
		{
			SearchAccountReceviableInfo();
			ReportAccountReceivableTotal rart = new ReportAccountReceivableTotal();
			rart.QueryString += pStrQueryString;
			string reportFileName="AccountReceivableTotal"+DateTime.Now.Ticks.ToString()+".pdf";
            rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

            rart.CreateReport(findFinanceAction.OrderModel, "应收款按照时间段合计", "应收款按照时间段合计", PageSize.A4, 10, 10, 10, 10);
			Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '应收款按照时间段合计', 1024, 1024 , false, false, null);</script>");
           QueryNextPageData(Convert.ToInt32(ViewState["currentPageIndex"]));
		}
		catch(Exception ex)
		{
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
		}
	}
	
	private void SearchAccountReceviableInfo() 
	{
        pStrQueryString = "";
        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["CustomerName"])))
		{
            findFinanceAction.OrderModel.NewOrder.CustomerName = ViewState["CustomerName"].ToString();
            pStrQueryString += " 顾客姓名: " + ViewState["CustomerName"].ToString();
		}

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["BeginBalanceDate"])))
		{
            findFinanceAction.OrderModel.NewOrder.BeginBalanceDate = ViewState["BeginBalanceDate"].ToString();
            pStrQueryString += " 开始日期: " + ViewState["BeginBalanceDate"].ToString();
		}

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["EndBalanceDate"])))
		{
            findFinanceAction.OrderModel.NewOrder.EndBalanceDate = ViewState["EndBalanceDate"].ToString();
            pStrQueryString += " 结束日期: " + ViewState["EndBalanceDate"].ToString();
		}
        findFinanceAction.SearchAllAccountReceviable();
	}
    #endregion
}