using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table CUSTOMER_TYPE 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class CustomerTypeBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** NO [NO] */
		private string no;
		/** 名称 [NAME] */
		private string name;
		/** 排序号 [SORT_NO] */
		private int sortNo;

		public CustomerTypeBase()
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
		/// <summary>
		/// 排序号 [SORT_NO]
		/// </summary>
		public virtual int SortNo
		{
			get { return this.sortNo; }
			set { this.sortNo = value; }
		}


	}
}
