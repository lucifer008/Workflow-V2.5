using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table TRASH_REASON 对应的Dao 接口
	/// </summary>
    public interface ITrashReasonDao : IDaoBase<TrashReason>
    {
        #region//废张原因
        /// <summary>
        /// 名   称:  SearchTrashReason
        /// 功能概要: 获取废张原因列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<TrashReason> SearchTrashReason(TrashReason trashReason);

        /// <summary>
        /// 名   称:  SearchTrashReasonRowCount
        /// 功能概要: 获取废张原因列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchTrashReasonRowCount(TrashReason trashReason);

        /// <summary>
        /// 名   称:  CheckTrashReasonIsUse
        /// 功能概要: 检查废张原因是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckTrashReasonIsUse(long trashReasonId);
        #endregion
    }
}
