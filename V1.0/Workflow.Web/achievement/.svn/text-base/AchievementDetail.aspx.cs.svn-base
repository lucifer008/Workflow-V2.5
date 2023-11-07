using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Achievement;
using Workflow.Action.Achievement.Model;
/// <summary>
/// 名    称: AchievementDetail
/// 功能概要: 员工业绩详情
/// 作    者: 
/// 创建时间:
/// 修正履历: 张晓林
/// 修正时间:  2009-01-06
///             完成查询功能
/// </summary>
public partial class AchievementDetail : Workflow.Web.PageBase
{
    #region //Class Member

    private SearchAchievementAction searchAchievementAction;
    public SearchAchievementAction SearchAchievementAction 
    {
        set { searchAchievementAction = value; }
    }
    private CashHandOverAction cashHandOverAction;
    public CashHandOverAction CashHandOverAction
    {
        set { cashHandOverAction = value; }
    }
    protected AdjustAchievementModel model;
    protected string dateTimeString = "";

    #endregion

    #region //Page_Load
    private void InitData() 
    {
        Hashtable achievement = new Hashtable();
        achievement.Add("EmployeeId", Request.QueryString["EmployeeId"]);
        #region//时间段
        string strBeginDateTime = Request.QueryString["BeginDateTimeString"];
        string strEndDateTime = Request.QueryString["EndDateTimeString"];
        string strYesNotDefault = Request.QueryString["YesNotDefault"];
        if ("" != strYesNotDefault)
        {

            //取交班时间
            cashHandOverAction.Model.HandOverDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            achievement.Add("BeginDateTimeString", cashHandOverAction.DailyPaperMinHandOverDateTime);
            dateTimeString = Convert.ToDateTime(achievement["BeginDateTimeString"]).ToString("yyyy-MM-dd HH:mm");
        }
        else
        {
            if ("" != strBeginDateTime)
            {
                //开始交班时间
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strBeginDateTime).ToString("yyyy-MM-dd");
                achievement.Add("BeginDateTimeString", cashHandOverAction.DailyPaperMinHandOverDateTime);
                dateTimeString = Convert.ToDateTime(achievement["BeginDateTimeString"]).ToString("yyyy-MM-dd HH:mm");
            }
            else//开始时间为空
            {
                if ("" != strEndDateTime)
                {
                    //开始交班时间
                    cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strEndDateTime).AddDays(-1).ToString("yyyy-MM-dd");
                    achievement.Add("BeginDateTimeString", cashHandOverAction.DailyPaperMinHandOverDateTime);
                    dateTimeString += Convert.ToDateTime(achievement["BeginDateTimeString"]).ToString("yyyy-MM-dd HH:mm");
                }
            }

            if ("" != strEndDateTime.Trim())
            {
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strEndDateTime).ToString("yyyy-MM-dd");
                achievement.Add("EndDateTimeString", cashHandOverAction.DailyPaperMinHandOverDateTime);
                dateTimeString += "至" + Convert.ToDateTime(achievement["EndDateTimeString"]).ToString("yyyy-MM-dd HH:mm");
            }
            else //结束日期为空
            {
                if ("" != strBeginDateTime)//开始日期不为空
                {
                    cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(strBeginDateTime).AddDays(+1).ToString("yyyy-MM-dd");
                    achievement.Add("EndDateTimeString", cashHandOverAction.DailyPaperMinHandOverDateTime);
                    dateTimeString += "至" + Convert.ToDateTime(achievement["EndDateTimeString"]).ToString("yyyy-MM-dd HH:mm");
                }
            }
        }
        #endregion
        if (null != Request.QueryString["PositionName"] && "" != Request.QueryString["PositionName"])
        {
            achievement.Add("PositionName", Request.QueryString["PositionName"].Trim());
        }
        achievement.Add("currentPageIndex", 0);
        achievement.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
        searchAchievementAction.GetCustomerAchievementDetail(achievement);

        AspNetPager1.CurrentPageIndex = 1;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.OrderId;//记录数

        ViewState.Add("EmployeeId", Request.QueryString["EmployeeId"]);
        if (null != achievement["BeginDateTimeString"])
        {
            ViewState.Add("BeginDateTimeString", achievement["BeginDateTimeString"]);
        }
        if (null != achievement["EndDateTimeString"])
        {
            ViewState.Add("EndDateTimeString", achievement["EndDateTimeString"]);
        }
        ViewState.Add("PositionName", Request.QueryString["PositionName"]);
        ViewState.Add("DateTimeString", dateTimeString);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchAchievementAction.Model;
        if (!IsPostBack)
        {
            InitData();
        }
    }
    #endregion

    #region //分页处理程序
    private void queryNextPageData(int currentPageIndex)
    {
        Hashtable condition = new Hashtable();
        if (null!=ViewState["EmployeeId"] && ""!= ViewState["EmployeeId"].ToString())
        {
            condition.Add("EmployeeId", ViewState["EmployeeId"].ToString().Trim());
        }
        if (null!=ViewState["BeginDateTimeString"] && "" != ViewState["BeginDateTimeString"].ToString())
        {
            condition.Add("BeginDateTimeString", ViewState["BeginDateTimeString"].ToString().Trim());
        }
        if (null!=ViewState["EndDateTimeString"] && "" != ViewState["EndDateTimeString"].ToString())
        {
            condition.Add("EndDateTimeString", ViewState["EndDateTimeString"].ToString().Trim());
        }
        if (null!=ViewState["PositionName"] && "" != ViewState["PositionName"].ToString().ToString())
        {
            condition.Add("PositionName", ViewState["PositionName"].ToString().Trim());
        }
        if ("" != ViewState["DateTimeString"].ToString())
        {
            dateTimeString = ViewState["DateTimeString"].ToString();
        }
        condition.Add("currentPageIndex", currentPageIndex - 1);
        condition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
        searchAchievementAction.GetCustomerAchievementDetail(condition);

        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.OrderId;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        queryNextPageData(e.NewPageIndex);
    }
    #endregion
}
