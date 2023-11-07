using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table SECONDARY_TRADE ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class SecondaryTradeBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ����ҵ_ID [MASTER_TRADE_ID] */
		private long masterTradeId;
		/** NO [NO] */
		private string no;
		/** ���� [NAME] */
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
		/// ����ҵ_ID [MASTER_TRADE_ID]
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
		/// ���� [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}


	}
}
