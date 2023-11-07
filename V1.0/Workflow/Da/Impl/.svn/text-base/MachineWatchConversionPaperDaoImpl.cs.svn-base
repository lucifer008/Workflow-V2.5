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
	/// Table MACHINE_WATCH_CONVERSION_PAPER 对应的Dao 实现
	/// </summary>
    public class MachineWatchConversionPaperDaoImpl : Workflow.Da.Base.DaoBaseImpl<MachineWatchConversionPaper>, IMachineWatchConversionPaperDao
    {
        public IList<MachineWatchConversionPaper> SelectMachineWatchRecordCheckData(MachineWatchConversionPaper machineWatchConversionPaper)
        {
            return sqlMap.QueryForList<MachineWatchConversionPaper>("MachineWatchConversionPaper.SelectMachineWatchRecordCheckData", machineWatchConversionPaper);
        }

		#region 获取所有计数器换算纸张

		/// <summary>
		/// 获取所有计数器换算纸张
		/// </summary>
		/// <returns>计数器换算纸张</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.28
		/// </remarks>
		public IList<MachineWatchConversionPaper> GetAllMachineWatchConversionPaper()
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			return sqlMap.QueryForList<MachineWatchConversionPaper>("MachineWatchConversionPaper.GetAllMachineWatchConversionPaper", map);
		}

		#endregion
	}
}
