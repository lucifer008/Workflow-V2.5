using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table EMPLOYEE_POSITION 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class EmployeePositionBase 
	{
		/** ID [ID] */
		private long id;
		/** 雇员_ID [EMPLOYEE_ID] */
		private long employeeId;
		/** 岗位_ID [POSITION_ID] */
		private long positionId;

		public EmployeePositionBase()
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
		/// 岗位_ID [POSITION_ID]
		/// </summary>
		public virtual long PositionId
		{
			get { return this.positionId; }
			set { this.positionId = value; }
		}


	}
}
