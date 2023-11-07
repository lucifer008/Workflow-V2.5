using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table PRINT_DEMAND 对应的Dao 接口
	/// </summary>
    public interface IPrintDemandDao : IDaoBase<PrintDemand>
    {
        #region//印制要求及明细
        /// <summary>
        /// 名   称:  SearchPrintDemand
        /// 功能概要: 获取印制要求列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<PrintDemand> SearchPrintDemand(PrintDemand printDemand);

        /// <summary>
        /// 名   称:  SearchPrintDemandRowCount
        /// 功能概要: 获取印制要求列表数目
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日11:49:00
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchPrintDemandRowCount(PrintDemand printDemand);

        /// <summary>
        /// 名   称:  GetAllPrintDemand
        /// 功能概要: 获取所有印制要求列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日17:47:10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<PrintDemand> GetAllPrintDemand();

        /// <summary>
        /// 名   称:  CheckPrintDemandIsUse
        /// 功能概要: 检查印制要求是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月26日17:49:14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckPrintDemandIsUse(long printDemandId);
        #endregion
    }
}
