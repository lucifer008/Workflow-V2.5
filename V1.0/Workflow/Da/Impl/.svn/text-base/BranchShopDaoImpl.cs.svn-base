using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table BRANCH_SHOP 对应的Dao 实现
	/// </summary>
    public class BranchShopDaoImpl : Workflow.Da.Base.DaoBaseImpl<BranchShop>, IBranchShopDao
    {
        /// <summary>
        /// 通过CompanyId获取其下所有分店信息
        /// </summary>
        /// <param name="companyId">公司ID</param>
        /// <returns></returns>
        public IList<BranchShop> GetBranchShopListByCompanyId(long companyId)
        {
            return sqlMap.QueryForList<BranchShop>("BranchShop.SelectBranchShopByCompanyId", companyId);
        }

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
            //branchShop.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            //branchShop.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<BranchShop>("BranchShop.SearchBranchShop", branchShop);
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
            return sqlMap.QueryForObject<long>("BranchShop.SearchBranchShopRowCount", branchShop);
        }
        #endregion
    }
}
