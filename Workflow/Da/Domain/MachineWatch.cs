using System;
using Workflow.Da.Domain.Base;
using System.Collections.Generic;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MACHINE_WATCH对应的DotNet Object
	/// </summary>
	[Serializable]
	public class MachineWatch : MachineWatchBase
	{
		public MachineWatch()
		{
		}
		private int number;
		/// <summary>
		/// 机器上的表的读取
		/// </summary>
		public int Number
		{
			get { return number; }
			set { number = value; }
		}
	}
}
