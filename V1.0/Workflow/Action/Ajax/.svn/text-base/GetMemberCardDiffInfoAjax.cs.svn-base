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
using Workflow.Action.Membercard;
using Workflow.Service;
using Workflow.Service.MemberCardManager;

namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: GetMemberCardDiffInfoAjax
    /// 功能概要: 根据会员Id获取会员参与的优惠业务信息
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月17日10:30:08
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    class GetMemberCardDiffInfoAjax : AjaxProcess
    {
        #region //注入Service
        private ISearchMemberCardService searchMemberCardService;
        public ISearchMemberCardService SearchMemberCardService 
        {
            set { searchMemberCardService = value; }
        }

        private IMemberCardService memberCardService;
        public IMemberCardService MemberCardService 
        {
            set { memberCardService = value; }
        }

        private MemberCardAction memberCardAction;
        public MemberCardAction MemberCardAction 
        {
            set { memberCardAction = value; }
        }
        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            try 
            {
                if (null == parameters["MemberCardId"] || "" == parameters["MemberCardId"]) return "";
                long memberCardId = Convert.ToInt32(parameters["MemberCardId"]);
                long orderId = Convert.ToInt32(parameters["OrderId"]);
                MemberCard memberCard = new MemberCard();
                memberCard.Id = memberCardId;
                memberCard.OperateType = orderId;
                IList<Order> orderListList=searchMemberCardService.GetMemberCardBaseBusItem(memberCard);
                IList<MemberCardConcession> memberCardConcessionList=searchMemberCardService.GetMemberCardConcessionBaseBusniessInfo(memberCardId);

                //获取匹配的业务明细信息
                int cout;//匹配的业务类型数目
                List<MemberCard.MemberCardBaseBusinessTypeItem> memberCardBaseBusinessTypeItemList;//匹配的业务类型信息列表
                List<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList;
                memberCardService.GetMatchingMemberCardBusinessTypeItemInfo(out cout,memberCardConcessionList,orderListList,out memberCardBaseBusinessTypeItemList,out baseBusinessTypePriceSetList);
                memberCardAction.Model.BaseBusinessTypePriceSetList = baseBusinessTypePriceSetList;
                //获取匹配的会员优惠明细列表
                memberCardAction.Model.MemberCardConcessionList=new List<MemberCardConcession>();
                foreach(BaseBusinessTypePriceSet bs in baseBusinessTypePriceSetList)
                {
                    MemberCardConcession memberCardConcession = new MemberCardConcession();
                    memberCardConcession.Id = bs.Id;//BaseBusinessTypeSetId
                    memberCardConcession.MemberCardId = memberCardId;
                    memberCardAction.Model.MemberCardConcessionList.Add(searchMemberCardService.GetMemberCardConcession(memberCardConcession));
                }
                memberCardAction.Model.MemberCardBaseBusinessTypeItemList = memberCardBaseBusinessTypeItemList;
                memberCardAction.Model.Id = cout;
                IDictionary<Type,string> jsonDic=new Dictionary<Type,string>();
                jsonDic.Add(typeof(MemberCardModel), "Id,MemberCardConcessionList,MemberCardBaseBusinessTypeItemList");
                jsonDic.Add(typeof(MemberCardConcession), "Id,ConcessionId,MemberCardId,JoinDateTime,RestPaperCount,PaperCount,Amount");
                jsonDic.Add(typeof(MemberCard.MemberCardBaseBusinessTypeItem), "MemberCardId,BaseBusAmount,BaseBusUnitPrice,OrderId,PactorValueList");
                return JSONUtils.ToJSONString(memberCardAction.Model, jsonDic);
            }
            catch(Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                return "";
            }
           
        }
    }
}
