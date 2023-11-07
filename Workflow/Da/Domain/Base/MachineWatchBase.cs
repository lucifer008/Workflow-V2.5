﻿#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MACHINE_WATCH (机器上的表) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MachineWatchBase
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
		
		#region MachineTypeId
		/* 机器型号_ID [MACHINE_TYPE_ID] */
		private long machineTypeId;
		/// <summary>
		/// 机器型号_ID [MACHINE_TYPE_ID]
		/// </summary>
		public virtual long MachineTypeId
		{
			get { return machineTypeId ;	}
			set { machineTypeId=value;		}	
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
		
		#region WatchType
		/* 表类型 [WATCH_TYPE] */
		private int watchType;
		/// <summary>
		/// 表类型 [WATCH_TYPE]
		/// </summary>
		public virtual int WatchType
		{
			get { return watchType ;	}
			set { watchType=value;		}	
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
		private DateTime? updateDateTime;
		/// <summary>
		/// 更新时间 [UPDATE_DATE_TIME]
		/// </summary>
		public virtual DateTime? UpdateDateTime
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
	}
}