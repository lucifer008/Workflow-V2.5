using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PRINT_DEMAND ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class PrintDemandBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ���� [NAME] */
		private string name;
		/** ��ע [MEMO] */
		private string memo;
		/** ����� [SORT_NO] */
		private int sortNo;

		public PrintDemandBase()
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
		/// ��ע [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// ����� [SORT_NO]
		/// </summary>
		public virtual int SortNo
		{
			get { return this.sortNo; }
			set { this.sortNo = value; }
		}

		private IList<Workflow.Da.Domain.PrintDemandDetail> printDemandDetailList;
		/// <summary>
		/// Source Table[PRINT_DEMAND] Column[ID] --> Target Table[PRINT_DEMAND_DETAIL] Column[PRINT_DEMAND_ID]
		/// </summary>
		public virtual IList<Workflow.Da.Domain.PrintDemandDetail> PrintDemandDetailList
		{
			get { return printDemandDetailList; }
			set { printDemandDetailList = value; }
		}

	}
}
