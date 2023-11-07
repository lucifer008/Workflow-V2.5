#region imports
using System;
using Workflow.Da.Domain.Base;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table UNCOMPLETE_ORDERS_USED_PAPER (未完工订单用纸情况) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class UncompleteOrdersUsedPaper : UncompleteOrdersUsedPaperBase
	{
		public UncompleteOrdersUsedPaper()
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

		#region 纸型名称

		private string paperName;
		/// <summary>
		/// 纸型名称
		/// </summary>
		public string PaperName
		{
			get { return paperName; }
			set { paperName = value; }
		}


		#endregion

		#region 订单No

		private string orderNo;
		/// <summary>
		/// 订单No
		/// </summary>
		public string OrderNo
		{
			get { return orderNo; }
			set { orderNo = value; }
		}


		#endregion

	}
}