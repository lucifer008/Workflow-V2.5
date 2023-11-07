using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table CASH_HAND_OVER 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class CashHandOverBase 
	{
		/** ID [ID] */
		private long id;
		/** 发票金额 [TICKET_AMOUNT_SUM] */
		private decimal ticketAmountSum;
		/** 结款笔数 [PAY_FOR_COUNT] */
		private int payForCount;
		/** 结款金额 [PAY_FOR_AMOUNT_SUM] */
		private decimal payForAmountSum;
		/** 现金合计 [CASH_AMOUNT] */
		private decimal cashAmount;
		/** 记帐笔数 [KEEP_BUSINESS_RECORD_COUNT] */
		private int keepBusinessRecordCount;
		/** 记帐合计 [KEEP_BUSINESS_RECORD_AMOUNT_SUM] */
		private decimal keepBusinessRecordAmountSum;
		/** 欠条笔数 [DEBT_COUNT] */
		private int debtCount;
		/** 欠条金额 [DEBT_AMOUNT_SUM] */
		private decimal debtAmountSum;
		/** 备用金 [STANDBY_AMOUNT] */
		private decimal standbyAmount;

		public CashHandOverBase()
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
		/// 发票金额 [TICKET_AMOUNT_SUM]
		/// </summary>
		public virtual decimal TicketAmountSum
		{
			get { return this.ticketAmountSum; }
			set { this.ticketAmountSum = value; }
		}
		/// <summary>
		/// 结款笔数 [PAY_FOR_COUNT]
		/// </summary>
		public virtual int PayForCount
		{
			get { return this.payForCount; }
			set { this.payForCount = value; }
		}
		/// <summary>
		/// 结款金额 [PAY_FOR_AMOUNT_SUM]
		/// </summary>
		public virtual decimal PayForAmountSum
		{
			get { return this.payForAmountSum; }
			set { this.payForAmountSum = value; }
		}
		/// <summary>
		/// 现金合计 [CASH_AMOUNT]
		/// </summary>
		public virtual decimal CashAmount
		{
			get { return this.cashAmount; }
			set { this.cashAmount = value; }
		}
		/// <summary>
		/// 记帐笔数 [KEEP_BUSINESS_RECORD_COUNT]
		/// </summary>
		public virtual int KeepBusinessRecordCount
		{
			get { return this.keepBusinessRecordCount; }
			set { this.keepBusinessRecordCount = value; }
		}
		/// <summary>
		/// 记帐合计 [KEEP_BUSINESS_RECORD_AMOUNT_SUM]
		/// </summary>
		public virtual decimal KeepBusinessRecordAmountSum
		{
			get { return this.keepBusinessRecordAmountSum; }
			set { this.keepBusinessRecordAmountSum = value; }
		}
		/// <summary>
		/// 欠条笔数 [DEBT_COUNT]
		/// </summary>
		public virtual int DebtCount
		{
			get { return this.debtCount; }
			set { this.debtCount = value; }
		}
		/// <summary>
		/// 欠条金额 [DEBT_AMOUNT_SUM]
		/// </summary>
		public virtual decimal DebtAmountSum
		{
			get { return this.debtAmountSum; }
			set { this.debtAmountSum = value; }
		}
		/// <summary>
		/// 备用金 [STANDBY_AMOUNT]
		/// </summary>
		public virtual decimal StandbyAmount
		{
			get { return this.standbyAmount; }
			set { this.standbyAmount = value; }
		}

		private IList<Workflow.Da.Domain.CashHandOverOrder> cashHandOverOrderList;
		/// <summary>
		/// Source Table[CASH_HAND_OVER] Column[ID] --> Target Table[CASH_HAND_OVER_ORDERS] Column[CASH_HAND_OVER_ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.CashHandOverOrder> CashHandOverOrderList
		{
			get { return cashHandOverOrderList; }
			set { cashHandOverOrderList = value; }
		}
		private Workflow.Da.Domain.HandOver handOver;
		/// <summary>
		/// Source Table[CASH_HAND_OVER] Column[HAND_OVER_ID] --> Target Table[HAND_OVER] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.HandOver HandOver
		{
			get { return handOver; }
			set { handOver = value; }
		}

	}
}
