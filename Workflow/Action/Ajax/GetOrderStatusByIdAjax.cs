using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Support;
using Workflow.Service;
using Workflow.Support.Log;
using Workflow.Support.Ajax;

namespace Workflow.Action.Ajax
{
    /// <summary>
    /// ��    ��: GetOrderStatusByIdAjax
    /// ���ܸ�Ҫ: ���ݹ���Id ��ȡ����״̬
    /// ��    ��: ������
    /// ����ʱ��: 2010��6��8��15:52:50
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public class GetOrderStatusByIdAjax : AjaxProcess
    {
        #region ����ע��Service
        private IFinanceService financeService;
        public IFinanceService FinanceService 
        {
            set { financeService = value; }
        }
        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
             try
             {
                 long orderId = Convert.ToInt32(parameters["OrderId"]) ;
                 int status = financeService.GetOrderStatusByOrderId(orderId);
                 return Convert.ToString(status);
             }
             catch (Exception ex)
             {
                 LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                 throw ex;
             }
        }
    }
}
