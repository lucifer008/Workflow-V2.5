using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Ajax;
using Workflow.Action;
using Workflow.Action.Model;
using Workflow.Da.Domain;
using Workflow.Util;
using System.Collections.Specialized;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 向页面传递工单明细
    /// </summary>
    /// <remarks>
    /// 作    者: 付强
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    class GetOrderItemAjax:AjaxProcess
    {
        protected NewOrderAction newOrderAction;
        public NewOrderAction NewOrderAction
        {
            set { newOrderAction = value; }
        }
        public string DoProcess(NameValueCollection parameters)
        {
            newOrderAction.GetOrderItemByOrderNo(parameters["orderNo"]);
            newOrderAction.GetOrderItemPrintRequeireDetail(parameters["orderNo"]);
            newOrderAction.GetOrderItemFactorValueByOrderNo(parameters["orderNo"]);
            newOrderAction.Model.OrderItemList = newOrderAction.Model.NewOrder.OrderItemList;
            newOrderAction.Model.OrderList = new List<Order>();
            for (int i = 0; i < newOrderAction.Model.OrderItem.Count; i++)
            {
                Order order=new Order();
                order.Id=newOrderAction.Model.OrderItem[i].Id;
                order.SumAmount = newOrderAction.Model.OrderItem[i].UnitPrice;
                order.PrepareMoneyAmount = newOrderAction.Model.OrderItem[i].Amount;
                order.Memo = newOrderAction.Model.OrderItem[i].Memo;
                newOrderAction.Model.OrderList.Add(order);
            }

            IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
            jsonDic.Add(typeof(OrderModel), "OrderList,OrderItemList,OrderItemPrintRequireDetailList");
            jsonDic.Add(typeof(Order), "Id,SumAmount,PrepareMoneyAmount,Memo");
            jsonDic.Add(typeof(OrderItem), "Id,Name,UnitPrice,Amount,PriceFactorId,Values");
            jsonDic.Add(typeof(OrderItemPrintRequireDetail), "Id,OrderItemId,PrintRequireDetailId,Name");
            return JSONUtils.ToJSONString(newOrderAction.Model, jsonDic);
        }
    }
}
