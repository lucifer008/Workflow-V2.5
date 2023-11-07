using System;
using System.Collections.Generic;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Support.Report.Finance;
using Workflow.Support.Report;
using iTextSharp.text;
/// <summary>
///  功能概要：核对订单
///  作    者: 张晓林
///  创建时间: 2010年1月8日10:37:11
///  修正履历:
///  修正时间：
/// </summary>
public partial class finance_MortgageOrder : System.Web.UI.Page
{
    #region//ClassMember
    protected bool isPrint = false;
    protected string strTitle = "";
    private string OrderNo = "";
    protected OrderModel model;
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }
    private SearchOrderAction sAction;
    public SearchOrderAction SearchOrderAction
    {
        set { sAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = newOrderAction.Model;
        if ("" != action.Value)
        {
            CheckOrder();
        }
        if (!IsPostBack) 
        {
            InitData();
            action.Value = Request.QueryString["Action"];
            if("check"==action.Value)
            {
                strTitle = "核对订单";
            }
            else if ("print" == action.Value)
            {
                strTitle = "打印确认";
            }
            else if ("return" == action.Value)
            {
                strTitle = "返回确认";
            }
        }
    }
    
    #endregion

    #region //获取订单详细信息
    /// <summary>
    /// 获取订单详细信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 张晓林
    /// 创建时间: 2010年1月8日10:43:25
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void InitData()
    {
        OrderNo = Request.QueryString["OrderNo"];
        try
        {
            //订单详细信息
            newOrderAction.GetOrderByOrderNo(OrderNo);
            newOrderAction.GetOrderInfo(OrderNo);
            newOrderAction.GetOrderItemByOrderNo(OrderNo);
            newOrderAction.GetOrderItemListByOrderNo(OrderNo);
            newOrderAction.GetOrderItemPrintRequeireDetail(OrderNo);
            newOrderAction.GetOrderItemFactorValueByOrderNo(OrderNo);
            newOrderAction.GetFactorValue(true);
            newOrderAction.GetAllUser();
            newOrderAction.InitMasterData();
            newOrderAction.GetOrderItemMortgageByOrderNo(OrderNo);

            //订单员工信息
            Workflow.Da.Domain.OrderItemEmployee orderItemEmployee = new Workflow.Da.Domain.OrderItemEmployee();
            orderItemEmployee.No = OrderNo;
            orderItemEmployee.PositionId1 = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.PositionId2 = Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.PositionId = Constants.POSITION_RECEPTION_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            newOrderAction.Model.OrderItemEmployee.Add(orderItemEmployee);
            newOrderAction.SelectOldEmployee();
            //送货人
            sAction.SearchDelivery(OrderNo);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }
    #endregion

    #region//CheckOrder
    /// <summary>
    /// 核对订单
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 张晓林
    /// 创建时间: 2010年1月8日10:40:58
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    public void CheckOrder() 
    {

        try
        {
            int currentStatus = 0;
            int nextStatus = 0;
            string memo = "";
            string strAction = action.Value;
            bool isAddBarCode = false;
            //核对订单
            if ("check" == strAction) 
            {
                memo = "核对订单";
                nextStatus = Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
                currentStatus = Constants.ORDER_STATUS_FINISHED_VALUE;
            }
            else if ("return" == strAction) 
            {
                memo = "从已登记返回到制作中";
                nextStatus = Constants.ORDER_STATUS_FACTURING_VALUE;
                currentStatus = Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
            }
            else if ("print" == strAction)
            {
                memo = "修正打印订单";
                nextStatus = Constants.ORDER_STATUS_FACTURING_VALUE;
                currentStatus = Constants.ORDER_STATUS_CONFIRM_VALUE;
                isPrint = true;
                isAddBarCode = true;
            }
            Order order = new Order();
            order.No = Request.Form["orderNo"];
            order.Status = nextStatus;
            order.IsNotStatisticsPoints = isAddBarCode;//是否添加条码

            OrdersStatusAlter ordersStatusAlter = new OrdersStatusAlter();
            ordersStatusAlter.OrdersId = newOrderAction.SelectOrderIdByOrderNo(order.No);
            ordersStatusAlter.Status = currentStatus;
            ordersStatusAlter.Memo = memo;

            newOrderAction.Model.NewOrder = order;
            newOrderAction.Model.OrderStatusAlter = ordersStatusAlter;
            model.IsPrint = isPrint;
            model.OrderItemIdArr = Request.Form["itemId"].Split(',');
            newOrderAction.ReturnOrder();
            
            if (!isPrint)
            {
                Response.Write("<script>opener.rVal='true';</script>");
                Response.Write("<script>window.close()</script>");
            }
            else 
            {
                PrintReport(order.No);
            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    /// <summary>
    /// 功能概要: 打印报表
    /// 作    者：张晓林
    /// 创建时间: 2010年1月7日18:12:08
    /// 修正履历:
    /// 修正履历:
    /// </summary>
    private void PrintReport(string orderNo)
    {
        try
        {
            //订单详细信息
            newOrderAction.GetOrderInfo(orderNo);
            newOrderAction.GetOrderItemByOrderNo(orderNo);
            newOrderAction.GetOrderItemListByOrderNo(orderNo);
            newOrderAction.GetOrderItemPrintRequeireDetail(orderNo);
            newOrderAction.GetOrderItemFactorValueByOrderNo(orderNo);
            newOrderAction.GetFactorValue(true);
            newOrderAction.InitMasterData();
            newOrderAction.GetAllUser();
            newOrderAction.Model.CustomerName = Request.Form["CustomerName"];

            //订单员工信息
            Workflow.Da.Domain.OrderItemEmployee orderItemEmployee = new Workflow.Da.Domain.OrderItemEmployee();
            orderItemEmployee.No = orderNo;
            orderItemEmployee.PositionId1 = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.PositionId2 = Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.PositionId = Constants.POSITION_CASHER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.Id = Constants.POSITION_RECEPTION_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            newOrderAction.Model.OrderItemEmployee.Add(orderItemEmployee);
            newOrderAction.SelectOldEmployee();
            newOrderAction.GetOrderPaymentConcessionByOrderId(newOrderAction.SelectOrderIdByOrderNo(orderNo));
            //送货人
            sAction.SearchDelivery(orderNo);
            ReportOrder ro = new ReportOrder();
            ro.IsDisplayBarCode = true;
            ro.IsDisplayOrderItemEdmit = true;
            string reportName = "Order" + DateTime.Now.Ticks.ToString() + ".pdf";
            ro.FileName = Server.MapPath("~") + @"\reports\" + reportName;
            ro.CreateReport(newOrderAction.Model, "", "", PageSize.A4, 0, 0, 30, 30);//"业务委托订单", "业务委托订单", PageSize.A4, 0, 0, 30, 30);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script>showPage('../reports/" + reportName + "', '_blank', 1024, 1024 , false, false, null);</script>");
            //Page.RegisterStartupScript(this.GetType(), "<script>showPage('../reports/" + reportName + "', '_blank', 1024, 1024 , false, false, null);window.location.href='DailyOrder.aspx';</script>");

            model = null;
            
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}

