using System;
using iTextSharp.text;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support.Report.Finance;

/// <summary>
/// 名    称: MonthPaper
/// 功能概要: 月报
/// 作    者: 张晓林
/// 创建时间: 2008-12-9
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class finance_find_MonthPaper : System.Web.UI.Page
{
    #region //Class Member

    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
        get { return findFinanceAction; }
    }

    private CashHandOverAction cashHandOverAction;
    public CashHandOverAction CashHandOverAction 
    {
        set { cashHandOverAction = value; }
        get { return cashHandOverAction; }
    }
    protected string pStrQueryString = "";
    protected FindFinanceModel model;
    #endregion

    #region //Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
        if (!IsPostBack)
        {
            //add by baixiaoyu 2010-07-14
            //年度汇总 点击详情到 月报
            if (null != Request.QueryString["dt"])
            {
                    txtMonthPaperDateTime.Value = Request.QueryString["dt"];
            }
        }

    }
    #endregion

    #region //Search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if ("" != Request.Form["txtMonthPaperDateTime"])
            {
                ViewState.Add("InsertDateTime", Request.Form["txtMonthPaperDateTime"]);
            }
            else 
            {
                ViewState.Add("InsertDateTime",DateTime.Now);
            } 
        }
        catch (Exception ex)
        {
            Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    #endregion

    #region //Print
    protected void btnDispatchPrint_Click(object sender, EventArgs e)
    {
        try
        {
            pStrQueryString = "";
            FindFinanceModel fModel = new FindFinanceModel();
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["InsertDateTime"])))
            {
                pStrQueryString = "结算月份 " + Convert.ToDateTime(ViewState["InsertDateTime"]).ToString("yyyy-MM");
                fModel.Operator3 = ViewState["InsertDateTime"].ToString();
            }
            else 
            {
                pStrQueryString = "结算月份 " + DateTime.Now.ToString("yyyy-MM");
                fModel.Operator3 = DateTime.Now.ToString("yyyy-MM-dd");
            }
            fModel.FindFinanceAction = findFinanceAction;
            fModel.CashHandOverAction = cashHandOverAction;
            ReportMonthPaper rart = new ReportMonthPaper();
            rart.QueryString += pStrQueryString;
            string reportFileName = "MonthPaper" + DateTime.Now.Ticks.ToString() + ".pdf";
            rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

            rart.CreateReport(fModel, "月报", "月报", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '月报', 1024, 1024 , false, false, null);</script>");
            ViewState.Add("InsertDateTime", ViewState["InsertDateTime"]);
        }
        catch (Exception ex)
        {
            Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    #endregion
   
}
