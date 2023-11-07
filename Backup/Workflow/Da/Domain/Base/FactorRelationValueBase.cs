using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table FACTOR_RELATION_VALUES ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class FactorRelationValueBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ����֮���������ϵ_ID [FACTOR_RELATION_ID] */
		private long factorRelationId;
		/** ԭֵ [SOURCE_VALUE] */
		private int sourceValue;
		/** Ŀ��ֵ [TARGET_VALUE] */
		private int targetValue;

		public FactorRelationValueBase()
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
		/// ����֮���������ϵ_ID [FACTOR_RELATION_ID]
		/// </summary>
		public virtual long FactorRelationId
		{
			get { return this.factorRelationId; }
			set { this.factorRelationId = value; }
		}
		/// <summary>
		/// ԭֵ [SOURCE_VALUE]
		/// </summary>
		public virtual int SourceValue
		{
			get { return this.sourceValue; }
			set { this.sourceValue = value; }
		}
		/// <summary>
		/// Ŀ��ֵ [TARGET_VALUE]
		/// </summary>
		public virtual int TargetValue
		{
			get { return this.targetValue; }
			set { this.targetValue = value; }
		}


	}
}
