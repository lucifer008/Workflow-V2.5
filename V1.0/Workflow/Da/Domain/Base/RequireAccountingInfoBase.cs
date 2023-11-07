using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table REQUIRE_ACCOUNTING_INFO 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class RequireAccountingInfoBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 备注 [MEMO] */
		private string memo;
		/** 批准 [PASSED] */
		private string passed;

		public RequireAccountingInfoBase()
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
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// 批准 [PASSED]
		/// </summary>
		public virtual string Passed
		{
			get { return this.passed; }
			set { this.passed = value; }
		}

		private Workflow.Da.Domain.Order orders;
		/// <summary>
		/// Source Table[REQUIRE_ACCOUNTING_INFO] Column[ORDERS_ID] --> Target Table[ORDERS] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.Order Orders
		{
			get { return orders; }
			set { orders = value; }
		}
		private Workflow.Da.Domain.User users;
		/// <summary>
		/// Source Table[REQUIRE_ACCOUNTING_INFO] Column[USERS_ID] --> Target Table[USERS] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.User Users
		{
			get { return users; }
			set { users = value; }
		}

	}
}
