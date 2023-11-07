using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Ajax;
using Workflow.Action;
using System.Collections.Specialized;
using Workflow.Da.Domain;
using Workflow.Util;
using Workflow.Action.Model;

namespace Workflow.Action.Ajax
{
    public class GetBusinessTypePriceFactorAjax : AjaxProcess
    {
        #region 参数传递
        protected BusinessTypePriceSetAction businessTypePriceSetAction;
        public BusinessTypePriceSetAction BusinessTypePriceSetAction
        {
            set { businessTypePriceSetAction = value; }
        }

        protected BaseBusinessTypePriceSetAction baseBusinessTypePriceSetAction;
        public BaseBusinessTypePriceSetAction BaseBusinessTypePriceSetAction
        {
            set { baseBusinessTypePriceSetAction = value; }
        }

        protected NewOrderAction newOrderAction;
        public NewOrderAction NewOrderAction
        {
            set { newOrderAction = value; }
        }

        public string DoProcess(NameValueCollection parameters)
        {
            if (parameters["action"] == null)
            { return null; }
            if (parameters["action"] == "Change")
            {
                FactorRelation fr = new FactorRelation();
                fr.BusinessTypeId = long.Parse(parameters["businessTypeId"]);
                //newOrderAction.Model.Factorrelation = fr;
                businessTypePriceSetAction.Model.Factorrelation=fr;
                //newOrderAction.GetActiveRelation();
                businessTypePriceSetAction.GetActiveRelation();
                //IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                //jsonDic.Add(typeof(OrderModel), "PriceFactor,BusinessType,DailyOrder");
                //jsonDic.Add(typeof(PriceFactor), "Id,DisplayText,Text, FactorValueList");
                //jsonDic.Add(typeof(FactorValue), "Id,Text");
                //jsonDic.Add(typeof(Order), "Id,CustomerName,CustomerTypeName,InsertDateTime,DeliveryType,DeliveryDateTime,UserName,Status,Memo");
                //return JSONUtils.ToJSONString(newOrderAction.Model, jsonDic);
                
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(BusinessTypePriceSetModel), "PriceFactor");
                //jsonDic.Add(typeof(OrderModel), "PriceFactor,BusinessType,DailyOrder");
                jsonDic.Add(typeof(PriceFactor), "Id,DisplayText,Text, FactorValueList");
                jsonDic.Add(typeof(FactorValue), "Id,Text");
                //jsonDic.Add(typeof(Order), "Id,CustomerName,CustomerTypeName,InsertDateTime,DeliveryType,DeliveryDateTime,UserName,Status,Memo");
                return JSONUtils.ToJSONString(businessTypePriceSetAction.Model, jsonDic);
                
            }
            else if (parameters["action"] == "Query")
            {
                PrepareModel(parameters);
                baseBusinessTypePriceSetAction.InitCustomQuery(baseBusinessTypePriceSetAction.Model);
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(BaseBusinessTypePriceSetModel), "BaseBusinessTypePriceSetList,PriceFactor,BusinessType");
                jsonDic.Add(typeof(BaseBusinessTypePriceSet), "Id,Factor1,Factor2,Factor3,Factor4,Factor5,Factor6,Factor7,Factor8,Factor9,Factor10,Factor11,Factor12,Factor13,Factor14,Factor15,Factor16,Factor17,Factor18,Factor19,Factor20,Texts,CostPrice,StandardPrice,ActivityPrice,ReservePrice,BusinessType");
                jsonDic.Add(typeof(PriceFactor),"Id,Name");
                jsonDic.Add(typeof(BusinessType), "Id,Name");
                return JSONUtils.ToJSONString(baseBusinessTypePriceSetAction.Model, jsonDic);

                //jsonDic.Add(typeof(OrderModel), "PriceFactor,BusinessType,DailyOrder");
                //jsonDic.Add(typeof(PriceFactor), "Id,DisplayText,Text");
                //jsonDic.Add(typeof(BusinessType), "Id,Name");
                //jsonDic.Add(typeof(Order), "Id,CustomerName,CustomerTypeName,InsertDateTime,DeliveryType,DeliveryDateTime,UserName,Status,Memo");
                //return JSONUtils.ToJSONString(newOrderAction.Model, jsonDic);
            }
            else
            {
                return null;
            }
        }

        private void PrepareModel(NameValueCollection parameters)
        {
            long lngBusinessTypeId = 0;
            string[] strFactorValueId = null;
            int intPriceFactorCounts = 0;

            BaseBusinessTypePriceSetModel model=baseBusinessTypePriceSetAction.Model;
            model.BaseBusinessTypePriceSet=new BaseBusinessTypePriceSet();
            model.BaseBusinessTypePriceSet.BusinessType = new BusinessType();
            //获取BussinessTypeId
            if (parameters["businessTypeId"] != null)
            {
                lngBusinessTypeId = long.Parse(parameters["businessTypeId"]);
            }
            //获取因素值ID
            if (null!=parameters["queryWhere"] && "" != parameters["queryWhere"].Trim())
            {
                strFactorValueId = parameters["queryWhere"].Split(',');
                intPriceFactorCounts = strFactorValueId.Length;
            }
            //给查询条件赋值
            model.BaseBusinessTypePriceSet.BusinessType.Id = lngBusinessTypeId;
            for (int i = 0; i < intPriceFactorCounts; i++)
            {
                model.BaseBusinessTypePriceSet.SetItem(i, long.Parse(strFactorValueId[i]));
            }
        }
        #endregion


    }
}
