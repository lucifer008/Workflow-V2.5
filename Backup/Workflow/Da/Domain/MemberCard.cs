using System;
using Workflow.Da.Domain.Base;
using System.Collections.Generic;
namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MEMBER_CARD��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class MemberCard : MemberCardBase
	{
		public MemberCard()
		{
		}

        private string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        private string customerMemo;
        public string CustomerMemo
        {
            get { return customerMemo; }
            set { customerMemo = value; }
        }
        //private long customerId;
        //public long CustomerId
        //{
        //    get { return customerId; }
        //    set { customerId = value; }
        //}
        private long tradeId;
        public long TradeId
        {
            get { return tradeId; }
            set { tradeId = value; }
        }
        private long customerTypeId;
        public long CustomerTypeId
        {
            get { return customerTypeId; }
            set { customerTypeId = value; }
        }
        private string linkManName;
        public string LinkManName
        {
            get { return linkManName; }
            set { linkManName = value; }
        }
        private string telNo;
        public string TelNo
        {
            get { return telNo; }
            set { telNo = value; }
        }
        //private string needTicket;
        //public string NeedTicket
        //{
        //    get { return needTicket; }
        //    set { needTicket = value; }
        //}
        private int payType;
        public int PayType
        {
            get { return payType; }
            set { payType = value; }
        }
        private string customerAddress;
        /// <summary>
        /// �ͻ�ͨѶ��ַ
        /// </summary>
        public string CustomerAddress
        {
            set { customerAddress = value; }
            get { return customerAddress; }
        }

        private string lastLinkMan;
        public string LastLinkMan
        {
            set { lastLinkMan = value; }
            get { return lastLinkMan; }
        }

        private string lastTelNo;
        public string LastTelNo
        {
            set { lastTelNo = value; }
            get { return lastTelNo; }
        }

        private string customerNameSimple;
        public string CustomerNameSimple 
        {
            set { customerNameSimple = value; }
            get { return customerNameSimple; }
        }

        private int membercardLevelId;
        public int MemberCardLevelId 
        {
            set { membercardLevelId = value; }
            get { return membercardLevelId; }
        }

        private string memo;
        public string Memo 
        {
            set { memo = value; }
            get { return memo; }
        }

        private string membercardBeginDateString;
        public string MemberCardBeginDateString 
        {
            set { membercardBeginDateString = value; }
            get {return membercardBeginDateString; }
        }

        private string membercardEndDateString;
        public string MemberCardEndDateString
        {
            set { membercardEndDateString = value; }
            get { return membercardEndDateString; }
        }

        private string customerValidateStatus;
        public string CustomerValidateStatus 
        {
            set { customerValidateStatus = value; }
            get { return customerValidateStatus; }
        }

        private int customerLevelId;
        public int CustomerLevelId 
        {
            set { customerLevelId = value; }
            get { return customerLevelId; }
        }

        private Customer customer;
        public Customer Customer 
        {
            set { customer = value; }
            get { return customer; }
        }

        private long memberOperateLogId;
        public long MemberOperateLogId 
        {
            set { memberOperateLogId = value; }
            get { return memberOperateLogId; }
        }

        private long opterateType;
        public long OperateType 
        {
            set { opterateType = value; }
            get { return opterateType; }
        }

        private string insertUserName;
        public string InsertUserName 
        {
            set { insertUserName = value; }
            get { return insertUserName; }
        }

        /// <summary>
        /// ��    ��:MemberCardBaseBusinessTypeItem
        /// ���ܸ�Ҫ:��Ա�������ҵ����ϸ��
        /// ��    ��:������
        /// ����ʱ��:2009��4��16��10:13:45
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public class MemberCardBaseBusinessTypeItem 
        {
            private long memberCardId;
            public long MemberCardId 
            {
                set { memberCardId = value; }
                get { return memberCardId; }
            }

            private decimal baseBusAmount;
            public decimal BaseBusAmount
            {
                set { baseBusAmount = value; }
                get { return baseBusAmount; }
            }

            private decimal baseBusUnitPrice;
            public decimal BaseBusUnitPrice 
            {
                set { baseBusUnitPrice = value; }
                get { return baseBusUnitPrice; }
            }

            private long orderId;
            public long OrderId 
            {
                set { orderId = value; }
                get { return orderId; }
            }

            private List<string> pactorValueList;
            public List<string> PactorValueList 
            {
                set { pactorValueList = value; }
                get { return pactorValueList; }
            }

            private long companyId;
            public long CompanyId 
            {
                set { companyId = value; }
                get { return companyId; }
            }

            private long branchShopId;
            public long BranchShopId 
            {
                set { branchShopId = value; }
                get { return branchShopId; }
            }
        }
	}
}
