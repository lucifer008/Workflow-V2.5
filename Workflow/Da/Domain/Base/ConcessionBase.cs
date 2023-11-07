using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table CONCESSION ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class ConcessionBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** Ӫ���_ID [CAMPAIGN_ID] */
		private long campaignId;
		/** ���� [NAME] */
		private string name;
		/** ���� [DESCRIPTION] */
		private string description;
		/** ��ֵ��� [CHARGE_AMOUNT] */
		private decimal chargeAmount;
		/** ʵ��ӡ���� [PAPER_COUNT] */
		private decimal paperCount;
		/** ��ע [MEMO] */
		private string memo;
		/** ���� [UNIT_PRICE] */
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
		/// Ӫ���_ID [CAMPAIGN_ID]
		/// </summary>
		public virtual long CampaignId
		{
			get { return this.campaignId; }
			set { this.campaignId = value; }
		}
		/// <summary>
		/// ���� [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}
		/// <summary>
		/// ���� [DESCRIPTION]
		/// </summary>
		public virtual string Description
		{
			get { return this.description; }
			set { this.description = value; }
		}
		/// <summary>
		/// ��ֵ��� [CHARGE_AMOUNT]
		/// </summary>
		public virtual decimal ChargeAmount
		{
			get { return this.chargeAmount; }
			set { this.chargeAmount = value; }
		}
		/// <summary>
		/// ʵ��ӡ���� [PAPER_COUNT]
		/// </summary>
		public virtual decimal PaperCount
		{
			get { return this.paperCount; }
			set { this.paperCount = value; }
		}
		/// <summary>
		/// ��ע [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// ���� [UNIT_PRICE]
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
