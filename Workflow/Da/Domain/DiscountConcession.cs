#region imports
using System;
using Workflow.Da.Domain.Base;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table DISCOUNT_CONCESSION (打折的优惠活动) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class DiscountConcession : DiscountConcessionBase
	{
		public DiscountConcession()
		{
		}

		#region 营销活动名称

		private string campaignName;
		/// <summary>
		/// 营销活动名称
		/// </summary>
		public string CampaignName
		{
			get { return campaignName; }
			set { campaignName = value; }
		}

		#endregion
	}
}