using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名   称:  MasterTradeDaoImpl
    /// 功能概要: 客户主行业接口实现
    /// 作    者: 
    /// 创建时间: 
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class MasterTradeDaoImpl : Workflow.Da.Base.DaoBaseImpl<MasterTrade>, IMasterTradeDao
    {
        /// <summary>
        /// 名   称:  SearchMasterTrade
        /// 功能概要: 获取客主行业列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<MasterTrade> SearchMasterTrade(MasterTrade masterTrade) 
        {
            masterTrade.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            masterTrade.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<MasterTrade>("MasterTrade.SearchMasterTrade", masterTrade);
        }

        /// <summary>
        /// 名   称:  SearchMasterTradeRowCount
        /// 功能概要: 获取客主行业列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchMasterTradeRowCount(MasterTrade masterTrade)
        {
            return sqlMap.QueryForObject<long>("MasterTrade.SearchMasterTradeRowCount", masterTrade);
        }

        /// <summary>
        /// 名   称:  CheckMasterTradeIsUse
        /// 功能概要: 检查客户客户主行业是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日11:48:22
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckMasterTradeIsUse(long masterTradeId) 
        {
            MasterTrade masterTrade = new MasterTrade();
            masterTrade.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            masterTrade.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            masterTrade.Id = masterTradeId;
            return sqlMap.QueryForObject<long>("MasterTrade.CheckMasterTradeIsUse", masterTrade);
        }
    }
}
