#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table APPLY_ABATE (申请优惠) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class ApplyAbateBase : Workflow.Da.Domain.Base.MetaData
	{

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
		/* 工单_ID [ORDERS_ID] */
		private long ordersId;
		/// <summary>
		/// 工单_ID [ORDERS_ID]
		/// </summary>
		public virtual long OrdersId
		{
			get { return ordersId ;	}
			set { ordersId=value;		}	
		}
		#endregion

		#region Money
		/* 金额 [MONEY] */
		private decimal money;
		/// <summary>
		/// 金额 [MONEY]
		/// </summary>
		public virtual decimal Money
		{
			get { return money ;	}
			set { money=value;		}	
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

		#region IsAgree
		/* 是否通过审核 [IS_AGREE] */
		private string isAgree;
		/// <summary>
		/// 是否通过审核 [IS_AGREE]
		/// </summary>
		public virtual string IsAgree
		{
			get { return isAgree ;	}
			set { isAgree=value;		}	
		}
		#endregion
	}
}