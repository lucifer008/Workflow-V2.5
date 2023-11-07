using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名    称: MemberCardLevelDaoImpl
    /// 功能概要: 会员卡级别接口实现
    /// 作    者: 张晓林
    /// 创建时间: 2009年5月23日11:04:29
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public class MemberCardLevelDaoImpl : Workflow.Da.Base.DaoBaseImpl<MemberCardLevel>, IMemberCardLevelDao
    {
        #region//会员卡级别
        /// <summary>
        /// 名   称:  SearchMemberCardLevel
        /// 功能概要: 获取会员卡级别列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:52:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<MemberCardLevel> SearchMemberCardLevel(MemberCardLevel memberCardLevel) 
        {
            memberCardLevel.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            memberCardLevel.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<MemberCardLevel>("MemberCardLevel.SearchMemberCardLevel", memberCardLevel);
        }

        /// <summary>
        /// 名   称:  SearchMemberCardLevelRowCount
        /// 功能概要: 获取会员卡级别列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:52:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchMemberCardLevelRowCount(MemberCardLevel memberCardLevel) 
        {
            return sqlMap.QueryForObject<long>("MemberCardLevel.SearchMemberCardLevelRowCount", memberCardLevel);
        }

        /// <summary>
        /// 名   称:  CheckMemberCardLevelIsUse
        /// 功能概要: 检查会员卡级别是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:58:02
        /// 修正履历:
        /// 修正时间:
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
