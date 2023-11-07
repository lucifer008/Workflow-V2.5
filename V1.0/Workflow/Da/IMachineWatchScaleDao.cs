using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table MACHINE_WATCH_SCALE ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IMachineWatchScaleDao : IDaoBase<MachineWatchScale>
    {
        /// <summary>
        /// ���ݻ�����ʾ�������ϴζ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-10-22
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<MachineWatchScale> SelectLastNumberByMachineId(long id);

        /// <summary>
        /// ���±�����¶���
        /// </summary>
        /// <param name="newNumber"></param>
        /// <remarks>
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-10-22
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        void UpdateLastNumber(MachineWatchRecordLog machineWatchRecordLog);
    }
}
