using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table COMPENSATE_USED_PAPER 对应的Dao 接口
	/// </summary>
    public interface ICompensateUsedPaperDao : IDaoBase<CompensateUsedPaper>
    {
        /// <summary>
        /// 获得机器抄表核对时的补单数量
        /// </summary>
        /// <param name="compensateUsedPaper"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-23
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        int SelectMachineWatchRecordPatchCount(CompensateUsedPaper compensateUsedPaper);

		#region 获取补单的用纸数量

		/// <summary>
		/// 获取补单的用纸数量
		/// </summary>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <param name="machineId">机器id</param>
		/// <param name="paperId">纸型id</param>
		/// <param name="colorType">纸色区分</param>
		/// <returns>CompensateUsedPaperList</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.4
		/// </remarks>
		IList<CompensateUsedPaper> SelectCompensateUsedPaper(long recordMachineWatchId, long machineId, long paperId, string colorType);

		#endregion

		#region 获取补单的用纸数量

		/// <summary>
		/// 获取补单的用纸数量
		/// </summary>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <returns>CompensateUsedPaperList</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.4
		/// </remarks>
		IList<CompensateUsedPaper> SelectCompensateUsedPaper(long recordMachineWatchId);

		#endregion

		#region 删除补单通过

		/// <summary>
		/// 删除补单通过
		/// </summary>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.4
		/// </remarks>
		void DeleteByRecordMachieWatch(long recordMachineWatchId);
		
		#endregion


		
	}
}
