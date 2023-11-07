using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ID_GENERATOR ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class IdGeneratorBase 
	{
		/** ID [ID] */
		private long id;
		/** ��ʾ�� [FLAG_NO] */
		private string flagNo;
		/** ��ʼֵ [BEGIN_VALUE] */
		private long beginValue;
		/** Ŀǰֵ [CURRENT_VALUE] */
		private long currentValue;
		/** ����ֵ [END_VALUE] */
		private long endValue;
		/** ��ע [MEMO] */
		private string memo;
		/** �ֵ� [BRANCH_SHOP_ID] */
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
		/// ��ʾ�� [FLAG_NO]
		/// </summary>
		public virtual string FlagNo
		{
			get { return this.flagNo; }
			set { this.flagNo = value; }
		}
		/// <summary>
		/// ��ʼֵ [BEGIN_VALUE]
		/// </summary>
		public virtual long BeginValue
		{
			get { return this.beginValue; }
			set { this.beginValue = value; }
		}
		/// <summary>
		/// Ŀǰֵ [CURRENT_VALUE]
		/// </summary>
		public virtual long CurrentValue
		{
			get { return this.currentValue; }
			set { this.currentValue = value; }
		}
		/// <summary>
		/// ����ֵ [END_VALUE]
		/// </summary>
		public virtual long EndValue
		{
			get { return this.endValue; }
			set { this.endValue = value; }
		}
		/// <summary>
		/// ��ע [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// �ֵ� [BRANCH_SHOP_ID]
		/// </summary>
		public virtual long BranchShopId
		{
			get { return this.branchShopId; }
			set { this.branchShopId = value; }
		}


	}
}
