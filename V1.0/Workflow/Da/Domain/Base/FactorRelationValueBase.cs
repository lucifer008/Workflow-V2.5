using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table FACTOR_RELATION_VALUES 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class FactorRelationValueBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** 因素之间的依赖关系_ID [FACTOR_RELATION_ID] */
		private long factorRelationId;
		/** 原值 [SOURCE_VALUE] */
		private int sourceValue;
		/** 目标值 [TARGET_VALUE] */
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
		/// 因素之间的依赖关系_ID [FACTOR_RELATION_ID]
		/// </summary>
		public virtual long FactorRelationId
		{
			get { return this.factorRelationId; }
			set { this.factorRelationId = value; }
		}
		/// <summary>
		/// 原值 [SOURCE_VALUE]
		/// </summary>
		public virtual int SourceValue
		{
			get { return this.sourceValue; }
			set { this.sourceValue = value; }
		}
		/// <summary>
		/// 目标值 [TARGET_VALUE]
		/// </summary>
		public virtual int TargetValue
		{
			get { return this.targetValue; }
			set { this.targetValue = value; }
		}


	}
}
