using System;
using System.Web;
using System.Collections.Generic;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Membercard;

/// <summary>
/// 功能概要: 修正待结算订单
/// 作    者: 张晓林
/// 创建时间: 2010年7月19日15:17:17
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class finance_AmendmentBalanceOrder : System.Web.UI.Page
{
    #region 类成员
    protected OrderModel model;
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }

    private SearchMemberCardAction searchMemberCardAction;
    public SearchMemberCardAction SearchMemberCardAction
    {
        set { searchMemberCardAction = value; }
    }
    private SearchOrderAction sAction;
    public SearchOrderAction SearchOrderAction
    {
        set { sAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            newOrderAction.GetOrderInfo(Request.QueryString["strNo"]);
            newOrderAction.GetOrderItemListByOrderNo(Request.QueryString["strNo"]);
            newOrderAction.GetOrderItemPrintRequeireDetail(Request.QueryString["strNo"]);
            newOrderAction.GetOrderItemFactorValueByOrderNo(Request.QueryString["strNo"]);
            newOrderAction.InitMasterData();
            if (!IsPostBack)
            {
                InitData();
            }
            model = newOrderAction.Model;
            if ("Save" == Request.Form["Action"])
            {
                OrderSave();
            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region 数据绑定
    protected void InitData()
    {
        bool isHave = false;
        foreach (CustomerType c in newOrderAction.Model.CustomerTypes)
        {
            if (c.Id.ToString().Equals(Constants.SELECT_VALUE_NOT_SELECTED_KEY))
            {
                isHave = true;
                break;
            }
        }
        if (!isHave)
        {
            CustomerType item = new CustomerType();
            item.Id = int.Parse(Constants.SELECT_VALUE_NOT_SELECTED_KEY);
            item.Name = Constants.SELECT_VALUE_NOT_SELECTED_TEXT;
            newOrderAction.Model.CustomerTypes.Insert(0, item);
        }

        //客户类型
        this.cbCustomerType.DataSource = newOrderAction.Model.CustomerTypes;
        this.cbCustomerType.DataTextField = "NAME";
        this.cbCustomerType.DataValueField = "Id";
        this.cbCustomerType.DataBind();
        for (int i = 0; i < this.cbCustomerType.Items.Count; i++)
        {
            if (cbCustomerType.Items[i].Value == newOrderAction.Model.NewOrder.CustomerType.ToString())
            {
                cbCustomerType.Items[i].Selected = true;
            }
        }

        //支付方式
        this.cbPaymentType.DataSource = newOrderAction.Model.PaymentTypes;
        this.cbPaymentType.DataTextField = "label";
        this.cbPaymentType.DataValueField = "value";
        this.cbPaymentType.DataBind();
        for (int i = 0; i < this.cbPaymentType.Items.Count; i++)
        {
            if (cbPaymentType.Items[i].Value == newOrderAction.Model.NewOrder.PayType.ToString())
            {
                cbPaymentType.Items[i].Selected = true; ;
            }
        }
        //送货方式
        this.cbDeliveryType.DataSource = newOrderAction.Model.DevileryTypes;
        this.cbDeliveryType.DataTextField = "label";
        this.cbDeliveryType.DataValueField = "value";
        this.cbDeliveryType.DataBind();
        for (int i = 0; i < this.cbDeliveryType.Items.Count; i++)
        {
            if (cbDeliveryType.Items[i].Value == newOrderAction.Model.NewOrder.DeliveryType.ToString())
            {
                cbDeliveryType.Items[i].Selected = true;
            }
        }

        if (newOrderAction.Model.NewOrder.PrepareMoney == Constants.TRUE)
        {
            this.ckNeedPrepareMoney.Checked = true;
        }

    }
    #endregion

    #region//Save
    private void OrderSave()
    {
        try
        {
            Save(Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE);
            Response.Write("<script>window.close();</script>");
            Response.Write("<script>window.opener.location.reload();</script>");
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    private void Save(int orderStatus)
    {
        //订单基本信息
        Order order = newOrderAction.Model.NewOrder;
        order.Id = newOrderAction.SelectOrderIdByOrderNo(Request.QueryString["strNo"]);
        order.CustomerId = Int64.Parse(Request.Form["txtCustomerId"]);//需要客户ID
        order.CustomerName = Request.Form["CustomerName"];
        order.CustomerType = int.Parse(cbCustomerType.Items[this.cbCustomerType.SelectedIndex].Value);
        order.CustomerTypeName = cbCustomerType.Items[this.cbCustomerType.SelectedIndex].Text;
        order.Name = Request.Form["RealName"];
        order.LastTelNo = Request.Form["RealTelNo"];
        order.ProjectName = Request.Form["ItemName"];
        order.No = Request.QueryString["strNo"];
        order.PayType = int.Parse(cbPaymentType.Items[this.cbPaymentType.SelectedIndex].Value);
        order.BalanceDateTime = Constants.NULL_DATE_TIME;
        order.PaidTicket = Constants.FALSE;
        User employee = new User();
        employee.Id = (ThreadLocalUtils.CurrentUserContext.CurrentUser).Id;
        order.NewOrderUser = employee;
        order.CashUser = employee;
        if (ckNeedPrepareMoney.Checked)
        {
            order.PrepareMoney = Constants.TRUE;
            order.PrepareMoneyAmount = decimal.Parse(Request.Form["PrepayMoney"]);
        }
        else
        {
            order.PrepareMoney = Constants.FALSE;
            order.PrepareMoneyAmount = 0;
        }
        order.Status = orderStatus;
        if (ckNeedTicket.Checked) order.NeedTicket = Constants.TRUE;
        else order.NeedTicket = Constants.FALSE;
        order.DeliveryType = int.Parse(this.cbDeliveryType.Value);

        if (!string.IsNullOrEmpty(Request.Form["txtDeliveryDateTime"]))
        {
            DateTime d;
            if (DateTime.TryParse(Request.Form["txtDeliveryDateTime"], out d))
            {
                order.DeliveryDateTime = d;
            }
            else
            {
                order.DeliveryDateTime = Constants.NULL_DATE_TIME;
            }
        }
        else
        {
            order.DeliveryDateTime = Constants.NULL_DATE_TIME;
        }

        order.Memo = Request.Form["Memo"];
        if (!StringUtils.IsEmpty(Request.Form["MemberCardNo"]))
        {
            searchMemberCardAction.Model.Id = long.Parse(Request.Form["MemberCardId"]);
            searchMemberCardAction.SearchMemberCardById();
            order.MemberCardId = long.Parse(Request.Form["MemberCardId"]);
            order.MemberCardNo = searchMemberCardAction.Model.MemberCard.MemberCardNo;
        }
        else
        {
            order.MemberCardId = -1;
            order.MemberCardNo = null;

        }
        string[] strBusinessArr = Request.Form["businessType"].ToString().Split(',');
        order.OrderItemList = new List<OrderItem>();
        List<decimal> memberCardRestPaperCount = new List<decimal>();
        List<long> memberCardConcessionId = new List<long>();
        string strOrderItemIds = Request.Form["orderItemId"];
        string[] printOrderItemId = null;
        if (null != strOrderItemIds) printOrderItemId = strOrderItemIds.Split(',');

        //订单明细
        for (int i = 0; i < strBusinessArr.Length; i++)
        {

            OrderItem orderItemList = new OrderItem();
            orderItemList.BusinessTypeId = Convert.ToInt64(strBusinessArr[i]);
            orderItemList.Amount = 0;
            orderItemList.BusinessTypeName = "";
            orderItemList.CashConsumeAmount = 0;
            orderItemList.CashConsumeCount = 0;
            orderItemList.CashUnitPrice = 0;
            orderItemList.ConsumePaperAmount = 0;
            orderItemList.ForecastMoneyAmount = 0;
            orderItemList.PaperConsumeCount = 0;
            orderItemList.UnitDifferencePrice = 0;
            orderItemList.UnitPrice = 0;
            orderItemList.Values = "";
            orderItemList.IsUseSavedPaper = Constants.FALSE;

            if (null != printOrderItemId && printOrderItemId.Length > i)
            {
                if (string.IsNullOrEmpty(printOrderItemId[i]))
                {
                    orderItemList.Id = 0;
                }
                else
                {
                    orderItemList.Id = Convert.ToInt32(printOrderItemId[i].Split('-')[0]);
                    orderItemList.Version = Convert.ToInt32(printOrderItemId[i].Split('-')[1]);
                }
            }
            else
            {
                orderItemList.Id = 0;
            }
            string[] strPrintRequest = Request.Form["txtPrintRequest" + (i + 1)].ToString().Split(',');

            #region //注释了
            ////会员卡消费时　冲减印张数　更新会员累积消费金额
            //if (null != Request.Form["MemberCardNo"] && "" != Request.Form["MemberCardNo"])
            //{
            //    string[] strAmount = Request.Form["Amount"].ToString().Split(',');
            //    string[] strPrice = Request.Form["strPrice"].ToString().Split(',');
            //    long memberId = long.Parse(Request.Form["MemberCardId"].ToString());
            //    //查找活动时 去掉了基本门市价格这个参数，
            //    MemberCardConcession memberCardConcession = new MemberCardConcession();
            //    memberCardConcession.MemberCardId = memberId;
            //    //memberCardConcession.Id = priceId;
            //    newOrderAction.Model.MemberCardConcession = memberCardConcession;
            //    newOrderAction.SelectMemberCardConcessionByPriceIdAndConcessionId();

            //    for (int j = 0; j < newOrderAction.Model.MemberCardConcessionList.Count; j++)
            //    {
            //        for (int m = 0; m < memberCardConcessionId.Count; m++)
            //        {
            //            if (memberCardConcessionId[m] == newOrderAction.Model.MemberCardConcessionList[j].Id)
            //            {
            //                newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount = memberCardRestPaperCount[m];
            //            }
            //        }
            //    }
            //    memberCardConcessionId.Clear();
            //    memberCardRestPaperCount.Clear();
            //    decimal thisAmount = -decimal.Parse(strAmount[i]);
            //    //冲减价值
            //    decimal subValue = 0;
            //    for (int j = 0; j < newOrderAction.Model.MemberCardConcessionList.Count; j++)
            //    {
            //        thisAmount += newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount;
            //        if (thisAmount <= 0)
            //        {
            //            subValue += newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount * newOrderAction.Model.MemberCardConcessionList[j].PriceDifference;
            //            newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount = 0;
            //        }
            //        else if (thisAmount > 0)
            //        {
            //            subValue += newOrderAction.Model.MemberCardConcessionList[j].PriceDifference * Math.Abs(thisAmount);
            //            newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount += thisAmount;
            //        }
            //        newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount += -thisAmount;
            //        newOrderAction.Model.MemberCard.Id = long.Parse(Request.Form["MemberCardId"]);
            //        newOrderAction.Model.MemberCard.ConsumeAmount += decimal.Parse(strPrice[i]) * decimal.Parse(strAmount[i]);

            //        memberCardRestPaperCount.Add(newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount);
            //        memberCardConcessionId.Add(newOrderAction.Model.MemberCardConcessionList[j].Id);
            //    }
            //    //如果没有冲减完成，则就是现金消费
            //    if (thisAmount < 0)
            //    {
            //        orderItemList.CashConsumeCount = Math.Abs(thisAmount);
            //        orderItemList.CashUnitPrice = decimal.Parse(strPrice[i]);
            //        orderItemList.CashConsumeAmount = Math.Abs(thisAmount) * decimal.Parse(strPrice[i]);
            //    }
            //    orderItemList.PaperConsumeCount = decimal.Parse(strAmount[i]) + thisAmount;
            //    //差价取平均值
            //    if (0 != subValue && 0 != (decimal.Parse(strAmount[i]) + thisAmount))
            //    {
            //        orderItemList.UnitDifferencePrice = decimal.Parse((subValue / (decimal.Parse(strAmount[i]) + thisAmount)).ToString("#.00"));
            //    }
            //    else
            //    {
            //        orderItemList.UnitDifferencePrice = 0;
            //    }
            //    orderItemList.ConsumePaperAmount = subValue;
            //}
            #endregion

            orderItemList.PrintRequireDetailList = new List<PrintRequireDetail>();
            orderItemList.OrderItemFactorValueList = new List<OrderItemFactorValue>();



            //订单明细的印制要求
            for (int j = 0; j < strPrintRequest.Length; j++)
            {
                if (StringUtils.IsEmpty(strPrintRequest[j])) continue;
                PrintRequireDetail prd = new PrintRequireDetail();
                prd.PrintDemandDetailId = Convert.ToInt32(strPrintRequest[j]);
                orderItemList.PrintRequireDetailList.Add(prd);

            }
            string[] strFactorArr = Request.Form["txtFactorId" + (i + 1)].ToString().Split(',');
            string[] strFactorValueArr = Request.Form["txtFactorValue" + (i + 1)].ToString().Split(',');
            string[] strPriceFactorArr = Request.Form["priceFactorId" + (i + 1)].ToString().Split(',');
            //订单明细的因素的值
            for (int k = 0; k < strFactorArr.Length; k++)
            {
                OrderItemFactorValue factorValue = new OrderItemFactorValue();
                if (StringUtils.IsEmpty(strFactorArr[k]) || StringUtils.IsEmpty(strFactorValueArr[k]) || StringUtils.IsEmpty(strPriceFactorArr[k])) break;
                factorValue.PriceFactorId = Int64.Parse(strPriceFactorArr[k]);// Int64.Parse(strBusinessArr[i]);
                factorValue.Value = strFactorArr[k];// strFactorValueArr[k];
                orderItemList.OrderItemFactorValueList.Add(factorValue);
            }

            order.OrderItemList.Add(orderItemList);

            //订单状态变更履历
            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            orderStatusAlter.OrdersId = Convert.ToInt64(Request.Form["OrdersId"]);
            orderStatusAlter.Memo = "修正待结算订单";
            orderStatusAlter.Status = orderStatus;// Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
            newOrderAction.Model.OrderStatusAlter = orderStatusAlter;
        }
        //如果有价格,则修改价格
        if (!StringUtils.IsEmpty(Request.Form["strPrice"]))
        {
            string[] strPrice = Request.Form["strPrice"].ToString().Split(',');
            for (int i = 0; i < strPrice.Length; i++)
            {
                if (StringUtils.IsEmpty(strPrice[i]))//|| 0 == decimal.Parse(strPrice[i]))
                {
                    Response.Write("<script>alert('单价不能为 0 !')</script>");
                    return;
                }
                order.OrderItemList[i].UnitPrice = decimal.Parse(strPrice[i]);
            }
        }
        if (!StringUtils.IsEmpty(Request.Form["Amount"]))
        {
            string[] strAmount = Request.Form["Amount"].ToString().Split(',');
            for (int i = 0; i < strAmount.Length; i++)
            {
                if (StringUtils.IsEmpty(strAmount[i]) || 0 == decimal.Parse(strAmount[i]))
                {
                    Response.Write("<script>alert('数量不能为 0 !')</script>");
                    return;
                }
                order.OrderItemList[i].Amount = decimal.Parse(strAmount[i]);
            }
        }
        decimal totalMoney = 0;
        foreach (OrderItem orderItem in order.OrderItemList)
        {
            totalMoney += decimal.Round(orderItem.UnitPrice, 2) * orderItem.Amount;
        }
        newOrderAction.Model.NewOrder.SumAmount = totalMoney;
        newOrderAction.RealFactureOrder();
    }
    #endregion

}
