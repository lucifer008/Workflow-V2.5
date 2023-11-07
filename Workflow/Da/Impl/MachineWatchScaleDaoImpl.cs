using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table MACHINE_WATCH_SCALE 对应的Dao 实现
	/// </summary>
    public class MachineWatchScaleDaoImpl : Workflow.Da.Base.DaoBaseImpl<MachineWatchScale>, IMachineWatchScaleDao
    {
        #region //根据机器显示机器的上次读数
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
        public IList<MachineWatchScale> SelectLastNumberByMachineId(long id)
        {
            return sqlMap.QueryForList<MachineWatchScale>("MachineWatchScale.SelectLastNumberByMachineId", id);
        }
        #endregion

        #region //更新表的最新读数
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
        public void UpdateLastNumber(MachineWatchRecordLog machineWatchRecordLog)
        {
            sqlMap.Update("MachineWatchScale.UpdateLastNumber", machineWatchRecordLog);
        }
        #endregion
    }
}
