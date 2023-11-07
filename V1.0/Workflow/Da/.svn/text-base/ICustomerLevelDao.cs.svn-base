using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
    /// <summary>
    /// 名    称: ICustomerLevelDao
    /// 功能概要: 客户级别接口
    /// 作    者: 
    /// 创建时间: 
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public interface ICustomerLevelDao : IDaoBase<CustomerLevel>
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
        IList<CustomerLevel> SearchCustomerLevel(CustomerLevel customerLevel);

        /// <summary>
        /// 名   称:  SearchCustomerLevelRowCount
        /// 功能概要: 获取客户级别列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日10:04:46
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchCustomerLevelRowCount(CustomerLevel customerLevel);

        /// <summary>
        /// 名   称:  CheckCustomerLevelIsUse
        /// 功能概要: 检查客户级别是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月19日11:35:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckCustomerLevelIsUse(long customerLevelId);
        #endregion
    }
}
