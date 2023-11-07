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
using Workflow.Web;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;

/// <summary>
/// 名    称: Delivery
/// 功能概要: 送货
/// 作    者: 付强
/// 创建时间: 2007-9-13
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class OrderDelivery : PageBase
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
           newOrderAction.GetOrderItemFactorValueByOrderNo(Request.QueryString["strNo"]);
           newOrderAction.GetFactorValue(true);
           newOrderAction.InitMasterData();
           model = newOrderAction.Model;
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

    #region 控件事件
    protected void SaveDelivery(object sender, EventArgs e)
    {
        try
        {
            string strPrint = Request.Form["sltDeliveryEmployee"];
            //string []empArr
            DeliveryOrder deliveryOrder = new DeliveryOrder();
            deliveryOrder.OrdersId = newOrderAction.SelectOrderIdByOrderNo(Request.QueryString["strNo"]);
            deliveryOrder.Memo = Request.Form["DeliveryMemo"];
            deliveryOrder.BeginDateTime = DateTime.Now;
            deliveryOrder.EndDateTime = Constants.NULL_DATE_TIME;
            Employee employee = new Employee();
            employee.Id = Int64.Parse(strPrint);
            deliveryOrder.Employee = employee;
            deliveryOrder.Finished = Constants.DELIVERY_STATUS_UNFINISHED_VALUE;
            newOrderAction.Model.DeliveryOrderList.Add(deliveryOrder);
            newOrderAction.DeliveryOrder(Request.QueryString["strNo"],Constants.ORDER_STATUS_DELIVERYING_VALUE);
            //打印送货单
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
