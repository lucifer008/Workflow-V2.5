using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table REAL_ORDER_ITEM_TRASH_REASON ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class RealOrderItemTrashReasonBase 
	{
		/** ID [ID] */
		private long id;
		/** ʵ�ʶ�����ϸ_ID [REAL_ORDER_ITEM_ID] */
		private long realOrderItemId;
		/** ����ԭ��_ID [TRASH_REASON_ID] */
		private long trashReasonId;

		public RealOrderItemTrashReasonBase()
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
		/// ʵ�ʶ�����ϸ_ID [REAL_ORDER_ITEM_ID]
		/// </summary>
		public virtual long RealOrderItemId
		{
			get { return this.realOrderItemId; }
			set { this.realOrderItemId = value; }
		}
		/// <summary>
		/// ����ԭ��_ID [TRASH_REASON_ID]
		/// </summary>
		public virtual long TrashReasonId
		{
			get { return this.trashReasonId; }
			set { this.trashReasonId = value; }
		}


	}
}
