#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MEMBER_CARD_BUY_SEND (会员卡买M送N) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MemberCardBuySendBase 	{

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

		#region BuySendId
		/* 买M送N_ID [BUY_SEND_ID] */
		private long buySendId;
		/// <summary>
		/// 买M送N_ID [BUY_SEND_ID]
		/// </summary>
		public virtual long BuySendId
		{
			get { return buySendId ;	}
			set { buySendId=value;		}	
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

		#region RestPaperCount
		/* 剩余印章数 [REST_PAPER_COUNT] */
		private decimal restPaperCount;
		/// <summary>
		/// 剩余印章数 [REST_PAPER_COUNT]
		/// </summary>
		public virtual decimal RestPaperCount
		{
			get { return restPaperCount ;	}
			set { restPaperCount=value;		}	
		}
		#endregion

		#region PaperCount
		/* 总计印章数 [PAPER_COUNT] */
		private decimal paperCount;
		/// <summary>
		/// 总计印章数 [PAPER_COUNT]
		/// </summary>
		public virtual decimal PaperCount
		{
			get { return paperCount ;	}
			set { paperCount=value;		}	
		}
		#endregion
	}
}