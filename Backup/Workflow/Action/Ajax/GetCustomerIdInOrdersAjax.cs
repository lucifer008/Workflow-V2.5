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
    /// 名    称: Workflow.Support.Ajax.GetMemberCardNo
    /// 功能概要: 判定该客户是否已经在订单中存在
    /// 作    者: liuwei
    /// 创建时间: 2007-10-11
    /// 修正履历: 张晓林
    /// 修正时间: 2009年4月21日9:46:16
    /// 修正描述:整理代码
    /// </summary>
    class GetCustomerIdInOrdersAjax:AjaxProcess
    {
        #region //注入Service
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
