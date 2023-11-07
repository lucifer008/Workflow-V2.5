using System;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Action.SystemMaintenance.System.Model
{
    /// <summary>
    /// 名   称:  SystemModel
    /// 功能概要: 系统基础数据管理Model
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:30:01
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class SystemModel
    {
        private IdGenerator idGenerator=new IdGenerator();
        public IdGenerator IdGenerator 
        {
            set { idGenerator = value; }
            get { return idGenerator; }
        }
        private IList<IdGenerator> idGeneratorList;
        public IList<IdGenerator> IdGeneratorList 
        {
            set { idGeneratorList = value; }
            get { return idGeneratorList; }
        }

        private long rowCount;
        public long RowCount 
        {
            set { rowCount = value; }
            get { return rowCount; }
        }

        private ApplicationProperty applicationProperty=new ApplicationProperty();
        public ApplicationProperty ApplicationProperty 
        {
            set { applicationProperty = value; }
            get { return applicationProperty; }
        }
        private IList<ApplicationProperty> applicationPropertyList;
        public IList<ApplicationProperty> AppliactionPropertyList 
        {
            set { applicationPropertyList = value; }
            get { return applicationPropertyList; }
        }

        private Company company=new Company();
        public Company Company 
        {
            set { company = value; }
            get { return company; }
        }
        private IList<Company> compayList;
        public IList<Company> CompanyList 
        {
            set { compayList = value; }
            get { return compayList; }
        }

        private BranchShop branchShop = new BranchShop();
        public BranchShop BranchShop 
        {
            set { branchShop = value; }
            get { return branchShop; }
        }

        private IList<BranchShop> branchShopList;
        public IList<BranchShop> BranchShopList 
        {
            set { branchShopList = value; }
            get { return branchShopList; }
        }

        private MarkingSetting markingSetting = new MarkingSetting();
        public MarkingSetting MarkingSetting 
        {
            set { markingSetting = value; }
            get { return markingSetting; }
        }
        private IList<MarkingSetting> markingSettingList;
        public IList<MarkingSetting> MarkingSettingList 
        {
            set { markingSettingList = value; }
            get { return markingSettingList; }
        }

        private IList<ProcessContent> processContentList;
        public IList<ProcessContent> ProcessContentList 
        {
            set { processContentList = value; }
            get { return processContentList; }
		}

		#region 公司ID
		private long companyId;
		/// <summary>
		/// 公司ID
		/// </summary>
		public long CompanyId
		{
			get { return companyId; }
			set { companyId = value; }
		}
		#endregion

		#region 分店Id
		private long branchShopId;
		/// <summary>
		/// 分店Id
		/// </summary>
		public long BranchShopId
		{
			get { return branchShopId; }
			set { branchShopId = value; }
		}
		#endregion

        #region 业务类型列表
        private IList<BusinessType> businessTypeList;
        /// <summary>
        /// 业务类型列表
        /// </summary>
        public IList<BusinessType> BusinessTypeList
        {
            get { return businessTypeList; }
            set { businessTypeList = value; }
        }
        #endregion

        #region 价格因素
        private IList<PriceFactor> priceFactor;
        /// <summary>
        /// 价格因素
        /// </summary>
        public IList<PriceFactor> PriceFactor
        {
            get { return priceFactor; }
            set { priceFactor = value; }
        }
        #endregion


    }
}
