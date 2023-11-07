using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table REAL_ORDER_ITEM_PRINT_REQUIRE ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class RealOrderItemPrintRequireBase 
	{
		/** ID [ID] */
		private long id;
		/** ӡ��Ҫ����ϸ����_ID [PRINT_REQUIRE_DETAIL_ID] */
		private long printRequireDetailId;
		/** ʵ�ʶ�����ϸ_ID [REAL_ORDER_ITEM_ID] */
		private long realOrderItemId;

		public RealOrderItemPrintRequireBase()
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
		/// ӡ��Ҫ����ϸ����_ID [PRINT_REQUIRE_DETAIL_ID]
		/// </summary>
		public virtual long PrintRequireDetailId
		{
			get { return this.printRequireDetailId; }
			set { this.printRequireDetailId = value; }
		}
		/// <summary>
		/// ʵ�ʶ�����ϸ_ID [REAL_ORDER_ITEM_ID]
		/// </summary>
		public virtual long RealOrderItemId
		{
			get { return this.realOrderItemId; }
			set { this.realOrderItemId = value; }
		}


	}
}
