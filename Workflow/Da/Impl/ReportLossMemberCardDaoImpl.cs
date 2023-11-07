using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table REPORT_LOSS_MEMBER_CARD 对应的Dao 实现
	/// </summary>
    public class ReportLossMemberCardDaoImpl : Workflow.Da.Base.DaoBaseImpl<ReportLossMemberCard>, IReportLossMemberCardDao
    {

        #region 通过MemberCardId删除reportLossMemberCard
        public void DeleteByMemberCardId(long memberCardId)
        {
            sqlMap.Delete("ReportLossMemberCard.DeleteByMemberCardId", memberCardId);
        }
        #endregion

    }
}
