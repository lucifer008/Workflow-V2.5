using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ORDERS_FOR_RECORD_MACHINE_SUM 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class OrdersForRecordMachineSumBase 
	{
		/** ID [ID] */
		private long id;
		/** 机器 [MACHINE_ID] */
		private long machineId;
		/** 工单_ID [ORDERS_ID] */
		private long ordersId;
		/** 颜色区分 [COLOR_TYPE] */
		private string colorType;
		/** 总计印章数 [PAPER_COUNT] */
		private decimal paperCount;
		/** 结算时间 [BALANCE_DATE_TIME] */
		private DateTime balanceDateTime;
		/** 废张数 [TRASH_PAPERS] */
		private decimal trashPapers;

		public OrdersForRecordMachineSumBase()
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
		/// 机器 [MACHINE_ID]
		/// </summary>
		public virtual long MachineId
		{
			get { return this.machineId; }
			set { this.machineId = value; }
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
		/// 颜色区分 [COLOR_TYPE]
		/// </summary>
		public virtual string ColorType
		{
			get { return this.colorType; }
			set { this.colorType = value; }
		}
		/// <summary>
		/// 总计印章数 [PAPER_COUNT]
		/// </summary>
		public virtual decimal PaperCount
		{
			get { return this.paperCount; }
			set { this.paperCount = value; }
		}
		/// <summary>
		/// 结算时间 [BALANCE_DATE_TIME]
		/// </summary>
		public virtual DateTime BalanceDateTime
		{
			get { return this.balanceDateTime; }
			set { this.balanceDateTime = value; }
		}
		/// <summary>
		/// 废张数 [TRASH_PAPERS]
		/// </summary>
		public virtual decimal TrashPapers
		{
			get { return this.trashPapers; }
			set { this.trashPapers = value; }
		}

		private Workflow.Da.Domain.PaperSpecification paperSpecification;
		/// <summary>
		/// Source Table[ORDERS_FOR_RECORD_MACHINE_SUM] Column[PAPER_SPECIFICATION_ID] --> Target Table[PAPER_SPECIFICATION] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.PaperSpecification PaperSpecification
		{
			get { return paperSpecification; }
			set { paperSpecification = value; }
		}

	}
}
