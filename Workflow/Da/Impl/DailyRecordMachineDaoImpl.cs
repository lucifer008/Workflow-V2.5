using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table DAILY_RECORD_MACHINE ��Ӧ��Dao ʵ��
	/// </summary>
    public class DailyRecordMachineDaoImpl : Workflow.Da.Base.DaoBaseImpl<DailyRecordMachine>, IDailyRecordMachineDao
    {
        #region //��������ѯ

        /// <summary>
        /// �������Զ����ѯ
        /// </summary>
        /// <param name="dailyRecordMachine"></param>
        /// <returns></returns>
        public IList<DailyRecordMachine> SelectDailyRecordMachineListCustomQuery(DailyRecordMachine dailyRecordMachine)
        {
			//dailyRecordMachine.MachineName = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId.ToString();//�ֵ�Id
			//dailyRecordMachine.Id = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;//��˾Id
			//return sqlMap.QueryForList<DailyRecordMachine>("DailyRecordMachine.SelectDailyRecordMachineListCustomQuery", dailyRecordMachine);
			return null;
        }

        /// <summary>
        /// ��    ��: GetDailyRecordMachineListCustomQueryPrint
        /// ���ܸ�Ҫ: ��������ѯ(��ӡ)
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��27��10:49:55
        /// �� �� ��: 
        /// ����ʱ��: 
        /// ��    ��: 
        /// </summary>
        /// <param name="dailyRecordMachine"></param>
        /// <returns></returns>
        public IList<DailyRecordMachine> GetDailyRecordMachineListCustomQueryPrint(DailyRecordMachine dailyRecordMachine) 
        {
			//dailyRecordMachine.MachineName = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId.ToString();//�ֵ�Id
			//dailyRecordMachine.Id = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;//��˾Id
			//return sqlMap.QueryForList<DailyRecordMachine>("DailyRecordMachine.GetDailyRecordMachineListCustomQueryPrint", dailyRecordMachine);
			return null;
        }

        /// <summary>
        /// ��    ��: GetDailyRecordMachineListCustomQueryRowCount
        /// ���ܸ�Ҫ: ��������ѯ��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��27��10:49:55
        /// �� �� ��: 
        /// ����ʱ��: 
        /// ��    ��: 
        /// </summary>
        /// <param name="dailyRecordMachine"></param>
        /// <returns></returns>
        public long GetDailyRecordMachineListCustomQueryRowCount(DailyRecordMachine dailyRecordMachine) 
        {
            return sqlMap.QueryForObject<long>("DailyRecordMachine.GetDailyRecordMachineListCustomQueryRowCount", dailyRecordMachine);
        }
        #endregion

		#region ��ȡָ������ID�Ľ��

		public IList<DailyRecordMachine> GetRecordMachineWatchResult(long recordMachineWatchId)
		{
			return sqlMap.QueryForList<DailyRecordMachine>("DailyRecordMachine.GetRecordMachineWatchResult", recordMachineWatchId);
		}

		#endregion
	}
}
