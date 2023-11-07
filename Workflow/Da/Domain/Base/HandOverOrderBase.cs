using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table HAND_OVER_ORDERS ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class HandOverOrderBase 
	{
		/** ID [ID] */
		private long id;
		/** ����_ID [ORDERS_ID] */
		private long ordersId;
		/** ����_ID [HAND_OVER_ID] */
		private long handOverId;
		/** NO [NO] */
		private string no;
		/** ����ʱ�� [INSERT_DATE_TIME] */
		private DateTime insertDateTime;
		/** �ͻ���ʽ [DELIVERY_TYPE] */
		private int deliveryType;
		/** �ͻ�ʱ�� [DELIVERY_DATE_TIME] */
		private DateTime deliveryDateTime;
		/** ��ע [MEMO] */
		private string memo;
		/** ״̬ [STATUS] */
		private int status;

		public HandOverOrderBase()
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
		/// ����_ID [HAND_OVER_ID]
		/// </summary>
		public virtual long HandOverId
		{
			get { return this.handOverId; }
			set { this.handOverId = value; }
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
		/// ����ʱ�� [INSERT_DATE_TIME]
		/// </summary>
		public virtual DateTime InsertDateTime
		{
			get { return this.insertDateTime; }
			set { this.insertDateTime = value; }
		}
		/// <summary>
		/// �ͻ���ʽ [DELIVERY_TYPE]
		/// </summary>
		public virtual int DeliveryType
		{
			get { return this.deliveryType; }
			set { this.deliveryType = value; }
		}
		/// <summary>
		/// �ͻ�ʱ�� [DELIVERY_DATE_TIME]
		/// </summary>
		public virtual DateTime DeliveryDateTime
		{
			get { return this.deliveryDateTime; }
			set { this.deliveryDateTime = value; }
		}
		/// <summary>
		/// ��ע [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// ״̬ [STATUS]
		/// </summary>
		public virtual int Status
		{
			get { return this.status; }
			set { this.status = value; }
		}


	}
}
