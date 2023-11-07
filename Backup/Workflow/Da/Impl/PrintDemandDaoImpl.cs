using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名   称: PrintDemandDaoImpl
    /// 功能概要:印制要求接口实现
    /// 作    者:
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class PrintDemandDaoImpl : Workflow.Da.Base.DaoBaseImpl<PrintDemand>, IPrintDemandDao
    {
        #region//印制要求
        /// <summary>
        /// 名   称:  SearchPrintDemand
        /// 功能概要: 获取印制要求列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<PrintDemand> SearchPrintDemand(PrintDemand printDemand) 
        {
            printDemand.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            printDemand.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<PrintDemand>("PrintDemand.SearchPrintDemand", printDemand);
        }

        /// <summary>
        /// 名   称:  SearchPrintDemandRowCount
        /// 功能概要: 获取印制要求列表数目
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchPrintDemandRowCount(PrintDemand printDemand) 
        {
            return sqlMap.QueryForObject<long>("PrintDemand.SearchPrintDemandRowCount", printDemand);
        }

        /// <summary>
        /// 名   称:  GetAllPrintDemand
        /// 功能概要: 获取所有印制要求列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日17:47:10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<PrintDemand> GetAllPrintDemand() 
        {
            PrintDemand printDemand = new PrintDemand();
            printDemand.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            printDemand.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<PrintDemand>("PrintDemand.SelectAll", printDemand);
        }

        /// <summary>
        /// 名   称:  CheckPrintDemandIsUse
        /// 功能概要: 检查印制要求是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日17:49:14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckPrintDemandIsUse(long printDemandId) 
        {
            PrintDemand printDemand = new PrintDemand();
            printDemand.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            printDemand.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            printDemand.Id = printDemandId;
            return sqlMap.QueryForObject<long>("PrintDemand.CheckPrintDemandIsUse", printDemand);
        }
        #endregion
    }
}
