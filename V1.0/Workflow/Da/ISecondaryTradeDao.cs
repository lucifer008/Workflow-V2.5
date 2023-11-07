using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
    /// <summary>
    /// 名   称:  ISecondaryTradeDao
    /// 功能概要: 客户子行业接口
    /// 作    者: 
    /// 创建时间: 
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public interface ISecondaryTradeDao : IDaoBase<SecondaryTrade>
    {
        /// <summary>
        /// 名   称:  SearchMasterTrade
        /// 功能概要: 获取客户子行业列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<SecondaryTrade> SearchSecondaryTrade(SecondaryTrade secondaryTrade);

        /// <summary>
        /// 名   称:  SearchMasterTradeRowCount
        /// 功能概要: 获取客户子行业列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchSecondaryTradeRowCount(SecondaryTrade secondaryTrade);
    }
}
