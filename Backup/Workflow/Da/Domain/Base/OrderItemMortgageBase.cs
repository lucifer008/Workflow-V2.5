#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ORDER_ITEM_MORTGAGE (订单冲减明细) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class OrderItemMortgageBase  : Workflow.Da.Domain.Base.MetaData 	{

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

		#region OrderMortgageRecordId
		/* 订单冲减记录_ID [ORDER_MORTGAGE_RECORD_ID] */
		private long orderMortgageRecordId;
		/// <summary>
		/// 订单冲减记录_ID [ORDER_MORTGAGE_RECORD_ID]
		/// </summary>
		public virtual long OrderMortgageRecordId
		{
			get { return orderMortgageRecordId ;	}
			set { orderMortgageRecordId=value;		}	
		}
		#endregion

		#region OrderItemId
		/* 订单明细_ID [ORDER_ITEM_ID] */
		private long orderItemId;
		/// <summary>
		/// 订单明细_ID [ORDER_ITEM_ID]
		/// </summary>
		public virtual long OrderItemId
		{
			get { return orderItemId ;	}
			set { orderItemId=value;		}	
		}
		#endregion

		#region SrcOrderItemId
		/* 原订单明细ID [SRC_ORDER_ITEM_ID] */
		private long srcOrderItemId;
		/// <summary>
		/// 原订单明细ID [SRC_ORDER_ITEM_ID]
		/// </summary>
		public virtual long SrcOrderItemId
		{
			get { return srcOrderItemId ;	}
			set { srcOrderItemId=value;		}	
		}
		#endregion

		#region Amount
		/* 冲减数量 [AMOUNT] */
		private int amount;
		/// <summary>
		/// 冲减数量 [AMOUNT]
		/// </summary>
		public virtual int Amount
		{
			get { return amount ;	}
			set { amount=value;		}	
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