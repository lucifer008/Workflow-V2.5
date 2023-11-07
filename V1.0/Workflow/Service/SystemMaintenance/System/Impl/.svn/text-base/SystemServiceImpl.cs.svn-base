using System;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using Workflow.Da;
using Workflow.Support;
using Workflow.Da.Domain;

namespace Workflow.Service.SystemMaintenance.System.Impl
{
    /// <summary>
    /// 名    称: SystemServiceImpl
    /// 功能概要: 系统基础数据管理接口实现
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月29日17:37:08
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public class SystemServiceImpl:ISystemService
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
            set { markingSettingDao  = value; }
        }
        #endregion

        #region//Id维护

        /// <summary>
        /// 名    称：InitIdData
        /// 功能概要：初始化Id数据
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日13:46:34
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        [Transaction]
        public void InitIdData() 
        {
            IList<IdGenerator> idGeneratorList=idGeneratorDao.GetAllUserTableName();
            idGeneratorDao.DeleteIdGenerator();
            int index = 1;
            long branchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            foreach(IdGenerator idGenerator in idGeneratorList)
            {
                idGenerator.Id = index;
                if (1 == branchShopId)
                {
                    idGenerator.BeginValue = branchShopId;
                    idGenerator.EndValue = 100000000;
                }
                else if(2==branchShopId)
                {
                    idGenerator.BeginValue = 100000000;
                    idGenerator.EndValue = 200000000;
                }
                else
                {
                    idGenerator.BeginValue = 200000000;
                    idGenerator.EndValue = 300000000;
                }
                idGenerator.CurrentValue = idGeneratorDao.GetRecordRowCountByTableName(idGenerator.FlagNo)+1;
                idGenerator.BranchShopId = branchShopId;
                idGenerator.Memo = "";
                idGeneratorDao.InsertIdGenerator(idGenerator);
                index++;
            }
        }

        /// <summary>
        /// 名    称：UpdateIdGenerator
        /// 功能概要：更新Id生成器数据
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日16:19:48
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateIdGenerator(IdGenerator idGenerator) 
        {
            idGeneratorDao.Update(idGenerator);
        }

        /// <summary>
        /// 名    称：DeleteIdGenerator
        /// 功能概要：删除Id生成器数据
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日16:19:48
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void DeleteIdGenerator(long idGeneratorId) 
        {
            idGeneratorDao.Delete(idGeneratorId);
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
        public void AddApplicationProperty(ApplicationProperty applicationProperty) 
        {
            applicationPropertyDao.Insert(applicationProperty);
        }

        /// <summary>
        /// 名    称：UpdateApplicationProperty
        /// 功能概要：更新应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateApplicationProperty(ApplicationProperty applicationProperty) 
        {
            applicationPropertyDao.Update(applicationProperty);
        }

        /// <summary>
        /// 名    称：LogicDeleteApplicationProperty
        /// 功能概要：逻辑删除应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void LogicDeleteApplicationProperty(long applicationPropertyId) 
        {
            applicationPropertyDao.LogicDelete(applicationPropertyId);
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
            applicationPropertyDao.DeletePropertyData("DISPLAY_ORDER_INNER_DAY_COUNT");
            ApplicationProperty applicationProperty = new ApplicationProperty();
            applicationProperty.PropertyId = "DISPLAY_ORDER_INNER_DAY_COUNT";
            applicationProperty.PropertyValue = "7";
            applicationPropertyDao.Insert(applicationProperty);
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
        public void AddCompany(Company company) 
        {
            companyDao.Insert(company);
        }

        /// <summary>
        /// 名    称：UpdateCompany
        /// 功能概要：更新公司
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日14:31:19
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateCompany(Company company) 
        {
            companyDao.Update(company);
        }

        /// <summary>
        /// 名    称：LogicDeleteCompany
        /// 功能概要：逻辑删除公司
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月9日14:31:19
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void LogicDeleteCompany(long companyId) 
        {
            companyDao.LogicDelete(companyId);
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
        public void AddBranchShop(BranchShop branchShop) 
        {
            branchShopDao.Insert(branchShop);
        }

        /// <summary>
        /// 名    称：UpdateBranchShop
        /// 功能概要：修改分店信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:50:59
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateBranchShop(BranchShop branchShop) 
        {
            branchShopDao.Update(branchShop);
        }

        /// <summary>
        /// 名    称：LogicDeleteBranchShop
        /// 功能概要：逻辑删除分店信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月11日11:50:59
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void LogicDeleteBranchShop(long branchShopId) 
        {
            branchShopDao.LogicDelete(branchShopId);
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
        public void AddMarkingSetting(MarkingSetting markingSetting) 
        {
            foreach(string str in markingSetting.StrProcessContent.Split(','))
            {
                if ("" != str.Trim())
                {
                    markingSetting.ProcessContentId = Convert.ToInt32(str);
                    if (!markingSettingDao.CheckMarkingSettingIsExist(markingSetting))
                        markingSettingDao.Insert(markingSetting);
                }
            }
        }

        /// <summary>
        /// 名    称：UpdateMarkingSetting
        /// 功能概要：更新积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日13:26:25
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void UpdateMarkingSetting(MarkingSetting markingSetting) 
        {
            markingSettingDao.Update(markingSetting);
        }

        /// <summary>
        /// 名    称：DeleteMarkingSetting
        /// 功能概要：删除积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日13:26:25
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void DeleteMarkingSetting(MarkingSetting markingSetting) 
        {
            markingSettingDao.Delete(markingSetting.Id);
        }
        #endregion
    }
}
