#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table DAILY_BUSIONESS_REPORT (日营业报表) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class DailyBusionessReportBase : Workflow.Da.Domain.Base.MetaData 	{

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

		#region CurrentDateTime
		/* 当前时间 [CURRENT_DATE_TIME] */
		private DateTime currentDateTime;
		/// <summary>
		/// 当前时间 [CURRENT_DATE_TIME]
		/// </summary>
		public virtual DateTime CurrentDateTime
		{
			get { return currentDateTime ;	}
			set { currentDateTime=value;		}	
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
	}
}