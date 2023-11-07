using System;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Employee;
using Workflow.Action.Achievement;
using Workflow.Action.Finance.Model;
using Workflow.Support.Report.Finance;
/// <summary>
/// 功能概要：按人员统计开单量明细
/// 作    者：张晓林
/// 创建时间：2010年1月5日10:16:34
/// 修正时间：
/// 修正履历:
/// </summary>
public partial class finance_find_SearchOrderCountDetail : System.Web.UI.Page
{
    #region //ClassMember
    protected FindFinanceModel model;
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
    }
    private CashHandOverAction cashHandOverAction;
    public CashHandOverAction CashHandOverAction
    {
        set { cashHandOverAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
        if(!IsPostBack)
        {
            ViewState.Add("EmployeeId", Request.QueryString["EmployeeId"]);
            ViewState.Add("PositionId", Request.QueryString["PositionId"]);
            ViewState.Add("BeginDate", Request.QueryString["BeginDate"]);
            ViewState.Add("EndDate", Request.QueryString["EndDate"]);
            QueryNextPageData(1);
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        try 
        {
            Order order = new Order();
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.EmployeeId = Convert.ToInt32(ViewState["EmployeeId"].ToString());
            order.NewOrderUserId = Convert.ToInt32(ViewState["PositionId"].ToString());
            if ("" != ViewState["BeginDate"].ToString()) 
            {
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(ViewState["BeginDate"].ToString()).ToString("yyyy-MM-dd");
                order.InsertDateTimeString = cashHandOverAction.DailyPaperMinHandOverDateTime;
            }
            if ("" != ViewState["EndDate"].ToString())
            {
                cashHandOverAction.Model.HandOverDateTime = Convert.ToDateTime(ViewState["EndDate"].ToString()).ToString("yyyy-MM-dd");
                order.BalanceDateTimeString = cashHandOverAction.DailyPaperMinHandOverDateTime;
            }
            order.EveryPageCount = Constants.ROW_COUNT_FOR_PAGER;
            order.CurrentPageIndex = Convert.ToInt32(currentPageIndex-1);
            findFinanceAction.Model.Order = order;
            findFinanceAction.SearchOrderCountDetail();

            AspNetPager1.CurrentPageIndex = currentPageIndex;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(model.EmployeeId);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
