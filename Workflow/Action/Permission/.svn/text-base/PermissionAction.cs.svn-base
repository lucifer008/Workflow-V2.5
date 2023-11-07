using System;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Support;
using Workflow.Action.Permission.Model;
using Workflow.Service.SystemPermission.PermissionManage;
/// <summary>
/// 名    称: PermissionAction
/// 功能概要: 操作管理Action
/// 作    者: 张晓林
/// 创建时间: 2009年1月16日
/// 修正履历: 
/// 修正时间:            
/// </summary>
namespace Workflow.Action.Permission
{
    public class PermissionAction
    {
        #region Model
        private PermissionModel model = new PermissionModel();
        public PermissionModel Model
        {
            get { return model; }
        }
        #endregion

        #region 注入 permissionService

        private IPermissionService permissionService;
        public IPermissionService PermissionService 
        {
            set { permissionService = value; }
        }
        #endregion

        #region //添加操作
        /// <summary>
        /// 添加操作
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月16日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void AddPermissionInfo() 
        {
            permissionService.AddPermissionInfo(Model.Permission);
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
        public void SearchPermissionInfo()
        {
            model.PermissionList = permissionService.SearchPermissionInfo(Model.Permission);
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
        public long SearchPermissionInfoRowCount()
        {
            return permissionService.SearchPermissionInfoRowCount(Model.Permission);
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
            permissionService.DeletePermissionInfo(permissionId);
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
        public void UpdatePermissionInfo() 
        {
            permissionService.UpdatePermissionInfo(model.Permission);
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
        public void AddPermissionGroup() 
        {
            permissionService.AddPermissionGroup(model.PermissionGroup);
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
        public void UpdatePermissionGroup()
        {
            permissionService.UpdatePermissionGroup(model.PermissionGroup);
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
        public void GetPermissionGroup()
        {
            model.PermissionGroupList = permissionService.GetPermissionGroup(model.PermissionGroup);
            model.RowCount = permissionService.GetPermissionGroupRowCount(model.PermissionGroup);
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
        public void LogicDeletePermissionGroup() 
        {
            permissionService.LogicDeletePermissionGroup(model.PermissionGroup);
        }
        #endregion
    }
}
