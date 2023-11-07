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
    /// ��    ��: AdjustOrderItemPerson
    /// ���ܸ�Ҫ: ���鶩��״̬
    /// ��    ��: ������
    /// ����ʱ��: 2009��5��7��17:06:14
    /// ��������: 
    /// ����ʱ��: 
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
                //��������Ƕ��������
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
