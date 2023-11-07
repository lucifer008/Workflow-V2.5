using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table CONCESSION_MEMBER_CARD_LEVEL 对应的Dao 接口
	/// </summary>
    public interface IConcessionMemberCardLevelDao : IDaoBase<ConcessionMemberCardLevel>
    {
        /// <summary>
        /// 通过CustomerId删除ConcessionMemberCard表中的信息
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-19
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void DeleteConcessionMemberCardByConcessionId(long Id);
        /// <summary>
        /// 通过CampaignId删除ConcessionMemberCard表中的信息
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void DeleteConcessionMemberCardLevelByCampaignId(long Id);
    }
}
