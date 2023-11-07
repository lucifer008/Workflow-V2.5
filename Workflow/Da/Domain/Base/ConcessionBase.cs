using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table CONCESSION 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class ConcessionBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 营销活动_ID [CAMPAIGN_ID] */
		private long campaignId;
		/** 名称 [NAME] */
		private string name;
		/** 描述 [DESCRIPTION] */
		private string description;
		/** 冲值金额 [CHARGE_AMOUNT] */
		private decimal chargeAmount;
		/** 实际印章数 [PAPER_COUNT] */
		private decimal paperCount;
		/** 备注 [MEMO] */
		private string memo;
		/** 单价 [UNIT_PRICE] */
		private decimal unitPrice;

		public ConcessionBase()
		{
			
		}

		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return this.id; }
			set { this.id = value; }
		}
		/// <summary>
		/// 营销活动_ID [CAMPAIGN_ID]
		/// </summary>
		public virtual long CampaignId
		{
			get { return this.campaignId; }
			set { this.campaignId = value; }
		}
		/// <summary>
		/// 名称 [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}
		/// <summary>
		/// 描述 [DESCRIPTION]
		/// </summary>
		public virtual string Description
		{
			get { return this.description; }
			set { this.description = value; }
		}
		/// <summary>
		/// 冲值金额 [CHARGE_AMOUNT]
		/// </summary>
		public virtual decimal ChargeAmount
		{
			get { return this.chargeAmount; }
			set { this.chargeAmount = value; }
		}
		/// <summary>
		/// 实际印章数 [PAPER_COUNT]
		/// </summary>
		public virtual decimal PaperCount
		{
			get { return this.paperCount; }
			set { this.paperCount = value; }
		}
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// 单价 [UNIT_PRICE]
		/// </summary>
		public virtual decimal UnitPrice
		{
			get { return this.unitPrice; }
			set { this.unitPrice = value; }
		}

		private Workflow.Da.Domain.BaseBusinessTypePriceSet baseBusinessTypePriceSet;
		/// <summary>
		/// Source Table[CONCESSION] Column[BASE_BUSINESS_TYPE_PRICE_SET_ID] --> Target Table[BASE_BUSINESS_TYPE_PRICE_SET] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.BaseBusinessTypePriceSet BaseBusinessTypePriceSet
		{
			get { return baseBusinessTypePriceSet; }
			set { baseBusinessTypePriceSet = value; }
		}
		private IList<Workflow.Da.Domain.MemberCardLevel> memberCardLevelList;
		/// <summary>
		/// Source Table[CONCESSION] Column[ID] --> Target Table[MEMBER_CARD_LEVEL] Column[ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.MemberCardLevel> MemberCardLevelList
		{
			get { return memberCardLevelList; }
			set { memberCardLevelList = value; }
		}

	}
}
