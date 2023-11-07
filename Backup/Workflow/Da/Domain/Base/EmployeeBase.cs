using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table EMPLOYEE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class EmployeeBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** NO [NO] */
		private string no;
		/** 名称 [NAME] */
		private string name;

		public EmployeeBase()
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

		private IList<Workflow.Da.Domain.Position> positionList;
		/// <summary>
		/// Source Table[EMPLOYEE] Column[ID] --> Target Table[POSITION] Column[ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.Position> PositionList
		{
			get { return positionList; }
			set { positionList = value; }
		}

	}
}
