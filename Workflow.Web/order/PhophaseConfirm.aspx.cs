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
using Workflow.Support.Report;
using iTextSharp.text;
/// <summary>
/// 名    称: PhophaseConfirm
/// 功能概要: 前期确认订单
/// 作    者: 张晓林
/// 创建时间: 2010年1月11日11:29:10
/// 修正履历: 
/// 修正时间: 
///           
/// </summary>
public partial class OrderRealFactureOrder :Workflow.Web.PageBase
{
    #region //类成员
    protected string orderNo;
    protected int maxVersion;
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

    #region //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        model = newOrderAction.Model;
        try
        {
            
            if (!IsPostBack)
            {
                DefaultLoadData();
            }
            DataOperate(); 
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }

    /// <summary>
    /// 默认加载当前用户的所有接单信息
    /// </summary>
    private void DefaultLoadData() 
    {
        divAllReceptionOrders.Visible = true;
        divAllReceptionOrdersList.Visible = false;
        long currentEmployeeId = ThreadLocalUtils.CurrentSession.CurrentUser.EmployeeId;
        newOrderAction.GetEmployeeReceptionOrderInfo(currentEmployeeId);
    }
    private void DataOperate() 
    {
        divContent.Visible = false;
        divReturnContent.Visible = false;
        string strOrderNo = txtOrderNo.Value.Trim();
        string action = Request.Form["Action"];
        switch(action)
        {
            case "Search":
                Search(strOrderNo);
                break;
            case "Save":
                OrderSave();
                DefaultLoadData();
                break;
            case "Return":
                PhophaseConfirmReturn();
                break;
            case "Look":
                LookOrders();
                break;
            case "Detail":
                OrderDetail();
                break;
        }
        maxVersion = newOrderAction.SelectOrderItemMaxVersion(orderNo);
    }
    #endregion

    #region //数据绑定
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

