using System;
using System.Collections.Generic;
using Workflow.Da.Domain;
/// <summary>
/// 功能概要: 操作 Service 接口
/// 作    者: 张晓林
/// 创建时间: 2009-2-04
/// 修 正 人: 
/// 修正时间: 
/// 修正描述: 
/// </summary>
namespace Workflow.Service.SystemPermission.PermissionManage
{
    public interface IPermissionService
    {
        /// <summary>
        /// 添加新操作
        /// </summary>
        /// <param name="permission"></param>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月16日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        void AddPermissionInfo(Permission permission);

        /// <summary>
        /// 获取操作名称列表 
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月16日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        IList<Permission> SearchPermissionInfo(Permission permission);

        /// <summary>
        /// 获取操作名称列表个数
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月16日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        long SearchPermissionInfoRowCount(Permission permission);

        /// <summary>
        /// 根据操作Id删除操作信息
        /// </summary>
        /// <param name="permissionId"></param>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月16日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        void DeletePermissionInfo(long permissionId);

        /// <summary>
        /// 根据操作Id更新操作信息
        /// </summary>
        /// <param name="permissionId"></param>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月16日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        void UpdatePermissionInfo(Permission permission);

        #region//权限组操作

        /// <summary>
        /// 添加权限组
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void AddPermissionGroup(PermissionGroup permissionGroup);

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
        /// 删除权限组列表
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日14:17:56
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void LogicDeletePermissionGroup(PermissionGroup permissionGroup);
        #endregion
    }
}
