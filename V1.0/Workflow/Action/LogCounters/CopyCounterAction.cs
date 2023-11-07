using System;
using System.Text;
using Workflow.Da.Domain;
using System.Collections.Generic;
using Workflow.Service.OrderManage;
using Workflow.Service.LogCounterManage;
using Workflow.Service.SystemPermission.UserMangae;

/// <summary>
/// ��    ��: CopyCounter
/// ���ܸ�Ҫ: ������Action
/// ��    ��: ����ط
/// ����ʱ��: 2009-2-10
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

		#region ע��

		#region logCountersService

		private ILogCountersService logCountersService;
		/// <summary>
		/// ע��logCountersService
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
		/// ���س���ҳ��Ļ�����Ϣ
		/// </summary>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-2-10
		/// </remarks>
		public void InitCopyCounter()
		{
			//��ȡ����������ͻ����ϴγ����ֵ
			model.MachineList = logCountersService.GetNeedRecordWarchMachineAndMachineWatch();

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

		#region ����δ��ɺ�ʵ�ĳ�������

		/// <summary>
		/// ����δ��ɺ�ʵ�ĳ�������
		/// </summary>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.24
		/// </remarks>
		public void CleanUpUncompleteRecordWatchData()
		{
			logCountersService.CleanUpUncompleteRecordWatchData();
		}

		#endregion

		#region ����ȴ���ʵ�ĳ�������

		/// <summary>
		/// ����ȴ���ʵ�ĳ�������
		/// </summary>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.28
		/// </remarks>
		public void SaveVerifyRecordWatchData()
		{
			RecordMachineWatch recordMachineWatch = logCountersService.GetCanUsedRecordMachineWatch();

			RecordMachineWatch lastRecordMachineWatch = logCountersService.GetLastRecordMachineWatch();
			foreach (Machine machine in model.MachineList)
			{
				foreach (MachineWatch machineWatch in machine.watchs)
				{
					int lastNumber = logCountersService.GetLastMachineWatchNumber(lastRecordMachineWatch.Id, machineWatch.Id);
					if (0 == lastNumber)
					{
						throw new ArgumentException("�ϴγ����¼���ݲ�ȫ");
					}
					else
					{
						MachineWatchRecordLog machineWatchRecordLog = new MachineWatchRecordLog();
						machineWatchRecordLog.Machine = new Machine();
						machineWatchRecordLog.Machine.Id = machine.Id;
						machineWatchRecordLog.MachineWatch = new MachineWatch();
						machineWatchRecordLog.MachineWatch.Id = machineWatch.Id;
						machineWatchRecordLog.RecordMachineWatchId = recordMachineWatch.Id;
						machineWatchRecordLog.LastNumber = lastNumber;
						machineWatchRecordLog.NewNumber = machineWatch.Number;
						machineWatchRecordLog.Memo="";
						logCountersService.SaveVerifyRecordWatchData(machineWatchRecordLog);
					}
				}
			}
			model.RecordMachineWatchId = recordMachineWatch.Id.ToString();
		}

		#endregion
	}
}
