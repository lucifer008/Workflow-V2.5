using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using System.Collections;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table COMPENSATE_USED_PAPER 对应的Dao 实现
	/// </summary>
    public class CompensateUsedPaperDaoImpl : Workflow.Da.Base.DaoBaseImpl<CompensateUsedPaper>, ICompensateUsedPaperDao
    {
        #region //获得机器抄表核对时的补单数量
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
        public int SelectMachineWatchRecordPatchCount(CompensateUsedPaper compensateUsedPaper)
        {
            return sqlMap.QueryForObject<int>("CompensateUsedPaper.SelectMachineWatchRecordPatchCount", compensateUsedPaper);
        }
        #endregion


		#region 获取补单的用纸数量

		/// <summary>
		/// 获取补单的用纸数量
		/// </summary>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <param name="machineTypeId">机器类型id</param>
		/// <param name="paperId">纸型id</param>
		/// <param name="colorType">纸色区分</param>
		/// <returns>数量</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.4
		/// </remarks>
		public IList<CompensateUsedPaper> SelectCompensateUsedPaper(long recordMachineWatchId, long machineTypeId, long paperId, long paperId2, long paperId3, string colorType)
		{
			Hashtable map = new Hashtable();
			map.Add("recordmachinewatchid", recordMachineWatchId);
			map.Add("machineTypeId", machineTypeId);
			map.Add("paperid", paperId);
			map.Add("paperid2", paperId2);
			map.Add("paperId3", paperId3);
			map.Add("colortype", colorType);
			return sqlMap.QueryForList<CompensateUsedPaper>("CompensateUsedPaper.SelectCompensateUsedPaper", map);
		}

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
		public IList<CompensateUsedPaper> SelectCompensateUsedPaper(long recordMachineWatchId)
		{
			return sqlMap.QueryForList<CompensateUsedPaper>("CompensateUsedPaper.SelectCompensateUsedPaperById", recordMachineWatchId);
		}

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
		public void DeleteByRecordMachieWatch(long recordMachineWatchId)
		{
			sqlMap.Delete("CompensateUsedPaper.DeleteByRecordMachieWatch", recordMachineWatchId);
		}

		#endregion
	}
}
