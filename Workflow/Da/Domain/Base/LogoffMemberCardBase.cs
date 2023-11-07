using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table LOGOFF_MEMBER_CARD ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class LogoffMemberCardBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ��Ա��_ID [MEMBER_CARD_ID] */
		private long memberCardId;
		/** ���� [NAME] */
		private string name;
		/** ע��ʱ�� [LOGOFF_DATE_TIME] */
		private DateTime logoffDateTime;
		/** ��ע [MEMO] */
		private string memo;
		/** ID [ID] */
		private long id;

		public LogoffMemberCardBase()
		{
			
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
		/// ���� [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}
		/// <summary>
		/// ע��ʱ�� [LOGOFF_DATE_TIME]
		/// </summary>
		public virtual DateTime LogoffDateTime
		{
			get { return this.logoffDateTime; }
			set { this.logoffDateTime = value; }
		}
		/// <summary>
		/// ��ע [MEMO]
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
