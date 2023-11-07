#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table DISCOUNT_CONCESSION_MACHINE_TYPE_PAPER_SPEC (打折的优惠活动所适用的机器类型和纸型) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class DiscountConcessionMachineTypePaperSpecBase
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
		
		#region MachineTypeId
		/* 机器型号_ID [MACHINE_TYPE_ID] */
		private long machineTypeId;
		/// <summary>
		/// 机器型号_ID [MACHINE_TYPE_ID]
		/// </summary>
		public virtual long MachineTypeId
		{
			get { return machineTypeId ;	}
			set { machineTypeId=value;		}	
		}
		#endregion
		
		#region PaperSpecificationId
		/* 纸型_ID [PAPER_SPECIFICATION_ID] */
		private long paperSpecificationId;
		/// <summary>
		/// 纸型_ID [PAPER_SPECIFICATION_ID]
		/// </summary>
		public virtual long PaperSpecificationId
		{
			get { return paperSpecificationId ;	}
			set { paperSpecificationId=value;		}	
		}
		#endregion
		
		#region DiscountConcessionId
		/* 打折的优惠活动_ID [DISCOUNT_CONCESSION_ID] */
		private long discountConcessionId;
		/// <summary>
		/// 打折的优惠活动_ID [DISCOUNT_CONCESSION_ID]
		/// </summary>
		public virtual long DiscountConcessionId
		{
			get { return discountConcessionId ;	}
			set { discountConcessionId=value;		}	
		}
		#endregion
		
		#region Discount
		/* 折扣 [DISCOUNT] */
		private decimal discount;
		/// <summary>
		/// 折扣 [DISCOUNT]
		/// </summary>
		public virtual decimal Discount
		{
			get { return discount ;	}
			set { discount=value;		}	
		}
		#endregion
	}
}