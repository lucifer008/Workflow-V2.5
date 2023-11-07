#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MEMBER_CARD_CONCESSION (会员卡参加的优惠活动) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MemberCardConcessionBase
	{

		#region Id
		/* ID [ID] */
		private long id;
		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return id; }
			set { id = value; }
		}
		#endregion

		#region ConcessionId
		/* 送印章的优惠活动_ID [CONCESSION_ID] */
		private long concessionId;
		/// <summary>
		/// 送印章的优惠活动_ID [CONCESSION_ID]
		/// </summary>
		public virtual long ConcessionId
		{
			get { return concessionId; }
			set { concessionId = value; }
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
			get { return memberCardId; }
			set { memberCardId = value; }
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
			get { return joinDateTime; }
			set { joinDateTime = value; }
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
			get { return restPaperCount; }
			set { restPaperCount = value; }
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
			get { return paperCount; }
			set { paperCount = value; }
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
			get { return amount; }
			set { amount = value; }
		}
		#endregion

		#region CONCESSION JoinType N:1	single_in
		private Workflow.Da.Domain.Concession concession;
		/// <summary>
		/// Source Table[MEMBER_CARD_CONCESSION] Column[CONCESSION_ID] --> Target Table[CONCESSION] Column[ID]
		/// PropertyComment	CONCESSION_ID:CONCESSION:single:autoJoin=true
		/// JoinType N:1	single_in
		/// </summary>
		public virtual Workflow.Da.Domain.Concession Concession
		{
			get { return concession; }
			set { concession = value; }
		}
		#endregion
	}
}