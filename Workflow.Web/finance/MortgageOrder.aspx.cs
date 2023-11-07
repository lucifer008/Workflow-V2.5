using System;
using System.Collections.Generic;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
using Workflow.Support.Report.Finance;
/// <summary>
///  功能概要：订单冲减
///  作    者: 张晓林
///  创建时间: 2009年11月21日11:59:48
///  修正履历:
///  修正时间：
/// </summary>
public partial class finance_MortgageOrder : System.Web.UI.Page
{
    #region//ClassMember
    protected bool actionTag = false;//标志是否打印数据
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
        if (!IsPostBack) 
        {
            divMortgage.Visible = false;
        }
        OperateAction();
    }
    private void OperateAction() 
    {
        string action = Request.Form["tagAction"];
        switch(action)
        {
            case "Search":
                SearchMortgageOrderInfo();
                break;
            case "Mortgage":
                Mortgage();
                break;
        }
    }
    #endregion

    #region //获取订单详细信息
    /// <summary>
    /// 获取冲减的订单详细信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 张晓林
    /// 创建时间: 2009年11月21日14:20:06
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void SearchMortgageOrderInfo()
    {
        if ("" != Request.Form["txtOrderNo"].Trim())
        {
            OrderNo = Request.Form["txtOrderNo"];
        }
        //newOrderAction.GetOrderByOrderNo(OrderNo);
        if ("" == OrderNo) return;
        newOrderAction.BluringSearchOrderByOrderNo(OrderNo, true);
        if (null == model.NewOrder) { divMortgage.Visible = false; return; }
        else divMortgage.Visible = true;
        if (0 > model.NewOrder.SumAmount) return;
        if (Constants.ORDER_STATUS_SUCCESSED_VALUE != model.NewOrder.Status) return;
        OrderNo = model.NewOrder.No;
        try
        {
            //订单详细信息
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

    #region//Search
    /// <summary>
    /// 统计冲减的订单明细金额总和
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 张晓林
    /// 创建时间: 2009年11月21日14:20:06
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    public decimal OrderItemAmountSum(long orderItemId) 
    {
        decimal sum=0;
        if(null!=model.OrderItemMortgageList)
        {
            foreach(OrderItemMortgage oim in model.OrderItemMortgageList)
            {
                if(orderItemId==oim.SrcOrderItemId)
                {
                    sum += oim.Amount;
                }
            }
        }
        return sum;
    }
    #endregion

    #region//Mortgage
    /// <summary>
    /// 冲减订单
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 张晓林
    /// 创建时间: 2009年11月21日14:20:06
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    public void Mortgage() 
    {
        try
        {
            string strOrderNo = Request.Form["orderNo"];
            newOrderAction.GetOrderInfo(strOrderNo);
            newOrderAction.GetOrderItemByOrderNo(strOrderNo);
            newOrderAction.GetOrderItemListByOrderNo(strOrderNo);
            newOrderAction.GetOrderItemPrintRequeireDetail(OrderNo);
            newOrderAction.GetOrderItemEmployeeListByOrderNo(strOrderNo);
            newOrderAction.GetOrderItemFactorValueListByOrderNO(strOrderNo);

            Order diffOrder = newOrderAction.Model.NewOrder;
            IList<OrderItem> diffTempOrderItemList = newOrderAction.Model.OrderItemList;
            IList<OrderItemEmployee> diffTempOrderItemEmployeeList = newOrderAction.Model.OrderItemEmployeeList;
            IList<OrderItemFactorValue> diffTempOrderItemFactorValueList = newOrderAction.Model.OrderItemFactorValueList;
            IList<OrderItemPrintRequireDetail> diffOrderPrintRequireDetailList = newOrderAction.Model.OrderItemPrintRequireDetailList;
            IList<OrderItem> diffOrderItemList=new List<OrderItem>();
            //IList<OrderItemEmployee> diffOrderItemEmployeeList=new List<OrderItemEmployee>();
            //IList<OrderItemFactorValue> diffOrderItemFactorValueList = new List<OrderItemFactorValue>();
            IList<Order> orderPrint=new List<Order>();
            decimal diffSumAmount = 0;
            for (int i = 0; i < diffTempOrderItemList.Count; i++)
            {
                long diffOrderItemNum = Convert.ToInt32(Request.Form["diffItemNum" + diffTempOrderItemList[i].Id]);
                if (0 != diffOrderItemNum)
                {
                    diffTempOrderItemList[i].Amount = -1 * diffOrderItemNum;//冲减数量
                    diffSumAmount += diffTempOrderItemList[i].Amount * diffTempOrderItemList[i].UnitPrice;
                    diffOrderItemList.Add(diffTempOrderItemList[i]);
                    //明细雇员
                    foreach(OrderItemEmployee oie in diffTempOrderItemEmployeeList)
                    {
                        if (oie.OrderItemId == diffTempOrderItemList[i].Id)
                        {
                            diffOrderItemList[diffOrderItemList.Count-1].OrderItemEmployeeList.Add(oie);
                        }
                    }
                    //明细因素
                    diffOrderItemList[diffOrderItemList.Count - 1].OrderItemFactorValueList = new List<OrderItemFactorValue>();
                    foreach (OrderItemFactorValue oif in diffTempOrderItemFactorValueList)
                    {
                        if(oif.OrderItemId==diffTempOrderItemList[i].Id)
                        {
                            diffOrderItemList[diffOrderItemList.Count - 1].OrderItemFactorValueList.Add(oif);
                        }
                    }
                    //明细印制要求
                    foreach (OrderItemPrintRequireDetail oip in diffOrderPrintRequireDetailList)
                    {
                        if (oip.OrderItemId == diffOrderItemList[i].Id) 
                        {
                            diffOrderItemList[diffOrderItemList.Count - 1].OrderItemPrintRequireDetailList.Add(oip);
                        }
                    }
                }
            }

            //冲减订单信息
            diffOrder.SumAmount = diffSumAmount;
            diffOrder.RealPaidAmount = 0;
            if (diffOrder.PayType == Constants.PAYMENT_TYPE_CASHER_GET_VALUE)
            {
                diffOrder.RealPaidAmount = diffSumAmount;
                diffOrder.PaidAmount = diffSumAmount;
            }
            if (Constants.TRUE == diffOrder.NeedTicket) 
            {
                diffOrder.NeedTicket = Constants.TRUE;
                diffOrder.PaidTicketAmount =diffSumAmount;
            }
            else if (Constants.FALSE == diffOrder.NeedTicket)
            {
                diffOrder.NeedTicket = Constants.FALSE;
                diffOrder.PaidTicketAmount = 0;
            }
            diffOrder.PaidTicket = Constants.FALSE;
            diffOrder.NotPayTicketAmount = 0;
            diffOrder.BalanceDateTime = DateTime.Now;
            diffOrder.NewOrderUser = new User();
            diffOrder.NewOrderUser.Id = newOrderAction.Model.NewOrder.NewOrderUserId;
            diffOrder.CashUser = new User();
            diffOrder.CashUser.Id = newOrderAction.Model.NewOrder.CashUserId;
            diffOrder.Name = "";
            diffOrder.Memo = "冲减订单";

            newOrderAction.Model.NewOrder = diffOrder;
            newOrderAction.Model.OrderItemList = diffOrderItemList;
            newOrderAction.OrderMortgage();
            divMortgage.Visible = false;
            actionTag = true;
            BillPrintReport();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }

    /// <summary>
    /// 冲减完后输出冲减报表
    /// </summary>
    /// <remarks>
    /// 作    者：张晓林
    /// 创建时间: 2009年12月8日16:42:21
    /// 修正履历：
    /// 修正时间:
    /// </remarks>
    private void BillPrintReport() 
    {
        newOrderAction.SearchMortgageOrderPrint();
        ReportMortgageOrder rdMortgage = new ReportMortgageOrder();
        string reportFileName = "MortgageOrder" + DateTime.Now.Ticks.ToString() + ".pdf";
        rdMortgage.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

        rdMortgage.CreateReport(model, "订单冲减", "订单冲减", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '订单冲减', 1024, 1024 , false, false, null);</script>");
    }
    #endregion
}
