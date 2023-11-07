﻿using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using Workflow.Da;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Action.Finance;
using Workflow.Support.Report;
using Workflow.Action.Membercard;
using Workflow.Action.Finance.Model;
using iTextSharp.text;
/// <summary>
/// 名    称: PayForOrder
/// 功能概要: 订单结算页面
/// 作    者: 付强
/// 创建时间: 2009-12-20
/// 修正履历: (修正人:张晓林 修正:1.只有记账客户才可以预存找零金额;2.找零金额计算BUG 日期:2010年6月5日10:57:17)
/// 修正时间: 
/// </summary>
public partial class PayForOrder : Workflow.Web.PageBase
{
    #region //Class Member
    private static string orderNo = "";
    private static long orderId = 0;
	private static long memberCardId = 0;
    protected decimal scotInverse=0;
    protected Boolean closeFlag = false;
    /// <summary>
    /// 预付
    /// </summary>
    protected decimal PrePayAmount = 0;
    /// <summary>
    /// 应收
    /// </summary>
    protected decimal needMoney = 0;
    /// <summary>
    /// 找零
    /// </summary>
    protected decimal returnMoney = 0;

    protected decimal preDeposit = 0;
    protected int customerPayType =0;
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

    private MemberCardAction memberCardAction;
    public MemberCardAction MemberCardAction 
    {
        set { memberCardAction = value; }
    }
    #endregion

    #region //Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = newOrderAction.Model;
        orderNo = Request.QueryString["strNo"];
        orderId = newOrderAction.SelectOrderIdByOrderNo(orderNo);
        newOrderAction.GetOrderInfo(orderNo);
        customerPayType = (int)model.CustomerPayType;

        //重新获取预付款
        Order order = new Order();
        order.Id = orderId;
        order.No = Constants.PAY_KIND_PREPAY_VALUE;
        PrePayAmount = newOrderAction.GetPrePayAmount(order);

        scotInverse = Convert.ToDecimal(newOrderAction.GetScotInverse());
        hiddMemberCardId.Value = model.NewOrder.MemberCardId.ToString();
        hiddOrderId.Value = model.NewOrder.Id.ToString();
        
        newOrderAction.GetOrderItemAll(orderNo);
        newOrderAction.GetFactorValue2(false);
        //获取基础数据
        newOrderAction.InitMasterData();


		hidOrderNo.Value = orderNo;
		memberCardId = model.NewOrder.MemberCardId;
		hiddMemberCardId.Value = memberCardId.ToString();

