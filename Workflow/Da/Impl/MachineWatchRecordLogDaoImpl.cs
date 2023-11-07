using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using System.Collections;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table MACHINE_WATCH_RECORD_LOG ��Ӧ��Dao ʵ��
	/// </summary>
    public class MachineWatchRecordLogDaoImpl : Workflow.Da.Base.DaoBaseImpl<MachineWatchRecordLog>, IMachineWatchRecordLogDao
    {
        /// <summary>
        /// ͨ������ID,����ID,������ID��ñ��γ������
        /// </summary>
        /// <returns></returns>
        public int SelectMachineWatchValue(MachineWatchRecordLog machineWatchRecordLog)
        {
            return sqlMap.QueryForObject<int>("MachineWatchRecordLog.SelectMachineWatchValue", machineWatchRecordLog);
        }

		#region ��ȡ��Ķ���ͨ�������¼id�ͻ�����id

		/// <summary>
		/// ��ȡ��Ķ���ͨ�������¼id�ͻ�����id
		/// </summary>
		/// <param name="recordMachineWatchId">�����¼id</param>
		/// <param name="machineWatchId">������id</param>
		/// <returns>����</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.28
		/// </remarks>
		public int GetLastMachineWatchNumber(long recordMachineWatchId, long machineWatchId)
		{
			Hashtable map=new Hashtable();
			map.Add("recordMachineWatchId",recordMachineWatchId);
			map.Add("machineWatchId",machineWatchId);
			return sqlMap.QueryForObject<int>("MachineWatchRecordLog.GetLastMachineWatchNumber", map);
		}

		#endregion

		#region ɾ��δ��ɺ�ʵ�ĳ����¼ͨ������id

		/// <summary>
		/// ɾ��δ��ɺ�ʵ�ĳ����¼ͨ������id
		/// </summary>
		/// <param name="recordMachineWatchId">����id</param>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.28
		/// </remarks>
		public void DeleteUncompleteOrderByRecordWatchId(long recordMachineWatchId)
		{
			sqlMap.Delete("MachineWatchRecordLog.DeleteUncompleteOrderByRecordWatchId", recordMachineWatchId);
		}

		#endregion

		#region ��ȡ��Ҫ�˶Եĳ����¼,ͨ������id�ͻ���id

		/// <summary>
		/// ��ȡ��Ҫ�˶Եĳ����¼,ͨ������id�ͻ���id
		/// </summary>
		/// <param name="recordMachineWatchId">����id</param>
		/// <param name="machineTypeId">��������id</param>
		/// <returns>�����¼�б�</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.30
		/// </remarks>
		public IList<MachineWatchRecordLog> GetNeedVerifyRecordLog(long recordMachineWatchId, long machineTypeId)
		{
			Hashtable map=new Hashtable();
			map.Add("recordmachinewatchid",recordMachineWatchId);
			map.Add("machineTypeId", machineTypeId);
			return sqlMap.QueryForList<MachineWatchRecordLog>("MachineWatchRecordLog.GetNeedVerifyRecordLog",map);
		}

		#endregion
	}
}
