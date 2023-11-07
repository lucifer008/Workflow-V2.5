using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ID_GENERATOR 对应的DotNet Object 基类
	/// 这个类是基类，不允许修改
	/// </summary>
	[Serializable]
	public class IdGeneratorBase 
	{
		/** ID [ID] */
		private long id;
		/** 标示符 [FLAG_NO] */
		private string flagNo;
		/** 开始值 [BEGIN_VALUE] */
		private long beginValue;
		/** 目前值 [CURRENT_VALUE] */
		private long currentValue;
		/** 结束值 [END_VALUE] */
		private long endValue;
		/** 备注 [MEMO] */
		private string memo;
		/** 分店 [BRANCH_SHOP_ID] */
		private long branchShopId;

		public IdGeneratorBase()
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
		/// 标示符 [FLAG_NO]
		/// </summary>
		public virtual string FlagNo
		{
			get { return this.flagNo; }
			set { this.flagNo = value; }
		}
		/// <summary>
		/// 开始值 [BEGIN_VALUE]
		/// </summary>
		public virtual long BeginValue
		{
			get { return this.beginValue; }
			set { this.beginValue = value; }
		}
		/// <summary>
		/// 目前值 [CURRENT_VALUE]
		/// </summary>
		public virtual long CurrentValue
		{
			get { return this.currentValue; }
			set { this.currentValue = value; }
		}
		/// <summary>
		/// 结束值 [END_VALUE]
		/// </summary>
		public virtual long EndValue
		{
			get { return this.endValue; }
			set { this.endValue = value; }
		}
		/// <summary>
		/// 备注 [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// 分店 [BRANCH_SHOP_ID]
		/// </summary>
		public virtual long BranchShopId
		{
			get { return this.branchShopId; }
			set { this.branchShopId = value; }
		}


	}
}
