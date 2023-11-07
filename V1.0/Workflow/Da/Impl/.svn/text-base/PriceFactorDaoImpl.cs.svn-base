using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using IBatisNet.DataMapper;
using Workflow.Support;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名    称:PriceFactorDaoImpl
    /// 功能概要:价格因素接口实现
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class PriceFactorDaoImpl : Workflow.Da.Base.DaoBaseImpl<PriceFactor>, IPriceFactorDao
    {
        
        /// <summary>
        /// 需要传递COMPANYID 合 BRANCHSHOPID
        /// 付强
        /// </summary>
        /// <returns></returns>
        public IList<PriceFactor>  SelectByUsed()
        {
            
            return base.sqlMap.QueryForList<PriceFactor>("PriceFactor.SelectByUsed", ThreadLocalUtils.CurrentUserContext.CurrentUser);
            
        }
        public IList<PriceFactor> SelectPriceFactorSetList(PriceFactor priceFactor)
        {
            return base.sqlMap.QueryForList<PriceFactor>("PriceFactor.SelectPriceFactorSetList", priceFactor);
        }

        #region 获取当前正在使用的价格因素

        /// <summary>
        /// 方法名称: SelectUsedPriceFactor
        /// 功能概要: 获取当前正在使用的价格因素
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-9
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<PriceFactor> SelectUsedPriceFactor(long businessTypeId)
        {
            return sqlMap.QueryForList<PriceFactor>("PriceFactor.SelectUsedPriceFactor", businessTypeId);
        }

        #endregion

        /// <summary>
        /// 名    称: SearchPriceFactor
        /// 功能概要: 获取所有价格因素列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日17:38:56
        /// 修正时间:
        /// </summary>
        public IList<PriceFactor> SearchPriceFactor(PriceFactor priceFactor) 
        {
            priceFactor.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            priceFactor.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<PriceFactor>("PriceFactor.SearchPriceFactor", priceFactor);
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
            return sqlMap.QueryForObject<long>("PriceFactor.SearchPriceFactorRowCount", priceFactor);
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
            PriceFactor priceFactor=new PriceFactor();
            priceFactor.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            priceFactor.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            priceFactor.Id=priceFactorId;

            long countPriceValue=sqlMap.QueryForObject<long>("PriceFactor.CheckPriceFactorIsUse",priceFactor);//价格因素值中是否使用价格因素
            long countBusinessType = sqlMap.QueryForObject<long>("PriceFactor.CheckPriceFactorIsUse1", priceFactor);//业务类型中是否包含价格因素
            long countFactor = sqlMap.QueryForObject<long>("PriceFactor.CheckPriceFactorIsUse2", priceFactor);//价格因素是否存在依赖关系

            return countPriceValue + countFactor + countBusinessType;
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
            PriceFactor priceFactor = new PriceFactor();
            priceFactor.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            priceFactor.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            priceFactor.Id = priceFactorId;
            return sqlMap.QueryForObject<PriceFactor>("PriceFactor.GetPriceFactorDetail", priceFactor);
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
            priceFactor.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            priceFactor.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<PriceFactor>("PriceFactor.GetPriceFactorValueList", priceFactor);
        }
    }
}
