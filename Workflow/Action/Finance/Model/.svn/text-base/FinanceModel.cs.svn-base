using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Action.Finance.Model
{
    /// <summary>
    /// 名    称: FinanceModel
    /// 功能概要: 财务处理的Model
    /// 作    者: 张晓林
    /// 创建时间: 2009-02-04
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class FinanceModel
    {
        public FinanceModel()
        {}
        private Order orders;
        public Order Orders
        {
            set { orders = value; }
            get { return orders; }
        }
        private IList<OrderItem> orderItemList;
        public IList<OrderItem> OrderItemList
        {
            set { orderItemList = value; }
            get { return orderItemList; }
        }

        private Gathering gatherings;
        public Gathering Gatherings
        {
            set { gatherings = value; }
            get{return gatherings;}
        }
        private IList<Gathering> gatheringList;
        public IList<Gathering> GatheringList
        {
            get { return gatheringList; }
            set { gatheringList = value; }
        }
        private GatheringOrder gatheringOrders;
        public GatheringOrder GatheringOrders
        {
            set { gatheringOrders = value; }
            get { return gatheringOrders; }
        }

        private IList<GatheringAndGatheringOrder> gatheringAndGatheringOrder= new List<GatheringAndGatheringOrder>();
        public IList<GatheringAndGatheringOrder> GatheringAndGatheringOrder
        {
            get
            {
                return gatheringAndGatheringOrder;
            }
            set
            {
                gatheringAndGatheringOrder=value;
            }
        }

        private IList<GatheringOrder> gatheringOrderList = new List<GatheringOrder>();
        public IList<GatheringOrder> GatheringOrderList
        {
            set { gatheringOrderList = value; }
            get { return gatheringOrderList; }
        }
        private OrdersStatusAlter orderStatusAlter;
        public OrdersStatusAlter OrderStatusAlter
        {
            set { orderStatusAlter = value; }
            get { return orderStatusAlter; }
        }
        private RelationEmployee relationEmployee;
        public RelationEmployee RelationEmployee
        {
            set { relationEmployee = value; }
            get { return relationEmployee; }
        }
        private IList<Order> orderList;
        public IList<Order> OrderList
        {
            set { orderList = value; }
            get { return orderList; }
        }
        private IList<Order> orderPrintList;
        public IList<Order> OrderPrintList
        {
            set { orderPrintList = value; }
            get { return orderPrintList; }
        }
        private IList<PaymentConcession> paymentConcessionList = new List<PaymentConcession>();
        public IList<PaymentConcession> PaymentConcessionList
        {
            set { paymentConcessionList = value; }
            get { return paymentConcessionList; }
        }
        private IList<OrdersForRecordMachineSum> ordersForRecordMachineSumList;
        public IList<OrdersForRecordMachineSum> OrdersForRecordMachineSumList
        {
            get { return ordersForRecordMachineSumList; }
            set { ordersForRecordMachineSumList = value; }
        }

        private RequireAccountingInfo requireAccountingInfo;
        /// <summary>
        /// 挂账信息
        /// </summary>
        public RequireAccountingInfo RequireAccountingInfo
        {
            get { return requireAccountingInfo; }
            set { requireAccountingInfo = value; }            
        }
        private int unClosedOrderCount;
        public int UnClosedOrderCount
        {
            get { return unClosedOrderCount; }
            set { unClosedOrderCount = value; }
        }

        private IList<OrderItemEmployee> orderItemEmployeeList;
        public IList<OrderItemEmployee> OrderItemEmployeeList
        {
            get { return orderItemEmployeeList; }
            set { orderItemEmployeeList = value; }
        }

		#region 活动信息

		private string campaignData;
		/// <summary>
		/// 活动信息
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-5-26
		/// </remarks>
		public string CampaignData
		{
			get { return campaignData; }
			set { campaignData = value; }
		}

		#endregion

		#region 会员卡订单明细冲减记录
		//MEMBER_CARD_ORDER_ITEM_COUNTERACT_LOG
		private IList<MemberCardOrderItemCounteractLog> memberCardOrderItemCounteractLogList;
		/// <summary>
		/// 会员卡订单明细冲减记录
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-5-26
		/// </remarks>
		public IList<MemberCardOrderItemCounteractLog> MemberCardOrderItemCounteractLogList
		{
			get { return memberCardOrderItemCounteractLogList; }
			set { memberCardOrderItemCounteractLogList = value; }
		}

		#endregion

        /// <summary>
        /// 客户预存款
        /// </summary>
        private decimal customerPreDeposits;
        /// <summary>
        /// 客户预存款
        /// </summary>
        public decimal CustomerPreDeposits 
        {
            set { customerPreDeposits = value; }
            get { return customerPreDeposits; }
        }
        /// <summary>
        /// 消费客户的预存款
        /// </summary>
        private decimal preDeposits;
        /// <summary>
        /// 消费客户的预存款
        /// </summary>
        public decimal PreDeposits
        {
            set { preDeposits = value; }
            get { return preDeposits; }
        }

        /// <summary>
        /// 是否使预存款
        /// </summary>
        private bool isUsePreDeposits;
        /// <summary>
        ///是否使用预存款
        /// </summary>
        public bool IsUsePreDeposits 
        {
            set { isUsePreDeposits = value; }
            get { return isUsePreDeposits; }
        }

        /// <summary>
        /// 是否使用预收款
        /// </summary>
        private bool isUsePreAmount;
        /// <summary>
        /// 是否使用预收款
        /// </summary>
        public bool IsUsePreAmount 
        {
            set { isUsePreAmount = value; }
            get { return isUsePreAmount; }
        }
        /// <summary>
        /// 是否记账
        /// </summary>
        private bool isAccounting;
        /// <summary>
        /// 是否记账
        /// </summary>
        public bool IsAccounting 
        {
            set { isAccounting = value; }
            get { return isAccounting; }
        }
        private long customerId;
        public long CustomerId 
        {
            set { customerId = value; }
            get { return customerId; }
        }

        private string customerName;
        public string CustomerName
        {
            set { customerName = value; }
            get { return customerName; }
        }

        /// <summary>
        /// 实际付款金额
        /// </summary>
        private decimal paidAmount;
        /// <summary>
        /// 实际付款金额
        /// </summary>
        public decimal PaidAmount
        {
            set { paidAmount = value; }
            get { return paidAmount; }
        }

        /// <summary>
        /// 客户支付方式
        /// </summary>
        private long customerPayType;
        /// <summary>
        /// 客户支付方式
        /// </summary>
        public long CustomerPayType
        {
            set { customerPayType = value; }
            get { return customerPayType; }
        }

        private OtherGatheringAndRefundmentRecord otherGatheringAndRefundmentRecord;
        public OtherGatheringAndRefundmentRecord OtherGatheringAndRefundmentRecord 
        {
            set { otherGatheringAndRefundmentRecord = value; }
            get { return otherGatheringAndRefundmentRecord; }
        }
        private IList<OtherGatheringAndRefundmentRecord> otherGatheringAndRefundmentRecordList;
        public IList<OtherGatheringAndRefundmentRecord> OtherGatheringAndRefundmentRecordList
        {
            set { otherGatheringAndRefundmentRecordList = value; }
            get { return otherGatheringAndRefundmentRecordList; }
        }
        private IList<string> diffArrOrderList;
        public IList<string> DiffArrOrderList 
        {
            set { diffArrOrderList = value; }
            get { return diffArrOrderList; }
        }

        private bool isPaidTicket;
        public bool IsPaidTicket 
        {
            set { isPaidTicket = value; }
            get { return isPaidTicket; }
        }
        private OtherGatheringAndRefundmentRecord otherGatheringAndRefundmentRecordPaidTicketRecord;
        public OtherGatheringAndRefundmentRecord OtherGatheringAndRefundmentRecordPaidTicketRecord
        {
            set { otherGatheringAndRefundmentRecordPaidTicketRecord = value; }
            get { return otherGatheringAndRefundmentRecordPaidTicketRecord; }
        }

		#region 会员卡

		private long memberCardId;
		/// <summary>
		/// 会员卡
		/// </summary>
		public long MemberCardId
		{
			get { return memberCardId; }
			set { memberCardId = value; }
		}

		#endregion


    }

    public class GatheringAndGatheringOrder
    {
        private IList<Gathering> gatheringList;
        public IList<Gathering> GatheringList
        {
            set { gatheringList = value; }
            get { return gatheringList; }
        }
        private IList<GatheringOrder> gatheringOrderList;
        public IList<GatheringOrder> GatheringOrderList
        {
            set { gatheringOrderList = value; }
            get { return gatheringOrderList; }
        }


    }
}
