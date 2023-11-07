using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;
/// <summary>
/// ���ܸ�Ҫ: ��ɫ Service �ӿ�
/// ��    ��: ����ط
/// ����ʱ��: 2009-1-15
/// �� �� ��: 
/// ����ʱ��: 
/// ��������: 
/// </summary>

namespace Workflow.Service.SystemPermission.RoleManage
{
	public interface IRoleService
	{
		#region ��ȡȫ����ɫ

		IList<Role> GetRoleList();

		#endregion

		#region ��ȡ���еĽ�ɫ

		/// <summary>
		/// ��ȡ���еĽ�ɫ
		/// </summary>
		/// <returns>��ɫ�б�</returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		IList<Role> GetAllRole();

		#endregion

		#region ɾ����ɫ

		/// <summary>
		/// ɾ����ɫ
		/// </summary>
		/// <param name="roleId">��ɫId</param>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		void DeleteRoleById(long roleId);

		#endregion

		#region Ȩ�������ϸ�б�

		/// <summary>
		/// Ȩ�������ϸ�б�
		/// </summary>
		///<returns>PermissionGroups</returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		IList<PermissionGroup> GetRolePermissionGroup();

		#endregion

		#region ��ȡ���е�Ȩ�����

		/// <summary>
		/// ��ȡ���е�Ȩ�����
		/// </summary>
		/// <returns>Ȩ������б�</returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		IList<Permission> GetAllPermission();

		#endregion

		#region ͨ����ɫid��ȡ��ǰ��ɫ������Ȩ����id

		/// <summary>
		/// ͨ����ɫid��ȡ��ǰ��ɫ������Ȩ����id
		/// </summary>
		/// <param name="roleId">��ɫId</param>
		/// <returns>Ȩ����id�б�</returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		IList<long> GetPermissionGroupIdListByRoleId(long roleId);

		#endregion

		#region ͨ��Ȩ����id��ȡΨһ��һ��Ȩ�����id

		/// <summary>
		/// ͨ��Ȩ����id��ȡΨһ��һ��Ȩ�����id
		/// </summary>
		/// <param name="permissionGroupId">Ȩ����Id</param>
		/// <returns>Ȩ�����Id</returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		long GetPermissionIdByPermissionGroupId(long permissionGroupId);

		#endregion

		#region ͨ����ɫid��ȡ��ǰ��ɫ

		/// <summary>
		/// ͨ����ɫid��ȡ��ǰ��ɫ
		/// </summary>
		/// <returns></returns>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		Role GetRoleById(long roleId);

		#endregion

		#region �����½�ɫ

		/// <summary>
		/// �����½�ɫ
		/// </summary>
		/// <param name="role">��ɫ</param>
		/// <param name="accessory">��ɫȨ�����Ȩ����ɵ������ַ�ƴ�� ����(1:5,2:5)</param>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		void InsertRole(Role role, string accessory);

		#endregion

		#region ���½�ɫ

		/// <summary>
		/// ���½�ɫ
		/// </summary>
		/// <param name="role">���µĽ�ɫ</param>
		/// <param name="accessory">��ɫȨ�����Ȩ����ɵ������ַ�ƴ�� ����(1:5,2:5)</param>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
		void UpdateRole(Role role, string accessory);

		#endregion
	}
}
