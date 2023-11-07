using System;
using iTextSharp.text;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Achievement;
using Workflow.Action.Achievement.Model;
using Workflow.Support.Report.Achievement;

/// <summary>
/// 名    称: AchievementShoperOrManagerSun
/// 功能概要: 店长经理绩效统计
/// 作    者: 张晓林 
/// 创建时间: 2009年5月23日14:22:43
/// 修正履历: 
/// 修正时间:
/// </summary>
public partial class achievement_SearchAchievementShoperOrManagerSum : System.Web.UI.Page
{
    #region//ClassMember
    protected AdjustAchievementModel model;
    private SearchAchievementAction searchAchievementAction;
    public SearchAchievementAction SearchAchievementAction
    {
        set { searchAchievementAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model=searchAchievementAction.Model;
        if(!IsPostBack)
        {
            //默认查询当前月份的记录
            model.NewAchievement.ProcessName = DateTime.Now.ToShortDateString();
            ViewState.Add("Month",DateTime.Now.ToShortDateString());
            searchAchievementAction.SearchAchievementByShoperAndManager();
        }
    }
    #endregion

    #region//Search
    protected void Search(object sender, EventArgs e)
    {
        if(""!=txtMonthPaperDateTime.Value.Trim())
        {
            model.NewAchievement.ProcessName = txtMonthPaperDateTime.Value+"-04";
        }
        searchAchievementAction.SearchAchievementByShoperAndManager();
        ViewState.Add("Month",model.NewAchievement.ProcessName);
    }
    #endregion
   
    #region//Print
    protected void btnDispPrint_Click(object sender, EventArgs e)
    {
        string strQuery = "";
        if (null != ViewState["Month"] && "" != ViewState["Month"].ToString())
        {
            model.NewAchievement.ProcessName = ViewState["Month"].ToString();
            strQuery = "结算月份:" + Convert.ToDateTime(ViewState["Month"]).ToString("yyyy-MM");
        }
        searchAchievementAction.SearchAchievementByShoperAndManager();
        ReportAchievementShoperOrManagerSum rart = new ReportAchievementShoperOrManagerSum();
        rart.QueryString += strQuery;
        string reportFileName = "CustomerAchievementTotal" + DateTime.Now.Ticks.ToString() + ".pdf";
        rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
        rart.CreateReport(searchAchievementAction.Model, "店长经理绩效统计", "店长经理绩效统计", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '店长经理绩效统计', 1024, 1024 , false, false, null);</script>");
    }
    #endregion

}
