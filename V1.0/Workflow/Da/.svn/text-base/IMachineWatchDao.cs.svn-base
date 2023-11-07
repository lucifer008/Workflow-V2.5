using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table MACHINE_WATCH 对应的Dao 接口
	/// </summary>
    public interface IMachineWatchDao : IDaoBase<MachineWatch>
	{
		#region 获取机器上的表通过机器类别id

		/// <summary>
		/// 获取机器上的表通过机器类别id
		/// </summary>
		/// <param name="machineTypeId">机器类别id</param>
		/// <returns>机器上的表列表</returns>
		IList<MachineWatch> SelectMachineWatchByMachineTypeId(long machineTypeId);
		#endregion

		
	}
}
