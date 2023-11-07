using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table TRASH_PAPER_EMPLOYEE ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class TrashPaperEmployeeBase 
	{
		/** ID [ID] */
		private long id;
		/** ʵ�ʶ�����ϸ_ID [REAL_ORDER_ITEM_ID] */
		private long realOrderItemId;
		/** ��Ա_ID [EMPLOYEE_ID] */
		private long employeeId;
		/** ������ [TRASH_PAPERS] */
		private decimal trashPapers;

		public TrashPaperEmployeeBase()
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
		/// ʵ�ʶ�����ϸ_ID [REAL_ORDER_ITEM_ID]
		/// </summary>
		public virtual long RealOrderItemId
		{
			get { return this.realOrderItemId; }
			set { this.realOrderItemId = value; }
		}
		/// <summary>
		/// ��Ա_ID [EMPLOYEE_ID]
		/// </summary>
		public virtual long EmployeeId
		{
			get { return this.employeeId; }
			set { this.employeeId = value; }
		}
		/// <summary>
		/// ������ [TRASH_PAPERS]
		/// </summary>
		public virtual decimal TrashPapers
		{
			get { return this.trashPapers; }
			set { this.trashPapers = value; }
		}


	}
}
