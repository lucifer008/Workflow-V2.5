using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Util;
using Workflow.Action;
using Workflow.Action.Membercard;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称: RealFactureOrder
/// 功能概要: 修正加订单
/// 作    者: 付强
/// 创建时间: 2007-10-8
/// 修正履历: 2009-1-12
/// 修正时间: 付强
///           添加重新分配人员的功能
/// </summary>
public partial class OrderRealFactureOrder :Workflow.Web.PageBase
{
    #region 类成员
    protected Boolean closeFlag = false;
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
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            newOrderAction.GetOrderInfo(Request.QueryString["strNo"]);
            //newOrderAction.GetOrderItemByOrderNo(Request.QueryString["strNo"]);
            newOrderAction.GetOrderItemListByOrderNo(Request.QueryString["strNo"]);
            newOrderAction.GetOrderItemPrintRequeireDetail(Request.QueryString["strNo"]);
            newOrderAction.GetOrderItemFactorValueByOrderNo(Request.QueryString["strNo"]);
            newOrderAction.InitMasterData();
            if (!IsPostBack)
            {
                InitData();
            }
            model = newOrderAction.Model;
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

        if(newOrderAction.Model.NewOrder.PrepareMoney==Constants.TRUE)
        {
            this.ckNeedPrepareMoney.Checked = true;
        }

    }
    #endregion

    #region 控件事件
    protected void OrderReturn(object sender, EventArgs e)
    {
        try
        {
            Save(Constants.ORDER_STATUS_FACTURING_VALUE);
            closeFlag = true;
            //Response.Write("<script>opener.parent.location.href='DailyOrder.aspx';</script>");
            Response.Write("<script>opener.rVal='true';</script>");
            Response.Write("<script>window.close()</script>");
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    protected void OrderSave(object sender, EventArgs e)
    {
        try
        {
            Save(Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE);
            closeFlag = true;
            //Response.Write("<script>opener.parent.location.href='DailyOrder.aspx';</script>");
            Response.Write("<script>opener.rVal='true';</script>");
            Response.Write("<script>window.close()</script>");
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
        newOrderAction.Model.NewOrder.Id = newOrderAction.SelectOrderIdByOrderNo(Request.QueryString["strNo"]);
        newOrderAction.Model.NewOrder.CustomerId = Int64.Parse(Request.Form["txtCustomerId"]);//需要客户ID
        newOrderAction.Model.NewOrder.CustomerName = Request.Form["CustomerName"];// txtCustomerName.Value;
        newOrderAction.Model.NewOrder.CustomerType = int.Parse(cbCustomerType.Items[this.cbCustomerType.SelectedIndex].Value);//int.Parse(Request.Form["sltCustomerType"]); 
        newOrderAction.Model.NewOrder.CustomerTypeName = cbCustomerType.Items[this.cbCustomerType.SelectedIndex].Text;
        newOrderAction.Model.NewOrder.Name = Request.Form["RealName"];
        newOrderAction.Model.NewOrder.LastTelNo = Request.Form["RealTelNo"];
        newOrderAction.Model.NewOrder.ProjectName = Request.Form["ItemName"];
        newOrderAction.Model.NewOrder.No = Request.QueryString["strNo"];
        newOrderAction.Model.NewOrder.PayType = int.Parse(cbPaymentType.Items[this.cbPaymentType.SelectedIndex].Value);// int.Parse(Request.Form["sltPayType"]);
        newOrderAction.Model.NewOrder.BalanceDateTime = Constants.NULL_DATE_TIME;
        newOrderAction.Model.NewOrder.PaidTicket = Constants.FALSE;
        User employee = new User();
        employee.Id = (ThreadLocalUtils.CurrentUserContext.CurrentUser).Id;
        newOrderAction.Model.NewOrder.NewOrderUser = employee;
        newOrderAction.Model.NewOrder.CashUser = employee;
        if (ckNeedPrepareMoney.Checked)
        {
            newOrderAction.Model.NewOrder.PrepareMoney = Constants.TRUE;
            newOrderAction.Model.NewOrder.PrepareMoneyAmount = decimal.Parse(Request.Form["PrepayMoney"]);//decimal.Parse(Request.Form["PrepayMoney"]);
        }
        else
        {
            newOrderAction.Model.NewOrder.PrepareMoney = Constants.FALSE;
            newOrderAction.Model.NewOrder.PrepareMoneyAmount = 0;
        }
        newOrderAction.Model.NewOrder.Status = orderStatus;// Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
        if (ckNeedTicket.Checked)
            newOrderAction.Model.NewOrder.NeedTicket = Constants.TRUE;
        else
            newOrderAction.Model.NewOrder.NeedTicket = Constants.FALSE;
        //newOrderAction.Model.NewOrder.DeliveryType = int.Parse(this.cbDeliveryType.Items[this.cbDeliveryType.SelectedIndex].Value);// int.Parse(Request.Form["DeliveryType"]);
        newOrderAction.Model.NewOrder.DeliveryType = int.Parse(this.cbDeliveryType.Value);
        if (!string.IsNullOrEmpty(Request.Form["txtDeliveryDateTime"]))
        {
            DateTime d;
            if (DateTime.TryParse(Request.Form["txtDeliveryDateTime"], out d))
            {
                newOrderAction.Model.NewOrder.DeliveryDateTime = d;
            }
            else
            {
                newOrderAction.Model.NewOrder.DeliveryDateTime = Constants.NULL_DATE_TIME;
            }
        }
        else
        {
            newOrderAction.Model.NewOrder.DeliveryDateTime = Constants.NULL_DATE_TIME;
        }

        newOrderAction.Model.NewOrder.Memo = Request.Form["Memo"];// this.txtMemo.Values;
        if (!StringUtils.IsEmpty(Request.Form["MemberCardNo"]))
        {
            searchMemberCardAction.Model.Id = long.Parse(Request.Form["MemberCardId"]);
            searchMemberCardAction.SearchMemberCardById();
            newOrderAction.Model.NewOrder.MemberCardId = long.Parse(Request.Form["MemberCardId"]);// this.txtMemberCardNo.Value; //0;//需要会员卡ID
            newOrderAction.Model.NewOrder.MemberCardNo = searchMemberCardAction.Model.MemberCard.MemberCardNo;// Request.Form["MemberCardNo"];
        }
        else
        {
            newOrderAction.Model.NewOrder.MemberCardId = -1;
            newOrderAction.Model.NewOrder.MemberCardNo = null;
            //newOrderAction.Model.NewOrder.MemberCardId =;//表示没有使用会员卡

        }
        string[] strBusinessArr = Request.Form["businessType"].ToString().Split(',');

        newOrderAction.Model.NewOrder.OrderItemList = new List<OrderItem>();

        List<decimal> memberCardRestPaperCount = new List<decimal>();
        List<long> memberCardConcessionId = new List<long>();



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

            string[] strPrintRequest = Request.Form["txtPrintRequest" + (i + 1)].ToString().Split(',');

            ////会员卡消费时　冲减印张数　更新会员累积消费金额
            if (null != Request.Form["MemberCardNo"] && "" != Request.Form["MemberCardNo"])
            {
                string[] strAmount = Request.Form["Amount"].ToString().Split(',');
                string[] strPrice = Request.Form["strPrice"].ToString().Split(',');
                long memberId = long.Parse(Request.Form["MemberCardId"].ToString());
                //查找活动时 去掉了基本门市价格这个参数，
                //long priceId = long.Parse(Request.Form["PriceId"].ToString().Split(',')[i]);
                MemberCardConcession memberCardConcession = new MemberCardConcession();
                memberCardConcession.MemberCardId = memberId;
                //memberCardConcession.Id = priceId;
                newOrderAction.Model.MemberCardConcession = memberCardConcession;
                newOrderAction.SelectMemberCardConcessionByPriceIdAndConcessionId();

                for (int j = 0; j < newOrderAction.Model.MemberCardConcessionList.Count; j++)
                {
                    for (int m = 0; m < memberCardConcessionId.Count; m++)
                    {
                        if (memberCardConcessionId[m] == newOrderAction.Model.MemberCardConcessionList[j].Id)
                        {
                            newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount = memberCardRestPaperCount[m];
                        }
                    }
                }
                memberCardConcessionId.Clear();
                memberCardRestPaperCount.Clear();
                decimal thisAmount = -decimal.Parse(strAmount[i]);
                //冲减价值
                decimal subValue = 0;
                for (int j = 0; j < newOrderAction.Model.MemberCardConcessionList.Count; j++)
                {
                    thisAmount += newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount;
                    if (thisAmount <= 0)
                    {
                        subValue += newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount * newOrderAction.Model.MemberCardConcessionList[j].PriceDifference;
                        newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount = 0;
                    }
                    else if (thisAmount > 0)
                    {
                        subValue += newOrderAction.Model.MemberCardConcessionList[j].PriceDifference * Math.Abs(thisAmount);
                        newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount += thisAmount;
                    }
                    newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount += -thisAmount;
                    newOrderAction.Model.MemberCard.Id = long.Parse(Request.Form["MemberCardId"]);
                    newOrderAction.Model.MemberCard.ConsumeAmount += decimal.Parse(strPrice[i]) * decimal.Parse(strAmount[i]);

                    memberCardRestPaperCount.Add(newOrderAction.Model.MemberCardConcessionList[j].RestPaperCount);
                    memberCardConcessionId.Add(newOrderAction.Model.MemberCardConcessionList[j].Id);
                }
                //如果没有冲减完成，则就是现金消费
                if (thisAmount < 0)
                {
                    orderItemList.CashConsumeCount = Math.Abs(thisAmount);
                    orderItemList.CashUnitPrice = decimal.Parse(strPrice[i]);
                    orderItemList.CashConsumeAmount = Math.Abs(thisAmount) * decimal.Parse(strPrice[i]);
                }
                orderItemList.PaperConsumeCount = decimal.Parse(strAmount[i]) + thisAmount;
                //差价取平均值
                if (0 != subValue && 0 != (decimal.Parse(strAmount[i]) + thisAmount))
                {
                    orderItemList.UnitDifferencePrice = decimal.Parse((subValue / (decimal.Parse(strAmount[i]) + thisAmount)).ToString("#.00"));
                }
                else
                {
                    orderItemList.UnitDifferencePrice = 0;
                }
                orderItemList.ConsumePaperAmount = subValue;
            }
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

            newOrderAction.Model.NewOrder.OrderItemList.Add(orderItemList);

            //订单状态变更履历
            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            orderStatusAlter.OrdersId = Convert.ToInt64(Request.Form["OrdersId"]);
            orderStatusAlter.Memo = "编辑订单";
            orderStatusAlter.Status = orderStatus;// Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
            newOrderAction.Model.OrderStatusAlter = orderStatusAlter;
        }
        //如果有价格,则修改价格
        if (!StringUtils.IsEmpty(Request.Form["strPrice"]))
        {
            string[] strPrice = Request.Form["strPrice"].ToString().Split(',');
            for (int i = 0; i < strPrice.Length; i++)
            {
                if (StringUtils.IsEmpty(strPrice[i]) )//|| 0 == decimal.Parse(strPrice[i]))
                {
                    Response.Write("<script>alert('单价不能为 0 !')</script>");
                    return;
                }
                newOrderAction.Model.NewOrder.OrderItemList[i].UnitPrice = decimal.Parse(strPrice[i]);
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
                newOrderAction.Model.NewOrder.OrderItemList[i].Amount = decimal.Parse(strAmount[i]);
            }
        }
        decimal totalMoney = 0;
        if (!StringUtils.IsEmpty(Request.Form["txtSumMoney"]))
        {
            string[] strSumMoney = Request.Form["txtSumMoney"].ToString().Split(',');
            for (int i = 0; i < strSumMoney.Length; i++)
            {
                if (StringUtils.IsEmpty(strSumMoney[i]) )//|| 0 == decimal.Parse(strSumMoney[i]))
                {
                    Response.Write("<script>alert('总金额不能为 0 !')</script>");
                    return;
                }
                totalMoney += decimal.Parse(strSumMoney[i]);
            }
            newOrderAction.Model.NewOrder.SumAmount = totalMoney;
        }
        newOrderAction.RealFactureOrder();
    }
    #endregion
}

