using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
/// <summary>
/// ���ܸ�Ҫ: ��ɫ Service ʵ��
/// ��    ��: ����ط
/// ����ʱ��: 2009-1-15
/// �� �� ��: 
/// ����ʱ��: 
/// ��������: 
/// </summary>

namespace Workflow.Service.SystemPermission.RoleManage
{ 
	public class RoleServiceImpl : IRoleService
	{
		#region ���Ա

		#region ע�� roleDao

		private IRoleDao roleDao;
		/// <summary>
		/// ע�� roleDao
		/// </summary>
		public IRoleDao RoleDao
		{
			set { roleDao = value; }
		}

		#endregion

		#region ע�� permissionGroupDetailDao

		private IPermissionGroupDetailDao permissionGroupDetailDao;
		/// <summary>
		/// ע�� permissionGroupDetailDao
		/// </summary>
		public IPermissionGroupDetailDao PermissionGroupDetailDao
		{
			set { permissionGroupDetailDao = value; }
		}

		#endregion

		#region rolePermissionGroupDao

		private IRolePermissionGroupDao rolePermissionGroupDao;
		/// <summary>
		/// ע�� rolePermissionGroupDao
		/// </summary>
		public IRolePermissionGroupDao RolePermissionGroupDao
		{
			set { rolePermissionGroupDao = value; }
		}

		#endregion

		#region permissionGroupDao

		private IPermissionGroupDao permissionGroupDao;
		/// <summary>
		/// ע�� permissionGroupDao
		/// </summary>
		public IPermissionGroupDao PermissionGroupDao
		{
			set { permissionGroupDao = value; }
		}

		#endregion

        #region ע�� permissionDao

        private IPermissionDao permissionDao;
        /// <summary>
        /// ע�� permissionDao
        /// </summary>
        public IPermissionDao PermissionDao
        {
            set { permissionDao = value; }
        }

        #endregion

		#endregion

		#region ��ȡȫ����ɫ

		public IList<Role> GetRoleList()
		{
			return roleDao.GetRoleList();
		}

		#endregion

		#region ��ȡ���еĽ�ɫ

		/// <summary>
		/// ��ȡ���еĽ�ɫ
		/// </summary>
		/// <returns>��ɫ�б�</returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		public IList<Role> GetAllRole()
		{
			return roleDao.SelectAll();
		}

		#endregion

		#region ͨ����ɫidɾ����ɫ

		/// Author:Cry
		/// Date:  2009.1.15
		/// <summary>
		/// ͨ����ɫidɾ����ɫ
		/// </summary>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		[Spring.Transaction.Interceptor.Transaction]
		public void DeleteRoleById(long roleId)
		{
			DeleteRolePermissionGroup(roleId);

			roleDao.LogicDelete(roleId);
		}

		#endregion

		#region ɾ����ǰ��ɫ���е�Ȩ����

		/// <summary>
        /// ͨ����ɫɾ����ǰ��ɫ���е�Ȩ����
        /// </summary>
        /// <param name="roleId">��ɫId</param>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
        private void DeleteRolePermissionGroup(long roleId)
        {
            rolePermissionGroupDao.DeleteRolePermissionGroup(roleId);
        }

        #endregion

		#region Ȩ�������ϸ�б�

		/// <summary>
		/// Ȩ�������ϸ�б�
		/// </summary>
		/// <returns>Ȩ�����б�</returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		public IList<PermissionGroup> GetRolePermissionGroup()
		{
			//return permissionGroupDao.SelectAll();
            return permissionGroupDao.GetBranchShopPermissionGroup();
		}

		#endregion

		#region ��ȡȫ����Ȩ�����

		/// <summary>
		/// ��ȡȫ����Ȩ�����
		/// </summary>
		/// <returns></returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		public IList<Permission> GetAllPermission()
		{
			//return permissionDao.SelectAll();
            return permissionDao.GetBranchShopPermission();
		}

		#endregion

		#region ͨ����ɫid��ȡ��ǰ��ɫ������Ȩ����id

		/// <summary>
		/// ͨ����ɫid��ȡ��ǰ��ɫ������Ȩ����id
		/// </summary>
		/// <param name="roleId">��ɫId</param>
		/// <returns>Ȩ����id�б�</returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		public IList<long> GetPermissionGroupIdListByRoleId(long roleId)
		{
			return rolePermissionGroupDao.GetPermissionGroupIdListByRoleId(roleId);
		}

		#endregion

		#region ͨ��Ȩ����id��ȡΨһ��һ��Ȩ�����id

		/// <summary>
		/// ͨ��Ȩ����id��ȡΨһ��һ��Ȩ�����id
		/// </summary>
		/// <param name="permissionGroupId">permissionGroupId</param>
		/// <returns>Ȩ�����id</returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		public long GetPermissionIdByPermissionGroupId(long permissionGroupId)
		{
			return permissionDao.GetPermissionIdByPermissionGroupId(permissionGroupId);
		}

		#endregion

		#region ͨ����ɫid��ȡ��ǰ��ɫ

		/// <summary>
		/// ͨ����ɫid��ȡ��ǰ��ɫ
		/// </summary>
		/// <param name="roleId">��ɫId</param>
		/// <returns>��ɫ</returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		public Role GetRoleById(long roleId)
		{
			return roleDao.SelectByPk(roleId);
		}

		#endregion

		#region �����½�ɫ

		/// <summary>
		/// �����½�ɫ
		/// </summary>
		/// <param name="role">��ɫ</param>
		/// <param name="accessory">��ɫȨ�����Ȩ����ɵ������ַ�ƴ�� ����(1:5,2:5)</param>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		[Spring.Transaction.Interceptor.Transaction]
		public void InsertRole(Role role, string accessory)
		{
			//�����ɫ 
			roleDao.Insert(role);
			//���뵱ǰ��ɫ��ʹ�õ�Ȩ��
			InsertRolePermission(role.Id, accessory);
		}
		#endregion

		#region ���½�ɫ

		/// <summary>
		/// ���½�ɫ
		/// </summary>
		/// <param name="role">��ɫ</param>
		/// <param name="accessory">��ɫȨ�����Ȩ����ɵ������ַ�ƴ�� ����(1:5,2:5)</param>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		[Spring.Transaction.Interceptor.Transaction]
		public void UpdateRole(Role role, string accessory)
		{
			//���½�ɫ
			roleDao.Update(role);
			//ɾ����ǰ��ɫ���е�Ȩ����
			DeleteRolePermissionGroup(role.Id);
			//���뵱ǰ��ɫ���º�Ŀ�ʹ�õ�Ȩ��
			InsertRolePermission(role.Id, accessory);
		}

		#endregion

		#region �����ɫȨ��
		
		/// <summary>
		/// �����ɫȨ��
		/// </summary>
		/// <param name="roleId">��ɫId</param>
		/// <param name="accessory">��ɫȨ�����Ȩ����ɵ������ַ�ƴ�� ����(1:5,2:5)</param>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		private void InsertRolePermission(long roleId, string accessory)
		{
			//��ȡ��ǰ�����й�ϵ��Ȩ����id
			IList<long> groupIdList = permissionGroupDetailDao.GetExistRelationPermissionGroup();
			//������Ҫ���µ�Ȩ����
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
						//������ɫ��Ȩ����֮��Ĺ�ϵ
						rolePermissionGroup = new RolePermissionGroup();
						rolePermissionGroup.RoleId = roleId;
						rolePermissionGroup.PermissionGroupId = groupId;
						rolePermissionGroupDao.Insert(rolePermissionGroup);
						//����Ȩ�����Ȩ�����֮��Ĺ�ϵ
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
