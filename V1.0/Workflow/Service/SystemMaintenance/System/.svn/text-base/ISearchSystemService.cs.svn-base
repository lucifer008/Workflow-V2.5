using System;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.SystemMaintenance.System
{
    /// <summary>
    /// 名    称: ISearchSystemService
    /// 功能概要: 获取系统基础数据接口
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:37:08
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public interface ISearchSystemService
    {
        #region//Id维护
        /// <summary>
        /// 名   称:  SearchIdGenerator
        /// 功能概要: 获取Id数据列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日10:42:26
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<IdGenerator> SearchIdGenerator(IdGenerator idGenerator);

        /// <summary>
        /// 名   称:  SearchIdGeneratorRowCount
        /// 功能概要: 获取Id数据列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日10:42:26
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchIdGeneratorRowCount(IdGenerator idGenerator);
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
        IList<ApplicationProperty> SearchApplictionPeroptery(ApplicationProperty applicationProperty);

        /// <summary>
        /// 名   称:  SearchApplictionPeropteryRowCount
        /// 功能概要: 获取应用参数信息列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日10:49:29
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchApplictionPeropteryRowCount(ApplicationProperty applicationProperty);
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
        IList<Company> SearchCompany(Company company);

        /// <summary>
        /// 名    称：SearchCompany
        /// 功能概要：获取公司信息列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日13:24:38
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        long SearchCompanyRowCount(Company company);

        /// <summary>
        /// 名    称：CheckCompanyIsUsed
        /// 功能概要：检查公司是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日13:24:38
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        long CheckCompanyIsUsed(long companyId);
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

       #region//会员积分设置
        /// <summary>
        /// 名   称:  SearchMarking
        /// 功能概要: 获取积分列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日11:32:18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<MarkingSetting> SearchMarkingSetting(MarkingSetting markingSetting);

        /// <summary>
        /// 名   称:  SearchMarkingSettingRowCount
        /// 功能概要: 获取积分列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日11:32:18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchMarkingSettingRowCount(MarkingSetting markingSetting);
       #endregion 
   }
}
