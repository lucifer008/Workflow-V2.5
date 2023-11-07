/*----------------------------------------------------------------
// Copyright (C) 2004 PHOOK
// 版权所有。 
//          角色Model
// 文件名：RoleModel.cs
// 文件功能描述：Workflow.Action.Roles
// 
// 创建标识：陈汝胤  2009.1.15
//
// 修改标识：
// 修改描述：
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
        /// 角色一栏
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
        /// 是否成功
        /// </summary>
        public bool IsSucceed
        {
            get { return isSucceed; }
            set { isSucceed = value; }
        }

        private IList<PermissionGroup> permissionGroupList;
        /// <summary>
        /// 权限组的详细列表
        /// </summary>
        public IList<PermissionGroup> PermissionGroupList
        {
            get { return permissionGroupList; }
            set { permissionGroupList = value; }
        }

        private string action;
        /// <summary>
        /// 当前动作
        /// </summary>
        public string Action
        {
            get
            {
                if (null == action)
                    return "添加";
                return action;
            }
            set { action = value; }
        }

        private string name;
        /// <summary>
        /// 角色描述
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
        /// 附件
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
        /// 权限许可
        /// </summary>
        public IList<Workflow.Da.Domain.Permission> PermissionList
        {
            get { return permissionList; }
            set { permissionList = value; }
        }
    }
}
