using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table COMPANY 对应的Dao 实现
	/// </summary>
    public class CompanyDaoImpl : Workflow.Da.Base.DaoBaseImpl<Company>, ICompanyDao
    {
        #region//公司信息维护
        /// <summary>
        /// 名    称：SearchCompany
        /// 功能概要：获取公司信息列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日13:24:38
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public IList<Company> SearchCompany(Company company) 
        {
            company.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            company.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Company>("Company.SearchCompany", company);
        }

        /// <summary>
        /// 名    称：SearchCompany
        /// 功能概要：获取公司信息列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日13:24:38
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public long SearchCompanyRowCount(Company company) 
        {
            return sqlMap.QueryForObject<long>("Company.SearchCompanyRowCount", company);
        }

        /// <summary>
        /// 名    称：CheckCompanyIsUsed
        /// 功能概要：检查公司是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日13:24:38
        /// 修正履历:
        /// 修正时间：
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
