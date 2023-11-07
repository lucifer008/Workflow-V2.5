using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ROLE 对应的Dao 接口
	/// </summary>
    public interface IRoleDao : IDaoBase<Role>
    {
		/// <summary>
		/// 获取所有角色
		/// </summary>
		/// <param name="role"></param>
		IList<Role> GetRoleList();

    }
}
