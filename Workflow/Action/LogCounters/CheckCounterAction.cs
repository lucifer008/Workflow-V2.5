using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Service.LogCounterManage;
using Workflow.Util;
using Workflow.Support;
using System.Collections;

/// <summary>
/// ��    ��: CheckCounterAction
/// ���ܸ�Ҫ: �Գ����¼�ĺ�ʵ
/// ��    ��: ����ط
/// ����ʱ��: 2009.4.29
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

		#region ע�� logCountersService

		private ILogCountersService logCountersService;
		/// <summary>
		/// ע�� logCountersService
		/// </summary>
		public ILogCountersService LogCountersService
		{
			set { logCountersService = value; }
		}

		#endregion

		#region ��ȡ��ʵ�ļ�¼

		/// <summary>
		/// ��ȡ��ʵ�ļ�¼
		/// </summary>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.30
		/// </remarks>
		public void GetVerifyData()
		{
			//�����б�
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

		#region �����ϵı���

		/// <summary>
		/// �����ϵı���
		/// </summary>
		/// <param name="machineWatchRecordList">�����ϵı�ļ�¼���</param>
		/// <param name="conversion">���������㹫ʽ</param>
		/// <param name="isNewNumber">�Ƿ�Ϊ���¼���ֵ</param>
		/// <returns></returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.30
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

		#region ɾ��ָ��id�Ĳ���

		/// <summary>
		/// ɾ��ָ��id�Ĳ���
		/// </summary>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.6
		/// </remarks>
		public void DeleteCompensateUsedPaper()
		{
			logCountersService.DeleteCompensateUsedPaper(model.CompensateUsedPaperId);
		}

		#endregion

		#region ��ɺ�ʵ����

		/// <summary>
		/// ��ɺ�ʵ����
		/// </summary>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.6
		/// </remarks>
		public void CompleteVerify()
		{
			if (null == model.ConversionList || model.RecordMachineWatchId==0)
				throw new Exception("�����쳣");
			logCountersService.DailyRecordMachine(model.ConversionList,model.RecordMachineWatchId);
		}

		#endregion

		/// <summary>
		/// ��    ��: ProcessPaperSpecificationId
		/// ���ܸ�Ҫ: ͨ��ֽ�����ƻ�ȡֽ��Id
		/// ��    ��: 
		/// ����ʱ��: 
		/// �� �� ��: ������
		/// ����ʱ��: 2010-05-07 
		/// ��    ��: 
		/// </summary>
		/// <param name="domain">����������ֽ��</param>
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
