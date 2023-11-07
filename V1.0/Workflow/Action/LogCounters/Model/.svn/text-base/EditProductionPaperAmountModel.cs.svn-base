using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;

/// <summary>
/// 名    称: EditProductionPaperAmountModel
/// 功能概要: 未完工单用纸情况
/// 作    者: 陈汝胤
/// 创建时间: 2009.4.23
/// </summary>
namespace Workflow.Action.LogCounters
{
	public class EditProductionPaperAmountModel
	{
		#region 未完工工单用纸情况id
		
		private long uncompleteOrdersUsedPaperId;
		/// <summary>
		/// 未完工工单用纸情况id
		/// </summary>
		public long UncompleteOrdersUsedPaperId
		{
			get { return uncompleteOrdersUsedPaperId; }
			set { uncompleteOrdersUsedPaperId = value; }
		}

		#endregion

		#region 订单列表

		private IList<Order> orderList;
		/// <summary>
		/// 订单列表
		/// </summary>
		public IList<Order> OrderList
		{
			get { return orderList; }
			set { orderList = value; }
		}

		#endregion

		#region 需要抄表的机器列表

		private IList<Machine> machineList;
		/// <summary>
		/// 需要抄表的机器列表
		/// </summary>
		public IList<Machine> MachineList
		{
			get { return machineList; }
			set { machineList = value; }
		}

		#endregion

		#region 纸型列表

		private IList<PaperSpecification> paperSpecificationList;
		/// <summary>
		/// 纸型列表
		/// </summary>
		public IList<PaperSpecification> PaperSpecificationList
		{
			get { return paperSpecificationList; }
			set { paperSpecificationList = value; }
		}

		#endregion

		#region 当前抄表id
		
		private long recordMachineWatchId;
		/// <summary>
		/// 未完成工单id
		/// </summary>
		public long RecordMachineWatchId
		{
			get { return recordMachineWatchId; }
			set { recordMachineWatchId = value; }
		}

		#endregion

		#region 当前动作的描述

		private string actionStr;
		/// <summary>
		/// 当前动作的描述
		/// </summary>
		public string ActionStr
		{
			get { return actionStr; }
			set { actionStr = value; }
		}

		#endregion

		#region 工单id

		private long orderId;
		/// <summary>
		/// 工单id
		/// </summary>
		public long OrderId
		{
			get { return orderId; }
			set { orderId = value; }
		}

		#endregion

		#region 机器id

		private long machineId;
		/// <summary>
		/// 机器id
		/// </summary>
		public long MachineId
		{
			get { return machineId; }
			set { machineId = value; }
		}

		#endregion

		#region 纸型id

		private long paperShapeId;
		/// <summary>
		/// 纸型id
		/// </summary>
		public long PaperShapeId
		{
			get { return paperShapeId; }
			set { paperShapeId = value; }
		}

		#endregion

		#region 纸色id

		private string paperColorType;
		/// <summary>
		/// 纸色id
		/// </summary>
		public string PaperColorType
		{
			get { return paperColorType; }
			set { paperColorType = value; }
		}

		#endregion

		#region 未完成工单用纸数量

		private int number;
		/// <summary>
		/// 未完成工单用纸数量
		/// </summary>
		public int Number
		{
			get { return number; }
			set { number = value; }
		}


		#endregion
	}
}
