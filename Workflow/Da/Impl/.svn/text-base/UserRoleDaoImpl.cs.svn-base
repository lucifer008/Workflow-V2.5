using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table USER_ROLE 对应的Dao 实现
	/// </summary>
    public class UserRoleDaoImpl : Workflow.Da.Base.DaoBaseImpl<UserRole>, IUserRoleDao
    {
        /// <summary>
        /// 通过User.Id删除UserRole
        /// </summary>
        /// <param name="id">User.Id</param>
        public void DeleteByUsersId(long id)
        {
            sqlMap.Delete("UserRole.DeleteByUsersId", id);
        }

        /// <summary>
        /// 通过User.Id和Role.Id查询User_Role
        /// </summary>
        /// <param name="uRole">UserRole</param>
        /// <returns>IList(UserRole)</returns>
        public UserRole SelectUserRoleByUserIdAndRoleId(UserRole uRole)
        {
            return sqlMap.QueryForObject<UserRole>("UserRole.SelectUserRoleByUserIdAndRoleId", uRole);
        }
    }
}
