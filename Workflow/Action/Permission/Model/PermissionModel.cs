using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Action.Permission.Model
{
    /// <summary>
    /// 名    称: PermissionModel
    /// 功能概要: 操作管理的Action
    /// 作    者: 张晓林
    /// 创建时间: 2009-01-23
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class PermissionModel
    {
        private Workflow.Da.Domain.Permission permission;
        public Workflow.Da.Domain.Permission Permission
        {
            set { permission = value; }
            get { return permission; }
        }

        private IList<Workflow.Da.Domain.Permission> permissionList;
        public IList<Workflow.Da.Domain.Permission> PermissionList 
        {
            set { permissionList = value; }
            get { return permissionList; }
        }

        private PermissionGroup permissionGroup = new PermissionGroup();
        public PermissionGroup PermissionGroup 
        {
            set { permissionGroup = value; }
            get { return permissionGroup; }
        }

        private IList<PermissionGroup> permissionGroupList;
        public IList<PermissionGroup> PermissionGroupList 
        {
            set { permissionGroupList = value; }
            get { return permissionGroupList; }
        }

        private long rowCount;
        public long RowCount 
        {
            set { rowCount = value; }
            get { return rowCount; }
        }
    }
}
