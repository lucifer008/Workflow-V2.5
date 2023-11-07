using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ROLE ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IRoleDao : IDaoBase<Role>
    {
		/// <summary>
		/// ��ȡ���н�ɫ
		/// </summary>
		/// <param name="role"></param>
		IList<Role> GetRoleList();

    }
}
