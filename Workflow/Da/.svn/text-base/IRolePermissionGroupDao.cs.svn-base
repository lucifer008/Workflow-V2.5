#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table ROLE_PERMISSION_GROUP (角色权限许可组)对应的Dao 接口
	/// </summary>
	public interface IRolePermissionGroupDao : IDaoBase<RolePermissionGroup>
	{
        /// Author:Cry
        /// Date:  2009.1.15
        /// <summary>
        /// 通过角色id获取当前角色的所有权限组id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        IList<long> GetPermissionGroupIdListByRoleId(long roleId);

        /// Author:Cry
        /// Date:  2009.1.15
        /// <summary>
        ///  //删除当前角色所有的权限组
        /// </summary>
        /// <param name="roleId">角色id</param>
        void DeleteRolePermissionGroup(long roleId);
    }
}