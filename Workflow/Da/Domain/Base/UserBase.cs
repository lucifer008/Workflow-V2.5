#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table USERS (用户) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class UserBase:MetaData
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
		
		#region UserName
		/* 登陆用户名 [USER_NAME] */
		private string userName;
		/// <summary>
		/// 登陆用户名 [USER_NAME]
		/// </summary>
		public virtual string UserName
		{
			get { return userName ;	}
			set { userName=value;		}	
		}
		#endregion
		
		#region Password
		/* 密码 [PASSWORD] */
		private string password;
		/// <summary>
		/// 密码 [PASSWORD]
		/// </summary>
		public virtual string Password
		{
			get { return password ;	}
			set { password=value;		}	
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
		
		#region IsLogin
		/* 是否已登陆 [IS_LOGIN] */
		private string isLogin;
		/// <summary>
		/// 是否已登陆 [IS_LOGIN]
		/// </summary>
		public virtual string IsLogin
		{
			get { return isLogin ;	}
			set { isLogin=value;		}	
		}
		#endregion
		
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

		#region ROLE JoinType 1:N	list_out
		private IList<Workflow.Da.Domain.Role> roleList; 
		/// <summary>
		/// Source Table[USERS] Column[USERS_ID] --> Target IList<Table[ROLE]> Column[ID]
		/// PropertyComment	:ROLE[USER_ROLE]:list:autoJoin=true
		/// JoinType 1:N	list_out
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.Role> RoleList
		{
			get { return roleList;	}
			set { roleList = value;	}
		}
		#endregion

		#region USER_CONCESSION_RANGE JoinType 1:N	list_in
		private IList<Workflow.Da.Domain.UserConcessionRange> userConcessionRangeList; 
		/// <summary>
		/// Source Table[USERS] Column[ID] --> Target IList<Table[USER_CONCESSION_RANGE]> Column[USERS_ID]
		/// PropertyComment	:USER_CONCESSION_RANGE:list:single:autoJoin=true
		/// JoinType 1:N	list_in
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.UserConcessionRange> UserConcessionRangeList
		{
			get { return userConcessionRangeList;	}
			set { userConcessionRangeList = value;	}
		}
		#endregion

        #region EMPLOYEE JoinType N:1	single_in
        private Workflow.Da.Domain.Employee employee;
        /// <summary>
        /// Source Table[USERS] Column[EMPLOYEE_ID] --> Target Table[EMPLOYEE] Column[ID]
        /// PropertyComment	EMPLOYEE_ID:EMPLOYEE:single:autoJoin=true
        /// JoinType N:1	single_in
        /// </summary>
        public virtual Workflow.Da.Domain.Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }
        #endregion
	}
}