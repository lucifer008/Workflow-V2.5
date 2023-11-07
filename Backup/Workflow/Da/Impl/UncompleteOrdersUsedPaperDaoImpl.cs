using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table UNCOMPLETE_ORDERS_USED_PAPER ��Ӧ��Dao ʵ��
	/// </summary>
    public class UncompleteOrdersUsedPaperDaoImpl : Workflow.Da.Base.DaoBaseImpl<UncompleteOrdersUsedPaper>, IUncompleteOrdersUsedPaperDao
    {
        /// <summary>
        /// ȡ��δ�깤��ֽ��
        /// </summary>
        /// <param name="uncompleteOrdersUsedPaper"></param>
        /// <returns></returns>
        public UncompleteOrdersUsedPaper SelectUncompeleteOrderUsePaper(UncompleteOrdersUsedPaper uncompleteOrdersUsedPaper)
        {
            return sqlMap.QueryForObject<UncompleteOrdersUsedPaper>("UncompleteOrdersUsedPaper.SelectUncompeleteOrderUsePaper", uncompleteOrdersUsedPaper);
        }

		#region ��ȡδ�깤�����б�ͨ������id

		/// <summary>
		/// ��ȡδ�깤�����б�ͨ������id
		/// </summary>
		/// <param name="recordMachineWatchId">����id</param>
		/// <returns>UncompleteOrdersUsedPaperList</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.24
		/// </remarks>
		public IList<UncompleteOrdersUsedPaper> SelectUncompleteOrdersByRecordWatchId(long recordMachineWatchId)
		{
			return sqlMap.QueryForList<UncompleteOrdersUsedPaper>("UncompleteOrdersUsedPaper.SelectUncompleteOrdersByRecordWatchId", recordMachineWatchId);
		}

		#endregion

		#region ɾ��ָ�������¼�µ�δ�깤������ֽ���

		/// <summary>
		/// ɾ��ָ�������¼�µ�δ�깤������ֽ���
		/// </summary>
		/// <param name="recordMachineWatchId"></param>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.24
		/// </remarks>
		public void DeleteUncompleteOrderByRecordWatchId(long recordMachineWatchId)
		{
			sqlMap.Delete("UncompleteOrdersUsedPaper.DeleteUncompleteOrderByRecordWatchId", recordMachineWatchId);
		}

		#endregion
	}
}
