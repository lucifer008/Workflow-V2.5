using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PRINT_DEMAND 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class PrintDemandBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 姓名 [NAME] */
		private string name;
		/** 备注 [MEMO] */
		private string memo;
		/** 排序号 [SORT_NO] */
		private int sortNo;

		public PrintDemandBase()
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
		/// 姓名 [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
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
		/// 排序号 [SORT_NO]
		/// </summary>
		public virtual int SortNo
		{
			get { return this.sortNo; }
			set { this.sortNo = value; }
		}

		private IList<Workflow.Da.Domain.PrintDemandDetail> printDemandDetailList;
		/// <summary>
		/// Source Table[PRINT_DEMAND] Column[ID] --> Target Table[PRINT_DEMAND_DETAIL] Column[PRINT_DEMAND_ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.PrintDemandDetail> PrintDemandDetailList
		{
			get { return printDemandDetailList; }
			set { printDemandDetailList = value; }
		}

	}
}
