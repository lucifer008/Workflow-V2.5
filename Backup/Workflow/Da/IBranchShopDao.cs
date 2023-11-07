using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table BRANCH_SHOP 对应的Dao 接口
	/// </summary>
    public interface IBranchShopDao : IDaoBase<BranchShop>
    {
        /// <summary>
        /// 通过CompanyId获取其下所有分店信息
        /// </summary>
        /// <param name="companyId">公司ID</param>
        /// <returns></returns>
        IList<BranchShop> GetBranchShopListByCompanyId(long companyId);

        #region//分店信息维护
        /// <summary>
        /// 名   称:  SearchBranchShop
        /// 功能概要: 获取分店信息列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:39:44
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<BranchShop> SearchBranchShop(BranchShop branchShop);

        /// <summary>
        /// 名   称:  SearchBranchShopRowCount
        /// 功能概要: 获取分店信息列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:39:44
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchBranchShopRowCount(BranchShop branchShop);
        #endregion
    }
}
