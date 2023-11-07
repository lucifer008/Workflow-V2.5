using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MEMBER_OPERATE_LOG 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MemberOperateLogBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 会员卡_ID [MEMBER_CARD_ID] */
		private long memberCardId;
		/** 操作类型 [OPERATE_TYPE] */
		private string operateType;
		/** 备注 [MEMO] */
		private string memo;

		public MemberOperateLogBase()
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
		/// 操作类型 [OPERATE_TYPE]
		/// </summary>
		public virtual string OperateType
		{
			get { return this.operateType; }
			set { this.operateType = value; }
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
