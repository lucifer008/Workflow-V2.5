#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table MEMBER_CARD_DISCOUNT_CONCESSION (会员卡参加的打折优惠活动)对应的Dao 接口
	/// </summary>
	public interface IMemberCardDiscountConcessionDao : IDaoBase<MemberCardDiscountConcession>
	{
		#region 获取有效的会员卡参加的打折活动-通过会员卡id

		/// <summary>
		/// 获取有效的会员卡参加的打折活动-通过会员卡id
		/// </summary>
		/// <param name="memberCardId">会员卡id</param>
		/// <returns>会员卡参加的打折活动</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.20
		/// </remarks>
		IList<MemberCardDiscountConcession> SelectValidMemberDiscountCardConcession(long memberCardId);
		
		#endregion


		#region 订单明细使用活动,更新打折活动的剩余金额

		/// <summary>
		/// 订单明细使用活动,更新打折活动的剩余金额
		/// </summary>
		/// <param name="id">打折活动id</param>
		/// <param name="amount">使用的金额</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.26
		/// </remarks>
		void UpdateRestAmount(long id, decimal amcount);

		#endregion
	}
}