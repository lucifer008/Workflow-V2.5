using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
    /// <summary>
    /// ��    ��:IMachineDao
    /// ���ܸ�Ҫ:�����ӿ�
    /// ��    ��:
    /// ����ʱ��:
    /// ����������������
    /// ����ʱ��:2009��5��4��14:34:24
    /// ��    ��:��������
    /// </summary>
    public interface IMachineDao : IDaoBase<Machine>
	{
		#region ��ȡ�����ϵı�����¿̶�
		/// <summary>
		/// ���ܸ�Ҫ: ��ȡ�����ϵı�����¿̶�
		/// </summary>
		/// <returns>machineList</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-2-10
		/// </remarks>
		IList<Machine> GetMachineLastestNumBer();

		#endregion

		#region ��ȡ��Ҫ����Ļ���

		/// <summary>
		/// ��ȡ��Ҫ����Ļ���
		/// </summary>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.23
		/// </remarks>
		/// <returns>machineList</returns>
		IList<Machine> SelectNeedRecordWarchMachine();

		#endregion

        /// <summary>
        /// ��    �ƣ�SearchMachine
        /// ���ܸ�Ҫ: ��ȡ�����б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��4��14:25:54
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<Machine> SearchMachine(Machine machine);

        /// <summary>
        /// ��    �ƣ�SearchMachineRowCount
        /// ���ܸ�Ҫ: ��ȡ������¼��
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��4��14:25:45
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchMachineRowCount(Machine machine);
	}
}
