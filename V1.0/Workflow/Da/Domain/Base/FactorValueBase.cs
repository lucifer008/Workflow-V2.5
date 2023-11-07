using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table FACTOR_VALUE ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class FactorValueBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** �۸�����_ID [PRICE_FACTOR_ID] */
		private long priceFactorId;
		/** ֵ [VALUE] */
		private string value;
		/** �ı� [TEXT] */
		private string text;
		/** ����� [SORT_NO] */
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
		/// �۸�����_ID [PRICE_FACTOR_ID]
		/// </summary>
		public virtual long PriceFactorId
		{
			get { return this.priceFactorId; }
			set { this.priceFactorId = value; }
		}
		/// <summary>
		/// ֵ [VALUE]
		/// </summary>
		public virtual string Value
		{
			get { return this.value; }
			set { this.value = value; }
		}
		/// <summary>
		/// �ı� [TEXT]
		/// </summary>
		public virtual string Text
		{
			get { return this.text; }
			set { this.text = value; }
		}
		/// <summary>
		/// ����� [SORT_NO]
		/// </summary>
		public virtual int SortNo
		{
			get { return this.sortNo; }
			set { this.sortNo = value; }
		}


	}
}
