using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ORDER_ITEM_EMPLOYEE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class OrderItemEmployeeBase 
	{
		/** ID [ID] */
		private long id;
		/** 订单明细_ID [ORDER_ITEM_ID] */
		private long orderItemId;
		/** 雇员_ID [EMPLOYEE_ID] */
		private long employeeId;

		public OrderItemEmployeeBase()
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
		/// 雇员_ID [EMPLOYEE_ID]
		/// </summary>
		public virtual long EmployeeId
		{
			get { return this.employeeId; }
			set { this.employeeId = value; }
		}


	}
}
