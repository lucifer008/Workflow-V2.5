using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table MACHINE_WATCH_SCALE 对应的Dao 接口
	/// </summary>
    public interface IMachineWatchScaleDao : IDaoBase<MachineWatchScale>
    {
        /// <summary>
        /// 根据机器显示机器的上次读数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-22
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<MachineWatchScale> SelectLastNumberByMachineId(long id);

        /// <summary>
        /// 更新表的最新读数
        /// </summary>
        /// <param name="newNumber"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-22
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void UpdateLastNumber(MachineWatchRecordLog machineWatchRecordLog);
    }
}
