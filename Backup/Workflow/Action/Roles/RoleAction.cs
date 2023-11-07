using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Service.SystemPermission.RoleManage;
/// <summary>
/// 功能概要: 角色Action
/// 作    者: 陈汝胤
/// 创建时间: 2009-1-15
/// 修 正 人: 
/// 修正时间: 
/// 修正描述: 
/// </summary>

namespace Workflow.Action.Roles
{
    public class RoleAction
	{
		#region 类成员
		
		#region RoleModel model
		private RoleModel model = new RoleModel();
        public RoleModel Model
        {
            get { return model; }
		}
		#endregion
		
		#region 注入 roleService

		private IRoleService roleService;
        /// <summary>
        /// 注入roleService
        /// </summary>
        public IRoleService RoleService
        {
            set { roleService = value; }
        }

        #endregion
		
		#endregion

		#region 获取岗位一览
		/// <summary>
		/// 获取岗位一览		
		/// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
        public void GetRoleList()
        {
            model.RoleList=roleService.GetAllRole();
        }
		#endregion

		#region 删除角色
		/// <summary>
        /// 删除角色
        /// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15 
        public void DeleteRoleById()
        {
            roleService.DeleteRoleById(model.Id);
        }
		#endregion

		#region 获取权限默认列表
		/// <summary>
        /// 获取权限默认列表
        /// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15 
        public void GetRolePermissionGroup()
        {
            model.PermissionGroupList = roleService.GetRolePermissionGroup();

            model.PermissionList = roleService.GetAllPermission();
        }
		#endregion

		#region 通过角色id获取当前角色,并获取名称,并绑定当前角色
		/// <summary>
        /// 通过角色id获取当前角色,并获取名称,并绑定当前角色
        /// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15 
        public void GetRoleUserdPermissionGroup()
        {
            IList<long> permissionGroupList = roleService.GetPermissionGroupIdListByRoleId(model.Id);
            if (null != model.PermissionGroupList && permissionGroupList.Count > 0)
            {
                foreach (PermissionGroup permissionGroup in model.PermissionGroupList)
                {
                    //如果当前的角色的当前权限组存在
                    if (permissionGroupList.Contains(permissionGroup.Id))
                    {
                        //查找唯一的一个权限许可的id
                        permissionGroup.PermissionId = roleService.GetPermissionIdByPermissionGroupId(permissionGroup.Id);
                        permissionGroup.IsChecked = true;
                    }
                }
            }
        }
		#endregion

		#region 获取角色通过角色id
		/// <summary>
        /// 获取角色通过角色id
        /// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15 
        public void GetRoleByRoleId()
        {
            Role role = roleService.GetRoleById(model.Id);
            model.Name = role.PermissionValues;
            model.Role = role;
        }
		#endregion

		#region 插入新角色
		/// <summary>
        /// 插入新角色
        /// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15 
        public void InsertRole()
        {
            Role role = new Role();
            role.PermissionValues = model.Name;
            roleService.InsertRole(role,model.Accessory);
        }
		#endregion

		#region 更新角色
		/// <summary>
        /// 更新角色
        /// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15 
        public void UpdateRole()
        {
            if (null != model.Role)
            {
                model.Role.PermissionValues = model.Name;
                roleService.UpdateRole(model.Role,model.Accessory);
            }
        }
		#endregion
    }
}
