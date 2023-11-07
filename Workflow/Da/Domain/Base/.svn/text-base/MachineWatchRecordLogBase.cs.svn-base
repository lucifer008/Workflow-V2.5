#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MACHINE_WATCH_RECORD_LOG (机器表抄表记录) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MachineWatchRecordLogBase  : Workflow.Da.Domain.Base.MetaData 	{

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

		#region LastNumber
		/* 上次读数 [LAST_NUMBER] */
		private int lastNumber;
		/// <summary>
		/// 上次读数 [LAST_NUMBER]
		/// </summary>
		public virtual int LastNumber
		{
			get { return lastNumber ;	}
			set { lastNumber=value;		}	
		}
		#endregion

		#region NewNumber
		/* 本次读数 [NEW_NUMBER] */
		private int newNumber;
		/// <summary>
		/// 本次读数 [NEW_NUMBER]
		/// </summary>
		public virtual int NewNumber
		{
			get { return newNumber ;	}
			set { newNumber=value;		}	
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
		
		#region MACHINE JoinType N:1	single_in
		private Workflow.Da.Domain.Machine machine; 
		/// <summary>
		/// Source Table[MACHINE_WATCH_RECORD_LOG] Column[MACHINE_ID] --> Target Table[MACHINE] Column[ID]
		/// PropertyComment	MACHINE_ID:MACHINE:single:autoJoin=true
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.Machine Machine
		{
			get { return machine;	}
			set { machine = value;	}
		}
		#endregion
		
		#region MACHINE_WATCH JoinType N:1	single_in
		private Workflow.Da.Domain.MachineWatch machineWatch; 
		/// <summary>
		/// Source Table[MACHINE_WATCH_RECORD_LOG] Column[MACHINE_WATCH_ID] --> Target Table[MACHINE_WATCH] Column[ID]
		/// PropertyComment	MACHINE_WATCH_ID:MACHINE_WATCH:single:autoJoin=true
		/// JoinType N:1	single_in
		/// </summary>
		public virtual  Workflow.Da.Domain.MachineWatch MachineWatch
		{
			get { return machineWatch;	}
			set { machineWatch = value;	}
		}
		#endregion
	}
}