#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table MEMBER_CARD_BUY_SEND (会员卡买M送N)对应的Dao 接口
	/// </summary>
	public interface IMemberCardBuySendDao : IDaoBase<MemberCardBuySend>
	{
		#region 通过会员卡Id获取活动信息
		/// <summary>
		/// 名    称: 通过会员卡Id获取活动信息
		/// 功能概要: 活动管理Action
		/// 作    者: 
		/// 创建时间: 
		/// 修 正 人: 白晓宇
		/// 修正时间: 2010-4-24		
		/// 描    述: 
		/// </summary>
		IList<MemberCardBuySend> SelectListByMemberCardId(long memberCardId);
		#endregion
	}
}