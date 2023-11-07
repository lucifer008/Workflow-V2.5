using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PRINT_DEMAND_DETAIL 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class PrintDemandDetailBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 印制要求_ID [PRINT_DEMAND_ID] */
		private long printDemandId;
		/** 姓名 [NAME] */
		private string name;
		/** 备注 [MEMO] */
		private string memo;
		/** 排序号 [SORT_NO] */
		private int sortNo;

		public PrintDemandDetailBase()
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
		/// 印制要求_ID [PRINT_DEMAND_ID]
		/// </summary>
		public virtual long PrintDemandId
		{
			get { return this.printDemandId; }
			set { this.printDemandId = value; }
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

		private IList<Workflow.Da.Domain.PrintRequireDetail> printRequireDetailList;
		/// <summary>
		/// Source Table[PRINT_DEMAND_DETAIL] Column[ID] --> Target Table[PRINT_REQUIRE_DETAIL] Column[PRINT_DEMAND_DETAIL_ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.PrintRequireDetail> PrintRequireDetailList
		{
			get { return printRequireDetailList; }
			set { printRequireDetailList = value; }
		}

	}
}
