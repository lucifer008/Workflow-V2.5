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
    }
}
