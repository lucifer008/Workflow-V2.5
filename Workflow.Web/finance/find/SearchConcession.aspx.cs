using System;
using iTextSharp.text;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support.Report.Finance;

/// <summary>
/// 名    称: SearchConcession
/// 功能概要: 优惠查询
/// 作    者: 张晓林
/// 创建时间: 2009年5月20日13:52:56
/// 修正履历: 
/// 修正时间: 
/// 描    述:查询条件:开始日期(t1)-结束日期(t2)
///         当t1不为空且t2不为空时， 查询的记录为:t1到t2的记录(不包括t2的记录)
///         当t1不为空且t2为空时，查询的记录为t1的记录
///         当t1为空且t2不为空时，查询的记录为:t2-1的记录(不包括t2的记录)
/// </summary>
public partial class finance_find_SearchConcession : System.Web.UI.Page
{
    #region//ClassMember
    protected FindFinanceModel model;
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
    }
    #endregion

    #region//Page_load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
        if (!IsPostBack)
        {
            cashHandOverAction.Model.HandOverDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            ViewState.Add("BeginDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
            QueryNextPageData(1);
        }
        else
        {
            int dateDiff = Convert.ToInt16(hidDate.Value);
            if (999 != dateDiff) DateNavigateQuery(dateDiff);
        }
    }

    /// <summary>
    /// 按照日期导航时间过滤
    /// </summary>
    /// <remarks>
    /// 作    者: 张晓林
    /// 创建时间: 2010年7月9日9:18:19
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void DateNavigateQuery(int day) 
    {
        string acTag = actionTag.Value;
        bool isNotCurrentMonth = false;
        if ("T" != acTag)
        {
            if (-30 == day)
            {
                isNotCurrentMonth = true;
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM") + "-01").ToString("yyyy-MM-dd");
                ViewState.Add("BeginDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);

                cashHandOverAction.Model.HandOverDateTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                ViewState.Add("EndDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
            }
            else
            {
                if (day < -2)
                {
                    cashHandOverAction.Model.HandOverDateTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                    ViewState.Add("EndDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
                }
                else
                {
                    cashHandOverAction.Model.HandOverDateTime = DateTime.Now.AddDays(day + 1).ToString("yyyy-MM-dd");
                    ViewState.Add("EndDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
                }
            }
        }
        else
        {
            cashHandOverAction.Model.HandOverDateTime = DateTime.Now.AddDays(day + 1).ToString("yyyy-MM-dd");
            ViewState.Add("EndDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
        }
        if (!isNotCurrentMonth)
        {
            cashHandOverAction.Model.HandOverDateTime = DateTime.Now.AddDays(day).ToString("yyyy-MM-dd");
            ViewState.Add("BeginDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
        }


        ViewState["OrderNo"] = null;
        QueryNextPageData(1);
    }
    #endregion

    #region//Query
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string strBeginDateTime = txtBeginDateTime.Value.Trim();
            string strEndDateTime = txtEndDateTime.Value.Trim();
            if ("" != txtOrderNo.Value.Trim())
            {
                model.PaymentConcession.OrderNo = txtOrderNo.Value;
            }

            #region//时间段
            if ("" != strBeginDateTime)
            {
                //开始交班时间
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strBeginDateTime).ToString("yyyy-MM-dd");
                model.PaymentConcession.BeiginDateTimeString = cashHandOverAction.DailyPaperMinHandOverDateTime;
            }
            else //开始日期为空
            {
                if ("" != strEndDateTime)
                {
                    //开始交班时间
                    cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strEndDateTime).AddDays(-1).ToString("yyyy-MM-dd");
                    model.PaymentConcession.BeiginDateTimeString = cashHandOverAction.DailyPaperMinHandOverDateTime;
                }
            }
            if ("" != strEndDateTime)
            {
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strEndDateTime).ToString("yyyy-MM-dd");
                model.PaymentConcession.EndDateTimeString = cashHandOverAction.DailyPaperMinHandOverDateTime;
            }
            else //结束日期为空
            {
                if ("" != strBeginDateTime)//开始日期不为空
                {
                    cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strBeginDateTime).AddDays(+1).ToString("yyyy-MM-dd");
                    model.PaymentConcession.EndDateTimeString = cashHandOverAction.DailyPaperMinHandOverDateTime;
                }

            }
            #endregion

            model.PaymentConcession.CurrentPageIndex = 0;
            model.PaymentConcession.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            findFinanceAction.SearchConcession();

            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(model.Operator1);

            ViewState.Add("OrderNo", model.PaymentConcession.OrderNo);
            ViewState.Add("BeginDateTime", model.PaymentConcession.BeiginDateTimeString);
            ViewState.Add("EndDateTime", model.PaymentConcession.EndDateTimeString);
            hidDate.Value = "999";
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        try
        {
            if (null != ViewState["OrderNo"] && "" != ViewState["OrderNo"].ToString())
            {
                model.PaymentConcession.OrderNo = ViewState["OrderNo"].ToString();
            }
            if (null != ViewState["BeginDateTime"] && "" != ViewState["BeginDateTime"].ToString())
            {
                model.PaymentConcession.BeiginDateTimeString = ViewState["BeginDateTime"].ToString();
            }
            if (null != ViewState["EndDateTime"] && "" != ViewState["EndDateTime"].ToString())
            {
                model.PaymentConcession.EndDateTimeString = ViewState["EndDateTime"].ToString();
            }

            model.PaymentConcession.CurrentPageIndex = currentPageIndex - 1;
            model.PaymentConcession.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            findFinanceAction.SearchConcession();

            AspNetPager1.CurrentPageIndex = currentPageIndex;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(model.Operator1);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion

    #region//Print
    protected void btnDispatchPrint_Click(object sender, EventArgs e)
    {
        try
        {
            string pStrQueryString = "";
            if (null != ViewState["OrderNo"] && "" != ViewState["OrderNo"].ToString())
            {
                pStrQueryString+= "订单号 " + ViewState["OrderNo"].ToString();
            }
            if (null != ViewState["BeginDateTime"] && "" != ViewState["BeginDateTime"].ToString())
            {
                pStrQueryString+= " 结算日期 " + Convert.ToDateTime(ViewState["BeginDateTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
            }

            if (null != ViewState["EndDateTime"] && "" != ViewState["EndDateTime"].ToString())
            {
                pStrQueryString += "至 " + Convert.ToDateTime(ViewState["EndDateTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
            }
            QueryNextPageData(AspNetPager1.CurrentPageIndex);
            ReportSearchConcession rart = new ReportSearchConcession();
            rart.QueryString += pStrQueryString;
            string reportFileName = "SearchConcession" + DateTime.Now.Ticks.ToString() + ".pdf";
            rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

            rart.CreateReport(model, "优惠查询", "优惠查询", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '优惠查询', 1024, 1024 , false, false, null);</script>");
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    #endregion
}
