#region imports
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
#endregion

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table APPLICATION_PROPERTIES (程序参数) 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class ApplicationPropertyBase : Workflow.Da.Domain.Base.MetaData
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

		#region PropertyId
		/* 参数ID [PROPERTY_ID] */
		private string propertyId;
		/// <summary>
		/// 参数ID [PROPERTY_ID]
		/// </summary>
		public virtual string PropertyId
		{
			get { return propertyId ;	}
			set { propertyId=value;		}	
		}
		#endregion

		#region PropertyValue
		/* 参数值 [PROPERTY_VALUE] */
		private string propertyValue;
		/// <summary>
		/// 参数值 [PROPERTY_VALUE]
		/// </summary>
		public virtual string PropertyValue
		{
			get { return propertyValue ;	}
			set { propertyValue=value;		}	
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