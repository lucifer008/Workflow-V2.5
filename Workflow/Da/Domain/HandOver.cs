using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table HAND_OVER对应的DotNet Object
	/// </summary>
	[Serializable]
	public class HandOver : HandOverBase
    {   /// <summary>
        /// 交班开始时间 [HAND_OVER_DATE_TIME_FROM](查询用)
        /// </summary>
        private String handOverDateTimeFrom;
        public String HandOverDateTimeFrom
        {
            get { return this.handOverDateTimeFrom; }
            set { this.handOverDateTimeFrom = value; }
        }
        
        /// <summary>
        /// 交班结束时间 [HAND_OVER_DATE_TIME_TO](查询用)
        /// </summary>
        private String handOverDateTimeTo;
        public String HandOverDateTimeTo
        {
            get { return this.handOverDateTimeTo; }
            set { this.handOverDateTimeTo = value; }
        }

        private int currentPageIndex;
        public int CurrentPageIndex
        {
            set { currentPageIndex = value; }
            get { return currentPageIndex; }
        }

        private long pageRowCount;
        public long PageRowCount
        {
            set { pageRowCount = value; }
            get { return pageRowCount; }
        }

        private string handOverTypeString;
        public string HandOverTypeString 
        {
            set { handOverTypeString=value; }
            get { return handOverTypeString; }
        }

        private int handOverTypeCasher;
        public int HandOverTypeCasher 
        {
            set { handOverTypeCasher = value; }
            get { return handOverTypeCasher; }
        }

        private string handOverPositionId;
        public string HandOverPositionId 
        {
            set { handOverPositionId = value; }
            get { return handOverPositionId; }
        }

        private string handOverOtherPersonId;
        public string HandOverOtherPersonId 
        {
            set { handOverOtherPersonId=value; }
            get { return handOverOtherPersonId; }
        }

        private string handOverPerson;
        public string HandOverPerson 
        {
            set { handOverPerson=value; }
            get { return handOverPerson; }
        }
        
        private string otherHandOverPerson;
        public string OtherHandOverPerson
        {
            set { otherHandOverPerson = value; }
            get { return otherHandOverPerson; }
        }

        private string strMemberCardList;
        public string StrMemberCardList 
        {
            set { strMemberCardList = value; }
            get { return strMemberCardList; }
        }

        private string minHandOverDateTime;
        public string MinHandOverDateTime 
        {
            set { minHandOverDateTime = value; }
            get { return minHandOverDateTime; }
        }

        private string maxHandOverDateTime;
        public string MaxHandOverDateTime 
        {
            set { maxHandOverDateTime = value; }
            get { return maxHandOverDateTime; }
        }
	}
}
