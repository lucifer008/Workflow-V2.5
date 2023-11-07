using System;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
using Workflow.Da.Support;
/// <summary>
/// 功能概要: 操作 IPermissionService 接口实现类
/// 作    者: 张晓林
/// 创建时间: 2009-2-04
/// 修 正 人: 
/// 修正时间: 
/// 修正描述: 
/// </summary>
namespace Workflow.Service.SystemPermission.PermissionManage.Impl
{
    public class PermissionServiceImpl : IPermissionService
    {
        #region 注入 Dao

        private IPermissionDao permissionDao;
        /// <summary>
        /// 注入 permissionDao
        /// </summary>
        public IPermissionDao PermissionDao
        {
            set { permissionDao = value; }
        }

        private IdGeneratorSupport idGeneratorSupport;
        public IdGeneratorSupport IdGeneratorSupport
        {
            set { idGeneratorSupport = value; }
        }

        private IPermissionGroupDao permissionGroupDao;
        public IPermissionGroupDao PermissionGroupDao 
        {
            set { permissionGroupDao = value; }
        }
        #endregion

        #region //添加新操作
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
        public void AddPermissionInfo(Permission permission)
        {
            permissionDao.AddPermissionInfo(permission);
        }
        #endregion

        #region //获取操作名称列表
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
        public IList<Permission> SearchPermissionInfo(Permission permission)
        {
            return permissionDao.SearchPermissionInfo(permission);
        }
        #endregion

        #region //获取操作名称列表个数
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
        public long SearchPermissionInfoRowCount(Permission permission)
        {
            return permissionDao.SearchPermissionInfoRowCount(permission);
        }
        #endregion

        #region //根据操作Id删除操作信息
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
        public void DeletePermissionInfo(long permissionId)
        {
            permissionDao.DeletePermissionInfo(permissionId);
        }
        #endregion

        #region //根据操作Id更新操作信息
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
        public void UpdatePermissionInfo(Permission permission)
        {
            permissionDao.UpdatePermissionInfo(permission);
        }
        #endregion

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
        public void AddPermissionGroup(PermissionGroup permissionGroup) 
        {
            Type type = typeof(PermissionGroup);
            long id = idGeneratorSupport.NextId(type);
            permissionGroup.SortNo = (int)id;
            permissionGroupDao.Insert(permissionGroup);
        }

        /// <summary>
        /// 修改权限组
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void UpdatePermissionGroup(PermissionGroup permissionGroup) 
        {
            permissionGroup.SortNo = (int)permissionGroup.Id;
            permissionGroupDao.UpdatePermissionGroup(permissionGroup);
        }

        /// <summary>
        /// 获取权限组列表
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<PermissionGroup> GetPermissionGroup(PermissionGroup permissionGroup) 
        {
            return permissionGroupDao.GetPermissionGroup(permissionGroup);
        }

        /// <summary>
        /// 获取权限组列表记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long GetPermissionGroupRowCount(PermissionGroup permissionGroup) 
        {
            return permissionGroupDao.GetPermissionGroupRowCount(permissionGroup);
        }

        /// <summary>
        /// 检查权限组是否正在使用
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long CheckPermissionGroupIsUsed(long permissionGroupId) 
        {
            return permissionGroupDao.CheckPermissionGroupIsUsed(permissionGroupId);
        }

        /// <summary>
        /// 删除权限组列表
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日14:17:56
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void LogicDeletePermissionGroup(PermissionGroup permissionGroup) 
        {
            permissionGroupDao.LogicDelete(permissionGroup.Id);
        }
        #endregion
    }
}
