using System;
using System.Text;
using Workflow.Da.Domain;
using System.Collections.Generic;
using Workflow.Service.OrderManage;
using Workflow.Service.LogCounterManage;
using Workflow.Service.SystemPermission.UserMangae;

/// <summary>
/// 名    称: CopyCounter
/// 功能概要: 抄表处理Action
/// 作    者: 陈汝胤
/// 创建时间: 2009-2-10
/// </summary>
namespace Workflow.Action.LogCounters
{
	public class CopyCounterAction
	{
		#region model
		private CopyCounterModel model = new CopyCounterModel();
		public CopyCounterModel Model
		{
			get { return model; }
		}
		#endregion

		#region 注入

		#region logCountersService

		private ILogCountersService logCountersService;
		/// <summary>
		/// 注入logCountersService
		/// </summary>
		public ILogCountersService LogCountersService
		{
			set { logCountersService = value; }
		}

		#endregion
		//GetCashOrderItemFactorValueByOrderId
		#region orderService

		private IOrderService orderService;
		/// <summary>
		/// orderService
		/// </summary>
		public IOrderService OrderService
		{
			set { orderService = value; }
		}
		
		#endregion

		#region userService

		private IUserService userService;
		/// <summary>
		/// userService
		/// </summary>
		public IUserService UserService
		{
			get { return userService; }
			set { userService = value; }
		}

		#endregion

		#endregion

		#region
		/// <summary>
		/// 加载抄表页面的基本信息
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-2-10
		/// </remarks>
		public void InitCopyCounter()
		{
			//获取当店面机器和机器上次抄表的值
			model.MachineTypeList = logCountersService.GetNeedRecordWarchMachineAndMachineWatch();

			model.UserList = userService.GetDifferEmployeeAllUser();

			if (!string.IsNullOrEmpty(model.UncompleteOrderId))
			{
				logCountersService.DeleteUnCompensateUsedPaper(long.Parse(model.UncompleteOrderId));
			}

			if (!string.IsNullOrEmpty(model.RecordMachineWatchId))
			{
				model.UncompleteOrderList = logCountersService.GetUncompleteOrderByRecordWatchId(long.Parse(model.RecordMachineWatchId));
			}
		}

		#endregion

		#region 清理未完成核实的抄表数据

		/// <summary>
		/// 清理未完成核实的抄表数据
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.24
		/// </remarks>
		public void CleanUpUncompleteRecordWatchData()
		{
			logCountersService.CleanUpUncompleteRecordWatchData();
		}

		#endregion

		#region 保存等待核实的抄表数据

		/// <summary>
		/// 保存等待核实的抄表数据
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.28
		/// </remarks>
		public void SaveVerifyRecordWatchData()
		{
			RecordMachineWatch recordMachineWatch = logCountersService.GetCanUsedRecordMachineWatch();

			RecordMachineWatch lastRecordMachineWatch = logCountersService.GetLastRecordMachineWatch();
			foreach (MachineType machineType in model.MachineTypeList)
			{
				foreach (MachineWatch machineWatch in machineType.MachineWatchList)
				{
					int lastNumber = 0;
					
					if (lastRecordMachineWatch != null) //非第一次超表
					{
						lastNumber=logCountersService.GetLastMachineWatchNumber(lastRecordMachineWatch.Id, machineWatch.Id);
						//if (0 == lastNumber)
						//{
						//	throw new ArgumentException("上次抄表记录数据不全");
						//}
					}
					
					MachineWatchRecordLog machineWatchRecordLog = new MachineWatchRecordLog();
					machineWatchRecordLog.MachineTypeId = machineWatch.MachineTypeId;
					machineWatchRecordLog.MachineWatchId = machineWatch.Id;
					machineWatchRecordLog.RecordMachineWatchId = recordMachineWatch.Id;
					machineWatchRecordLog.LastNumber = lastNumber;
					machineWatchRecordLog.NewNumber = machineWatch.Number;
					machineWatchRecordLog.Memo = "";
					logCountersService.SaveVerifyRecordWatchData(machineWatchRecordLog);
				}
			}
			if (lastRecordMachineWatch == null)
			{
				logCountersService.UpdateCanUsedRecordMachineWatch();
				model.RecordMachineWatchId = "0";
			}
			else
			{
				model.RecordMachineWatchId = recordMachineWatch.Id.ToString();
			}
		}

		#endregion
	}
}
