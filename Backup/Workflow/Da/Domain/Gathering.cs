using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table GATHERING��Ӧ��DotNet Object
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
		/// ��������
		/// </summary>
		public string PayKind
		{
			get { return payKind; }
			set { payKind = value; }
		}

		private string orderNo;
		/// <summary>
		/// ������
		/// </summary>
		public string OrderNo
		{
			get { return orderNo; }
			set { orderNo = value; }
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
        private Order order;
        public Order Order 
        {
            set { order = value; }
            get { return order; }
        }
	}

}


