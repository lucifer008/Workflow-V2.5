using System;
using System.Collections.Generic;
using Workflow.Service.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;
using Workflow.Service;
using Workflow.Service.SystemManege.PriceManage;

namespace Workflow.Action.SystemMaintenance.System
{
    /// <summary>
    /// 名   称:  SystemAction
    /// 功能概要: 系统基础数据管理Action
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:30:01
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class SystemAction
    {
        #region//ClassMember
        private SystemModel model = new SystemModel();
        public SystemModel Model 
        {
            set { model = value; }
            get { return model; }
        }
        private ISystemService systemService;
        public ISystemService SystemService 
        {
            set { systemService = value; }
        }

        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }

        private ISelectActiveFactorService selectActiveFactorService;
        public ISelectActiveFactorService SelectActiveFactorService
        {
            set { selectActiveFactorService = value; }
        }
        #endregion

        #region// Id维护

        /// <summary>
        /// 名    称：InitIdData
        /// 功能概要：初始化Id数据
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日13:46:34
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void InitIdData() 
        {
            systemService.InitIdData();
        }

        /// <summary>
        /// 名    称：UpdateIdGenerator
        /// 功能概要：更新Id生成器数据
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日16:19:48
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateIdGenerator()
        {
            systemService.UpdateIdGenerator(model.IdGenerator);
        }

          /// <summary>
        /// 名    称：DeleteIdGenerator
        /// 功能概要：删除Id生成器数据
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日16:19:48
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void DeleteIdGenerator() 
        {
            systemService.DeleteIdGenerator(model.IdGenerator.Id);
        }
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
        public void AddApplicationProperty() 
        {
            systemService.AddApplicationProperty(model.ApplicationProperty);
        }

        /// <summary>
        /// 名    称：UpdateApplicationProperty
        /// 功能概要：更新应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateApplicationProperty()
        {
            systemService.UpdateApplicationProperty(model.ApplicationProperty);
        }

        /// <summary>
        /// 名    称：LogicDeleteApplicationProperty
        /// 功能概要：逻辑删除应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void LogicDeleteApplicationProperty()
        {
            systemService.LogicDeleteApplicationProperty(model.ApplicationProperty.Id);
        }

        /// <summary>
        /// 名    称：InitApplicationPropertyData
        /// 功能概要：初始化应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void InitApplicationPropertyData() 
        {
            systemService.InitApplicationPropertyData();
        }
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
        public void AddCompany()
        {
            systemService.AddCompany(model.Company);
        }

        /// <summary>
        /// 名    称：UpdateCompany
        /// 功能概要：更新公司
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日14:31:19
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateCompany()
        {
            systemService.UpdateCompany(model.Company);
        }

        /// <summary>
        /// 名    称：LogicDeleteCompany
        /// 功能概要：逻辑删除公司
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日14:31:19
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void LogicDeleteCompany()
        {
            systemService.LogicDeleteCompany(model.Company.Id);
        }

		/// <summary>
		/// 名    称：GetCompanyInfo
		/// 功能概要：获取公司信息
		/// 作    者: 白晓宇
		/// 创建时间: 2010年4月28日16:07:19
		/// 修正履历:
		/// 修正时间：
		/// </summary>
		public void GetCompanyInfo()
		{
			model.Company = systemService.GetCompanyInfo(model.CompanyId);
		}
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
        public void AddBranchShop() 
        {
            systemService.AddBranchShop(model.BranchShop);
        }

        /// <summary>
        /// 名    称：UpdateBranchShop
        /// 功能概要：修改分店信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:50:59
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateBranchShop()
        {
            systemService.UpdateBranchShop(model.BranchShop);
        }

        /// <summary>
        /// 名    称：LogicDeleteBranchShop
        /// 功能概要：逻辑删除分店信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:50:59
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void LogicDeleteBranchShop()
        {
            systemService.LogicDeleteBranchShop(model.BranchShop.Id);
        }

