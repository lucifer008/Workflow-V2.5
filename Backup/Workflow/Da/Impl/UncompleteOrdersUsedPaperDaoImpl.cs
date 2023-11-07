using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table UNCOMPLETE_ORDERS_USED_PAPER 对应的Dao 实现
	/// </summary>
    public class UncompleteOrdersUsedPaperDaoImpl : Workflow.Da.Base.DaoBaseImpl<UncompleteOrdersUsedPaper>, IUncompleteOrdersUsedPaperDao
    {
        /// <summary>
        /// 取得未完工用纸量
        /// </summary>
        /// <param name="uncompleteOrdersUsedPaper"></param>
        /// <returns></returns>
        public UncompleteOrdersUsedPaper SelectUncompeleteOrderUsePaper(UncompleteOrdersUsedPaper uncompleteOrdersUsedPaper)
        {
            return sqlMap.QueryForObject<UncompleteOrdersUsedPaper>("UncompleteOrdersUsedPaper.SelectUncompeleteOrderUsePaper", uncompleteOrdersUsedPaper);
        }

		#region 获取未完工订单列表通过抄表id

		/// <summary>
		/// 获取未完工订单列表通过抄表id
		/// </summary>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <returns>UncompleteOrdersUsedPaperList</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.24
		/// </remarks>
		public IList<UncompleteOrdersUsedPaper> SelectUncompleteOrdersByRecordWatchId(long recordMachineWatchId)
		{
			return sqlMap.QueryForList<UncompleteOrdersUsedPaper>("UncompleteOrdersUsedPaper.SelectUncompleteOrdersByRecordWatchId", recordMachineWatchId);
		}

		#endregion

		#region 删除指定抄表记录下的未完工订单用纸情况

		/// <summary>
		/// 删除指定抄表记录下的未完工订单用纸情况
		/// </summary>
		/// <param name="recordMachineWatchId"></param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.24
		/// </remarks>
		public void DeleteUncompleteOrderByRecordWatchId(long recordMachineWatchId)
		{
			sqlMap.Delete("UncompleteOrdersUsedPaper.DeleteUncompleteOrderByRecordWatchId", recordMachineWatchId);
		}

		#endregion
	}
}
