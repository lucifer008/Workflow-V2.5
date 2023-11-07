using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table HAND_OVER 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class HandOverBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 交班时间 [HAND_OVER_DATE_TIME] */
		private DateTime handOverDateTime;
		/** 备注 [MEMO] */
		private string memo;
		/** 交班状态 [HAND_OVER_STATUS] */
		private string handOverStatus;
		/** 交班类别 [HAND_OVER_TYPE] */
		private string handOverType;

		public HandOverBase()
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
		/// 交班时间 [HAND_OVER_DATE_TIME]
		/// </summary>
		public virtual DateTime HandOverDateTime
		{
			get { return this.handOverDateTime; }
			set { this.handOverDateTime = value; }
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
		/// 交班状态 [HAND_OVER_STATUS]
		/// </summary>
		public virtual string HandOverStatus
		{
			get { return this.handOverStatus; }
			set { this.handOverStatus = value; }
		}
		/// <summary>
		/// 交班类别 [HAND_OVER_TYPE]
		/// </summary>
		public virtual string HandOverType
		{
			get { return this.handOverType; }
			set { this.handOverType = value; }
		}

		private Workflow.Da.Domain.Employee otherEmployee;
		/// <summary>
		/// Source Table[HAND_OVER] Column[OTHER_EMPLOYEE_ID] --> Target Table[EMPLOYEE] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.Employee OtherEmployee
		{
			get { return otherEmployee; }
			set { otherEmployee = value; }
		}
		private IList<Workflow.Da.Domain.HandOverMemberCard> handOverMemberCardList;
		/// <summary>
		/// Source Table[HAND_OVER] Column[ID] --> Target Table[HAND_OVER_MEMBER_CARD] Column[HAND_OVER_ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.HandOverMemberCard> HandOverMemberCardList
		{
			get { return handOverMemberCardList; }
			set { handOverMemberCardList = value; }
		}
		private IList<Workflow.Da.Domain.HandOverOrder> handOverOrderList;
		/// <summary>
		/// Source Table[HAND_OVER] Column[ID] --> Target Table[HAND_OVER_ORDERS] Column[HAND_OVER_ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.HandOverOrder> HandOverOrderList
		{
			get { return handOverOrderList; }
			set { handOverOrderList = value; }
		}
		private Workflow.Da.Domain.Employee employee;
		/// <summary>
		/// Source Table[HAND_OVER] Column[EMPLOYEE_ID] --> Target Table[EMPLOYEE] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.Employee Employee
		{
			get { return employee; }
			set { employee = value; }
		}

	}
}
