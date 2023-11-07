using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using System.Collections;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table MACHINE_WATCH_RECORD_LOG 对应的Dao 实现
	/// </summary>
    public class MachineWatchRecordLogDaoImpl : Workflow.Da.Base.DaoBaseImpl<MachineWatchRecordLog>, IMachineWatchRecordLogDao
    {
        /// <summary>
        /// 通过机器ID,抄表ID,计数器ID获得本次抄表读数
        /// </summary>
        /// <returns></returns>
        public int SelectMachineWatchValue(MachineWatchRecordLog machineWatchRecordLog)
        {
            return sqlMap.QueryForObject<int>("MachineWatchRecordLog.SelectMachineWatchValue", machineWatchRecordLog);
        }

		#region 获取表的读数通过抄表记录id和机器表id

		/// <summary>
		/// 获取表的读数通过抄表记录id和机器表id
		/// </summary>
		/// <param name="recordMachineWatchId">抄表记录id</param>
		/// <param name="machineWatchId">机器表id</param>
		/// <returns>读书</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.28
		/// </remarks>
		public int GetLastMachineWatchNumber(long recordMachineWatchId, long machineWatchId)
		{
			Hashtable map=new Hashtable();
			map.Add("recordMachineWatchId",recordMachineWatchId);
			map.Add("machineWatchId",machineWatchId);
			return sqlMap.QueryForObject<int>("MachineWatchRecordLog.GetLastMachineWatchNumber", map);
		}

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
		public void DeleteUncompleteOrderByRecordWatchId(long recordMachineWatchId)
		{
			sqlMap.Delete("MachineWatchRecordLog.DeleteUncompleteOrderByRecordWatchId", recordMachineWatchId);
		}

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
		public IList<MachineWatchRecordLog> GetNeedVerifyRecordLog(long recordMachineWatchId, long machineTypeId)
		{
			Hashtable map=new Hashtable();
			map.Add("recordmachinewatchid",recordMachineWatchId);
			map.Add("machineTypeId", machineTypeId);
			return sqlMap.QueryForList<MachineWatchRecordLog>("MachineWatchRecordLog.GetNeedVerifyRecordLog",map);
		}

		#endregion
	}
}
