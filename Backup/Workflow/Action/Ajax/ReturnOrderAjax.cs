using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Support.Ajax;
using Workflow.Da.Domain;
using Workflow.Service.OrderManage;

namespace Workflow.Action.Ajax
{
    /// <summary>
    /// ��    ��: ReturnOrderAjax
    /// ���ܸ�Ҫ: ���Ѿ���ɵĶ��� ���ص��ѵǼ�״̬
    /// ��    ��: ������
    /// ����ʱ��: 2009��10��12��9:27:55
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public class ReturnOrderAjax : AjaxProcess
    {
        #region//ClassMember
        private IOrderService orderService;
        public IOrderService OrderService 
        {
            set { orderService = value; }
        }

        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            //1:��ʾ���سɹ�;0��ʾʧ�� 
            long count = 0;
            long orderId = Convert.ToInt32(parameters["orderId"]);
            try 
            {
                //count = orderService.ReurnOrderToNoblankoutrecord(orderId);
            }
            catch(Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                throw ex;
            }
            return count.ToString();
        }
    }
}
