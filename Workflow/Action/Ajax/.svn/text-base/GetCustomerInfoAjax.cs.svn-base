using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Util;
using System.Collections.Specialized;
using Workflow.Support.Ajax;
using Workflow.Action;
using Workflow.Action.Model;
using Workflow.Da.Domain;
namespace Workflow.Action.Ajax
{
    class GetCustomerInfoAjax : AjaxProcess
    {
        protected NewOrderAction newOrderAction;
        public NewOrderAction NewOrderAction
        {
            set { newOrderAction = value; }
        }
        public string DoProcess(NameValueCollection parameters)
        {
            if (!StringUtils.IsEmpty(parameters["memberCardNo"]))
            {
                newOrderAction.SelectCustomerInfoByMemberCardNo(parameters["memberCardNo"]);
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(OrderModel), "MemberCard");
                jsonDic.Add(typeof(MemberCard), "Id,MemberCardNo,CustomerId,TradeId,CustomerTypeId,CustomerName,LinkManName,TelNo,CustomerMemo,NeedTicket,PayType");
                return JSONUtils.ToJSONString(newOrderAction.Model, jsonDic);
            }
            else
            {
                return JSONUtils.ToJSONString(null,null);
            }

        }
    }
}
