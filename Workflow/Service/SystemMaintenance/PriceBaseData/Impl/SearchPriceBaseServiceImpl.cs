using System;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
namespace Workflow.Service.SystemMaintenance.PriceBaseData.Impl
{
    /// <summary>
    /// 名    称: SearchPriceBaseServiceImpl
    /// 功能概要: 价格基础数据获取数据接口实现
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月28日15:33:14
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public class SearchPriceBaseServiceImpl : ISearchPriceBaseService
    {
        #region //注入Dao
        private IBusinessTypeDao businessTypeDao;
        public IBusinessTypeDao BusinessTypeDao 
        {
            set { businessTypeDao = value; }
        }

        private IProcessContentDao processContentDao;
        public IProcessContentDao ProcessContentDao 
        {
            set { processContentDao = value; }
        }

        private IMachineTypeDao machineTypeDao;
        public IMachineTypeDao MachineTypeDao 
        {
            set { machineTypeDao = value; }
        }

        private IMachineDao machineDao;
        public IMachineDao MachineDao 
        {
            set { machineDao = value; }
        }

        private IPaperSpecificationDao paperSpecificationDao;
        public IPaperSpecificationDao PaperSpecificationDao 
        {
            set { paperSpecificationDao = value; }
        }

        private IPaperTypeDao paperTypeDao;
        public IPaperTypeDao PaperTypeDao 
        {
            set { paperTypeDao = value; }
            get { return paperTypeDao; }
        }

        private IPriceFactorDao priceFactorDao;
        public IPriceFactorDao PriceFactorDao 
        {
            set { priceFactorDao = value; }
            get { return priceFactorDao; }
        }

        private IFactorValueDao factorValueDao;
        public IFactorValueDao FactorValueDao 
        {
            set { factorValueDao = value; }
        }

        private IBusinessTypePriceFactorDao businessTypePriceFactorDao;
        public IBusinessTypePriceFactorDao BusinessTypePriceFactorDao
        {
            set { businessTypePriceFactorDao = value; }
            get { return businessTypePriceFactorDao; }
        }

        private IFactorRelationDao factorRelationDao;
        public IFactorRelationDao FactorRelationDao 
        {
            set { factorRelationDao = value; }
            get { return factorRelationDao; }
        }

        private IFactorRelationValueDao factorRelationValueDao;
        public IFactorRelationValueDao FactorRelationValueDao 
        {
            set { factorRelationValueDao = value; }
            get { return factorRelationValueDao; }
        }
        #endregion

        #region //业务类型
        /// <summary>
        /// 名   称：GetBusinessTypeList
        /// 功能概要：获取业务类型列表
        /// 作者:张晓林
        /// 创建时间:2009年4月28日17:26:13
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        public IList<BusinessType> GetBusinessTypeList(BusinessType businessType) 
        {
            return businessTypeDao.GetBusinessTypeList(businessType);
        }

        /// <summary>
        /// 名    称：GetBusinessTypeListRowCount
        /// 功能概要：获取业务类型记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月29日11:26:27
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        public long GetBusinessTypeListRowCount(BusinessType businessType) 
        {
            return businessTypeDao.GetBusinessTypeListRowCount(businessType);
        }

        /// <summary>
        /// 名    称：GetAllBusinessTypeList
        /// 功能概要: 获取业务类型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日9:45:47
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<BusinessType> GetAllBusinessTypeList() 
        {
            return businessTypeDao.GetAllBusinessTypeList();
        }

        /// <summary>
        /// 名    称：CheckBusinessTyIsUse
        /// 功能概要: 检查业务类型是否正在使用
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日15:35:42
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckBusinessTyIsUse(long businessTypeId) 
        {
            return businessTypeDao.CheckBusinessTyIsUse(businessTypeId);
        }
        #endregion

        #region //加工内容
        /// <summary>
        /// 名    称：GetProcessContentList
        /// 功能概要: 获取加工内容列表
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日9:45:47
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<ProcessContent> GetProcessContentList(ProcessContent processContent) 
        {
            return processContentDao.GetProcessContentList(processContent);
        }

        /// <summary>
        /// 名    称：GetProcessContentListRowCount
        /// 功能概要: 获取加工内容列表记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年4月30日9:45:47
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long GetProcessContentListRowCount(ProcessContent processContent) 
        {
            return processContentDao.GetProcessContentListRowCount(processContent);
        }

        /// <summary>
        /// 名    称：CheckProcessContentIsUse
        /// 功能概要: 检查加工内容是否正在使用
        /// 作    者：张晓林
        /// 创建时间: 2009年5月15日17:29:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckProcessContentIsUse(long processContentId) 
        {
            return processContentDao.CheckProcessContentIsUse(processContentId);
        }
        #endregion

        #region //机器类型
        /// <summary>
        /// 名    称：SearchMachineType
        /// 功能概要: 获取机器类型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日10:08:21
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<MachineType> SearchMachineType(MachineType machineType) 
        {
           return machineTypeDao.SearchMachineType(machineType);
        }

        /// <summary>
        /// 名    称：SearchMachineTypeRowCount
        /// 功能概要: 获取机器类型列表记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日10:08:21
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchMachineTypeRowCount(MachineType machineType) 
        {
            return machineTypeDao.SearchMachineTypeRowCount(machineType);
        }

        /// <summary>
        /// 名    称：CheckMachineTypeIsUse
        /// 功能概要: 检查机器类型是否正在使用
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日13:35:19
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckMachineTypeIsUse(long businessTypeId) 
        {
            return machineTypeDao.CheckMachineTypeIsUse(businessTypeId);
        }
        #endregion

        #region//机器
        /// <summary>
        /// 名    称：SearchMachine
        /// 功能概要: 获取机器列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日14:25:54
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<Machine> SearchMachine(Machine machine) 
        {
            return machineDao.SearchMachine(machine);
        }

        /// <summary>
        /// 名    称：SearchMachineRowCount
        /// 功能概要: 获取机器记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日14:25:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchMachineRowCount(Machine machine) 
        {
            return machineDao.SearchMachineRowCount(machine);
        }

        /// <summary>
        /// 名    称：SearchAllMachineType
        /// 功能概要: 获取获取所有机器类型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日14:21:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<MachineType> SearchAllMachineType() 
        {
           return machineTypeDao.SelectAll();
        }
        #endregion

        #region //纸型
        /// <summary>
        /// 名    称: SearchPaperSecification
        /// 功能概要: 获取纸型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月5日15:15:30
        /// 修正时间:
        /// </summary>
        public IList<PaperSpecification> SearchPaperSecification(PaperSpecification paperSpecification) 
        {
            return paperSpecificationDao.SearchPaperSecification(paperSpecification);
        }

        /// <summary>
        /// 名    称: SearchPaperSecificationRowCount
        /// 功能概要: 获取纸型记录数 
        /// 作    者：张晓林
        /// 创建时间: 2009年5月5日15:15:30
        /// 修正时间:
        /// </summary>
        public long SearchPaperSecificationRowCount(PaperSpecification paperSpecification) 
        {
            return paperSpecificationDao.SearchPaperSecificationRowCount(paperSpecification);
        }
        #endregion

        #region //纸质
        /// <summary>
        /// 名    称: SearchPaperType
        /// 功能概要: 获取纸质列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日9:53:28
        /// 修正时间:
        /// </summary>
        public IList<PaperType> SearchPaperType(PaperType paperType) 
        {
            return paperTypeDao.SearchPaperType(paperType);
        }

        /// <summary>
        /// 名    称: SearchPaperTypeRowCount
        /// 功能概要: 获取纸质记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日9:53:28
        /// 修正时间:
        /// </summary>
        public long SearchPaperTypeRowCount(PaperType paperType) 
        {
            return paperTypeDao.SearchPaperTypeRowCount(paperType);
        }

        #endregion

        #region//价格因素及值
        /// <summary>
        /// 名    称: GetAllPriceFactor
        /// 功能概要: 获取所有价格因素
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日15:01:35
        /// 修正时间:
        /// </summary>
        public IList<PriceFactor> GetAllPriceFactor() 
        {
            return priceFactorDao.SelectAll();
        }

        /// <summary>
        /// 名    称: SearchFactorValue
        /// 功能概要: 获取所有因素值列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日15:01:35
        /// 修正时间:
        /// </summary>
        public IList<FactorValue> SearchFactorValue(FactorValue factorValue) 
        {
            return factorValueDao.SearchFactorValue(factorValue);
        }

        /// <summary>
        /// 名    称: SearchFactorValueRowCount
        /// 功能概要: 获取所有因素值记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日15:01:35
        /// 修正时间:
        /// </summary>
        public long SearchFactorValueRowCount(FactorValue factorValue) 
        {
            return factorValueDao.SearchFactorValueRowCount(factorValue);
        }

        /// <summary>
        /// 名    称: SearchPriceFactor
        /// 功能概要: 获取所有价格因素列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日17:38:56
        /// 修正时间:
        /// </summary>
        public IList<PriceFactor> SearchPriceFactor(PriceFactor priceFactor) 
        {
            return priceFactorDao.SearchPriceFactor(priceFactor);
        }

        /// <summary>
        /// 名    称: SearchPriceFactorRowCount
        /// 功能概要: 获取所有价格因素记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日17:38:56
        /// 修正时间:
        /// </summary>
        public long SearchPriceFactorRowCount(PriceFactor priceFactor) 
        {
            return priceFactorDao.SearchPriceFactorRowCount(priceFactor);
        }

        /// <summary>
        /// 名    称：CheckPriceFactorIsUse
        /// 功能概要: 检查价格因素是否正在使用
        /// 作    者：张晓林
        /// 创建时间: 2009年5月12日15:29:25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckPriceFactorIsUse(long priceFactorId) 
        {
            return priceFactorDao.CheckPriceFactorIsUse(priceFactorId);
        }

        /// <summary>
        /// 名    称: GetPriceFactorDetail
        /// 功能概要: 获取价格因素详情
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月12日16:00:46
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public PriceFactor GetPriceFactorDetail(long priceFactorId) 
        {
            return priceFactorDao.GetPriceFactorDetail(priceFactorId);
        }
        #endregion

        #region//业务类型包含的价格因素

        /// <summary>
        /// 名    称: SearchBusinessTypePriceFactor
        /// 功能概要: 获取业务类型包含的价格因素列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日10:01:27
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public IList<BusinessTypePriceFactor> SearchBusinessTypePriceFactor()
        {
            return businessTypePriceFactorDao.SearchBusinessTypePriceFactor();
        }

        /// <summary>
        /// 名    称: SearchBusinessTypePriceFactor
        /// 功能概要: 获取业务类型包含的价格因素列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日10:01:27
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public IList<BusinessTypePriceFactor> SearchBusinessTypePriceFactor(long businessTypeId) 
        {
            return businessTypePriceFactorDao.SearchBusinessTypePriceFactor(businessTypeId);
        }
        #endregion

        #region//价格因素之间的依赖

        /// <summary>
        /// 名    称: SearchFactorRelation
        /// 功能概要: 获取因素之间的依赖列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日10:47:30
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public IList<FactorRelation> SearchFactorRelation(FactorRelation factorRelation) 
        {
            return factorRelationDao.SearchFactorRelation(factorRelation);
        }


        /// <summary>
        /// 名    称: SearchFactorRelationRowCount
        /// 功能概要: 获取因素之间的依赖列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日10:47:30
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public long SearchFactorRelationRowCount(FactorRelation factorRelation) 
        {
            return factorRelationDao.SearchFactorRelationRowCount(factorRelation);
        }

        /// <summary>
        /// 名    称: CheckFactorRelationIsUse
        /// 功能概要: 检查价格因素依赖关系是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日9:53:25
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public long CheckFactorRelationIsUse(long factorRelationId) 
        {
            return factorRelationDao.CheckFactorRelationIsUse(factorRelationId);
        }
        #endregion

        #region//价格因素依赖关系值

        /// <summary>
        /// 名    称: GetFactorRelationById
        /// 功能概要: 根据Id获取FactorRelation
        /// 作    者: 张晓林
        /// 创建时间: 2009年7月15日9:37:25
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public FactorRelation GetFactorRelationById(long factorRelationId) 
        {
            return factorRelationDao.SelectByPk(factorRelationId);
        }

        /// <summary>
        /// 名    称: GetPriceFactorById
        /// 功能概要: 根据Id获取PriceFactor
        /// 作    者: 张晓林
        /// 创建时间: 2009年7月15日9:37:25
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public PriceFactor GetPriceFactorById(long priceFactorId) 
        {
            return priceFactorDao.SelectByPk(priceFactorId);
        }

        /// <summary>
        /// 名    称: GetPriceFactorValueList
        /// 功能概要: 根据依赖关系Id获取该因素下的所有值
        /// 作    者: 张晓林
        /// 创建时间: 2009年7月15日9:37:25
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public IList<PriceFactor> GetPriceFactorValueList(PriceFactor priceFactor) 
        {
            return priceFactorDao.GetPriceFactorValueList(priceFactor);
        }

        /// <summary>
        /// 名    称: GetAllFactorRelationValue
        /// 功能概要: 获取所有因素之间的依赖列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日11:10:17
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public IList<FactorRelation> GetAllFactorRelationValue() 
        {
            return factorRelationDao.SelectAll();
        }

        /// <summary>
        /// 名    称: SearchFactorRelationValue
        /// 功能概要: 获取因素依赖的关系值列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日11:10:17
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public IList<FactorRelationValue> SearchFactorRelationValue(FactorRelationValue factorRelationValue) 
        {
            return factorRelationValueDao.SearchFactorRelationValue(factorRelationValue);
        }

        /// <summary>
        /// 名    称: SearchFactorRelationValueRowCount
        /// 功能概要: 获取因素依赖的关系值列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日11:10:17
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public long SearchFactorRelationValueRowCount(FactorRelationValue factorRelationValue) 
        {
            return factorRelationValueDao.SearchFactorRelationValueRowCount(factorRelationValue);
        }
        #endregion
    }
}
