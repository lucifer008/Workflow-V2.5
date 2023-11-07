using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table DELIVERY_ORDER ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class DeliveryOrderBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ����_ID [ORDERS_ID] */
		private long ordersId;
		/** ��ʼʱ�� [BEGIN_DATE_TIME] */
		private DateTime beginDateTime;
		/** ����ʱ�� [END_DATE_TIME] */
		private DateTime endDateTime;
		/** ��ע [MEMO] */
		private string memo;
		/** ��� [FINISHED] */
		private string finished;

		public DeliveryOrderBase()
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
		/// ����_ID [ORDERS_ID]
		/// </summary>
		public virtual long OrdersId
		{
			get { return this.ordersId; }
			set { this.ordersId = value; }
		}
		/// <summary>
		/// ��ʼʱ�� [BEGIN_DATE_TIME]
		/// </summary>
		public virtual DateTime BeginDateTime
		{
			get { return this.beginDateTime; }
			set { this.beginDateTime = value; }
		}
		/// <summary>
		/// ����ʱ�� [END_DATE_TIME]
		/// </summary>
		public virtual DateTime EndDateTime
		{
			get { return this.endDateTime; }
			set { this.endDateTime = value; }
		}
		/// <summary>
		/// ��ע [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// ��� [FINISHED]
		/// </summary>
		public virtual string Finished
		{
			get { return this.finished; }
			set { this.finished = value; }
		}

		private Workflow.Da.Domain.Employee employee;
		/// <summary>
		/// Source Table[DELIVERY_ORDER] Column[EMPLOYEE_ID] --> Target Table[EMPLOYEE] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.Employee Employee
		{
			get { return employee; }
			set { employee = value; }
		}

	}
}
