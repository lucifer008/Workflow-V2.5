using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table TAKE_WORK ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class TakeWorkBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** �ͻ�_ID [CUSTOMER_ID] */
		private long customerId;
		/** NO [NO] */
		private string no;
		/** ��ʼʱ�� [BEGIN_DATE_TIME] */
		private DateTime beginDateTime;
		/** ����ʱ�� [END_DATE_TIME] */
		private DateTime endDateTime;
		/** ��ϵ�� [LINK_MAN_NAME] */
		private string linkManName;
		/** �绰 [TEL_NO] */
		private string telNo;
		/** ��ַ [ADDRESS] */
		private string address;
		/** ��� [FINISHED] */
		private string finished;
		/** ��ע [MEMO] */
		private string memo;

		public TakeWorkBase()
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
		/// �ͻ�_ID [CUSTOMER_ID]
		/// </summary>
		public virtual long CustomerId
		{
			get { return this.customerId; }
			set { this.customerId = value; }
		}
		/// <summary>
		/// NO [NO]
		/// </summary>
		public virtual string No
		{
			get { return this.no; }
			set { this.no = value; }
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
		/// ��ϵ�� [LINK_MAN_NAME]
		/// </summary>
		public virtual string LinkManName
		{
			get { return this.linkManName; }
			set { this.linkManName = value; }
		}
		/// <summary>
		/// �绰 [TEL_NO]
		/// </summary>
		public virtual string TelNo
		{
			get { return this.telNo; }
			set { this.telNo = value; }
		}
		/// <summary>
		/// ��ַ [ADDRESS]
		/// </summary>
		public virtual string Address
		{
			get { return this.address; }
			set { this.address = value; }
		}
		/// <summary>
		/// ��� [FINISHED]
		/// </summary>
		public virtual string Finished
		{
			get { return this.finished; }
			set { this.finished = value; }
		}
		/// <summary>
		/// ��ע [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}

		private Workflow.Da.Domain.Employee employee;
		/// <summary>
		/// Source Table[TAKE_WORK] Column[EMPLOYEE_ID] --> Target Table[EMPLOYEE] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.Employee Employee
		{
			get { return employee; }
			set { employee = value; }
		}

	}
}
