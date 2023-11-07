using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table CONCESSION_MEMBER_CARD_LEVEL 对应的Dao 实现
	/// </summary>
    public class ConcessionMemberCardLevelDaoImpl : Workflow.Da.Base.DaoBaseImpl<ConcessionMemberCardLevel>, IConcessionMemberCardLevelDao
    {
        #region 通过ConcessionId删除ConcessionMemberCard表中的相关信息
        public void DeleteConcessionMemberCardByConcessionId(long Id)
        {
            sqlMap.Delete("ConcessionMemberCardLevel.DeleteConcessionMemberCardByConcessionId", Id);
        }
        #endregion

        #region 通过CampaignId删除ConcessionMemberCard表中的相关信息
        public void DeleteConcessionMemberCardLevelByCampaignId(long Id)
        {
            sqlMap.Delete("ConcessionMemberCardLevel.DeleteByCampaignId", Id);
        }
        #endregion
    }
}
