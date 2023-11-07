using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table MACHINE_WATCH_CONVERSION_PAPER 对应的Dao 接口
	/// </summary>
    public interface IMachineWatchConversionPaperDao : IDaoBase<MachineWatchConversionPaper>
    {
        IList<MachineWatchConversionPaper> SelectMachineWatchRecordCheckData(MachineWatchConversionPaper machineWatchConversionPaper);

		#region 获取所有计数器换算纸张

		/// <summary>
		/// 获取所有计数器换算纸张
		/// </summary>
		/// <returns>计数器换算纸张</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.28
		/// </remarks>
		IList<MachineWatchConversionPaper> GetAllMachineWatchConversionPaper();

		#endregion

		
	}
}
