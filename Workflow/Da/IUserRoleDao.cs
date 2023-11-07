using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table USER_ROLE 对应的Dao 接口
	/// </summary>
    public interface IUserRoleDao : IDaoBase<UserRole>
    {
    	/// <summary>
        /// 通过User.Id删除UserRole
        /// </summary>
        /// <param name="id">User.Id</param>
        void DeleteByUsersId(long id);

        /// <summary>
        /// 通过User.Id和Role.Id查询User_Role
        /// </summary>
        /// <param name="uRole">UserRole</param>
        /// <returns>IList(UserRole)</returns>
        UserRole SelectUserRoleByUserIdAndRoleId(UserRole uRole);
    }
}
