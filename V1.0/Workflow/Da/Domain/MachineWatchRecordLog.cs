using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MACHINE_WATCH_RECORD_LOG��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class MachineWatchRecordLog : MachineWatchRecordLogBase
	{
		public MachineWatchRecordLog()
		{
		}

		#region ����id

        //private long recordMachineWatchId;
        ///// <summary>
        ///// ����id
        ///// </summary>
        //public long RecordMachineWatchId
        //{
        //    get { return recordMachineWatchId; }
        //    set { recordMachineWatchId = value; }
        //}

		#endregion

		#region ������

		private int watchType;
		/// <summary>
		/// ������
		/// </summary>
		public int WatchType
		{
			get { return watchType; }
			set { watchType = value; }
		}

		#endregion
	}
}
