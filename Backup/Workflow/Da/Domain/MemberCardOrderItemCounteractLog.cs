#region imports
using System;
using Workflow.Da.Domain.Base;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MEMBER_CARD_ORDER_ITEM_COUNTERACT_LOG (会员卡订单明细冲减记录) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class MemberCardOrderItemCounteractLog : MemberCardOrderItemCounteractLogBase
	{
		public MemberCardOrderItemCounteractLog()
		{
		}

		#region 活动类型

		private string campaignType;
		/// <summary>
		/// 活动类型
		/// </summary>
		public string CampaignType
		{
			get { return campaignType; }
			set { campaignType = value; }
		}
		 
		#endregion

		#region 活动临时id(在未区分活动之前存放)

		private long campaignTempId;
		/// <summary>
		/// 活动临时id(在未区分活动之前存放)
		/// </summary>
		public long CampaignTempId
		{
			get { return campaignTempId; }
			set { campaignTempId = value; }
		}

		#endregion

		#region 使用数量(金额)

		private decimal usedAmount;
		/// <summary>
		/// 使用数量(金额)
		/// </summary>
		public decimal UsedAmount
		{
			get { return usedAmount; }
			set { usedAmount = value; }
		}

		#endregion

		#region 活动单价

		private decimal campaignUnitPrice;
		/// <summary>
		/// 活动单价
		/// </summary>
		public decimal CampaignUnitPrice
		{
			get { return campaignUnitPrice; }
			set { campaignUnitPrice = value; }
		}

		#endregion

		#region 当前订单明细折扣的金额

		private decimal orderItemDiscountPrice;
		/// <summary>
		/// 当前订单明细的实际金额
		/// </summary>
		public decimal OrderItemDiscountPrice
		{
			get { return orderItemDiscountPrice; }
			set { orderItemDiscountPrice = value; }
		}

		#endregion
	}
}