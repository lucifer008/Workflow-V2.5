using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
/// <summary>
/// 功能概要: 角色 Service 实现
/// 作    者: 陈汝胤
/// 创建时间: 2009-1-15
/// 修 正 人: 
/// 修正时间: 
/// 修正描述: 
/// </summary>

namespace Workflow.Service.SystemPermission.RoleManage
{ 
	public class RoleServiceImpl : IRoleService
	{
		#region 类成员

		#region 注入 roleDao

		private IRoleDao roleDao;
		/// <summary>
		/// 注入 roleDao
		/// </summary>
		public IRoleDao RoleDao
		{
			set { roleDao = value; }
		}

		#endregion

		#region 注入 permissionGroupDetailDao

		private IPermissionGroupDetailDao permissionGroupDetailDao;
		/// <summary>
		/// 注入 permissionGroupDetailDao
		/// </summary>
		public IPermissionGroupDetailDao PermissionGroupDetailDao
		{
			set { permissionGroupDetailDao = value; }
		}

		#endregion

		#region rolePermissionGroupDao

		private IRolePermissionGroupDao rolePermissionGroupDao;
		/// <summary>
		/// 注入 rolePermissionGroupDao
		/// </summary>
		public IRolePermissionGroupDao RolePermissionGroupDao
		{
			set { rolePermissionGroupDao = value; }
		}

		#endregion

		#region permissionGroupDao

		private IPermissionGroupDao permissionGroupDao;
		/// <summary>
		/// 注入 permissionGroupDao
		/// </summary>
		public IPermissionGroupDao PermissionGroupDao
		{
			set { permissionGroupDao = value; }
		}

		#endregion

        #region 注入 permissionDao

        private IPermissionDao permissionDao;
        /// <summary>
        /// 注入 permissionDao
        /// </summary>
        public IPermissionDao PermissionDao
        {
            set { permissionDao = value; }
        }

        #endregion

		#endregion

		#region 获取全部角色

		public IList<Role> GetRoleList()
		{
			return roleDao.GetRoleList();
		}

		#endregion

		#region 获取所有的角色

		/// <summary>
		/// 获取所有的角色
		/// </summary>
		/// <returns>角色列表</returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		public IList<Role> GetAllRole()
		{
			return roleDao.SelectAll();
		}

		#endregion

		#region 通过角色id删除角色

		/// Author:Cry
		/// Date:  2009.1.15
		/// <summary>
		/// 通过角色id删除角色
		/// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		[Spring.Transaction.Interceptor.Transaction]
		public void DeleteRoleById(long roleId)
		{
			DeleteRolePermissionGroup(roleId);

			roleDao.LogicDelete(roleId);
		}

		#endregion

		#region 删除当前角色所有的权限组

		/// <summary>
        /// 通过角色删除当前角色所有的权限组
        /// </summary>
        /// <param name="roleId">角色Id</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
        private void DeleteRolePermissionGroup(long roleId)
        {
            rolePermissionGroupDao.DeleteRolePermissionGroup(roleId);
        }

        #endregion

		#region 权限组的详细列表

		/// <summary>
		/// 权限组的详细列表
		/// </summary>
		/// <returns>权限组列表</returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		public IList<PermissionGroup> GetRolePermissionGroup()
		{
			//return permissionGroupDao.SelectAll();
            return permissionGroupDao.GetBranchShopPermissionGroup();
		}

		#endregion

		#region 获取全部的权限许可

		/// <summary>
		/// 获取全部的权限许可
		/// </summary>
		/// <returns></returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		public IList<Permission> GetAllPermission()
		{
			//return permissionDao.SelectAll();
            return permissionDao.GetBranchShopPermission();
		}

		#endregion

		#region 通过角色id获取当前角色的所有权限组id

		/// <summary>
		/// 通过角色id获取当前角色的所有权限组id
		/// </summary>
		/// <param name="roleId">角色Id</param>
		/// <returns>权限组id列表</returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		public IList<long> GetPermissionGroupIdListByRoleId(long roleId)
		{
			return rolePermissionGroupDao.GetPermissionGroupIdListByRoleId(roleId);
		}

		#endregion

		#region 通过权限组id获取唯一的一个权限许可id

		/// <summary>
		/// 通过权限组id获取唯一的一个权限许可id
		/// </summary>
		/// <param name="permissionGroupId">permissionGroupId</param>
		/// <returns>权限许可id</returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		public long GetPermissionIdByPermissionGroupId(long permissionGroupId)
		{
			return permissionDao.GetPermissionIdByPermissionGroupId(permissionGroupId);
		}

		#endregion

		#region 通过角色id获取当前角色

		/// <summary>
		/// 通过角色id获取当前角色
		/// </summary>
		/// <param name="roleId">角色Id</param>
		/// <returns>角色</returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		public Role GetRoleById(long roleId)
		{
			return roleDao.SelectByPk(roleId);
		}

		#endregion

		#region 插入新角色

		/// <summary>
		/// 插入新角色
		/// </summary>
		/// <param name="role">角色</param>
		/// <param name="accessory">角色权限组和权限许可的特殊字符拼接 例如(1:5,2:5)</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		[Spring.Transaction.Interceptor.Transaction]
		public void InsertRole(Role role, string accessory)
		{
			//插入角色 
			roleDao.Insert(role);
			//插入当前角色可使用的权限
			InsertRolePermission(role.Id, accessory);
		}
		#endregion

		#region 更新角色

		/// <summary>
		/// 更新角色
		/// </summary>
		/// <param name="role">角色</param>
		/// <param name="accessory">角色权限组和权限许可的特殊字符拼接 例如(1:5,2:5)</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		[Spring.Transaction.Interceptor.Transaction]
		public void UpdateRole(Role role, string accessory)
		{
			//更新角色
			roleDao.Update(role);
			//删除当前角色所有的权限组
			DeleteRolePermissionGroup(role.Id);
			//插入当前角色更新后的可使用的权限
			InsertRolePermission(role.Id, accessory);
		}

		#endregion

		#region 插入角色权限
		
		/// <summary>
		/// 插入角色权限
		/// </summary>
		/// <param name="roleId">角色Id</param>
		/// <param name="accessory">角色权限组和权限许可的特殊字符拼接 例如(1:5,2:5)</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-15
		private void InsertRolePermission(long roleId, string accessory)
		{
			//获取当前所有有关系的权限组id
			IList<long> groupIdList = permissionGroupDetailDao.GetExistRelationPermissionGroup();
			//插入需要更新的权限组
			if (null != accessory)
			{
				string[] groupArr = accessory.Split(',');
				RolePermissionGroup rolePermissionGroup;
				PermissionGroupDetail permissionGroupDetail;
				foreach (string group in groupArr)
				{
					string[] arr = group.Split(':');
					if (arr.Length == 2)
					{
						long groupId = long.Parse(arr[0]);
						//创建角色和权限组之间的关系
						rolePermissionGroup = new RolePermissionGroup();
						rolePermissionGroup.RoleId = roleId;
						rolePermissionGroup.PermissionGroupId = groupId;
						rolePermissionGroupDao.Insert(rolePermissionGroup);
						//创建权限组和权限许可之间的关系
						if (!groupIdList.Contains(groupId))
						{
							permissionGroupDetail = new PermissionGroupDetail();
							permissionGroupDetail.PermissionGroupId = groupId;
							permissionGroupDetail.PermissionId = long.Parse(arr[1]);
							permissionGroupDetailDao.Insert(permissionGroupDetail);

						}
					}
				}
			}
		}

		#endregion
	}
}
