using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;

/// <summary>
/// ��    ��: EditProductionPaperAmountModel
/// ���ܸ�Ҫ: δ�궩����ֽ���
/// ��    ��: ����ط
/// ����ʱ��: 2009.4.23
/// </summary>
namespace Workflow.Action.LogCounters
{
	public class EditProductionPaperAmountModel
	{
		#region δ�깤������ֽ���id
		
		private long uncompleteOrdersUsedPaperId;
		/// <summary>
		/// δ�깤������ֽ���id
		/// </summary>
		public long UncompleteOrdersUsedPaperId
		{
			get { return uncompleteOrdersUsedPaperId; }
			set { uncompleteOrdersUsedPaperId = value; }
		}

		#endregion

		#region �����б�

		private IList<Order> orderList;
		/// <summary>
		/// �����б�
		/// </summary>
		public IList<Order> OrderList
		{
			get { return orderList; }
			set { orderList = value; }
		}

		#endregion

		#region ��Ҫ����Ļ��������б�

		private IList<MachineType> machineTypeList;
		/// <summary>
		/// ��Ҫ����Ļ����б�
		/// </summary>
		public IList<MachineType> MachineTypeList
		{
			get { return machineTypeList; }
			set { machineTypeList = value; }
		}

		#endregion

		#region ֽ���б�

		private IList<PaperSpecification> paperSpecificationList;
		/// <summary>
		/// ֽ���б�
		/// </summary>
		public IList<PaperSpecification> PaperSpecificationList
		{
			get { return paperSpecificationList; }
			set { paperSpecificationList = value; }
		}

		#endregion

		#region ��ǰ����id
		
		private long recordMachineWatchId;
		/// <summary>
		/// δ��ɶ���id
		/// </summary>
		public long RecordMachineWatchId
		{
			get { return recordMachineWatchId; }
			set { recordMachineWatchId = value; }
		}

		#endregion

		#region ��ǰ����������

		private string actionStr;
		/// <summary>
		/// ��ǰ����������
		/// </summary>
		public string ActionStr
		{
			get { return actionStr; }
			set { actionStr = value; }
		}

		#endregion

		#region ����id

		private long orderId;
		/// <summary>
		/// ����id
		/// </summary>
		public long OrderId
		{
			get { return orderId; }
			set { orderId = value; }
		}

		#endregion

		#region ��������id

		private long machineTypeId;
		/// <summary>
		/// ����id
		/// </summary>
		public long MachineTypeId
		{
			get { return machineTypeId; }
			set { machineTypeId = value; }
		}

		#endregion

		#region ֽ��id

		private long paperShapeId;
		/// <summary>
		/// ֽ��id
		/// </summary>
		public long PaperShapeId
		{
			get { return paperShapeId; }
			set { paperShapeId = value; }
		}

		#endregion

		#region ֽɫid

		private string paperColorType;
		/// <summary>
		/// ֽɫid
		/// </summary>
		public string PaperColorType
		{
			get { return paperColorType; }
			set { paperColorType = value; }
		}

		#endregion

		#region δ��ɶ�����ֽ����

		private int number;
		/// <summary>
		/// δ��ɶ�����ֽ����
		/// </summary>
		public int Number
		{
			get { return number; }
			set { number = value; }
		}


		#endregion
	}
}
