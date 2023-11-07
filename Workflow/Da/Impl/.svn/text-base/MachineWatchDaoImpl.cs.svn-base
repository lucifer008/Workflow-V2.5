using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table MACHINE_WATCH 对应的Dao 实现
	/// </summary>
    public class MachineWatchDaoImpl : Workflow.Da.Base.DaoBaseImpl<MachineWatch>, IMachineWatchDao
	{

		#region 获取机器上的表通过机器类别id

		/// <summary>
		/// 获取机器上的表通过机器类别id
		/// </summary>
		/// <param name="machineTypeId">机器类别id</param>
		/// <returns>机器上的表列表</returns>
		public IList<MachineWatch> SelectMachineWatchByMachineTypeId(long machineTypeId)
		{
			return sqlMap.QueryForList<MachineWatch>("MachineWatch.SelectMachineWatchByMachineTypeId", machineTypeId);
		}

		#endregion
	}
}
