using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Util;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名    称:FactorValueDaoImpl
    /// 功能概要:因素值接口实现
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class FactorValueDaoImpl : Workflow.Da.Base.DaoBaseImpl<FactorValue>, IFactorValueDao
    {
        public IList<FactorValue> GetFactorValueListByPriceFactor(PriceFactor priceFactor)
        {
            if (StringUtils.IsEmpty(priceFactor.TargetTable))
            {
                return base.sqlMap.QueryForList<FactorValue>("FactorValue.GetFactorValueListByFactorRelationFromCommonTable", priceFactor);
            }
            else
            {
                this.MakeMetaData(priceFactor);
                if(StringUtils.IsEmpty(priceFactor.TargetPriceFactorId))

                    return base.sqlMap.QueryForList<FactorValue>("FactorValue.GetFactorValueListByFactorRelationFromTargetTable", priceFactor);
                else
                    return base.sqlMap.QueryForList<FactorValue>("FactorValue.GetFactorValueListByFactorRelationFromTargetTable1", priceFactor);
            }
        }

        public string GetFactorValueByFactorValueId(PriceFactor priceFactor, bool common)
        {
            FactorValue fv;
            if (common)
            {
                fv = base.sqlMap.QueryForObject<FactorValue>("FactorValue.GetFactorValueTextByFactorRelationFromCommonTable", priceFactor);
            }
            else
            {
                this.MakeMetaData(priceFactor);
                fv = base.sqlMap.QueryForObject<FactorValue>("FactorValue.GetFactorValueTextByFactorRelationFromTargetTable", priceFactor);
            }

            if (fv != null)
            {
                return fv.Text;
            }
            else
            {
                return "";
            }
            
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
            factorValue.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorValue.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<FactorValue>("FactorValue.SearchFactorValue", factorValue);
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
            return sqlMap.QueryForObject<long>("FactorValue.SearchFactorValueRowCount", factorValue);
        }

        /// <summary>
        /// 名    称: GetLastFactorValueByPriceFactorId
        /// 功能概要: 根据价格因素Id获取上一个Value,排序号
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日16:27:26
        /// 修正时间:
        /// </summary>
        public FactorValue GetLastFactorValueByPriceFactorId(long priceFactorId) 
        {
            FactorValue factorValue = new FactorValue();
            factorValue.CompanyId= Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorValue.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            factorValue.PriceFactorId = priceFactorId;
            return sqlMap.QueryForObject<FactorValue>("FactorValue.GetLastFactorValueByPriceFactorId", factorValue);
        }

        /// <summary>
        /// 名    称: GetLastFactorValueById
        /// 功能概要: 根据价格因素值Id Value,排序号
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日16:27:26
        /// 修正时间:
        /// </summary>
        public FactorValue GetLastFactorValueById(long factorValueId) 
        {
            FactorValue factorValue = new FactorValue();
            factorValue.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorValue.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            factorValue.Id = factorValueId;
            return sqlMap.QueryForObject<FactorValue>("FactorValue.GetLastFactorValueById", factorValue);
        }
    }
}
