using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table COMPENSATE_EMPLOYEE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class CompensateEmployeeBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 雇员_ID [EMPLOYEE_ID] */
		private long employeeId;
		/** 补单用纸情况_ID [COMPENSATE_USED_PAPER_ID] */
		private long compensateUsedPaperId;

		public CompensateEmployeeBase()
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
		/// 补单用纸情况_ID [COMPENSATE_USED_PAPER_ID]
		/// </summary>
		public virtual long CompensateUsedPaperId
		{
			get { return this.compensateUsedPaperId; }
			set { this.compensateUsedPaperId = value; }
		}


	}
}
