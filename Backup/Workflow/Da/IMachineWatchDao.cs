using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table MACHINE_WATCH ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IMachineWatchDao : IDaoBase<MachineWatch>
	{
		#region ��ȡ�����ϵı�ͨ���������id

		/// <summary>
		/// ��ȡ�����ϵı�ͨ���������id
		/// </summary>
		/// <param name="machineTypeId">�������id</param>
		/// <returns>�����ϵı��б�</returns>
		IList<MachineWatch> SelectMachineWatchByMachineTypeId(long machineTypeId);
		#endregion

		
	}
}
