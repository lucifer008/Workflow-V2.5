using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table FACTOR_VALUE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class FactorValueBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 价格因素_ID [PRICE_FACTOR_ID] */
		private long priceFactorId;
		/** 值 [VALUE] */
		private string value;
		/** 文本 [TEXT] */
		private string text;
		/** 排序号 [SORT_NO] */
		private int sortNo;

		public FactorValueBase()
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
		/// 价格因素_ID [PRICE_FACTOR_ID]
		/// </summary>
		public virtual long PriceFactorId
		{
			get { return this.priceFactorId; }
			set { this.priceFactorId = value; }
		}
		/// <summary>
		/// 值 [VALUE]
		/// </summary>
		public virtual string Value
		{
			get { return this.value; }
			set { this.value = value; }
		}
		/// <summary>
		/// 文本 [TEXT]
		/// </summary>
		public virtual string Text
		{
			get { return this.text; }
			set { this.text = value; }
		}
		/// <summary>
		/// 排序号 [SORT_NO]
		/// </summary>
		public virtual int SortNo
		{
			get { return this.sortNo; }
			set { this.sortNo = value; }
		}


	}
}
