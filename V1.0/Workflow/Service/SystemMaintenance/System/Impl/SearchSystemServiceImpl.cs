using System;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;

namespace Workflow.Service.SystemMaintenance.System.Impl
{
    /// <summary>
    /// 名    称: SearchSystemServiceImpl
    /// 功能概要: 获取系统基础数据接口实现
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:37:08
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public class SearchSystemServiceImpl:ISearchSystemService
    {
      
        #region//注入Dao
        private IIdGeneratorDao idGeneratorDao;
        public IIdGeneratorDao IdGeneratorDao 
        {
            set { idGeneratorDao = value; }
        }

        private IApplicationPropertyDao applicationPropertyDao;
        public IApplicationPropertyDao ApplicationPropertyDao
        {
            set { applicationPropertyDao = value; }
        }

        private ICompanyDao companyDao;
        public ICompanyDao CompanyDao 
        {
            set { companyDao = value; }
        }

        private IBranchShopDao branchShopDao;
        public IBranchShopDao BranchShopDao 
        {
            set { branchShopDao = value; }
        }

        private IMarkingSettingDao markingSettingDao;
        public IMarkingSettingDao MarkingSettingDao 
        {
            set { markingSettingDao = value; }
        }
        #endregion

        #region //Id维护
        /// <summary>
        /// 名   称:  SearchIdGenerator
        /// 功能概要: 获取Id数据列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日10:42:26
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<IdGenerator> SearchIdGenerator(IdGenerator idGenerator) 
        {
            return idGeneratorDao.SearchIdGenerator(idGenerator); ;
        }

        /// <summary>
        /// 名   称:  SearchIdGeneratorRowCount
        /// 功能概要: 获取Id数据列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日10:42:26
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchIdGeneratorRowCount(IdGenerator idGenerator) 
        {
            return idGeneratorDao.SearchIdGeneratorRowCount(idGenerator) ;
        }
        #endregion

        #region//应用参数维护
        /// <summary>
        /// 名   称:  SearchApplictionPeroptery
        /// 功能概要: 获取应用参数信息列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日10:49:29
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<ApplicationProperty> SearchApplictionPeroptery(ApplicationProperty applicationProperty) 
        {
            return applicationPropertyDao.SearchApplictionPeroptery(applicationProperty);
        }

        /// <summary>
        /// 名   称:  SearchApplictionPeropteryRowCount
        /// 功能概要: 获取应用参数信息列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日10:49:29
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchApplictionPeropteryRowCount(ApplicationProperty applicationProperty) 
        {
            return applicationPropertyDao.SearchApplictionPeropteryRowCount(applicationProperty);
        }
        #endregion

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
            return companyDao.SearchCompany(company);
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
            return companyDao.SearchCompanyRowCount(company);
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
            return companyDao.CheckCompanyIsUsed(companyId);
        }
        #endregion

        #region//分店信息维护
        /// <summary>
        /// 名   称:  SearchBranchShop
        /// 功能概要: 获取分店信息列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:39:44
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<BranchShop> SearchBranchShop(BranchShop branchShop) 
        {
            return branchShopDao.SearchBranchShop(branchShop);
        }

        /// <summary>
        /// 名   称:  SearchBranchShopRowCount
        /// 功能概要: 获取分店信息列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:39:44
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchBranchShopRowCount(BranchShop branchShop) 
        {
            return branchShopDao.SearchBranchShopRowCount(branchShop);
        }
        #endregion

        #region//会员积分设置
        /// <summary>
        /// 名   称:  SearchMarking
        /// 功能概要: 获取积分列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日11:32:18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<MarkingSetting> SearchMarkingSetting(MarkingSetting markingSetting) 
        {
            return markingSettingDao.SearchMarkingSetting(markingSetting);
        }

        /// <summary>
        /// 名   称:  SearchMarkingSettingRowCount
        /// 功能概要: 获取积分列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日11:32:18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchMarkingSettingRowCount(MarkingSetting markingSetting) 
        {
            return markingSettingDao.SearchMarkingSettingRowCount(markingSetting);
        }
        #endregion
    }
}
