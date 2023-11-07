using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table MACHINE_WATCH_SCALE ��Ӧ��Dao ʵ��
	/// </summary>
    public class MachineWatchScaleDaoImpl : Workflow.Da.Base.DaoBaseImpl<MachineWatchScale>, IMachineWatchScaleDao
    {
        #region //���ݻ�����ʾ�������ϴζ���
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
        public IList<MachineWatchScale> SelectLastNumberByMachineId(long id)
        {
            return sqlMap.QueryForList<MachineWatchScale>("MachineWatchScale.SelectLastNumberByMachineId", id);
        }
        #endregion

        #region //���±�����¶���
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
        public void UpdateLastNumber(MachineWatchRecordLog machineWatchRecordLog)
        {
            sqlMap.Update("MachineWatchScale.UpdateLastNumber", machineWatchRecordLog);
        }
        #endregion
    }
}
