using System;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Workflow.Web;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称: NewReDoOrderForOrderItem
/// 功能概要: 订单返回:从已修正返回到接待中
/// 作    者: 张晓林
/// 创建时间: 2010年1月26日
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class order_ReDoOrderForOrderItem : PageBase
{
    #region 类成员
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
            string orderNo = Request.QueryString["strNo"];
            model = newOrderAction.Model;
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region 控件事件
    protected void SaveReDo(object sender, EventArgs e)
    {
        try
        {
            btnOk.Enabled = false;
            Order order = new Order();
            order.No = Request.QueryString["strNo"];
            order.Status = Constants.ORDER_STATUS_RECEPTING_VALUE;

            OrdersStatusAlter ordersStatusAlter = new OrdersStatusAlter();
            ordersStatusAlter.OrdersId = newOrderAction.SelectOrderIdByOrderNo(order.No);
            ordersStatusAlter.Status = Constants.ORDER_STATUS_CONFIRM_VALUE;
            ordersStatusAlter.Memo = Request.Form["Memo"];

            newOrderAction.Model.NewOrder = order;
            newOrderAction.Model.OrderStatusAlter = ordersStatusAlter;
            newOrderAction.ReturnOrder();
            Response.Write("<script>opener.rVal='true';</script>");
            Response.Write("<script>window.close()</script>");
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }
    #endregion
}
