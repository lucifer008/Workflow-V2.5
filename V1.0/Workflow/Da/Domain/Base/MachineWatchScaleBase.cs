using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MACHINE_WATCH_SCALE ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class MachineWatchScaleBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ����_ID [MACHINE_ID] */
		private long machineId;
		/** �����ϵı�_ID [MACHINE_WATCH_ID] */
		private long machineWatchId;
		/** ���¶��� [LASTEST_NUMBER] */
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
		/// ����_ID [MACHINE_ID]
		/// </summary>
		public virtual long MachineId
		{
			get { return this.machineId; }
			set { this.machineId = value; }
		}
		/// <summary>
		/// �����ϵı�_ID [MACHINE_WATCH_ID]
		/// </summary>
		public virtual long MachineWatchId
		{
			get { return this.machineWatchId; }
			set { this.machineWatchId = value; }
		}
		/// <summary>
		/// ���¶��� [LASTEST_NUMBER]
		/// </summary>
		public virtual int LastestNumber
		{
			get { return this.lastestNumber; }
			set { this.lastestNumber = value; }
		}


	}
}
