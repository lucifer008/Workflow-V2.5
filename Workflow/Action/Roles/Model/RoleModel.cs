/*----------------------------------------------------------------
// Copyright (C) 2004 PHOOK
// ��Ȩ���С� 
//          ��ɫModel
// �ļ�����RoleModel.cs
// �ļ�����������Workflow.Action.Roles
// 
// ������ʶ������ط  2009.1.15
//
// �޸ı�ʶ��
// �޸�������
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Action.Roles
{
    public class RoleModel
    {
        private IList<Role> roleList;
        /// <summary>
        /// ��ɫһ��
        /// </summary>
        public IList<Role> RoleList
        {
            get { return roleList; }
            set { roleList = value; }
        }

        private long id;
        /// <summary>
        /// id
        /// </summary>
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private bool isSucceed;
        /// <summary>
        /// �Ƿ�ɹ�
        /// </summary>
        public bool IsSucceed
        {
            get { return isSucceed; }
            set { isSucceed = value; }
        }

        private IList<PermissionGroup> permissionGroupList;
        /// <summary>
        /// Ȩ�������ϸ�б�
        /// </summary>
        public IList<PermissionGroup> PermissionGroupList
        {
            get { return permissionGroupList; }
            set { permissionGroupList = value; }
        }

        private string action;
        /// <summary>
        /// ��ǰ����
        /// </summary>
        public string Action
        {
            get
            {
                if (null == action)
                    return "���";
                return action;
            }
            set { action = value; }
        }

        private string name;
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string Name
        {
            get
            {
                if (null == name)
                    return "";
                return name;
            }
            set { name = value; }
        }

        private string accessory;
        /// <summary>
        /// ����
        /// </summary>
        public string Accessory
        {
            get { return accessory; }
            set { accessory = value; }
        }

        private Role role;
        /// <summary>
        /// role
        /// </summary>
        public Role Role
        {
            get { return role; }
            set { role = value; }
        }

        private IList<Workflow.Da.Domain.Permission> permissionList;
        /// <summary>
        /// Ȩ�����
        /// </summary>
        public IList<Workflow.Da.Domain.Permission> PermissionList
        {
            get { return permissionList; }
            set { permissionList = value; }
        }
    }
}
