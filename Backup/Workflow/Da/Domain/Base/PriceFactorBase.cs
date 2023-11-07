using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PRICE_FACTOR ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class PriceFactorBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ���� [NAME] */
		private string name;
		/** ��ʾ�ı� [DISPLAY_TEXT] */
		private string displayText;
		/** ��Ӧ�ı� [TARGET_TABLE] */
		private string targetTable;
		/** ��Ӧ��ֵ�� [TARGET_VALUE_COLUMN] */
		private string targetValueColumn;
		/** ��Ӧ���ı��� [TARGET_TEXT_COLUMN] */
		private string targetTextColumn;
		/** �Ƿ�ʹ�� [USED] */
		private string used;
		/** ʹ�õ�ʱ���Ƿ���ʾ [IS_DISPLAY] */
		private string isDisplay;
		/** ����� [SORT_NO] */
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
		/// ���� [NAME]
		/// </summary>
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}
		/// <summary>
		/// ��ʾ�ı� [DISPLAY_TEXT]
		/// </summary>
		public virtual string DisplayText
		{
			get { return this.displayText; }
			set { this.displayText = value; }
		}
		/// <summary>
		/// ��Ӧ�ı� [TARGET_TABLE]
		/// </summary>
		public virtual string TargetTable
		{
			get { return this.targetTable; }
			set { this.targetTable = value; }
		}
		/// <summary>
		/// ��Ӧ��ֵ�� [TARGET_VALUE_COLUMN]
		/// </summary>
		public virtual string TargetValueColumn
		{
			get { return this.targetValueColumn; }
			set { this.targetValueColumn = value; }
		}
		/// <summary>
		/// ��Ӧ���ı��� [TARGET_TEXT_COLUMN]
		/// </summary>
		public virtual string TargetTextColumn
		{
			get { return this.targetTextColumn; }
			set { this.targetTextColumn = value; }
		}
		/// <summary>
		/// �Ƿ�ʹ�� [USED]
		/// </summary>
		public virtual string Used
		{
			get { return this.used; }
			set { this.used = value; }
		}
		/// <summary>
		/// ʹ�õ�ʱ���Ƿ���ʾ [IS_DISPLAY]
		/// </summary>
		public virtual string IsDisplay
		{
			get { return this.isDisplay; }
			set { this.isDisplay = value; }
		}
		/// <summary>
		/// ����� [SORT_NO]
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
