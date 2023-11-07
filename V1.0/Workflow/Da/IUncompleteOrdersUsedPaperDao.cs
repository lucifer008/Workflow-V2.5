using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table UNCOMPLETE_ORDERS_USED_PAPER 对应的Dao 接口
	/// </summary>
    public interface IUncompleteOrdersUsedPaperDao : IDaoBase<UncompleteOrdersUsedPaper>
    {
        /// <summary>
        /// 取得未完工用纸量
        /// </summary>
        /// <param name="uncompleteOrdersUsedPaper"></param>
        /// <returns></returns>
        UncompleteOrdersUsedPaper SelectUncompeleteOrderUsePaper(UncompleteOrdersUsedPaper uncompleteOrdersUsedPaper);

		#region 获取未完工工单列表通过抄表id

		/// <summary>
		/// 获取未完工工单列表通过抄表id
		/// </summary>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <returns>UncompleteOrdersUsedPaperList</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.24
		/// </remarks>
		IList<UncompleteOrdersUsedPaper> SelectUncompleteOrdersByRecordWatchId(long recordMachineWatchId);

		#endregion

		#region 删除指定抄表记录下的未完工工单用纸情况

		/// <summary>
		/// 删除指定抄表记录下的未完工工单用纸情况
		/// </summary>
		/// <param name="recordMachineWatchId"></param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.24
		/// </remarks>
		void DeleteUncompleteOrderByRecordWatchId(long recordMachineWatchId);

		#endregion

		
	}
}
