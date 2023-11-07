using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table SECONDARY_TRADE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class SecondaryTradeBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 主行业_ID [MASTER_TRADE_ID] */
		private long masterTradeId;
		/** NO [NO] */
		private string no;
		/** 名称 [NAME] */
		private string name;

		public SecondaryTradeBase()
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
		/// 主行业_ID [MASTER_TRADE_ID]
		/// </summary>
		public virtual long MasterTradeId
		{
			get { return this.masterTradeId; }
			set { this.masterTradeId = value; }
		}
		/// <summary>
		/// NO [NO]
		/// </summary>
		public virtual string No
		{
			get { return this.no; }
			set { this.no = value; }
		}
		/// <summary>
		/// 名称 [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}


	}
}
