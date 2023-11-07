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
using Workflow.Service.CompaignManage;
using Workflow.Service.SystemManege.PriceManage;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: GetBaseBusinessTypePriceSetByIdAjax
    /// 功能概要: 根据业务类型Id获取业务信息,及获取更新的方案信息
    /// 作    者: 张晓林
    /// 创建时间: 2009年3月10日11:44:45
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    class GetBaseBusinessTypePriceSetByIdAjax : AjaxProcess
    {
        #region //ClassMember
        private IPriceService priceService;
        public IPriceService PriceService
        {
            set { priceService = value; }
        }

        private BaseBusinessTypePriceSetAction action;
        public BaseBusinessTypePriceSetAction BaseBusinessTypePriceSetAction
        {
            set { action = value; }
        }

        private ISearchCampaignService searchCampaignService;
        public ISearchCampaignService SearchCampaignService 
        {
            set { searchCampaignService = value; }
            get { return searchCampaignService; }
        }
        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            if (null == parameters["BusinessTypeId"])
            {
                return null;
            }
            else
            {
                BaseBusinessTypePriceSet baseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
                baseBusinessTypePriceSet.Id = Convert.ToInt32(parameters["BusinessTypeId"]);
                //获取价格因素，及价格标题,及因素值
                baseBusinessTypePriceSet = priceService.GetBaseBusinessTypePriceSetById(baseBusinessTypePriceSet);
                //获取要编辑的优惠方案信息
                if (null != parameters["ConcessionId"] && "undefined" != parameters["ConcessionId"])
                {
                    baseBusinessTypePriceSet.Concession = searchCampaignService.GetConcessionInfo(Convert.ToInt32(parameters["ConcessionId"]));
                    baseBusinessTypePriceSet.MemberCardLevelList=searchCampaignService.GetConcessionMemberCardLelvelInfo(Convert.ToInt32(parameters["ConcessionId"]));
                }
                action.Model.BaseBusinessTypePriceSet = baseBusinessTypePriceSet;
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(BaseBusinessTypePriceSet), "Texts,BusinessType,ActivityPrice,Concession,MemberCardLevelList");
                jsonDic.Add(typeof(BusinessType), "PriceFactorList,Name");
                jsonDic.Add(typeof(PriceFactor), "Id,Name,DisplayText");
                jsonDic.Add(typeof(Concession), "CampaignId,Name,Description,ChargeAmount,PaperCount,UnitPrice");
                jsonDic.Add(typeof(MemberCardLevel),"Id");
                return JSONUtils.ToJSONString(action.Model.BaseBusinessTypePriceSet, jsonDic);
            }
        }
    }
}
