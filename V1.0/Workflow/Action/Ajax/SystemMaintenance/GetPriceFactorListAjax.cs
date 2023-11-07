using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Support.Ajax;
using Workflow.Service.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;
namespace Workflow.Action.Ajax.SystemMaintenance
{
    /// <summary>
    /// 名    称: GetPriceFactorListAjax
    /// 功能概要: 根据选择依赖关系加载 依赖关系列表
    /// 作    者: 张晓林
    /// 创建时间: 2009年7月15日9:28:27
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    class GetPriceFactorListAjax : AjaxProcess
    {
        #region 依赖注入Service
        private SearchPriceBaseDataAction searchPriceBaseDataAction;
        public SearchPriceBaseDataAction SearchPriceBaseDataAction 
        {
            set { searchPriceBaseDataAction = value; }
        }

        private ISearchPriceBaseService searchPriceBaseService;
        public ISearchPriceBaseService SearchPriceBaseService
        {
            set { searchPriceBaseService = value; }
        }
        
        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            try
            {
                long factorRelationId = Convert.ToInt32(parameters["FactorRelationId"]);
                FactorRelation factorRelation = searchPriceBaseService.GetFactorRelationById(factorRelationId);
                PriceFactor priceFactor1 = searchPriceBaseService.GetPriceFactorById(factorRelation.PriceFactorId);//依赖因素
                PriceFactor priceFactor2 = searchPriceBaseService.GetPriceFactorById(factorRelation.PriceFactor.Id);//被依赖因素
                IList<PriceFactor> priceFactorList1 = searchPriceBaseService.GetPriceFactorValueList(priceFactor1);
                IList<PriceFactor> priceFactorList2 = searchPriceBaseService.GetPriceFactorValueList(priceFactor2);
                searchPriceBaseDataAction.Model.PriceFactorList = priceFactorList1;
                searchPriceBaseDataAction.Model.PriceFactorList2 = priceFactorList2;
                IDictionary<Type,string> jsonDic=new Dictionary<Type,string>();
                jsonDic.Add(typeof(PriceBaseDataModel), "PriceFactorList,PriceFactorList2");
                jsonDic.Add(typeof(PriceFactor), "Id,Name");
                return JSONUtils.ToJSONString(searchPriceBaseDataAction.Model, jsonDic);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                throw ex;
            }
        }
    }
}
