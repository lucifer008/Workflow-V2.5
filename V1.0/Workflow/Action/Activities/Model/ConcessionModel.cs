using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Action.Model
{
    public class ConcessionModel
    {
        private Concession concession;
        public Concession Concession
        {
            get { return concession; }
            set { concession = value; }
        }

        private IList<Concession> concessionList;
        public IList<Concession> ConcessionList
        {
            get { return concessionList; }
            set { concessionList = value; }
        }

        private long campaignId;
        public long CampaignId
        {
            get { return campaignId; }
            set { campaignId = value; }
        }

        private IList<MemberCardLevel> memberCardLevelList;
        public IList<MemberCardLevel> MemberCardLevelList
        {
            get { return memberCardLevelList; }
            set { memberCardLevelList = value; }
        }

        private ConcessionMemberCardLevel concessionMemberCardLevel;
        public ConcessionMemberCardLevel ConcessionMemberCardLevel
        {
            get { return concessionMemberCardLevel; }
            set { concessionMemberCardLevel = value; }
        }

        private IList<ConcessionDifferencePrice> concessionDifferencePriceList;
        public IList<ConcessionDifferencePrice> ConcessionDifferencePriceList
        {
            get { return concessionDifferencePriceList; }
            set { concessionDifferencePriceList = value; }
        }

        private ConcessionDifferencePrice concessionDifferencePrice;
        public ConcessionDifferencePrice ConcessionDifferencePrice
        {
            get { return concessionDifferencePrice; }
            set { concessionDifferencePrice = value; }
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string concessionMemberCardLevelIds;
        public string ConcessionMemberCardLevelIds
        {
            get { return concessionMemberCardLevelIds; }
            set { concessionMemberCardLevelIds = value; }
        }

        private string concessionDifferencePriceIds;
        public string ConcessionDifferencePricesIds
        {
            get { return concessionDifferencePriceIds; }
            set { concessionDifferencePriceIds = value; }
        }

        private string concessionDifferencePriceValues;
        public string ConcessionDifferencePriceValues
        {
            get { return concessionDifferencePriceValues; }
            set { concessionDifferencePriceValues = value; }
        }

        private IList<Campaign> campaignList;
        public IList<Campaign> CampaignList 
        {
            set { campaignList = value; }
            get { return campaignList; }
        }

        private string campaignName;
        public string CampaignName 
        {
            set { campaignName = value; }
            get { return campaignName; }
        }
    }
}
