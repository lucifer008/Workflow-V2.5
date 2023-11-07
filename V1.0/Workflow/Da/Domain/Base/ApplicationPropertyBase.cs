using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table APPLICATION_PROPERTIES ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class ApplicationPropertyBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ����ID [PROPERTY_ID] */
		private string propertyId;
		/** ����ֵ [PROPERTY_VALUE] */
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
		/// ����ID [PROPERTY_ID]
		/// </summary>
		public virtual string PropertyId
		{
			get { return this.propertyId; }
			set { this.propertyId = value; }
		}
		/// <summary>
		/// ����ֵ [PROPERTY_VALUE]
		/// </summary>
		public virtual string PropertyValue
		{
			get { return this.propertyValue; }
			set { this.propertyValue = value; }
		}


	}
}
