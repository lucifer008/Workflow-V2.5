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
    /// 名    称: ReturnOrderAjax
    /// 功能概要: 将已经完成的订单 返回到已登记状态
    /// 作    者: 张晓林
    /// 创建时间: 2009年10月12日9:27:55
    /// 修正履历: 
    /// 修正时间: 
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
            //1:表示返回成功;0表示失败 
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
