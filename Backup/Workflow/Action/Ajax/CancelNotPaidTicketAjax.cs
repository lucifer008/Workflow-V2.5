using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Support.Ajax;
using Workflow.Service.OrderManage;

namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: CancelNotPaidTicketAjax
    /// 功能概要: 取消欠发票
    /// 作    者: 张晓林
    /// 创建时间: 2009年10月24日15:19:10
    /// 修正履历: 张晓林 作废
    /// 修正时间: 2009年12月2日11:40:40
    /// </summary>
    public class CancelNotPaidTicketAjax : AjaxProcess
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
            long count = 0;
            try
            {
                if (null == parameters["OrderId"]) return null;
                if ("" != parameters["OrderId"])
                {
                    count = 1;
                    //orderService.CancelNotPaidTicket(Convert.ToInt32(parameters["OrderId"]));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            }
            return Convert.ToString(count);
        }
    }
}
