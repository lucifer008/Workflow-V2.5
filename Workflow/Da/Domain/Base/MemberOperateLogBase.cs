using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MEMBER_OPERATE_LOG ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class MemberOperateLogBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ��Ա��_ID [MEMBER_CARD_ID] */
		private long memberCardId;
		/** �������� [OPERATE_TYPE] */
		private string operateType;
		/** ��ע [MEMO] */
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
		/// ��Ա��_ID [MEMBER_CARD_ID]
		/// </summary>
		public virtual long MemberCardId
		{
			get { return this.memberCardId; }
			set { this.memberCardId = value; }
		}
		/// <summary>
		/// �������� [OPERATE_TYPE]
		/// </summary>
		public virtual string OperateType
		{
			get { return this.operateType; }
			set { this.operateType = value; }
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