        long customerId = newOrderAction.Model.NewOrder.CustomerId;
        long cuSacttId = Constants.scatteredClientId(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
        long cuStudentId = Constants.studentClientId(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
        if(cuSacttId!=customerId && customerId!=cuStudentId)
        {
            tdPreSaveAmount.Visible = true;
        }

        if (!IsPostBack)
        {
            //支付方式
            this.cbPaymentType.DataSource = newOrderAction.Model.PaymentTypes;
            this.cbPaymentType.DataTextField = "label";
            this.cbPaymentType.DataValueField = "value";
            this.cbPaymentType.DataBind();
            //绑定客户支付方式
            cbPaymentType.Value = Convert.ToString(model.CustomerPayType);
        }
        if ( "1"==Request.Form["subTag"])
        {
            decimal orderSumAmount = model.NewOrder.SumAmount;
            decimal orderItemSumAmount = getOrderItemAmount(model.OrderItem);
            if (orderSumAmount != orderItemSumAmount)
            {
                Exception ex = new Exception("订单明细总金额不等于订单金额!请返回重新分配订单明细!");
                Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                throw ex;
            }
            //防止重复结算(结算完后由于某种原因页面没刷新)
            if (Constants.ORDER_STATUS_SUCCESSED_VALUE != model.NewOrder.Status)
            {
                Save();
            }
            else
            {
                Response.Write("<script>alert('该订单已经结算完成！');</script>");
                Response.Write("<script>window.opener.navigate('selectOrder.aspx');</script>");
            }
        }
		
    }
    private decimal getOrderItemAmount(IList<OrderItem> orderItemList) 
    {
        decimal amount = 0;
        foreach(OrderItem oi in orderItemList)
        {
            amount += oi.Amount * oi.UnitPrice;
        }
        return amount;
    }
    #endregion

    #region //Save
    public void Save()
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
            order.CustomerId = newOrderAction.Model.NewOrder.CustomerId;

            decimal paidAmount = decimal.Parse(Request.Form["realAmount"]);//实际付款金额(现金) 
            //if (Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE == order.PayType) paidAmount = 0;

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
            if (Request.Form["isUsePreDeposits"] == "Y")//预存冲减
            {
                order.PaidAmount+=decimal.Parse(Request.Form["realPreDepositsAmount"]);
            }
            financeAction.Model.PaidAmount = order.PaidAmount;
            switch (Request.Form["ticket"])
            {
                case "Y"://欠发票
                    //order.PaidTicket = Constants.TRUE;
                    order.NeedTicket = Constants.TRUE;
                    order.NotPayTicketAmount = decimal.Parse(Request.Form["txtOweMoney"]);
                    order.PaidTicketAmount = decimal.Parse(Request.Form["txtPaidTicket"]);
                    AddPaidTicketRecord();
                    break;
                case "N"://不欠发票
                    //order.PaidTicket = Constants.TRUE;
                    order.NeedTicket = Constants.TRUE;
                    order.NotPayTicketAmount = 0;
                    order.PaidTicketAmount = decimal.Parse(Request.Form["txtPayTicketMoney"]);
                    AddPaidTicketRecord();
                    break;
                case "F"://不用给票
                    //order.PaidTicket = Constants.FALSE;
                    order.NeedTicket = Constants.FALSE;
                    order.NotPayTicketAmount = 0;
                    order.PaidTicketAmount = 0;
                    break;
            }
            order.PaidTicket = Request.Form["ticket"];
            order.BalanceDateTime = DateTime.Now;
            User cashUser = new User();
            cashUser.Id = user.Id;
            order.CashUser = cashUser;
            order.RealPaidAmount = paidAmount;
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

                //收银人员只从Order表中取 不保存在订单明细的参与人员表中
                //OrderItemEmployee oiei = new OrderItemEmployee();
                //oiei.EmployeeId = user.EmployeeId;
                //oiei.OrderItemId = oi.Id;
                //financeAction.Model.OrderItemEmployeeList.Add(oiei);
            }
            #endregion

            //添加付款明细

            //decimal ReceivableMoney_deci = 0;
            GatheringAndGatheringOrder gatheringAndGatheringorder = new GatheringAndGatheringOrder();
            gatheringAndGatheringorder.GatheringList = new List<Gathering>();
            financeAction.Model.IsUsePreAmount = false;
            financeAction.Model.IsUsePreDeposits = false;
            financeAction.Model.IsAccounting = false;
            if (order.PayType == Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE)  financeAction.Model.IsAccounting = true;

