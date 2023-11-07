using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table DAILY_RECORD_MACHINE 对应的Dao 实现
	/// </summary>
    public class DailyRecordMachineDaoImpl : Workflow.Da.Base.DaoBaseImpl<DailyRecordMachine>, IDailyRecordMachineDao
    {
        #region //机器数查询

        /// <summary>
        /// 计数器自定义查询
        /// </summary>
        /// <param name="dailyRecordMachine"></param>
        /// <returns></returns>
        public IList<DailyRecordMachine> SelectDailyRecordMachineListCustomQuery(DailyRecordMachine dailyRecordMachine)
        {
			//dailyRecordMachine.MachineName = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId.ToString();//分店Id
			//dailyRecordMachine.Id = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;//公司Id
			//return sqlMap.QueryForList<DailyRecordMachine>("DailyRecordMachine.SelectDailyRecordMachineListCustomQuery", dailyRecordMachine);
			return null;
        }

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
        public IList<DailyRecordMachine> GetDailyRecordMachineListCustomQueryPrint(DailyRecordMachine dailyRecordMachine) 
        {
			//dailyRecordMachine.MachineName = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId.ToString();//分店Id
			//dailyRecordMachine.Id = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;//公司Id
			//return sqlMap.QueryForList<DailyRecordMachine>("DailyRecordMachine.GetDailyRecordMachineListCustomQueryPrint", dailyRecordMachine);
			return null;
        }

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
        public long GetDailyRecordMachineListCustomQueryRowCount(DailyRecordMachine dailyRecordMachine) 
        {
            return sqlMap.QueryForObject<long>("DailyRecordMachine.GetDailyRecordMachineListCustomQueryRowCount", dailyRecordMachine);
        }
        #endregion

		#region 获取指定抄表ID的结果

		public IList<DailyRecordMachine> GetRecordMachineWatchResult(long recordMachineWatchId)
		{
			return sqlMap.QueryForList<DailyRecordMachine>("DailyRecordMachine.GetRecordMachineWatchResult", recordMachineWatchId);
		}

		#endregion
	}
}
