using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table GATHERING对应的DotNet Object
	/// </summary>
	[Serializable]
	public class Gathering : GatheringBase
	{
		public Gathering()
		{
		}
        //private decimal amount;
        //public decimal Amount
        //{
        //    set { amount = value; }
        //    get { return amount; }
        //}
        //private DateTime gatheringDateTime;
        //public DateTime GatheringDateTime
        //{
        //    set { gatheringDateTime = value; }
        //    get { return gatheringDateTime; }
        //}
        private string userName;
        public string UserName
        {
            set { userName = value; }
            get { return userName; }
        }
        private decimal arrearage;
        public decimal Arrearage
        {
            set { arrearage = value; }
            get { return arrearage; }
        }
        private string memo;
        public string Memo
        {
            set { memo = value; }
            get { return memo; }
        }

		private string payKind;
		/// <summary>
		/// 付款类型
		/// </summary>
		public string PayKind
		{
			get { return payKind; }
			set { payKind = value; }
		}

		private string orderNo;
		/// <summary>
		/// 订单号
		/// </summary>
		public string OrderNo
		{
			get { return orderNo; }
			set { orderNo = value; }
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
        private Order order;
        public Order Order 
        {
            set { order = value; }
            get { return order; }
        }
	}

}


