#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
#endregion

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table USER_CONCESSION_RANGE (用户优惠范围) 对应的Dao 实现
	/// </summary>
    public class UserConcessionRangeDaoImpl : Workflow.Da.Base.DaoBaseImpl<UserConcessionRange>, IUserConcessionRangeDao
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
        public void DeleteConcessionRanageByUserId(long userId) 
        {
            UserConcessionRange userConcessionRanage = new UserConcessionRange();
            userConcessionRanage.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            userConcessionRanage.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            userConcessionRanage.UsersId = userId;
            sqlMap.Delete("UserConcessionRange.DeleteConcessionRanageByUserId", userConcessionRanage);
        }
    }
}