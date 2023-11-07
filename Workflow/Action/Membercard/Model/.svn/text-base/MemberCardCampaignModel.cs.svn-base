using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Action.Membercard
{
	/// <summary>
	/// 会员卡活动Model
	/// </summary>
	/// <remarks>
	/// 作    者: 陈汝胤
	/// 创建时间: 2009-1-9
	/// </remarks>
	public class MemberCardCampaignModel
	{
		#region 相关会员卡参加的有效送印章活动信息

		private IList<MemberCardConcession> memberCardConcessionList;
		/// <summary>
		/// 相关会员卡参加的有效送印章活动信息
		/// </summary>
		public IList<MemberCardConcession> MemberCardConcessionList
		{
			get { return memberCardConcessionList; }
			set { memberCardConcessionList = value; }
		}

		#endregion

		#region 相关会员卡参加的打折活动的信息

		private IList<MemberCardDiscountConcession> memberCardDiscountConcessionList;
		/// <summary>
		/// 相关会员卡参加的打折活动的信息
		/// </summary>
		public IList<MemberCardDiscountConcession> MemberCardDiscountConcessionList
		{
			get { return memberCardDiscountConcessionList; }
			set { memberCardDiscountConcessionList = value; }
		}

		#endregion

		#region 相关订单明细信息

		private IList<OrderItem> orderItemList;
		/// <summary>
		/// 相关订单明细信息
		/// </summary>
		public IList<OrderItem> OrderItemList
		{
			get { return orderItemList; }
			set { orderItemList = value; }
		}

		#endregion
	}
}
