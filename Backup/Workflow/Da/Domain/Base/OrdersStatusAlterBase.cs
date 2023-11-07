using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ORDERS_STATUS_ALTER ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class OrdersStatusAlterBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ����_ID [ORDERS_ID] */
		private long ordersId;
		/** ״̬ [STATUS] */
		private int status;
		/** ��ע [MEMO] */
		private string memo;

		public OrdersStatusAlterBase()
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
		/// ����_ID [ORDERS_ID]
		/// </summary>
		public virtual long OrdersId
		{
			get { return this.ordersId; }
			set { this.ordersId = value; }
		}
		/// <summary>
		/// ״̬ [STATUS]
		/// </summary>
		public virtual int Status
		{
			get { return this.status; }
			set { this.status = value; }
		}
		/// <summary>
		/// ��ע [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}


	}
}
