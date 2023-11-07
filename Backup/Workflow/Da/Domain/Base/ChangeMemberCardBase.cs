using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table CHANGE_MEMBER_CARD 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class ChangeMemberCardBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 会员卡_ID [MEMBER_CARD_ID] */
		private long memberCardId;
		/** 老卡号 [OLD_MEMBER_CARD_NO] */
		private string oldMemberCardNo;
		/** 新卡号 [NEW_MEMBER_CARD_NO] */
		private string newMemberCardNo;
		/** 备注 [MEMO] */
		private string memo;

		public ChangeMemberCardBase()
		{
			
		}

		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return this.id; }
			set { this.id = value; }
		}
		/// <summary>
		/// 会员卡_ID [MEMBER_CARD_ID]
		/// </summary>
		public virtual long MemberCardId
		{
			get { return this.memberCardId; }
			set { this.memberCardId = value; }
		}
		/// <summary>
		/// 老卡号 [OLD_MEMBER_CARD_NO]
		/// </summary>
		public virtual string OldMemberCardNo
		{
			get { return this.oldMemberCardNo; }
			set { this.oldMemberCardNo = value; }
		}
		/// <summary>
		/// 新卡号 [NEW_MEMBER_CARD_NO]
		/// </summary>
		public virtual string NewMemberCardNo
		{
			get { return this.newMemberCardNo; }
			set { this.newMemberCardNo = value; }
		}
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}


	}
}
