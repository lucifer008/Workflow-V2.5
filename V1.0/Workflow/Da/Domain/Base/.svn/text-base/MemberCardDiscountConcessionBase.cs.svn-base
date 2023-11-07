#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MEMBER_CARD_DISCOUNT_CONCESSION (会员卡参加的打折优惠活动) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MemberCardDiscountConcessionBase
	{
		
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
		
		#region MemberCardId
		/* 会员卡_ID [MEMBER_CARD_ID] */
		private long memberCardId;
		/// <summary>
		/// 会员卡_ID [MEMBER_CARD_ID]
		/// </summary>
		public virtual long MemberCardId
		{
			get { return memberCardId ;	}
			set { memberCardId=value;		}	
		}
		#endregion
		
		#region DiscountConcessionId
		/* 打折的优惠活动_ID [DISCOUNT_CONCESSION_ID] */
		private long discountConcessionId;
		/// <summary>
		/// 打折的优惠活动_ID [DISCOUNT_CONCESSION_ID]
		/// </summary>
		public virtual long DiscountConcessionId
		{
			get { return discountConcessionId ;	}
			set { discountConcessionId=value;		}	
		}
		#endregion
		
		#region JoinDateTime
		/* 参加时间 [JOIN_DATE_TIME] */
		private DateTime joinDateTime;
		/// <summary>
		/// 参加时间 [JOIN_DATE_TIME]
		/// </summary>
		public virtual DateTime JoinDateTime
		{
			get { return joinDateTime ;	}
			set { joinDateTime=value;		}	
		}
		#endregion
		
		#region Amount
		/* 收款金额 [AMOUNT] */
		private decimal amount;
		/// <summary>
		/// 收款金额 [AMOUNT]
		/// </summary>
		public virtual decimal Amount
		{
			get { return amount ;	}
			set { amount=value;		}	
		}
		#endregion
		
		#region RestAmount
		/* 剩余金额 [REST_AMOUNT] */
		private decimal restAmount;
		/// <summary>
		/// 剩余金额 [REST_AMOUNT]
		/// </summary>
		public virtual decimal RestAmount
		{
			get { return restAmount ;	}
			set { restAmount=value;		}	
		}
		#endregion
		
		#region DiffAmount
		/* 因折扣累计少收金额 [DIFF_AMOUNT] */
		private decimal diffAmount;
		/// <summary>
		/// 因折扣累计少收金额 [DIFF_AMOUNT]
		/// </summary>
		public virtual decimal DiffAmount
		{
			get { return diffAmount ;	}
			set { diffAmount=value;		}	
		}
		#endregion
		
		#region CounteractTimes
		/* 冲减次数 [COUNTERACT_TIMES] */
		private int counteractTimes;
		/// <summary>
		/// 冲减次数 [COUNTERACT_TIMES]
		/// </summary>
		public virtual int CounteractTimes
		{
			get { return counteractTimes ;	}
			set { counteractTimes=value;		}	
		}
		#endregion
	}
}