using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;
/// <summary>
/// 名    称: MemberCardModel
/// 功能概要: 会员卡操作的Model
/// 作    者: 张晓林
/// 创建时间: 2009-01-23
/// 修正履历: 
/// 修正时间: 
/// </summary>
namespace Workflow.Action.Model
{
    public class MemberCardModel
    {
        private long memberCardId;
        ///<summary>
        /// Gets or sets the member card id
        /// </summary>
        /// <value>The member card id.</value>
        public long MemberCardId
        {
            get { return memberCardId; }
            set { memberCardId = value; }
        }

        private MemberCard memberCard;
        /// <summary>
        /// Gets or sets the member card
        /// </summary>
        /// <value>The member card</value>
        public MemberCard MemberCard
        {
            get { return memberCard; }
            set { memberCard = value; }
        }

        private MemberCardLevel memberCardLevel;
        /// <summary>
        /// Gets or sets the member card level
        /// </summary>
        /// <value>The member card level.</value>
        public MemberCardLevel MemberCardLevel
        {
            get { return memberCardLevel; }
            set { memberCardLevel = value; }
        }

        private IList<MemberCard> memberCardList;
        /// <summary>
        /// Gets or sets the member card list
        /// </summary>
        /// <value>The member card list</value>
        public IList<MemberCard> MemberCardList
        {
            get { return memberCardList; }
            set { memberCardList = value; }
        }

        private IList<MemberCard> memberCardPrintList;
        public IList<MemberCard> MemberCardPrintList 
        {
            set { memberCardPrintList = value; }
            get { return memberCardPrintList; }
        }

        private IList<MemberCardLevel> memberCardLevelList;
        /// <summary>
        /// Gets or sets the member card level list
        /// </summary>
        /// <value>The member card level list</value>
        public IList<MemberCardLevel> MemberCardLevelList
        {
            get { return memberCardLevelList; }
            set { memberCardLevelList = value; }
        }
        private IList<CustomerType> customerTypeList;
        /// <summary>
        /// Gets or sets the Customer Type
        /// </summary>
        /// <value>The Customer Type.</value>
        public IList<CustomerType> CustomerTypeList
        {
            get { return customerTypeList; }
            set { customerTypeList = value; }
        }
        private Customer customer;
        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        /// <value>The customer</value>
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private IList<MasterTrade> masterTradeList;
        /// <summary>
        /// Gets or sets the master Trade 
        /// </summary>
        /// <value>The Mater Trade</value>
        public IList<MasterTrade> MasterTradeList
        {
            get { return masterTradeList; }
            set { masterTradeList = value; }
        }

        private IList<SecondaryTrade> secondaryTradeList;
        /// <summary>
        /// Gets or sets the secondary Trade 
        /// </summary>
        /// <value>The secondary Trade</value>
        public IList<SecondaryTrade> SecondaryTradeList
        {
            get { return secondaryTradeList; }
            set { secondaryTradeList = value; }
        }

        /// <summary>
        /// 付款类型 付强
        /// </summary>
        private IList<LabelValue> paymentTypes;
        public IList<LabelValue> PaymentTypes
        {
            get { return paymentTypes; }
            set { paymentTypes = value; }
        }

        private IList<CustomerLevel> customerLevelList;
        /// <summary>
        /// Gets or sets the customer level 
        /// </summary>
        /// <value>The customr level</value>
        public IList<CustomerLevel> CustomerLevelList
        {
            get { return customerLevelList; }
            set { customerLevelList = value; }
        }

        private IList<Campaign> campaignList;
        /// <summary>
        /// Gets or sets the campaign
        /// </summary>
        /// <value>The campaign</value>
        public IList<Campaign> CampaignList
        {
            get { return campaignList; }
            set { campaignList = value; }
        }

