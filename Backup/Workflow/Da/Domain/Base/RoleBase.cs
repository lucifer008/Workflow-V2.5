using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ROLE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class RoleBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 权限标示 [PERMISSION_VALUES] */
		private string permissionValues;

		public RoleBase()
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
		/// 权限标示 [PERMISSION_VALUES]
		/// </summary>
		public virtual string PermissionValues
		{
			get { return this.permissionValues; }
			set { this.permissionValues = value; }
		}

		private IList<Workflow.Da.Domain.PermissionGroup> permissionGroupList;
		/// <summary>
		/// Source Table[ROLE] Column[ID] --> Target Table[PERMISSION_GROUP] Column[ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.PermissionGroup> PermissionGroupList
		{
			get { return permissionGroupList; }
			set { permissionGroupList = value; }
		}

	}
}
