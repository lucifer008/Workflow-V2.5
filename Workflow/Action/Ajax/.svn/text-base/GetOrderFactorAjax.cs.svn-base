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
    /// 向页面传递动态因素
    /// </summary>
    /// <remarks>
    /// 作    者: 付强
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
 
    class GetOrderFactorAjax:AjaxProcess
    {
        protected NewOrderAction newOrderAction;
        public NewOrderAction NewOrderAction
        {
            set { newOrderAction = value; }
        }

        public string DoProcess(NameValueCollection parameters)
        {
            if (!StringUtils.IsEmpty(parameters["businessTypeId"]))
            {
                FactorRelation fr = new FactorRelation();
                fr.BusinessTypeId = Int64.Parse(parameters["businessTypeId"]);
                if (null != parameters["PriceFactorId"] && null!=parameters["SourceValue"])
                {
                    fr.PriceFactorId = Int64.Parse(parameters["PriceFactorId"]);
                    fr.SourceValue = Int64.Parse(parameters["SourceValue"]);
                }
                
                newOrderAction.Model.Factorrelation = fr;
                newOrderAction.GetActiveRelation();
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(OrderModel), "PriceFactor,BusinessType,DailyOrder");
                //jsonDic.Add(typeof(OrderModel), "PriceFactor,BusinessType");
                jsonDic.Add(typeof(PriceFactor), "Id,DisplayText,Text, FactorValueList");
                jsonDic.Add(typeof(FactorValue), "Id,Text");
                jsonDic.Add(typeof(Order), "Id,CustomerName,CustomerTypeName,InsertDateTime,DeliveryType,DeliveryDateTime,UserName,Status,Memo");
                return JSONUtils.ToJSONString(newOrderAction.Model, jsonDic);
            }
            else
            {

                newOrderAction.InitMasterData();
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(OrderModel), "PriceFactor,BusinessType,DailyOrder");
                //jsonDic.Add(typeof(OrderModel), "PriceFactor,BusinessType");
                jsonDic.Add(typeof(PriceFactor), "Id,DisplayText,Text");
                jsonDic.Add(typeof(BusinessType), "Id,Name");
                jsonDic.Add(typeof(Order), "Id,CustomerName,CustomerTypeName,InsertDateTime,DeliveryType,DeliveryDateTime,UserName,Status,Memo");
                return JSONUtils.ToJSONString(newOrderAction.Model, jsonDic);
            }

        }
        
        


    }
}
