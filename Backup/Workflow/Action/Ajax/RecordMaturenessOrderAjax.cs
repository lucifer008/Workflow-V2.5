using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Support.Ajax;
using Workflow.Service.OrderManage;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: RecordMaturenessOrderAjax
    /// 功能概要: 记录送货时间到期订单
    /// 作    者: 张晓林
    /// 创建时间: 2009年12月3日11:16:38
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class RecordMaturenessOrderAjax : AjaxProcess
    {
        #region//ClassMember
        private IApplicationProperty applicationProperty;
        public IApplicationProperty ApplicationProperty
        {
            set { applicationProperty = value; }
        }
        private IOrderService orderService;
        public IOrderService OrderService
        {
            set { orderService = value; }
        }
        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            long count = 0;
            try
            {
                //插入所有当期订单
                Order order = new Order();
                order.Status =Constants.ORDER_STATUS_SUCCESSED_VALUE;
                order.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
                order.Status2 = Convert.ToInt32(applicationProperty.GetOrderTimeOuntTime());
                IList<Order> orderList=orderService.GetAllNotSucessedOrdersList(order);
                orderService.RecordMaturenessOrders(orderList);
                //实时返回前20个订单状态
               
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            }
            return Convert.ToString(count);
        }
    }
}
