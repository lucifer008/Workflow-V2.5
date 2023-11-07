#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table OTHER_GATHERING_AND_REFUNDMENT_RECORD (其它收退款记录) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class OtherGatheringAndRefundmentRecordBase  : Workflow.Da.Domain.Base.MetaData 	{

		#region Id
		/* ID [ID] */
		private long id;
		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return id ;	}
			set { id=value;		}	
		}
		#endregion

		#region OrdersId
		/* 订单ID [ORDERS_ID] */
		private long ordersId;
		/// <summary>
		/// 订单ID [ORDERS_ID]
		/// </summary>
		public virtual long OrdersId
		{
			get { return ordersId ;	}
			set { ordersId=value;		}	
		}
		#endregion

		#region CustomerId
		/* 客户ID [CUSTOMER_ID] */
		private long customerId;
		/// <summary>
		/// 客户ID [CUSTOMER_ID]
		/// </summary>
		public virtual long CustomerId
		{
			get { return customerId ;	}
			set { customerId=value;		}	
		}
		#endregion

		#region MemberCardId
		/* 会员卡ID [MEMBER_CARD_ID] */
		private long memberCardId;
		/// <summary>
		/// 会员卡ID [MEMBER_CARD_ID]
		/// </summary>
		public virtual long MemberCardId
		{
			get { return memberCardId ;	}
			set { memberCardId=value;		}	
		}
		#endregion

		#region Amount
		/* 金额 [AMOUNT] */
		private decimal amount;
		/// <summary>
		/// 金额 [AMOUNT]
		/// </summary>
		public virtual decimal Amount
		{
			get { return amount ;	}
			set { amount=value;		}	
		}
		#endregion

		#region TicketAmountSum
		/* 发票金额 [TICKET_AMOUNT_SUM] */
		private decimal ticketAmountSum;
		/// <summary>
		/// 发票金额 [TICKET_AMOUNT_SUM]
		/// </summary>
		public virtual decimal TicketAmountSum
		{
			get { return ticketAmountSum ;	}
			set { ticketAmountSum=value;		}	
		}
		#endregion

		#region PayKind
		/* 付款类型 [PAY_KIND] */
		private string payKind;
		/// <summary>
		/// 付款类型 [PAY_KIND]
		/// </summary>
		public virtual string PayKind
		{
			get { return payKind ;	}
			set { payKind=value;		}	
		}
		#endregion

		#region Memo
		/* 备注 [MEMO] */
		private string memo;
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return memo ;	}
			set { memo=value;		}	
		}
		#endregion
	}
}