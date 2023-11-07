using System;
using Workflow.Da.Domain.Base;
using System.Collections.Generic;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table PERMISSION_GROUP对应的DotNet Object
	/// </summary>
	[Serializable]
	public class PermissionGroup : PermissionGroupBase
	{
		public PermissionGroup()
		{
		}

        private bool isChecked;
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }


        private long permissionId;
        /// <summary>
        /// 当前角色已经存在的权限许可,引目前表结构.每个角色的权限组下的权限许可只允许有1个.
        /// </summary>
        public long PermissionId
        {
            get { return permissionId; }
            set { permissionId = value; }
        }

        public long UsedPermissionId
        {
            get { return 5; }
        }
	}
}
