using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table REPORT_LESS_MODE 对应的Dao 实现
	/// </summary>
    public class ReportLessModeDaoImpl : Workflow.Da.Base.DaoBaseImpl<ReportLessMode>, IReportLessModeDao
    {
        #region//挂失方式
        /// <summary>
        /// 名   称:  SearchReportLessMode
        /// 功能概要: 获取挂失方式列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<ReportLessMode> SearchReportLessMode(ReportLessMode reportLessMode) 
        {
            reportLessMode.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            reportLessMode.BranchShopId= Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<ReportLessMode>("ReportLessMode.SearchReportLessMode", reportLessMode);
        }

        /// <summary>
        /// 名   称:  SearchReportLessModeRowCount
        /// 功能概要: 获取挂失方式列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchReportLessModeRowCount(ReportLessMode reportLessMode) 
        {
            return sqlMap.QueryForObject<long>("ReportLessMode.SearchReportLessModeRowCount", reportLessMode);
        }

        /// <summary>
        /// 名   称:  CheckReportLessModeIsUse
        /// 功能概要: 检查挂失方式是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日10:36:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckReportLessModeIsUse(long reportLessModeId) 
        {
            ReportLessMode reportLessMode = new ReportLessMode();
            reportLessMode.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            reportLessMode.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            reportLessMode.Id = reportLessModeId;
            return sqlMap.QueryForObject<long>("ReportLessMode.CheckReportLessModeIsUse", reportLessMode);
        }
        #endregion
    }
}
