using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
   
    /// <summary>
    /// 名    称: IMemberCardLevelDao
    /// 功能概要: 会员卡级别接口
    /// 作    者: 张晓林
    /// 创建时间: 2009年5月23日11:04:29
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public interface IMemberCardLevelDao : IDaoBase<MemberCardLevel>
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
        IList<MemberCardLevel> SearchMemberCardLevel(MemberCardLevel memberCardLevel);

        /// <summary>
        /// 名   称:  SearchMemberCardLevelRowCount
        /// 功能概要: 获取会员卡级别列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:52:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchMemberCardLevelRowCount(MemberCardLevel memberCardLevel);

        /// <summary>
        /// 名   称:  CheckMemberCardLevelIsUse
        /// 功能概要: 检查会员卡级别是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日10:58:02
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckMemberCardLevelIsUse(long memberCardLevelId);
        #endregion
    }
}
