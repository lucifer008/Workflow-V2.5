using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Service.SystemPermission.RoleManage;
/// <summary>
/// ���ܸ�Ҫ: ��ɫAction
/// ��    ��: ����ط
/// ����ʱ��: 2009-1-15
/// �� �� ��: 
/// ����ʱ��: 
/// ��������: 
/// </summary>

namespace Workflow.Action.Roles
{
    public class RoleAction
	{
		#region ���Ա
		
		#region RoleModel model
		private RoleModel model = new RoleModel();
        public RoleModel Model
        {
            get { return model; }
		}
		#endregion
		
		#region ע�� roleService

		private IRoleService roleService;
        /// <summary>
        /// ע��roleService
        /// </summary>
        public IRoleService RoleService
        {
            set { roleService = value; }
        }

        #endregion
		
		#endregion

		#region ��ȡ��λһ��
		/// <summary>
		/// ��ȡ��λһ��		
		/// </summary>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15
        public void GetRoleList()
        {
            model.RoleList=roleService.GetAllRole();
        }
		#endregion

		#region ɾ����ɫ
		/// <summary>
        /// ɾ����ɫ
        /// </summary>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15 
        public void DeleteRoleById()
        {
            roleService.DeleteRoleById(model.Id);
        }
		#endregion

		#region ��ȡȨ��Ĭ���б�
		/// <summary>
        /// ��ȡȨ��Ĭ���б�
        /// </summary>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15 
        public void GetRolePermissionGroup()
        {
            model.PermissionGroupList = roleService.GetRolePermissionGroup();

            model.PermissionList = roleService.GetAllPermission();
        }
		#endregion

		#region ͨ����ɫid��ȡ��ǰ��ɫ,����ȡ����,���󶨵�ǰ��ɫ
		/// <summary>
        /// ͨ����ɫid��ȡ��ǰ��ɫ,����ȡ����,���󶨵�ǰ��ɫ
        /// </summary>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15 
        public void GetRoleUserdPermissionGroup()
        {
            IList<long> permissionGroupList = roleService.GetPermissionGroupIdListByRoleId(model.Id);
            if (null != model.PermissionGroupList && permissionGroupList.Count > 0)
            {
                foreach (PermissionGroup permissionGroup in model.PermissionGroupList)
                {
                    //�����ǰ�Ľ�ɫ�ĵ�ǰȨ�������
                    if (permissionGroupList.Contains(permissionGroup.Id))
                    {
                        //����Ψһ��һ��Ȩ����ɵ�id
                        permissionGroup.PermissionId = roleService.GetPermissionIdByPermissionGroupId(permissionGroup.Id);
                        permissionGroup.IsChecked = true;
                    }
                }
            }
        }
		#endregion

		#region ��ȡ��ɫͨ����ɫid
		/// <summary>
        /// ��ȡ��ɫͨ����ɫid
        /// </summary>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15 
        public void GetRoleByRoleId()
        {
            Role role = roleService.GetRoleById(model.Id);
            model.Name = role.PermissionValues;
            model.Role = role;
        }
		#endregion

		#region �����½�ɫ
		/// <summary>
        /// �����½�ɫ
        /// </summary>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15 
        public void InsertRole()
        {
            Role role = new Role();
            role.PermissionValues = model.Name;
            roleService.InsertRole(role,model.Accessory);
        }
		#endregion

		#region ���½�ɫ
		/// <summary>
        /// ���½�ɫ
        /// </summary>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-1-15 
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
