using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Service.LogCounterManage;
using Workflow.Util;
using Workflow.Support;
using System.Collections;

/// <summary>
/// 名    称: CheckCounterAction
/// 功能概要: 对抄表记录的核实
/// 作    者: 陈汝胤
/// 创建时间: 2009.4.29
/// </summary>
namespace Workflow.Action.LogCounters
{
	public class CheckCounterAction
	{
		#region model
		private CheckCounterModel model = new CheckCounterModel();
		/// <summary>
		/// ChckCounterModel
		/// </summary>
		public CheckCounterModel Model
		{
			get { return model; }
		}
		#endregion

		#region 注入 logCountersService

		private ILogCountersService logCountersService;
		/// <summary>
		/// 注入 logCountersService
		/// </summary>
		public ILogCountersService LogCountersService
		{
			set { logCountersService = value; }
		}

		#endregion

		#region 获取核实的记录

		/// <summary>
		/// 获取核实的记录
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.30
		/// </remarks>
		public void GetVerifyData()
		{
			model.ConversionList = logCountersService.GetAllMachineWatchConversionPaper();
			IList<MachineWatchRecordLog> machineWatchRecordList=null;
			IList<MachineWatchRecordLog> lastMachineWatchrecordList = null;
			RecordMachineWatch lastRecordMachineWatch=null;
			long currentMachineId=0;
			bool isReadMap = model.MakeMap.Count > 0 ? true : false;
			model.IsAllowVerify = true;
			foreach (MachineWatchConversionPaper conversion in model.ConversionList)
			{
				if (conversion.MachineId != currentMachineId)
				{
					machineWatchRecordList = logCountersService.GetNeedVerifyRecordLog(model.RecordMachineWatchId, conversion.MachineId);
					lastRecordMachineWatch=logCountersService.GetLastRecordMachineWatch();
					lastMachineWatchrecordList = logCountersService.GetNeedVerifyRecordLog(lastRecordMachineWatch.Id, conversion.MachineId);
				}
				currentMachineId = conversion.MachineId;
				
				conversion.CashCount = 0;
				conversion.LastCount = AccountMachineOnWatch(lastMachineWatchrecordList, conversion.ComputeFormula);
				conversion.NewCount = AccountMachineOnWatch(machineWatchRecordList,conversion.ComputeFormula);
				Hashtable map = new Hashtable();
				long machineTypeId = logCountersService.GetMachineTypeIdByMachineId(conversion.MachineId);
				map.Add("machineid", machineTypeId);
				map.Add("paperid", conversion.PaperId);
				map.Add("color", conversion.ColorType);
				map.Add("recordmachinewatchid", lastRecordMachineWatch.Id);
				map.Add("orderstatus", Constants.ORDER_STATUS_SUCCESSED_VALUE);
				if (isReadMap)
				{
					conversion.OrderUsePaperCount = (int)model.MakeMap[conversion.Id];
				}
				else
				{
					conversion.OrderUsePaperCount = logCountersService.GetVerifyRecordWatchCompleteOrderUsedCount(map);
					model.MakeMap.Add(conversion.Id, conversion.OrderUsePaperCount);
				}
				conversion.PatchCount = logCountersService.GetCompensateUsedPaperCount(model.RecordMachineWatchId,conversion.MachineId, conversion.PaperId, conversion.ColorType);
				conversion.PaperColor = Constants.GetColorType(conversion.ColorType);

				int result = conversion.NewCount - conversion.LastCount - conversion.PatchCount - conversion.OrderUsePaperCount;
				if (result != 0) model.IsAllowVerify = false;
				conversion.Result = result == 0 ? "不差" : string.Format("差{0}张", result);
			}
			model.CompensateUsedPaperList = logCountersService.GetCompensateUsedPaperList();
		}

		#endregion

		#region 机器上的表换算

		/// <summary>
		/// 机器上的表换算
		/// </summary>
		/// <param name="machineWatchRecordList">机器上的表的记录情况</param>
		/// <param name="conversion">计数器换算公式</param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.30
		/// </remarks>
		private int AccountMachineOnWatch(IList<MachineWatchRecordLog> machineWatchRecordList,string computeFormula)
		{
			object[] objArr = new object[machineWatchRecordList.Count];
			foreach (MachineWatchRecordLog machineWatchRecordLog in machineWatchRecordList)
			{
				objArr[machineWatchRecordLog.WatchType - 1] = machineWatchRecordLog.NewNumber;
			}
			return Convert.ToInt32(NumericUtils.Eval(string.Format(computeFormula, objArr)));
		}

		#endregion

		#region 删除指定id的补单

		/// <summary>
		/// 删除指定id的补单
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.6
		/// </remarks>
		public void DeleteCompensateUsedPaper()
		{
			logCountersService.DeleteCompensateUsedPaper(model.CompensateUsedPaperId);
		}

		#endregion

		#region 完成核实抄表

		/// <summary>
		/// 完成核实抄表
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.6
		/// </remarks>
		public void CompleteVerify()
		{
			if (null == model.ConversionList || model.RecordMachineWatchId==0)
				throw new Exception("数据异常");
			logCountersService.DailyRecordMachine(model.ConversionList,model.RecordMachineWatchId);
		}

		#endregion
	}
}
