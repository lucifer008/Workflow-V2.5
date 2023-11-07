using System;
using Workflow.Da.Domain.Base;


namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MEMBER_CARD_CONCESSION¶ÔÓ¦µÄDotNet Object
	/// </summary>
	[Serializable]
    public class MemberCardConcession : MemberCardConcessionBase
	{
		public MemberCardConcession()
		{
		}
        private decimal priceDifference;
        public decimal PriceDifference
        {
            get { return priceDifference; }
            set { priceDifference = value; }
        }

        private string memberCardNo;
        public string MemberCardNo 
        {
            set { memberCardNo = value; }
            get { return memberCardNo; }
        }

        private string customerName;
        public string CustomerName 
        {
            set { customerName = value; }
            get { return customerName; }
        }

        private string campaignName;
        public string CampaignName 
        {
            set { campaignName = value; }
            get { return campaignName; }
        }

        private string concessionName;
        public string ConcessionName 
        {
            set { concessionName = value; }
            get { return concessionName; }
        }

        private string memo;
        public string Memo 
        {
            set { memo = value; }
            get { return memo;}
        }

		private long baseBusinessTypePriceSetId;
		public long BaseBusinessTypePriceSetId 
        {
			set { baseBusinessTypePriceSetId = value; }
			get { return baseBusinessTypePriceSetId; }
        }

        //private long concessionId;
        //public long ConcessionId 
        //{
        //    set { concessionId = value; }
        //    get { return concessionId; }
        //}

		private decimal concessionPrice;
		public decimal ConcessionPrice
		{
			get { return concessionPrice; }
			set { concessionPrice = value; }
		}
	}
}
