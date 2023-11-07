using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MACHINE_TYPE ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class MachineTypeBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** NO [NO] */
		private string no;
		/** ���� [NAME] */
		private string name;
		/** ��Ҫ���� [NEED_RECORD_WARCH] */
		private string needRecordWarch;

		public MachineTypeBase()
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
		/// NO [NO]
		/// </summary>
		public virtual string No
		{
			get { return this.no; }
			set { this.no = value; }
		}
		/// <summary>
		/// ���� [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}
		/// <summary>
		/// ��Ҫ���� [NEED_RECORD_WARCH]
		/// </summary>
		public virtual string NeedRecordWarch
		{
			get { return this.needRecordWarch; }
			set { this.needRecordWarch = value; }
		}

		private IList<Workflow.Da.Domain.MachineWatchConversionPaper> machineWatchConversionPaperList;
		/// <summary>
		/// Source Table[MACHINE_TYPE] Column[ID] --> Target Table[MACHINE_WATCH_CONVERSION_PAPER] Column[MACHINE_TYPE_ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.MachineWatchConversionPaper> MachineWatchConversionPaperList
		{
			get { return machineWatchConversionPaperList; }
			set { machineWatchConversionPaperList = value; }
		}
		private IList<Workflow.Da.Domain.MachineWatch> machineWatchList;
		/// <summary>
		/// Source Table[MACHINE_TYPE] Column[ID] --> Target Table[MACHINE_WATCH] Column[MACHINE_TYPE_ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.MachineWatch> MachineWatchList
		{
			get { return machineWatchList; }
			set { machineWatchList = value; }
		}
		private IList<Workflow.Da.Domain.Machine> machineList;
		/// <summary>
		/// Source Table[MACHINE_TYPE] Column[ID] --> Target Table[MACHINE] Column[MACHINE_TYPE_ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.Machine> MachineList
		{
			get { return machineList; }
			set { machineList = value; }
		}

	}
}