		/// <summary>
		/// 名    称：GetBranchShopInfo
		/// 功能概要：获取分店信息
		/// 作    者: 白晓宇
		/// 创建时间: 2010年4月28日16:07:19
		/// 修正履历:
		/// 修正时间：
		public void GetBranchShopInfo()
		{
			model.BranchShop = systemService.GetBranchShopInfo(model.BranchShopId);
		}
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
        public void AddMarkingSetting() 
        {
            systemService.AddMarkingSetting(model.MarkingSetting);
        }
        /// <summary>
        /// 名    称：UpdateMarkingSetting
        /// 功能概要：更新积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日13:26:25
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateMarkingSetting()
        {
            systemService.UpdateMarkingSetting(model.MarkingSetting);
        }

        /// <summary>
        /// 名    称：DeleteMarkingSetting
        /// 功能概要：删除积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日13:26:25
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void DeleteMarkingSetting()
        {
            systemService.DeleteMarkingSetting(model.MarkingSetting);
        }
        #endregion

        #region 获取业务类型
        /// <summary>
        /// 名    称; GetBusinessTypeList
        /// 功能概要: 获取业务类型
        /// 作    者: 白晓宇
        /// 创建时间: 2010年06-29 
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        public void GetBusinessTypeList()
        {
            model.BusinessTypeList = masterDataService.GetBusinessTypes();
        }
        #endregion

        #region 获取价格因素
        /// <summary>
        /// 获取价格因素
        /// </summary>
        public void GetPriceFactor()
        {
            model.PriceFactor = selectActiveFactorService.GetPriceFactor();
        }
        #endregion

        #region 获取开单默认数据
        /// <summary>
        /// 名    称: GetDefaultData
        /// 功能概要: 获取开单默认数据
        /// 作    者: 白晓宇
        /// 创建时间: 2010年7月1日
        /// </summary>
        public void GetDefaultData()
        {
            model.ApplicationProperty = systemService.GetDefaultPriceFactor();
        }
        #endregion

        #region 获取应用程序参数
        /// <summary>
        /// 名    称: GetApplicationProperty
        /// 功能概要: 获取应用程序参数
        /// 作    者: 白晓宇
        /// 创建时间: 2010年7月1日15:57:07
        /// </summary>
        /// <param name="applicationPropertyId"></param>
        public void GetApplicationProperty(long applicationPropertyId)
        {
            model.ApplicationProperty = systemService.GetApplicationProperty(applicationPropertyId);
        }
        #endregion

        #region 修改应用程序参数
        /// <summary>
        /// 名    称: EditApplicationProperty
        /// 功能概要: 修改应用程序参数
        /// 作    者: 白晓宇 
        /// 创建时间: 2010年7月2日 9:52:57
        /// </summary>
        public void EditApplicationProperty()
        {
            systemService.EditApplicationProperty(model.ApplicationProperty);
        }
        #endregion

        #region 获取所有可用的价格因素
        /// <summary>
        /// 名    称: GetPriceFactorList
        /// 功能概要: 获取所有可用的价格因素 
        /// 作    者: 白晓宇
        /// 创建时间: 2010年7月3日 10:52:06
        /// </summary>
        /// <param name="businessTypeId"></param>
        public IList<Workflow.Da.Domain.PriceFactor> GetPriceFactorList(long businessTypeId)
        {
            return masterDataService.GetPriceFactors();
        }
        #endregion

        #region 获取价格因素描述
        /// <summary>
        /// 名    称: GetFactorValueText
        /// 功能概要: 获取价格因素描述 
        /// 作    者: 白晓宇
        /// 创建时间: 2010年7月3日 10:59:46  
        /// </summary>
        /// <param name="priceFactor"></param>
        /// <returns></returns>
        public string GetFactorValueText(Workflow.Da.Domain.PriceFactor priceFactor)
        {
            return masterDataService.GetFactorValueText(priceFactor);
        }
        #endregion
    }
}
