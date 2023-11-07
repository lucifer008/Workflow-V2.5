#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table MARKING_SETTING (积分设置) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class MarkingSettingBase
	{
		
		#region Id
		/* ID [ID] */
		private long id;
		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return id ;	}
			set { id=value;		}	
		}
		#endregion
		
		#region ProcessContentId
		/* 加工内容_ID [PROCESS_CONTENT_ID] */
		private long processContentId;
		/// <summary>
		/// 加工内容_ID [PROCESS_CONTENT_ID]
		/// </summary>
		public virtual long ProcessContentId
		{
			get { return processContentId ;	}
			set { processContentId=value;		}	
		}
		#endregion
		
		#region Amount
		/* 积分金额 [AMOUNT] */
		private decimal amount;
		/// <summary>
		/// 积分金额 [AMOUNT]
		/// </summary>
		public virtual decimal Amount
		{
			get { return amount ;	}
			set { amount=value;		}	
		}
		#endregion
		
		#region Marking
		/* 分 [MARKING] */
		private decimal marking;
		/// <summary>
		/// 分 [MARKING]
		/// </summary>
		public virtual decimal Marking
		{
			get { return marking ;	}
			set { marking=value;		}	
		}
		#endregion
		
		#region Memo
		/* 备注 [MEMO] */
		private string memo;
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return memo ;	}
			set { memo=value;		}	
		}
		#endregion
	}
}