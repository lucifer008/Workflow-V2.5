using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table DAILY_RECORD_MACHINE 对应的Dao 接口
	/// </summary>
    public interface IDailyRecordMachineDao : IDaoBase<DailyRecordMachine>
    {
        #region //机器数查询

        /// <summary>
        /// 计数器自定义查询
        /// </summary>
        /// <param name="dailyRecordMachine"></param>
        /// <returns></returns>
        IList<DailyRecordMachine> SelectDailyRecordMachineListCustomQuery(DailyRecordMachine dailyRecordMachine);

        /// <summary>
        /// 名    称: GetDailyRecordMachineListCustomQueryPrint
        /// 功能概要: 计数器查询(打印)
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月27日10:49:55
        /// 修 正 人: 
        /// 修正时间: 
        /// 描    述: 
        /// </summary>
        /// <param name="dailyRecordMachine"></param>
        /// <returns></returns>
        IList<DailyRecordMachine> GetDailyRecordMachineListCustomQueryPrint(DailyRecordMachine dailyRecordMachine);

        /// <summary>
        /// 名    称: GetDailyRecordMachineListCustomQueryRowCount
        /// 功能概要: 计数器查询记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月27日10:49:55
        /// 修 正 人: 
        /// 修正时间: 
        /// 描    述: 
        /// </summary>
        /// <param name="dailyRecordMachine"></param>
        /// <returns></returns>
        long GetDailyRecordMachineListCustomQueryRowCount(DailyRecordMachine dailyRecordMachine);
        #endregion
    }
}
