using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table FACTOR_RELATION 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class FactorRelationBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 业务类型_ID [BUSINESS_TYPE_ID] */
		private long businessTypeId;
		/** 价格因素_ID [PRICE_FACTOR_ID] */
		private long priceFactorId;
		/** 备注 [MEMO] */
		private string memo;

		public FactorRelationBase()
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
		/// 业务类型_ID [BUSINESS_TYPE_ID]
		/// </summary>
		public virtual long BusinessTypeId
		{
			get { return this.businessTypeId; }
			set { this.businessTypeId = value; }
		}
		/// <summary>
		/// 价格因素_ID [PRICE_FACTOR_ID]
		/// </summary>
		public virtual long PriceFactorId
		{
			get { return this.priceFactorId; }
			set { this.priceFactorId = value; }
		}
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}

		private Workflow.Da.Domain.PriceFactor priceFactor;
		/// <summary>
		/// Source Table[FACTOR_RELATION] Column[PRICE_FACTOR_ID2] --> Target Table[PRICE_FACTOR] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.PriceFactor PriceFactor
		{
			get { return priceFactor; }
			set { priceFactor = value; }
		}

	}
}
