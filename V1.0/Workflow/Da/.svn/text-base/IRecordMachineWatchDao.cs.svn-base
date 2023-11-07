using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table RECORD_MACHINE_WATCH 对应的Dao 接口
	/// </summary>
    public interface IRecordMachineWatchDao : IDaoBase<RecordMachineWatch>
    {
        RecordMachineWatch SelectLastTimeRecordMachineWatch(RecordMachineWatch recordMachineWatch);

		#region 获取一个可用的抄表记录

		/// <summary>
		/// 获取一次未核实的抄表记录
		/// </summary>
		/// <returns>RecordMachineWatch</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.24
		/// </remarks>
		RecordMachineWatch SelectCompleteRecordMachineWatch();

		#endregion

		#region 获取最后一次抄表记录

		/// <summary>
		/// 获取最后一次抄表记录
		/// </summary>
		/// <returns>RecordMachineWatch</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.28
		/// </remarks>
		RecordMachineWatch SelectLastRecordMachineWatch();

		#endregion

		#region 获取核实抄表,完成的工单的用纸数,通过上次抄表时间,机器id,纸型id

		/// <summary>
		/// 获取核实抄表,完成的工单的用纸数,通过上次抄表时间,机器id,纸型id
		/// </summary>
		/// <returns>数量</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.4
		/// </remarks>
		int GetVerifyRecordWatchCompleteOrderUsedCount(System.Collections.Hashtable map);

		#endregion

		#region 更新抄表记录的确认状态

		/// <summary>
		/// 更新抄表记录的确认状态
		/// </summary>
		/// <param name="recordMachineWatchId">抄表记录状态</param>
		/// <param name="status">状态</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.7
		/// </remarks>
		void UpdateIsConfirmedById(long recordMachineWatchId, string status);

		#endregion
		
	}
}
