using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Support.Security
{
	public class CommonPermission : IPermission
	{
		private long id;
		private string name;
		private string actions;
		public CommonPermission(string value)
		{
			InitPermission(value);
		}
		private void InitPermission(string value)
		{
			int splitPos = value.IndexOf(':');
			if (splitPos > 0)
			{
				name = value.Substring(0, splitPos).ToLower().Trim();
				actions = value.Substring(splitPos + 1).ToLower().Trim();
			}
			else
			{
				name = value.Substring(0, splitPos + 1).ToLower().Trim();
				actions = value.Substring(splitPos + 1).ToLower().Trim();
			}
		}
		public CommonPermission(Permission perm)
		{
			id = perm.Id;
			string permissionValues = perm.PermissionIdentity + ":" + PermissionName(perm.PermissionType);
			InitPermission(permissionValues);
		}

		/// <summary>
		/// 转化标示符代表的权限
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		private string PermissionName(string type)
		{
			if ("*" == type)
				return type;
			else if ("1" == type)
				return "execute";
			else
				return "unexecute";
		}
		#region IPermission 成员

		public string Name
		{
			get { return name; }
		}

		public string Actions
		{
			get { return actions; }
		}

		public virtual bool Implies(IPermission permission)
		{
			if (this == permission)
			{
				return true;
			}

			if (permission.Name.StartsWith(this.name))
			{
				if ("*".Equals(actions) || this.actions.Equals(permission.Actions))
				{
					return true;
				}
			}
			if (!name.Equals(permission.Name))
			{
				return false;
			}

			if ("*".Equals(actions))
			{
				return true;
			}

			return actions == permission.Actions;
		}

		#endregion

		public override bool Equals(object target)
		{
			return this == target;
		}

		#region IPermission 成员

		public long Id
		{
			get { return id ; }
		}

		#endregion
	}
}
