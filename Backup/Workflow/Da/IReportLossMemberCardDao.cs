using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table REPORT_LOSS_MEMBER_CARD ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IReportLossMemberCardDao : IDaoBase<ReportLossMemberCard>
    {
        /// <summary>
        /// ��    ��: DeleteByMemberCardId
        /// ���ܸ�Ҫ: ͨ��MemberCardIdɾ��
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-6
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        void DeleteByMemberCardId(long memberCardId);
    	
    }
}
