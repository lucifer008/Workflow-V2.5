using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MACHINE_WATCH_RECORD_LOG 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MachineWatchRecordLogBase 
	{
		/** ID [ID] */
		private long id;
		/** 抄表_ID [RECORD_MACHINE_WATCH_ID] */
		private long recordMachineWatchId;
		/** 上次读数 [LAST_NUMBER] */
		private int lastNumber;
		/** 本次读数 [NEW_NUMBER] */
		private int newNumber;
		/** 备注 [MEMO] */
		private string memo;

		public MachineWatchRecordLogBase()
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
		/// 上次读数 [LAST_NUMBER]
		/// </summary>
		public virtual int LastNumber
		{
			get { return this.lastNumber; }
			set { this.lastNumber = value; }
		}
		/// <summary>
		/// 本次读数 [NEW_NUMBER]
		/// </summary>
		public virtual int NewNumber
		{
			get { return this.newNumber; }
			set { this.newNumber = value; }
		}
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}

		private Workflow.Da.Domain.MachineWatch machineWatch;
		/// <summary>
		/// Source Table[MACHINE_WATCH_RECORD_LOG] Column[MACHINE_WATCH_ID] --> Target Table[MACHINE_WATCH] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.MachineWatch MachineWatch
		{
			get { return machineWatch; }
			set { machineWatch = value; }
		}
		private Workflow.Da.Domain.Machine machine;
		/// <summary>
		/// Source Table[MACHINE_WATCH_RECORD_LOG] Column[MACHINE_ID] --> Target Table[MACHINE] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.Machine Machine
		{
			get { return machine; }
			set { machine = value; }
		}

	}
}
