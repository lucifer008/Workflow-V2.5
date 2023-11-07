using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Employee;
using Workflow.Action.Achievement;
using Workflow.Action.Achievement.Model;
using Workflow.Support.Report.Achievement;

/// <summary>
/// 名    称: AchievementUselessPaperSum
/// 功能概要: 员工绩效统计
/// 作    者: 
/// 创建时间:
/// 修正履历: 张晓林
/// 修正时间:  2009-01-07
///             完成查询；分页；打印功能
/// </summary>
public partial class AchievementUselessPaperSum : Workflow.Web.PageBase
{
    #region //Class Member
    private CashHandOverAction cashHandOverAction;
    public CashHandOverAction CashHandOverAction
    {
        set { cashHandOverAction = value; }
    }
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
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("pragma", "no-cache");
        Response.AppendHeader("Cache-Control", "no-cache, must-revalidate");
        Response.AppendHeader("expires", "0");

        model = searchAchievementAction.Model;
        InitData();
        if (!IsPostBack)
        {
            cashHandOverAction.Model.HandOverDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            ViewState.Add("BeginDateTime", cashHandOverAction.DailyPaperMinHandOverDateTime);
            QueryNextPageData(1);
        }
        else
        {
            int date = Convert.ToInt16(hidDate.Value);
            if (date != 999) QueryDataByDate(date);
        }
    }

    /// <summary>
    /// 添加日期导航
    /// </summary>
    /// <param name="day"></param>
    /// <remarks>
    /// 作者: 张晓林
    /// 日期: 2010年6月29日11:52:16
    /// </remarks>
    private void QueryDataByDate(int day) 
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
   
        ViewState["EmployeeList"] = null;
        ViewState["PositionList"] = null;
        QueryNextPageData(1);
        //model.SearchDate = day;
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
         #region //获取查询条件
        Hashtable achievement = new Hashtable();

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

        IList<string> positionList = new List<string>();
        if (!StringUtils.IsEmpty(Request.Form["sltPosition"]))
        { 
            string [] position=Request.Form["sltPosition"].Split(',');
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
        #endregion
        achievement.Add("pageCountIndex", 0);
        achievement.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
        searchAchievementAction.GetCustomerAchievementCount(achievement);
        AspNetPager1.CurrentPageIndex = 1;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = Convert.ToInt32(searchAchievementAction.GetCustomerAchievmentCountTotal(achievement));

        #region //保存查询条件

        if (null != achievement["BeginDateTimeString"])
        {
            ViewState.Add("BeginDateTime", achievement["BeginDateTimeString"]);
        }
        else
        {
            ViewState.Add("BeginDateTime", null);
        }

        if (null != achievement["EndDateTimeString"])
        {
            ViewState.Add("EndDateTime", achievement["EndDateTimeString"]);
        }
        else 
        {
            ViewState.Add("EndDateTime", null);
        }
        ViewState.Add("PositionList", positionList);
        ViewState.Add("EmployeeList", employeeList);
        ViewState.Add("CurrentPageInde", 1);
        hidDate.Value = "999";
        //model.SearchDate = 999;
        #endregion
    }
    
    #endregion 
   
    #region //Print
    protected void btnDispPrint_Click(object sender, EventArgs e)
    {
        try
        {
            string strQuery = "";
            Hashtable achievement = new Hashtable();
            if (null != ViewState["BeginDateTime"] && "" != ViewState["BeginDateTime"].ToString())
            {
                achievement.Add("BeginDateTimeString", ViewState["BeginDateTime"]);
                strQuery += " 结算时间: " + Convert.ToDateTime(ViewState["BeginDateTime"]).ToString("yyyy-MM-dd HH:mm"); 
            }
            if (null != ViewState["EndDateTime"] && "" != ViewState["EndDateTime"].ToString())
            {
                achievement.Add("EndDateTimeString", ViewState["EndDateTime"]);
                strQuery += " 至" + Convert.ToDateTime(ViewState["EndDateTime"]).ToString("yyyy-MM-dd HH:mm");
            }
            if (null != ViewState["PositionList"] && "" != ViewState["PositionList"].ToString())
            {
                achievement.Add("PositionIdList", ViewState["PositionList"]);
                string strPositionList = hiddPositionList.Value;
                if ("" != strPositionList)
                {
                    strQuery += " 部门: " + strPositionList;
                }
            }

            if (null != ViewState["EmployeeList"] && "" != ViewState["EmployeeList"].ToString())
            {
                achievement.Add("EmployeeIdList", ViewState["EmployeeList"]);
                string strEmployeeList=hiddEmployeeList.Value;
                if(strEmployeeList!="")
                {
                    strQuery += " 员工: " + strEmployeeList;
                }
            }
            achievement.Add("pageCountIndex", ViewState["CurrentPageIndex"]);
            searchAchievementAction.GetCustomerAchevmentCountPrint(achievement);
            ReportCustomerAchievement rart = new ReportCustomerAchievement();
            rart.QueryString += strQuery;
            string reportFileName = "CustomerAchievementTotal" + DateTime.Now.Ticks.ToString() + ".pdf";
            rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

            rart.CreateReport(searchAchievementAction.Model, "员工绩效统计", "员工绩效统计", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '员工绩效统计', 1024, 1024 , false, false, null);</script>");
            QueryNextPageData(Convert.ToInt32(ViewState["CurrentPageIndex"]));
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
  
    #endregion

    #region //分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        Hashtable hashCondition = new Hashtable();
        if (null != ViewState["BeginDateTime"] && "" != ViewState["BeginDateTime"].ToString())
        {
            hashCondition.Add("BeginDateTimeString",ViewState["BeginDateTime"]);
        }
        if (null != ViewState["EndDateTime"] && "" != ViewState["EndDateTime"].ToString())
        {
            hashCondition.Add("EndDateTimeString",ViewState["EndDateTime"]);
        }
        if (null != ViewState["EmployeeList"] && "" != ViewState["EmployeeList"].ToString())
        {
            hashCondition.Add("EmployeeIdList", ViewState["EmployeeList"]);
        }
        if (null != ViewState["PositionList"] && "" != ViewState["PositionList"].ToString())
        {
            hashCondition.Add("PositionIdList",ViewState["PositionList"]);
        }
        hashCondition.Add("pageCountIndex", currentPageIndex - 1);
        hashCondition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
        searchAchievementAction.GetCustomerAchievementCount(hashCondition);
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = Convert.ToInt32(searchAchievementAction.GetCustomerAchievmentCountTotal(hashCondition));
        //保存数据
        ViewState.Add("BeginDateTime", ViewState["BeginDateTime"]);
        ViewState.Add("EndDateTime",ViewState["EndDateTime"]);
        ViewState.Add("EmployeeList",ViewState["EmployeeList"]);
        ViewState.Add("PositionList",ViewState["PositionList"]);
        ViewState.Add("CurrentPageIndex", currentPageIndex);
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