        private IList<Concession> concessionList;
        /// <summary>
        /// Gets or sets the concession list
        /// </summary>
        /// <value>The concession list</value>
        public IList<Concession> ConcessionList
        {
            get { return concessionList; }
            set { concessionList = value; }
        }

        private IList<MemberCardConcession> memberCardConcessionList;
        public IList<MemberCardConcession> MemberCardConcessionList
        {
            get { return memberCardConcessionList; }
            set { memberCardConcessionList = value; }
        }

        private IList<MemberOperateLog> memberOperateLogList;
        public IList<MemberOperateLog> MemberOperateLogList
        {
            get { return memberOperateLogList; }
            set { memberOperateLogList = value; }
        }

        private IList<ChangeMemberCard> changeMemberCardList;
        public IList<ChangeMemberCard> ChangeMemberCardList
        {
            get { return changeMemberCardList; }
            set { changeMemberCardList = value; }
        }

        private IList<BaseBusinessTypePriceSet> baseBusinessTypePriceSetList;
        public IList<BaseBusinessTypePriceSet> BaseBusinessTypePriceSetList 
        {
            set { baseBusinessTypePriceSetList = value; }
            get { return baseBusinessTypePriceSetList; }
        }

        private BaseBusinessTypePriceSet baseBusinessTypePriceSet;
        public BaseBusinessTypePriceSet BaseBusinessTypePriceSet
        {
            set { baseBusinessTypePriceSet = value; }
            get { return baseBusinessTypePriceSet; }
        }

        private string campaignNames;
        //参加的营销活动
        public string CampaignNames
        {
            get { return campaignNames; }
            set { campaignNames = value; }
        }

        private string memberCardNo;
        /// <summary>
        /// Gets or sets the 卡号
        /// </summary>
        /// <value>The member card no</value>
        public string MemberCardNo
        {
            get { return memberCardNo; }
            set { memberCardNo = value; }
        }
        private MemberOperateLog memberOperateLog=new MemberOperateLog();
        public MemberOperateLog MemberOperateLog
        {
            set { memberOperateLog = value; }
            get { return memberOperateLog; }
        }

        private MemberCardConcession memberCardConcession;
        /// <summary>
        /// Gets or sets the member card concession
        /// </summary>
        /// <value>The member card concession</value>
        public MemberCardConcession MemberCardConcession
        {
            get { return memberCardConcession; }
            set { memberCardConcession = value; }
        }



        private ChangeMemberCard changeMemberCard;
        public ChangeMemberCard ChangeMemberCard
        {
            get { return changeMemberCard; }
            set { changeMemberCard = value; }
        }

        private long id;
        /// <summary>
        /// Gets or sets the member card id
        /// </summary>
        /// <value>The member card id</value>
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string customerName;
        /// <summary>
        /// Gets or sets the customer name
        /// </summary>
        /// <value>The customer name</value>
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        private string passWord;

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
        private string memberState;
        /// <summary>
        /// Gets or sets the 卡状态
        /// </summary>
        /// <value>The member state </value>
        public string MemberState
        {
            get { return memberState; }
            set { memberState = value; }
        }

        private string beginDate;
        /// <summary>
        /// Gets or sets from 注册时间
        /// </summary>
        /// <value>From enrol time.</value>
        public string BeginDate
        {
            get { return beginDate; }
            set { beginDate = value; }
        }

        private string endDate;
        /// <summary>
        /// Gets or sets to 注册时间
        /// </summary>
        /// <value>To enrol time.</value>
        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private string customerMemo;
        /// <summary>
        /// Gets or sets to 备注
        /// </summary>
        /// <value>To customer memo.</value>
        public string CustomerMemo
        {
            get { return customerMemo; }
            set { customerMemo = value; }
        }

        private long chargeSum;
        public long ChargeSum
        {
            get { return chargeSum; }
            set { chargeSum = value; }
        }

