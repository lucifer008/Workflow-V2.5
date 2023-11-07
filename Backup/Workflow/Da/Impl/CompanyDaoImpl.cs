using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table COMPANY ��Ӧ��Dao ʵ��
	/// </summary>
    public class CompanyDaoImpl : Workflow.Da.Base.DaoBaseImpl<Company>, ICompanyDao
    {
        #region//��˾��Ϣά��
        /// <summary>
        /// ��    �ƣ�SearchCompany
        /// ���ܸ�Ҫ����ȡ��˾��Ϣ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��13:24:38
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public IList<Company> SearchCompany(Company company) 
        {
            company.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            company.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Company>("Company.SearchCompany", company);
        }

        /// <summary>
        /// ��    �ƣ�SearchCompany
        /// ���ܸ�Ҫ����ȡ��˾��Ϣ�б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��13:24:38
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public long SearchCompanyRowCount(Company company) 
        {
            return sqlMap.QueryForObject<long>("Company.SearchCompanyRowCount", company);
        }

        /// <summary>
        /// ��    �ƣ�CheckCompanyIsUsed
        /// ���ܸ�Ҫ����鹫˾�Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��13:24:38
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public long CheckCompanyIsUsed(long companyId) 
        {
            Company company = new Company();
            company.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            company.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            company.Id = companyId;
            return sqlMap.QueryForObject<long>("Company.CheckCompanyIsUsed", company);
        }
        #endregion
    }
}
