using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table REPORT_LESS_MODE 对应的Dao 接口
	/// </summary>
    public interface IReportLessModeDao : IDaoBase<ReportLessMode>
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
        IList<ReportLessMode> SearchReportLessMode(ReportLessMode reportLessMode);

        /// <summary>
        /// 名   称:  SearchReportLessModeRowCount
        /// 功能概要: 获取挂失方式列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchReportLessModeRowCount(ReportLessMode reportLessMode);

        /// <summary>
        /// 名   称:  CheckReportLessModeIsUse
        /// 功能概要: 检查挂失方式是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月27日10:36:51
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckReportLessModeIsUse(long reportLessModeId);
        #endregion
    }
}
