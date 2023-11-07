using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table LOGOFF_MEMBER_CARD 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class LogoffMemberCardBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** 会员卡_ID [MEMBER_CARD_ID] */
		private long memberCardId;
		/** 姓名 [NAME] */
		private string name;
		/** 注销时间 [LOGOFF_DATE_TIME] */
		private DateTime logoffDateTime;
		/** 备注 [MEMO] */
		private string memo;
		/** ID [ID] */
		private long id;

		public LogoffMemberCardBase()
		{
			
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
		/// 姓名 [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}
		/// <summary>
		/// 注销时间 [LOGOFF_DATE_TIME]
		/// </summary>
		public virtual DateTime LogoffDateTime
		{
			get { return this.logoffDateTime; }
			set { this.logoffDateTime = value; }
		}
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return this.id; }
			set { this.id = value; }
		}


	}
}
