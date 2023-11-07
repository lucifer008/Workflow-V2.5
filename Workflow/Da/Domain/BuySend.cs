#region imports
using System;
using Workflow.Da.Domain.Base;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table BUY_SEND (买M送N) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class BuySend : BuySendBase
	{
		public BuySend()
		{

		}


		#region 基本门市价格
		private BaseBusinessTypePriceSet baseBusinessTypePriceSet;
		/// <summary>
		/// 基本门市价格
		/// </summary>
		public BaseBusinessTypePriceSet BaseBusinessTypePriceSet
		{
			get { return baseBusinessTypePriceSet; }
			set { baseBusinessTypePriceSet = value; }
		}
		#endregion

		#region 活动
		private Campaign campaign;
		/// <summary>
		/// 活动
		/// </summary>
		public Campaign Campaign
		{
			get { return campaign; }
			set { campaign = value; }
		}
		#endregion
	}
}