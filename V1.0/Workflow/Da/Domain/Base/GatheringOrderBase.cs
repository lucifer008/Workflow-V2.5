using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table GATHERING_ORDERS ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class GatheringOrderBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ����_ID [ORDERS_ID] */
		private long ordersId;
		/** �տ��¼_ID [GATHERING_ID] */
		private long gatheringId;
		/** �������� [PAY_KIND] */
		private string payKind;

		public GatheringOrderBase()
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
		/// �տ��¼_ID [GATHERING_ID]
		/// </summary>
		public virtual long GatheringId
		{
			get { return this.gatheringId; }
			set { this.gatheringId = value; }
		}
		/// <summary>
		/// �������� [PAY_KIND]
		/// </summary>
		public virtual string PayKind
		{
			get { return this.payKind; }
			set { this.payKind = value; }
		}


	}
}
