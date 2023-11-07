using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table MACHINE_WATCH_RECORD_LOG 对应的Dao 接口
	/// </summary>
    public interface IMachineWatchRecordLogDao : IDaoBase<MachineWatchRecordLog>
    {
        /// <summary>
        /// 通过机器ID,抄表ID,计数器ID获得本次抄表读数
        /// </summary>
        /// <returns></returns>
        int SelectMachineWatchValue(MachineWatchRecordLog machineWatchRecordLog);

		#region 获取表的读数通过抄表记录id和机器表id

		/// <summary>
		///	获取表的读数通过抄表记录id和机器表id
		/// </summary>
		/// <param name="recordMachineWatchId">抄表记录id</param>
		/// <param name="machineWatchId">机器表id</param>
		/// <returns>读书</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.28
		/// </remarks>
		int GetLastMachineWatchNumber(long recordMachineWatchId, long machineWatchId);

		#endregion

		#region 删除未完成核实的抄表记录通过抄表id

		/// <summary>
		/// 删除未完成核实的抄表记录通过抄表id
		/// </summary>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.28
		/// </remarks>
		void DeleteUncompleteOrderByRecordWatchId(long recordMachineWatchId);
		
		#endregion

		#region 获取需要核对的抄表记录,通过抄表id和机器id

		/// <summary>
		/// 获取需要核对的抄表记录,通过抄表id和机器id
		/// </summary>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <param name="machineTypeId">机器类型id</param>
		/// <returns>抄表记录列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.30
		/// </remarks>
		IList<MachineWatchRecordLog> GetNeedVerifyRecordLog(long recordMachineWatchId, long machineTypeId);

		#endregion
	}
}
