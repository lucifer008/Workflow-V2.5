#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ORDERS (工单) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
    public class OrderBase : Workflow.Da.Domain.Base.MetaData 
	{
		
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
		
		#region CustomerId
		/* 客户_ID [CUSTOMER_ID] */
		private long customerId;
		/// <summary>
		/// 客户_ID [CUSTOMER_ID]
		/// </summary>
		public virtual long CustomerId
		{
			get { return customerId ;	}
			set { customerId=value;		}	
		}
		#endregion
		
		#region NewOrderUserId
		/* 开单人 [NEW_ORDER_USER_ID] */
		private long newOrderUserId;
		/// <summary>
		/// 开单人 [NEW_ORDER_USER_ID]
		/// </summary>
		public virtual long NewOrderUserId
		{
			get { return newOrderUserId ;	}
			set { newOrderUserId=value;		}	
		}
		#endregion
		
		#region CashUserId
		/* 收银人 [CASH_USER_ID] */
		private long cashUserId;
		/// <summary>
		/// 收银人 [CASH_USER_ID]
		/// </summary>
		public virtual long CashUserId
		{
			get { return cashUserId ;	}
			set { cashUserId=value;		}	
		}
		#endregion
		
		#region MemberCardId
		/* 会员卡_ID [MEMBER_CARD_ID] */
		private long memberCardId;
		/// <summary>
		/// 会员卡_ID [MEMBER_CARD_ID]
		/// </summary>
		public virtual long MemberCardId
		{
			get { return memberCardId ;	}
			set { memberCardId=value;		}	
		}
		#endregion
		
		#region No
		/* NO [NO] */
		private string no;
		/// <summary>
		/// NO [NO]
		/// </summary>
		public virtual string No
		{
			get { return no ;	}
			set { no=value;		}	
		}
		#endregion
		
		#region CustomerType
		/* 客户类型 [CUSTOMER_TYPE] */
		private int customerType;
		/// <summary>
		/// 客户类型 [CUSTOMER_TYPE]
		/// </summary>
		public virtual int CustomerType
		{
			get { return customerType ;	}
			set { customerType=value;		}	
		}
		#endregion
		
		#region CustomerName
		/* 客户名称 [CUSTOMER_NAME] */
		private string customerName;
		/// <summary>
		/// 客户名称 [CUSTOMER_NAME]
		/// </summary>
		public virtual string CustomerName
		{
			get { return customerName ;	}
			set { customerName=value;		}	
		}
		#endregion
		
		#region Name
		/* 姓名 [NAME] */
		private string name;
		/// <summary>
		/// 姓名 [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return name ;	}
			set { name=value;		}	
		}
		#endregion
		
		#region ProjectName
		/* 项目名称 [PROJECT_NAME] */
		private string projectName;
		/// <summary>
		/// 项目名称 [PROJECT_NAME]
		/// </summary>
		public virtual string ProjectName
		{
			get { return projectName ;	}
			set { projectName=value;		}	
		}
		#endregion
		
		#region PayType
		/* 支付方式 [PAY_TYPE] */
		private int payType;
		/// <summary>
		/// 支付方式 [PAY_TYPE]
		/// </summary>
		public virtual int PayType
		{
			get { return payType ;	}
			set { payType=value;		}	
		}
		#endregion
		
		#region PrepareMoney
		/* 预收款 [PREPARE_MONEY] */
		private string prepareMoney;
		/// <summary>
		/// 预收款 [PREPARE_MONEY]
		/// </summary>
		public virtual string PrepareMoney
		{
			get { return prepareMoney ;	}
			set { prepareMoney=value;		}	
		}
		#endregion
		
		#region PrepareMoneyAmount
		/* 预收款金额 [PREPARE_MONEY_AMOUNT] */
		private decimal prepareMoneyAmount;
		/// <summary>
		/// 预收款金额 [PREPARE_MONEY_AMOUNT]
		/// </summary>
		public virtual decimal PrepareMoneyAmount
		{
			get { return prepareMoneyAmount ;	}
			set { prepareMoneyAmount=value;		}	
		}
		#endregion
		
		#region NeedTicket
		/* 需要发票 [NEED_TICKET] */
		private string needTicket;
		/// <summary>
		/// 需要发票 [NEED_TICKET]
		/// </summary>
		public virtual string NeedTicket
		{
			get { return needTicket ;	}
			set { needTicket=value;		}	
		}
		#endregion
		
		#region DeliveryType
		/* 送货方式 [DELIVERY_TYPE] */
		private int deliveryType;
		/// <summary>
		/// 送货方式 [DELIVERY_TYPE]
		/// </summary>
		public virtual int DeliveryType
		{
			get { return deliveryType ;	}
			set { deliveryType=value;		}	
		}
		#endregion
		
		#region DeliveryDateTime
		/* 送货时间 [DELIVERY_DATE_TIME] */
		private DateTime deliveryDateTime;
		/// <summary>
		/// 送货时间 [DELIVERY_DATE_TIME]
		/// </summary>
		public virtual DateTime DeliveryDateTime
		{
			get { return deliveryDateTime ;	}
			set { deliveryDateTime=value;		}	
		}
		#endregion
		
		#region SumAmount
		/* 总计金额 [SUM_AMOUNT] */
		private decimal sumAmount;
		/// <summary>
		/// 总计金额 [SUM_AMOUNT]
		/// </summary>
		public virtual decimal SumAmount
		{
			get { return sumAmount ;	}
			set { sumAmount=value;		}	
		}
		#endregion
		
		#region Memo
		/* 备注 [MEMO] */
		private string memo;
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return memo ;	}
			set { memo=value;		}	
		}
		#endregion
		
		#region NotPayTicketAmount
		/* 欠发票的金额 [NOT_PAY_TICKET_AMOUNT] */
		private decimal notPayTicketAmount;
		/// <summary>
		/// 欠发票的金额 [NOT_PAY_TICKET_AMOUNT]
		/// </summary>
		public virtual decimal NotPayTicketAmount
		{
			get { return notPayTicketAmount ;	}
			set { notPayTicketAmount=value;		}	
		}
		#endregion
		
		#region PaidTicketAmount
		/* 已付发票金额 [PAID_TICKET_AMOUNT] */
		private decimal paidTicketAmount;
		/// <summary>
		/// 已付发票金额 [PAID_TICKET_AMOUNT]
		/// </summary>
		public virtual decimal PaidTicketAmount
		{
			get { return paidTicketAmount ;	}
			set { paidTicketAmount=value;		}	
		}
		#endregion
		
		#region RealPaidAmount
		/* 实收金额 [REAL_PAID_AMOUNT] */
		private decimal realPaidAmount;
		/// <summary>
		/// 实收金额 [REAL_PAID_AMOUNT]
		/// </summary>
		public virtual decimal RealPaidAmount
		{
			get { return realPaidAmount ;	}
			set { realPaidAmount=value;		}	
		}
		#endregion
		
		#region PaidAmount
		/* 已付金额 [PAID_AMOUNT] */
		private decimal paidAmount;
		/// <summary>
		/// 已付金额 [PAID_AMOUNT]
		/// </summary>
		public virtual decimal PaidAmount
		{
			get { return paidAmount ;	}
			set { paidAmount=value;		}	
		}
		#endregion
		
		#region PaidTicket
		/* 是否欠发票 [PAID_TICKET] */
		private string paidTicket;
		/// <summary>
		/// 是否欠发票 [PAID_TICKET]
		/// </summary>
		public virtual string PaidTicket
		{
			get { return paidTicket ;	}
			set { paidTicket=value;		}	
		}
		#endregion
		
		#region Status
		/* 状态 [STATUS] */
		private int status;
		/// <summary>
		/// 状态 [STATUS]
		/// </summary>
		public virtual int Status
		{
			get { return status ;	}
			set { status=value;		}	
		}
		#endregion
		
		#region BalanceDateTime
		/* 结算时间 [BALANCE_DATE_TIME] */
		private DateTime balanceDateTime;
		/// <summary>
		/// 结算时间 [BALANCE_DATE_TIME]
		/// </summary>
		public virtual DateTime BalanceDateTime
		{
			get { return balanceDateTime ;	}
			set { balanceDateTime=value;		}	
		}
		#endregion

		#region ORDER_ITEM JoinType 1:N	list_in
		private IList<Workflow.Da.Domain.OrderItem> orderItemList; 
		/// <summary>
		/// Source Table[ORDERS] Column[ID] --> Target IList<Table[ORDER_ITEM]> Column[ORDERS_ID]
		/// PropertyComment	 :ORDER_ITEM:list:autoJoin=true
		/// JoinType 1:N	list_in
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.OrderItem> OrderItemList
		{
			get { return orderItemList;	}
			set { orderItemList = value;	}
		}
		#endregion
		
		#region USERS JoinType N:1	single_in
		private Workflow.Da.Domain.User newOrderUser; 
		/// <summary>
		/// Source Table[ORDERS] Column[NEW_ORDER_USER_ID] --> Target Table[USERS] Column[ID]
		/// PropertyComment	NEW_ORDER_USER_ID:USERS:single
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.User NewOrderUser
		{
			get { return newOrderUser;	}
			set { newOrderUser = value;	}
		}
		#endregion
		
		#region USERS JoinType N:1	single_in
		private Workflow.Da.Domain.User cashUser; 
		/// <summary>
		/// Source Table[ORDERS] Column[CASH_USER_ID] --> Target Table[USERS] Column[ID]
		/// PropertyComment	CASH_USER_ID:USERS:single
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.User CashUser
		{
			get { return cashUser;	}
			set { cashUser = value;	}
		}
		#endregion
	}
}