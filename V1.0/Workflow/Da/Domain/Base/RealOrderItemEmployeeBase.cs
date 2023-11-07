using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table REAL_ORDER_ITEM_EMPLOYEE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class RealOrderItemEmployeeBase 
	{
		/** ID [ID] */
		private long id;
		/** 雇员_ID [EMPLOYEE_ID] */
		private long employeeId;
		/** 实际工单明细_ID [REAL_ORDER_ITEM_ID] */
		private long realOrderItemId;

		public RealOrderItemEmployeeBase()
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
		/// 雇员_ID [EMPLOYEE_ID]
		/// </summary>
		public virtual long EmployeeId
		{
			get { return this.employeeId; }
			set { this.employeeId = value; }
		}
		/// <summary>
		/// 实际工单明细_ID [REAL_ORDER_ITEM_ID]
		/// </summary>
		public virtual long RealOrderItemId
		{
			get { return this.realOrderItemId; }
			set { this.realOrderItemId = value; }
		}


	}
}
