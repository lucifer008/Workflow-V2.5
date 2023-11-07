#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table DAILY_BUSIONESS_REPORT_ITEM (日营业报表明细) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class DailyBusionessReportItemBase 	{

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

		#region DailyBusionessReportId
		/* 日营业报表_ID [DAILY_BUSIONESS_REPORT_ID] */
		private long dailyBusionessReportId;
		/// <summary>
		/// 日营业报表_ID [DAILY_BUSIONESS_REPORT_ID]
		/// </summary>
		public virtual long DailyBusionessReportId
		{
			get { return dailyBusionessReportId ;	}
			set { dailyBusionessReportId=value;		}	
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

		#region PaperSpecificationName
		/* 纸型 [PAPER_SPECIFICATION_NAME] */
		private string paperSpecificationName;
		/// <summary>
		/// 纸型 [PAPER_SPECIFICATION_NAME]
		/// </summary>
		public virtual string PaperSpecificationName
		{
			get { return paperSpecificationName ;	}
			set { paperSpecificationName=value;		}	
		}
		#endregion

		#region Amount
		/* 金额 [AMOUNT] */
		private decimal amount;
		/// <summary>
		/// 金额 [AMOUNT]
		/// </summary>
		public virtual decimal Amount
		{
			get { return amount ;	}
			set { amount=value;		}	
		}
		#endregion

		#region Count
		/* 数量 [COUNT] */
		private decimal count;
		/// <summary>
		/// 数量 [COUNT]
		/// </summary>
		public virtual decimal Count
		{
			get { return count ;	}
			set { count=value;		}	
		}
		#endregion

		#region Sort
		/* 排序 [SORT] */
		private int sort;
		/// <summary>
		/// 排序 [SORT]
		/// </summary>
		public virtual int Sort
		{
			get { return sort ;	}
			set { sort=value;		}	
		}
		#endregion

		#region TypeSort
		/* 类型排序 [TYPE_SORT] */
		private int typeSort;
		/// <summary>
		/// 类型排序 [TYPE_SORT]
		/// </summary>
		public virtual int TypeSort
		{
			get { return typeSort ;	}
			set { typeSort=value;		}	
		}
		#endregion
	}
}