#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table BUSINESS_MODULE_GROUP (业务模块组) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class BusinessModuleGroupBase
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
		
		#region ModuleName
		/* 模块组名称 [MODULE_NAME] */
		private string moduleName;
		/// <summary>
		/// 模块组名称 [MODULE_NAME]
		/// </summary>
		public virtual string ModuleName
		{
			get { return moduleName ;	}
			set { moduleName=value;		}	
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