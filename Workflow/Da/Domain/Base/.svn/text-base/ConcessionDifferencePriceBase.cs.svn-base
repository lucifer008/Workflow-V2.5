using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table CONCESSION_DIFFERENCE_PRICE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class ConcessionDifferencePriceBase 
	{
		/** ID [ID] */
		private long id;
		/** 优惠活动_ID [CONCESSION_ID] */
		private long concessionId;
		/** 差价 [PRICE_DIFFERENCE] */
		private decimal priceDifference;

		public ConcessionDifferencePriceBase()
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
		/// 优惠活动_ID [CONCESSION_ID]
		/// </summary>
		public virtual long ConcessionId
		{
			get { return this.concessionId; }
			set { this.concessionId = value; }
		}
		/// <summary>
		/// 差价 [PRICE_DIFFERENCE]
		/// </summary>
		public virtual decimal PriceDifference
		{
			get { return this.priceDifference; }
			set { this.priceDifference = value; }
		}

		private Workflow.Da.Domain.BaseBusinessTypePriceSet baseBusinessTypePriceSet;
		/// <summary>
		/// Source Table[CONCESSION_DIFFERENCE_PRICE] Column[BASE_BUSINESS_TYPE_PRICE_SET_ID] --> Target Table[BASE_BUSINESS_TYPE_PRICE_SET] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.BaseBusinessTypePriceSet BaseBusinessTypePriceSet
		{
			get { return baseBusinessTypePriceSet; }
			set { baseBusinessTypePriceSet = value; }
		}

	}
}
