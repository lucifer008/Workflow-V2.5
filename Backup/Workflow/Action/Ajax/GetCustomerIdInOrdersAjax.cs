using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Util;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Support.Ajax;
using Workflow.Service.OrderManage;

namespace Workflow.Action.Ajax
{
    /// <summary>
    /// ��    ��: Workflow.Support.Ajax.GetMemberCardNo
    /// ���ܸ�Ҫ: �ж��ÿͻ��Ƿ��Ѿ��ڶ����д���
    /// ��    ��: liuwei
    /// ����ʱ��: 2007-10-11
    /// ��������: ������
    /// ����ʱ��: 2009��4��21��9:46:16
    /// ��������:�������
    /// </summary>
    class GetCustomerIdInOrdersAjax:AjaxProcess
    {
        #region //ע��Service
        private IOrderService orderService;
        public IOrderService OrderService
        {
            get { return orderService; }
            set { orderService = value; }
        }
        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            if (parameters[1] == null)
            {
                return null;
            }
            long CustomerId =NumericUtils.ToLong(parameters[1]);
            return orderService.SearchCustomerInOrder(CustomerId).ToString();
        }
    }
}
