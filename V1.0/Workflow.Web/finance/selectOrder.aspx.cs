using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;

/// <summary>
/// 名    称: FinanceSelectOrder
/// 功能概要: 待结算单一览
/// 作    者: 付强
/// 创建时间: 2007-9-13
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class FinanceSelectOrder :Workflow.Web.PageBase
{
    #region Class Member
    private long orderId = 0;
    protected FinanceModel fModel;
    private FinanceAction financeAction;
    public FinanceAction FinanceAction
    {
        set { financeAction = value; }
    }
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData(0);
        }
        fModel = financeAction.Model;
        ReturnOrders();

    }
    #endregion

    #region Search
    protected void Search(object sender, EventArgs e)
    {
        if (!StringUtils.IsEmpty(Request.Form["OrderNo"]))
        {
            orderId = financeAction.SelectOrderIdByOrderNo(Request.Form["OrderNo"]);
            if (orderId == 0)
            {
                orderId = -1;
            }
        }
        else
        {
            orderId = 0;
        }

        financeAction.Model.Orders = new Order();
        financeAction.Model.Orders.Id = orderId;
        financeAction.Model.Orders.Status = Constants.ROW_COUNT_FOR_PAGER;
        financeAction.Model.Orders.Status1 = Constants.ORDER_STATUS_DELIVERYED_VALUE;
        financeAction.Model.Orders.Status2 = Constants.ORDER_STATUS_NOPATCHUP_VALUE;
        financeAction.Model.Orders.Status3 = Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
        financeAction.Model.Orders.CurrentPageIndex = 0;
        ViewState.Add("OrdersId", orderId);
        ViewState.Add("Status", Constants.ROW_COUNT_FOR_PAGER);
        ViewState.Add("Status1", Constants.ORDER_STATUS_DELIVERYED_VALUE);
        ViewState.Add("Status2", Constants.ORDER_STATUS_NOPATCHUP_VALUE);
        ViewState.Add("Status3", Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE);
        financeAction.SelectUnClosedOrderCount();
        financeAction.SelectUnClosedOrder();
        this.AspNetPager1.CurrentPageIndex = 1;
        this.AspNetPager1.RecordCount = financeAction.Model.UnClosedOrderCount;
        this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

    }
    #endregion

    #region Pager Event
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        BindData(e.NewPageIndex-1);
    }
    #endregion

    #region Data Bind
    private void BindData(int currentPageIndex)
    {
        financeAction.Model.Orders = new Order();
        if (ViewState["OrdersId"] != null)
        {
            financeAction.Model.Orders.Id = long.Parse(ViewState["OrdersId"].ToString());
        }
        else
        {
            financeAction.Model.Orders.Id = 0;
        }
        if (ViewState["Status"] != null)
        {
            financeAction.Model.Orders.Status = int.Parse(ViewState["Status"].ToString());
        }
        else
        {
            financeAction.Model.Orders.Status = Constants.ROW_COUNT_FOR_PAGER;
        }
        if (ViewState["Status1"] != null)
        {
            financeAction.Model.Orders.Status1 = int.Parse(ViewState["Status1"].ToString());
        }
        else
        {
            financeAction.Model.Orders.Status1 = Constants.ORDER_STATUS_DELIVERYED_VALUE;
        }
        if (ViewState["Status2"] != null)
        {
            financeAction.Model.Orders.Status2 = int.Parse(ViewState["Status2"].ToString());
        }
        else
        {
            financeAction.Model.Orders.Status2 = Constants.ORDER_STATUS_NOPATCHUP_VALUE;
        }
        if (ViewState["Status3"] != null)
        {
            financeAction.Model.Orders.Status3 = int.Parse(ViewState["Status3"].ToString());
        }
        else
        {
            financeAction.Model.Orders.Status3 = Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
        }
        financeAction.Model.Orders.CurrentPageIndex = currentPageIndex;
        financeAction.SelectUnClosedOrderCount();
        financeAction.SelectUnClosedOrder();

        this.AspNetPager1.RecordCount = financeAction.Model.UnClosedOrderCount;
        this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

    }
    #endregion

    #region Return Order
    /// <summary>
    /// 订单返回处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// 作    者: 张晓林
    /// 创建时间: 2008-12-23
    /// 修正履历:
    /// </remarks>
    public void ReturnOrders() 
    {
        try
        {
            if (checkTag.Value=="T")//Request.Form["checkTag"] == "T")
            {           
                financeAction.Model.OrderStatusAlter = new OrdersStatusAlter();
                financeAction.Model.OrderStatusAlter.OrdersId = Convert.ToUInt32(searchTag.Value);
                financeAction.Model.OrderStatusAlter.Status = Constants.ORDER_STATUS_FINISHED_VALUE;
                financeAction.Model.OrderStatusAlter.Memo = "返回工单";
                financeAction.ReturnOrder();
                this.AspNetPager1.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex;
                BindData(this.AspNetPager1.CurrentPageIndex-1);
           }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
