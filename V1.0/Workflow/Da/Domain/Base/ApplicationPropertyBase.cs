using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table APPLICATION_PROPERTIES 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class ApplicationPropertyBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 参数ID [PROPERTY_ID] */
		private string propertyId;
		/** 参数值 [PROPERTY_VALUE] */
		private string propertyValue;

		public ApplicationPropertyBase()
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
		/// 参数ID [PROPERTY_ID]
		/// </summary>
		public virtual string PropertyId
		{
			get { return this.propertyId; }
			set { this.propertyId = value; }
		}
		/// <summary>
		/// 参数值 [PROPERTY_VALUE]
		/// </summary>
		public virtual string PropertyValue
		{
			get { return this.propertyValue; }
			set { this.propertyValue = value; }
		}


	}
}
