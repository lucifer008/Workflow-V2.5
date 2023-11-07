using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table BUSINESS_TYPE 对应的Dao 实现
	/// </summary>
    public class BusinessTypeDaoImpl : Workflow.Da.Base.DaoBaseImpl<BusinessType>, IBusinessTypeDao
    {

        #region IBusinessTypeDao 成员

        //public IList<PriceFactor> GetPriceFactorListByBusinessTypeId(long id)
        //{
        //    return sqlMap.QueryForList<PriceFactor>("BusinessTypeBase.SelectPriceFactor", id);
        //}

        public IList<BusinessType> SelectCustomerQueryBusinessTypeList(BusinessType businessType)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            businessType.CompanyId = user.CompanyId;
            businessType.BranchShopId = user.BranchShopId;
            return sqlMap.QueryForList<BusinessType>("BusinessType.SelectCustomQueryBusinessTypeList", businessType);
        }


        public IList<BusinessType> SelectCustomerQueryBusinessTypeList_Set(BusinessType businessType)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            businessType.CompanyId = user.CompanyId;
            businessType.BranchShopId = user.BranchShopId;
            return sqlMap.QueryForList<BusinessType>("BusinessType.SelectCustomQueryBusinessTypeList_Set", businessType);
        }

        /// <summary>
        /// 指定编号的业务类型是否能删除.如果不能返回BusinessType类型数据,否则无数据
        /// </summary>
        /// <param name="businessId">要检验的业务类型ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 日期:2008-11-06
        /// 朱静程
        ///</remarks>
        public IList<BusinessType> DeleteCheck(long businessId)
        {
            return sqlMap.QueryForList<BusinessType>("BusinessType.DeleteCheck", businessId);        
        }



        #endregion

        /// <summary>
        /// 名    称：GetBusinessTypeList
        /// 功能概要：获取业务类型列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月28日17:26:13
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        public IList<BusinessType> GetBusinessTypeList(BusinessType businessType) 
        {
            businessType.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            businessType.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<BusinessType>("BusinessType.GetBusinessTypeList", businessType);
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
            return sqlMap.QueryForObject<long>("BusinessType.GetBusinessTypeListRowCount", businessType);
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
            BusinessType businessType = new BusinessType();
            businessType.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            businessType.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<BusinessType>("BusinessType.GetAllBusinessTypeList", businessType);
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
            BusinessType businessType = new BusinessType();
            businessType.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            businessType.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            businessType.Id = businessTypeId;
            return sqlMap.QueryForObject<long>("BusinessType.CheckBusinessTyIsUse", businessType);
        }
    }
}
