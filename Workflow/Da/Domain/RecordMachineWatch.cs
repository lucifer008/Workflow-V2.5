using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table RECORD_MACHINE_WATCH��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class RecordMachineWatch : RecordMachineWatchBase
	{
		public RecordMachineWatch()
		{
		}

		#region �����û���
		private string insertUserName;
		/// <summary>
		/// ��ȡ���еĳ����¼
		/// </summary>
		public string InsertUserName
		{
			get { return insertUserName; }
			set { insertUserName = value; }
		}
		#endregion

		
	
	}
}
