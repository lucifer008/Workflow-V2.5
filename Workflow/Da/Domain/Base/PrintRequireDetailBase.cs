using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PRINT_REQUIRE_DETAIL ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class PrintRequireDetailBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ӡ��Ҫ����ϸ_ID [PRINT_DEMAND_DETAIL_ID] */
		private long printDemandDetailId;
		/** ���� [NAME] */
		private string name;
		/** ��ע [MEMO] */
		private string memo;
		/** ����� [SORT_NO] */
		private int sortNo;

		public PrintRequireDetailBase()
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
		/// ӡ��Ҫ����ϸ_ID [PRINT_DEMAND_DETAIL_ID]
		/// </summary>
		public virtual long PrintDemandDetailId
		{
			get { return this.printDemandDetailId; }
			set { this.printDemandDetailId = value; }
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


	}
}
