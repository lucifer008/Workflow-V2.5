using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table TRASH_REASON ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface ITrashReasonDao : IDaoBase<TrashReason>
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
        IList<TrashReason> SearchTrashReason(TrashReason trashReason);

        /// <summary>
        /// ��   ��:  SearchTrashReasonRowCount
        /// ���ܸ�Ҫ: ��ȡ����ԭ���б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchTrashReasonRowCount(TrashReason trashReason);

        /// <summary>
        /// ��   ��:  CheckTrashReasonIsUse
        /// ���ܸ�Ҫ: ������ԭ���Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long CheckTrashReasonIsUse(long trashReasonId);
        #endregion
    }
}
