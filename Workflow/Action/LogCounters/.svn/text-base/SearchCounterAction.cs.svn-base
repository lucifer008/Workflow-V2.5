using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Service.LogCounterManage;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Service.SystemPermission.UserMangae;
/// <summary>
/// 名    称：SearchCounterAction
/// 功能概要: 计数器查询Action
/// 作    者: 陈汝胤
/// 创建时间: 2009.12.23
/// </summary>
namespace Workflow.Action.LogCounters
{
	public class SearchCounterAction
	{
		#region inject

		#region logCountersService

		private ILogCountersService logCountersService;
		/// <summary>
		/// logCountersService
		/// </summary>
		public ILogCountersService LogCountersService
		{
			set { logCountersService = value; }
		}

		private IUserService userService;
		/// <summary>
		/// userService
		/// </summary>
		public IUserService UserService
		{
			set { userService = value; }
		}
	

		#endregion

		#endregion

		private SearchCounterModel model = new SearchCounterModel();
		public SearchCounterModel Model
		{
			get { return model; }
		}

		#region 抄表记录Init

		/// <summary>
		/// 抄表记录Init
		/// </summary>
		public void Init()
		{
			if (string.IsNullOrEmpty(model.EndDate.Trim()))
				model.EndDate = model.BeginDate;
			model.RecordCount = logCountersService.GetRecordMachineWatchCount(model.BeginDate, model.EndDate);
			
			model.RecordMachineWatchs=logCountersService.GetRecordMachineWatch(model.BeginRow, model.EndRow, model.BeginDate, model.EndDate);
		}

		#endregion

		#region 获取抄表结果

		/// <summary>
		/// 获取抄表结果
		/// </summary>
		public void GetRecordMachineWatchResult()
		{
			model.DailyRecordMachines = logCountersService.GetRecordMachineWatchResult(model.RecordMachineWatchId);
			foreach (DailyRecordMachine val in model.DailyRecordMachines)
			{
				if (model.Map[val.MachineTypeId] == null)
				{
					DataUnite unite = new DataUnite();
					unite.UniteCount = 1;
					unite.Amount = val.InWatchCount;
					model.Map.Add(val.MachineTypeId, unite);
				}
				else
				{
					DataUnite unite = (DataUnite)model.Map[val.MachineTypeId];
					unite.UniteCount++;
					unite.Amount += val.InWatchCount;
				}
			}
		}

		#endregion

	}
}
