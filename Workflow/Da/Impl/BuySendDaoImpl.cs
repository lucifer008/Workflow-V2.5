#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using System.Collections;
#endregion

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table BUY_SEND (买M送N) 对应的Dao 实现
	/// </summary>
    public class BuySendDaoImpl : Workflow.Da.Base.DaoBaseImpl<BuySend>, IBuySendDao
	{
		#region 获取买M送N方案记录数
		/// <summary>
		/// 名    称: SelectAllBuySendListInfoRowCount
		/// 功能概要: 获取买M送N方案记录数
		/// 作    者: 白晓宇
		/// 创建时间: 2010年4月19日
		/// 修 正 人: 
		/// 修正时间: 
		/// 描    述: 
		/// </summary>
		public int SelectAllBuySendListInfoRowCount(Hashtable condition)
		{
			User domain = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser;
			condition.Add("CompanyId", domain.CompanyId);
			condition.Add("BranchShopId", domain.BranchShopId);

			return sqlMap.QueryForObject<int>("BuySend.SelectAllBuySendListInfoRowCount", condition);
		}
		#endregion

		#region 获取买M送N方案
		/// <summary>
		/// 名    称: SelectAllBuySendListInfo
		/// 功能概要: 获取买M送N方案
		/// 作    者: 白晓宇
		/// 创建时间: 2010年4月19日
		/// 修 正 人: 
		/// 修正时间: 
		/// 描    述: 
		/// </summary>
		public IList<BuySend> SelectAllBuySendListInfo(Hashtable condition)
		{
			User domain = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser;
			condition.Add("CompanyId", domain.CompanyId);
			condition.Add("BranchShopId", domain.BranchShopId);

			return sqlMap.QueryForList<BuySend>("BuySend.SelectAllBuySendListInfo", condition);
		}
		#endregion

		#region 获取当前活动
		/// <summary>
		/// 名    称: SelectCurrentBuySend
		/// 功能概要: 获取当前活动
		/// 作    者: 白晓宇
		/// 创建时间: 2010年4月20日
		/// 修 正 人: 
		/// 修正时间: 
		/// 描    述: 
		/// </summary>
		public BuySend SelectCurrentBuySend(DateTime dtNow)
		{
			return sqlMap.QueryForObject<BuySend>("BuySend.SelectCurrentBuySend", dtNow);
		}
		#endregion
	}
}