            #region//没预收 有付款 没预存
            if (Request.Form["usePrepay"] != "Y" && Request.Form["isUsePreDeposits"] != "Y" && paidAmount > 0)
            {
                //ReceivableMoney_deci = decimal.Parse(Request.Form["realAmount"]);

                Gathering gathering = new Gathering();
                //if (ReceivableMoney_deci >= 0)
                //{
                //    gathering.Amount = ReceivableMoney_deci;
                //}
                //else
                //{
                //    gathering.Amount = 0;
                //}
                gathering.Amount = paidAmount;
                gathering.GatheringDateTime = DateTime.Now;
                gatheringAndGatheringorder.GatheringList.Add(gathering);



                //financeAction.Model.Gatherings = gathering;
                //付款明细相关的订单
                GatheringOrder gatheringOrder = new GatheringOrder();
                gatheringOrder.OrdersId = orderId;
                gatheringOrder.PayKind = Constants.PAY_KIND_CLOSED_VALUE;
                gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrder);
            }
            #endregion
            #region//有预收 有付款 无预存
            else if ((Request.Form["usePrepay"] == "Y") && paidAmount > 0 && Request.Form["isUsePreDeposits"] != "Y")
            {
                financeAction.Model.IsUsePreAmount = true;
                //实收金额记录
                //ReceivableMoney_deci = decimal.Parse(Request.Form["realAmount"]);
                Gathering gathering = new Gathering();
                //if (ReceivableMoney_deci >= 0)
                //{
                //    gathering.Amount = ReceivableMoney_deci;
                //}
                //else
                //{
                //    gathering.Amount = 0;
                //}
                gathering.Amount = paidAmount;
                gathering.GatheringDateTime = DateTime.Now;
                gatheringAndGatheringorder.GatheringList.Add(gathering);
                //financeAction.Model.Gatherings = gathering;
                //付款明细相关的订单
                GatheringOrder gatheringOrder = new GatheringOrder();
                gatheringOrder.OrdersId = orderId;
                gatheringOrder.PayKind = Constants.PAY_KIND_CLOSED_VALUE;
                gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrder);

                //使用预收款记录
                Gathering g = new Gathering();
                g.Amount = decimal.Parse(Request.Form["realPrePayAmount"]);
                g.GatheringDateTime = DateTime.Now;

                gatheringAndGatheringorder.GatheringList.Add(g);
                //financeAction.Model.Gatherings = gathering;
                //付款明细相关的订单
                GatheringOrder gOrder = new GatheringOrder();
                gOrder.OrdersId = orderId;
                gOrder.PayKind = Constants.PAY_KIND_USE_PREPAY_VALUE;
                gatheringAndGatheringorder.GatheringOrderList.Add(gOrder);

            }
            #endregion
            #region//有预收 没付款 无预存
            else if ((Request.Form["usePrepay"] == "Y") && paidAmount <= 0 && Request.Form["isUsePreDeposits"] != "Y")
            {
                financeAction.Model.IsUsePreAmount = true;
                //使用预收款记录
                Gathering g = new Gathering();
                g.Amount = decimal.Parse(Request.Form["realPrePayAmount"]);
                g.GatheringDateTime = DateTime.Now;
                gatheringAndGatheringorder.GatheringList.Add(g);
                //financeAction.Model.Gatherings = gathering;
                //付款明细相关的订单
                GatheringOrder gatheringOrder = new GatheringOrder();
                gatheringOrder.OrdersId = orderId;
                gatheringOrder.PayKind = Constants.PAY_KIND_USE_PREPAY_VALUE;
                gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrder);
            }
            #endregion
            #region//无预收 没付款 无预存
            else if ((Request.Form["usePrepay"] != "Y") && paidAmount <= 0 && Request.Form["isUsePreDeposits"] != "Y")
            {
                Gathering g = new Gathering();
                g.Amount = paidAmount;
                g.GatheringDateTime = DateTime.Now;
                gatheringAndGatheringorder.GatheringList.Add(g);

                GatheringOrder gatheringOrder = new GatheringOrder();
                gatheringOrder.OrdersId = orderId;
                gatheringOrder.PayKind = Constants.PAY_KIND_CLOSED_VALUE;
                gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrder);
            }
            #endregion
            #region//有预收 有付款 有预存
            else if ((Request.Form["usePrepay"] == "Y") && paidAmount> 0 && Request.Form["isUsePreDeposits"] == "Y")
            {
                financeAction.Model.IsUsePreAmount = true;
                financeAction.Model.IsUsePreDeposits = true;

                //付款
                Gathering ga = new Gathering();
                ga.Amount = paidAmount;//decimal.Parse(Request.Form["realAmount"]);
                ga.GatheringDateTime = DateTime.Now;
                gatheringAndGatheringorder.GatheringList.Add(ga);
                //付款明细相关的订单
                GatheringOrder gatheringOrder = new GatheringOrder();
                gatheringOrder.OrdersId = orderId;
                gatheringOrder.PayKind = Constants.PAY_KIND_CLOSED_VALUE;
                gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrder);

                //预收
                Gathering gPre = new Gathering();
                gPre.Amount = decimal.Parse(Request.Form["realPrePayAmount"]);
                gPre.GatheringDateTime = DateTime.Now;
                gatheringAndGatheringorder.GatheringList.Add(gPre);
                //付款明细相关的订单
                GatheringOrder gatheringOrderPre = new GatheringOrder();
                gatheringOrderPre.OrdersId = orderId;
                gatheringOrderPre.PayKind = Constants.PAY_KIND_USE_PREPAY_VALUE;
                //gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrderPre);

                //预存
                Gathering gatheringPreDepos = new Gathering();
                gatheringPreDepos.Amount = decimal.Parse(Request.Form["realPreDepositsAmount"]);
                gatheringPreDepos.GatheringDateTime = DateTime.Now;
                gatheringAndGatheringorder.GatheringList.Add(gatheringPreDepos);
                //付款明细相关的订单
                GatheringOrder gatheringOrderPreDe = new GatheringOrder();
                gatheringOrderPreDe.OrdersId = orderId;
                gatheringOrderPreDe.PayKind = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;
                //gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrderPreDe);
            }
            #endregion
            #region//无预收 有付款 有预存
            else if ((Request.Form["usePrepay"] != "Y") && paidAmount > 0 && Request.Form["isUsePreDeposits"] == "Y")
            {
                financeAction.Model.IsUsePreDeposits = true;
                //付款
                Gathering ga = new Gathering();
                ga.Amount = paidAmount;//decimal.Parse(Request.Form["realAmount"]);
                ga.GatheringDateTime = DateTime.Now;
                gatheringAndGatheringorder.GatheringList.Add(ga);
                //付款明细相关的订单
                GatheringOrder gatheringOrder = new GatheringOrder();
                gatheringOrder.OrdersId = orderId;
                gatheringOrder.PayKind = Constants.PAY_KIND_CLOSED_VALUE;
                gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrder);

                //预存
                Gathering gatheringPreDepos = new Gathering();
                gatheringPreDepos.Amount = decimal.Parse(Request.Form["realPreDepositsAmount"]);
                gatheringPreDepos.GatheringDateTime = DateTime.Now;
                gatheringAndGatheringorder.GatheringList.Add(gatheringPreDepos);
                //付款明细相关的订单
                GatheringOrder gatheringOrderPreDe = new GatheringOrder();
                gatheringOrderPreDe.OrdersId = orderId;
                gatheringOrderPreDe.PayKind = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;
                //gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrderPreDe);
            }
            #endregion
            #region//有预收 无付款 有预存
            else if ((Request.Form["usePrepay"] == "Y") && paidAmount <= 0 && Request.Form["isUsePreDeposits"] == "Y")
            {
                financeAction.Model.IsUsePreAmount = true;
                financeAction.Model.IsUsePreDeposits = true;
                //预收
                Gathering gPre = new Gathering();
                gPre.Amount = decimal.Parse(Request.Form["realPrePayAmount"]);
                gPre.GatheringDateTime = DateTime.Now;
                gatheringAndGatheringorder.GatheringList.Add(gPre);
                //付款明细相关的订单
                GatheringOrder gatheringOrderPre = new GatheringOrder();
                gatheringOrderPre.OrdersId = orderId;
                gatheringOrderPre.PayKind = Constants.PAY_KIND_USE_PREPAY_VALUE;
                gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrderPre);

                //预存
                Gathering gatheringPreDepos = new Gathering();
                gatheringPreDepos.Amount = decimal.Parse(Request.Form["realPreDepositsAmount"]);
                gatheringPreDepos.GatheringDateTime = DateTime.Now;
                gatheringAndGatheringorder.GatheringList.Add(gatheringPreDepos);
                //付款明细相关的订单
                GatheringOrder gatheringOrderPreDe = new GatheringOrder();
                gatheringOrderPreDe.OrdersId = orderId;
                gatheringOrderPreDe.PayKind = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;
                //gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrderPreDe);
            }
            #endregion
            #region//无预收 无付款 有预存
            else if ((Request.Form["usePrepay"] != "Y") && paidAmount <= 0 && Request.Form["isUsePreDeposits"] == "Y")
            {
                financeAction.Model.IsUsePreDeposits = true;
                //预存
                Gathering gatheringPreDepos = new Gathering();
                gatheringPreDepos.Amount = decimal.Parse(Request.Form["realPreDepositsAmount"]);
                gatheringPreDepos.GatheringDateTime = DateTime.Now;
                gatheringAndGatheringorder.GatheringList.Add(gatheringPreDepos);
                //付款明细相关的订单
                GatheringOrder gatheringOrderPreDe = new GatheringOrder();
                gatheringOrderPreDe.OrdersId = orderId;
                gatheringOrderPreDe.PayKind = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;
                gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
                gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrderPreDe);
            }
            #endregion

            #region //会员卡冲减

            //if (null != Request.Form["useSavePaper"] && "on" == Request.Form["useSavePaper"])
            //{
            //    long memberCardId = Convert.ToInt32(Request.QueryString["memberCardId"]);
            //    memberCardAction.Model.MemberCard = new MemberCard();
            //    memberCardAction.Model.MemberCard.Id = memberCardId;
            //    memberCardAction.Model.MemberCard.OperateType = orderId;//订单Id
            //    memberCardAction.Model.MemberCard.BranchShopId = Convert.ToInt32(Request.Form["UseSavePaperCounter"]);//本次冲减的印章数
            //    memberCardAction.Model.MemberCard.ConsumeAmount = Convert.ToDecimal(Request.Form["diffAmount"]);//本次冲减金额
            //    //memberCardAction.MemberCardDiff();

            //    #region//添加会员卡冲减记录

            //    ReceivableMoney_deci = Convert.ToDecimal(Request.Form["diffAmount"]);

            //    Gathering gathering = new Gathering();
            //    if (ReceivableMoney_deci >= 0)
            //    {
            //        gathering.Amount = ReceivableMoney_deci;
            //    }
            //    else
            //    {
            //        gathering.Amount = 0;
            //    }
            //    gathering.GatheringDateTime = DateTime.Now;
            //    gatheringAndGatheringorder.GatheringList.Add(gathering);
            //    //financeAction.Model.Gatherings = gathering;
            //    //付款明细相关的订单
            //    GatheringOrder gatheringOrder = new GatheringOrder();
            //    gatheringOrder.OrdersId = orderId;
            //    gatheringOrder.PayKind = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;
            //    if (null == gatheringAndGatheringorder.GatheringOrderList)
            //    {
            //        gatheringAndGatheringorder.GatheringOrderList = new List<GatheringOrder>();
            //    }
            //    gatheringAndGatheringorder.GatheringOrderList.Add(gatheringOrder);
            //    #endregion
            //}
            #endregion

            #region //注释掉的代码
            ////记录找零 付强 2008-12-19
            //if (decimal.Parse(Request.Form["returnMoney"]) > 0)
            //{
            //    Gathering g = new Gathering();
            //    g.Amount = -decimal.Parse(Request.Form["returnMoney"]);
            //    g.GatheringDateTime = DateTime.Now;
            //    gatheringAndGatheringorder.GatheringList.Add(g);

            //    GatheringOrder gOrder = new GatheringOrder();
            //    gOrder.OrdersId = orderId;
            //    gOrder.PayKind = Constants.PAY_KIND_RETURN_VALUE;
            //    gatheringAndGatheringorder.GatheringOrderList.Add(gOrder);
            //}

            //financeAction.Model.GatheringOrders = gatheringOrder;
            #endregion

            financeAction.Model.GatheringAndGatheringOrder.Add(gatheringAndGatheringorder);

            #region//优惠/抹零
            if (Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE != order.PayType)
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

            #region //注释掉的代码
            //申请挂账记录
            //if (!StringUtils.IsEmpty(Request.Form["AccountMoney"]))
            //{
            //    RequireAccountingInfo requreAccountingInfo = new RequireAccountingInfo();
            //    requreAccountingInfo.Orders = order;          //订单
            //    requreAccountingInfo.Passed = Constants.TRUE;
            //    requreAccountingInfo.Users = user;
            //    financeAction.Model.RequireAccountingInfo = requreAccountingInfo;


			//}
			#endregion

			#region 活动

			financeAction.Model.CampaignData = hidCampaignVal.Value;

			if (!string.IsNullOrEmpty(financeAction.Model.CampaignData))
			{
				financeAction.Model.MemberCardId = memberCardId;
				financeAction.ParseCampaignData();
			}

			#endregion

            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            orderStatusAlter.Memo = "订单结算";
            orderStatusAlter.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            orderStatusAlter.OrdersId = orderId;
            financeAction.Model.OrderStatusAlter = orderStatusAlter;
            //参与人员
            RelationEmployee relationEmployee = new RelationEmployee();
            relationEmployee.EmployeeId = user.EmployeeId;
            financeAction.Model.RelationEmployee = relationEmployee;
            
            #region//预存款冲减
            if ("Y" == Request.Form["isUsePreDeposits"])
            {
                financeAction.Model.PreDeposits = Convert.ToDecimal(Request.Form["realPreDepositsAmount"]);
            }
            #endregion

            #region//统计会员消费积分
            if ("0" != Request.QueryString["memberCardId"].Trim())
            {
                financeAction.Model.Orders.IsNotStatisticsPoints =true;
            }
            #endregion

            #region//客户预存款
            //除散客和学生客户外才可以预存
            if ("" != Request.Form["preDepositAmount"] && Convert.ToDecimal(Request.Form["preDepositAmount"])>0)
            {
                financeAction.Model.CustomerPreDeposits = Convert.ToDecimal(Request.Form["preDepositAmount"]);
            }
            #endregion

            #region//统计税费
            if (null != Request.Form["txtScotAmount"] && "0" != Request.Form["txtScotAmount"]) 
            {
                OtherGatheringAndRefundmentRecord ogr = new OtherGatheringAndRefundmentRecord();
                ogr.Amount = Convert.ToDecimal(Request.Form["txtScotAmount"]);
                ogr.TicketAmountSum = Convert.ToDecimal(Request.Form["txtPaidTicket"]) + Convert.ToDecimal(Request.Form["txtPayTicketMoney"]);
                ogr.PayKind = Constants.BALANCE_SCOT_AMOUNT_KEY.ToString();
                ogr.Memo = "结算:订单结算时产生的税费";
                ogr.OrdersId = orderId;
                ogr.CustomerId = order.CustomerId;
                financeAction.Model.OtherGatheringAndRefundmentRecord = ogr;
            }
            #endregion

            financeAction.CloseOrder();
        }
        catch (Exception ex)
        {
            Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

        //
        string tagJat = Request.Form["hidHaveJat"];
        if (!String.IsNullOrEmpty(tagJat) && tagJat.Equals("1"))
        {
            //打印小票
            PrintSmallTicket(orderNo);
        }
        else
        {
            PrintOrderBill(orderNo);
        }
        
		//Response.Write("<script>window.opener.location.reload();</script>");
		//Response.Write("<script>window.close();</script>");
		//Response.Write("<script>showPage('SmallTicketPrintConfirm.aspx', null, 850, 900, false, false);</script>");
		//Page.ClientScript.RegisterStartupScript(this.GetType(), "aspx", "<script>showPage('SmallTicketPrintConfirm.aspx?OrderNo=" + orderNo + "', '_blank', 1024, 1024 , false, false, null);</script>");
        closeFlag = true;
        model = null;
    }

    /// <summary>
    /// 功能概要: 添加付票记录
    /// 作    者: 张晓林
    /// 创建时间: 2009年12月29日17:40:03
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    private void AddPaidTicketRecord() 
    {
        decimal paidTicket = 0 != decimal.Parse(Request.Form["txtPaidTicket"]) ? decimal.Parse(Request.Form["txtPaidTicket"]) : decimal.Parse(Request.Form["txtPayTicketMoney"]);
        if (paidTicket > 0)
        {
            OtherGatheringAndRefundmentRecord ogAndRe = new OtherGatheringAndRefundmentRecord();
            ogAndRe.CustomerId = newOrderAction.Model.NewOrder.CustomerId;
            ogAndRe.Amount = 0;
            ogAndRe.TicketAmountSum = paidTicket;
            ogAndRe.Memo = "结算:付票记录";
            ogAndRe.PayKind = Constants.BALANCE_TICKET_AMOUNT_KEY.ToString();
            ogAndRe.OrdersId = orderId;
            financeAction.Model.OtherGatheringAndRefundmentRecordPaidTicketRecord = ogAndRe;
        }
    }
    #endregion

	#region //注释掉的部分
	//public void CalculateForLogCounter()
    //{
    //    //newOrderAction.GetOrderItemFactorValueByOrderNo(orderNo);
        
    //    for (int m = 0; m < newOrderAction.Model.RealOrderItem.Count; m++)
    //    {
    //        long machineId = 0;
    //        long paperSpecificationId = 0;
    //        long processContentId = 0;
    //        decimal amount = 0;
    //        decimal trashAmount = 0;
    //        for (int j = 0; j < newOrderAction.Model.BusinessType.Count; j++)
    //        {
    //            for (int i = 0; i < newOrderAction.Model.RealOrderItemList.Count; i++)
    //            {
    //                if (newOrderAction.Model.RealOrderItem[m].Id == newOrderAction.Model.RealOrderItemList[i].Id)
    //                {
    //                    if (Constants.TRUE == newOrderAction.Model.BusinessType[j].NeedRecordMachine)
    //                    {
    //                        for (int n = 0; n < newOrderAction.Model.PriceFactor.Count; n++)
    //                        {
    //                            financeAction.Model.OrdersForRecordMachineSumList = new List<OrdersForRecordMachineSum>();
    //                            if (Constants.PRICE_FACTOR_MACHINE_ID == newOrderAction.Model.RealOrderItemList[i].PriceFactorId)
    //                            {
    //                                machineId = long.Parse(newOrderAction.Model.RealOrderItemList[i].Values);
    //                                amount = newOrderAction.Model.RealOrderItemList[i].Amount;
    //                                trashAmount = newOrderAction.Model.RealOrderItemList[i].TrashPapers;
    //                            }
    //                            else if (Constants.PRICE_FACTOR_PAPER_SPECIFICATION_ID == newOrderAction.Model.RealOrderItemList[i].PriceFactorId)
    //                            {
    //                                paperSpecificationId = long.Parse(newOrderAction.Model.RealOrderItemList[i].Values);
    //                            }
    //                            else if (Constants.PRICE_FACTOR_PROCESS_CONTENT_ID == newOrderAction.Model.RealOrderItemList[i].PriceFactorId)
    //                            {
    //                                processContentId = long.Parse(newOrderAction.Model.RealOrderItemList[i].Values);
    //                            }
    //                            else
    //                            {
    //                                continue;
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        //if (0 != machineId && 0 != paperSpecificationId && 0 != processContentId && 0 != amount)
    //        if (0 != machineId  && 0 != amount)
    //        {
    //            OrdersForRecordMachineSum ordersForRecordMachinieSum = new OrdersForRecordMachineSum();
    //            ordersForRecordMachinieSum.MachineId = machineId;
    //            ordersForRecordMachinieSum.OrdersId = orderId;
    //            if (0 != paperSpecificationId)
    //            {
    //                PaperSpecification pas = new PaperSpecification();
    //                pas.Id = paperSpecificationId;
    //                ordersForRecordMachinieSum.PaperSpecification = pas;
    //            }
    //            else
    //            {
    //                ordersForRecordMachinieSum.PaperSpecification = null;
    //            }
    //            ordersForRecordMachinieSum.PaperCount = amount;
    //            ordersForRecordMachinieSum.TrashPapers = trashAmount;
    //            ordersForRecordMachinieSum.BalanceDateTime = DateTime.Now;
    //            if (0 != processContentId)
    //            {
    //                ordersForRecordMachinieSum.ColorType = financeAction.GetProcessContentById(processContentId);
    //            }
    //            else
    //            {
    //                ordersForRecordMachinieSum.ColorType = "0";
    //            }
    //            financeAction.Model.OrdersForRecordMachineSumList.Add(ordersForRecordMachinieSum);
    //        }
    //    }
    //}
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
            //string reportName = "CloseOrder" + ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId.ToString() + ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId.ToString() + newOrderAction.Model.NewOrder.Id.ToString() + ".pdf";
            string reportName = "CloseOrder" + DateTime.Now.Ticks.ToString() + ".pdf";
            ro.FileName = Server.MapPath("~") + @"\reports\" + reportName;
            ro.CreateReport(newOrderAction.Model, "业务委托订单", "业务委托订单", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script>showPage('../reports/" + reportName + "', '_blank', 1024, 1024 , false, false, null);</script>");

			
        }
        catch (Exception ex)
        {
            Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

	#region//Print Small Ticket
	/// <summary>
	///  功     能：结算完后打印小票
	///  作     者：张晓林
	///  日     期: 2010年4月1日15:25:28
	/// </summary>
	private void PrintSmallTicket(string orderNo)
	{
		try
		{
			//转向打印小票
			Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>showPage('SmallTicketPrintConfirm.aspx?OrderNo=" + orderNo + "', '_blank', 800, 600 , false, false, null);</script>");
			//newOrderAction.GetOrderInfo(orderNo);
			//ReportSmallTicket ro = new ReportSmallTicket();
			//string reportName = "CloseOrder" + DateTime.Now.Ticks.ToString() + ".pdf";
			//ro.FileName = Server.MapPath("~") + @"\reports\" + reportName;
			//ro.CreateReport(newOrderAction.Model, "结算单", "结算单", PageSize.A4, 10, 10, 10, 10);
			//Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script>showPage('../reports/" + reportName + "', '_blank', 1024, 1024 , false, false, null);</script>");
		}
		catch (Exception ex)
		{
			Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
			throw ex;
		}
	}
	#endregion
}
