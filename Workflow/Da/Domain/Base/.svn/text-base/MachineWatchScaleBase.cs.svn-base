#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MACHINE_WATCH_SCALE (机器上表的最新刻度) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MachineWatchScaleBase  : Workflow.Da.Domain.Base.MetaData 	{

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

		#region MachineWatchId
		/* 机器上的表_ID [MACHINE_WATCH_ID] */
		private long machineWatchId;
		/// <summary>
		/// 机器上的表_ID [MACHINE_WATCH_ID]
		/// </summary>
		public virtual long MachineWatchId
		{
			get { return machineWatchId ;	}
			set { machineWatchId=value;		}	
		}
		#endregion

		#region LastestNumber
		/* 最新读数 [LASTEST_NUMBER] */
		private int lastestNumber;
		/// <summary>
		/// 最新读数 [LASTEST_NUMBER]
		/// </summary>
		public virtual int LastestNumber
		{
			get { return lastestNumber ;	}
			set { lastestNumber=value;		}	
		}
		#endregion
	}
}