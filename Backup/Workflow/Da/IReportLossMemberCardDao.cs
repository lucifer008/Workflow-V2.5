using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table REPORT_LOSS_MEMBER_CARD 对应的Dao 接口
	/// </summary>
    public interface IReportLossMemberCardDao : IDaoBase<ReportLossMemberCard>
    {
        /// <summary>
        /// 名    称: DeleteByMemberCardId
        /// 功能概要: 通过MemberCardId删除
        /// 作    者: liuwei
        /// 创建时间: 2007-10-6
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        void DeleteByMemberCardId(long memberCardId);
    	
    }
}
