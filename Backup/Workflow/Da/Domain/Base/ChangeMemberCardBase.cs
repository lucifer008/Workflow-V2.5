using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table CHANGE_MEMBER_CARD ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class ChangeMemberCardBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ��Ա��_ID [MEMBER_CARD_ID] */
		private long memberCardId;
		/** �Ͽ��� [OLD_MEMBER_CARD_NO] */
		private string oldMemberCardNo;
		/** �¿��� [NEW_MEMBER_CARD_NO] */
		private string newMemberCardNo;
		/** ��ע [MEMO] */
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
		/// ��Ա��_ID [MEMBER_CARD_ID]
		/// </summary>
		public virtual long MemberCardId
		{
			get { return this.memberCardId; }
			set { this.memberCardId = value; }
		}
		/// <summary>
		/// �Ͽ��� [OLD_MEMBER_CARD_NO]
		/// </summary>
		public virtual string OldMemberCardNo
		{
			get { return this.oldMemberCardNo; }
			set { this.oldMemberCardNo = value; }
		}
		/// <summary>
		/// �¿��� [NEW_MEMBER_CARD_NO]
		/// </summary>
		public virtual string NewMemberCardNo
		{
			get { return this.newMemberCardNo; }
			set { this.newMemberCardNo = value; }
		}
		/// <summary>
		/// ��ע [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}


	}
}
