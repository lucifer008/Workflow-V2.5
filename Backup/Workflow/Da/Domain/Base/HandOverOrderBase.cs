using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table HAND_OVER_ORDERS 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class HandOverOrderBase 
	{
		/** ID [ID] */
		private long id;
		/** 订单_ID [ORDERS_ID] */
		private long ordersId;
		/** 交班_ID [HAND_OVER_ID] */
		private long handOverId;
		/** NO [NO] */
		private string no;
		/** 插入时间 [INSERT_DATE_TIME] */
		private DateTime insertDateTime;
		/** 送货方式 [DELIVERY_TYPE] */
		private int deliveryType;
		/** 送货时间 [DELIVERY_DATE_TIME] */
		private DateTime deliveryDateTime;
		/** 备注 [MEMO] */
		private string memo;
		/** 状态 [STATUS] */
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
		/// 订单_ID [ORDERS_ID]
		/// </summary>
		public virtual long OrdersId
		{
			get { return this.ordersId; }
			set { this.ordersId = value; }
		}
		/// <summary>
		/// 交班_ID [HAND_OVER_ID]
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
		/// 插入时间 [INSERT_DATE_TIME]
		/// </summary>
		public virtual DateTime InsertDateTime
		{
			get { return this.insertDateTime; }
			set { this.insertDateTime = value; }
		}
		/// <summary>
		/// 送货方式 [DELIVERY_TYPE]
		/// </summary>
		public virtual int DeliveryType
		{
			get { return this.deliveryType; }
			set { this.deliveryType = value; }
		}
		/// <summary>
		/// 送货时间 [DELIVERY_DATE_TIME]
		/// </summary>
		public virtual DateTime DeliveryDateTime
		{
			get { return this.deliveryDateTime; }
			set { this.deliveryDateTime = value; }
		}
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// 状态 [STATUS]
		/// </summary>
		public virtual int Status
		{
			get { return this.status; }
			set { this.status = value; }
		}


	}
}
