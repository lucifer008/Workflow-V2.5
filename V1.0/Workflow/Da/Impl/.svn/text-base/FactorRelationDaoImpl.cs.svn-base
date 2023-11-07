using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Util;


namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table FACTOR_RELATION 对应的Dao 实现
	/// </summary>
    public class FactorRelationDaoImpl : Workflow.Da.Base.DaoBaseImpl<FactorRelation>, IFactorRelationDao
    {

        #region IFactorRelationDao 成员

        public IList<FactorRelation> GetRelatedPriceFactorBySourcePriceFactor(FactorRelation factorRelation)
        {
            return base.sqlMap.QueryForList<FactorRelation>("FactorRelation.GetRelatedPriceFactorBySourcePriceFactor", factorRelation);
        }

        public IList<FactorValue> GetFactorValueListByFactorRelation(FactorRelation factorRelation)
        {
            if (StringUtils.IsEmpty(factorRelation.PriceFactor.TargetTable))
            {
                return base.sqlMap.QueryForList<FactorValue>("FactorRelation.GetFactorValueListByFactorRelationFromCommonTable", factorRelation);
            }
            else
            {
                return base.sqlMap.QueryForList<FactorValue>("FactorRelation.GetFactorValueListByFactorRelationFromTargetTable", factorRelation);
            }
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
            factorRelation.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorRelation.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<FactorRelation>("FactorRelation.SearchFactorRelation",factorRelation);
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
            return sqlMap.QueryForObject<long>("FactorRelation.SearchFactorRelationRowCount", factorRelation);
        }

        /// <summary>
        /// 名    称: CheckFactorRelationIsExist
        /// 功能概要: 检查是否存在FactorRelation
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日10:47:30
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public bool CheckFactorRelationIsExist(FactorRelation factorRelation) 
        {
            factorRelation.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorRelation.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            long count = sqlMap.QueryForObject<long>("FactorRelation.CheckFactorRelationIsExist", factorRelation);
            bool isExists=false;
            if(1==count)
            {
                isExists=true;
            }
            return isExists;
        }

        /// <summary>
        /// 名    称: DeleteFactorRelationValue
        /// 功能概要: 删除FactorRelationValue
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月14日15:48:02
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void DeleteFactorRelationValue(long factorRelationId) 
        {
            FactorRelation factorRelation=new FactorRelation();
            factorRelation.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorRelation.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            factorRelation.Id = factorRelationId;
            sqlMap.Delete("FactorRelation.DeleteFactorRelationValue", factorRelation);
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
            FactorRelation factorRelation = new FactorRelation();
            factorRelation.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorRelation.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            factorRelation.Id = factorRelationId;
            return sqlMap.QueryForObject<long>("FactorRelation.CheckFactorRelationIsUse", factorRelation);
        }
        #endregion
    }
}
