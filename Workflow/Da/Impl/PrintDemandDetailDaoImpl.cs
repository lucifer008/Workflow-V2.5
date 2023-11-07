using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名   称: PrintDemandDetailDaoImpl
    /// 功能概要:印制要求明细接口实现
    /// 作    者:
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class PrintDemandDetailDaoImpl : Workflow.Da.Base.DaoBaseImpl<PrintDemandDetail>, IPrintDemandDetailDao
    {
        #region//印制要求明细

        /// <summary>
        /// 名   称:  SearchPrintDemandDetail
        /// 功能概要: 获取印制要求明细列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<PrintDemandDetail> SearchPrintDemandDetail(PrintDemandDetail printDemandDetail) 
        {
            printDemandDetail.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            printDemandDetail.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<PrintDemandDetail>("PrintDemandDetail.SearchPrintDemandDetail", printDemandDetail);
        }

        /// <summary>
        /// 名   称:  SearchPrintDemandDetailRowCount
        /// 功能概要: 获取印制要求明细列表数目
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchPrintDemandDetailRowCount(PrintDemandDetail printDemandDetail) 
        {
            return sqlMap.QueryForObject<long>("PrintDemandDetail.SearchPrintDemandDetailRowCount", printDemandDetail);
        }
        #endregion
    }
}
