using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PAPER_SPECIFICATION_SIMILARITY ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class PaperSpecificationSimilarityBase 
	{
		/** ID [ID] */
		private long id;
		/** ��ֽ��_ID [PARENT_PAPER_SPECIFICATION_ID] */
		private long parentPaperSpecificationId;
		/** ��ֽ��_ID [CHILD_PAPER_SPECIFICATION_ID] */
		private long childPaperSpecificationId;

		public PaperSpecificationSimilarityBase()
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
		/// ��ֽ��_ID [PARENT_PAPER_SPECIFICATION_ID]
		/// </summary>
		public virtual long ParentPaperSpecificationId
		{
			get { return this.parentPaperSpecificationId; }
			set { this.parentPaperSpecificationId = value; }
		}
		/// <summary>
		/// ��ֽ��_ID [CHILD_PAPER_SPECIFICATION_ID]
		/// </summary>
		public virtual long ChildPaperSpecificationId
		{
			get { return this.childPaperSpecificationId; }
			set { this.childPaperSpecificationId = value; }
		}


	}
}
