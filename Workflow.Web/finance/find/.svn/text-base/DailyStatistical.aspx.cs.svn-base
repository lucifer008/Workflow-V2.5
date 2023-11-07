using System;
using iTextSharp.text;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Finance.Find;
using Workflow.Support.Report.Finance;
using Workflow.Action.Finance.Find.Model;

/// <summary>
/// 功能概要: 日营业报表
/// 作    者：张晓林
/// 日    期: 2010年4月16日11:20:27
/// </summary>
public partial class finance_find_DailyStatistical : System.Web.UI.Page
{
    #region//成员变量
    protected DailyStatisticalModel model;
    private DailyStatisticalAction dailyStatisticalAction;
    public DailyStatisticalAction DailyStatisticalAction 
    {
        set { dailyStatisticalAction = value; }
    }
    #endregion

    #region //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        model = dailyStatisticalAction.Model;
        if (!IsPostBack) { InitData(); }
    }

    /// <summary>
    ///  功能：加载日统计数据
    ///  作者：张晓林
    ///  日期: 2010年4月16日11:55:20
    /// </summary>
    private void InitData() 
    {

    }
    #endregion

    #region//Search
    protected void btnSearch_ServerClick(object sender, EventArgs e)
    {
        btnSearch.Disabled = true;
        SearchDailyStatisticalInfo();
        btnSearch.Disabled = false;
    }

    /// <summary>
    /// 获取同一种业务下所有纸型的所占比例
    /// </summary>
    /// <param name="businessTypeName">业务名称</param>
    /// <returns></returns>
    /// <remarks>
    ///  作者: 张晓林
    ///  日期: 2010年5月4日13:54:45
    /// </remarks>
    protected string GetSameBusinessTypeInverse(string businessTypeName) 
    {
        string date = Convert.ToDateTime(txtBeginDateTime.Value.Trim()).ToString("yyyy-MM-dd");
        return dailyStatisticalAction.GetSameBusinessTypeInverse(businessTypeName, date);
    }
    /// <summary>
    ///  功能：日营业报表查询
    ///  作者：张晓林
    ///  日期: 2010年4月16日11:55:20
    /// </summary>
    private void SearchDailyStatisticalInfo() 
    {
        try
        {
            if ("" == txtBeginDateTime.Value.Trim()) return;
            model.DailyBusionessReportItem.Date = Convert.ToDateTime(txtBeginDateTime.Value.Trim()).ToString("yyyy-MM-dd");
            model.DailyBusionessReportItem.FileName = Server.MapPath("~") + @"\DailyBusionessReport.txt";
            dailyStatisticalAction.SearchDailyBusinessInfo();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//Print
    #endregion
    protected void btnPrint_ServerClick(object sender, EventArgs e)
    {
        try
        {
            btnPrint.Disabled = true;
            SearchDailyStatisticalInfo();
            ReportDailyStatistical rart = new ReportDailyStatistical();
            rart.Date = Convert.ToDateTime(txtBeginDateTime.Value.Trim()).ToString("yyyy-MM-dd");
            rart.QueryString = "统计日期为:"+txtBeginDateTime.Value.Trim();
            string reportFileName = "DailyStatistical" + DateTime.Now.Ticks.ToString() + ".pdf";
            rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
            rart.CreateReport(model, "日营业报表", "日营业报表", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '日营业报表', 1024, 1024 , false, false, null);</script>");
            btnPrint.Disabled = false;
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
}
