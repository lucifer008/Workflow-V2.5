using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table BUSINESS_TYPE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class BusinessTypeBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 名称 [NAME] */
		private string name;
		/** 需要抄表 [NEED_RECORD_MACHINE] */
		private string needRecordMachine;

		public BusinessTypeBase()
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
		/// 名称 [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}
		/// <summary>
		/// 需要抄表 [NEED_RECORD_MACHINE]
		/// </summary>
		public virtual string NeedRecordMachine
		{
			get { return this.needRecordMachine; }
			set { this.needRecordMachine = value; }
		}

		private IList<Workflow.Da.Domain.PriceFactor> priceFactorList;
		/// <summary>
		/// Source Table[BUSINESS_TYPE] Column[ID] --> Target Table[PRICE_FACTOR] Column[ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.PriceFactor> PriceFactorList
		{
			get { return priceFactorList; }
			set { priceFactorList = value; }
		}

	}
}
