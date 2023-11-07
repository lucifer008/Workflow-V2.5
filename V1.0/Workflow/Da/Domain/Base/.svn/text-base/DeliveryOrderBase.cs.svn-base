using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table DELIVERY_ORDER 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class DeliveryOrderBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 工单_ID [ORDERS_ID] */
		private long ordersId;
		/** 开始时间 [BEGIN_DATE_TIME] */
		private DateTime beginDateTime;
		/** 结束时间 [END_DATE_TIME] */
		private DateTime endDateTime;
		/** 备注 [MEMO] */
		private string memo;
		/** 完成 [FINISHED] */
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
		/// 工单_ID [ORDERS_ID]
		/// </summary>
		public virtual long OrdersId
		{
			get { return this.ordersId; }
			set { this.ordersId = value; }
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
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// 完成 [FINISHED]
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
