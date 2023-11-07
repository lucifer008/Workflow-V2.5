using System;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Finance;
using Workflow.Support.Report;
using Workflow.Action.Membercard;
using Workflow.Action.Finance.Model;
using iTextSharp.text;
/// <summary>
///  功能概要: 修正
///  作    者: 张晓晓林
///  创建时间: 2009年11月17日10:40:55
///  修正履历:
///  修正时间:
/// </summary>
public partial class finance_AmendmentOrder : System.Web.UI.Page
{
    #region//ClassMember
    private long customerId = 0;
    protected decimal scotInverse = 0;
    protected string orderNo = "";
    protected long orderId = 0;
    protected bool closeFlag = false;
    protected decimal returnMoney, PrePayAmount, needMoney;
    private DateTime balanceDateTime;
    protected OrderModel model;
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }
    private FinanceAction financeAction;
    public FinanceAction FinanceAction
    {
        set { financeAction = value; }
    }
    private SearchOrderAction searchOrderAction;
    public SearchOrderAction SearchOrderAction
    {
        set { searchOrderAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = newOrderAction.Model;
        orderNo = Request.QueryString["strNo"];
        financeAction.Model.Orders = new Order();
        financeAction.Model.Orders.No = orderNo;
        financeAction.Model.Orders.Status=Convert.ToInt32(Constants.ORDER_STATUS_SUCCESSED_VALUE);
        financeAction.GetAmendmentOrder();
        newOrderAction.GetOrderItemAll(orderNo);
        balanceDateTime = financeAction.Model.Orders.BalanceDateTime;
        orderId = financeAction.Model.Orders.Id;
        customerId = financeAction.Model.Orders.CustomerId;
        scotInverse = Convert.ToDecimal(newOrderAction.GetScotInverse());
        if (!IsPostBack)
        {
            InitData();
            //支付方式
            this.cbPaymentType.DataSource = newOrderAction.Model.PaymentTypes;
            this.cbPaymentType.DataTextField = "label";
            this.cbPaymentType.DataValueField = "value";
            this.cbPaymentType.DataBind();
            //绑定客户支付方式
            cbPaymentType.Value = Convert.ToString(financeAction.Model.CustomerPayType);
        }
        
        if (Request.Form["subTag"] == "1")
        {
            Save();
        }
    }
    private void InitData() 
    {
        newOrderAction.GetFactorValue2(false);
        newOrderAction.InitMasterData();
        //重新获取预付款
        Order order = new Order();
        order.Id = orderId;
        order.No = Constants.PAY_KIND_PREPAY_VALUE;
        PrePayAmount = newOrderAction.GetPrePayAmount(order);
    }
    #endregion

    #region//Save
    /// <summary>
    /// 功能概要: 修正订单
    /// 作    者: 张晓林
    /// 创建时间: 2009年11月18日13:42:24
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    private void Save() 
    {
        try 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            #region//修改该订单
            Order order = new Order();
            order.Id = orderId;
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.CustomerName = newOrderAction.Model.NewOrder.CustomerName;
            order.PayType = int.Parse(cbPaymentType.Items[this.cbPaymentType.SelectedIndex].Value);
            order.CustomerId = customerId;
            decimal paidAmount = decimal.Parse(Request.Form["realAmount"]);//实收金额
            if (paidAmount >= 0)
            {
                order.PaidAmount = paidAmount;
            }
            else
            {
                order.PaidAmount = 0;
            }
            if (Request.Form["usePrepay"] == "Y") //预收冲减
            {
                order.PaidAmount += decimal.Parse(Request.Form["realPrePayAmount"]);
            }
            financeAction.Model.PaidAmount = order.PaidAmount;
            switch (Request.Form["ticket"])
            {
                case "Y"://欠发票
                    order.NeedTicket = Constants.TRUE;
                    order.NotPayTicketAmount = decimal.Parse(Request.Form["txtOweMoney"]);
                    order.PaidTicketAmount = decimal.Parse(Request.Form["txtPaidTicket"]);
                    break;
                case "N"://不欠发票
                    order.NeedTicket = Constants.TRUE;
                    order.NotPayTicketAmount = 0;
                    order.PaidTicketAmount = decimal.Parse(Request.Form["txtPayTicketMoney"]);
                    break;
                case "F"://不用给票
                    order.NeedTicket = Constants.FALSE;
                    order.NotPayTicketAmount = 0;
                    order.PaidTicketAmount = 0;
                    break;
            }
            order.PaidTicket = Request.Form["ticket"];
            order.BalanceDateTime = balanceDateTime;
            User cashUser = new User();
            cashUser.Id = user.Id;
            order.CashUser = cashUser;
            financeAction.Model.Orders = order;
            #endregion

            #region//获取订单明细计算业绩做准备
            financeAction.Model.OrderItemList = new List<OrderItem>();
            financeAction.Model.OrderItemEmployeeList = new List<OrderItemEmployee>();
            foreach (OrderItem oi in newOrderAction.Model.OrderItem)
            {
                //如果不冲减印章
                oi.OrdersId = orderId;
                oi.PaperConsumeCount = 0;
                oi.ConsumePaperAmount = 0;
                oi.IsUseSavedPaper = "N";
                oi.UnitDifferencePrice = 0;
                oi.CashConsumeCount = oi.Amount;
                oi.CashUnitPrice = oi.UnitPrice;
                oi.CashConsumeAmount = oi.Amount * oi.UnitPrice;
                financeAction.Model.OrderItemList.Add(oi);
            }
            #endregion

            #region //添加付款明细

            GatheringAndGatheringOrder gatheringAndGatheringorder = new GatheringAndGatheringOrder();
            gatheringAndGatheringorder.GatheringList = new List<Gathering>();
            financeAction.Model.IsUsePreAmount = false;
            financeAction.Model.IsUsePreDeposits = false;
            financeAction.Model.IsAccounting = false;
            if (order.PayType == Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE) financeAction.Model.IsAccounting = true;

            #region//没预收 有付款
            if (Request.Form["usePrepay"] != "Y" && Request.Form["isUsePreDeposits"] != "Y" && paidAmount > 0)
            {
                Gathering gathering = new Gathering();
                gathering.Amount = decimal.Parse(Request.Form["realAmount"]);
                gathering.GatheringDateTime = balanceDateTime;
                gatheringAndGatheringorder.GatheringList.Add(gathering);
                GatheringOrder gatheringOrder = new GatheringOrder();
                gatheringOrder.OrdersId = orderId;
                gatheringOrder.PayKind = Constants.PAY_KIND_CLOSED_VALUE;
                gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrder);
            }
            #endregion

            #region//有预收 有付款 
            else if ((Request.Form["usePrepay"] == "Y") && paidAmount > 0 && Request.Form["isUsePreDeposits"] != "Y")
            {
                financeAction.Model.IsUsePreAmount = true;
                Gathering gathering = new Gathering();
                gathering.Amount = decimal.Parse(Request.Form["realAmount"]);
                gathering.GatheringDateTime = balanceDateTime;
                gatheringAndGatheringorder.GatheringList.Add(gathering);
                GatheringOrder gatheringOrder = new GatheringOrder();
                gatheringOrder.OrdersId = orderId;
                gatheringOrder.PayKind = Constants.PAY_KIND_CLOSED_VALUE;
                gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrder);

                //使用预收款记录
                Gathering g = new Gathering();
                g.Amount = decimal.Parse(Request.Form["realPrePayAmount"]);
                g.GatheringDateTime = balanceDateTime;
                gatheringAndGatheringorder.GatheringList.Add(g);
                //付款明细相关的订单
                GatheringOrder gOrder = new GatheringOrder();
                gOrder.OrdersId = orderId;
                gOrder.PayKind = Constants.PAY_KIND_USE_PREPAY_VALUE;
                gatheringAndGatheringorder.GatheringOrderList.Add(gOrder);

            }
            #endregion

            #region//有预收 没付款
            else if ((Request.Form["usePrepay"] == "Y") && paidAmount <= 0)
            {
                financeAction.Model.IsUsePreAmount = true;
                //使用预收款记录
                Gathering g = new Gathering();
                g.Amount = decimal.Parse(Request.Form["realPrePayAmount"]);
                g.GatheringDateTime = balanceDateTime;
                gatheringAndGatheringorder.GatheringList.Add(g);
                
                //付款明细相关的订单
                GatheringOrder gatheringOrder = new GatheringOrder();
                gatheringOrder.OrdersId = orderId;
                gatheringOrder.PayKind = Constants.PAY_KIND_USE_PREPAY_VALUE;
                gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrder);
            }
            #endregion

            #region//无预收 没付款 
            else if ((Request.Form["usePrepay"] != "Y") && paidAmount <= 0)
            {
                Gathering g = new Gathering();
                g.Amount = paidAmount;
                g.GatheringDateTime = balanceDateTime;
                gatheringAndGatheringorder.GatheringList.Add(g);

                GatheringOrder gatheringOrder = new GatheringOrder();
                gatheringOrder.OrdersId = orderId;
                gatheringOrder.PayKind = Constants.PAY_KIND_CLOSED_VALUE;
                gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrder);
            }
            #endregion

        
            financeAction.Model.GatheringAndGatheringOrder.Add(gatheringAndGatheringorder);
            #region//抹零 优惠 舍入
            if (Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE != order.PayType)//记账时不允许有舍入
            {
                //抹零记录
                decimal ZeroMoney_deci = 0;

                if (!StringUtils.IsEmpty(Request.Form["ZeroMoney"]))
                {
                    ZeroMoney_deci = decimal.Parse(Request.Form["ZeroMoney"]);
                }
                if (ZeroMoney_deci != 0)
                {
                    PaymentConcession paymentConcession = new PaymentConcession();
                    paymentConcession.AuthUsers = user;
                    paymentConcession.ConcessionAmount = ZeroMoney_deci;
                    paymentConcession.ConcessionType = Constants.CONCESSION_TYPE_ZERO_VALUE;
                    paymentConcession.OperateDateTime = DateTime.Now;
                    paymentConcession.OperateUsers = user;
                    paymentConcession.Memo = Constants.CONSESSION_TYPE_ZERO_LABEL;
                    financeAction.Model.PaymentConcessionList.Add(paymentConcession);
                }

                //优惠记录
                decimal PreferentialMoney_deci = 0;
                if (!StringUtils.IsEmpty(Request.Form["PreferentialMoney"]))
                {
                    PreferentialMoney_deci = decimal.Parse(Request.Form["PreferentialMoney"]);
                }
                if (PreferentialMoney_deci != 0)
                {
                    PaymentConcession paymentConcession_yh = new PaymentConcession();
                    paymentConcession_yh.AuthUsers = user;
                    paymentConcession_yh.ConcessionAmount = PreferentialMoney_deci;
                    paymentConcession_yh.ConcessionType = Constants.CONCESSION_TYPE_CONCESSION_VALUE;
                    paymentConcession_yh.OperateDateTime = DateTime.Now;
                    paymentConcession_yh.OperateUsers = user;
                    paymentConcession_yh.Memo = Constants.CONSESSION_TYPE_CONCESSION_LABEL;
                    financeAction.Model.PaymentConcessionList.Add(paymentConcession_yh);
                }

                //舍入记录
                decimal roundMoney = 0;
                if (Request.Form["CarryMoney"] == "on")
                {
                    if (decimal.Parse(Request.Form["ReceivableMoney"]) > 0)
                    {
                        roundMoney = decimal.Parse(Request.Form["RealMoney"] == null ? "0" : Request.Form["RealMoney"]) - decimal.Parse(Request.Form["ReceivableMoney"]) - decimal.Parse(Request.Form["txtScotAmount"]);
                    }
                }
                if (roundMoney != 0)
                {
                    PaymentConcession paymentConcessionRound = new PaymentConcession();
                    paymentConcessionRound.AuthUsers = user;
                    if (roundMoney < 0)
                    {
                        paymentConcessionRound.ConcessionAmount = Math.Abs(roundMoney);
                        paymentConcessionRound.ConcessionType = Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE;
                        paymentConcessionRound.Memo = Constants.CONCESSION_TYPE_ROUND_NEGTIVE_LABEL;
                    }
                    else
                    {
                        paymentConcessionRound.ConcessionAmount = Math.Abs(roundMoney);
                        paymentConcessionRound.ConcessionType = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;
                        paymentConcessionRound.Memo = Constants.CONCESSION_TYPE_ROUND_POSITIVE_LABEL;
                    }
                    paymentConcessionRound.OperateDateTime = DateTime.Now;
                    paymentConcessionRound.OperateUsers = user;
                    financeAction.Model.PaymentConcessionList.Add(paymentConcessionRound);
                }
            }
            #endregion

            #endregion

            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            orderStatusAlter.Memo = "订单修正";
            orderStatusAlter.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            orderStatusAlter.OrdersId = orderId;
            financeAction.Model.OrderStatusAlter = orderStatusAlter;
            //参与人员
            RelationEmployee relationEmployee = new RelationEmployee();
            relationEmployee.EmployeeId = user.EmployeeId;
            financeAction.Model.RelationEmployee = relationEmployee;

            #region//统计税费
            if (null != Request.Form["txtScotAmount"] && "0" != Request.Form["txtScotAmount"])
            {
                OtherGatheringAndRefundmentRecord ogr = new OtherGatheringAndRefundmentRecord();
                ogr.Amount = Convert.ToDecimal(Request.Form["txtScotAmount"]);
                ogr.TicketAmountSum = 0;
                ogr.PayKind = Constants.BALANCE_SCOT_AMOUNT_KEY.ToString();
                ogr.Memo = "订单修正产生的税费";
                ogr.OrdersId = orderId;
                ogr.CustomerId = customerId;
                financeAction.Model.OtherGatheringAndRefundmentRecord = ogr;
            }
            #endregion

            financeAction.AmendmentOrder();
            PrintOrderBill(orderNo);
            closeFlag = true;
            //Response.Write("<script>window.opener.location.reload();</script>");
            //Response.Write("<script>window.opener.navigate('SelectAmendmentOrder.aspx');</script>");
            //Response.Write("<script>window.close()</script>");
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }

    #endregion

    #region //Print Report
    private void PrintOrderBill(string orderNo)
    {
        try
        {
            //订单详细信息
            newOrderAction.GetOrderInfo(orderNo);
            newOrderAction.GetOrderItemByOrderNo(orderNo);
            newOrderAction.GetOrderItemListByOrderNo(orderNo);
            newOrderAction.GetOrderItemPrintRequeireDetail(orderNo);
            newOrderAction.GetOrderItemFactorValueByOrderNo(orderNo);
            newOrderAction.GetOrderPaymentConcessionByOrderId(newOrderAction.SelectOrderIdByOrderNo(orderNo));
            newOrderAction.GetFactorValue(true);
            newOrderAction.GetAllUser();
            newOrderAction.InitMasterData();

            //订单员工信息
            Workflow.Da.Domain.OrderItemEmployee orderItemEmployee = new Workflow.Da.Domain.OrderItemEmployee();
            orderItemEmployee.No = orderNo;
            orderItemEmployee.PositionId1 = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.PositionId2 = Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.PositionId = Constants.POSITION_CASHER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.Id = Constants.POSITION_RECEPTION_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            newOrderAction.Model.OrderItemEmployee.Add(orderItemEmployee);
            newOrderAction.SelectOldEmployee();

            //送货人
            searchOrderAction.SearchDelivery(orderNo);
            newOrderAction.Model.PreDeposits = financeAction.Model.PreDeposits;
            newOrderAction.Model.IsUsePreAmount = financeAction.Model.IsUsePreAmount;
            newOrderAction.Model.IsUsePreDeposits = financeAction.Model.IsUsePreDeposits;
            newOrderAction.Model.IsAccounting = financeAction.Model.IsAccounting;
            newOrderAction.Model.PaidAmount = financeAction.Model.PaidAmount;
            ReportOrder ro = new ReportOrder();
            string reportName = "AmendmentOrder" + DateTime.Now.Ticks.ToString() + ".pdf";
            ro.FileName = Server.MapPath("~") + @"\reports\" + reportName;
            ro.CreateReport(newOrderAction.Model, "业务委托订单(修正)", "业务委托订单(修正)", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script>showPage('../reports/" + reportName + "', '_blank', 1024, 1024 , false, false, null);</script>");
        }
        catch (Exception ex)
        {
            Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
     #endregion
}
