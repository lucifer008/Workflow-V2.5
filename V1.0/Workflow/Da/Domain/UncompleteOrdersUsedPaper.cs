using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table UNCOMPLETE_ORDERS_USED_PAPER��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class UncompleteOrdersUsedPaper : UncompleteOrdersUsedPaperBase
	{
        private long lastRecordMachineWatchId;
        /// <summary>
        /// �ϴγ���_ID
        /// </summary>
        public long LastRecordMachineWatchId
        {
            get { return this.lastRecordMachineWatchId;     }
            set { this.lastRecordMachineWatchId = value;    }
        }

        private int lastTimeUsedPaperCount;
        /// <summary>
        /// �ϴ���ֽ��
        /// </summary>
        public int LastTimeUsedPaperCount
        {
            get { return this.lastTimeUsedPaperCount; }
            set { this.lastTimeUsedPaperCount = value; }
		}

		#region ��������

		private string machineName;
		/// <summary>
		/// �������� 
		/// </summary>
		/// <remarks>Add:Cry,Date:2009.4.24</remarks>
		public string MachineName
		{
			get { return machineName; }
			set { machineName = value; }
		}

		#endregion

		#region ֽ������

		private string paperName;
		/// <summary>
		/// ֽ������
		/// </summary>
		/// <remarks>Add:Cry,Date:2009.4.24</remarks>
		public string PaperName
		{
			get { return paperName; }
			set { paperName = value; }
		}

		#endregion

		#region �������

		private string orderNo;
		/// <summary>
		/// �������
		/// </summary>
		/// <remarks>Add:Cry,Date:2009.4.24</remarks>
		public string OrderNo
		{
			get { return orderNo; }
			set { orderNo = value; }
		}

		#endregion
	}
}
