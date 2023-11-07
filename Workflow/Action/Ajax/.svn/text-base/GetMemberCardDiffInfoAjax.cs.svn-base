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
using Workflow.Service.OrderManage;
using Workflow.Service.SystemManege.PriceManage;
using Workflow.Service.CompaignManage;

namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: GetMemberCardDiffInfoAjax
    /// 功能概要: 根据会员Id获取会员参与的优惠业务信息
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月17日10:30:08
    /// 修正履历: 陈汝胤
    /// 修正时间: 2009-5-19
	/// 描    述: 2个活动同时使用
    /// </summary>
    class GetMemberCardDiffInfoAjax : AjaxProcess
	{
		#region 类成员

		private MemberCardCampaignModel model = new MemberCardCampaignModel();

		#endregion

		#region 注入Service

		#region 注入 campaignService

		private ICampaignService campaignService;
		/// <summary>
		/// 注入 campaignService
		/// </summary>
		public ICampaignService CampaignService
		{
			set { campaignService = value; }
		}

		#endregion

		#region 注入 orderService
		private IOrderService orderService;
		/// <summary>
		/// 注入 orderService
		/// </summary>
		public IOrderService OrderService
		{
			set { orderService = value; }
		}
		#endregion

		#region 注入 priceService
		private IPriceService priceService;
		/// <summary>
		/// 注入 priceService
		/// </summary>
		public IPriceService PriceService
		{
			set { priceService = value; }
		}
		#endregion

        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            try
            {
				string orderNo = parameters["orderNo"];
                if (null == parameters["MemberCardId"] || "" == parameters["MemberCardId"]) return "";
                long memberCardId = Convert.ToInt32(parameters["MemberCardId"]);
                long orderId = Convert.ToInt32(parameters["OrderId"]);
                MemberCard memberCard = new MemberCard();
                memberCard.Id = memberCardId;
                memberCard.OperateType = orderId;
                //IList<Order> orderListList=searchMemberCardService.GetMemberCardBaseBusItem(memberCard);
                //IList<MemberCardConcession> memberCardConcessionList=searchMemberCardService.GetMemberCardConcessionBaseBusniessInfo(memberCardId);

				//获取会员卡参加的有效的送印章活动
				model.MemberCardConcessionList = campaignService.GetValidMemberCardConcession(memberCardId);
				//获取会员卡产假的有效的打折活动
				model.MemberCardDiscountConcessionList = campaignService.GetValidMemberDiscountCardConcession(memberCardId);

				if (model.MemberCardConcessionList.Count == 0 && model.MemberCardDiscountConcessionList.Count == 0)
					return "";

				model.OrderItemList = priceService.GetOrderItemBaseBusinessTypePriceSet(orderNo);

                IDictionary<Type,string> jsonDic=new Dictionary<Type,string>();
				jsonDic.Add(typeof(MemberCardCampaignModel), "Id,MemberCardConcessionList,MemberCardDiscountConcessionList,OrderItemList");
				jsonDic.Add(typeof(MemberCardConcession), "Id,ConcessionName,RestPaperCount,BaseBusinessTypePriceSetId,PaperCount,Amount,ConcessionPrice");
				jsonDic.Add(typeof(MemberCardDiscountConcession), "Id,DiscountConcessionName,RestAmount,Discount,ContrastValues");
				jsonDic.Add(typeof(OrderItem), "Id,Amount,UnitPrice,BaseBusinessTypePriceSetId,MachinePriceFactor,PaperPriceFactor");
				return JSONUtils.ToJSONString(model, jsonDic);
            }
            catch(Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                return "";
            }
        }
    }
}
