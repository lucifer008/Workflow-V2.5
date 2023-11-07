using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Service;
using Workflow.Support.Log;
using Workflow.Support.Ajax;
using Workflow.Service.OrderManage;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: AdjustOrderItemPerson
    /// 功能概要: 检验订单状态
    /// 作    者: 张晓林
    /// 创建时间: 2009年5月7日17:06:14
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    class AdjustOrderItemPersonAjax : AjaxProcess
    {
        #region //ClassMember
        private IOrderService orderService;
        /// <summary>
        /// Add:Cry Date:2009-1-6
        /// </summary>
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
                string orderNo = parameters["OrderNo"];
                Order order = orderService.GetOrderInfoByOrderNo(orderNo);
                if (null != order && order.Status != Constants.ORDER_STATUS_SUCCESSED_VALUE)
                {
                    count = 1;
                }
                //过滤输入非订单号情况
                if (null == order) 
                {
                    count = 2;
                }
                if(null!=order && order.SumAmount<0)
                {
                    count = 3;
                }
            }
            catch(Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                count = 0;
            }
            return count.ToString();
        }
    }
}
