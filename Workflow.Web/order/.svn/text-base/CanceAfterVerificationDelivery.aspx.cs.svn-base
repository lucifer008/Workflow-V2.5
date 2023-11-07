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
/// 名    称: OrderCanceAfterVerificationDelivery
/// 功能概要: 作废订单
/// 作    者: 付强
/// 创建时间: 2007-10-6
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class OrderCanceAfterVerificationDelivery : PageBase
{
    #region 类成员
    protected bool closeFlag = false;
    string OrderNo = "";
    //private OrderModel model;
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
        //Response.Write("<script> var strNo='" + Request.QueryString[0] + "'; var strName='" + Request.QueryString[1] + "';</script>");
    }
    #endregion
    
    #region 控件事件
    protected void CancelAfterVerificationn(object sender, EventArgs e)
    {
        try
        {
            bool stFlag = false;
            if ("on" == Request.Form["CancelAfterVerificationStatus"])
            {
                stFlag = true;
                newOrderAction.GetOrderByOrderNo(Request.QueryString[0]);
                OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
                orderStatusAlter.OrdersId = newOrderAction.Model.NewOrder.Id;
                orderStatusAlter.Status = Constants.ORDER_STATUS_DELIVERYED_VALUE;
                if (null != Request.Form["Remark"])
                {
                    orderStatusAlter.Memo = Request.Form["Remark"];
                }
                else
                {
                    orderStatusAlter.Memo = "核销送货";
                }
                newOrderAction.Model.OrderStatusAlter = orderStatusAlter;
                newOrderAction.GetDeliveryOrderByOrderNo(Request.QueryString[0]);
                newOrderAction.CancelAfterVerification(Request.QueryString[0], Constants.ORDER_STATUS_NOPATCHUP_VALUE, stFlag);
            }
            else
            {
                newOrderAction.CancelAfterVerification(Request.QueryString[0], Constants.ORDER_STATUS_FINISHED_VALUE, stFlag);
            }
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
