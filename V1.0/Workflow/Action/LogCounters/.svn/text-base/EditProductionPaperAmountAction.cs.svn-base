using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Service.OrderManage;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Service.LogCounterManage;

/// <summary>
/// 名    称: EditProductionPaperAmountAction
/// 功能概要: 未完工单用纸情况
/// 作    者: 陈汝胤
/// 创建时间: 2009-2-12
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

		#region 注入 orderService

		private ISearchOrderService searchOrderService;
		/// <summary>
		/// 注入 orderService
		/// </summary>
		public ISearchOrderService SearchOrderService
		{
			set { searchOrderService = value; }
		}

		#endregion

		#region 注入 logCounterService

		private ILogCountersService logCountersService;
		/// <summary>
		/// 注入 logCounterService
		/// </summary>
		public ILogCountersService LogCountersService
		{
			set { logCountersService = value; }
		}

		#endregion

		#region 初始化页面

		/// <summary>
		/// 初始化页面
		/// </summary>
		public void InitEditProductionPaperAmount()
		{
			model.OrderList = searchOrderService.GetOrderListByStatus(Constants.ORDER_STATUS_FACTURING_VALUE);
		
			model.MachineList= logCountersService.GetNeedRecordWarchMachine();
			//纸型
			model.PaperSpecificationList = logCountersService.GetPaperSpecification();
			//颜色
			//model.PaperColor = new string[] { "黑白", "彩色" };
			if (model.UncompleteOrdersUsedPaperId != 0)
			{
				UncompleteOrdersUsedPaper uncompleteOrderUsedPaper = logCountersService.GetUncompeleteOrderUsePaperById(model.UncompleteOrdersUsedPaperId);
				model.PaperShapeId = uncompleteOrderUsedPaper.PaperSpecification.Id;
				model.MachineId = uncompleteOrderUsedPaper.Machine.Id;
				model.OrderId = uncompleteOrderUsedPaper.OrdersId;
				model.Number = uncompleteOrderUsedPaper.UsedPaperCount;
				model.PaperColorType = uncompleteOrderUsedPaper.ColorType;
			}
		}

		#endregion

		#region 添加未完工工单用纸情况
		
		/// <summary>
		/// 添加未完工工单用纸情况
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.5
		/// </remarks>
		public void AddUncompeteOrdersUsedPaper()
		{

			RecordMachineWatch recordMachineWatch = logCountersService.GetCanUsedRecordMachineWatch();
			
			UncompleteOrdersUsedPaper uncompleteOrderUsedPaper = new UncompleteOrdersUsedPaper();
			uncompleteOrderUsedPaper.RecordMachineWatchId = recordMachineWatch.Id;
			uncompleteOrderUsedPaper.PaperSpecification = new PaperSpecification();
			uncompleteOrderUsedPaper.PaperSpecification.Id = model.PaperShapeId;
			uncompleteOrderUsedPaper.Machine = new Machine();
			uncompleteOrderUsedPaper.Machine.Id = model.MachineId;
			uncompleteOrderUsedPaper.OrdersId = model.OrderId;
			uncompleteOrderUsedPaper.UsedPaperCount = model.Number;
			uncompleteOrderUsedPaper.ColorType = model.PaperColorType;
			logCountersService.AddUncompleteOrderUsedPaper(uncompleteOrderUsedPaper);
			model.RecordMachineWatchId = recordMachineWatch.Id;
		}

		#endregion

		#region 更新未完成工单用纸情况

		/// <summary>
		/// 更新未完成工单用纸情况
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.5
		/// </remarks>
		public void UpdateUncompeteOrdersUsedPaper()
		{
			UncompleteOrdersUsedPaper uncompleteOrderUsedPaper=logCountersService.GetUncompeleteOrderUsePaperById(model.UncompleteOrdersUsedPaperId);
			uncompleteOrderUsedPaper.PaperSpecification.Id = model.PaperShapeId;
			uncompleteOrderUsedPaper.Machine.Id = model.MachineId;
			uncompleteOrderUsedPaper.OrdersId = model.OrderId;
			uncompleteOrderUsedPaper.UsedPaperCount = model.Number;
			uncompleteOrderUsedPaper.ColorType = model.PaperColorType;
			logCountersService.UpdateUncompleteOrdersUsedPaper(uncompleteOrderUsedPaper);
			model.RecordMachineWatchId = uncompleteOrderUsedPaper.RecordMachineWatchId;
		}

		#endregion
	}
}
