using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;
/// <summary>
/// 功能概要: 角色 Service 接口
/// 作    者: 陈汝胤
/// 创建时间: 2009-1-15
/// 修 正 人: 
/// 修正时间: 
/// 修正描述: 
/// </summary>

namespace Workflow.Service.SystemPermission.RoleManage
{
	public interface IRoleService
	{
		#region 获取全部角色

		IList<Role> GetRoleList();

		#endregion

		#region 获取所有的角色

		/// <summary>
		/// 获取所有的角色
		/// </summary>
		/// <returns>角色列表</returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		IList<Role> GetAllRole();

		#endregion

		#region 删除角色

		/// <summary>
		/// 删除角色
		/// </summary>
		/// <param name="roleId">角色Id</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		void DeleteRoleById(long roleId);

		#endregion

		#region 权限组的详细列表

		/// <summary>
		/// 权限组的详细列表
		/// </summary>
		///<returns>PermissionGroups</returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		IList<PermissionGroup> GetRolePermissionGroup();

		#endregion

		#region 获取所有的权限许可

		/// <summary>
		/// 获取所有的权限许可
		/// </summary>
		/// <returns>权限许可列表</returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		IList<Permission> GetAllPermission();

		#endregion

		#region 通过角色id获取当前角色的所有权限组id

		/// <summary>
		/// 通过角色id获取当前角色的所有权限组id
		/// </summary>
		/// <param name="roleId">角色Id</param>
		/// <returns>权限组id列表</returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		IList<long> GetPermissionGroupIdListByRoleId(long roleId);

		#endregion

		#region 通过权限组id获取唯一的一个权限许可id

		/// <summary>
		/// 通过权限组id获取唯一的一个权限许可id
		/// </summary>
		/// <param name="permissionGroupId">权限组Id</param>
		/// <returns>权限许可Id</returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		long GetPermissionIdByPermissionGroupId(long permissionGroupId);

		#endregion

		#region 通过角色id获取当前角色

		/// <summary>
		/// 通过角色id获取当前角色
		/// </summary>
		/// <returns></returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		Role GetRoleById(long roleId);

		#endregion

		#region 插入新角色

		/// <summary>
		/// 插入新角色
		/// </summary>
		/// <param name="role">角色</param>
		/// <param name="accessory">角色权限组和权限许可的特殊字符拼接 例如(1:5,2:5)</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		void InsertRole(Role role, string accessory);

		#endregion

		#region 更新角色

		/// <summary>
		/// 更新角色
		/// </summary>
		/// <param name="role">更新的角色</param>
		/// <param name="accessory">角色权限组和权限许可的特殊字符拼接 例如(1:5,2:5)</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		void UpdateRole(Role role, string accessory);

		#endregion
	}
}
