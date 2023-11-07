using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PAYMENT_CONCESSION 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class PaymentConcessionBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 收款记录_ID [GATHERING_ID] */
		private long gatheringId;
		/** 优惠类型 [CONCESSION_TYPE] */
		private string concessionType;
		/** 优惠金额 [CONCESSION_AMOUNT] */
		private decimal concessionAmount;
		/** 操作时间 [OPERATE_DATE_TIME] */
		private DateTime operateDateTime;
		/** 备注 [MEMO] */
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
		/// 收款记录_ID [GATHERING_ID]
		/// </summary>
		public virtual long GatheringId
		{
			get { return this.gatheringId; }
			set { this.gatheringId = value; }
		}
		/// <summary>
		/// 优惠类型 [CONCESSION_TYPE]
		/// </summary>
		public virtual string ConcessionType
		{
			get { return this.concessionType; }
			set { this.concessionType = value; }
		}
		/// <summary>
		/// 优惠金额 [CONCESSION_AMOUNT]
		/// </summary>
		public virtual decimal ConcessionAmount
		{
			get { return this.concessionAmount; }
			set { this.concessionAmount = value; }
		}
		/// <summary>
		/// 操作时间 [OPERATE_DATE_TIME]
		/// </summary>
		public virtual DateTime OperateDateTime
		{
			get { return this.operateDateTime; }
			set { this.operateDateTime = value; }
		}
		/// <summary>
		/// 备注 [MEMO]
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