    #region //前期确认
    /// <summary>
    /// 前期确认
    /// </summary>
    private void OrderSave()
    {
        try
        {
            Save(tempOrderNo.Value.Trim());
            //PrintReport(tempOrderNo.Value.Trim());
            divContent.Visible = false;
            txtOrderNo.Value = "";
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }

    private void Save(string strOrderNo)
    {
        //订单基本信息
        newOrderAction.Model.NewOrder.Id = newOrderAction.SelectOrderIdByOrderNo(strOrderNo);
        newOrderAction.Model.NewOrder.CustomerId = Int64.Parse(Request.Form["txtCustomerId"]);//需要客户ID
        newOrderAction.Model.NewOrder.CustomerName = Request.Form["CustomerName"];// txtCustomerName.Value;
        newOrderAction.Model.NewOrder.CustomerType = int.Parse(cbCustomerType.Items[this.cbCustomerType.SelectedIndex].Value);
        newOrderAction.Model.NewOrder.CustomerTypeName = cbCustomerType.Items[this.cbCustomerType.SelectedIndex].Text;
        newOrderAction.Model.NewOrder.Name = Request.Form["RealName"];
        newOrderAction.Model.NewOrder.LastTelNo = Request.Form["RealTelNo"];
        newOrderAction.Model.NewOrder.ProjectName = Request.Form["ItemName"];
        newOrderAction.Model.NewOrder.No = strOrderNo;
        newOrderAction.Model.NewOrder.PayType = int.Parse(cbPaymentType.Items[this.cbPaymentType.SelectedIndex].Value);
        newOrderAction.Model.NewOrder.BalanceDateTime = Constants.NULL_DATE_TIME;
        newOrderAction.Model.NewOrder.PaidTicket = Constants.FALSE;
        User employee = new User();
        employee.Id = (ThreadLocalUtils.CurrentUserContext.CurrentUser).Id;
        newOrderAction.Model.NewOrder.NewOrderUser = employee;
        newOrderAction.Model.NewOrder.CashUser = employee;
        if (ckNeedPrepareMoney.Checked)
        {
            newOrderAction.Model.NewOrder.PrepareMoney = Constants.TRUE;
            newOrderAction.Model.NewOrder.PrepareMoneyAmount = decimal.Parse(Request.Form["PrepayMoney"]);
        }
        else
        {
            newOrderAction.Model.NewOrder.PrepareMoney = Constants.FALSE;
            newOrderAction.Model.NewOrder.PrepareMoneyAmount = 0;
        }
        newOrderAction.Model.NewOrder.Status = Constants.ORDER_STATUS_CONFIRM_VALUE;//ORDER_STATUS_FACTURING_VALUE;//ORDER_STATUS_CONFIRM_VALUE;
        if (ckNeedTicket.Checked) newOrderAction.Model.NewOrder.NeedTicket = Constants.TRUE;
        else newOrderAction.Model.NewOrder.NeedTicket = Constants.FALSE;
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

        newOrderAction.Model.NewOrder.Memo = Request.Form["Memo"];
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
        string [] printOrderItemId=Request.Form["orderItemId"].Split(',');
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
            if (printOrderItemId.Length > i)
            {
                orderItemList.Id = Convert.ToInt32(printOrderItemId[i].Split('-')[0]);
                orderItemList.Version = Convert.ToInt32(printOrderItemId[i].Split('-')[1]);
            }
            else 
            {
                orderItemList.Id = 0;
            }
            string[] strPrintRequest = Request.Form["txtPrintRequest" + (i + 1)].Split(',');
            
            #region//会员卡消费时　冲减印张数　更新会员累积消费金额
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

            newOrderAction.Model.NewOrder.OrderItemList.Add(orderItemList);

            //订单状态变更履历
            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            orderStatusAlter.OrdersId = Convert.ToInt64(Request.Form["OrdersId"]);
            orderStatusAlter.Memo = "前期确认订单";
            orderStatusAlter.Status = Constants.ORDER_STATUS_CONFIRM_VALUE;//ORDER_STATUS_RECEPTING_VALUE;
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
       foreach (OrderItem orderItem in newOrderAction.Model.NewOrder.OrderItemList)
       {
           totalMoney += decimal.Round(orderItem.UnitPrice, 2) * orderItem.Amount;
       }
       newOrderAction.Model.NewOrder.SumAmount = totalMoney;
       newOrderAction.RealFactureOrder();
    
    }

    /// <summary>
    /// 功能概要: 打印报表
    /// 作    者：张晓林
    /// 创建时间: 2010年4月28日13:46:11
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
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//查询订单
    /// <summary>
    /// 功能概要: 查询订单
    /// 作    者: 张晓林
    /// 创建时间: 2010年1月11日11:50:39
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    private void Search(string strOrderNo) 
    {
        try
        {
            long orderId = newOrderAction.GetPhophaseOrderId(strOrderNo);
            if (0 != orderId)
            {
                string action = Request.Form["Action"];
                orderNo =newOrderAction.GetOrderById(orderId).No;
                strOrderNo = orderNo;
                tempOrderNo.Value = orderNo;
                newOrderAction.GetOrderInfo(orderNo);
                int status = model.NewOrder.Status;
                switch(status)
                {
                    case Constants.ORDER_STATUS_RECEPTING_VALUE:
                        divContent.Visible = true;
                        DisplayOrderItem(orderNo);
                        break;
                    case Constants.ORDER_STATUS_CONFIRM_VALUE:
                        //if ("Detail" == action) { divContent.Visible = true; DisplayOrderItem(strOrderNo); }
                        //else divReturnContent.Visible = true;
                        divReturnContent.Visible = true;
                        break;
                    case Constants.ORDER_STATUS_FACTURING_VALUE:
                        divReturnContent.Visible=true;
                        break;
                    default:
                        divContent.Visible = false;
                        divReturnContent.Visible = false;
                        break;
                }
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    private void DisplayOrderItem(string strOrderNo) 
    {
        newOrderAction.InitMasterData();
        newOrderAction.GetOrderItemListByOrderNo(strOrderNo);
        newOrderAction.GetOrderItemPrintRequeireDetail(strOrderNo);
        newOrderAction.GetOrderItemFactorValueByOrderNo(strOrderNo);
        InitData();
    }
    #endregion

    #region//新增
    /// <summary>
    /// 功能概要: 前期确认新增
    /// 作    者: 张晓林
    /// 创建时间: 2010年1月28日14:10:08
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    private void PhophaseConfirmReturn() 
    {
        try 
        {
            newOrderAction.GetOrderInfo(tempOrderNo.Value);
            Order order = new Order();
            order.No = tempOrderNo.Value.Trim();
            order.Status = Constants.ORDER_STATUS_RECEPTING_VALUE;

            OrdersStatusAlter ordersStatusAlter = new OrdersStatusAlter();
            ordersStatusAlter.OrdersId = newOrderAction.SelectOrderIdByOrderNo(order.No);
            ordersStatusAlter.Status = model.NewOrder.Status;
            ordersStatusAlter.Memo = "新增";

            newOrderAction.Model.NewOrder = order;
            newOrderAction.Model.OrderStatusAlter = ordersStatusAlter;
            newOrderAction.ReturnOrder();
            
            divReturnContent.Visible = false;
            Search(order.No);
            divContent.Visible = true;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//查看
    /// <summary>
    /// 查看各个状态订单信息
    /// </summary>
    /// <remarks>
    /// 作者: 张晓林
    /// 日期: 2010年4月6日13:08:39
    /// </remarks>
    private void LookOrders() 
    {
        string strLook=Request.Form["hiOrderNo"];
        divAllReceptionOrders.Visible = false;
        divAllReceptionOrdersList.Visible = true;
        newOrderAction.GetReceptionOrderDetail(strLook);
    }
    #endregion

    #region//详情
    /// <summary>
    /// 查看单个订单明细
    /// </summary>
    /// <remarks>
    /// 作者: 张晓林
    /// 日期: 2010年4月6日13:08:39
    /// </remarks>
    private void OrderDetail() 
    {
        Search(txtOrderNo.Value);
        divContent.Visible = true;
        divAllReceptionOrdersList.Visible = false;
    }
    #endregion
}

