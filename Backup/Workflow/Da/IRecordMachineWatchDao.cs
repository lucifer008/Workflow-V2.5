using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table RECORD_MACHINE_WATCH ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IRecordMachineWatchDao : IDaoBase<RecordMachineWatch>
    {
        RecordMachineWatch SelectLastTimeRecordMachineWatch(RecordMachineWatch recordMachineWatch);

		#region ��ȡһ�����õĳ����¼

		/// <summary>
		/// ��ȡһ��δ��ʵ�ĳ����¼
		/// </summary>
		/// <returns>RecordMachineWatch</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.24
		/// </remarks>
		RecordMachineWatch SelectCompleteRecordMachineWatch();

		#endregion

		#region ���¿��õĳ����¼

		/// <summary>
		/// ���¿��õĳ����¼(��1�θ���ʱ��ʼ������)
		/// </summary>
		void UpdateCanUsedRecordMachineWatch();

		#endregion

		#region ��ȡ���һ�γ����¼

		/// <summary>
		/// ��ȡ���һ�γ����¼
		/// </summary>
		/// <returns>RecordMachineWatch</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.28
		/// </remarks>
		RecordMachineWatch SelectLastRecordMachineWatch();

		#endregion

		#region ��ȡ��ʵ����,��ɵĶ�������ֽ��,ͨ���ϴγ���ʱ��,����id,ֽ��id

		/// <summary>
		/// ��ȡ��ʵ����,��ɵĶ�������ֽ��,ͨ���ϴγ���ʱ��,����id,ֽ��id
		/// </summary>
		/// <returns>����</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.4
		/// </remarks>
		int GetVerifyRecordWatchCompleteOrderUsedCount(System.Collections.Hashtable map);

		#endregion

		#region ���³����¼��ȷ��״̬

		/// <summary>
		/// ���³����¼��ȷ��״̬
		/// </summary>
		/// <param name="recordMachineWatchId">�����¼״̬</param>
		/// <param name="status">״̬</param>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.7
		/// </remarks>
		void UpdateIsConfirmedById(long recordMachineWatchId, string status);

		#endregion

		#region ��ȡ�����¼

		/// <summary>
		/// ��ȡ�����¼
		/// </summary>
		/// <param name="beginRow">��ʼ��</param>
		/// <param name="endRow">������</param>
		/// <param name="beginDate">��ʼʱ��</param>
		/// <param name="endDate">����ʱ��</param>
		/// <returns></returns>
		IList<RecordMachineWatch> GetRecordMachineWatch(int beginRow, int endRow, string beginDate, string endDate);

		#endregion

		#region ��ȡ��Ч�ĳ�����

		/// <summary>
		/// ��ȡ��Ч�ĳ�����
		/// </summary>
		/// <returns></returns>
		int GetRecordMachineWatchCount(string beginDate, string endDate);

		#endregion

		
	}
}
