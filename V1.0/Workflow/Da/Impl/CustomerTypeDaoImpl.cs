using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using System.Reflection;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名    称: CustomerTypeDaoImpl
    /// 功能概要: 客户类型接口实现
    /// 作    者: 
    /// 创建时间: 
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public class CustomerTypeDaoImpl : Workflow.Da.Base.DaoBaseImpl<CustomerType>, ICustomerTypeDao
    {
        #region//客户类型

        /// <summary>
        /// 名   称:  SearchCustomerType
        /// 功能概要: 获取客户类型列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<CustomerType> SearchCustomerType(CustomerType customerType) 
        {
            customerType.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            customerType.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<CustomerType>("CustomerType.SearchCustomerType", customerType);
        }

        /// <summary>
        /// 名   称:  SearchCustomerTypeRowCount
        /// 功能概要: 获取客户类型列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchCustomerTypeRowCount(CustomerType customerType) 
        {
            return sqlMap.QueryForObject<long>("CustomerType.SearchCustomerTypeRowCount", customerType);
        }

        /// <summary>
        /// 名   称:  CheckCustomerTypeIsUse
        /// 功能概要: 检查客户类型是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日11:35:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckCustomerTypeIsUse(long customerTypeId) 
        {
            CustomerType customerType = new CustomerType();
            customerType.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            customerType.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            customerType.Id = customerTypeId;
            return sqlMap.QueryForObject<long>("CustomerType.CheckCustomerTypeIsUse", customerType);
        }
        #endregion
    }
}
