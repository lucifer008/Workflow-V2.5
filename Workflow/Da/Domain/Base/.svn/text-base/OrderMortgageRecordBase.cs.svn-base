#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ORDER_MORTGAGE_RECORD (订单冲减记录) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class OrderMortgageRecordBase  : Workflow.Da.Domain.Base.MetaData 	{

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

		#region OrdersId
		/* 订单_ID [ORDERS_ID] */
		private long ordersId;
		/// <summary>
		/// 订单_ID [ORDERS_ID]
		/// </summary>
		public virtual long OrdersId
		{
			get { return ordersId ;	}
			set { ordersId=value;		}	
		}
		#endregion

		#region SrcOrderId
		/* 原订单ID [SRC_ORDER_ID] */
		private long srcOrderId;
		/// <summary>
		/// 原订单ID [SRC_ORDER_ID]
		/// </summary>
		public virtual long SrcOrderId
		{
			get { return srcOrderId ;	}
			set { srcOrderId=value;		}	
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