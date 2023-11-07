#region imports
using System;
using Workflow.Da.Domain.Base;
using System.Collections.Generic;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MEMBER_CARD_BUY_SEND (会员卡买M送N) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class MemberCardBuySend : MemberCardBuySendBase
	{
		public MemberCardBuySend()
		{

		}

		#region 订单详情
		private IList<OrderItem> orderItemList;
		/// <summary>
		/// 订单详情
		/// </summary>
		public IList<OrderItem> OrderItemList
		{
			get { return orderItemList; }
			set { orderItemList = value; }
		}
		#endregion

		#region 活动名称
		private string buySendName;
		/// <summary>
		/// 活动名称
		/// </summary>
		public string BuySendName
		{
			get { return buySendName; }
			set { buySendName = value; }
		}
		#endregion

		#region 买的数量
		private long buyCount;
		/// <summary>
		/// 买的数量
		/// </summary>
		public long BuyCount
		{
			get { return buyCount; }
			set { buyCount = value; }
		}
		#endregion

		#region 送的数量
		private long sendCount;
		/// <summary>
		/// 送的数量
		/// </summary>
		public long SendCount
		{
			get { return sendCount; }
			set { sendCount = value; }
		}
		#endregion
	}
}