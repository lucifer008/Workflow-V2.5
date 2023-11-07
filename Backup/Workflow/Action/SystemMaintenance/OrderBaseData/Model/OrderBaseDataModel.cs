using System;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Action.SystemMaintenance.OrderBaseData.Model
{
    /// <summary>
    /// ��   ��:  OrderBaseDataModel
    /// ���ܸ�Ҫ: �����������ݹ���Model
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��29��17:02:07
    /// ��������:
    /// ����ʱ��:
    /// </summary>
    public class OrderBaseDataModel
    {
        private long rowCount;
        public long RowCount 
        {
            set { rowCount = value; }
            get { return rowCount; }
        }

        private CustomerLevel customerLevel=new CustomerLevel();
        public CustomerLevel CustomerLevel 
        {
            set { customerLevel = value; }
            get { return customerLevel; }
        }

        private IList<CustomerLevel> customerLevelList;
        public IList<CustomerLevel> CustomerLevelList 
        {
            set { customerLevelList = value; }
            get { return customerLevelList; }
        }

        private CustomerType customerType = new CustomerType();
        public CustomerType CustomerType
        {
            set { customerType = value; }
            get { return customerType; }
        }

        private IList<CustomerType> customerTypeList;
        public IList<CustomerType> CustomerTypeList
        {
            set { customerTypeList = value; }
            get { return customerTypeList; }
        }

        private SecondaryTrade secondaryTrade=new SecondaryTrade();
        public SecondaryTrade SecondaryTrade 
        {
            set { secondaryTrade = value; }
            get { return secondaryTrade; }
        }

        private IList<SecondaryTrade> secondaryTradeList;
        public IList<SecondaryTrade> SecondaryTradeList 
        {
            set { secondaryTradeList = value; }
            get { return secondaryTradeList; }
        }

        private MasterTrade masterTrade=new MasterTrade();
        public MasterTrade MasterTrade 
        {
            set { masterTrade = value; }
            get { return masterTrade; }
        }
        private IList<MasterTrade> masterTradeList;
        public IList<MasterTrade> MasterTradeList 
        {
            set { masterTradeList = value; }
            get { return masterTradeList; }
        }

        private MemberCardLevel memberCardLevel = new MemberCardLevel();
        public MemberCardLevel MemberCardLevel 
        {
            set { memberCardLevel = value; }
            get{return memberCardLevel;}
        }
        private IList<MemberCardLevel> memberCardLevelList;
        public IList<MemberCardLevel> MemberCardLevelList 
        {
            set { memberCardLevelList = value; }
            get { return memberCardLevelList; }
        }

        private PrintDemand printDemand = new PrintDemand();
        public PrintDemand PrintDemand 
        {
            set { printDemand = value; }
            get { return printDemand; }
        }

        private IList<PrintDemand> printDemandList;
        public IList<PrintDemand> PrintDemandList 
        {
            set { printDemandList = value; }
            get { return printDemandList; }
        }

        private PrintDemandDetail printDemandDetail = new PrintDemandDetail();
        public PrintDemandDetail PrintDemandDetail 
        {
            set { printDemandDetail = value; }
            get { return printDemandDetail; }
        }

        private IList<PrintDemandDetail> printDemandDetailList;
        public IList<PrintDemandDetail> PrintDemandDetailList 
        {
            set { printDemandDetailList = value; }
            get { return printDemandDetailList; }
        }

        private ReportLessMode reportLessMode=new ReportLessMode();
        public ReportLessMode ReportLessMode 
        {
            set { reportLessMode = value; }
            get { return reportLessMode; }
        }

        private IList<ReportLessMode> reportLessModeList;
        public IList<ReportLessMode> ReportLessModeList 
        {
            set { reportLessModeList = value; }
            get { return reportLessModeList; }
        }

        private TrashReason trashReason=new TrashReason();
        public TrashReason TrashReason 
        {
            set { trashReason = value; }
            get { return trashReason; }
        }

        private IList<TrashReason> trashReasonList;
        public IList<TrashReason> TrashReasonList 
        {
            set { trashReasonList = value; }
            get { return trashReasonList; }
        }
        private IList<ProcessContent> processContentList;
        public IList<ProcessContent> ProcessContentList 
        {
            set { processContentList = value; }
            get { return processContentList; }
        }

        private ProcessContentAchievementRate processContentAchievementRate = new ProcessContentAchievementRate();
        public ProcessContentAchievementRate ProcessContentAchievementRate 
        {
            set { processContentAchievementRate = value; }
            get { return processContentAchievementRate; }
        }

        private IList<ProcessContentAchievementRate> processContentAchievementRateList;
        public IList<ProcessContentAchievementRate> ProcessContentAchievementRateList 
        {
            set { processContentAchievementRateList = value; }
            get { return processContentAchievementRateList; }
        }
    }
}
