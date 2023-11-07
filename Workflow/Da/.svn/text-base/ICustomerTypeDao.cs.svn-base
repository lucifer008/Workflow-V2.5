using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
    /// <summary>
    /// 名    称: ICustomerTypeDao
    /// 功能概要: 客户类型接口
    /// 作    者: 
    /// 创建时间: 
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public interface ICustomerTypeDao : IDaoBase<CustomerType>
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
        IList<CustomerType> SearchCustomerType(CustomerType customerType);

        /// <summary>
        /// 名   称:  SearchCustomerTypeRowCount
        /// 功能概要: 获取客户类型列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchCustomerTypeRowCount(CustomerType customerType);


        /// <summary>
        /// 名   称:  CheckCustomerTypeIsUse
        /// 功能概要: 检查客户类型是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日11:35:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckCustomerTypeIsUse(long customerTypeId);
        #endregion
    }
}
