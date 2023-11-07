#region imports
using System;
using Workflow.Da.Domain.Base;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MACHINE_WATCH_SCALE (机器上表的最新刻度) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class MachineWatchScale : MachineWatchScaleBase
	{
		public MachineWatchScale()
		{
		}
	}
}