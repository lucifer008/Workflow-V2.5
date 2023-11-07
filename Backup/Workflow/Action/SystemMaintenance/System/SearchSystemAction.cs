using System;
using System.Collections.Generic;
using Workflow.Service.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;
using Workflow.Service.SystemMaintenance.OrderBaseData;

namespace Workflow.Action.SystemMaintenance.System
{
    /// <summary>
    /// 名   称:  SearchSystemAction
    /// 功能概要: 获取系统基础数据Action
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:30:01
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class SearchSystemAction
    {
        #region//ClassMember
        private SystemModel model = new SystemModel();
        public SystemModel Model 
        {
            set { model = value; }
            get { return model; }
        }
        private ISearchSystemService searchSystemService;
        public ISearchSystemService SearchSystemService 
        {
            set { searchSystemService = value; }
        }

        private ISearchOrderBaseDataService searchOrderBaseDataService;
        public ISearchOrderBaseDataService SearchOrderBaseDataService 
        {
            set { searchOrderBaseDataService = value; }
        }
        #endregion

        #region//Id维护
        /// <summary>
        /// 名   称:  SearchIdGenerator
        /// 功能概要: 获取Id数据列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日10:42:26
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchIdGenerator()
        {
            model.IdGeneratorList = searchSystemService.SearchIdGenerator(model.IdGenerator);
            model.RowCount = searchSystemService.SearchIdGeneratorRowCount(model.IdGenerator);
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
        public void SearchApplictionPeroptery() 
        {
            model.AppliactionPropertyList = searchSystemService.SearchApplictionPeroptery(model.ApplicationProperty);
            model.RowCount = searchSystemService.SearchApplictionPeropteryRowCount(model.ApplicationProperty);
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
        public void SearchCompany() 
        {
            model.CompanyList = searchSystemService.SearchCompany(model.Company);
            model.RowCount = searchSystemService.SearchCompanyRowCount(model.Company);
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
        public void SearchBranchShop() 
        {
            model.BranchShopList = searchSystemService.SearchBranchShop(model.BranchShop);
            model.RowCount=searchSystemService.SearchBranchShopRowCount(model.BranchShop);
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
        public void SearchMarkingSetting()
        {
            model.MarkingSettingList = searchSystemService.SearchMarkingSetting(model.MarkingSetting);
            model.RowCount = searchSystemService.SearchMarkingSettingRowCount(model.MarkingSetting);
        }
        #endregion

        /// <summary>
        /// 名   称:  SearchProcessContentList
        /// 功能概要: 获取加工内容积分列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日11:32:18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchProcessContentList() 
        {
            model.ProcessContentList = searchOrderBaseDataService.GetAllProcessContent();
        }
    }
}
