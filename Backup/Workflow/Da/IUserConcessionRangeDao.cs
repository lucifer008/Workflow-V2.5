#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table USER_CONCESSION_RANGE (用户优惠范围)对应的Dao 接口
	/// </summary>
	public interface IUserConcessionRangeDao : IDaoBase<UserConcessionRange>
	{
        /// <summary>
        /// 根据用户Id删除用户优惠信息
        /// </summary>
        /// <param name="userConcessionRange"></param>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年8月3日13:39:34
        /// 修正履历:
        /// 修正时间:
        ///</remarks>
        void DeleteConcessionRanageByUserId(long userId);
	}
}