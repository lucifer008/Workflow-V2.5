using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PAYMENT_CONCESSION ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class PaymentConcessionBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** �տ��¼_ID [GATHERING_ID] */
		private long gatheringId;
		/** �Ż����� [CONCESSION_TYPE] */
		private string concessionType;
		/** �Żݽ�� [CONCESSION_AMOUNT] */
		private decimal concessionAmount;
		/** ����ʱ�� [OPERATE_DATE_TIME] */
		private DateTime operateDateTime;
		/** ��ע [MEMO] */
		private string memo;

		public PaymentConcessionBase()
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
		/// �տ��¼_ID [GATHERING_ID]
		/// </summary>
		public virtual long GatheringId
		{
			get { return this.gatheringId; }
			set { this.gatheringId = value; }
		}
		/// <summary>
		/// �Ż����� [CONCESSION_TYPE]
		/// </summary>
		public virtual string ConcessionType
		{
			get { return this.concessionType; }
			set { this.concessionType = value; }
		}
		/// <summary>
		/// �Żݽ�� [CONCESSION_AMOUNT]
		/// </summary>
		public virtual decimal ConcessionAmount
		{
			get { return this.concessionAmount; }
			set { this.concessionAmount = value; }
		}
		/// <summary>
		/// ����ʱ�� [OPERATE_DATE_TIME]
		/// </summary>
		public virtual DateTime OperateDateTime
		{
			get { return this.operateDateTime; }
			set { this.operateDateTime = value; }
		}
		/// <summary>
		/// ��ע [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}

		private Workflow.Da.Domain.User authUsers;
		/// <summary>
		/// Source Table[PAYMENT_CONCESSION] Column[AUTH_USERS_ID] --> Target Table[USERS] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.User AuthUsers
		{
			get { return authUsers; }
			set { authUsers = value; }
		}
		private Workflow.Da.Domain.User operateUsers;
		/// <summary>
		/// Source Table[PAYMENT_CONCESSION] Column[OPERATE_USERS_ID] --> Target Table[USERS] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.User OperateUsers
		{
			get { return operateUsers; }
			set { operateUsers = value; }
		}

	}
}
