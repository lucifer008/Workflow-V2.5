#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table RECORD_MACHINE_WATCH (抄表) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class RecordMachineWatchBase : MetaData
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
		
		#region RecordDateTime
		/* 查表时间 [RECORD_DATE_TIME] */
		private DateTime recordDateTime;
		/// <summary>
		/// 查表时间 [RECORD_DATE_TIME]
		/// </summary>
		public virtual DateTime RecordDateTime
		{
			get { return recordDateTime ;	}
			set { recordDateTime=value;		}	
		}
		#endregion
		
		#region IsConfirmed
		/* 是否确认 [IS_CONFIRMED] */
		private string isConfirmed;
		/// <summary>
		/// 是否确认 [IS_CONFIRMED]
		/// </summary>
		public virtual string IsConfirmed
		{
			get { return isConfirmed ;	}
			set { isConfirmed=value;		}	
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

		#region MACHINE_WATCH_RECORD_LOG JoinType 1:N	list_in
		private IList<Workflow.Da.Domain.MachineWatchRecordLog> machineWatchRecordLogList; 
		/// <summary>
		/// Source Table[RECORD_MACHINE_WATCH] Column[ID] --> Target IList<Table[MACHINE_WATCH_RECORD_LOG]> Column[RECORD_MACHINE_WATCH_ID]
		/// PropertyComment	:MACHINE_WATCH_RECORD_LOG:list
		/// JoinType 1:N	list_in
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.MachineWatchRecordLog> MachineWatchRecordLogList
		{
			get { return machineWatchRecordLogList;	}
			set { machineWatchRecordLogList = value;	}
		}
		#endregion

		#region COMPENSATE_USED_PAPER JoinType 1:N	list_in
		private IList<Workflow.Da.Domain.CompensateUsedPaper> compensateUsedPaperList; 
		/// <summary>
		/// Source Table[RECORD_MACHINE_WATCH] Column[ID] --> Target IList<Table[COMPENSATE_USED_PAPER]> Column[RECORD_MACHINE_WATCH_ID]
		/// PropertyComment	:COMPENSATE_USED_PAPER:list
		/// JoinType 1:N	list_in
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.CompensateUsedPaper> CompensateUsedPaperList
		{
			get { return compensateUsedPaperList;	}
			set { compensateUsedPaperList = value;	}
		}
		#endregion

		#region UNCOMPLETE_ORDERS_USED_PAPER JoinType 1:N	list_in
		private IList<Workflow.Da.Domain.UncompleteOrdersUsedPaper> uncompleteOrdersUsedPaperList; 
		/// <summary>
		/// Source Table[RECORD_MACHINE_WATCH] Column[ID] --> Target IList<Table[UNCOMPLETE_ORDERS_USED_PAPER]> Column[RECORD_MACHINE_WATCH_ID]
		/// PropertyComment	:UNCOMPLETE_ORDERS_USED_PAPER:list
		/// JoinType 1:N	list_in
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.UncompleteOrdersUsedPaper> UncompleteOrdersUsedPaperList
		{
			get { return uncompleteOrdersUsedPaperList;	}
			set { uncompleteOrdersUsedPaperList = value;	}
		}
		#endregion
	}
}