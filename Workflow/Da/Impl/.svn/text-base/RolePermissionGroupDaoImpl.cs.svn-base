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
	/// Table ROLE_PERMISSION_GROUP (角色权限许可组) 对应的Dao 实现
	/// </summary>
    public class RolePermissionGroupDaoImpl : Workflow.Da.Base.DaoBaseImpl<RolePermissionGroup>, IRolePermissionGroupDao
    {
        #region 通过角色id获取当前角色的所有权限组id

        /// Author:Cry
        /// Date:  2009.1.15
        /// <summary>
        /// 通过角色id获取当前角色的所有权限组id
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<long> GetPermissionGroupIdListByRoleId(long roleId)
        {
            return sqlMap.QueryForList<long>("RolePermissionGroup.GetPermissionGroupIdListByRoleId", roleId);
        }

        #endregion

        #region //删除当前角色所有的权限组

        /// Author:Cry
        /// Date:  2009.1.15
        /// <summary>
        ///  //删除当前角色所有的权限组
        /// </summary>
        /// <param name="roleId">角色id</param>
        public void DeleteRolePermissionGroup(long roleId)
        {
            sqlMap.Delete("RolePermissionGroup.DeleteRolePermissionGroup", roleId);
        }

        #endregion
    }
}