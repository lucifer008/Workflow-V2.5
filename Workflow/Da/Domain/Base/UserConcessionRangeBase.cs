﻿#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table USER_CONCESSION_RANGE (用户优惠范围) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class UserConcessionRangeBase
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
		
		#region UsersId
		/* 用户_ID [USERS_ID] */
		private long usersId;
		/// <summary>
		/// 用户_ID [USERS_ID]
		/// </summary>
		public virtual long UsersId
		{
			get { return usersId ;	}
			set { usersId=value;		}	
		}
		#endregion
		
		#region ConcessionType
		/* 优惠类型 [CONCESSION_TYPE] */
		private string concessionType;
		/// <summary>
		/// 优惠类型 [CONCESSION_TYPE]
		/// </summary>
		public virtual string ConcessionType
		{
			get { return concessionType ;	}
			set { concessionType=value;		}	
		}
		#endregion
		
		#region Min
		/* 优惠下限 [Min] */
		private decimal min;
		/// <summary>
		/// 优惠下限 [Min]
		/// </summary>
		public virtual decimal Min
		{
			get { return min ;	}
			set { min=value;		}	
		}
		#endregion
		
		#region Max
		/* 优惠上限 [Max] */
		private decimal max;
		/// <summary>
		/// 优惠上限 [Max]
		/// </summary>
		public virtual decimal Max
		{
			get { return max ;	}
			set { max=value;		}	
		}
		#endregion
		
		#region InsertDateTime
		/* 插入时间 [INSERT_DATE_TIME] */
		private DateTime insertDateTime;
		/// <summary>
		/// 插入时间 [INSERT_DATE_TIME]
		/// </summary>
		public virtual DateTime InsertDateTime
		{
			get { return insertDateTime ;	}
			set { insertDateTime=value;		}	
		}
		#endregion
		
		#region InsertUser
		/* 插入用户 [INSERT_USER] */
		private long insertUser;
		/// <summary>
		/// 插入用户 [INSERT_USER]
		/// </summary>
		public virtual long InsertUser
		{
			get { return insertUser ;	}
			set { insertUser=value;		}	
		}
		#endregion
		
		#region UpdateDateTime
		/* 更新时间 [UPDATE_DATE_TIME] */
		private DateTime updateDateTime;
		/// <summary>
		/// 更新时间 [UPDATE_DATE_TIME]
		/// </summary>
		public virtual DateTime UpdateDateTime
		{
			get { return updateDateTime ;	}
			set { updateDateTime=value;		}	
		}
		#endregion
		
		#region UpdateUser
		/* 更新用户 [UPDATE_USER] */
		private long updateUser;
		/// <summary>
		/// 更新用户 [UPDATE_USER]
		/// </summary>
		public virtual long UpdateUser
		{
			get { return updateUser ;	}
			set { updateUser=value;		}	
		}
		#endregion
		
		#region Version
		/* 版本 [VERSION] */
		private int version;
		/// <summary>
		/// 版本 [VERSION]
		/// </summary>
		public virtual int Version
		{
			get { return version ;	}
			set { version=value;		}	
		}
		#endregion
		
		#region Deleted
		/* 删除标志 [DELETED] */
		private string deleted;
		/// <summary>
		/// 删除标志 [DELETED]
		/// </summary>
		public virtual string Deleted
		{
			get { return deleted ;	}
			set { deleted=value;		}	
		}
		#endregion
		
		#region BranchShopId
		/* 分店 [BRANCH_SHOP_ID] */
		private long branchShopId;
		/// <summary>
		/// 分店 [BRANCH_SHOP_ID]
		/// </summary>
		public virtual long BranchShopId
		{
			get { return branchShopId ;	}
			set { branchShopId=value;		}	
		}
		#endregion
		
		#region CompanyId
		/* 公司 [COMPANY_ID] */
		private long companyId;
		/// <summary>
		/// 公司 [COMPANY_ID]
		/// </summary>
		public virtual long CompanyId
		{
			get { return companyId ;	}
			set { companyId=value;		}	
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
	}
}