using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ROLE ��Ӧ��Dao ʵ��
	/// </summary>
    public class RoleDaoImpl : Workflow.Da.Base.DaoBaseImpl<Role>, IRoleDao
    {
		public IList<Role> GetRoleList()
		{
			//�������ݿ� 
			Role role = new Role();
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			role.BranchShopId = user.BranchShopId;
			role.CompanyId = user.CompanyId;

			return base.sqlMap.QueryForList<Role>("Role.SelectAll", role);
		}
    }
}
