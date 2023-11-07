using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// ��    ��: MemberCardLevelDaoImpl
    /// ���ܸ�Ҫ: ��Ա������ӿ�ʵ��
    /// ��    ��: ������
    /// ����ʱ��: 2009��5��23��11:04:29
    /// �� �� ��: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public class MemberCardLevelDaoImpl : Workflow.Da.Base.DaoBaseImpl<MemberCardLevel>, IMemberCardLevelDao
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
        public IList<MemberCardLevel> SearchMemberCardLevel(MemberCardLevel memberCardLevel) 
        {
            memberCardLevel.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            memberCardLevel.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<MemberCardLevel>("MemberCardLevel.SearchMemberCardLevel", memberCardLevel);
        }

        /// <summary>
        /// ��   ��:  SearchMemberCardLevelRowCount
        /// ���ܸ�Ҫ: ��ȡ��Ա�������б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:52:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchMemberCardLevelRowCount(MemberCardLevel memberCardLevel) 
        {
            return sqlMap.QueryForObject<long>("MemberCardLevel.SearchMemberCardLevelRowCount", memberCardLevel);
        }

        /// <summary>
        /// ��   ��:  CheckMemberCardLevelIsUse
        /// ���ܸ�Ҫ: ����Ա�������Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:58:02
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long CheckMemberCardLevelIsUse(long memberCardLevelId) 
        {
            MemberCardLevel memberCardLevel = new MemberCardLevel();
            memberCardLevel.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            memberCardLevel.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            memberCardLevel.Id = memberCardLevelId;
            return sqlMap.QueryForObject<long>("MemberCardLevel.CheckMemberCardLevelIsUse", memberCardLevel);
        }
        #endregion
    }
}
