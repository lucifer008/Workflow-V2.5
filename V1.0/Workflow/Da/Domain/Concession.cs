using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table CONCESSION¶ÔÓ¦µÄDotNet Object
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
	}
}
