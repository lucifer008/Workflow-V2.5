using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名     称:FactorRelationValueDaoImpl
    /// 功能概要:因素依赖关系值接口实现
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class FactorRelationValueDaoImpl : Workflow.Da.Base.DaoBaseImpl<FactorRelationValue>, IFactorRelationValueDao
    {
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
            factorRelationValue.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorRelationValue.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<FactorRelationValue>("FactorRelationValue.SearchFactorRelationValue", factorRelationValue);
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
            return sqlMap.QueryForObject<long>("FactorRelationValue.SearchFactorRelationValueRowCount", factorRelationValue);
        }

        /// <summary>
        /// 名    称: CheckFactorIsRelation
        /// 功能概要: 检查是否存在这样的依赖关系
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月25日15:26:24
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public long CheckFactorIsRelation(FactorRelationValue factorRelationValue) 
        {
            return sqlMap.QueryForObject<long>("FactorRelationValue.CheckFactorIsRelation", factorRelationValue);
        }

        ///// <summary>
        ///// 名    称: GetBusinessTypeRelationPriceFactorCount
        ///// 功能概要: 获取业务类型价格因素
        ///// 作    者: 张晓林
        ///// 创建时间: 2009年6月26日9:44:49
        ///// 修正履历：
        ///// 修正时间:
        ///// </summary>
        ///// <param name="condition"></param>
        ///// <returns></returns>
        //public long GetBusinessTypeRelationPriceFactorCount(FactorRelationValue factorRelationValue) 
        //{
        //    return sqlMap.QueryForObject<long>("FactorRelationValue.GetBusinessTypeRelationPriceFactorCount", factorRelationValue);
        //}

        /// <summary>
        /// 名    称: GetFactorRelationId
        /// 功能概要: 获取价格因素依赖关系Id
        /// 作    者: 张晓林
        /// 创建时间: 2009年7月13日10:27:18
        /// 修正履历：
        /// 修正时间: 
        /// </summary>
        /// <param name="factorRelation"></param>
        /// <returns></returns>
        public long GetFactorRelationId(FactorRelation factorRelation) 
        {
            factorRelation.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorRelation.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("FactorRelationValue.GetFactorRelationId", factorRelation);
        }

        /// <summary>
        /// 名    称: CheckFactorRelationValueIsExist
        /// 功能概要: 检查FactorRelationValue是否存在
        /// 作    者: 张晓林
        /// 创建时间: 2009年7月15日14:50:16
        /// 修正履历：
        /// 修正时间: 
        /// </summary>
        /// <param name="factorRelation"></param>
        /// <returns></returns>
        public bool CheckFactorRelationValueIsExist(FactorRelationValue factorRelationValue) 
        {
            factorRelationValue.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorRelationValue.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            long count = sqlMap.QueryForObject<long>("FactorRelationValue.CheckFactorRelationValueIsExist", factorRelationValue);
            if (count > 0) 
            {
                return true;
            }
            return false;
        }
    }
}
