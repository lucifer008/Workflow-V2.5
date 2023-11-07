using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
   
    /// <summary>
    /// ��    ��: IMemberCardLevelDao
    /// ���ܸ�Ҫ: ��Ա������ӿ�
    /// ��    ��: ������
    /// ����ʱ��: 2009��5��23��11:04:29
    /// �� �� ��: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public interface IMemberCardLevelDao : IDaoBase<MemberCardLevel>
    {
        #region//��Ա������
        /// <summary>
        /// ��   ��:  SearchMemberCardLevel
        /// ���ܸ�Ҫ: ��ȡ��Ա�������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:52:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<MemberCardLevel> SearchMemberCardLevel(MemberCardLevel memberCardLevel);

        /// <summary>
        /// ��   ��:  SearchMemberCardLevelRowCount
        /// ���ܸ�Ҫ: ��ȡ��Ա�������б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:52:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchMemberCardLevelRowCount(MemberCardLevel memberCardLevel);

        /// <summary>
        /// ��   ��:  CheckMemberCardLevelIsUse
        /// ���ܸ�Ҫ: ����Ա�������Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:58:02
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long CheckMemberCardLevelIsUse(long memberCardLevelId);
        #endregion
    }
}
