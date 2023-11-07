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
    /// 名    称: GetOrderStatusByIdAjax
    /// 功能概要: 根据工单Id 获取工单状态
    /// 作    者: 张晓林
    /// 创建时间: 2010年6月8日15:52:50
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class GetOrderStatusByIdAjax : AjaxProcess
    {
        #region 依赖注入Service
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
