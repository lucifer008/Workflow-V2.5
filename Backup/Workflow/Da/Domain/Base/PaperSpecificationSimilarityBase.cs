using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table PAPER_SPECIFICATION_SIMILARITY 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class PaperSpecificationSimilarityBase 
	{
		/** ID [ID] */
		private long id;
		/** 父纸型_ID [PARENT_PAPER_SPECIFICATION_ID] */
		private long parentPaperSpecificationId;
		/** 子纸型_ID [CHILD_PAPER_SPECIFICATION_ID] */
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
		/// 父纸型_ID [PARENT_PAPER_SPECIFICATION_ID]
		/// </summary>
		public virtual long ParentPaperSpecificationId
		{
			get { return this.parentPaperSpecificationId; }
			set { this.parentPaperSpecificationId = value; }
		}
		/// <summary>
		/// 子纸型_ID [CHILD_PAPER_SPECIFICATION_ID]
		/// </summary>
		public virtual long ChildPaperSpecificationId
		{
			get { return this.childPaperSpecificationId; }
			set { this.childPaperSpecificationId = value; }
		}


	}
}
