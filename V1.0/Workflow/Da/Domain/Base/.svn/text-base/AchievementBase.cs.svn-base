#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ACHIEVEMENT (业绩) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class AchievementBase:MetaData
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
		
		#region OrderItemId
		/* 工单明细_ID [ORDER_ITEM_ID] */
		private long orderItemId;
		/// <summary>
		/// 工单明细_ID [ORDER_ITEM_ID]
		/// </summary>
		public virtual long OrderItemId
		{
			get { return orderItemId ;	}
			set { orderItemId=value;		}	
		}
		#endregion
		
		#region EmployeeId
		/* 雇员_ID [EMPLOYEE_ID] */
		private long employeeId;
		/// <summary>
		/// 雇员_ID [EMPLOYEE_ID]
		/// </summary>
		public virtual long EmployeeId
		{
			get { return employeeId ;	}
			set { employeeId=value;		}	
		}
		#endregion
		
		#region OrdersId
		/* 工单_ID [ORDERS_ID] */
		private long ordersId;
		/// <summary>
		/// 工单_ID [ORDERS_ID]
		/// </summary>
		public virtual long OrdersId
		{
			get { return ordersId ;	}
			set { ordersId=value;		}	
		}
		#endregion
		
		#region AchievementValue
		/* 业绩值 [ACHIEVEMENT_VALUE] */
		private decimal achievementValue;
		/// <summary>
		/// 业绩值 [ACHIEVEMENT_VALUE]
		/// </summary>
		public virtual decimal AchievementValue
		{
			get { return achievementValue ;	}
			set { achievementValue=value;		}	
		}
		#endregion
		
		#region Position
		/* 职务 [POSITION] */
		private string position;
		/// <summary>
		/// 职务 [POSITION]
		/// </summary>
		public virtual string Position
		{
			get { return position ;	}
			set { position=value;		}	
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
		
		#region EMPLOYEE JoinType N:1	single_in
		private Workflow.Da.Domain.Employee employee; 
		/// <summary>
		/// Source Table[ACHIEVEMENT] Column[EMPLOYEE_ID] --> Target Table[EMPLOYEE] Column[ID]
		/// PropertyComment	EMPLOYEE_ID:EMPLOYEE:single
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.Employee Employee
		{
			get { return employee;	}
			set { employee = value;	}
		}
		#endregion
	}
}