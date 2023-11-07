using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table GATHERING 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class GatheringBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 收款金额 [AMOUNT] */
		private decimal amount;
		/** 收款时间 [GATHERING_DATE_TIME] */
		private DateTime gatheringDateTime;

		public GatheringBase()
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
		/// 收款金额 [AMOUNT]
		/// </summary>
		public virtual decimal Amount
		{
			get { return this.amount; }
			set { this.amount = value; }
		}
		/// <summary>
		/// 收款时间 [GATHERING_DATE_TIME]
		/// </summary>
		public virtual DateTime GatheringDateTime
		{
			get { return this.gatheringDateTime; }
			set { this.gatheringDateTime = value; }
		}


	}
}
