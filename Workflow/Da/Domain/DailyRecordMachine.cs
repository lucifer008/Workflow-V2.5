#region imports
using System;
using Workflow.Da.Domain.Base;
using Workflow.Support;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table DAILY_RECORD_MACHINE (每次抄表基本信息记录) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class DailyRecordMachine : DailyRecordMachineBase
	{
		public DailyRecordMachine()
		{
		}

		#region 机器类型名称

		private string machineTypeName;
		/// <summary>
		/// 机器类型名称
		/// </summary>
		public string MachineTypeName
		{
			get { return machineTypeName; }
			set { machineTypeName = value; }
		}

		#endregion

		#region 机器纸型名称

		private string paperSpecificationName;
		/// <summary>
		/// 机器纸型名称
		/// </summary>
		public string PaperSpecificationName
		{
			get
			{
				if (ColorType == Constants.COLOR_BLACKWHITE)
					paperSpecificationName = "A3/A4";
				return paperSpecificationName;	
			}
			set { paperSpecificationName = value; }
		}

		#endregion
	}
}