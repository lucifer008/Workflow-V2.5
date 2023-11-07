using System;
using Workflow.Da.Domain.Base;
using System.Collections.Generic;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table PAYMENT_CONCESSION对应的DotNet Object
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
        /// 优惠金额合计
        /// </summary>
        public decimal ConcessionAmountTotal 
        {
            set { concessionAmountTotal = value; }
            get { return concessionAmountTotal; }
        }

        private decimal moreConcessionAmountTotal;
        /// <summary>
        /// 多收金额合计(舍入多收金额)
        /// </summary>
        public decimal MoreConcessionAmountTotal 
        {
            set { moreConcessionAmountTotal = value; }
            get { return moreConcessionAmountTotal; }
        }

        private string payTypeBalance;
        /// <summary>
        /// 结算款
        /// </summary>
        public string PayTypeBalance 
        {
            set { payTypeBalance = value; }
            get { return payTypeBalance; }
        }

        private string payTypePreDiff;
        /// <summary>
        /// 预收款冲减
        /// </summary>
        public string PayTypePreDiff 
        {
            set { payTypePreDiff = value; }
            get { return payTypePreDiff; }
        }

        private string payTypeMemberCardDiff;
        /// <summary>
        /// 会员卡冲减
        /// </summary>
        public string PayTypeMemberCardDiff 
        {
            set { payTypeMemberCardDiff = value; }
            get { return payTypeMemberCardDiff; }
        }

        private string payTypeOwe;
        /// <summary>
        /// 应收款处理冲减
        /// </summary>
        public string PayTypeOwe 
        {
            set { payTypeOwe = value; }
            get { return payTypeOwe; }
        }

        /// <summary>
        /// 客户预存款冲减
        /// </summary>
        private string accountPreDepositsDiff;
        /// <summary>
        /// 客户预存款冲减
        /// </summary>
        public string AccountPreDepositsDiff 
        {
            set { accountPreDepositsDiff = value; }
            get { return accountPreDepositsDiff; }
        }
        /// <summary>
        /// 客户预存款冲减
        /// </summary>
        private string preDepositsDiff;
        /// <summary>
        /// 客户预存款冲减
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
