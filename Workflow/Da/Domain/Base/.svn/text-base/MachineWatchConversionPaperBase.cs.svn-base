using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MACHINE_WATCH_CONVERSION_PAPER 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MachineWatchConversionPaperBase 
	{
		/** ID [ID] */
		private long id;
		/** 名称 [NAME] */
		private string name;
		/** 计算公式 [COMPUTE_FORMULA] */
		private string computeFormula;
		/** 颜色区分 [COLOR_TYPE] */
		private string colorType;

		public MachineWatchConversionPaperBase()
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
		/// 名称 [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}
		/// <summary>
		/// 计算公式 [COMPUTE_FORMULA]
		/// </summary>
		public virtual string ComputeFormula
		{
			get { return this.computeFormula; }
			set { this.computeFormula = value; }
		}
		/// <summary>
		/// 颜色区分 [COLOR_TYPE]
		/// </summary>
		public virtual string ColorType
		{
			get { return this.colorType; }
			set { this.colorType = value; }
		}

		private Workflow.Da.Domain.PaperSpecification paperSpecification;
		/// <summary>
		/// Source Table[MACHINE_WATCH_CONVERSION_PAPER] Column[PAPER_SPECIFICATION_ID] --> Target Table[PAPER_SPECIFICATION] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.PaperSpecification PaperSpecification
		{
			get { return paperSpecification; }
			set { paperSpecification = value; }
		}
		private Workflow.Da.Domain.MachineType machineType;
		/// <summary>
		/// Source Table[MACHINE_WATCH_CONVERSION_PAPER] Column[MACHINE_TYPE_ID] --> Target Table[MACHINE_TYPE] Column[ID]
		/// </summary>
		public virtual Workflow.Da.Domain.MachineType MachineType
		{
			get { return machineType; }
			set { machineType = value; }
		}

	}
}
