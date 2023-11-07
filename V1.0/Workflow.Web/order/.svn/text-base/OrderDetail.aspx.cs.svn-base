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
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
/// <summary>
/// 名    称: OrderDetail
/// 功能概要: 工单详情
/// 作    者: 付强
/// 创建时间: 2007-9-13
/// 修正履历: 付强
/// 修正时间: 2009-1-10
///             补齐客户资料
/// </summary>
public partial class OrderDetail : Workflow.Web.PageBase
{
    #region 类成员
    protected Boolean closeFlag = false;
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
        model = newOrderAction.Model;
        Response.Expires = -1;
        InitData();
    }
    #endregion

    #region 获取工单详细信息
    /// <summary>
    /// 获取工单详细信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 刘伟
    /// 创建时间: 2007-10-9
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void InitData()
    {
        string  OrderNo =Request.QueryString["OrderNo"];
        try
        {
            //工单详细信息
            newOrderAction.GetOrderInfo(OrderNo);
            newOrderAction.GetOrderItemByOrderNo(OrderNo);
            newOrderAction.GetOrderItemListByOrderNo(OrderNo);
            newOrderAction.GetOrderItemPrintRequeireDetail(OrderNo);
            newOrderAction.GetOrderItemFactorValueByOrderNo(OrderNo);
            newOrderAction.GetFactorValue(true);
            newOrderAction.GetAllUser();
            newOrderAction.InitMasterData();
            
            //工单员工信息
            Workflow.Da.Domain.OrderItemEmployee orderItemEmployee = new Workflow.Da.Domain.OrderItemEmployee();
            orderItemEmployee.No = OrderNo;
            orderItemEmployee.PositionId1 = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.PositionId2 = Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.PositionId = Constants.POSITION_RECEPTION_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            newOrderAction.Model.OrderItemEmployee.Add(orderItemEmployee);
            newOrderAction.SelectOldEmployee();
            //送货人
            sAction.SearchDelivery(OrderNo);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }
    #endregion
}
