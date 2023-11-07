using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
    /// <summary>
    /// 名    称:IMachineDao
    /// 功能概要:机器接口
    /// 作    者:
    /// 创建时间:
    /// 修正履历：张晓林
    /// 修正时间:2009年5月4日14:34:24
    /// 描    述:代码整理
    /// </summary>
    public interface IMachineDao : IDaoBase<Machine>
	{
		#region 获取机器上的表的最新刻度
		/// <summary>
		/// 功能概要: 获取机器上的表的最新刻度
		/// </summary>
		/// <returns>machineList</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-2-10
		/// </remarks>
		IList<Machine> GetMachineLastestNumBer();

		#endregion

		#region 获取需要抄表的机器

		/// <summary>
		/// 获取需要抄表的机器
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.23
		/// </remarks>
		/// <returns>machineList</returns>
		IList<Machine> SelectNeedRecordWarchMachine();

		#endregion

        /// <summary>
        /// 名    称：SearchMachine
        /// 功能概要: 获取机器列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日14:25:54
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<Machine> SearchMachine(Machine machine);

        /// <summary>
        /// 名    称：SearchMachineRowCount
        /// 功能概要: 获取机器记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日14:25:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchMachineRowCount(Machine machine);
	}
}
