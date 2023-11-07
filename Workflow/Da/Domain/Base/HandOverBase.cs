#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table HAND_OVER (交班) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class HandOverBase:MetaData 	{

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

		#region EmployeeId2
		/* 雇员_ID2 [EMPLOYEE_ID2] */
		private long employeeId2;
		/// <summary>
		/// 雇员_ID2 [EMPLOYEE_ID2]
		/// </summary>
		public virtual long EmployeeId2
		{
			get { return employeeId2 ;	}
			set { employeeId2=value;		}	
		}
		#endregion

		#region HandOverDateTime
		/* 交班时间 [HAND_OVER_DATE_TIME] */
		private DateTime handOverDateTime;
		/// <summary>
		/// 交班时间 [HAND_OVER_DATE_TIME]
		/// </summary>
		public virtual DateTime HandOverDateTime
		{
			get { return handOverDateTime ;	}
			set { handOverDateTime=value;		}	
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

		#region HandOverStatus
		/* 交班状态 [HAND_OVER_STATUS] */
		private string handOverStatus;
		/// <summary>
		/// 交班状态 [HAND_OVER_STATUS]
		/// </summary>
		public virtual string HandOverStatus
		{
			get { return handOverStatus ;	}
			set { handOverStatus=value;		}	
		}
		#endregion

		#region HandOverType
		/* 交班类别 [HAND_OVER_TYPE] */
		private string handOverType;
		/// <summary>
		/// 交班类别 [HAND_OVER_TYPE]
		/// </summary>
		public virtual string HandOverType
		{
			get { return handOverType ;	}
			set { handOverType=value;		}	
		}
		#endregion
		
		#region EMPLOYEE JoinType N:1	single_in
		private Workflow.Da.Domain.Employee employee; 
		/// <summary>
		/// Source Table[HAND_OVER] Column[EMPLOYEE_ID] --> Target Table[EMPLOYEE] Column[ID]
		/// PropertyComment	EMPLOYEE_ID:EMPLOYEE:single
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.Employee Employee
		{
			get { return employee;	}
			set { employee = value;	}
		}
		#endregion
		
		#region EMPLOYEE JoinType N:1	single_in
		private Workflow.Da.Domain.Employee otherEmployee; 
		/// <summary>
		/// Source Table[HAND_OVER] Column[OTHER_EMPLOYEE_ID] --> Target Table[EMPLOYEE] Column[ID]
		/// PropertyComment	OTHER_EMPLOYEE_ID:EMPLOYEE:single
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.Employee OtherEmployee
		{
			get { return otherEmployee;	}
			set { otherEmployee = value;	}
		}
		#endregion

		#region HAND_OVER_ORDERS JoinType 1:N	list_in
		private IList<Workflow.Da.Domain.HandOverOrder> handOverOrderList; 
		/// <summary>
		/// Source Table[HAND_OVER] Column[ID] --> Target IList<Table[HAND_OVER_ORDER]> Column[HAND_OVER_ID]
		/// PropertyComment	:HAND_OVER_ORDER:list
		/// JoinType 1:N	list_in
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.HandOverOrder> HandOverOrderList
		{
			get { return handOverOrderList;	}
			set { handOverOrderList = value;	}
		}
		#endregion

		#region HAND_OVER_MEMBER_CARD JoinType 1:N	list_in
		private IList<Workflow.Da.Domain.HandOverMemberCard> handOverMemberCardList; 
		/// <summary>
		/// Source Table[HAND_OVER] Column[ID] --> Target IList<Table[HAND_OVER_MEMBER_CARD]> Column[HAND_OVER_ID]
		/// PropertyComment	:HAND_OVER_MEMBER_CARD:list
		/// JoinType 1:N	list_in
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.HandOverMemberCard> HandOverMemberCardList
		{
			get { return handOverMemberCardList;	}
			set { handOverMemberCardList = value;	}
		}
		#endregion
	}
}