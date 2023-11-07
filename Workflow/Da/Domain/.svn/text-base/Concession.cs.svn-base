using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table CONCESSION对应的DotNet Object
	/// </summary>
	[Serializable]
	public class Concession : ConcessionBase
	{
		public Concession()
		{
		}

        private string campaignName;
        public string CampaignName 
        {
            set { campaignName = value; }
            get { return campaignName; }
        }

        private string []concessionMemberCardLevelId;
        public string [] ConcessionMemberCardLevelId 
        {
            set { concessionMemberCardLevelId = value; }
            get { return concessionMemberCardLevelId; }
        }

        private decimal roomPrice;
        public decimal RoomPrice 
        {
            set { roomPrice = value; }
            get { return roomPrice; }
        }

        private long baseBusinessTypePriceSetId;
        public long BaseBusinessTypePriceSetId 
        {
            set { baseBusinessTypePriceSetId = value; }
            get { return baseBusinessTypePriceSetId; }
		}

		#region 活动的价格

		private decimal activityPrice;
		/// <summary>
		/// 活动的价格
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.14
		/// </remarks>
		public decimal ActivityPrice
		{
			get { return activityPrice; }
			set { activityPrice = value; }
		}

		#endregion

	}
}
