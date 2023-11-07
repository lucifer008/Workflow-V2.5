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
	/// Table MEMBER_CARD_BUY_SEND (会员卡买M送N) 对应的Dao 实现
	/// </summary>
    public class MemberCardBuySendDaoImpl : Workflow.Da.Base.DaoBaseImpl<MemberCardBuySend>, IMemberCardBuySendDao
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
		public IList<MemberCardBuySend> SelectListByMemberCardId(long memberCardId)
		{
			Hashtable map = new Hashtable();
			map.Add("MemberCardId", memberCardId);
			map.Add("CurrentDataTime",DateTime.Now );
			return sqlMap.QueryForList<MemberCardBuySend>("MemberCardBuySend.SelectListByMemberCardId", map);
		}
		#endregion
		
    }
}