using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PRICE_FACTOR 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class PriceFactorBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 名称 [NAME] */
		private string name;
		/** 显示文本 [DISPLAY_TEXT] */
		private string displayText;
		/** 对应的表 [TARGET_TABLE] */
		private string targetTable;
		/** 对应的值列 [TARGET_VALUE_COLUMN] */
		private string targetValueColumn;
		/** 对应的文本列 [TARGET_TEXT_COLUMN] */
		private string targetTextColumn;
		/** 是否被使用 [USED] */
		private string used;
		/** 使用的时候是否显示 [IS_DISPLAY] */
		private string isDisplay;
		/** 排序号 [SORT_NO] */
		private int sortNo;

		public PriceFactorBase()
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
		/// 显示文本 [DISPLAY_TEXT]
		/// </summary>
		public virtual string DisplayText
		{
			get { return this.displayText; }
			set { this.displayText = value; }
		}
		/// <summary>
		/// 对应的表 [TARGET_TABLE]
		/// </summary>
		public virtual string TargetTable
		{
			get { return this.targetTable; }
			set { this.targetTable = value; }
		}
		/// <summary>
		/// 对应的值列 [TARGET_VALUE_COLUMN]
		/// </summary>
		public virtual string TargetValueColumn
		{
			get { return this.targetValueColumn; }
			set { this.targetValueColumn = value; }
		}
		/// <summary>
		/// 对应的文本列 [TARGET_TEXT_COLUMN]
		/// </summary>
		public virtual string TargetTextColumn
		{
			get { return this.targetTextColumn; }
			set { this.targetTextColumn = value; }
		}
		/// <summary>
		/// 是否被使用 [USED]
		/// </summary>
		public virtual string Used
		{
			get { return this.used; }
			set { this.used = value; }
		}
		/// <summary>
		/// 使用的时候是否显示 [IS_DISPLAY]
		/// </summary>
		public virtual string IsDisplay
		{
			get { return this.isDisplay; }
			set { this.isDisplay = value; }
		}
		/// <summary>
		/// 排序号 [SORT_NO]
		/// </summary>
		public virtual int SortNo
		{
			get { return this.sortNo; }
			set { this.sortNo = value; }
		}

		private IList<Workflow.Da.Domain.FactorValue> factorValueList;
		/// <summary>
		/// Source Table[PRICE_FACTOR] Column[ID] --> Target Table[FACTOR_VALUE] Column[PRICE_FACTOR_ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.FactorValue> FactorValueList
		{
			get { return factorValueList; }
			set { factorValueList = value; }
		}

	}
}
