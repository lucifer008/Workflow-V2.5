using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MACHINE_WATCH_RECORD_LOG ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class MachineWatchRecordLogBase 
	{
		/** ID [ID] */
		private long id;
		/** ����_ID [RECORD_MACHINE_WATCH_ID] */
		private long recordMachineWatchId;
		/** �ϴζ��� [LAST_NUMBER] */
		private int lastNumber;
		/** ���ζ��� [NEW_NUMBER] */
		private int newNumber;
		/** ��ע [MEMO] */
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
		/// ����_ID [RECORD_MACHINE_WATCH_ID]
		/// </summary>
		public virtual long RecordMachineWatchId
		{
			get { return this.recordMachineWatchId; }
			set { this.recordMachineWatchId = value; }
		}
		/// <summary>
		/// �ϴζ��� [LAST_NUMBER]
		/// </summary>
		public virtual int LastNumber
		{
			get { return this.lastNumber; }
			set { this.lastNumber = value; }
		}
		/// <summary>
		/// ���ζ��� [NEW_NUMBER]
		/// </summary>
		public virtual int NewNumber
		{
			get { return this.newNumber; }
			set { this.newNumber = value; }
		}
		/// <summary>
		/// ��ע [MEMO]
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
