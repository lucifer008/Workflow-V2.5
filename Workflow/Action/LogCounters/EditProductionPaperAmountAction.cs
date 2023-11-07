using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Service.OrderManage;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Service.LogCounterManage;
using System.Collections;

/// <summary>
/// ��    ��: EditProductionPaperAmountAction
/// ���ܸ�Ҫ: δ�궩����ֽ���
/// ��    ��: ����ط
/// ����ʱ��: 2009-2-12
/// </summary>
namespace Workflow.Action.LogCounters
{
	public class EditProductionPaperAmountAction
	{
		#region model

		private EditProductionPaperAmountModel model = new EditProductionPaperAmountModel();
		public EditProductionPaperAmountModel Model
		{
			get { return model; }
		}

		#endregion

		#region ע�� orderService

		private ISearchOrderService searchOrderService;
		/// <summary>
		/// ע�� orderService
		/// </summary>
		public ISearchOrderService SearchOrderService
		{
			set { searchOrderService = value; }
		}

		#endregion

		#region ע�� logCounterService

		private ILogCountersService logCountersService;
		/// <summary>
		/// ע�� logCounterService
		/// </summary>
		public ILogCountersService LogCountersService
		{
			set { logCountersService = value; }
		}

		#endregion

		#region ��ʼ��ҳ��

		/// <summary>
		/// ��ʼ��ҳ��
		/// </summary>
		public void InitEditProductionPaperAmount()
		{
			Hashtable map = new Hashtable();
			map.Add("status1", Constants.ORDER_STATUS_FACTURING_VALUE);
			map.Add("status2", Constants.ORDER_STATUS_FINISHED_VALUE);
			map.Add("status3", Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE);
			model.OrderList = searchOrderService.GetOrderListByStatus(map);

			model.MachineTypeList = logCountersService.GetNeedRecordWarchMachineAndMachineWatch();
			//ֽ��
			model.PaperSpecificationList = logCountersService.GetPaperSpecification();
			//��ɫ
			//model.PaperColor = new string[] { "�ڰ�", "��ɫ" };
			if (model.UncompleteOrdersUsedPaperId != 0)
			{
				UncompleteOrdersUsedPaper uncompleteOrderUsedPaper = logCountersService.GetUncompeleteOrderUsePaperById(model.UncompleteOrdersUsedPaperId);
				model.PaperShapeId = uncompleteOrderUsedPaper.PaperSpecificationId;
				model.MachineTypeId = uncompleteOrderUsedPaper.MachineTypeId;
				model.OrderId = uncompleteOrderUsedPaper.OrdersId;
				model.Number = uncompleteOrderUsedPaper.UsedPaperCount;
				model.PaperColorType = uncompleteOrderUsedPaper.ColorType;
			}
		}

		#endregion

		#region ���δ�깤������ֽ���
		
		/// <summary>
		/// ���δ�깤������ֽ���
		/// </summary>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.5
		/// </remarks>
		public void AddUncompeteOrdersUsedPaper()
		{

			RecordMachineWatch recordMachineWatch = logCountersService.GetCanUsedRecordMachineWatch();
			
			UncompleteOrdersUsedPaper uncompleteOrderUsedPaper = new UncompleteOrdersUsedPaper();
			uncompleteOrderUsedPaper.RecordMachineWatchId = recordMachineWatch.Id;
			uncompleteOrderUsedPaper.PaperSpecificationId = model.PaperShapeId;
			uncompleteOrderUsedPaper.MachineTypeId = model.MachineTypeId;
			uncompleteOrderUsedPaper.OrdersId = model.OrderId;
			uncompleteOrderUsedPaper.UsedPaperCount = model.Number;
			uncompleteOrderUsedPaper.ColorType = model.PaperColorType;
			logCountersService.AddUncompleteOrderUsedPaper(uncompleteOrderUsedPaper);
			model.RecordMachineWatchId = recordMachineWatch.Id;
		}

		#endregion

		#region ����δ��ɶ�����ֽ���

		/// <summary>
		/// ����δ��ɶ�����ֽ���
		/// </summary>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.5
		/// </remarks>
		public void UpdateUncompeteOrdersUsedPaper()
		{
			UncompleteOrdersUsedPaper uncompleteOrderUsedPaper=logCountersService.GetUncompeleteOrderUsePaperById(model.UncompleteOrdersUsedPaperId);
			uncompleteOrderUsedPaper.PaperSpecificationId = model.PaperShapeId;
			uncompleteOrderUsedPaper.MachineTypeId= model.MachineTypeId;
			uncompleteOrderUsedPaper.OrdersId = model.OrderId;
			uncompleteOrderUsedPaper.UsedPaperCount = model.Number;
			uncompleteOrderUsedPaper.ColorType = model.PaperColorType;
			logCountersService.UpdateUncompleteOrdersUsedPaper(uncompleteOrderUsedPaper);
			model.RecordMachineWatchId = uncompleteOrderUsedPaper.RecordMachineWatchId;
		}

		#endregion
	}
}
