using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MEMBER_CARD 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MemberCardBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 客户_ID [CUSTOMER_ID] */
		private long customerId;
		/** 会员卡号 [MEMBER_CARD_NO] */
		private string memberCardNo;
		/** 姓名 [NAME] */
		private string name;
		/** 年龄 [AGE] */
		private int age;
		/** EMAIL [EMAIL] */
		private string email;
		/** 爱好 [HOBBY] */
		private string hobby;
		/** 手机 [MOBILE_NO] */
		private string mobileNo;
		/** 职务 [POSITION] */
		private string position;
		/** 性别 [SEX] */
		private string sex;
		/** 会员卡状态 [MEMBER_STATE] */
		private string memberState;
		/** 身份证 [IDENTITY_CARD_NO] */
		private string identityCardNo;
		/** 密码 [PASSWORD] */
		private string password;
		/** 会籍起始日 [MEMBER_CARD_BEGIN_DATE] */
		private DateTime memberCardBeginDate;
		/** 会籍到期日 [MEMBER_CARD_END_DATE] */
		private DateTime memberCardEndDate;
		/** 需要发票 [NEED_TICKET] */
		private string needTicket;
		/** 消费总额 [CONSUME_AMOUNT] */
		private decimal consumeAmount;
		/** 积分 [INTEGRAl] */
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
		/// 客户_ID [CUSTOMER_ID]
		/// </summary>
		public virtual long CustomerId
		{
			get { return this.customerId; }
			set { this.customerId = value; }
		}
		/// <summary>
		/// 会员卡号 [MEMBER_CARD_NO]
		/// </summary>
		public virtual string MemberCardNo
		{
			get { return this.memberCardNo; }
			set { this.memberCardNo = value; }
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
		/// 年龄 [AGE]
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
		/// 爱好 [HOBBY]
		/// </summary>
		public virtual string Hobby
		{
			get { return this.hobby; }
			set { this.hobby = value; }
		}
		/// <summary>
		/// 手机 [MOBILE_NO]
		/// </summary>
		public virtual string MobileNo
		{
			get { return this.mobileNo; }
			set { this.mobileNo = value; }
		}
		/// <summary>
		/// 职务 [POSITION]
		/// </summary>
		public virtual string Position
		{
			get { return this.position; }
			set { this.position = value; }
		}
		/// <summary>
		/// 性别 [SEX]
		/// </summary>
		public virtual string Sex
		{
			get { return this.sex; }
			set { this.sex = value; }
		}
		/// <summary>
		/// 会员卡状态 [MEMBER_STATE]
		/// </summary>
		public virtual string MemberState
		{
			get { return this.memberState; }
			set { this.memberState = value; }
		}
		/// <summary>
		/// 身份证 [IDENTITY_CARD_NO]
		/// </summary>
		public virtual string IdentityCardNo
		{
			get { return this.identityCardNo; }
			set { this.identityCardNo = value; }
		}
		/// <summary>
		/// 密码 [PASSWORD]
		/// </summary>
		public virtual string Password
		{
			get { return this.password; }
			set { this.password = value; }
		}
		/// <summary>
		/// 会籍起始日 [MEMBER_CARD_BEGIN_DATE]
		/// </summary>
		public virtual DateTime MemberCardBeginDate
		{
			get { return this.memberCardBeginDate; }
			set { this.memberCardBeginDate = value; }
		}
		/// <summary>
		/// 会籍到期日 [MEMBER_CARD_END_DATE]
		/// </summary>
		public virtual DateTime MemberCardEndDate
		{
			get { return this.memberCardEndDate; }
			set { this.memberCardEndDate = value; }
		}
		/// <summary>
		/// 需要发票 [NEED_TICKET]
		/// </summary>
		public virtual string NeedTicket
		{
			get { return this.needTicket; }
			set { this.needTicket = value; }
		}
		/// <summary>
		/// 消费总额 [CONSUME_AMOUNT]
		/// </summary>
		public virtual decimal ConsumeAmount
		{
			get { return this.consumeAmount; }
			set { this.consumeAmount = value; }
		}
		/// <summary>
		/// 积分 [INTEGRAl]
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
