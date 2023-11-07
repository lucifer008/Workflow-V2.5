using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table TRASH_REASON ��Ӧ��Dao ʵ��
	/// </summary>
    public class TrashReasonDaoImpl : Workflow.Da.Base.DaoBaseImpl<TrashReason>, ITrashReasonDao
    {
        #region//����ԭ��
        /// <summary>
        /// ��   ��:  SearchTrashReason
        /// ���ܸ�Ҫ: ��ȡ����ԭ���б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<TrashReason> SearchTrashReason(TrashReason trashReason) 
        {
            trashReason.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            trashReason.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<TrashReason>("TrashReason.SearchTrashReason", trashReason);
        }

        /// <summary>
        /// ��   ��:  SearchTrashReasonRowCount
        /// ���ܸ�Ҫ: ��ȡ����ԭ���б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchTrashReasonRowCount(TrashReason trashReason) 
        {
            return sqlMap.QueryForObject<long>("TrashReason.SearchTrashReasonRowCount", trashReason);
        }

        /// <summary>
        /// ��   ��:  CheckTrashReasonIsUse
        /// ���ܸ�Ҫ: ������ԭ���Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long CheckTrashReasonIsUse(long trashReasonId) 
        {
            TrashReason trashReason = new TrashReason();
            trashReason.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            trashReason.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            trashReason.Id = trashReasonId;
            return sqlMap.QueryForObject<long>("TrashReason.CheckTrashReasonIsUse", trashReason);
        }
        #endregion
    }
}
