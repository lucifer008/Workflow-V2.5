using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table REAL_ORDER_ITEM_TRASH_REASON 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class RealOrderItemTrashReasonBase 
	{
		/** ID [ID] */
		private long id;
		/** 实际订单明细_ID [REAL_ORDER_ITEM_ID] */
		private long realOrderItemId;
		/** 废张原因_ID [TRASH_REASON_ID] */
		private long trashReasonId;

		public RealOrderItemTrashReasonBase()
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
		/// 实际订单明细_ID [REAL_ORDER_ITEM_ID]
		/// </summary>
		public virtual long RealOrderItemId
		{
			get { return this.realOrderItemId; }
			set { this.realOrderItemId = value; }
		}
		/// <summary>
		/// 废张原因_ID [TRASH_REASON_ID]
		/// </summary>
		public virtual long TrashReasonId
		{
			get { return this.trashReasonId; }
			set { this.trashReasonId = value; }
		}


	}
}
