using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table RELATION_EMPLOYEE ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class RelationEmployeeBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ����״̬����_ID [ORDERS_STATUS_ALTER_ID] */
		private long ordersStatusAlterId;
		/** ��Ա_ID [EMPLOYEE_ID] */
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
		/// ����״̬����_ID [ORDERS_STATUS_ALTER_ID]
		/// </summary>
		public virtual long OrdersStatusAlterId
		{
			get { return this.ordersStatusAlterId; }
			set { this.ordersStatusAlterId = value; }
		}
		/// <summary>
		/// ��Ա_ID [EMPLOYEE_ID]
		/// </summary>
		public virtual long EmployeeId
		{
			get { return this.employeeId; }
			set { this.employeeId = value; }
		}


	}
}
