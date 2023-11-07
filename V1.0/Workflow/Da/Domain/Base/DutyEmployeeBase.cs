using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table DUTY_EMPLOYEE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class DutyEmployeeBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 雇员_ID [EMPLOYEE_ID] */
		private long employeeId;
		/** 工单责任_ID [ORDERS_DUTY_ID] */
		private long ordersDutyId;

		public DutyEmployeeBase()
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
		/// 工单责任_ID [ORDERS_DUTY_ID]
		/// </summary>
		public virtual long OrdersDutyId
		{
			get { return this.ordersDutyId; }
			set { this.ordersDutyId = value; }
		}


	}
}
