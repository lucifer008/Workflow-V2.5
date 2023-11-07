using System;
using Workflow.Da.Domain.Base;
using System.Collections;
using System.Collections.Generic;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MACHINE对应的DotNet Object
	/// </summary>
	[Serializable]
	public class Machine : MachineBase
	{
		public Machine()
		{
		}
		public IList<MachineWatch> watchs;
		/// <summary>
		/// 机器上的表列表
		/// </summary>
		public IList<MachineWatch> Watchs
		{
			get { return watchs; }
			set { watchs = value; }
		}

        private string machineTypeName;
        public string MachineTypeName 
        {
            set { machineTypeName = value;}
            get { return machineTypeName; }
        }

        private long machineTypeId;
        public long MachineTypeId 
        {
            set { machineTypeId = value; }
            get { return machineTypeId; }
        }
	}
}
