using System;

using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;

/// <summary>
/// 功能概要: 获取要修正的订单:只能修改未交班的订单
/// 作    者: 张晓林
/// 创建时间: 2009年11月17日13:45:52
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class finance_SelectAmendmentOrder : System.Web.UI.Page
{
    #region //Class Member
    protected FinanceModel model;
    private FinanceAction financeAction;
    public FinanceAction FinanceAction
    {
        set { financeAction = value; }
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
        model = financeAction.Model;
    }
    #endregion

    #region//分页处理程序
    private void QueryNextOPageData(int currentPageIndex) 
    {
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextOPageData(e.NewPageIndex);
    }
    #endregion

    #region//Search
    protected void Search(object sender, EventArgs e)
    {
        try
        {
            model.Orders = new Order();
            //获取当天最迟交班时间
            //model.Orders.BalanceDateTimeString = DateTime.Now.ToString("yyyy-MM-dd");
            //cashHandOverAction.Model.HandOverDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            //model.Orders.CurrentHandOverBeginDate = cashHandOverAction.DailyPaperMaxHandOverDateTime;
            if ("" != txtOrderNo.Value.Trim())
            {
                model.Orders.No = txtOrderNo.Value.Trim();
            }
            model.Orders.Status = Convert.ToInt32(Constants.ORDER_STATUS_SUCCESSED_VALUE);
            financeAction.GetAmendmentOrder();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
