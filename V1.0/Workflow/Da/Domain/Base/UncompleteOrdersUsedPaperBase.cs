using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table UNCOMPLETE_ORDERS_USED_PAPER 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class UncompleteOrdersUsedPaperBase 
	{
		/** ID [ID] */
		private long id;
		/** 工单_ID [ORDERS_ID] */
		private long ordersId;
		/** 抄表_ID [RECORD_MACHINE_WATCH_ID] */
		private long recordMachineWatchId;
		/** 用纸量 [USED_PAPER_COUNT] */
		private int usedPaperCount;
		/** 颜色区分 [COLOR_TYPE] */
		private string colorType;

		public UncompleteOrdersUsedPaperBase()
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
		/// 抄表_ID [RECORD_MACHINE_WATCH_ID]
		/// </summary>
		public virtual long RecordMachineWatchId
		{
			get { return this.recordMachineWatchId; }
			set { this.recordMachineWatchId = value; }
		}
		/// <summary>
		/// 用纸量 [USED_PAPER_COUNT]
		/// </summary>
		public virtual int UsedPaperCount
		{
			get { return this.usedPaperCount; }
			set { this.usedPaperCount = value; }
		}
		/// <summary>
		/// 颜色区分 [COLOR_TYPE]
		/// </summary>
		public virtual string ColorType
		{
			get { return this.colorType; }
			set { this.colorType = value; }
		}

		private Workflow.Da.Domain.Machine machine;
		/// <summary>
		/// Source Table[UNCOMPLETE_ORDERS_USED_PAPER] Column[MACHINE_ID] --> Target Table[MACHINE] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.Machine Machine
		{
			get { return machine; }
			set { machine = value; }
		}
		private Workflow.Da.Domain.PaperSpecification paperSpecification;
		/// <summary>
		/// Source Table[UNCOMPLETE_ORDERS_USED_PAPER] Column[PAPER_SPECIFICATION_ID] --> Target Table[PAPER_SPECIFICATION] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.PaperSpecification PaperSpecification
		{
			get { return paperSpecification; }
			set { paperSpecification = value; }
		}

	}
}
