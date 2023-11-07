using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table RELATION_EMPLOYEE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class RelationEmployeeBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 订单状态履历_ID [ORDERS_STATUS_ALTER_ID] */
		private long ordersStatusAlterId;
		/** 雇员_ID [EMPLOYEE_ID] */
		private long employeeId;

		public RelationEmployeeBase()
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
		/// 订单状态履历_ID [ORDERS_STATUS_ALTER_ID]
		/// </summary>
		public virtual long OrdersStatusAlterId
		{
			get { return this.ordersStatusAlterId; }
			set { this.ordersStatusAlterId = value; }
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
