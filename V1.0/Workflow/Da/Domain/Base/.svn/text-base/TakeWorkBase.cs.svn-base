using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table TAKE_WORK 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class TakeWorkBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 客户_ID [CUSTOMER_ID] */
		private long customerId;
		/** NO [NO] */
		private string no;
		/** 开始时间 [BEGIN_DATE_TIME] */
		private DateTime beginDateTime;
		/** 结束时间 [END_DATE_TIME] */
		private DateTime endDateTime;
		/** 联系人 [LINK_MAN_NAME] */
		private string linkManName;
		/** 电话 [TEL_NO] */
		private string telNo;
		/** 地址 [ADDRESS] */
		private string address;
		/** 完成 [FINISHED] */
		private string finished;
		/** 备注 [MEMO] */
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
		/// 客户_ID [CUSTOMER_ID]
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
		/// 开始时间 [BEGIN_DATE_TIME]
		/// </summary>
		public virtual DateTime BeginDateTime
		{
			get { return this.beginDateTime; }
			set { this.beginDateTime = value; }
		}
		/// <summary>
		/// 结束时间 [END_DATE_TIME]
		/// </summary>
		public virtual DateTime EndDateTime
		{
			get { return this.endDateTime; }
			set { this.endDateTime = value; }
		}
		/// <summary>
		/// 联系人 [LINK_MAN_NAME]
		/// </summary>
		public virtual string LinkManName
		{
			get { return this.linkManName; }
			set { this.linkManName = value; }
		}
		/// <summary>
		/// 电话 [TEL_NO]
		/// </summary>
		public virtual string TelNo
		{
			get { return this.telNo; }
			set { this.telNo = value; }
		}
		/// <summary>
		/// 地址 [ADDRESS]
		/// </summary>
		public virtual string Address
		{
			get { return this.address; }
			set { this.address = value; }
		}
		/// <summary>
		/// 完成 [FINISHED]
		/// </summary>
		public virtual string Finished
		{
			get { return this.finished; }
			set { this.finished = value; }
		}
		/// <summary>
		/// 备注 [MEMO]
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
