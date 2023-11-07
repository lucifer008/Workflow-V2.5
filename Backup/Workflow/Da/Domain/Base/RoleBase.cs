using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ROLE ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class RoleBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** Ȩ�ޱ�ʾ [PERMISSION_VALUES] */
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
		/// Ȩ�ޱ�ʾ [PERMISSION_VALUES]
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
