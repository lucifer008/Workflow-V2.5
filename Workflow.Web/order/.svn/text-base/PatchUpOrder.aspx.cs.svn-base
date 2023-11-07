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
using Workflow.Web;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称: OrderPatchUpOrder
/// 功能概要: 拼版
/// 作    者: 付强
/// 创建时间: 2007-10-8
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class OrderPatchUpOrder : PageBase
{
    #region 类成员
    protected Boolean closeFlag = false;
    protected OrderModel model;
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            newOrderAction.GetOrderInfo(Request.QueryString["strNo"]);
            newOrderAction.GetOrderItemByOrderNo(Request.QueryString["strNo"]);
            newOrderAction.GetOrderItemListByOrderNo(Request.QueryString["strNo"]);
            newOrderAction.GetOrderItemPrintRequeireDetail(Request.QueryString["strNo"]);
            newOrderAction.GetOrderItemEmployeeByOrderNo(Request.QueryString["strNo"]);
            newOrderAction.GetOrderItemFactorValueByOrderNo(Request.QueryString["strNo"]);
            newOrderAction.GetRealOrderItemAll(Request.QueryString["strNo"]);
            InitData();

        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
        if (!IsPostBack)
        {
        }
    }
    #endregion

    #region 数据绑定
    protected void InitData()
    {
        newOrderAction.InitMasterData();
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
        model = newOrderAction.Model;
    }
    #endregion

    #region 控件事件
    protected void OrderSave(object sender, EventArgs e)
    {
        try
        {
            string[] strBusinessArr = Request.Form["businessType"].ToString().Split(',');
            string[] strOrderItemIdArr = Request.Form["OrderItemId"].ToString().Split(',');
            //string[] strTrashNumArr = Request.Form[""].ToString().Split(',');

            newOrderAction.Model.RealOrderItem = new List<RealOrderItem>();
            

            //订单明细
            for (int i = 0; i < strBusinessArr.Length; i++)
            {
                RealOrderItem orderItemList = new RealOrderItem();

                orderItemList.OrdersId = Convert.ToInt64(Request.Form["OrdersId"]);
                if (strOrderItemIdArr[i] != "")
                {
                    orderItemList.OrderItemId = Convert.ToInt64(strOrderItemIdArr[i]);
                }
                orderItemList.BusinessTypeId = Convert.ToInt64(strBusinessArr[i]);
                orderItemList.Amount = 0;
                orderItemList.CashConsumeAmount = 0;
                orderItemList.CashConsumeCount = 0;
                orderItemList.CashUnitPrice = 0;
                orderItemList.ConsumePaperAmount = 0;
                orderItemList.ForecastMoneyAmount = 0;
                orderItemList.PaperConsumeCount = 0;
                orderItemList.UnitDifferencePrice = 0;
                orderItemList.UnitPrice = 0;
                orderItemList.TrashPapers = 0;
                
                orderItemList.IsUseSavedPaper = Constants.FALSE;


                string[] strPrintRequest = Request.Form["txtPrintRequest" + (i + 1)].ToString().Split(',');

                orderItemList.PrintRequireDetailList = new List<PrintRequireDetail>();
                orderItemList.RealOrderItemFactorValueList = new List<RealOrderItemFactorValue>();
                orderItemList.RealOrderItemEmployeeList = new List<RealOrderItemEmployee>();
                
                //订单明细的印制要求
                for (int j = 0; j < strPrintRequest.Length; j++)
                {
                    if (strPrintRequest[j] == null || strPrintRequest[j].ToString() == "") continue;
                    PrintRequireDetail prd = new PrintRequireDetail();
                    prd.PrintDemandDetailId = Convert.ToInt64(strPrintRequest[j]);
                    orderItemList.PrintRequireDetailList.Add(prd);
                }
                string[] strFactorArr = Request.Form["txtFactorId" + (i + 1)].ToString().Split(',');
                string[] strFactorValueArr = Request.Form["txtFactorValue" + (i + 1)].ToString().Split(',');
                string[] strPriceFactorArr = Request.Form["priceFactorId" + (i + 1)].ToString().Split(',');
                //订单明细的因素的值
                for (int k = 0; k < strFactorArr.Length; k++)
                {
                    RealOrderItemFactorValue factorValue = new RealOrderItemFactorValue();
                    if (StringUtils.IsEmpty(strFactorArr[k]) || StringUtils.IsEmpty(strFactorValueArr[k]) || StringUtils.IsEmpty(strPriceFactorArr[k])) break;
                    factorValue.PriceFactorId = Int64.Parse(strPriceFactorArr[k]);// Int64.Parse(strBusinessArr[i]);
                    factorValue.Value = strFactorArr[k];// strFactorValueArr[k];
                    orderItemList.RealOrderItemFactorValueList.Add(factorValue);
                }
                //订单明细前后期的参与人员
                for (int k = 0; k < newOrderAction.Model.OrderItemEmployee.Count; k++)
                {
                    RealOrderItemEmployee roie = new RealOrderItemEmployee();

                    roie.EmployeeId = newOrderAction.Model.OrderItemEmployee[i].EmployeeId;
                    orderItemList.RealOrderItemEmployeeList.Add(roie);
                }
                
                newOrderAction.Model.RealOrderItem.Add(orderItemList);

                //订单状态变更履历
                OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
                orderStatusAlter.OrdersId = Convert.ToInt64(Request.Form["OrdersId"]);
                orderStatusAlter.Memo = "拼版";
                orderStatusAlter.Status = Constants.ORDER_STATUS_NODISPATCHED_VALUE;
                newOrderAction.Model.OrderStatusAlter = orderStatusAlter;
            }
            //如果有价格,则修改价格
            if (!StringUtils.IsEmpty(Request.Form["strPrice"]))
            {
                string[] strPrice = Request.Form["strPrice"].ToString().Split(',');
                for (int i = 0; i < strPrice.Length; i++)
                {
                    if (StringUtils.IsEmpty(strPrice[i]) || 0 == decimal.Parse(strPrice[i]))
                    {
                        Response.Write("<script>alert('单价不能为 0 !')</script>");
                        return;
                    }
                    newOrderAction.Model.RealOrderItem[i].UnitPrice = decimal.Parse(strPrice[i]);
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
                    newOrderAction.Model.RealOrderItem[i].Amount = decimal.Parse(strAmount[i]);
                }
            }
            decimal totalMoney = 0;
            if (!StringUtils.IsEmpty(Request.Form["txtSumMoney"]))
            {
                string[] strSumMoney = Request.Form["txtSumMoney"].ToString().Split(',');
                for (int i = 0; i < strSumMoney.Length; i++)
                {
                    if (StringUtils.IsEmpty(strSumMoney[i]) || 0 == decimal.Parse(strSumMoney[i]))
                    {
                        Response.Write("<script>alert('总金额不能为 0 !')</script>");
                        return;
                    }
                    totalMoney += decimal.Parse(strSumMoney[i]);
                }
                newOrderAction.Model.NewOrder.SumAmount = totalMoney;
            }
            newOrderAction.PatchUpOrder(Request.QueryString["strNo"]);
            closeFlag = true;
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

}
