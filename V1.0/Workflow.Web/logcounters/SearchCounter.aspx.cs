using System;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Report.Logcounters;
/// <summary>
/// 名    称：SearchCounter
/// 功能概要:计数器查询
/// 作    者:
/// 创建时间:
/// 修正履历:张晓林
/// 修正时间:2009年4月27日9:40:01
/// 修正描述:完成查询、分页、打印 功能
/// </summary>
public partial class SearchCounter : Workflow.Web.PageBase
{
    #region //ClassMember
    private LogCountersAction logCountersAction;
    public LogCountersAction LogCountersAction
    {
        set { logCountersAction = value; }
    }
    protected LogCountersModel model;

    private string strQuery = "";
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = logCountersAction.Model;
            InitData();
            //获得页面动作
            if (!StringUtils.IsEmpty(Request.Form["txtAction"]))
            {
                if ("query" == Request.Form["txtAction"])
                {
                    queryData();
                }
                if ("print" == Request.Form["txtAction"])
                {
                    printData();
                }
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    private void InitData() 
    {
        logCountersAction.GetMachineList();
    }
    #endregion

    #region //Search
    private void queryData()
    {
        long lngMachineId = 0;
        model.DailyRecordMachine = new DailyRecordMachine();
        if (!StringUtils.IsEmpty(Request.Form["sltMachine"]))
        {
            lngMachineId=long.Parse(Request.Form["sltMachine"]);
        }
        if(-1!=lngMachineId)
        {
            model.DailyRecordMachine.Memo = lngMachineId.ToString();
        }
        if ("" != Request.Form["txtBeginDate"]) 
        {
            model.DailyRecordMachine.BeginDoWatchDateTimeString = Request.Form["txtBeginDate"];
        }
        if ("" != Request.Form["txtEndDate"])
        {
            model.DailyRecordMachine.EndDoWatchDateTimeString = Request.Form["txtEndDate"];
        }
        model.DailyRecordMachine.CurrentPageIndex = 0;
        model.DailyRecordMachine.RowCount = Constants.ROW_COUNT_FOR_PAGER;
        logCountersAction.InitDailyRecordMachineCustomQuery();

        AspNetPager1.CurrentPageIndex = 1;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.DailyRecordMachineRecordCount;

        ViewState.Add("lngMachineId", Request.Form["sltMachine"]);
        ViewState.Add("txtBeginDate", Request.Form["txtBeginDate"]);
        ViewState.Add("txtEndDate", Request.Form["txtEndDate"]);
        ViewState.Add("machineName", Request.Form["machineName"]);//保存打印条件
    }
    #endregion

    #region//Print
    private void printData() 
    {
        //model.DailyRecordMachine = new DailyRecordMachine();
        if ("" != ViewState["machineName"].ToString())
        {
            strQuery += " 机器: " + ViewState["machineName"].ToString();
        }
        if ("" != ViewState["txtBeginDate"].ToString())
        {
            strQuery+=" 抄表时间:"+ ViewState["txtBeginDate"].ToString();
        }
        if ("" != ViewState["txtEndDate"].ToString())
        {
            strQuery += " 至" + ViewState["txtEndDate"].ToString();
        }
        queryNextData(AspNetPager1.CurrentPageIndex);
        logCountersAction.GetDailyRecordMachineListCustomQueryPrint();
        ReportSearchCounter rsSearchCounter = new ReportSearchCounter();
        string reportFileName = "rsSearchCounter" + DateTime.Now.Ticks.ToString() + ".pdf";
        rsSearchCounter.QueryString += strQuery;
        rsSearchCounter.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
        rsSearchCounter.CreateReport(model, "机器数查询报表", "机器数查询报表", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '机器数查询', 1024, 1024 , false, false, null);</script>");
    }
    #endregion

    #region //分页处理程序
    private void queryNextData(int currentPageIndex) 
    {
        model.DailyRecordMachine = new DailyRecordMachine();
        if ("-1" != ViewState["lngMachineId"].ToString())
        {
            model.DailyRecordMachine.Memo =ViewState["lngMachineId"].ToString();
        }
        if ("" != ViewState["txtBeginDate"].ToString())
        {
            model.DailyRecordMachine.BeginDoWatchDateTimeString = ViewState["txtBeginDate"].ToString();
        }
        if ("" != ViewState["txtEndDate"].ToString())
        {
            model.DailyRecordMachine.EndDoWatchDateTimeString = ViewState["txtEndDate"].ToString();
        }
        model.DailyRecordMachine.CurrentPageIndex = currentPageIndex - 1;
        model.DailyRecordMachine.RowCount = Constants.ROW_COUNT_FOR_PAGER;
        logCountersAction.InitDailyRecordMachineCustomQuery();

        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.DailyRecordMachineRecordCount;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        queryNextData(e.NewPageIndex);
    }
    #endregion
}
