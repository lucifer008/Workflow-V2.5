#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table CASH_HAND_OVER (收银交班) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class CashHandOverBase 	{

		#region Id
		/* ID [ID] */
		private long id;
		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return id ;	}
			set { id=value;		}	
		}
		#endregion

		#region HandOverId
		/* 交班_ID [HAND_OVER_ID] */
		private long handOverId;
		/// <summary>
		/// 交班_ID [HAND_OVER_ID]
		/// </summary>
		public virtual long HandOverId
		{
			get { return handOverId ;	}
			set { handOverId=value;		}	
		}
		#endregion

		#region TicketAmountSum
		/* 发票金额 [TICKET_AMOUNT_SUM] */
		private decimal ticketAmountSum;
		/// <summary>
		/// 发票金额 [TICKET_AMOUNT_SUM]
		/// </summary>
		public virtual decimal TicketAmountSum
		{
			get { return ticketAmountSum ;	}
			set { ticketAmountSum=value;		}	
		}
		#endregion

		#region PayForCount
		/* 结款笔数 [PAY_FOR_COUNT] */
		private int payForCount;
		/// <summary>
		/// 结款笔数 [PAY_FOR_COUNT]
		/// </summary>
		public virtual int PayForCount
		{
			get { return payForCount ;	}
			set { payForCount=value;		}	
		}
		#endregion

		#region PayForAmountSum
		/* 结款金额 [PAY_FOR_AMOUNT_SUM] */
		private decimal payForAmountSum;
		/// <summary>
		/// 结款金额 [PAY_FOR_AMOUNT_SUM]
		/// </summary>
		public virtual decimal PayForAmountSum
		{
			get { return payForAmountSum ;	}
			set { payForAmountSum=value;		}	
		}
		#endregion

		#region MemberCardChargeAmount
		/* 会员充值金额 [MEMBER_CARD_CHARGE_AMOUNT] */
		private decimal memberCardChargeAmount;
		/// <summary>
		/// 会员充值金额 [MEMBER_CARD_CHARGE_AMOUNT]
		/// </summary>
		public virtual decimal MemberCardChargeAmount
		{
			get { return memberCardChargeAmount ;	}
			set { memberCardChargeAmount=value;		}	
		}
		#endregion

		#region CashAmount
		/* 现金合计 [CASH_AMOUNT] */
		private decimal cashAmount;
		/// <summary>
		/// 现金合计 [CASH_AMOUNT]
		/// </summary>
		public virtual decimal CashAmount
		{
			get { return cashAmount ;	}
			set { cashAmount=value;		}	
		}
		#endregion

		#region KeepBusinessRecordCount
		/* 记帐笔数 [KEEP_BUSINESS_RECORD_COUNT] */
		private int keepBusinessRecordCount;
		/// <summary>
		/// 记帐笔数 [KEEP_BUSINESS_RECORD_COUNT]
		/// </summary>
		public virtual int KeepBusinessRecordCount
		{
			get { return keepBusinessRecordCount ;	}
			set { keepBusinessRecordCount=value;		}	
		}
		#endregion

		#region KeepBusinessRecordAmountSum
		/* 记帐合计 [KEEP_BUSINESS_RECORD_AMOUNT_SUM] */
		private decimal keepBusinessRecordAmountSum;
		/// <summary>
		/// 记帐合计 [KEEP_BUSINESS_RECORD_AMOUNT_SUM]
		/// </summary>
		public virtual decimal KeepBusinessRecordAmountSum
		{
			get { return keepBusinessRecordAmountSum ;	}
			set { keepBusinessRecordAmountSum=value;		}	
		}
		#endregion

		#region DebtCount
		/* 欠条笔数 [DEBT_COUNT] */
		private int debtCount;
		/// <summary>
		/// 欠条笔数 [DEBT_COUNT]
		/// </summary>
		public virtual int DebtCount
		{
			get { return debtCount ;	}
			set { debtCount=value;		}	
		}
		#endregion

		#region DebtAmountSum
		/* 欠条金额 [DEBT_AMOUNT_SUM] */
		private decimal debtAmountSum;
		/// <summary>
		/// 欠条金额 [DEBT_AMOUNT_SUM]
		/// </summary>
		public virtual decimal DebtAmountSum
		{
			get { return debtAmountSum ;	}
			set { debtAmountSum=value;		}	
		}
		#endregion

		#region StandbyAmount
		/* 备用金 [STANDBY_AMOUNT] */
		private decimal standbyAmount;
		/// <summary>
		/// 备用金 [STANDBY_AMOUNT]
		/// </summary>
		public virtual decimal StandbyAmount
		{
			get { return standbyAmount ;	}
			set { standbyAmount=value;		}	
		}
		#endregion

		#region CASH_HAND_OVER_ORDERS JoinType 1:N	list_in
		private IList<Workflow.Da.Domain.CashHandOverOrder> cashHandOverOrdersList; 
		/// <summary>
		/// Source Table[CASH_HAND_OVER] Column[ID] --> Target IList<Table[CASH_HAND_OVER_ORDERS]> Column[CASH_HAND_OVER_ID]
		/// PropertyComment	:CASH_HAND_OVER_ORDERS:list
		/// JoinType 1:N	list_in
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.CashHandOverOrder> CashHandOverOrdersList
		{
			get { return cashHandOverOrdersList;	}
			set { cashHandOverOrdersList = value;	}
		}
		#endregion
		
		#region HAND_OVER JoinType N:1	single_in
		private Workflow.Da.Domain.HandOver handOver; 
		/// <summary>
		/// Source Table[CASH_HAND_OVER] Column[HAND_OVER_ID] --> Target Table[HAND_OVER] Column[ID]
		/// PropertyComment	HAND_OVER_ID:HAND_OVER:single
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.HandOver HandOver
		{
			get { return handOver;	}
			set { handOver = value;	}
		}
		#endregion
	}
}