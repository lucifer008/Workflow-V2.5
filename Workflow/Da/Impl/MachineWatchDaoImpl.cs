using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table MACHINE_WATCH ��Ӧ��Dao ʵ��
	/// </summary>
    public class MachineWatchDaoImpl : Workflow.Da.Base.DaoBaseImpl<MachineWatch>, IMachineWatchDao
	{

		#region ��ȡ�����ϵı�ͨ���������id

		/// <summary>
		/// ��ȡ�����ϵı�ͨ���������id
		/// </summary>
		/// <param name="machineTypeId">�������id</param>
		/// <returns>�����ϵı��б�</returns>
		public IList<MachineWatch> SelectMachineWatchByMachineTypeId(long machineTypeId)
		{
			return sqlMap.QueryForList<MachineWatch>("MachineWatch.SelectMachineWatchByMachineTypeId", machineTypeId);
		}

		#endregion
	}
}
