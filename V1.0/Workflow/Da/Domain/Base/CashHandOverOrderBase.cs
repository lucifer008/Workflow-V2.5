using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table CASH_HAND_OVER_ORDERS 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class CashHandOverOrderBase 
	{
		/** ID [ID] */
		private long id;
		/** 工单_ID [ORDERS_ID] */
		private long ordersId;
		/** 收银交班_ID [CASH_HAND_OVER_ID] */
		private long cashHandOverId;
		/** NO [NO] */
		private string no;
		/** 定金金额 [EARNEST_AMOUNT] */
		private decimal earnestAmount;

		public CashHandOverOrderBase()
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
		/// 收银交班_ID [CASH_HAND_OVER_ID]
		/// </summary>
		public virtual long CashHandOverId
		{
			get { return this.cashHandOverId; }
			set { this.cashHandOverId = value; }
		}
		/// <summary>
		/// NO [NO]
		/// </summary>
		public virtual string No
		{
			get { return this.no; }
			set { this.no = value; }
		}
		/// <summary>
		/// 定金金额 [EARNEST_AMOUNT]
		/// </summary>
		public virtual decimal EarnestAmount
		{
			get { return this.earnestAmount; }
			set { this.earnestAmount = value; }
		}


	}
}
