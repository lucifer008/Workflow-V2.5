using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table MACHINE_WATCH_CONVERSION_PAPER ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IMachineWatchConversionPaperDao : IDaoBase<MachineWatchConversionPaper>
    {
        IList<MachineWatchConversionPaper> SelectMachineWatchRecordCheckData(MachineWatchConversionPaper machineWatchConversionPaper);

		#region ��ȡ���м���������ֽ��

		/// <summary>
		/// ��ȡ���м���������ֽ��
		/// </summary>
		/// <returns>����������ֽ��</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.28
		/// </remarks>
		IList<MachineWatchConversionPaper> GetAllMachineWatchConversionPaper();

		#endregion

		
	}
}
