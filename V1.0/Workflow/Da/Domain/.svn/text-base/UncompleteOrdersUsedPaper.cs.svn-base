using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table UNCOMPLETE_ORDERS_USED_PAPER对应的DotNet Object
	/// </summary>
	[Serializable]
	public class UncompleteOrdersUsedPaper : UncompleteOrdersUsedPaperBase
	{
        private long lastRecordMachineWatchId;
        /// <summary>
        /// 上次抄表_ID
        /// </summary>
        public long LastRecordMachineWatchId
        {
            get { return this.lastRecordMachineWatchId;     }
            set { this.lastRecordMachineWatchId = value;    }
        }

        private int lastTimeUsedPaperCount;
        /// <summary>
        /// 上次用纸量
        /// </summary>
        public int LastTimeUsedPaperCount
        {
            get { return this.lastTimeUsedPaperCount; }
            set { this.lastTimeUsedPaperCount = value; }
		}

		#region 机器名称

		private string machineName;
		/// <summary>
		/// 机器名称 
		/// </summary>
		/// <remarks>Add:Cry,Date:2009.4.24</remarks>
		public string MachineName
		{
			get { return machineName; }
			set { machineName = value; }
		}

		#endregion

		#region 纸型名称

		private string paperName;
		/// <summary>
		/// 纸型名称
		/// </summary>
		/// <remarks>Add:Cry,Date:2009.4.24</remarks>
		public string PaperName
		{
			get { return paperName; }
			set { paperName = value; }
		}

		#endregion

		#region 工单编号

		private string orderNo;
		/// <summary>
		/// 工单编号
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
