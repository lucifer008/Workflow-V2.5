using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Da
{
	/// <summary>
	/// Table PERMISSION_GROUP 对应的Dao 接口
	/// </summary>
    public interface IPermissionGroupDao : IDaoBase<PermissionGroup>
    {
        IList<PermissionGroup> GetBranchShopPermissionGroup();

        #region//权限组操作

        /// <summary>
        /// 获取权限组列表
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<PermissionGroup> GetPermissionGroup(PermissionGroup permissionGroup);

        /// <summary>
        /// 获取权限组列表记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long GetPermissionGroupRowCount(PermissionGroup permissionGroup);

        /// <summary>
        /// 检查权限组是否正在使用
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long CheckPermissionGroupIsUsed(long permissionGroupId);

        /// <summary>
        /// 修改权限组
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void UpdatePermissionGroup(PermissionGroup permissionGroup); 
        #endregion
    }
}
