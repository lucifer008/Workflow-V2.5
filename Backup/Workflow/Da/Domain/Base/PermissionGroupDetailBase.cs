using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PERMISSION_GROUP_DETAIL 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class PermissionGroupDetailBase 
	{
		/** ID [ID] */
		private long id;
		/** 权限许可_ID [PERMISSION_ID] */
		private long permissionId;
		/** 权限许可组_ID [PERMISSION_GROUP_ID] */
		private long permissionGroupId;

		public PermissionGroupDetailBase()
		{
			
		}

		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return this.id; }
			set { this.id = value; }
		}
		/// <summary>
		/// 权限许可_ID [PERMISSION_ID]
		/// </summary>
		public virtual long PermissionId
		{
			get { return this.permissionId; }
			set { this.permissionId = value; }
		}
		/// <summary>
		/// 权限许可组_ID [PERMISSION_GROUP_ID]
		/// </summary>
		public virtual long PermissionGroupId
		{
			get { return this.permissionGroupId; }
			set { this.permissionGroupId = value; }
		}


	}
}
