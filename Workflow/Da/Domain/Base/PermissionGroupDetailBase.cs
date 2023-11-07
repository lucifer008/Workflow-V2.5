using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PERMISSION_GROUP_DETAIL ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class PermissionGroupDetailBase 
	{
		/** ID [ID] */
		private long id;
		/** Ȩ�����_ID [PERMISSION_ID] */
		private long permissionId;
		/** Ȩ�������_ID [PERMISSION_GROUP_ID] */
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
		/// Ȩ�����_ID [PERMISSION_ID]
		/// </summary>
		public virtual long PermissionId
		{
			get { return this.permissionId; }
			set { this.permissionId = value; }
		}
		/// <summary>
		/// Ȩ�������_ID [PERMISSION_GROUP_ID]
		/// </summary>
		public virtual long PermissionGroupId
		{
			get { return this.permissionGroupId; }
			set { this.permissionGroupId = value; }
		}


	}
}
