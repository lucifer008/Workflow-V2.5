using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ORDER_ITEM_PRINT_REQUIRE_DETAIL 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class OrderItemPrintRequireDetailBase 
	{
		/** ID [ID] */
		private long id;
		/** 订单明细_ID [ORDER_ITEM_ID] */
		private long orderItemId;
		/** 印制要求明细详情_ID [PRINT_REQUIRE_DETAIL_ID] */
		private long printRequireDetailId;

		public OrderItemPrintRequireDetailBase()
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
		/// 订单明细_ID [ORDER_ITEM_ID]
		/// </summary>
		public virtual long OrderItemId
		{
			get { return this.orderItemId; }
			set { this.orderItemId = value; }
		}
		/// <summary>
		/// 印制要求明细详情_ID [PRINT_REQUIRE_DETAIL_ID]
		/// </summary>
		public virtual long PrintRequireDetailId
		{
			get { return this.printRequireDetailId; }
			set { this.printRequireDetailId = value; }
		}


	}
}
