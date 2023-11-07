#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table COMPENSATE_USED_PAPER (补单用纸情况) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class CompensateUsedPaperBase  : Workflow.Da.Domain.Base.MetaData 	{

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

		#region RecordMachineWatchId
		/* 抄表_ID [RECORD_MACHINE_WATCH_ID] */
		private long recordMachineWatchId;
		/// <summary>
		/// 抄表_ID [RECORD_MACHINE_WATCH_ID]
		/// </summary>
		public virtual long RecordMachineWatchId
		{
			get { return recordMachineWatchId ;	}
			set { recordMachineWatchId=value;		}	
		}
		#endregion

		#region PaperSpecificationId
		/* 纸型_ID [PAPER_SPECIFICATION_ID] */
		private long paperSpecificationId;
		/// <summary>
		/// 纸型_ID [PAPER_SPECIFICATION_ID]
		/// </summary>
		public virtual long PaperSpecificationId
		{
			get { return paperSpecificationId ;	}
			set { paperSpecificationId=value;		}	
		}
		#endregion

		#region UsedPaperCount
		/* 用纸量 [USED_PAPER_COUNT] */
		private int usedPaperCount;
		/// <summary>
		/// 用纸量 [USED_PAPER_COUNT]
		/// </summary>
		public virtual int UsedPaperCount
		{
			get { return usedPaperCount ;	}
			set { usedPaperCount=value;		}	
		}
		#endregion

		#region ColorType
		/* 颜色区分 [COLOR_TYPE] */
		private string colorType;
		/// <summary>
		/// 颜色区分 [COLOR_TYPE]
		/// </summary>
		public virtual string ColorType
		{
			get { return colorType ;	}
			set { colorType=value;		}	
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
		
		#region MACHINE JoinType N:1	single_in
		private Workflow.Da.Domain.MachineType machineType; 
		/// <summary>
		/// Source Table[COMPENSATE_USED_PAPER] Column[MACHINE_ID] --> Target Table[MACHINE] Column[ID]
		/// PropertyComment	MACHINE_ID:MACHINE:single:autoJoin=true
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.MachineType MachineType
		{
			get { return machineType; }
			set { machineType = value; }
		}
		#endregion
		
		#region PAPER_SPECIFICATION JoinType N:1	single_in
		private Workflow.Da.Domain.PaperSpecification paperSpecification; 
		/// <summary>
		/// Source Table[COMPENSATE_USED_PAPER] Column[PAPER_SPECIFICATION_ID] --> Target Table[PAPER_SPECIFICATION] Column[ID]
		/// PropertyComment	PAPER_SPECIFICATION_ID:PAPER_SPECIFICATION:single:autoJoin=true
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.PaperSpecification PaperSpecification
		{
			get { return paperSpecification;	}
			set { paperSpecification = value;	}
		}
		#endregion

		#region EMPLOYEE JoinType 1:N	list_out
		private IList<Workflow.Da.Domain.Employee> employeeList; 
		/// <summary>
		/// Source Table[COMPENSATE_USED_PAPER] Column[COMPENSATE_USED_PAPER_ID] --> Target IList<Table[EMPLOYEE]> Column[ID]
		/// PropertyComment	:EMPLOYEE[COMPENSATE_EMPLOYEE]:list
		/// JoinType 1:N	list_out
		/// </summary>
		public virtual  IList<Workflow.Da.Domain.Employee> EmployeeList
		{
			get { return employeeList;	}
			set { employeeList = value;	}
		}
		#endregion
	}
}