using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Util;
using iTextSharp.text;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Employee;
using Workflow.Action.Achievement;
using Workflow.Action.Achievement.Model;
using Workflow.Support.Report.Achievement;

/// <summary>
/// 名    称: SearchAchievement
/// 功能概要: 绩效查询
/// 作    者: 付强
/// 创建时间:2008-11-2
/// 修正履历: 张晓林
/// 修正时间:  2009-01-05
///             完成查询；打印；分页功能
/// </summary>
public partial class SearchAchievement : System.Web.UI.Page
{

    #region //Class Member
    private SearchAchievementAction searchAchievementAction;
    public SearchAchievementAction SearchAchievementAction
    {
        set { searchAchievementAction = value; }
    }
    protected AdjustAchievementModel model;
    private EmployeeAction employeeAction;
    public EmployeeAction EmployeeAction 
    {
        set { employeeAction = value; }
    }
    private string strQuery = "";

    private CashHandOverAction cashHandOverAction;
    public CashHandOverAction CashHandOverAction
    {
        set { cashHandOverAction = value; }
    }
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchAchievementAction.Model;
        InitData();
        if (!IsPostBack)
        {
            cashHandOverAction.Model.HandOverDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            ViewState.Add("BeginDateTimeString", cashHandOverAction.DailyPaperMinHandOverDateTime);
            QueryNextPageData(1);
        }
    }
    private void InitData() 
    {
        employeeAction.GetAllEmployee();
        model.EmployeeList = employeeAction.Model.EmployeeList;
        searchAchievementAction.GetPositionList();
    }
    #endregion

    #region //Search
    protected void Search(object sender, EventArgs e)
    {
        try
        {
            Hashtable achievement=new Hashtable();
            string strBeginDateTime = txtBeginDateTime.Value.Trim();
            string strEndDateTime = txtTo.Value.Trim();

             #region//时间段
            if (!StringUtils.IsEmpty(strBeginDateTime))
            {
                //开始交班时间
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strBeginDateTime).ToString("yyyy-MM-dd");
                achievement.Add("BeginDateTimeString", cashHandOverAction.DailyPaperMinHandOverDateTime);
            }
            else 
            {
                if ("" != strEndDateTime)
                {
                    //开始交班时间
                    cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strEndDateTime).AddDays(-1).ToString("yyyy-MM-dd");
                    achievement.Add("BeginDateTimeString", cashHandOverAction.DailyPaperMinHandOverDateTime);
                }
            }

            if (!StringUtils.IsEmpty(strEndDateTime))
            {
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strEndDateTime).ToString("yyyy-MM-dd");
                achievement.Add("EndDateTimeString", cashHandOverAction.DailyPaperMinHandOverDateTime);
            }
            else 
            {
                if ("" != strBeginDateTime)//开始日期不为空
                {
                    cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strBeginDateTime).AddDays(+1).ToString("yyyy-MM-dd");
                    achievement.Add("EndDateTimeString", cashHandOverAction.DailyPaperMinHandOverDateTime);
                }
            }
            #endregion
            if (!StringUtils.IsEmpty(Request.Form["txtOrderNo"]))
            {
                achievement.Add("OrderNo", Request.Form["txtOrderNo"]);
            }
            IList<string> positionList = new List<string>();
            if (!StringUtils.IsEmpty(Request.Form["sltPosition"]))
            {
                string[] position = Request.Form["sltPosition"].Split(',');
                foreach (string str in position)
                {
                    positionList.Add(str);
                }
            }
            achievement.Add("PositionIdList", positionList);

            IList<string> employeeList = new List<string>();
            if (!StringUtils.IsEmpty(Request.Form["sltEmployee"]))
            {
                string[] employee = Request.Form["sltEmployee"].Split(',');
                foreach (string str in employee)
                {
                    employeeList.Add(str);
                }
            }
            achievement.Add("EmployeeIdList", employeeList);
            achievement.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            achievement.Add("pageCountIndex", 0);
            searchAchievementAction.SearchAchievement(achievement);
            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.PageSize = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(searchAchievementAction.SearchAchievementRowCount(achievement));

            if (null != achievement["BeginDateTimeString"])
            {
                ViewState.Add("BeginDateTimeString", achievement["BeginDateTimeString"]);
            }
            else 
            {
                ViewState.Add("BeginDateTimeString", null);
            }
            if (null != achievement["EndDateTimeString"])
            {
                ViewState.Add("EndDateTimeString", achievement["EndDateTimeString"]);
            }
            else 
            {
                ViewState.Add("EndDateTimeString", null);
            }
            ViewState.Add("PositionIdList",positionList);
            ViewState.Add("EmployeeIdList",employeeList);
            ViewState.Add("currentPageIndex", "1");
            ViewState.Add("OrderNo", Request.Form["txtOrderNo"]);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
       
    }
    #endregion

    #region //Print
    protected void btnDispatchPrint_Click(object sender, EventArgs e)
    {
        try
        {
            Hashtable achievement = new Hashtable();
            if (null != ViewState["BeginDateTimeString"] && "" != ViewState["BeginDateTimeString"].ToString())
            {
                achievement.Add("BeginDateTimeString", ViewState["BeginDateTimeString"]);
                strQuery += " 结算时间>=" + DateUtils.ToFormatDateTime(Convert.ToDateTime(ViewState["BeginDateTimeString"]), DateTimeFormatEnum.DateTimeNoSecondFormat);
            }
            if (null != ViewState["EndDateTimeString"] && "" != ViewState["EndDateTimeString"].ToString())
            {
                achievement.Add("EndDateTimeString", ViewState["EndDateTimeString"]);
                strQuery += "且<=" + DateUtils.ToFormatDateTime(Convert.ToDateTime(ViewState["EndDateTimeString"]), DateTimeFormatEnum.DateTimeNoSecondFormat);
            }

            if (null != ViewState["OrderNo"] && "" != ViewState["OrderNo"].ToString())
            {
                achievement.Add("OrderNo", ViewState["OrderNo"]);
                strQuery += " 工单号:" + Convert.ToString(ViewState["OrderNo"]);
            }
            if (null != ViewState["PositionIdList"] && "" != ViewState["PositionIdList"].ToString())
            {
                achievement.Add("PositionIdList", ViewState["PositionIdList"]);
                string strPositionList = hiddPositionList.Value;
                if ("" != strPositionList)
                {
                    strQuery += " 部门: " + strPositionList;
                }
            }

            if (null != ViewState["EmployeeIdList"] && "" != ViewState["EmployeeIdList"].ToString())
            {
                achievement.Add("EmployeeIdList", ViewState["EmployeeIdList"]);
                string strEmployeeList=hiddEmployeeList.Value;
                if ("" != strEmployeeList)
                {
                    strQuery += " 员工: " + strEmployeeList;
                }
            }
            searchAchievementAction.SearchAchievementPrint(achievement);
            ReportAchievement rart = new ReportAchievement();
            rart.QueryString += strQuery;
            string reportFileName = "AchievementTotal" + DateTime.Now.Ticks.ToString() + ".pdf";
            rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

            rart.CreateReport(searchAchievementAction.Model, "绩效统计", "绩效统计", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '绩效统计', 1024, 1024 , false, false, null);</script>");
            QueryNextPageData(Convert.ToInt32(ViewState["currentPageIndex"]));
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    
    #endregion

    #region //分页处理
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    private void QueryNextPageData(int currentPageIndex)
    {
        try
        {
            Hashtable achievement = new Hashtable();
            if (null != ViewState["BeginDateTimeString"] && "" != ViewState["BeginDateTimeString"].ToString())
            {
                ViewState.Add("BeginDateTimeString", ViewState["BeginDateTimeString"]);
                achievement.Add("BeginDateTimeString", ViewState["BeginDateTimeString"]);
            }
            if (null != ViewState["EndDateTimeString"] && "" != ViewState["EndDateTimeString"].ToString())
            {
                ViewState.Add("EndDateTimeString", ViewState["EndDateTimeString"]);
                achievement.Add("EndDateTimeString", ViewState["EndDateTimeString"]);
            }
            if (null != ViewState["PositionIdList"] && "" != ViewState["PositionIdList"].ToString())
            {
                ViewState.Add("PositionIdList", ViewState["PositionIdList"]);
                achievement.Add("PositionIdList", ViewState["PositionIdList"]);
            }

            if (null != ViewState["EmployeeIdList"] && "" != ViewState["EmployeeIdList"].ToString())
            {
                ViewState.Add("EmployeeIdList", ViewState["EmployeeIdList"]);
                achievement.Add("EmployeeIdList", ViewState["EmployeeIdList"]);
            }
            if (null != ViewState["OrderNo"] && ""!=ViewState["OrderNo"].ToString())
            {
                achievement.Add("OrderNo", ViewState["OrderNo"]);
                ViewState.Add("OrderNo", ViewState["OrderNo"]);
            }
            ViewState.Add("currentPageIndex",currentPageIndex);
            achievement.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            achievement.Add("pageCountIndex", currentPageIndex - 1);
            searchAchievementAction.SearchAchievement(achievement);
            AspNetPager1.PageSize = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(searchAchievementAction.SearchAchievementRowCount(achievement));
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }
    #endregion

}
