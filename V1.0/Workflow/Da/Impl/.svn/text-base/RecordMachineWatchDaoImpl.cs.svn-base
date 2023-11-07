using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
using System.Collections;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table RECORD_MACHINE_WATCH 对应的Dao 实现
	/// </summary>
    public class RecordMachineWatchDaoImpl : Workflow.Da.Base.DaoBaseImpl<RecordMachineWatch>, IRecordMachineWatchDao
    {
        public RecordMachineWatch SelectLastTimeRecordMachineWatch(RecordMachineWatch recordMachineWatch)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            recordMachineWatch.CompanyId = user.CompanyId;
            recordMachineWatch.BranchShopId = user.BranchShopId;
            return sqlMap.QueryForObject<RecordMachineWatch>("RecordMachineWatch.SelectLastTimeRecordMachineWatch", recordMachineWatch);
        }

		#region 获取一个可用的抄表记录

		/// <summary>
		/// 获取一个可用的抄表记录
		/// 用于临时存放当前的抄表信息,本次信息进行核实后才有效
		/// </summary>
		/// <returns>RecordMachineWatch</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.24
		/// </remarks>
		public RecordMachineWatch SelectCompleteRecordMachineWatch()
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			map.Add("isconfirmed", Constants.FALSE);
			return sqlMap.QueryForObject<RecordMachineWatch>("RecordMachineWatch.SelectCompleteRecordMachineWatch", map);
		}

		#endregion

		#region 获取最后一次抄表记录

		/// <summary>
		/// 获取最后一次抄表记录
		/// </summary>
		/// <returns>RecordMachineWatch</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.28
		/// </remarks>
		public RecordMachineWatch SelectLastRecordMachineWatch()
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			map.Add("isconfirmed", Constants.TRUE);
			return sqlMap.QueryForObject<RecordMachineWatch>("RecordMachineWatch.SelectLastRecordMachineWatch", map);
		}

		#endregion

		#region 获取核实抄表,完成的工单的用纸数,通过上次抄表时间,机器id,纸型id

		/// <summary>
		/// 获取核实抄表,完成的工单的用纸数,通过上次抄表时间,机器id,纸型id
		/// </summary>
		/// <returns>数量</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.4
		/// </remarks>
		public int GetVerifyRecordWatchCompleteOrderUsedCount(Hashtable map)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			return sqlMap.QueryForObject<int>("RecordMachineWatch.GetVerifyRecordWatchCompleteOrderUsedCount", map);
		}

		#endregion

		#region 更新抄表记录的确认状态

		/// <summary>
		/// 更新抄表记录的确认状态
		/// </summary>
		/// <param name="recordMachineWatchId">抄表记录状态</param>
		/// <param name="status">状态</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.7
		/// </remarks>
		public void UpdateIsConfirmedById(long recordMachineWatchId, string status)
		{
			Hashtable map = new Hashtable();
			map.Add("id", recordMachineWatchId);
			map.Add("status", status);
			sqlMap.Update("RecordMachineWatch.UpdateIsConfirmedById", map);
		}

		#endregion
	}
}
