using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table DAILY_RECORD_MACHINE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class DailyRecordMachineBase 
	{
		/** ID [ID] */
		private long id;
		/** 颜色区分 [COLOR_TYPE] */
		private string colorType;
		/** 表显示数量 [IN_WATCH_COUNT] */
		private decimal inWatchCount;
		/** 实际制作数 [MAKE_COUNT] */
		private decimal makeCount;
		/** 废张数 [CASH_COUNT] */
		private decimal cashCount;
		/** 补单量 [PATCH_COUNT] */
		private decimal patchCount;
		/** 备注 [MEMO] */
		private string memo;
		/** 抄表时间 [DO_WATCH_DATE_TIME] */
		private DateTime doWatchDateTime;

		public DailyRecordMachineBase()
		{
			
		}

		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return this.id; }
			set { this.id = value; }
		}
		/// <summary>
		/// 颜色区分 [COLOR_TYPE]
		/// </summary>
		public virtual string ColorType
		{
			get { return this.colorType; }
			set { this.colorType = value; }
		}
		/// <summary>
		/// 表显示数量 [IN_WATCH_COUNT]
		/// </summary>
		public virtual decimal InWatchCount
		{
			get { return this.inWatchCount; }
			set { this.inWatchCount = value; }
		}
		/// <summary>
		/// 实际制作数 [MAKE_COUNT]
		/// </summary>
		public virtual decimal MakeCount
		{
			get { return this.makeCount; }
			set { this.makeCount = value; }
		}
		/// <summary>
		/// 废张数 [CASH_COUNT]
		/// </summary>
		public virtual decimal CashCount
		{
			get { return this.cashCount; }
			set { this.cashCount = value; }
		}
		/// <summary>
		/// 补单量 [PATCH_COUNT]
		/// </summary>
		public virtual decimal PatchCount
		{
			get { return this.patchCount; }
			set { this.patchCount = value; }
		}
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// 抄表时间 [DO_WATCH_DATE_TIME]
		/// </summary>
		public virtual DateTime DoWatchDateTime
		{
			get { return this.doWatchDateTime; }
			set { this.doWatchDateTime = value; }
		}

		private Workflow.Da.Domain.Machine machine;
		/// <summary>
		/// Source Table[DAILY_RECORD_MACHINE] Column[MACHINE_ID] --> Target Table[MACHINE] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.Machine Machine
		{
			get { return machine; }
			set { machine = value; }
		}
		private Workflow.Da.Domain.PaperSpecification paperSpecification;
		/// <summary>
		/// Source Table[DAILY_RECORD_MACHINE] Column[PAPER_SPECIFICATION_ID] --> Target Table[PAPER_SPECIFICATION] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.PaperSpecification PaperSpecification
		{
			get { return paperSpecification; }
			set { paperSpecification = value; }
		}

	}
}
