using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MEMBER_CARD ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class MemberCardBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** �ͻ�_ID [CUSTOMER_ID] */
		private long customerId;
		/** ��Ա���� [MEMBER_CARD_NO] */
		private string memberCardNo;
		/** ���� [NAME] */
		private string name;
		/** ���� [AGE] */
		private int age;
		/** EMAIL [EMAIL] */
		private string email;
		/** ���� [HOBBY] */
		private string hobby;
		/** �ֻ� [MOBILE_NO] */
		private string mobileNo;
		/** ְ�� [POSITION] */
		private string position;
		/** �Ա� [SEX] */
		private string sex;
		/** ��Ա��״̬ [MEMBER_STATE] */
		private string memberState;
		/** ���֤ [IDENTITY_CARD_NO] */
		private string identityCardNo;
		/** ���� [PASSWORD] */
		private string password;
		/** �Ἦ��ʼ�� [MEMBER_CARD_BEGIN_DATE] */
		private DateTime memberCardBeginDate;
		/** �Ἦ������ [MEMBER_CARD_END_DATE] */
		private DateTime memberCardEndDate;
		/** ��Ҫ��Ʊ [NEED_TICKET] */
		private string needTicket;
		/** �����ܶ� [CONSUME_AMOUNT] */
		private decimal consumeAmount;
		/** ���� [INTEGRAl] */
		private int integral;

		public MemberCardBase()
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
		/// �ͻ�_ID [CUSTOMER_ID]
		/// </summary>
		public virtual long CustomerId
		{
			get { return this.customerId; }
			set { this.customerId = value; }
		}
		/// <summary>
		/// ��Ա���� [MEMBER_CARD_NO]
		/// </summary>
		public virtual string MemberCardNo
		{
			get { return this.memberCardNo; }
			set { this.memberCardNo = value; }
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
		/// ���� [AGE]
		/// </summary>
		public virtual int Age
		{
			get { return this.age; }
			set { this.age = value; }
		}
		/// <summary>
		/// EMAIL [EMAIL]
		/// </summary>
		public virtual string Email
		{
			get { return this.email; }
			set { this.email = value; }
		}
		/// <summary>
		/// ���� [HOBBY]
		/// </summary>
		public virtual string Hobby
		{
			get { return this.hobby; }
			set { this.hobby = value; }
		}
		/// <summary>
		/// �ֻ� [MOBILE_NO]
		/// </summary>
		public virtual string MobileNo
		{
			get { return this.mobileNo; }
			set { this.mobileNo = value; }
		}
		/// <summary>
		/// ְ�� [POSITION]
		/// </summary>
		public virtual string Position
		{
			get { return this.position; }
			set { this.position = value; }
		}
		/// <summary>
		/// �Ա� [SEX]
		/// </summary>
		public virtual string Sex
		{
			get { return this.sex; }
			set { this.sex = value; }
		}
		/// <summary>
		/// ��Ա��״̬ [MEMBER_STATE]
		/// </summary>
		public virtual string MemberState
		{
			get { return this.memberState; }
			set { this.memberState = value; }
		}
		/// <summary>
		/// ���֤ [IDENTITY_CARD_NO]
		/// </summary>
		public virtual string IdentityCardNo
		{
			get { return this.identityCardNo; }
			set { this.identityCardNo = value; }
		}
		/// <summary>
		/// ���� [PASSWORD]
		/// </summary>
		public virtual string Password
		{
			get { return this.password; }
			set { this.password = value; }
		}
		/// <summary>
		/// �Ἦ��ʼ�� [MEMBER_CARD_BEGIN_DATE]
		/// </summary>
		public virtual DateTime MemberCardBeginDate
		{
			get { return this.memberCardBeginDate; }
			set { this.memberCardBeginDate = value; }
		}
		/// <summary>
		/// �Ἦ������ [MEMBER_CARD_END_DATE]
		/// </summary>
		public virtual DateTime MemberCardEndDate
		{
			get { return this.memberCardEndDate; }
			set { this.memberCardEndDate = value; }
		}
		/// <summary>
		/// ��Ҫ��Ʊ [NEED_TICKET]
		/// </summary>
		public virtual string NeedTicket
		{
			get { return this.needTicket; }
			set { this.needTicket = value; }
		}
		/// <summary>
		/// �����ܶ� [CONSUME_AMOUNT]
		/// </summary>
		public virtual decimal ConsumeAmount
		{
			get { return this.consumeAmount; }
			set { this.consumeAmount = value; }
		}
		/// <summary>
		/// ���� [INTEGRAl]
		/// </summary>
		public virtual int Integral
		{
			get { return this.integral; }
			set { this.integral = value; }
		}

		private Workflow.Da.Domain.MemberCardLevel memberCardLevel;
		/// <summary>
		/// Source Table[MEMBER_CARD] Column[MEMBER_CARD_LEVEL_ID] --> Target Table[MEMBER_CARD_LEVEL] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.MemberCardLevel MemberCardLevel
		{
			get { return memberCardLevel; }
			set { memberCardLevel = value; }
		}
		private IList<Workflow.Da.Domain.MemberCardConcession> memberCardConcessionList;
		/// <summary>
		/// Source Table[MEMBER_CARD] Column[ID] --> Target Table[MEMBER_CARD_CONCESSION] Column[MEMBER_CARD_ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.MemberCardConcession> MemberCardConcessionList
		{
			get { return memberCardConcessionList; }
			set { memberCardConcessionList = value; }
		}
        #region MEMBER_CARD_DISCOUNT_CONCESSION JoinType 1:N	list_in
        private IList<Workflow.Da.Domain.MemberCardDiscountConcession> memberCardDiscountConcessionList;
        /// <summary>
        /// Source Table[MEMBER_CARD] Column[ID] --> Target IList<Table[MEMBER_CARD_DISCOUNT_CONCESSION]> Column[MEMBER_CARD_ID]
        /// PropertyComment	:MEMBER_CARD_DISCOUNT_CONCESSION:list:autoJoin=true
        /// JoinType 1:N	list_in
        /// </summary>
        public virtual IList<Workflow.Da.Domain.MemberCardDiscountConcession> MemberCardDiscountConcessionList
        {
            get { return memberCardDiscountConcessionList; }
            set { memberCardDiscountConcessionList = value; }
        }
        #endregion
	}
}
