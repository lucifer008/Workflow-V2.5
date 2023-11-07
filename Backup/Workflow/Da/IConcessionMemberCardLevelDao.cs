using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table CONCESSION_MEMBER_CARD_LEVEL ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IConcessionMemberCardLevelDao : IDaoBase<ConcessionMemberCardLevel>
    {
        /// <summary>
        /// ͨ��CustomerIdɾ��ConcessionMemberCard���е���Ϣ
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-19
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void DeleteConcessionMemberCardByConcessionId(long Id);
        /// <summary>
        /// ͨ��CampaignIdɾ��ConcessionMemberCard���е���Ϣ
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-22
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void DeleteConcessionMemberCardLevelByCampaignId(long Id);
    }
}
