using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Workflow.Support.Security
{
	public class PermissionFactory
	{
		private static Hashtable permissions = new Hashtable();

		public static IPermission GetPermission(string value)
		{
			IPermission permission = (IPermission)permissions[value];
			if (permission == null)
			{
				lock (permissions)
				{
					permission = (IPermission)permissions[value];
					if (permission == null)
					{
						permission = new CommonPermission(value);
						permissions[value] = permission;
					}
				}
			}
				
			return permission;
		}
	}
}
