using System;
using Workflow.Da.Domain.Base;
using System.Collections.Generic;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MACHINE_WATCH��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class MachineWatch : MachineWatchBase
	{
		public MachineWatch()
		{
		}
		private int number;
		/// <summary>
		/// �����ϵı�Ķ�ȡ
		/// </summary>
		public int Number
		{
			get { return number; }
			set { number = value; }
		}
	}
}
