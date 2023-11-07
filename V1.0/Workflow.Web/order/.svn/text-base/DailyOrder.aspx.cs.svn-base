using System;
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
using Workflow.Util;
using Workflow.Enums;
using Workflow.Action;
using Workflow.Service;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Da.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Report;
using iTextSharp.text;
/// <summary>
/// 名    称: DailyOrder
/// 功能概要: 开单
/// 作    者: 付强
/// 创建时间: 2007-9-13
/// 修正履历: 张晓林
///             防止用户连续点击 “保存打印”按钮
/// 修正时间: 2009年10月21日13:56:48
/// </summary>

public partial class OrderDailyOrder :Workflow.Web.PageBase
{
    #region 类成员
    //private string strPrintMemo = "";
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

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
        }
        if (null != Request.Form["action"] && "" != Request.Form["action"]) { btnDispatchAndPrint1_ServerClick(sender, e); }//防止连续点击开单按钮 
    }
    #endregion

    #region 数据绑定
    private void InitData()
    {
        try
        {
            newOrderAction.InitMasterData();
            model = newOrderAction.Model;

        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

        //客户类型
        this.cbCustomerType.DataSource = newOrderAction.Model.CustomerTypes;
        this.cbCustomerType.DataTextField = "NAME";
        this.cbCustomerType.DataValueField = "Id";
        this.cbCustomerType.DataBind();

        //支付方式
        this.cbPaymentType.DataSource = newOrderAction.Model.PaymentTypes;
        this.cbPaymentType.DataTextField = "label";
        this.cbPaymentType.DataValueField = "value";
        this.cbPaymentType.DataBind();
        

        //送货方式
        this.cbDeliveryType.DataSource = newOrderAction.Model.DevileryTypes;
        this.cbDeliveryType.DataTextField = "label";
        this.cbDeliveryType.DataValueField = "value";
        this.cbDeliveryType.DataBind();
    }
    #endregion

    #region 自定义方法
    protected void OrderSave()
    {
        try
        {
            bool scatteredClientBool = false;
            if (string.IsNullOrEmpty(Request.Form["txtCustomerId"]))
            {
                scatteredClientBool = true;
            }
            //工单基本信息
            long brachShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            newOrderAction.Model.NewOrder.CustomerId = scatteredClientBool ? Constants.scatteredClientId(brachShopId) : Int64.Parse(Request.Form["txtCustomerId"]);//需要客户ID
            newOrderAction.Model.NewOrder.CustomerName = Request.Form["CustomerName"];// txtCustomerName.Value;
            newOrderAction.Model.NewOrder.CustomerType = int.Parse(cbCustomerType.Items[this.cbCustomerType.SelectedIndex].Value);//int.Parse(Request.Form["sltCustomerType"]); 
            if (newOrderAction.Model.NewOrder.CustomerType == -1)
            {
                newOrderAction.Model.NewOrder.CustomerType = Convert.ToInt32(Constants.scatteredCustomerTypeId(brachShopId));//1;
            }
            newOrderAction.Model.NewOrder.CustomerTypeName = cbCustomerType.Items[this.cbCustomerType.SelectedIndex].Text;
            newOrderAction.Model.NewOrder.Name = Request.Form["RealName"];// txtName.Value;
            newOrderAction.Model.NewOrder.ProjectName = Request.Form["ItemName"];
            newOrderAction.Model.NewOrder.No = "11";//临时工单编号 Service层会修改之
            newOrderAction.Model.NewOrder.LastTelNo = Request.Form["RealTelNo"];//  .telNo.Value;
            newOrderAction.Model.NewOrder.PayType = int.Parse(cbPaymentType.Items[this.cbPaymentType.SelectedIndex].Value);// int.Parse(Request.Form["sltPayType"]);
            newOrderAction.Model.NewOrder.BalanceDateTime = Constants.NULL_DATE_TIME;
            newOrderAction.Model.NewOrder.NewOrderUser = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            newOrderAction.Model.NewOrder.CashUser = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            if (ckNeedPrepareMoney.Checked)
            {
                newOrderAction.Model.NewOrder.PrepareMoney = Constants.TRUE;
                newOrderAction.Model.NewOrder.PrepareMoneyAmount = decimal.Parse(this.txtPrepayMoney.Value);//decimal.Parse(Request.Form["PrepayMoney"]);
                newOrderAction.Model.NewOrder.Status = Constants.ORDER_STATUS_NOPREPAY_VALUE;
            }
            else
            {
                newOrderAction.Model.NewOrder.PrepareMoney = Constants.FALSE;
                newOrderAction.Model.NewOrder.PrepareMoneyAmount = 0;
                newOrderAction.Model.NewOrder.Status = Constants.ORDER_STATUS_NODISPATCHED_VALUE;
            }
            //if (ckNeedTicket.Checked)
            //    newOrderAction.Model.NewOrder.NeedTicket = Constants.TRUE;
            //else
            //    newOrderAction.Model.NewOrder.NeedTicket = Constants.FALSE;
            newOrderAction.Model.NewOrder.NeedTicket = Constants.FALSE;
            newOrderAction.Model.NewOrder.DeliveryType = int.Parse(this.cbDeliveryType.Items[this.cbDeliveryType.SelectedIndex].Value);// int.Parse(Request.Form["DeliveryType"]);
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
            newOrderAction.Model.NewOrder.PaidTicket = Constants.FALSE;
            newOrderAction.Model.NewOrder.Memo = Request.Form["Memo"];// this.txtMemo.Values;
            if (null != Request.Form["MemberCardNo"] && "" != Request.Form["MemberCardNo"])
            {
                newOrderAction.Model.NewOrder.MemberCardId = Int64.Parse(Request.Form["MemberCardId"]);// this.txtMemberCardNo.Value; //0;//需要会员卡ID
                newOrderAction.Model.NewOrder.MemberCardNo = Request.Form["MemberCardNo"];
            }
            else
            {
                newOrderAction.Model.NewOrder.MemberCardId = -1;
                newOrderAction.Model.NewOrder.MemberCardNo = null;
                //newOrderAction.Model.NewOrder.MemberCardId =;//表示没有使用会员卡

            }
            LinkMan man = new LinkMan();
            man.Name = Request.Form["RealName"];
            //man.Name = txtName.Value;
            man.MobileNo = Request.Form["RealTelNo"];
            //man.MobileNo = telNo.Value;
            man.Age = 0;
            man.Sex = Constants.SEX_MALE_VALUE.ToString();
            man.Position = "";
            man.Hobby = "";
            man.Qq = "";
            man.CompanyTelNo = "";
            man.Email = "";
            man.Address = "";
            man.Memo = "";
            man.CustomerId = scatteredClientBool ? Constants.scatteredClientId(brachShopId) : Int64.Parse(Request.Form["txtCustomerId"]);
            newOrderAction.Model.LinkMan = man;
            Customer customer = new Customer();
            customer.LastLinkMan = Request.Form["RealName"];
            customer.LastTelNo = Request.Form["RealTelNo"];
            customer.LinkManCount = 1;
            customer.Id = scatteredClientBool ? Constants.scatteredClientId(brachShopId) : Int64.Parse(Request.Form["txtCustomerId"]);
            newOrderAction.Model.Customer = customer;
            string [] strBusinessArr = Request.Form["businessType"].ToString().Split(',');

            newOrderAction.Model.NewOrder.OrderItemList = new List<OrderItem>();

            //工单状态变更履历
            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            orderStatusAlter.Memo = "新增工单";
            if (ckNeedPrepareMoney.Checked)
            {
                orderStatusAlter.Status = Constants.ORDER_STATUS_NOPREPAY_VALUE;
            }
            else
            {
                orderStatusAlter.Status = Constants.ORDER_STATUS_NODISPATCHED_VALUE;
            }

            newOrderAction.Model.OrderStatusAlter = orderStatusAlter;

            //工单明细
            for (int i = 0; i < strBusinessArr.Length; i++)
            {
                if (strBusinessArr[i] == "-1")
                    continue;
                string[] strPrintMemo = Request.Form["printDemandMemo"].Split(',');

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
                orderItemList.Memo = strPrintMemo[i];

                string[] strPrintRequest = Request.Form["txtPrintRequest"+(i+1)].ToString().Split(',');

                orderItemList.PrintRequireDetailList = new List<PrintRequireDetail>();
                orderItemList.OrderItemFactorValueList = new List<OrderItemFactorValue>();

                //工单明细的印制要求
                for(int j=0;j<strPrintRequest.Length ;j++)
                {
                    if (StringUtils.IsEmpty(strPrintRequest[j])) continue;
                    PrintRequireDetail prd = new PrintRequireDetail();
                    prd.PrintDemandDetailId = Convert.ToInt64(strPrintRequest[j]);
                    orderItemList.PrintRequireDetailList.Add(prd);

                }
                string[] strFactorArr = Request.Form["txtFactorId" + (i + 1)].ToString().Split(',');
                string[] strFactorValueArr = Request.Form["txtFactorValue" + (i + 1)].ToString().Split(',');
                string[] strPriceFactorArr = Request.Form["priceFactorId" + (i + 1)].ToString().Split(',');
                //工单明细的因素的值
                for (int k = 0; k <strFactorArr.Length; k++)
                {
                    OrderItemFactorValue factorValue = new OrderItemFactorValue();
                    if (StringUtils.IsEmpty(strFactorArr[k]) || StringUtils.IsEmpty(strFactorValueArr[k]) || StringUtils.IsEmpty(strPriceFactorArr[k])) break;
                    factorValue.PriceFactorId = Int64.Parse(strPriceFactorArr[k]);// Int64.Parse(strBusinessArr[i]);
                    factorValue.Value = strFactorArr[k];// strFactorValueArr[k];
                    orderItemList.OrderItemFactorValueList.Add(factorValue);
                }

                newOrderAction.Model.NewOrder.OrderItemList.Add(orderItemList);

            }
            //如果有价格,则修改价格
            if (!StringUtils.IsEmpty(Request.Form["strPrice"]))
            {
                string[] strPrice = Request.Form["strPrice"].ToString().Split(',');
                for(int i=0;i<strPrice.Length;i++)
                {
                    if (strBusinessArr[i] != "-1")
                    {
                        if (!string.IsNullOrEmpty(strPrice[i]))
                        {
                            newOrderAction.Model.NewOrder.OrderItemList[i].UnitPrice = decimal.Parse(strPrice[i]);
                        }
                        else
                        {
                            newOrderAction.Model.NewOrder.OrderItemList[i].UnitPrice = 0;
                        }
                    }
                }
            }
            if (!StringUtils.IsEmpty(Request.Form["Amount"]))
            {
                string[] strAmount = Request.Form["Amount"].ToString().Split(',');
                for (int i = 0; i < strAmount.Length; i++)
                {
                    if (strBusinessArr[i] != "-1")
                    {
                        if (!string.IsNullOrEmpty(strAmount[i]))
                        {
                            newOrderAction.Model.NewOrder.OrderItemList[i].Amount = decimal.Parse(strAmount[i]);
                        }
                        else
                        {
                            newOrderAction.Model.NewOrder.OrderItemList[i].Amount = 0;
                        }
                    }
                }
            }
            decimal totalMoney = 0;
            if (!StringUtils.IsEmpty(Request.Form["txtSumMoney"]))
            {
                string[] strSumMoney = Request.Form["txtSumMoney"].ToString().Split(',');
                for (int i = 0; i < strSumMoney.Length; i++)
                {
                    if (strBusinessArr[i] != "-1")
                    {
                        if (!string.IsNullOrEmpty(strSumMoney[i]))
                        {
                            totalMoney += decimal.Parse(strSumMoney[i]);
                        }
                        else
                        {
                            totalMoney += 0;
                        }
                    }
                }
                newOrderAction.Model.NewOrder.SumAmount = totalMoney;
            }

            //如果没有工单明细 则加一条空明细
            if (newOrderAction.Model.NewOrder.OrderItemList.Count <= 0)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.BusinessTypeId = Constants.BUSINESS_TYPE_ID(brachShopId);//处理分店带来的Id不同问题--张晓林 2009年8月15日14:28:19
                orderItem.Amount = 0;
                orderItem.BusinessTypeName = "";
                orderItem.CashConsumeAmount = 0;
                orderItem.CashConsumeCount = 0;
                orderItem.CashUnitPrice = 0;
                orderItem.ConsumePaperAmount = 0;
                orderItem.ForecastMoneyAmount = 0;
                orderItem.PaperConsumeCount = 0;
                orderItem.UnitDifferencePrice = 0;
                orderItem.UnitPrice = 0;
                orderItem.Values = "";
                orderItem.IsUseSavedPaper = Constants.FALSE;
                orderItem.Memo = "";
                newOrderAction.Model.NewOrder.OrderItemList.Add(orderItem);

            }
            
            newOrderAction.AddOrder();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region 控件事件
    protected void btnDispatchAndPrint1_ServerClick(object sender, EventArgs e)
    {
       
        this.OrderSave();
        string orderNo = newOrderAction.Model.NewOrder.No;

        try
        {
            //工单详细信息
            newOrderAction.GetOrderInfo(orderNo);
            newOrderAction.GetOrderItemByOrderNo(orderNo);
            newOrderAction.GetOrderItemListByOrderNo(orderNo);
            newOrderAction.GetOrderItemPrintRequeireDetail(orderNo);
            newOrderAction.GetOrderItemFactorValueByOrderNo(orderNo);
            newOrderAction.GetFactorValue(true);
            newOrderAction.InitMasterData();
            newOrderAction.GetAllUser();
            newOrderAction.Model.CustomerName = Request.Form["CustomerName"];

            //工单员工信息
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
            string reportName = "Order" + DateTime.Now.Ticks.ToString() + ".pdf";
            ro.FileName = Server.MapPath("~") + @"\reports\" + reportName;
            ro.CreateReport(newOrderAction.Model, "", "", PageSize.A4, 0, 0, 30, 30);//"业务委托工单", "业务委托工单", PageSize.A4, 0, 0, 30, 30);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script>showPage('../reports/" + reportName + "', '_blank', 1024, 1024 , false, false, null);window.location.href='DailyOrder.aspx';</script>");
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    protected void btnDispatchAndPrint2_ServerClick(object sender, EventArgs e)
    {
        btnDispatchAndPrint1_ServerClick(sender, e);
    }

    #endregion

}


