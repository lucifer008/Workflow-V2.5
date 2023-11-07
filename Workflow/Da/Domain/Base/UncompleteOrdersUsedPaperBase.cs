#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table UNCOMPLETE_ORDERS_USED_PAPER (未完工订单用纸情况) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class UncompleteOrdersUsedPaperBase  : Workflow.Da.Domain.Base.MetaData 	{

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

		#region RecordMachineWatchId
		/* 抄表_ID [RECORD_MACHINE_WATCH_ID] */
		private long recordMachineWatchId;
		/// <summary>
		/// 抄表_ID [RECORD_MACHINE_WATCH_ID]
		/// </summary>
		public virtual long RecordMachineWatchId
		{
			get { return recordMachineWatchId ;	}
			set { recordMachineWatchId=value;		}	
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

		#region UsedPaperCount
		/* 用纸量 [USED_PAPER_COUNT] */
		private int usedPaperCount;
		/// <summary>
		/// 用纸量 [USED_PAPER_COUNT]
		/// </summary>
		public virtual int UsedPaperCount
		{
			get { return usedPaperCount ;	}
			set { usedPaperCount=value;		}	
		}
		#endregion

		#region ColorType
		/* 颜色区分 [COLOR_TYPE] */
		private string colorType;
		/// <summary>
		/// 颜色区分 [COLOR_TYPE]
		/// </summary>
		public virtual string ColorType
		{
			get { return colorType ;	}
			set { colorType=value;		}	
		}
		#endregion
		
		#region MACHINE JoinType N:1	single_in
		private Workflow.Da.Domain.Machine machine; 
		/// <summary>
		/// Source Table[UNCOMPLETE_ORDERS_USED_PAPER] Column[MACHINE_ID] --> Target Table[MACHINE] Column[ID]
		/// PropertyComment	MACHINE_ID:MACHINE:single:autoJoin=true
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.Machine Machine
		{
			get { return machine;	}
			set { machine = value;	}
		}
		#endregion
		
		#region PAPER_SPECIFICATION JoinType N:1	single_in
		private Workflow.Da.Domain.PaperSpecification paperSpecification; 
		/// <summary>
		/// Source Table[UNCOMPLETE_ORDERS_USED_PAPER] Column[PAPER_SPECIFICATION_ID] --> Target Table[PAPER_SPECIFICATION] Column[ID]
		/// PropertyComment	PAPER_SPECIFICATION_ID:PAPER_SPECIFICATION:single:autoJoin=true
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.PaperSpecification PaperSpecification
		{
			get { return paperSpecification;	}
			set { paperSpecification = value;	}
		}
		#endregion
	}
}