using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using System.Collections;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table COMPENSATE_USED_PAPER ��Ӧ��Dao ʵ��
	/// </summary>
    public class CompensateUsedPaperDaoImpl : Workflow.Da.Base.DaoBaseImpl<CompensateUsedPaper>, ICompensateUsedPaperDao
    {
        #region //��û�������˶�ʱ�Ĳ�������
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
        public int SelectMachineWatchRecordPatchCount(CompensateUsedPaper compensateUsedPaper)
        {
            return sqlMap.QueryForObject<int>("CompensateUsedPaper.SelectMachineWatchRecordPatchCount", compensateUsedPaper);
        }
        #endregion


		#region ��ȡ��������ֽ����

		/// <summary>
		/// ��ȡ��������ֽ����
		/// </summary>
		/// <param name="recordMachineWatchId">����id</param>
		/// <param name="machineTypeId">��������id</param>
		/// <param name="paperId">ֽ��id</param>
		/// <param name="colorType">ֽɫ����</param>
		/// <returns>����</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.4
		/// </remarks>
		public IList<CompensateUsedPaper> SelectCompensateUsedPaper(long recordMachineWatchId, long machineTypeId, long paperId, long paperId2, long paperId3, string colorType)
		{
			Hashtable map = new Hashtable();
			map.Add("recordmachinewatchid", recordMachineWatchId);
			map.Add("machineTypeId", machineTypeId);
			map.Add("paperid", paperId);
			map.Add("paperid2", paperId2);
			map.Add("paperId3", paperId3);
			map.Add("colortype", colorType);
			return sqlMap.QueryForList<CompensateUsedPaper>("CompensateUsedPaper.SelectCompensateUsedPaper", map);
		}

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
		public IList<CompensateUsedPaper> SelectCompensateUsedPaper(long recordMachineWatchId)
		{
			return sqlMap.QueryForList<CompensateUsedPaper>("CompensateUsedPaper.SelectCompensateUsedPaperById", recordMachineWatchId);
		}

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
		public void DeleteByRecordMachieWatch(long recordMachineWatchId)
		{
			sqlMap.Delete("CompensateUsedPaper.DeleteByRecordMachieWatch", recordMachineWatchId);
		}

		#endregion
	}
}
