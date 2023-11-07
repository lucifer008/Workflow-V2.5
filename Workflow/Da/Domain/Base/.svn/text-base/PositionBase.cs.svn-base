using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table POSITION 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class PositionBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 名称 [NAME] */
		private string name;
		/** 备注 [MEMO] */
		private string memo;

		public PositionBase()
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
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}

		private IList<Workflow.Da.Domain.Employee> employee;
		/// <summary>
		/// Source Table[POSITION] Column[ID] --> Target Table[EMPLOYEE] Column[ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.Employee> Employee
		{
			get { return employee; }
			set { employee = value; }
		}

	}
}
