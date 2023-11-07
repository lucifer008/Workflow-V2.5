using System;
using Workflow.Da.Domain.Base;
using System.Collections.Generic;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table PAYMENT_CONCESSION��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class PaymentConcession : PaymentConcessionBase
	{
		public PaymentConcession()
		{
		}
        private string orderNo;
        public string OrderNo 
        {
            set { orderNo = value; }
            get { return orderNo; }
        }

        private decimal concessionAmountTotal;
        /// <summary>
        /// �Żݽ��ϼ�
        /// </summary>
        public decimal ConcessionAmountTotal 
        {
            set { concessionAmountTotal = value; }
            get { return concessionAmountTotal; }
        }

        private decimal moreConcessionAmountTotal;
        /// <summary>
        /// ���ս��ϼ�(������ս��)
        /// </summary>
        public decimal MoreConcessionAmountTotal 
        {
            set { moreConcessionAmountTotal = value; }
            get { return moreConcessionAmountTotal; }
        }

        private string payTypeBalance;
        /// <summary>
        /// �����
        /// </summary>
        public string PayTypeBalance 
        {
            set { payTypeBalance = value; }
            get { return payTypeBalance; }
        }

        private string payTypePreDiff;
        /// <summary>
        /// Ԥ�տ���
        /// </summary>
        public string PayTypePreDiff 
        {
            set { payTypePreDiff = value; }
            get { return payTypePreDiff; }
        }

        private string payTypeMemberCardDiff;
        /// <summary>
        /// ��Ա�����
        /// </summary>
        public string PayTypeMemberCardDiff 
        {
            set { payTypeMemberCardDiff = value; }
            get { return payTypeMemberCardDiff; }
        }

        private string payTypeOwe;
        /// <summary>
        /// Ӧ�տ����
        /// </summary>
        public string PayTypeOwe 
        {
            set { payTypeOwe = value; }
            get { return payTypeOwe; }
        }

        /// <summary>
        /// �ͻ�Ԥ�����
        /// </summary>
        private string accountPreDepositsDiff;
        /// <summary>
        /// �ͻ�Ԥ�����
        /// </summary>
        public string AccountPreDepositsDiff 
        {
            set { accountPreDepositsDiff = value; }
            get { return accountPreDepositsDiff; }
        }
        /// <summary>
        /// �ͻ�Ԥ�����
        /// </summary>
        private string preDepositsDiff;
        /// <summary>
        /// �ͻ�Ԥ�����
        /// </summary>
        public string PreDepositsDiff
        {
            set { preDepositsDiff = value; }
            get { return preDepositsDiff; }
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

        private string beginDateTimeString;
        public string BeiginDateTimeString 
        {
            set { beginDateTimeString = value; }
            get { return beginDateTimeString; }
        }

        private string endDateTimeString;
        public string EndDateTimeString
        {
            set { endDateTimeString = value; }
            get { return endDateTimeString; }
        }

		private Order order;
		public Order Order
		{
			get { return order; }
			set { order = value; }
		}

		private long operateUsersId;
		public long OperateUsersId
		{
			get { return operateUsersId; }
			set { operateUsersId = value; }
		}

		private int orderCount;
		public int OrderCount
		{
			get { return orderCount; }
			set { orderCount = value; }
		}

		private decimal sumAmountTotal;
		public decimal SumAmountTotal
		{
			get { return sumAmountTotal; }
			set { sumAmountTotal = value; }
		}

		private decimal realAmountTotal;
		public decimal RealAmountTotal
		{
			get { return realAmountTotal; }
			set { realAmountTotal = value; }
		}

		private IList<long> operateUserIdList;
		/// <summary>
		/// 
		/// </summary>
		public IList<long> OperateUserIdList
		{
			get { return operateUserIdList; }
			set { operateUserIdList = value; }
		}
	}
}
