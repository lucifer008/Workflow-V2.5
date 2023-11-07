using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MACHINE_WATCH_RECORD_LOG对应的DotNet Object
	/// </summary>
	[Serializable]
	public class MachineWatchRecordLog : MachineWatchRecordLogBase
	{
		public MachineWatchRecordLog()
		{
		}

		#region 抄表id

        //private long recordMachineWatchId;
        ///// <summary>
        ///// 抄表id
        ///// </summary>
        //public long RecordMachineWatchId
        //{
        //    get { return recordMachineWatchId; }
        //    set { recordMachineWatchId = value; }
        //}

		#endregion

		#region 表类型

		private int watchType;
		/// <summary>
		/// 表类型
		/// </summary>
		public int WatchType
		{
			get { return watchType; }
			set { watchType = value; }
		}

		#endregion
	}
}
