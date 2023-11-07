using System;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
using Workflow.Da.Support;
using Spring.Transaction.Interceptor;
namespace Workflow.Service.SystemMaintenance.PriceBaseData.Impl
{
    /// <summary>
    /// 名    称: PriceBaseImpl
    /// 功能概要: 价格基础数据维护接口实现
    /// 作    者: 张晓林
    /// 创建时间: 2009年4月28日15:33:14
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public class PriceBaseServiceImpl : IPriceBaseService
    {
        #region// 注入Dao
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

        private IdGeneratorSupport idGeneratorSupport;
        public IdGeneratorSupport IdGeneratorSupport
        {
            set { idGeneratorSupport = value; }
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
        }

        private IPriceFactorDao priceFactorDao;
        public IPriceFactorDao PriceFactorDao 
        {
            set { priceFactorDao = value; }
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

        private IProcessContentAchievementRateDao processContentAchievementRateDao;
        public IProcessContentAchievementRateDao ProcessContentAchievementRateDao
        {
            set { processContentAchievementRateDao = value; }
        }
        #endregion

        #region //新增业务类型

        /// <summary>
        /// 名    称: AddBusinessType
        /// 功能概要: 添加业务类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月28日17:06:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddBusinessType(BusinessType businessType) 
        {
            businessTypeDao.Insert(businessType);
        }
        #endregion

        #region //修改业务类型
        /// <summary>
        /// 名    称: UpdateBusinessType
        /// 功能概要: 修改业务类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月28日17:06:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType"></param>
        public void UpdateBusinessType(BusinessType businessType) 
        {
            businessTypeDao.Update(businessType);
        }
         #endregion

        #region //删除业务类型
        /// <summary>
        /// 名    称: DeleteBusinessType
        /// 功能概要: 删除业务类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月28日17:06:43
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType"></param>
        public void DeleteBusinessType(long businessTypeId) 
        {
            businessTypeDao.LogicDelete(businessTypeId);
        }
        #endregion

        #region //加工内容维护
        /// <summary>
        /// 名    称:AddProcessContent
        /// 功能概要:新增加工内容
        /// 作    者:张晓林
        /// 创建时间:2009年4月30日10:23:38
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        [Transaction]
        public void AddProcessContent(ProcessContent processContent,ProcessContentAchievementRate processContentAchievementRate) 
        {
            Type type = typeof(ProcessContent);
            long id = idGeneratorSupport.NextId(type);
            processContent.No = "0"+id.ToString();
            processContentDao.Insert(processContent);
            //添加业绩
            processContentAchievementRate.ProcessContentId = processContent.Id;
            processContentAchievementRateDao.Insert(processContentAchievementRate);
        }

        /// <summary>
        /// 名    称:UpdateProcessContent
        /// 功能概要:修改加工内容
        /// 作    者:张晓林
        /// 创建时间:2009年4月30日10:23:38
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        [Transaction]
        public void UpdateProcessContent(ProcessContent processContent,ProcessContentAchievementRate processContentAchievementRate) 
        {
            processContent.No = "0" + processContent.Id.ToString();
            processContentDao.UpdateProcessContent(processContent);
            //更新业绩
            processContentAchievementRateDao.UpdateProcessContentAchievementRate(processContentAchievementRate);
        }

        /// <summary>
        /// 名    称:DeleteProcessContent
        /// 功能概要:删除加工内容
        /// 作    者:张晓林
        /// 创建时间:2009年4月30日10:23:38
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void DeleteProcessContent(long processContentId) 
        {
            processContentDao.DeleteLogicProcessContent(processContentId);
        }

        /// <summary>
        /// 名    称:GetProcessContentAchievementRate
        /// 功能概要:获取加工内容的业绩
        /// 作    者:张晓林
        /// 创建时间:2009年6月5日11:52:04
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public ProcessContentAchievementRate GetProcessContentAchievementRate(long processContentId) 
        {
            return processContentAchievementRateDao.GetProcessContentAchievementRate(processContentId);
        } 
        #endregion

        #region//机器类型维护
        /// <summary>
        /// 名    称: AddMachineType
        /// 功能概要: 新增机器类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日10:31:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddMachineType(MachineType machineType) 
        {
            machineTypeDao.Insert(machineType);
        }

        /// <summary>
        /// 名    称: UpdateMachineType
        /// 功能概要: 更新机器类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日10:35:23
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateMachineType(MachineType machineType) 
        {
            machineTypeDao.Update(machineType);
        }

        /// <summary>
        /// 名    称: LogicDeleteMachineType
        /// 功能概要: 逻辑删除机器类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日10:35:23
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteMachineType(long machineTypeId) 
        {
            machineTypeDao.LogicDelete(machineTypeId);
        }
        #endregion

        #region//机器维护
        /// <summary>
        /// 名    称: AddMachine
        /// 功能概要: 新增机器
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日14:59:35
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddMachine(Machine machine)
        {
            machineDao.Insert(machine);
        }

        /// <summary>
        /// 名    称: UpdateMachine
        /// 功能概要: 更新机器类型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日15:01:19
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateMachine(Machine machine)
        {
            machineDao.Update(machine);
        }

        /// <summary>
        /// 名    称: LogicDeleteMachine
        /// 功能概要: 逻辑删除机器
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月4日15:01:10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteMachine(long machineId)
        {
            machineDao.LogicDelete(machineId);
        }
        #endregion

        #region//纸型维护

        /// <summary>
        /// 名    称: AddPaperSpecification
        /// 功能概要: 新增纸型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月5日15:31:55
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddPaperSpecification(PaperSpecification paperSpecification) 
        {
            Type type = typeof(PaperSpecification);
            long id = idGeneratorSupport.NextId(type);
            paperSpecification.No = "0" + id.ToString();
            paperSpecificationDao.Insert(paperSpecification);
        }

        /// <summary>
        /// 名    称: UpdateSpecification
        /// 功能概要: 更新纸型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月5日15:31:55
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateSpecification(PaperSpecification paperSpecification) 
        {
            paperSpecification.No = "0" + paperSpecification.Id.ToString();
            paperSpecificationDao.Update(paperSpecification);
        }

        /// <summary>
        /// 名    称: LogicDeleteSpecification
        /// 功能概要: 逻辑删除纸型
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月5日15:31:55
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteSpecification(long paperSpecificationId) 
        {
            paperSpecificationDao.LogicDelete(paperSpecificationId);
        }
        #endregion

        #region//纸质维护
        /// <summary>
        /// 名    称: AddPaperType
        /// 功能概要: 新增纸质
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日10:14:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddPaperType(PaperType paperType)
        {
            Type type = typeof(PaperType);
            long id = idGeneratorSupport.NextId(type);
            paperType.No = "0" + id.ToString();
            paperTypeDao.Insert(paperType);
        }

        /// <summary>
        /// 名    称: UpdatePaperType
        /// 功能概要: 修改纸质
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日10:14:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdatePaperType(PaperType paperType) 
        {
            paperType.No = "0" + paperType.Id.ToString();
            paperTypeDao.Update(paperType);
        }

        /// <summary>
        /// 名    称: LogicDeletePaperType
        /// 功能概要: 逻辑删除纸质
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日10:14:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeletePaperType(long paperTypeId) 
        {
            paperTypeDao.LogicDelete(paperTypeId);
        }
        #endregion

        #region//其他价格因素及值维护
        /// <summary>
        /// 名    称: AddPriceFactor
        /// 功能概要: 新增价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddPriceFactor(PriceFactor priceFactor) 
        {
            Type type = typeof(PriceFactor);
            long id = idGeneratorSupport.NextId(type);
            priceFactor.SortNo = Convert.ToInt32(id);
            priceFactorDao.Insert(priceFactor);
        }

        /// <summary>
        /// 名    称: UpdatePriceFactor
        /// 功能概要: 修改价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdatePriceFactor(PriceFactor priceFactor) 
        {
            Type type = typeof(PriceFactor);
            long id = idGeneratorSupport.NextId(type);
            priceFactor.SortNo = Convert.ToInt32(id);
            priceFactorDao.Update(priceFactor);
        }

        /// <summary>
        /// 名    称: LogicDeletePriceFactor
        /// 功能概要: 逻辑删除价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeletePriceFactor(long priceFactorId) 
        {
            priceFactorDao.LogicDelete(priceFactorId);
        }

        /// <summary>
        /// 名    称: AddFactorValue
        /// 功能概要: 新增价格因素值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddFactorValue(FactorValue factorValue) 
        {
            FactorValue lastFactorValue = factorValueDao.GetLastFactorValueByPriceFactorId(factorValue.PriceFactorId);
            if (null != lastFactorValue)
            {
                factorValue.Value = "0" + Convert.ToString((Convert.ToInt32(lastFactorValue.Value) + 1));
                factorValue.SortNo =lastFactorValue.SortNo + 1;
            }
            else 
            {
                factorValue.Value = "01";
                factorValue.SortNo = 1;
            }
            factorValueDao.Insert(factorValue);
        }

        /// <summary>
        /// 名    称: UpdateFactorValue
        /// 功能概要: 更新价格因素值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateFactorValue(FactorValue factorValue) 
        {
            FactorValue updateFactorValue = factorValueDao.GetLastFactorValueById(factorValue.Id);
            factorValue.Value = updateFactorValue.Value;
            factorValue.SortNo = updateFactorValue.SortNo;
            factorValueDao.Update(factorValue);
        }

        /// <summary>
        /// 名    称: LogicDeleteFactorValue
        /// 功能概要: 逻辑删除价格因素值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月6日16:03:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void LogicDeleteFactorValue(long factorValueId) 
        {
            factorValueDao.LogicDelete(factorValueId);
        }
        #endregion

        #region//业务类型包含的价格因素
        /// <summary>
        /// 名    称: AddBusinessTypePriceFactor
        /// 功能概要: 添加业务类型包含的价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日9:23:33
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void AddBusinessTypePriceFactor(BusinessTypePriceFactor businessTypePriceFactor,string[] priceFactorIds) 
        {
            
            foreach(string str in priceFactorIds)
            {
               businessTypePriceFactor.PriceFactorId = Convert.ToInt32(str);
               if (!businessTypePriceFactorDao.CheckBusinessTypePriceFactorIsExist(businessTypePriceFactor))
               {
                   businessTypePriceFactorDao.Insert(businessTypePriceFactor);
               }
            }
        }

        /// <summary>
        /// 名    称: UpdateBusinessTypePriceFactor
        /// 功能概要: 修改 业务类型包含的价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日9:23:33
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateBusinessTypePriceFactor(BusinessTypePriceFactor businessTypePriceFactor, string[] priceFactorIds) 
        {
            businessTypePriceFactorDao.DeleteBusinessTypePriceFactorByBusinessTypeId(businessTypePriceFactor.BusinessTypeId);
            foreach (string str in priceFactorIds)
            {
                businessTypePriceFactor.PriceFactorId = Convert.ToInt32(str);
                businessTypePriceFactorDao.Insert(businessTypePriceFactor);
            }
        }

        /// <summary>
        /// 名    称: DeleteBusinessTypePriceFactor
        /// 功能概要: 删除 业务类型包含的价格因素
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日9:23:33
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void DeleteBusinessTypePriceFactor(long businessTypePriceFactorId) 
        {
            businessTypePriceFactorDao.Delete(businessTypePriceFactorId);
        }

        /// <summary>
        /// 名    称: DeleteBusinessTypePriceFactorByBusinessTypeId
        /// 功能概要: 根据业务类型Id删除与价格因素之间的依赖 
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日10:01:27
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void DeleteBusinessTypePriceFactorByBusinessTypeId(long businessTypeId) 
        {
            businessTypePriceFactorDao.DeleteBusinessTypePriceFactorByBusinessTypeId(businessTypeId);
        }
        #endregion

        #region//价格因素之间的依赖
        /// <summary>
        /// 名    称: AddFactorRelation
        /// 功能概要: 新增价格因素依赖
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日12:02:58
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        [Spring.Transaction.Interceptor.Transaction]
        public void AddFactorRelation(FactorRelation factorRelation, string[] priceFactorIds) 
        {
            foreach(string str in priceFactorIds)
            {
                factorRelation.PriceFactorId2 = Convert.ToInt32(str);
                factorRelation.PriceFactor = new PriceFactor();
                factorRelation.PriceFactor.Id = Convert.ToInt32(str);
                if(!factorRelationDao.CheckFactorRelationIsExist(factorRelation))
                {
                    if (factorRelation.PriceFactorId != Convert.ToInt32(str))
                    {
                        factorRelationDao.Insert(factorRelation);
                    }
                }
            }
        }

        /// <summary>
        /// 名    称: UpdateFactorRelation
        /// 功能概要: 更新价格因素依赖
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日12:02:58
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        [Spring.Transaction.Interceptor.Transaction]
        public void UpdateFactorRelation(FactorRelation factorRelation, string[] priceFactorIds)
        {
            factorRelationDao.DeleteFactorRelationValue(factorRelation.Id);
            factorRelationDao.Delete(factorRelation.Id);
            foreach (string str in priceFactorIds)
            {

                if (factorRelation.PriceFactorId!=Convert.ToInt32(str))
                {
                    factorRelation.PriceFactor = new PriceFactor();
                    factorRelation.PriceFactor.Id = Convert.ToInt32(str);
                    factorRelationDao.Insert(factorRelation);
                }
            }
        }

        /// <summary>
        /// 名    称: LogicDeleteFactorRelation
        /// 功能概要: 逻辑删除价格因素依赖
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日12:02:58
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void LogicDeleteFactorRelation(FactorRelation factorRelation)
        {
            factorRelationDao.LogicDelete(factorRelation.Id);
        }
        #endregion

        #region//价格因素依赖关系值
        /// <summary>
        /// 名    称: AddFactorRelationValue
        /// 功能概要: 添加价格因素依赖关系值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日13:24:37
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        [Transaction]
        public void AddFactorRelationValue(FactorRelationValue factorRelationValue) 
        {
            foreach(string strSourceValue in factorRelationValue.ArrSourceValue)
            {
                foreach(string strTargetValue in factorRelationValue.ArrTargetValue)
                {
                    factorRelationValue.SourceValue = Convert.ToInt32(strSourceValue);
                    factorRelationValue.TargetValue = Convert.ToInt32(strTargetValue);
                    if (!factorRelationValueDao.CheckFactorRelationValueIsExist(factorRelationValue))
                    {
                        factorRelationValueDao.Insert(factorRelationValue);
                    }
                }
            }
        }

        /// <summary>
        /// 名    称: UpdateFactorRelationValue
        /// 功能概要: 更新价格因素依赖关系值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日13:24:37
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void UpdateFactorRelationValue(FactorRelationValue factorRelationValue) 
        {
            factorRelationValueDao.Update(factorRelationValue);
        }

        /// <summary>
        /// 名    称: LogicDeleteFactorRelationValue
        /// 功能概要: 逻辑删除价格因素依赖关系值
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月18日13:24:37
        /// 修正履历：更改为物理删除
        /// 修正时间: 2009年7月16日13:59:42
        /// </summary>
        public void LogicDeleteFactorRelationValue(long factorRelationValueId) 
        {
            factorRelationValueDao.Delete(factorRelationValueId);
        }
        #endregion
    }
}
