using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table BASE_BUSINESS_TYPE_PRICE_SET 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class BaseBusinessTypePriceSetBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 因素1 [FACTOR1] */
		private long factor1;
		/** 因素2 [FACTOR2] */
		private long factor2;
		/** 因素3 [FACTOR3] */
		private long factor3;
		/** 因素4 [FACTOR4] */
		private long factor4;
		/** 因素5 [FACTOR5] */
		private long factor5;
		/** 因素6 [FACTOR6] */
		private long factor6;
		/** 因素7 [FACTOR7] */
		private long factor7;
		/** 因素8 [FACTOR8] */
		private long factor8;
		/** 因素9 [FACTOR9] */
		private long factor9;
		/** 因素10 [FACTOR10] */
		private long factor10;
		/** 因素11 [FACTOR11] */
		private long factor11;
		/** 因素12 [FACTOR12] */
		private long factor12;
		/** 因素13 [FACTOR13] */
		private long factor13;
		/** 因素14 [FACTOR14] */
		private long factor14;
		/** 因素15 [FACTOR15] */
		private long factor15;
		/** 因素16 [FACTOR16] */
		private long factor16;
		/** 因素17 [FACTOR17] */
		private long factor17;
		/** 因素18 [FACTOR18] */
		private long factor18;
		/** 因素19 [FACTOR19] */
		private long factor19;
		/** 因素20 [FACTOR20] */
		private long factor20;
		/** 成本价格 [COST_PRICE] */
		private decimal costPrice;
		/** 标准价格 [STANDARD_PRICE] */
		private decimal standardPrice;
		/** 活动价格 [ACTIVITY_PRICE] */
		private decimal activityPrice;
		/** 备用价格 [RESERVE_PRICE] */
		private decimal reservePrice;

		public BaseBusinessTypePriceSetBase()
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
		/// 因素1 [FACTOR1]
		/// </summary>
		public virtual long Factor1
		{
			get { return this.factor1; }
			set { this.factor1 = value; }
		}
		/// <summary>
		/// 因素2 [FACTOR2]
		/// </summary>
		public virtual long Factor2
		{
			get { return this.factor2; }
			set { this.factor2 = value; }
		}
		/// <summary>
		/// 因素3 [FACTOR3]
		/// </summary>
		public virtual long Factor3
		{
			get { return this.factor3; }
			set { this.factor3 = value; }
		}
		/// <summary>
		/// 因素4 [FACTOR4]
		/// </summary>
		public virtual long Factor4
		{
			get { return this.factor4; }
			set { this.factor4 = value; }
		}
		/// <summary>
		/// 因素5 [FACTOR5]
		/// </summary>
		public virtual long Factor5
		{
			get { return this.factor5; }
			set { this.factor5 = value; }
		}
		/// <summary>
		/// 因素6 [FACTOR6]
		/// </summary>
		public virtual long Factor6
		{
			get { return this.factor6; }
			set { this.factor6 = value; }
		}
		/// <summary>
		/// 因素7 [FACTOR7]
		/// </summary>
		public virtual long Factor7
		{
			get { return this.factor7; }
			set { this.factor7 = value; }
		}
		/// <summary>
		/// 因素8 [FACTOR8]
		/// </summary>
		public virtual long Factor8
		{
			get { return this.factor8; }
			set { this.factor8 = value; }
		}
		/// <summary>
		/// 因素9 [FACTOR9]
		/// </summary>
		public virtual long Factor9
		{
			get { return this.factor9; }
			set { this.factor9 = value; }
		}
		/// <summary>
		/// 因素10 [FACTOR10]
		/// </summary>
		public virtual long Factor10
		{
			get { return this.factor10; }
			set { this.factor10 = value; }
		}
		/// <summary>
		/// 因素11 [FACTOR11]
		/// </summary>
		public virtual long Factor11
		{
			get { return this.factor11; }
			set { this.factor11 = value; }
		}
		/// <summary>
		/// 因素12 [FACTOR12]
		/// </summary>
		public virtual long Factor12
		{
			get { return this.factor12; }
			set { this.factor12 = value; }
		}
		/// <summary>
		/// 因素13 [FACTOR13]
		/// </summary>
		public virtual long Factor13
		{
			get { return this.factor13; }
			set { this.factor13 = value; }
		}
		/// <summary>
		/// 因素14 [FACTOR14]
		/// </summary>
		public virtual long Factor14
		{
			get { return this.factor14; }
			set { this.factor14 = value; }
		}
		/// <summary>
		/// 因素15 [FACTOR15]
		/// </summary>
		public virtual long Factor15
		{
			get { return this.factor15; }
			set { this.factor15 = value; }
		}
		/// <summary>
		/// 因素16 [FACTOR16]
		/// </summary>
		public virtual long Factor16
		{
			get { return this.factor16; }
			set { this.factor16 = value; }
		}
		/// <summary>
		/// 因素17 [FACTOR17]
		/// </summary>
		public virtual long Factor17
		{
			get { return this.factor17; }
			set { this.factor17 = value; }
		}
		/// <summary>
		/// 因素18 [FACTOR18]
		/// </summary>
		public virtual long Factor18
		{
			get { return this.factor18; }
			set { this.factor18 = value; }
		}
		/// <summary>
		/// 因素19 [FACTOR19]
		/// </summary>
		public virtual long Factor19
		{
			get { return this.factor19; }
			set { this.factor19 = value; }
		}
		/// <summary>
		/// 因素20 [FACTOR20]
		/// </summary>
		public virtual long Factor20
		{
			get { return this.factor20; }
			set { this.factor20 = value; }
		}
		/// <summary>
		/// 成本价格 [COST_PRICE]
		/// </summary>
		public virtual decimal CostPrice
		{
			get { return this.costPrice; }
			set { this.costPrice = value; }
		}
		/// <summary>
		/// 标准价格 [STANDARD_PRICE]
		/// </summary>
		public virtual decimal StandardPrice
		{
			get { return this.standardPrice; }
			set { this.standardPrice = value; }
		}
		/// <summary>
		/// 活动价格 [ACTIVITY_PRICE]
		/// </summary>
		public virtual decimal ActivityPrice
		{
			get { return this.activityPrice; }
			set { this.activityPrice = value; }
		}
		/// <summary>
		/// 备用价格 [RESERVE_PRICE]
		/// </summary>
		public virtual decimal ReservePrice
		{
			get { return this.reservePrice; }
			set { this.reservePrice = value; }
		}

		private Workflow.Da.Domain.BusinessType businessType;
		/// <summary>
		/// Source Table[BASE_BUSINESS_TYPE_PRICE_SET] Column[BUSINESS_TYPE_ID] --> Target Table[BUSINESS_TYPE] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.BusinessType BusinessType
		{
			get { return businessType; }
			set { businessType = value; }
		}
	}
}
