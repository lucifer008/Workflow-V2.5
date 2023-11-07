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
			//补单列表
			model.CompensateUsedPaperList = logCountersService.GetCompensateUsedPaperByRecordWatchId(model.RecordMachineWatchId);

			model.MachineTypeList = logCountersService.GetNeedRecordWarchMachineAndMachineWatch();

			model.ConversionList = logCountersService.GetAllMachineWatchConversionPaper();
			RecordMachineWatch lastRecordWath= logCountersService.GetLastRecordMachineWatch();

			bool isReadMap = model.MakeMap.Count > 0 ? true : false;

			IList<MachineWatchRecordLog> machineWatchRecordLogList = null;
			Hashtable map = new Hashtable();
			foreach (MachineType machineType in model.MachineTypeList)
			{
				foreach (MachineWatchConversionPaper conversion in model.ConversionList)
				{
					if (machineType.Id == conversion.MachineTypeId)
					{
						machineWatchRecordLogList = logCountersService.GetNeedVerifyRecordLog(model.RecordMachineWatchId, conversion.MachineTypeId);
						conversion.LastCount = AccountMachineOnWatch(machineWatchRecordLogList, conversion.ComputeFormula, false);
						conversion.NewCount = AccountMachineOnWatch(machineWatchRecordLogList, conversion.ComputeFormula, true);
						conversion.PaperColor = Constants.GetColorType(conversion.ColorType);

						this.ProcessPaperSpecificationId(conversion);

						if (isReadMap)
						{
							conversion.OrderUsePaperCount = (int)model.MakeMap[conversion.Id];
						}
						else
						{
							map.Clear();

							map.Add("machineId", conversion.MachineTypeId);
							map.Add("paperSpcId", conversion.PaperId);
							map.Add("paperSpcId2", conversion.PaperSpcId2);
							map.Add("paperSpcId3", conversion.PaperSpcId3);
							map.Add("paperColor", conversion.ColorType);
							long lastRecordWatchId = lastRecordWath == null ? 0 : lastRecordWath.Id;
							map.Add("logCounterId", lastRecordWatchId);
							map.Add("recordWatchId", model.RecordMachineWatchId);
							map.Add("orderStatus", Constants.ORDER_STATUS_SUCCESSED_VALUE);
							conversion.OrderUsePaperCount = logCountersService.GetVerifyRecordWatchCompleteOrderUsedCount(map);
							model.MakeMap.Add(conversion.Id, conversion.OrderUsePaperCount);
						}
						conversion.PatchCount = logCountersService.GetCompensateUsedPaperCount(model.RecordMachineWatchId, conversion.MachineTypeId, conversion.PaperId, conversion.PaperSpcId2, conversion.ColorType, conversion.PaperSpcId3);
						conversion.Result = conversion.NewCount - conversion.LastCount == conversion.OrderUsePaperCount + conversion.PatchCount ? true : false;
						conversion.ResultValue = conversion.NewCount - conversion.LastCount - conversion.OrderUsePaperCount - conversion.PatchCount;
						conversion.NeedRecordWatch = true;
					}
				}
			}
			model.IsAllowVerify = true;

		}

		#endregion

		#region 机器上的表换算

		/// <summary>
		/// 机器上的表换算
		/// </summary>
		/// <param name="machineWatchRecordList">机器上的表的记录情况</param>
		/// <param name="conversion">计数器换算公式</param>
		/// <param name="isNewNumber">是否为最新计数值</param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.30
		/// </remarks>
		private int AccountMachineOnWatch(IList<MachineWatchRecordLog> machineWatchRecordList, string computeFormula, bool isNewNumber)
		{
			object[] objArr = new object[machineWatchRecordList.Count];
			for (int i = 0; i < machineWatchRecordList.Count; i++)
			{
				int number = isNewNumber ? machineWatchRecordList[i].NewNumber : machineWatchRecordList[i].LastNumber;
				objArr[i] = number;
			}
			return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(NumericUtils.Eval(string.Format(computeFormula, objArr)))));
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

		/// <summary>
		/// 名    称: ProcessPaperSpecificationId
		/// 功能概要: 通过纸型名称获取纸型Id
		/// 作    者: 
		/// 创建时间: 
		/// 修 正 人: 白晓宇
		/// 修正时间: 2010-05-07 
		/// 描    述: 
		/// </summary>
		/// <param name="domain">计数器换算纸张</param>
		private void ProcessPaperSpecificationId(MachineWatchConversionPaper domain)
		{
			if (null != domain) 
			{
				string[] names = domain.PaperName.Split(new char[] { '/'});
				if (names.Length == 3)
				{
					domain.PaperId = logCountersService.GetPaperSpecificationIdByName(names[0]);
					domain.PaperSpcId2 = logCountersService.GetPaperSpecificationIdByName(names[1]);
					domain.PaperSpcId3 = logCountersService.GetPaperSpecificationIdByName(names[2]);
				}
				else if (names.Length == 2)
				{
					domain.PaperId = logCountersService.GetPaperSpecificationIdByName(names[0]);
					domain.PaperSpcId2 = logCountersService.GetPaperSpecificationIdByName(names[1]);
				}
				else 
				{
					
				}
			}
		}

		
	}
}
