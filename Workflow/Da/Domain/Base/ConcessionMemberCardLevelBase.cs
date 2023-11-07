using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table CONCESSION_MEMBER_CARD_LEVEL 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class ConcessionMemberCardLevelBase 
	{
		/** ID [ID] */
		private long id;
		/** 优惠活动_ID [CONCESSION_ID] */
		private long concessionId;
		/** 卡级别_ID [MEMBER_CARD_LEVEL_ID] */
		private long memberCardLevelId;

		public ConcessionMemberCardLevelBase()
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
		/// 优惠活动_ID [CONCESSION_ID]
		/// </summary>
		public virtual long ConcessionId
		{
			get { return this.concessionId; }
			set { this.concessionId = value; }
		}
		/// <summary>
		/// 卡级别_ID [MEMBER_CARD_LEVEL_ID]
		/// </summary>
		public virtual long MemberCardLevelId
		{
			get { return this.memberCardLevelId; }
			set { this.memberCardLevelId = value; }
		}


	}
}
