﻿#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PERMISSION_GROUP (权限许可组) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class PermissionGroupBase:MetaData
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
		
		#region SortNo
		/* 排序号 [SORT_NO] */
		private int sortNo;
		/// <summary>
		/// 排序号 [SORT_NO]
		/// </summary>
		public virtual int SortNo
		{
			get { return sortNo ;	}
			set { sortNo=value;		}	
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

		#region PERMISSION JoinType 1:N	list_out
		private IList<Workflow.Da.Domain.Permission> permissionList; 
		/// <summary>
		/// Source Table[PERMISSION_GROUP] Column[PERMISSION_GROUP_ID] --> Target IList<Table[PERMISSION]> Column[ID]
		/// PropertyComment	ID:PERMISSION[PERMISSION_GROUP_DETAIL]:list:autoJoin=true
		/// JoinType 1:N	list_out
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.Permission> PermissionList
		{
			get { return permissionList;	}
			set { permissionList = value;	}
		}
		#endregion
	}
}