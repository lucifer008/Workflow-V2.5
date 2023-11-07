using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Achievement;
using Workflow.Action.Achievement.Model;

//
/// <summary>
/// 名    称: AchievementDetailByManagerOrShoper
/// 功能概要: 店长经理绩效统计详情
/// 作    者: 张晓林 
/// 创建时间: 2009年5月25日10:06:00
/// 修正履历: 
/// 修正时间:
/// </summary>
public partial class achievement_AchievementDetailByManagerOrShoper : System.Web.UI.Page
{
    #region//ClassMember
    private SearchAchievementAction searchAchievementAction;
    public SearchAchievementAction SearchAchievementAction
    {
        set { searchAchievementAction = value; }
    }
    protected AdjustAchievementModel model;
    protected string dateTimeString = "";
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchAchievementAction.Model;
        if(!IsPostBack)
        {

        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {

    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
