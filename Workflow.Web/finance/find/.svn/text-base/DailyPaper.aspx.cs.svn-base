using System;
using iTextSharp.text;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Finance;
using Workflow.Action.Achievement;
using Workflow.Support.Report.Finance;

/// <summary>
/// 名    称: DailyPaper
/// 功能概要: 日报
/// 作    者: 张晓林
/// 创建时间: 2008-12-01
/// 修正履历: 
/// 修正时间: 
/// 描    述: 2010年4月26-张晓林-添加查询条件查询类型         
/// </summary>

public partial class finance_find_DailyPaper : System.Web.UI.Page
{
	#region //Class Member
    private string pStrQueryString;
    private string strEndDateTime;
    private string strBeginDateTime;
    protected OrderModel model;
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
	#endregion

	#region //Page_Load
	protected void Page_Load(object sender, EventArgs e)
	{
        model = findFinanceAction.OrderModel;
		try
		{
            if (!IsPostBack)
            {
                BingData();
                cashHandOverAction.Model.HandOverDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                ViewState.Add("BeginDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
                ViewState.Add("EndDateTime", DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd"));
                QueryNextPageData(1);
            }
            else 
            {
                int date = Convert.ToInt16(hidDate.Value);
                if (date != 999) QueryDataByDate(date);
            }
		}
		catch (Exception ex)
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
		    throw ex;
		}
	}
    private void BingData() 
    {
        System.Web.UI.WebControls.ListItem listItemSetDate = new System.Web.UI.WebControls.ListItem();
        System.Web.UI.WebControls.ListItem listItemHandOver = new System.Web.UI.WebControls.ListItem();

        listItemSetDate.Text = Constants.ACCORDING_TO_SET_DATE_QUERY_LABEL;
        listItemHandOver.Text =Constants.ACCORDING_TO_HAND_OVER_DATE_QUERY_LABEL;
        listItemSetDate.Value =Constants.ACCORDING_TO_SET_DATE_QUERY_VALUE.ToString();
        listItemHandOver.Value =Constants.ACCORDING_TO_HAND_OVER_DATE_QUERY_VALUE.ToString();

        sltQueryType.Items.Add(listItemHandOver);
        sltQueryType.Items.Add(listItemSetDate);
        
    }

    /// <summary>
    /// 日期选项卡数据过滤
    /// </summary>
    /// <param name="dayDiff">日期时间差</param>
    /// <remarks>
    /// 功    能: 张晓林
    /// 创建时间: 2010年7月13日10:35:22
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void QueryDataByDate(int dayDiff) 
    {
        string acTag = actionTag.Value;
        bool isNotCurrentMonth = false;
        if ("T" != acTag)
        {
            if (-30 == dayDiff)
            {
                isNotCurrentMonth = true;
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM") + "-01").ToString("yyyy-MM-dd");
                ViewState.Add("BeginDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);

                cashHandOverAction.Model.HandOverDateTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                ViewState.Add("EndDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
            }
            else
            {
                if (dayDiff < -2)
                {
                    cashHandOverAction.Model.HandOverDateTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                    ViewState.Add("EndDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
                }
                else
                {
                    cashHandOverAction.Model.HandOverDateTime = DateTime.Now.AddDays(dayDiff + 1).ToString("yyyy-MM-dd");
                    ViewState.Add("EndDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
                }
            }
        }
        else
        {
            cashHandOverAction.Model.HandOverDateTime = DateTime.Now.AddDays(dayDiff + 1).ToString("yyyy-MM-dd");
            ViewState.Add("EndDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
        }
        if (!isNotCurrentMonth)
        {
            cashHandOverAction.Model.HandOverDateTime = DateTime.Now.AddDays(dayDiff).ToString("yyyy-MM-dd");
            ViewState.Add("BeginDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
        }

        QueryNextPageData(1);
    }
	#endregion

    #region //Search
    protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
        {
            btnSearch.Enabled = false;
            string strQueryType = sltQueryType.Value;
            strEndDateTime = txtEndDateTime.Value.Trim();
            strBeginDateTime=txtBeginDateTime.Value.Trim();
            switch(strQueryType)
            {
                case "1":
                    AccordingToHandOverDateQuery();
                    break;
                case "2":
                    AccordingToSetDateTimeQuery();
                    break;
            }
            this.AspNetPager1.CurrentPageIndex = 1;
            findFinanceAction.SearchDailyPaperOrder(0);
            this.AspNetPager1.RecordCount = (int)model.NeedPrePayOrdersCount;
            this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;//每页显示条数

            ViewState.Add("BeginDateTime", model.NewOrder.CurrentHandOverBeginDate);
            ViewState.Add("EndDateTime", model.NewOrder.CurrentHandOverEndDate);
            btnSearch.Enabled = true;
		}
		catch (Exception ex) 
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
			throw ex;
		}
    }

    /// <summary>
    /// 功能: 按照交班日期查询
    /// </summary>
    /// <remarks>
    /// 作者: 张晓林
    /// 日期: 2010年4月26日14:48:51
    /// </remarks>
    private void AccordingToHandOverDateQuery() 
    {
        string handOverDateStart = null;
        string handOverDateEnd = null;
        if ("" != strBeginDateTime && ""==strEndDateTime)
        {
            cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strBeginDateTime).ToString("yyyy-MM-dd");
            handOverDateStart = cashHandOverAction.DailyPaperMinHandOverDateTime;
            cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strBeginDateTime).AddDays(+1).ToString("yyyy-MM-dd");
            handOverDateEnd = cashHandOverAction.DailyPaperMinHandOverDateTime;
        }
        if(""==strBeginDateTime && ""!=strEndDateTime)
        {
            cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strEndDateTime).AddDays(-1).ToString("yyyy-MM-dd");
            handOverDateStart = cashHandOverAction.DailyPaperMinHandOverDateTime;
            cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strEndDateTime).ToString("yyyy-MM-dd");
            handOverDateEnd = cashHandOverAction.DailyPaperMinHandOverDateTime;
        }
        if ("" != strBeginDateTime && "" != strEndDateTime)
        {
            cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strBeginDateTime).ToString("yyyy-MM-dd");
            handOverDateStart = cashHandOverAction.DailyPaperMinHandOverDateTime;
            cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strEndDateTime).ToString("yyyy-MM-dd");
            handOverDateEnd = cashHandOverAction.DailyPaperMinHandOverDateTime;

        }
        model.NewOrder.CurrentHandOverBeginDate = handOverDateStart;
        model.NewOrder.CurrentHandOverEndDate = handOverDateEnd;
    }

    /// <summary>
    /// 按照设置日期查询
    /// </summary>
    /// <remarks>
    /// 作者：张晓林
    /// 日期: 2010年4月26日14:50:13
    /// </remarks>
    private void AccordingToSetDateTimeQuery() 
    {
        string setDateTimeStart=null;
        string setDateTimeEnd =null;
        string workStartDateTime = cashHandOverAction.WorkStartDateTime;
        string workEndDateTime = cashHandOverAction.WorkEndDateTime;
        if ("" != strBeginDateTime && "" == strEndDateTime) 
        {
            setDateTimeStart = Convert.ToDateTime(strBeginDateTime).ToString("yyyy-MM-dd") + " " + workStartDateTime;
            setDateTimeEnd = Convert.ToDateTime(strBeginDateTime).ToString("yyyy-MM-dd") + " " + workEndDateTime;
        }
        if ("" == strBeginDateTime && "" != strEndDateTime)
        {
            setDateTimeStart = Convert.ToDateTime(strEndDateTime).ToString("yyyy-MM-dd") + " " + workStartDateTime;
            setDateTimeEnd = Convert.ToDateTime(strEndDateTime).ToString("yyyy-MM-dd") + " " + workEndDateTime;
        }
        if ("" != strBeginDateTime && "" != strEndDateTime)
        {
            setDateTimeStart = Convert.ToDateTime(strBeginDateTime).ToString("yyyy-MM-dd") + " " + workStartDateTime;
            setDateTimeEnd = Convert.ToDateTime(strEndDateTime).ToString("yyyy-MM-dd") + " " + workEndDateTime;
        }
        model.NewOrder.CurrentHandOverBeginDate = setDateTimeStart;
        model.NewOrder.CurrentHandOverEndDate = setDateTimeEnd;
        
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
            pStrQueryString = "查询类型:";
            if ("1" == sltQueryType.Value) pStrQueryString = "以交班时间查询 ";
            else pStrQueryString = "以设置时间查询 ";
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["BeginDateTime"])))
            {
                model.NewOrder.CurrentHandOverBeginDate = ViewState["BeginDateTime"].ToString();
                pStrQueryString += "结算日期 " + Convert.ToDateTime(ViewState["BeginDateTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
            }
            else
            {
                cashHandOverAction.Model.HandOverDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                model.NewOrder.CurrentHandOverBeginDate = cashHandOverAction.DailyPaperMinHandOverDateTime;
            }

            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["EndDateTime"])))
            {
                model.NewOrder.CurrentHandOverEndDate = ViewState["EndDateTime"].ToString();
                pStrQueryString += "至 " + Convert.ToDateTime(ViewState["EndDateTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
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
            btnDispatchPrint.Enabled = false;
            model.IsAccounting = true;
            QueryNextPageData(AspNetPager1.CurrentPageIndex);
            ReportDailyPaper rart = new ReportDailyPaper();
            rart.QueryString += pStrQueryString;
            string reportFileName = "DailyPaper" + DateTime.Now.Ticks.ToString() + ".pdf";
            rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

            rart.CreateReport(model, "日报", "日报", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '日报', 1024, 1024 , false, false, null);</script>");

            ViewState.Add("BeginDateTime", model.NewOrder.CurrentHandOverBeginDate);
            ViewState.Add("EndDateTime", model.NewOrder.CurrentHandOverEndDate);
            btnDispatchPrint.Enabled = true;
		}
		catch (Exception ex)
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
		    throw ex;
		}
    }
    #endregion
}
