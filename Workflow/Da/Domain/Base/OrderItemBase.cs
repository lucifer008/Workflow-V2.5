#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ORDER_ITEM (订单明细) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class OrderItemBase:MetaData
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
		
		#region OrdersId
		/* 订单_ID [ORDERS_ID] */
		private long ordersId;
		/// <summary>
		/// 订单_ID [ORDERS_ID]
		/// </summary>
		public virtual long OrdersId
		{
			get { return ordersId ;	}
			set { ordersId=value;		}	
		}
		#endregion
		
		#region BusinessTypeId
		/* 业务类型_ID [BUSINESS_TYPE_ID] */
		private long businessTypeId;
		/// <summary>
		/// 业务类型_ID [BUSINESS_TYPE_ID]
		/// </summary>
		public virtual long BusinessTypeId
		{
			get { return businessTypeId ;	}
			set { businessTypeId=value;		}	
		}
		#endregion
		
		#region Amount
		/* 数量 [AMOUNT] */
		private decimal amount;
		/// <summary>
		/// 数量 [AMOUNT]
		/// </summary>
		public virtual decimal Amount
		{
			get { return amount ;	}
			set { amount=value;		}	
		}
		#endregion
		
		#region UnitPrice
		/* 单价 [UNIT_PRICE] */
		private decimal unitPrice;
		/// <summary>
		/// 单价 [UNIT_PRICE]
		/// </summary>
		public virtual decimal UnitPrice
		{
			get { return unitPrice ;	}
			set { unitPrice=value;		}	
		}
		#endregion
		
		#region ForecastMoneyAmount
		/* 预计金额 [FORECAST_MONEY_AMOUNT] */
		private decimal forecastMoneyAmount;
		/// <summary>
		/// 预计金额 [FORECAST_MONEY_AMOUNT]
		/// </summary>
		public virtual decimal ForecastMoneyAmount
		{
			get { return forecastMoneyAmount ;	}
			set { forecastMoneyAmount=value;		}	
		}
		#endregion
		
		#region IsUseSavedPaper
		/* 是否消费印章 [IS_USE_SAVED_PAPER] */
		private string isUseSavedPaper;
		/// <summary>
		/// 是否消费印章 [IS_USE_SAVED_PAPER]
		/// </summary>
		public virtual string IsUseSavedPaper
		{
			get { return isUseSavedPaper ;	}
			set { isUseSavedPaper=value;		}	
		}
		#endregion
		
		#region PaperConsumeCount
		/* 冲减价印章数 [PAPER_CONSUME_COUNT] */
		private decimal paperConsumeCount;
		/// <summary>
		/// 冲减价印章数 [PAPER_CONSUME_COUNT]
		/// </summary>
		public virtual decimal PaperConsumeCount
		{
			get { return paperConsumeCount ;	}
			set { paperConsumeCount=value;		}	
		}
		#endregion
		
		#region UnitDifferencePrice
		/* 单体差价 [UNIT_DIFFERENCE_PRICE] */
		private decimal unitDifferencePrice;
		/// <summary>
		/// 单体差价 [UNIT_DIFFERENCE_PRICE]
		/// </summary>
		public virtual decimal UnitDifferencePrice
		{
			get { return unitDifferencePrice ;	}
			set { unitDifferencePrice=value;		}	
		}
		#endregion
		
		#region ConsumePaperAmount
		/* 消费印张差额金额总计 [CONSUME_PAPER_AMOUNT] */
		private decimal consumePaperAmount;
		/// <summary>
		/// 消费印张差额金额总计 [CONSUME_PAPER_AMOUNT]
		/// </summary>
		public virtual decimal ConsumePaperAmount
		{
			get { return consumePaperAmount ;	}
			set { consumePaperAmount=value;		}	
		}
		#endregion
		
		#region CashConsumeCount
		/* 现金消费数量 [CASH_CONSUME_COUNT] */
		private decimal cashConsumeCount;
		/// <summary>
		/// 现金消费数量 [CASH_CONSUME_COUNT]
		/// </summary>
		public virtual decimal CashConsumeCount
		{
			get { return cashConsumeCount ;	}
			set { cashConsumeCount=value;		}	
		}
		#endregion
		
		#region CashUnitPrice
		/* 现金消费单价 [CASH_UNIT_PRICE] */
		private decimal cashUnitPrice;
		/// <summary>
		/// 现金消费单价 [CASH_UNIT_PRICE]
		/// </summary>
		public virtual decimal CashUnitPrice
		{
			get { return cashUnitPrice ;	}
			set { cashUnitPrice=value;		}	
		}
		#endregion
		
		#region CashConsumeAmount
		/* 现金消费金额总计 [CASH_CONSUME_AMOUNT] */
		private decimal cashConsumeAmount;
		/// <summary>
		/// 现金消费金额总计 [CASH_CONSUME_AMOUNT]
		/// </summary>
		public virtual decimal CashConsumeAmount
		{
			get { return cashConsumeAmount ;	}
			set { cashConsumeAmount=value;		}	
		}
		#endregion
		
        //#region Deleted
        ///* 删除标志 [DELETED] */
        //private string deleted;
        ///// <summary>
        ///// 删除标志 [DELETED]
        ///// </summary>
        //public virtual string Deleted
        //{
        //    get { return deleted ;	}
        //    set { deleted=value;		}	
        //}
        //#endregion
		
        //#region InsertDateTime
        ///* 插入时间 [INSERT_DATE_TIME] */
        //private DateTime insertDateTime;
        ///// <summary>
        ///// 插入时间 [INSERT_DATE_TIME]
        ///// </summary>
        //public virtual DateTime InsertDateTime
        //{
        //    get { return insertDateTime ;	}
        //    set { insertDateTime=value;		}	
        //}
        //#endregion
		
        //#region InsertUser
        ///* 插入用户 [INSERT_USER] */
        //private long insertUser;
        ///// <summary>
        ///// 插入用户 [INSERT_USER]
        ///// </summary>
        //public virtual long InsertUser
        //{
        //    get { return insertUser ;	}
        //    set { insertUser=value;		}	
        //}
        //#endregion
		
        //#region UpdateDateTime
        ///* 更新时间 [UPDATE_DATE_TIME] */
        //private DateTime? updateDateTime;
        ///// <summary>
        ///// 更新时间 [UPDATE_DATE_TIME]
        ///// </summary>
        //public virtual DateTime? UpdateDateTime
        //{
        //    get { return updateDateTime ;	}
        //    set { updateDateTime=value;		}	
        //}
        //#endregion
		
        //#region UpdateUser
        ///* 更新用户 [UPDATE_USER] */
        //private long updateUser;
        ///// <summary>
        ///// 更新用户 [UPDATE_USER]
        ///// </summary>
        //public virtual long UpdateUser
        //{
        //    get { return updateUser ;	}
        //    set { updateUser=value;		}	
        //}
        //#endregion
		
        //#region Version
        ///* 版本 [VERSION] */
        //private int version;
        ///// <summary>
        ///// 版本 [VERSION]
        ///// </summary>
        //public virtual int Version
        //{
        //    get { return version ;	}
        //    set { version=value;		}	
        //}
        //#endregion
		
        //#region CompanyId
        ///* 公司 [COMPANY_ID] */
        //private long companyId;
        ///// <summary>
        ///// 公司 [COMPANY_ID]
        ///// </summary>
        //public virtual long CompanyId
        //{
        //    get { return companyId ;	}
        //    set { companyId=value;		}	
        //}
        //#endregion
		
        //#region BranchShopId
        ///* 分店 [BRANCH_SHOP_ID] */
        //private long branchShopId;
        ///// <summary>
        ///// 分店 [BRANCH_SHOP_ID]
        ///// </summary>
        //public virtual long BranchShopId
        //{
        //    get { return branchShopId ;	}
        //    set { branchShopId=value;		}	
        //}
        //#endregion
		
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

		#region PRINT_REQUIRE_DETAIL JoinType 1:N	list_out
		private IList<Workflow.Da.Domain.PrintRequireDetail> printRequireDetailList; 
		/// <summary>
		/// Source Table[ORDER_ITEM] Column[ORDER_ITEM_ID] --> Target IList<Table[PRINT_REQUIRE_DETAIL]> Column[ID]
		/// PropertyComment	:PRINT_REQUIRE_DETAIL[ORDER_ITEM_PRINT_REQUIRE_DETAIL]:list
		/// JoinType 1:N	list_out
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.PrintRequireDetail> PrintRequireDetailList
		{
			get { return printRequireDetailList;	}
			set { printRequireDetailList = value;	}
		}
		#endregion

		#region ORDER_ITEM_FACTOR_VALUE JoinType 1:N	list_in
		private IList<Workflow.Da.Domain.OrderItemFactorValue> orderItemFactorValueList; 
		/// <summary>
		/// Source Table[ORDER_ITEM] Column[ID] --> Target IList<Table[ORDER_ITEM_FACTOR_VALUE]> Column[ORDER_ITEM_ID]
		/// PropertyComment	:ORDER_ITEM_FACTOR_VALUE:list
		/// JoinType 1:N	list_in
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.OrderItemFactorValue> OrderItemFactorValueList
		{
			get { return orderItemFactorValueList;	}
			set { orderItemFactorValueList = value;	}
		}
		#endregion
		
		#region BUSINESS_TYPE JoinType N:1	single_in
		private Workflow.Da.Domain.BusinessType businessType; 
		/// <summary>
		/// Source Table[ORDER_ITEM] Column[BUSINESS_TYPE_ID] --> Target Table[BUSINESS_TYPE] Column[ID]
		/// PropertyComment	BUSINESS_TYPE_ID:BUSINESS_TYPE:single:autoJoin=true
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.BusinessType BusinessType
		{
			get { return businessType;	}
			set { businessType = value;	}
		}
		#endregion
	}
}