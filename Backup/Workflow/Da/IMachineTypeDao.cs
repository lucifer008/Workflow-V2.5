using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
    /// <summary>
    /// ��    ��: IMachineTypeDao
    /// ���ܸ�Ҫ����������Dao�ӿ�
    /// ��    ��:
    /// ����ʱ��:
    /// ��������:
    /// ����ʱ�䣺
    /// </summary>
    public interface IMachineTypeDao : IDaoBase<MachineType>
    {
        #region //��������
        /// <summary>
        /// ��    �ƣ�SearchMachineType
        /// ���ܸ�Ҫ: ��ȡ���������б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��4��10:08:21
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<MachineType> SearchMachineType(MachineType machineType);

        /// <summary>
        /// ��    �ƣ�SearchMachineTypeRowCount
        /// ���ܸ�Ҫ: ��ȡ���������б��¼��
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��4��10:08:21
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchMachineTypeRowCount(MachineType machineType);

        /// <summary>
        /// ��    �ƣ�CheckMachineTypeIsUse
        /// ���ܸ�Ҫ: �����������Ƿ�����ʹ��
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��4��13:35:19
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long CheckMachineTypeIsUse(long machineTypeId); 
        #endregion

		/// <summary>
		/// ��ȡ������Ҫ����Ļ�������
		/// </summary>
		/// <returns>��������</returns>
		IList<MachineType> SearchNeedRecordMachineType();
	}
}
