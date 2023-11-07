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
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称: OrderBlankOut
/// 功能概要: 订单作废
/// 作    者: 付强
/// 创建时间: 2007-9-13
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class OrderBlankOut : Workflow.Web.PageBase
{
    #region 类成员
    protected bool closeFlag = false;
    string OrderNo = "";
    //protected OrderModel model;
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        OrderNo = Request.QueryString[0];
    }
    #endregion

    #region 控件事件
    protected void BlankOutOrder(object sender, EventArgs e)
    {
        try
        {
            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            orderStatusAlter.Status = Constants.ORDER_STATUS_FACTURING_VALUE;
            Int64 orderId = newOrderAction.SelectOrderIdByOrderNo(Request.QueryString[0]);
            orderStatusAlter.OrdersId = orderId;
            orderStatusAlter.Memo =Request.Form["Memo"];

            newOrderAction.Model.OrderStatusAlter = orderStatusAlter;
            newOrderAction.BlankOutOrder(OrderNo, Constants.ORDER_STATUS_BLANKOUT_VALUE);
            closeFlag=true;
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw;
        }

    }
    #endregion
}
