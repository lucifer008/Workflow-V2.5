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
    /// 名    称:MachineDaoImpl
    /// 功能概要:机器接口实现
    /// 作    者:
    /// 创建时间:
    /// 修正履历：张晓林
    /// 修正时间:2009年5月4日14:34:24
    /// 描    述:代码整理
	/// </summary>
    public class MachineDaoImpl : Workflow.Da.Base.DaoBaseImpl<Machine>, IMachineDao
	{

		#region 获取所有的机器
		/// <summary>
		/// 功能概要: 获取机器上的表的最新刻度
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-2-10
		/// </summary>
		public IList<Machine> GetMachineLastestNumBer()
		{
			return sqlMap.QueryForList<Machine>("Machine.GetMachineLastestNumBer", null);
		}

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
		public IList<Machine> SelectNeedRecordWarchMachine()
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			map.Add("needrecordwatch", Constants.TRUE);
			return sqlMap.QueryForList<Machine>("Machine.SelectNeedRecordWarchMachine", map);
		}

		#endregion

        /// <summary>
        /// 名    称：SearchMachine
        /// 功能概要: 获取机器列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日14:25:54
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<Machine> SearchMachine(Machine machine) 
        {
            machine.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            machine.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Machine>("Machine.SearchMachine", machine);
        }

        /// <summary>
        /// 名    称：SearchMachineRowCount
        /// 功能概要: 获取机器记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月4日14:25:45
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchMachineRowCount(Machine machine) 
        {
            return sqlMap.QueryForObject<long>("Machine.SearchMachineRowCount", machine);
        }
	}
}
