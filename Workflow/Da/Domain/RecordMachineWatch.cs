using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table RECORD_MACHINE_WATCH对应的DotNet Object
	/// </summary>
	[Serializable]
	public class RecordMachineWatch : RecordMachineWatchBase
	{
		public RecordMachineWatch()
		{
		}

		#region 插入用户名
		private string insertUserName;
		/// <summary>
		/// 获取所有的抄表记录
		/// </summary>
		public string InsertUserName
		{
			get { return insertUserName; }
			set { insertUserName = value; }
		}
		#endregion

		
	
	}
}
