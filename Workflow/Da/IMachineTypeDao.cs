using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
    /// <summary>
    /// 名    称: IMachineTypeDao
    /// 功能概要：机器类型Dao接口
    /// 作    者:
    /// 创建时间:
    /// 修正履历:
    /// 修正时间：
    /// </summary>
    public interface IMachineTypeDao : IDaoBase<MachineType>
    {
        #region //机器类型
        /// <summary>
        /// 名    称：SearchMachineType
        /// 功能概要: 获取机器类型列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日10:08:21
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<MachineType> SearchMachineType(MachineType machineType);

        /// <summary>
        /// 名    称：SearchMachineTypeRowCount
        /// 功能概要: 获取机器类型列表记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日10:08:21
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchMachineTypeRowCount(MachineType machineType);

        /// <summary>
        /// 名    称：CheckMachineTypeIsUse
        /// 功能概要: 检查机器类型是否正在使用
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日13:35:19
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckMachineTypeIsUse(long machineTypeId); 
        #endregion

		/// <summary>
		/// 获取所有需要抄表的机器类型
		/// </summary>
		/// <returns>机器类型</returns>
		IList<MachineType> SearchNeedRecordMachineType();
	}
}
