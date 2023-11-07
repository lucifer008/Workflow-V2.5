using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	///  名   称: IPaperTypeDao
    /// 功能概要:纸质操作接口
    /// 作    者:
    /// 修正履历:
    /// 修正时间:
	/// </summary>
    public interface IPaperTypeDao : IDaoBase<PaperType>
    {
        #region //纸质
        /// <summary>
        /// 名    称: SearchPaperType
        /// 功能概要: 获取纸质列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日9:53:28
        /// 修正时间:
        /// </summary>
        IList<PaperType> SearchPaperType(PaperType paperType);

        /// <summary>
        /// 名    称: SearchPaperTypeRowCount
        /// 功能概要: 获取纸质记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日9:53:28
        /// 修正时间:
        /// </summary>
        long SearchPaperTypeRowCount(PaperType paperType);

        #endregion
    }
}
