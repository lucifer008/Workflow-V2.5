#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table DISCOUNT_CONCESSION (打折的优惠活动) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class DiscountConcessionBase:MetaData
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
		
		#region CampaignId
		/* 营销活动_ID [CAMPAIGN_ID] */
		private long campaignId;
		/// <summary>
		/// 营销活动_ID [CAMPAIGN_ID]
		/// </summary>
		public virtual long CampaignId
		{
			get { return campaignId ;	}
			set { campaignId=value;		}	
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

		#region DISCOUNT_CONCESSION_MACHINE_TYPE_PAPER_SPEC JoinType 1:N	list_in
		private IList<Workflow.Da.Domain.DiscountConcessionMachineTypePaperSpec> discountConcessionMachineTypePaperSpecList; 
		/// <summary>
		/// Source Table[DISCOUNT_CONCESSION] Column[ID] --> Target IList<Table[DISCOUNT_CONCESSION_MACHINE_TYPE_PAPER_SPEC]> Column[DISCOUNT_CONCESSION_ID]
		/// PropertyComment	:DISCOUNT_CONCESSION_MACHINE_TYPE_PAPER_SPEC:list:autoJoin=true
		/// JoinType 1:N	list_in
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.DiscountConcessionMachineTypePaperSpec> DiscountConcessionMachineTypePaperSpecList
		{
			get { return discountConcessionMachineTypePaperSpecList;	}
			set { discountConcessionMachineTypePaperSpecList = value;	}
		}
		#endregion
	}
}