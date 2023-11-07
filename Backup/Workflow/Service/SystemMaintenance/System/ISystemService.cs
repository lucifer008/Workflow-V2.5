using System;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.SystemMaintenance.System
{
    /// <summary>
    /// 名    称: ISystemService
    /// 功能概要: 系统基础数据管理接口
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:37:08
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public interface ISystemService
    {
        #region//Id维护

        /// <summary>
        /// 名    称：InitIdData
        /// 功能概要：初始化Id数据
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日13:46:34
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void InitIdData();

        /// <summary>
        /// 名    称：UpdateIdGenerator
        /// 功能概要：更新Id生成器数据
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日16:19:48
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void UpdateIdGenerator(IdGenerator idGenerator);

        /// <summary>
        /// 名    称：DeleteIdGenerator
        /// 功能概要：删除Id生成器数据
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日16:19:48
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void DeleteIdGenerator(long idGeneratorId);
        #endregion

        #region//应用程序参数维护
        /// <summary>
        /// 名    称：AddApplicationProperty
        /// 功能概要：添加应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void AddApplicationProperty(ApplicationProperty applicationProperty);

        /// <summary>
        /// 名    称：UpdateApplicationProperty
        /// 功能概要：更新应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void UpdateApplicationProperty(ApplicationProperty applicationProperty);

        /// <summary>
        /// 名    称：LogicDeleteApplicationProperty
        /// 功能概要：逻辑删除应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void LogicDeleteApplicationProperty(long applicationPropertyId);

        /// <summary>
        /// 名    称：InitApplicationPropertyData
        /// 功能概要：初始化应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void InitApplicationPropertyData();

        #endregion

        #region//公司维护
        /// <summary>
        /// 名    称：AddCompany
        /// 功能概要：添加公司
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日14:31:19
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void AddCompany(Company company);

        /// <summary>
        /// 名    称：UpdateCompany
        /// 功能概要：更新公司
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日14:31:19
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void UpdateCompany(Company company);

        /// <summary>
        /// 名    称：LogicDeleteCompany
        /// 功能概要：逻辑删除公司
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日14:31:19
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void LogicDeleteCompany(long companyId);

		/// <summary>
		/// 名    称：GetCompanyInfo
		/// 功能概要：获取公司信息
		/// 作    者: 白晓宇
		/// 创建时间: 2010年4月28日16:07:19
		/// 修正履历:
		/// 修正时间：
		/// </summary>
		/// <param name="companyId">公司Id</param>
		Company GetCompanyInfo(long companyId);
        #endregion

        #region//分店信息维护
        /// <summary>
        /// 名    称：AddBranchShop
        /// 功能概要：添加分店信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:50:59
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void AddBranchShop(BranchShop branchShop);

        /// <summary>
        /// 名    称：UpdateBranchShop
        /// 功能概要：修改分店信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:50:59
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void UpdateBranchShop(BranchShop branchShop);

        /// <summary>
        /// 名    称：LogicDeleteBranchShop
        /// 功能概要：逻辑删除分店信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:50:59
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void LogicDeleteBranchShop(long branchShop);

		/// <summary>
		/// 名    称：GetBranchShopInfo
		/// 功能概要：获取分店信息
		/// 作    者: 白晓宇
		/// 创建时间: 2010年4月28日16:07:19
		/// 修正履历:
		/// 修正时间：
		/// <param name="branchShopId">分店Id</param>
		BranchShop GetBranchShopInfo(long branchShopId);
        #endregion

        #region//积分信息维护

        /// <summary>
        /// 名    称：AddMarkingSetting
        /// 功能概要：增加积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日13:26:25
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void AddMarkingSetting(MarkingSetting markingSetting);
        /// <summary>
        /// 名    称：UpdateMarkingSetting
        /// 功能概要：更新积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日13:26:25
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void UpdateMarkingSetting(MarkingSetting markingSetting);

        /// <summary>
        /// 名    称：DeleteMarkingSetting
        /// 功能概要：删除积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日13:26:25
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void DeleteMarkingSetting(MarkingSetting markingSetting);
        #endregion

        /// <summary>
        /// 名    称: 
        /// 功能概要: 获取开单默认值
        /// 创建时间: 2010年07月01 
        /// 作    者: 白晓宇
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        ApplicationProperty GetDefaultPriceFactor();

        /// <summary>
        /// 名    称: GetApplicationProperty
        /// 功能概要: 获取应用程序参数
        /// 创建时间: 2010年7月1日
        /// 作    者: 白晓宇
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApplicationProperty GetApplicationProperty(long id);

        /// <summary>
        /// 名    称: EditApplicationProperty
        /// 功能概要: 修改应用程序参数
        /// 创建时间: 2010年7月2日 9:47:53
        /// 作    者: 白晓宇
        /// 修 正 人:
        /// 修正时间:
        /// </summary>
        /// <param name="applicationProperty"></param>
        void EditApplicationProperty(ApplicationProperty applicationProperty);
    }
}
