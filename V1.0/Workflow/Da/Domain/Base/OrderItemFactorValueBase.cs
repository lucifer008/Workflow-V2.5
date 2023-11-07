using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ORDER_ITEM_FACTOR_VALUE ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class OrderItemFactorValueBase 
	{
		/** ID [ID] */
		private long id;
		/** �۸�����_ID [PRICE_FACTOR_ID] */
		private long priceFactorId;
		/** ������ϸ_ID [ORDER_ITEM_ID] */
		private long orderItemId;
		/** ֵ [VALUE] */
		private string value;

		public OrderItemFactorValueBase()
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
		/// ������ϸ_ID [ORDER_ITEM_ID]
		/// </summary>
		public virtual long OrderItemId
		{
			get { return this.orderItemId; }
			set { this.orderItemId = value; }
		}
		/// <summary>
		/// ֵ [VALUE]
		/// </summary>
		public virtual string Value
		{
			get { return this.value; }
			set { this.value = value; }
		}


	}
}
