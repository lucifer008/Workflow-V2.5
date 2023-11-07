using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名    称: CustomerLevelDaoImpl
    /// 功能概要: 客户级别接口实现
    /// 作    者: 
    /// 创建时间: 
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public class CustomerLevelDaoImpl : Workflow.Da.Base.DaoBaseImpl<CustomerLevel>, ICustomerLevelDao
    {
        #region//客户级别
        /// <summary>
        /// 名   称:  SearchCustomerLevel
        /// 功能概要: 获取客户级别列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<CustomerLevel> SearchCustomerLevel(CustomerLevel customerLevel) 
        {
            customerLevel.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            customerLevel.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<CustomerLevel>("CustomerLevel.SearchCustomerLevel", customerLevel);
        }

        /// <summary>
        /// 名   称:  SearchCustomerLevelRowCount
        /// 功能概要: 获取客户级别列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchCustomerLevelRowCount(CustomerLevel customerLevel) 
        {
            return sqlMap.QueryForObject<long>("CustomerLevel.SearchCustomerLevelRowCount", customerLevel);
        }

        /// <summary>
        /// 名   称:  CheckCustomerLevelIsUse
        /// 功能概要: 检查客户级别是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日11:35:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckCustomerLevelIsUse(long customerLevelId) 
        {
            CustomerLevel customerLevel = new CustomerLevel();
            customerLevel.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            customerLevel.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            customerLevel.Id = customerLevelId;
            return sqlMap.QueryForObject<long>("CustomerLevel.CheckCustomerLevelIsUse", customerLevel);
        }
        #endregion
    }
}
