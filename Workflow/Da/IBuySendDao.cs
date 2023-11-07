#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table BUY_SEND (买M送N)对应的Dao 接口
	/// </summary>
	public interface IBuySendDao : IDaoBase<BuySend>
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
		int SelectAllBuySendListInfoRowCount(Hashtable condition);
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
		IList<BuySend> SelectAllBuySendListInfo(Hashtable condition);
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
		BuySend SelectCurrentBuySend(DateTime dtNow);
		#endregion
	}
}