using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
    /// <summary>
    /// 名   称:  IMasterTradeDao
    /// 功能概要: 客户主行业接口
    /// 作    者: 
    /// 创建时间: 
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public interface IMasterTradeDao : IDaoBase<MasterTrade>
    {
        /// <summary>
        /// 名   称:  SearchMasterTrade
        /// 功能概要: 获取客主行业列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<MasterTrade> SearchMasterTrade(MasterTrade masterTrade);

        /// <summary>
        /// 名   称:  SearchMasterTradeRowCount
        /// 功能概要: 获取客主行业列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日10:20:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchMasterTradeRowCount(MasterTrade masterTrade);

         /// <summary>
        /// 名   称:  CheckMasterTradeIsUse
        /// 功能概要: 检查客户客户主行业是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日11:48:22
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckMasterTradeIsUse(long masterTradeId); 
    }
}
