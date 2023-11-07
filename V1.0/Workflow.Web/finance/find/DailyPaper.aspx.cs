using System;
using iTextSharp.text;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Finance;
using Workflow.Action.Achievement;
using Workflow.Support.Report.Finance;
using Workflow.Action;

/// <summary>
/// 名    称: DailyPaper
/// 功能概要: 日报
/// 作    者: 张晓林
/// 创建时间: 2008-12-01
/// 修正履历: 
/// 修正时间: 
/// 描    述:查询条件:开始日期(t1)-结束日期(t2)
///         当t1不为空且t2不为空时， 查询的记录为:t1到t2的记录(不包括t2的记录)
///         当t1不为空且t2为空时，查询的记录为t1的记录
///         当t1为空且t2不为空时，查询的记录为:t2-1的记录(不包括t2的记录)
/// </summary>

public partial class finance_find_DailyPaper : System.Web.UI.Page
{
	#region //Class Member

    private CashHandOverAction cashHandOverAction;
    public CashHandOverAction CashHandOverAction
    {
        set{cashHandOverAction=value;}
    }

    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
        get { return findFinanceAction; }
    }
    protected string pStrQueryString="";
    protected OrderModel model;
	#endregion

	#region //Page_Load

	protected void Page_Load(object sender, EventArgs e)
	{
        model = findFinanceAction.OrderModel;
		try
		{
            if (!IsPostBack) 
            {
                cashHandOverAction.Model.HandOverDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                ViewState.Add("BeginDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
                ViewState.Add("EndDateTime", DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd"));
                QueryNextPageData(1);
            }
		}
		catch (Exception ex)
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
			//throw ex;
		}
	}
	#endregion

    #region //Search
    protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
        {
            string strBeginDateTime=txtBeginDateTime.Value.Trim();
            string strEndDateTime=txtEndDateTime.Value.Trim();

            if ("" != strBeginDateTime)
            {
                //开始交班时间
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strBeginDateTime).ToString("yyyy-MM-dd");
                model.NewOrder.CurrentHandOverBeginDate = cashHandOverAction.DailyPaperMinHandOverDateTime;
            }
            else  /*查询条件：开始日期为空，但结束日期不为空,得到的记录为结束日期这一天的记录*/
            {
                if ("" != strEndDateTime)
                {
                    
                    cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strEndDateTime).AddDays(-1).ToString("yyyy-MM-dd");
                    model.NewOrder.CurrentHandOverBeginDate = cashHandOverAction.DailyPaperMinHandOverDateTime;
                }
            }

            if ("" != strEndDateTime)
            {
                //结束交班时间
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strEndDateTime).ToString("yyyy-MM-dd");
                model.NewOrder.CurrentHandOverEndDate = cashHandOverAction.DailyPaperMinHandOverDateTime;
            }
            else 
            {
                /*查询条件：开始日期不为空，但结束日期为空,得到的记录为开始记录起这一天的记录*/
                if ("" != strBeginDateTime)
                {
                    //当查询的开始日期为当前日期做特殊处理
                    if (Convert.ToDateTime(strBeginDateTime).ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        model.NewOrder.CurrentHandOverEndDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strBeginDateTime).AddDays(+1).ToString("yyyy-MM-dd");
                        model.NewOrder.CurrentHandOverEndDate = cashHandOverAction.DailyPaperMinHandOverDateTime;
                    }
                }
            }

            this.AspNetPager1.CurrentPageIndex = 1;
            findFinanceAction.SearchDailyPaperOrder(0);
            this.AspNetPager1.RecordCount = (int)model.NeedPrePayOrdersCount;//(int)findFinanceAction.SearchDailyPaperRowCount();//总记录数
            this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;//每页显示条数

            ViewState.Add("BeginDateTime", model.NewOrder.CurrentHandOverBeginDate);
            ViewState.Add("EndDateTime", model.NewOrder.CurrentHandOverEndDate);
		}
		catch (Exception ex) 
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
			//throw ex;
		}
    }
    #endregion

    #region //分页处理程序
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }

    protected void QueryNextPageData(int currentPageIndex)
    {
        try
        {
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["BeginDateTime"])))
            {
                model.NewOrder.CurrentHandOverBeginDate = ViewState["BeginDateTime"].ToString();
            }
            else 
            {
                cashHandOverAction.Model.HandOverDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                model.NewOrder.CurrentHandOverBeginDate = cashHandOverAction.DailyPaperMinHandOverDateTime;
            }

            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["EndDateTime"])))
            {
                model.NewOrder.CurrentHandOverEndDate = ViewState["EndDateTime"].ToString();
            }
            else 
            {
               model.NewOrder.CurrentHandOverEndDate = DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd");
            }

            findFinanceAction.SearchDailyPaperOrder(currentPageIndex - 1);
            this.AspNetPager1.CurrentPageIndex = currentPageIndex;
            this.AspNetPager1.RecordCount = (int)model.NeedPrePayOrdersCount;//总记录数
            this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;//每页显示条数
            ViewState.Add("BeginDateTime", model.NewOrder.CurrentHandOverBeginDate);
            ViewState.Add("EndDateTime", model.NewOrder.CurrentHandOverEndDate);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
             throw ex;
        }
    }
    #endregion

    #region //Print
    protected void btnDispatchPrint_Click(object sender, EventArgs e)
	{
		try
		{
            pStrQueryString = "";
            if (null != ViewState["BeginDateTime"] && "" != ViewState["BeginDateTime"].ToString())
            {
                model.NewOrder.CurrentHandOverBeginDate = ViewState["BeginDateTime"].ToString();
                pStrQueryString = "结算日期 " + Convert.ToDateTime(ViewState["BeginDateTime"].ToString()).ToString("yyyy-MM-dd HH:mm");  
            }

            if (null != ViewState["EndDateTime"] && "" != ViewState["EndDateTime"].ToString()) 
            {
                model.NewOrder.CurrentHandOverEndDate = ViewState["EndDateTime"].ToString();
                pStrQueryString += "至 " + Convert.ToDateTime(ViewState["EndDateTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
            }
            findFinanceAction.SearchDailyPaperOrder_ToPrint();
            ReportDailyPaper rart = new ReportDailyPaper();
            rart.QueryString += pStrQueryString;
            string reportFileName = "DailyPaper" + DateTime.Now.Ticks.ToString() + ".pdf";
            rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

            rart.CreateReport(model, "日报", "日报", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '日报', 1024, 1024 , false, false, null);</script>");
            QueryNextPageData(AspNetPager1.CurrentPageIndex);

            ViewState.Add("BeginDateTime", model.NewOrder.CurrentHandOverBeginDate);
            ViewState.Add("EndDateTime", model.NewOrder.CurrentHandOverEndDate);
		}
		catch (Exception ex)
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
			//throw ex;
		}
    }
    #endregion
}
