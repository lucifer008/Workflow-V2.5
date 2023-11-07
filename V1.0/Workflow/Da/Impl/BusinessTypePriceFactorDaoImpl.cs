using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名     称: BusinessTypePriceFactorDaoImpl
    /// 功能概要: 业务类型包含的价格因素接口实现
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class BusinessTypePriceFactorDaoImpl : Workflow.Da.Base.DaoBaseImpl<BusinessTypePriceFactor>, IBusinessTypePriceFactorDao
    {
        public void DeleteByBusinessTypeId(long id)
        {
            base.sqlMap.Delete("BusinessTypePriceFactor.DeleteByBusinessTypeId", id);
        }

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
            BusinessTypePriceFactor businessTypePriceFactor = new BusinessTypePriceFactor();
            businessTypePriceFactor.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            businessTypePriceFactor.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<BusinessTypePriceFactor>("BusinessTypePriceFactor.SearchBusinessTypePriceFactor", businessTypePriceFactor);
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
            BusinessTypePriceFactor businessTypePriceFactor = new BusinessTypePriceFactor();
            businessTypePriceFactor.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            businessTypePriceFactor.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            businessTypePriceFactor.BusinessTypeId = businessTypeId;
            return sqlMap.QueryForList<BusinessTypePriceFactor>("BusinessTypePriceFactor.SearchBusinessTypePriceFactorByBusId", businessTypePriceFactor);
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
            BusinessTypePriceFactor businessTypePriceFactor = new BusinessTypePriceFactor();
            businessTypePriceFactor.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            businessTypePriceFactor.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            businessTypePriceFactor.BusinessTypeId = businessTypeId;
            sqlMap.Delete("BusinessTypePriceFactor.DeleteBusinessTypePriceFactorByBusinessTypeId", businessTypePriceFactor);
        }

        /// <summary>
        /// 名    称: CheckBusinessTypePriceFactorIsExist
        /// 功能概要: 根据业务类型Id和价格因素Id是否存在之间的依赖 
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月13日14:54:39
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public bool CheckBusinessTypePriceFactorIsExist(BusinessTypePriceFactor businessTypePriceFactor) 
        {
            long count = sqlMap.QueryForObject<long>("BusinessTypePriceFactor.CheckBusinessTypePriceFactorIsExist", businessTypePriceFactor);
            if (count > 0) 
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
