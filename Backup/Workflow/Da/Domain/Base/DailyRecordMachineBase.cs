#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table DAILY_RECORD_MACHINE (每次抄表基本信息记录) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class DailyRecordMachineBase 	{

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

		#region InWatchCount
		/* 表显示数量 [IN_WATCH_COUNT] */
		private decimal inWatchCount;
		/// <summary>
		/// 表显示数量 [IN_WATCH_COUNT]
		/// </summary>
		public virtual decimal InWatchCount
		{
			get { return inWatchCount ;	}
			set { inWatchCount=value;		}	
		}
		#endregion

		#region MakeCount
		/* 实际制作数 [MAKE_COUNT] */
		private decimal makeCount;
		/// <summary>
		/// 实际制作数 [MAKE_COUNT]
		/// </summary>
		public virtual decimal MakeCount
		{
			get { return makeCount ;	}
			set { makeCount=value;		}	
		}
		#endregion

		#region CashCount
		/* 废张数 [CASH_COUNT] */
		private decimal cashCount;
		/// <summary>
		/// 废张数 [CASH_COUNT]
		/// </summary>
		public virtual decimal CashCount
		{
			get { return cashCount ;	}
			set { cashCount=value;		}	
		}
		#endregion

		#region PatchCount
		/* 补单量 [PATCH_COUNT] */
		private decimal patchCount;
		/// <summary>
		/// 补单量 [PATCH_COUNT]
		/// </summary>
		public virtual decimal PatchCount
		{
			get { return patchCount ;	}
			set { patchCount=value;		}	
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

		#region DoWatchDateTime
		/* 抄表时间 [DO_WATCH_DATE_TIME] */
		private DateTime doWatchDateTime;
		/// <summary>
		/// 抄表时间 [DO_WATCH_DATE_TIME]
		/// </summary>
		public virtual DateTime DoWatchDateTime
		{
			get { return doWatchDateTime ;	}
			set { doWatchDateTime=value;		}	
		}
		#endregion
		
		#region MACHINE_TYPE JoinType N:1	single_in
		private Workflow.Da.Domain.MachineType machineType; 
		/// <summary>
		/// Source Table[DAILY_RECORD_MACHINE] Column[MACHINE_TYPE_ID] --> Target Table[MACHINE_TYPE] Column[ID]
		/// PropertyComment	MACHINE_TYPE_ID:MACHINE_TYPE:single:autoJoin=true
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.MachineType MachineType
		{
			get { return machineType;	}
			set { machineType = value;	}
		}
		#endregion
		
		#region PAPER_SPECIFICATION JoinType N:1	single_in
		private Workflow.Da.Domain.PaperSpecification paperSpecification; 
		/// <summary>
		/// Source Table[DAILY_RECORD_MACHINE] Column[PAPER_SPECIFICATION_ID] --> Target Table[PAPER_SPECIFICATION] Column[ID]
		/// PropertyComment	PAPER_SPECIFICATION_ID:PAPER_SPECIFICATION:single:autoJoin=true
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.PaperSpecification PaperSpecification
		{
			get { return paperSpecification;	}
			set { paperSpecification = value;	}
		}
		#endregion
	}
}