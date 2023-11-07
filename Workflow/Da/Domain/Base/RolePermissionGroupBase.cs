#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ROLE_PERMISSION_GROUP (角色权限许可组) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class RolePermissionGroupBase
	{
		
		#region Id
		/* ID [ID] */
		private long id;
		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return id ;	}
			set { id=value;		}	
		}
		#endregion
		
		#region RoleId
		/* 角色_ID [ROLE_ID] */
		private long roleId;
		/// <summary>
		/// 角色_ID [ROLE_ID]
		/// </summary>
		public virtual long RoleId
		{
			get { return roleId ;	}
			set { roleId=value;		}	
		}
		#endregion
		
		#region PermissionGroupId
		/* 权限许可组_ID [PERMISSION_GROUP_ID] */
		private long permissionGroupId;
		/// <summary>
		/// 权限许可组_ID [PERMISSION_GROUP_ID]
		/// </summary>
		public virtual long PermissionGroupId
		{
			get { return permissionGroupId ;	}
			set { permissionGroupId=value;		}	
		}
		#endregion
	}
}