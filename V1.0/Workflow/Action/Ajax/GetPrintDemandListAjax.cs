using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Ajax;
using System.Collections.Specialized;
using Workflow.Action;
using Workflow.Action.Model;
using Workflow.Da.Domain;
using Workflow.Util;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: GetPrintDemandListAjax
    /// 功能概要: 向页面传递制作要求数据
    /// 作    者: 付强
    /// 创建时间: 2007-9-19
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    class GetPrintDemandListAjax:AjaxProcess
    {
        protected NewOrderAction newOrderAction;
        public NewOrderAction NewOrderAction
        {
            set { newOrderAction = value; }
        }
        public string DoProcess(NameValueCollection parameters)
        {
            newOrderAction.InitMasterData();
            IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
            jsonDic.Add(typeof(OrderModel), "PrintDemandList");
            jsonDic.Add(typeof(PrintDemand), "Id,Name,PrintDemandDetailList");
            jsonDic.Add(typeof(PrintDemandDetail), "Id,Name,PrintRequireDetailList");
            jsonDic.Add(typeof(PrintRequireDetail), "Id,Name");
            return JSONUtils.ToJSONString(newOrderAction.Model, jsonDic);
        }

    }
}
