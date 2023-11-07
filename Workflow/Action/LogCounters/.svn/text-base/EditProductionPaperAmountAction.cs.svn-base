using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Service.OrderManage;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Service.LogCounterManage;
using System.Collections;

/// <summary>
/// 名    称: EditProductionPaperAmountAction
/// 功能概要: 未完订单用纸情况
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
			Hashtable map = new Hashtable();
			map.Add("status1", Constants.ORDER_STATUS_FACTURING_VALUE);
			map.Add("status2", Constants.ORDER_STATUS_FINISHED_VALUE);
			map.Add("status3", Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE);
			model.OrderList = searchOrderService.GetOrderListByStatus(map);

			model.MachineTypeList = logCountersService.GetNeedRecordWarchMachineAndMachineWatch();
			//纸型
			model.PaperSpecificationList = logCountersService.GetPaperSpecification();
			//颜色
			//model.PaperColor = new string[] { "黑白", "彩色" };
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

		#region 添加未完工订单用纸情况
		
		/// <summary>
		/// 添加未完工订单用纸情况
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
			uncompleteOrderUsedPaper.PaperSpecificationId = model.PaperShapeId;
			uncompleteOrderUsedPaper.MachineTypeId = model.MachineTypeId;
			uncompleteOrderUsedPaper.OrdersId = model.OrderId;
			uncompleteOrderUsedPaper.UsedPaperCount = model.Number;
			uncompleteOrderUsedPaper.ColorType = model.PaperColorType;
			logCountersService.AddUncompleteOrderUsedPaper(uncompleteOrderUsedPaper);
			model.RecordMachineWatchId = recordMachineWatch.Id;
		}

		#endregion

		#region 更新未完成订单用纸情况

		/// <summary>
		/// 更新未完成订单用纸情况
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.5
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
