using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Common.Logging;
using System.Reflection;
using Workflow.Support.Security;

namespace Workflow.Support.Spring
{
	public class SecurityInterceptor : IInterceptor
	{
		private static readonly ILog LOG = LogManager.GetLogger(typeof(SecurityInterceptor));
		#region IInterceptor 成员

		private Type actionClass;
		public SecurityInterceptor(Type type)
		{
			this.actionClass = type;
		}
		public object Intercept(IInvocation invocation, params object[] args)
		{
			MethodInfo mi = invocation.Method;

			StringBuilder buffer = new StringBuilder();
			buffer.Append(actionClass.FullName);
			buffer.Append(".");
			buffer.Append(mi.Name);
			buffer.Append(":");
			buffer.Append("execute");
			string permissionValue = buffer.ToString();
			if (LOG.IsDebugEnabled)
			{
				LOG.Debug("检查用户权限 + " + permissionValue);
			}
			IPermission permission = PermissionFactory.GetPermission(permissionValue);

			return invocation.Proceed(args);
		}

		#endregion
	}
}
