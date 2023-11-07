using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Util;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Support.Ajax;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.OrderManage;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: GetCustomerInfoByNameAjax
    /// 功能概要: 根据客户名称获取客户信息
    /// 作    者: 张晓林
    /// 创建时间: 2009年3月9日18:06:55
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    class GetCustomerInfoByNameAjax : AjaxProcess
    {
        #region //依赖注入
        private IOrderService orderService;
        public IOrderService OrderService 
        {
            set { orderService = value; }
        }

        public NewOrderAction newOrderAction;
        public NewOrderAction NewOrderAction
        {
            set { newOrderAction = value; }
        }
        #endregion
        public string DoProcess(NameValueCollection parameters)
        {
            if (null == parameters["CustomerName"])
            {
                return null;
            }
            else
            {
                newOrderAction.Model.Customer = orderService.GetCustomerInfoByName(parameters["CustomerName"]);
                
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                //jsonDic.Add(typeof(OrderModel), "CustomerList");
                jsonDic.Add(typeof(Workflow.Da.Domain.Customer), "Id,Name,CustomerLevelId,CustomerTypeId,PayType,Memo,LastLinkMan,LastTelNo,NeedTicket");
                return JSONUtils.ToJSONString(newOrderAction.Model, jsonDic);
            }
        }
    }
}
