using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table COMPENSATE_USED_PAPER ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface ICompensateUsedPaperDao : IDaoBase<CompensateUsedPaper>
    {
        /// <summary>
        /// ��û�������˶�ʱ�Ĳ�������
        /// </summary>
        /// <param name="compensateUsedPaper"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-10-23
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        int SelectMachineWatchRecordPatchCount(CompensateUsedPaper compensateUsedPaper);

		#region ��ȡ��������ֽ����

		/// <summary>
		/// ��ȡ��������ֽ����
		/// </summary>
		/// <param name="recordMachineWatchId">����id</param>
		/// <param name="machineId">����id</param>
		/// <param name="paperId">ֽ��id</param>
		/// <param name="colorType">ֽɫ����</param>
		/// <returns>CompensateUsedPaperList</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.4
		/// </remarks>
		IList<CompensateUsedPaper> SelectCompensateUsedPaper(long recordMachineWatchId, long machineId, long paperId, string colorType);

		#endregion

		#region ��ȡ��������ֽ����

		/// <summary>
		/// ��ȡ��������ֽ����
		/// </summary>
		/// <param name="recordMachineWatchId">����id</param>
		/// <returns>CompensateUsedPaperList</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.4
		/// </remarks>
		IList<CompensateUsedPaper> SelectCompensateUsedPaper(long recordMachineWatchId);

		#endregion

		#region ɾ������ͨ��

		/// <summary>
		/// ɾ������ͨ��
		/// </summary>
		/// <param name="recordMachineWatchId">����id</param>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.4
		/// </remarks>
		void DeleteByRecordMachieWatch(long recordMachineWatchId);
		
		#endregion


		
	}
}
