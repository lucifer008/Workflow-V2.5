
using System;
using System.Collections.Generic;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Achievement;
using Workflow.Action.Achievement.Model;
using Workflow.Support.Report.Achievement;

/// <summary>
/// 名    称: AchievementComposition
/// 功能概要: 工单绩效分配情况
/// 作    者: 
/// 创建时间:
/// 修正履历: 张晓林
/// 修正时间:  2009-01-06
///             完成查询；打印；分页功能
/// </summary>
public partial class achievement_AchievementComposition:Workflow.Web.PageBase
{
    #region //Class Member
    public static int count = 0;
    public static string strOrderNo = "";
    private int orderId = 0;
    private SearchAchievementAction searchAchievementAction;
    public SearchAchievementAction SearchAchievementAction
    {
        set { searchAchievementAction = value; }
    }

    //public AdjustAchievementAction adjustAchievementAction;
    //public AdjustAchievementAction AdjustAchievementAction
    //{
    //    set { adjustAchievementAction = value; }
    //}

    protected AdjustAchievementModel aaModel;
    protected OrderModel oModel;
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aaModel = searchAchievementAction.Model;
            oModel = searchAchievementAction.OrderModel;
            if (!IsPostBack)
            {
                QueryNextPageData(1);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //Search
    protected void Search(object sender, EventArgs e)
    {
        try
        {
            strOrderNo = Request.Form["strNo"];
            if ("" != strOrderNo)
            {
                searchAchievementAction.GetOrderInfo(Request.Form["strNo"]);
                orderId = Convert.ToInt32(searchAchievementAction.SelectOrderIdByOrderNo(strOrderNo));
                searchAchievementAction.GetAchievementCount(1, orderId);

                AspNetPager1.CurrentPageIndex = 1;
                AspNetPager1.RecordCount = Convert.ToInt32(searchAchievementAction.GetAchievementCountTotal(orderId));
                AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

                ViewState.Add("OrderId", orderId);
                ViewState.Add("OrderNo", Request.Form["strNo"]);
                ViewState.Add("CurrentPageIndex", 1);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //Print
    
    protected void btnDisPrint_Click(object sender, EventArgs e)
    {
        try
        {
            string strQuery = "";
            if (null != ViewState["OrderNo"] && "" != ViewState["OrderNo"].ToString())
            {
                searchAchievementAction.GetOrderInfo(ViewState["OrderNo"].ToString());

                orderId = Convert.ToInt32(searchAchievementAction.SelectOrderIdByOrderNo(ViewState["OrderNo"].ToString()));
                strQuery += "工单号:" + ViewState["OrderNo"].ToString();
            }
            if (null != searchAchievementAction.OrderModel.NewOrder)
            {
                Achievement achievement = new Achievement();
                achievement.No = searchAchievementAction.OrderModel.NewOrder.No;
                achievement.EmployeeName = searchAchievementAction.OrderModel.NewOrder.CustomerName;//客户名称
                achievement.NewOrderName = searchAchievementAction.OrderModel.NewOrder.ProjectName;//工单工程名
                achievement.TrashPaper = searchAchievementAction.OrderModel.NewOrder.SumAmount;//工单总计金额
                searchAchievementAction.Model.NewAchievement = achievement;

            }
            searchAchievementAction.GetAchievementCountPrint(orderId);
            ReportOrdersAchievement rart = new ReportOrdersAchievement();
            rart.QueryString += strQuery;
            string reportFileName = "OrdersAchievementTotal" + DateTime.Now.Ticks.ToString() + ".pdf";
            rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

            rart.CreateReport(searchAchievementAction.Model, "工单业绩分配统计", "工单业绩分配统计", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '工单业绩分配统计', 1024, 1024 , false, false, null);</script>");
            QueryNextPageData(Convert.ToInt32(ViewState["CurrentPageIndex"]));
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //分页处理程序
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        try
        {
            QueryNextPageData(e.NewPageIndex);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    private void QueryNextPageData(int currentPageIndex)
    {
        if (null != ViewState["OrderId"] && "" != ViewState["OrderId"].ToString())
        {
            ViewState.Add("OrderId", ViewState["OrderId"]);
            orderId = Convert.ToInt32(ViewState["OrderId"]);
        }
        if (null != ViewState["OrderNo"] && "" != ViewState["OrderNo"].ToString())
        {
            searchAchievementAction.GetOrderInfo(ViewState["OrderNo"].ToString());
            Achievement achievement = new Achievement();
            achievement.OrdersId = searchAchievementAction.SelectOrderIdByOrderNo(ViewState["OrderNo"].ToString());
            searchAchievementAction.Model.NewAchievement = achievement;
            ViewState.Add("OrderNo", ViewState["OrderNo"]);
        }
        searchAchievementAction.GetAchievementCount(currentPageIndex, orderId);
        AspNetPager1.RecordCount = Convert.ToInt32(searchAchievementAction.GetAchievementCountTotal(orderId));
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        ViewState.Add("CurrentPageIndex", currentPageIndex);
    }
    #endregion
}
