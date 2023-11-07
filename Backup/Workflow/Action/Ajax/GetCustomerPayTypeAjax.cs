using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Ajax;
using Workflow.Util;
using Workflow.Action.Model;
using Workflow.Da.Domain;

namespace Workflow.Action.Ajax
{
    class GetCustomerPayTypeAjax:AjaxProcess
    {
        protected NewOrderAction newOrderAction;
        public NewOrderAction NewOrderAction
        {
            set { newOrderAction = value; }
        }

        public string DoProcess(System.Collections.Specialized.NameValueCollection parameters)
        {
            if (!StringUtils.IsEmpty(parameters["CustomerId"]))
            {
                newOrderAction.GetCustomerInfoById(int.Parse(parameters["CustomerId"]));
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(OrderModel), "Customer");
                jsonDic.Add(typeof(Customer), "Id,Name,PayType");
                return JSONUtils.ToJSONString(newOrderAction.Model, jsonDic);
            }
            else
            {
                return "";
            }
        }
    }
}
