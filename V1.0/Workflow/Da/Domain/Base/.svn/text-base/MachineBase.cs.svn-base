using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MACHINE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MachineBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** NO [NO] */
		private string no;
		/** 名称 [NAME] */
		private string name;

		public MachineBase()
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
		/// NO [NO]
		/// </summary>
		public virtual string No
		{
			get { return this.no; }
			set { this.no = value; }
		}
		/// <summary>
		/// 名称 [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		private Workflow.Da.Domain.MachineType machineType;
		/// <summary>
		/// Source Table[MACHINE] Column[MACHINE_TYPE_ID] --> Target Table[MACHINE_TYPE] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.MachineType MachineType
		{
			get { return machineType; }
			set { machineType = value; }
		}

	}
}