        private IList<ReportLessMode> reportLessModeList; /// <summary>
        /// Gets or sets the report less mode list
        /// </summary>
        /// <value>The report less mode list.</value>
        public IList<ReportLessMode> ReportLessModeList
        {
            get { return reportLessModeList; }
            set { reportLessModeList = value; }
        }

        private ReportLossMemberCard reportLossMemberCard;
        /// <summary>
        /// Gets or sets the report loss member card 
        /// </summary>
        /// <value>The report loss member card.</value>
        public ReportLossMemberCard ReportLossMemberCard
        {
            get { return reportLossMemberCard; }
            set { reportLossMemberCard = value; }
        }

        private LogoffMemberCard logoffMemberCard=new LogoffMemberCard();
        /// Gets or sets the logoff member card
        /// </summary>
        /// <value>The logoff member card.</value>
        public LogoffMemberCard LogoffMemberCard
        {
            get { return logoffMemberCard; }
            set { logoffMemberCard = value; }
        }

        private IList<Order> orderList;
        public IList<Order> OrderList 
        {
            set { orderList = value; }
            get { return orderList; }
        }
        private Order order;
        public Order Order 
        {
            set { order = value; }
            get { return order; }
        }

        private string balanceDateTimeString;
        public string BalanceDateTimeString
        {
            get { return balanceDateTimeString; }
            set { balanceDateTimeString = value; }
        }

        private string insertDateTimeString;
        public string InsertDateTimeString
        {
            get { return insertDateTimeString; }
            set { insertDateTimeString = value; }
        }

        private long memberCardConcessionRecordCount;
        public long MemberCardConcessionRecordCount 
        {
            set { memberCardConcessionRecordCount = value; }
            get { return memberCardConcessionRecordCount; }
        }

        private int currentPageIndex;
        public int CurrentPageIndex 
        {
            set { currentPageIndex = value; }
            get { return currentPageIndex; }
        }

        private int rowCount;
        public int RowCount 
        {
            set { rowCount = value; }
            get { return rowCount; }
        }

        private IList<ChangeMemberCard> changeMemberCardListPrint;
        public IList<ChangeMemberCard> ChangeMemberCardListPrint
        {
            set { changeMemberCardListPrint = value; }
            get { return changeMemberCardListPrint; }
        }

        private IList<Order> orderTempList;
        public IList<Order> OrderTempList 
        {
            set { orderTempList = value; }
            get { return orderTempList; }
        }

        private List<MemberCard.MemberCardBaseBusinessTypeItem> memberCardBaseBusinessTypeItemList;
        public List<MemberCard.MemberCardBaseBusinessTypeItem> MemberCardBaseBusinessTypeItemList 
        {
            set { memberCardBaseBusinessTypeItemList = value; }
            get { return memberCardBaseBusinessTypeItemList; }
		}
        private OtherGatheringAndRefundmentRecord otherGatheringAndRefundmentRecord;
        public OtherGatheringAndRefundmentRecord OtherGatheringAndRefundmentRecord 
        {
            set { otherGatheringAndRefundmentRecord = value; }
            get { return otherGatheringAndRefundmentRecord; }
        }

		#region 会员卡参加优惠活动的付款记录

		private MemberCardConcessionGathering memberCardConcessionGathering;
		/// <summary>
		/// 会员卡参加优惠活动的付款记录
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.14
		/// </remarks>
		public MemberCardConcessionGathering MemberCardConcessionGathering
		{
			get { return memberCardConcessionGathering; }
			set { memberCardConcessionGathering = value; }
		}

		#endregion

		#region 会员卡参加的打折优惠活动

		private MemberCardDiscountConcession memberCardDiscountConcession;
		/// <summary>
		/// 会员卡参加的打折优惠活动
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.14
		/// </remarks>
		public MemberCardDiscountConcession MemberCardDiscountConcession
		{
			get { return memberCardDiscountConcession; }
			set { memberCardDiscountConcession = value; }
		}

		#endregion
	}
}
