#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table CUSTOMER (客户) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class CustomerBase:MetaData
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
		
		#region CustomerLevelId
		/* 客户级别_ID [CUSTOMER_LEVEL_ID] */
		private long customerLevelId;
		/// <summary>
		/// 客户级别_ID [CUSTOMER_LEVEL_ID]
		/// </summary>
		public virtual long CustomerLevelId
		{
			get { return customerLevelId ;	}
			set { customerLevelId=value;		}	
		}
		#endregion
		
		#region CustomerTypeId
		/* 客户类型_ID [CUSTOMER_TYPE_ID] */
		private long customerTypeId;
		/// <summary>
		/// 客户类型_ID [CUSTOMER_TYPE_ID]
		/// </summary>
		public virtual long CustomerTypeId
		{
			get { return customerTypeId ;	}
			set { customerTypeId=value;		}	
		}
		#endregion
		
		#region SecondaryTradeId
		/* 子行业_ID [SECONDARY_TRADE_ID] */
		private long secondaryTradeId;
		/// <summary>
		/// 子行业_ID [SECONDARY_TRADE_ID]
		/// </summary>
		public virtual long SecondaryTradeId
		{
			get { return secondaryTradeId ;	}
			set { secondaryTradeId=value;		}	
		}
		#endregion
		
		#region Name
		/* 名称 [NAME] */
		private string name;
		/// <summary>
		/// 名称 [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return name ;	}
			set { name=value;		}	
		}
		#endregion
		
		#region SimpleName
		/* 简拼 [SIMPLE_NAME] */
		private string simpleName;
		/// <summary>
		/// 简拼 [SIMPLE_NAME]
		/// </summary>
		public virtual string SimpleName
		{
			get { return simpleName ;	}
			set { simpleName=value;		}	
		}
		#endregion
		
		#region Address
		/* 地址 [ADDRESS] */
		private string address;
		/// <summary>
		/// 地址 [ADDRESS]
		/// </summary>
		public virtual string Address
		{
			get { return address ;	}
			set { address=value;		}	
		}
		#endregion
		
		#region LastLinkMan
		/* 上次联系人 [LAST_LINK_MAN] */
		private string lastLinkMan;
		/// <summary>
		/// 上次联系人 [LAST_LINK_MAN]
		/// </summary>
		public virtual string LastLinkMan
		{
			get { return lastLinkMan ;	}
			set { lastLinkMan=value;		}	
		}
		#endregion
		
		#region LastTelNo
		/* 上次电话 [LAST_TEL_NO] */
		private string lastTelNo;
		/// <summary>
		/// 上次电话 [LAST_TEL_NO]
		/// </summary>
		public virtual string LastTelNo
		{
			get { return lastTelNo ;	}
			set { lastTelNo=value;		}	
		}
		#endregion
		
		#region LinkManCount
		/* 联系人数量 [LINK_MAN_COUNT] */
		private int linkManCount;
		/// <summary>
		/// 联系人数量 [LINK_MAN_COUNT]
		/// </summary>
		public virtual int LinkManCount
		{
			get { return linkManCount ;	}
			set { linkManCount=value;		}	
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
		
		#region Amount
		/* 预存金额 [AMOUNT] */
		private decimal amount;
		/// <summary>
		/// 预存金额 [AMOUNT]
		/// </summary>
		public virtual decimal Amount
		{
			get { return amount ;	}
			set { amount=value;		}	
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
		
		#region ValidateStatus
		/* 确认状态 [VALIDATE_STATUS] */
		private string validateStatus;
		/// <summary>
		/// 确认状态 [VALIDATE_STATUS]
		/// </summary>
		public virtual string ValidateStatus
		{
			get { return validateStatus ;	}
			set { validateStatus=value;		}	
		}
		#endregion
		
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
		
		#region CUSTOMER_TYPE JoinType N:1	single_in
		private Workflow.Da.Domain.CustomerType customerType; 
		/// <summary>
		/// Source Table[CUSTOMER] Column[CUSTOMER_TYPE_ID] --> Target Table[CUSTOMER_TYPE] Column[ID]
		/// PropertyComment	CUSTOMER_TYPE_ID:CUSTOMER_TYPE:single
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.CustomerType CustomerType
		{
			get { return customerType;	}
			set { customerType = value;	}
		}
		#endregion
		
		#region CUSTOMER_LEVEL JoinType N:1	single_in
		private Workflow.Da.Domain.CustomerLevel customerLevel; 
		/// <summary>
		/// Source Table[CUSTOMER] Column[CUSTOMER_LEVEL_ID] --> Target Table[CUSTOMER_LEVEL] Column[ID]
		/// PropertyComment	CUSTOMER_LEVEL_ID:CUSTOMER_LEVEL:single
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.CustomerLevel CustomerLevel
		{
			get { return customerLevel;	}
			set { customerLevel = value;	}
		}
		#endregion
		
		#region SECONDARY_TRADE JoinType N:1	single_in
		private Workflow.Da.Domain.SecondaryTrade secondaryTrade; 
		/// <summary>
		/// Source Table[CUSTOMER] Column[SECONDARY_TRADE_ID] --> Target Table[SECONDARY_TRADE] Column[ID]
		/// PropertyComment	SECONDARY_TRADE_ID:SECONDARY_TRADE:single
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.SecondaryTrade SecondaryTrade
		{
			get { return secondaryTrade;	}
			set { secondaryTrade = value;	}
		}
		#endregion

		#region LINK_MAN JoinType 1:N	list_in
		private IList<Workflow.Da.Domain.LinkMan> linkManList; 
		/// <summary>
		/// Source Table[CUSTOMER] Column[ID] --> Target IList<Table[LINK_MAN]> Column[CUSTOMER_ID]
		/// PropertyComment	:LINK_MAN:list
		/// JoinType 1:N	list_in
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.LinkMan> LinkManList
		{
			get { return linkManList;	}
			set { linkManList = value;	}
		}
		#endregion
	}
}