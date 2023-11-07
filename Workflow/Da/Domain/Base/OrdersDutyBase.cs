using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ORDERS_DUTY 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class OrdersDutyBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 订单_ID [ORDERS_ID] */
		private long ordersId;
		/** 责任金额 [DUTY_AMOUNT] */
		private decimal dutyAmount;
		/** 备注 [MEMO] */
		private string memo;
		/** 责任标志 [DUTY_FLAG] */
		private string dutyFlag;

		public OrdersDutyBase()
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
		/// 订单_ID [ORDERS_ID]
		/// </summary>
		public virtual long OrdersId
		{
			get { return this.ordersId; }
			set { this.ordersId = value; }
		}
		/// <summary>
		/// 责任金额 [DUTY_AMOUNT]
		/// </summary>
		public virtual decimal DutyAmount
		{
			get { return this.dutyAmount; }
			set { this.dutyAmount = value; }
		}
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// 责任标志 [DUTY_FLAG]
		/// </summary>
		public virtual string DutyFlag
		{
			get { return this.dutyFlag; }
			set { this.dutyFlag = value; }
		}


	}
}
