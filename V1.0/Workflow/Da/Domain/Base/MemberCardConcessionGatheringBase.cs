#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MEMBER_CARD_CONCESSION_GATHERING (会员卡参加优惠活动的付款记录) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MemberCardConcessionGatheringBase:MetaData
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
		
		#region MemberCardConcessionId
		/* 会员卡参加的优惠活动_ID [MEMBER_CARD_CONCESSION_ID] */
		private long memberCardConcessionId;
		/// <summary>
		/// 会员卡参加的优惠活动_ID [MEMBER_CARD_CONCESSION_ID]
		/// </summary>
		public virtual long MemberCardConcessionId
		{
			get { return memberCardConcessionId ;	}
			set { memberCardConcessionId=value;		}	
		}
		#endregion
		
		#region MemberCardDiscountConcessionId
		/* 会员卡参加的打折优惠活动_ID [MEMBER_CARD_DISCOUNT_CONCESSION_ID] */
		private long memberCardDiscountConcessionId;
		/// <summary>
		/// 会员卡参加的打折优惠活动_ID [MEMBER_CARD_DISCOUNT_CONCESSION_ID]
		/// </summary>
		public virtual long MemberCardDiscountConcessionId
		{
			get { return memberCardDiscountConcessionId ;	}
			set { memberCardDiscountConcessionId=value;		}	
		}
		#endregion
		
		#region ChargeAmount
		/* 冲值金额 [CHARGE_AMOUNT] */
		private decimal chargeAmount;
		/// <summary>
		/// 冲值金额 [CHARGE_AMOUNT]
		/// </summary>
		public virtual decimal ChargeAmount
		{
			get { return chargeAmount ;	}
			set { chargeAmount=value;		}	
		}
		#endregion
		
		#region PayType
		/* 付款类型 [PAY_TYPE] */
		private string payType;
		/// <summary>
		/// 付款类型 [PAY_TYPE]
		/// </summary>
		public virtual string PayType
		{
			get { return payType ;	}
			set { payType=value;		}	
		}
		#endregion
		
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
        //private DateTime updateDateTime;
        ///// <summary>
        ///// 更新时间 [UPDATE_DATE_TIME]
        ///// </summary>
        //public virtual DateTime UpdateDateTime
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
	}
}