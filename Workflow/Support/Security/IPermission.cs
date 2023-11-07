using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Support.Security
{
	public interface IPermission
	{
		/// <summary>
		/// 对应数据库中的ID
		/// </summary>
		long Id
		{
			get;
		}
		/// <summary>
		/// 获取权限名称
		/// </summary>
		string Name
		{
			get;
		}

		/// <summary>
		/// 获取权限可以执行的动作
		/// </summary>
		string Actions
		{
			get;
		}

		/// <summary>
		/// 检查指定的权限的动作是否在目前对象中默认包含
		/// </summary>
		/// <param name="permission"></param>
		/// <returns></returns>
		bool Implies(IPermission permission);

	}
}
