using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table COMPENSATE_USED_PAPER 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class CompensateUsedPaperBase 
	{
		/** ID [ID] */
		private long id;
		/** 抄表_ID [RECORD_MACHINE_WATCH_ID] */
		private long recordMachineWatchId;
		/** 用纸量 [USED_PAPER_COUNT] */
		private int usedPaperCount;
		/** 颜色区分 [COLOR_TYPE] */
		private string colorType;
		/** 备注 [MEMO] */
		private string memo;

		public CompensateUsedPaperBase()
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
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}

		private Workflow.Da.Domain.Machine machine;
		/// <summary>
		/// Source Table[COMPENSATE_USED_PAPER] Column[MACHINE_ID] --> Target Table[MACHINE] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.Machine Machine
		{
			get { return machine; }
			set { machine = value; }
		}
		private Workflow.Da.Domain.PaperSpecification paperSpecification;
		/// <summary>
		/// Source Table[COMPENSATE_USED_PAPER] Column[PAPER_SPECIFICATION_ID] --> Target Table[PAPER_SPECIFICATION] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.PaperSpecification PaperSpecification
		{
			get { return paperSpecification; }
			set { paperSpecification = value; }
		}
		private IList<Workflow.Da.Domain.Employee> employeeList;
		/// <summary>
		/// Source Table[COMPENSATE_USED_PAPER] Column[ID] --> Target Table[EMPLOYEE] Column[ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.Employee> EmployeeList
		{
			get { return employeeList; }
			set { employeeList = value; }
		}

	}
}
