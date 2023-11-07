using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table GATHERING_ORDERS 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class GatheringOrderBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 工单_ID [ORDERS_ID] */
		private long ordersId;
		/** 收款记录_ID [GATHERING_ID] */
		private long gatheringId;
		/** 付款类型 [PAY_KIND] */
		private string payKind;

		public GatheringOrderBase()
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
		/// 工单_ID [ORDERS_ID]
		/// </summary>
		public virtual long OrdersId
		{
			get { return this.ordersId; }
			set { this.ordersId = value; }
		}
		/// <summary>
		/// 收款记录_ID [GATHERING_ID]
		/// </summary>
		public virtual long GatheringId
		{
			get { return this.gatheringId; }
			set { this.gatheringId = value; }
		}
		/// <summary>
		/// 付款类型 [PAY_KIND]
		/// </summary>
		public virtual string PayKind
		{
			get { return this.payKind; }
			set { this.payKind = value; }
		}


	}
}
