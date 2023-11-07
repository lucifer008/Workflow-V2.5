using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MACHINE_WATCH_SCALE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MachineWatchScaleBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 机器_ID [MACHINE_ID] */
		private long machineId;
		/** 机器上的表_ID [MACHINE_WATCH_ID] */
		private long machineWatchId;
		/** 最新读数 [LASTEST_NUMBER] */
		private int lastestNumber;

		public MachineWatchScaleBase()
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
		/// 机器_ID [MACHINE_ID]
		/// </summary>
		public virtual long MachineId
		{
			get { return this.machineId; }
			set { this.machineId = value; }
		}
		/// <summary>
		/// 机器上的表_ID [MACHINE_WATCH_ID]
		/// </summary>
		public virtual long MachineWatchId
		{
			get { return this.machineWatchId; }
			set { this.machineWatchId = value; }
		}
		/// <summary>
		/// 最新读数 [LASTEST_NUMBER]
		/// </summary>
		public virtual int LastestNumber
		{
			get { return this.lastestNumber; }
			set { this.lastestNumber = value; }
		}


	}
}
