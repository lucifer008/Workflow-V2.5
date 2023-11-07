using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名   称:  SecondaryTradeDaoImpl
    /// 功能概要: 客户子行业接口实现
    /// 作    者: 
    /// 创建时间: 
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class SecondaryTradeDaoImpl : Workflow.Da.Base.DaoBaseImpl<SecondaryTrade>, ISecondaryTradeDao
    {
        /// <summary>
        /// 名   称:  SearchMasterTrade
        /// 功能概要: 获取客户子行业列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<SecondaryTrade> SearchSecondaryTrade(SecondaryTrade secondaryTrade) 
        {
            secondaryTrade.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            secondaryTrade.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<SecondaryTrade>("SecondaryTrade.SearchSecondaryTrade", secondaryTrade);
        }

        /// <summary>
        /// 名   称:  SearchMasterTradeRowCount
        /// 功能概要: 获取客户子行业列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchSecondaryTradeRowCount(SecondaryTrade secondaryTrade) 
        {
            return sqlMap.QueryForObject<long>("SecondaryTrade.SearchSecondaryTradeRowCount", secondaryTrade);
        }
    }
}
