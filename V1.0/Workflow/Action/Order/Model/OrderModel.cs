using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Service.Impl;
using Workflow.Da.Domain;

namespace Workflow.Action.Model
{
    /// <summary>
    /// 付强
    /// </summary>
    public class OrderModel
    {
        public OrderModel()
        {         }
        /// <summary>
        /// 客户类型 付强
        /// </summary>
        private IList<CustomerType> customerTypes;
        public IList<CustomerType> CustomerTypes
        {
            get { return customerTypes; }
            set { customerTypes = value; }
        }
        /// <summary>
        /// 送货方式 付强
        /// </summary>
        private IList<LabelValue> devileryTypes;
        public IList<LabelValue> DevileryTypes
        {
            get { return devileryTypes; }
            set { devileryTypes = value; }
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

        /// <summary>
        /// 业务大类 付强
        /// </summary>
        private IList<BusinessType> businessType;
        public IList<BusinessType> BusinessType
        {
            get { return businessType; }
            set { businessType = value; }
        }
        /// <summary>
        ///价格因素 付强
        /// </summary>
    
        private IList<PriceFactor> priceFactor;
        public IList<PriceFactor> PriceFactor
        {
            get { return priceFactor; }
            set { priceFactor = value; }
        }
        /// <summary>
        /// 印制要求 付强
        /// </summary>
        private IList<PrintDemand> printDemandList=new List<PrintDemand>();
        public IList<PrintDemand> PrintDemandList
        {
            get { return printDemandList; }
            set { printDemandList = value; }
        }

        /// <summary>
        /// 工单列表 付强
        /// </summary>
        private IList<Order> dailyOrder;
        public IList<Order> DailyOrder
        {
            get { return dailyOrder; }
            set { dailyOrder = value; }
        }

        private BaseBusinessTypePriceSet baseBusinessTypePriceSet;
        public BaseBusinessTypePriceSet BaseBusinessTypePriceSet
        {
            get { return baseBusinessTypePriceSet; }
            set { baseBusinessTypePriceSet = value; }
        }

        private BusinessTypePriceSet businessTypePriceSet;
        public BusinessTypePriceSet BusinessTypePriceSet
        {
            get { return businessTypePriceSet; }
            set { businessTypePriceSet = value; }
        }

        private IList<Workflow.Da.Domain.Employee> employeeList;
        public IList<Workflow.Da.Domain.Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; }
        }
        private IList<OrderItemEmployee> orderItemEmployee=new List<OrderItemEmployee>();
        public IList<OrderItemEmployee> OrderItemEmployee
        {
            get { return orderItemEmployee; }
            set { orderItemEmployee = value; }
        }
        private IList<OrderItem> orderItemList = new List<OrderItem>();
        public IList<OrderItem> OrderItemList
        {
            get { return orderItemList; }
            set { orderItemList = value; }
        }
        private IList<OrderItem> orderItem;
        public IList<OrderItem> OrderItem
        {
            get { return orderItem; }
            set { orderItem = value; }
        }
        private IList<TrashReason> trashReason;
        public IList<TrashReason> TrashReason
        {
            get { return trashReason; }
            set { trashReason = value; }
        }
        private IList<TrashPaperEmployee> trashPaperEmployeeList=new List<TrashPaperEmployee>();
        public IList<TrashPaperEmployee> TrashPaperEmployeeList
        {
            get { return trashPaperEmployeeList; }
            set { trashPaperEmployeeList = value; }
        }
        private IList<RealOrderItem> realOrderItem;
        public IList<RealOrderItem> RealOrderItem
        {
            get { return realOrderItem; }
            set { realOrderItem = value; }

        }
        private IList<RealOrderItem> realOrderItemList;
        public IList<RealOrderItem> RealOrderItemList
        {
            get { return realOrderItemList; }
            set { realOrderItemList = value; }
        }

        private Gathering gathering;
        public Gathering Gathering
        {
            get { return gathering; }
            set { gathering = value; }
        }

        private GatheringOrder gatheringOrder;
        public GatheringOrder GatheringOrder
        {
            get { return gatheringOrder; }
            set { gatheringOrder = value; }
        }

        private IList<RealOrderItemTrashReason> realOrderItemTrashReason=new List<RealOrderItemTrashReason>();
        public IList<RealOrderItemTrashReason> RealOrderItemTrashReason
        {
            get { return realOrderItemTrashReason; }
            set { realOrderItemTrashReason = value; }
        }

        private IList<RealOrderItemPrintRequire> realOrderItemPrintRequire;
        public IList<RealOrderItemPrintRequire> RealOrderItemPrintRequire
        {
            get { return realOrderItemPrintRequire; }
            set { realOrderItemPrintRequire = value; }
        }


        private IList<OrderItemPrintRequireDetail> orderItemPrintRequireDetail;
        public IList<OrderItemPrintRequireDetail> OrderItemPrintRequireDetail
        {
            get { return orderItemPrintRequireDetail; }
            set { orderItemPrintRequireDetail = value; }
        }

        private IList<RealOrderItemEmployee> realOrderItemEmployeeList;
        public IList<RealOrderItemEmployee> RealOrderItemEmployeeList
        {
            get { return realOrderItemEmployeeList; }
            set { realOrderItemEmployeeList = value; }
        }

        private IList<OrderItemEmployee> orderItemEmployeeList;
        public IList<OrderItemEmployee> OrderItemEmployeeList
        {
            get { return orderItemEmployeeList; }
            set { orderItemEmployeeList = value; }
        }

        private MemberCardConcession memberCardConcession;
        public MemberCardConcession MemberCardConcession
        {
            get { return memberCardConcession; }
            set { memberCardConcession = value; }
        }
        private IList<MemberCardConcession> memberCardConcessionList;
        public IList<MemberCardConcession> MemberCardConcessionList
        {
            get { return memberCardConcessionList; }
            set { memberCardConcessionList = value; }
        }
        private MemberCard memberCard=new MemberCard();
        public MemberCard MemberCard
        {
            get { return memberCard; }
            set { memberCard = value; }
        }
        private string bijiao;
        public  string  BiJiao
         {
             get { return bijiao; }
             set { bijiao = value; }
        }
        private ProcessContent processContent;
        public ProcessContent ProcessContent
        {
            get { return processContent; }
            set { processContent = value; }
        }
        /// <summary>
        /// 增加一个新工单  付强
        /// </summary>

        private Order newOrder=new Order();
        public Order NewOrder
        {
            get { return newOrder; }
            set { newOrder = value; }
        }

        private IList<FactorRelation> factorRelation;
        public IList<FactorRelation> FactorRelation
        {
            get { return factorRelation; }
            set { factorRelation = value; }
        }

        private FactorRelation factorrelation;
        public FactorRelation Factorrelation
        {
            get { return factorrelation; }
            set { factorrelation = value; }
        }

        private IList<FactorRelationValue> factorRelationValue;
        public IList<FactorRelationValue> FactorRelationValue
        {
            get { return factorRelationValue; }
            set { factorRelationValue = value; }
        }

        private IList<FactorValue> factorValue;
        public IList<FactorValue> FactorValue
        {
            get { return factorValue; }
            set { factorValue = value; }
        }
        private OrdersStatusAlter orderStatusAlter;
        public OrdersStatusAlter OrderStatusAlter
        {
            get { return orderStatusAlter; }
            set { orderStatusAlter = value; }
        }

        private IList<PaymentConcession> paymentConcessionList;
        public IList<PaymentConcession> PaymentConcessionList
        {
            get { return paymentConcessionList; }
            set { paymentConcessionList = value; }
        }

        private IList<RelationEmployee> relationEmployeeList=new List<RelationEmployee>();
        public IList<RelationEmployee> RelationEmployeeList
        {
            get { return relationEmployeeList; }
            set { relationEmployeeList = value; }
        }
        private OrdersDuty ordersDuty;
        public OrdersDuty OrdersDuty
        {
            get { return ordersDuty; }
            set { ordersDuty = value; }
        }
        private IList<DutyEmployee> dutyEmployeeList=new List<DutyEmployee>();
        public IList<DutyEmployee> DutyEmployeeList
        {
            get { return dutyEmployeeList; }
            set { dutyEmployeeList = value; }
        }

        //private int orderItemCount;
        //public int OrderItemCount
        //{
        //    //get { return orderItemCount; }
        //    set { orderItemCount = value; }
        //}
        private IList<OrderItemPrintRequireDetail> orderItemPrintRequireDetailList;//=new List<OrderItemPrintRequireDetail>();
        public IList<OrderItemPrintRequireDetail> OrderItemPrintRequireDetailList
        {
            get { return orderItemPrintRequireDetailList; }
            set { orderItemPrintRequireDetailList = value; }
        }
        private IList<DeliveryOrder> deliveryOrderList=new List<DeliveryOrder>();
        public IList<DeliveryOrder> DeliveryOrderList
        {
            get { return deliveryOrderList; }
            set { deliveryOrderList = value; }
        }
        private IList<OrderItemFactorValue> orderItemFactorValueList;
        public IList<OrderItemFactorValue> OrderItemFactorValueList
        {
            get { return orderItemFactorValueList; }
            set { orderItemFactorValueList = value; }
        }
        private LinkMan linkMan;
        public LinkMan LinkMan
        {
            get { return linkMan; }
            set { linkMan = value; }
        }
        private Customer customer;
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }


        private string beginDate;
        //查询开始时间        刘伟
        public string BeginDate
        {
            get { return beginDate; }
            set { beginDate = value; }
        }

        private string endDate;
        //查询结束时间        刘伟
        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int selectCondition;
        //查询大小条件         刘伟
        public int SelectCondition
        {
            get { return selectCondition; }
            set { selectCondition = value; }
        }
        private string comporeCondition;
        public string ComporeCondition
        {
            get { return comporeCondition; }
            set { comporeCondition = value; }
        }

        private int memberCardBrushNumber;
        //计算会员卡刷卡次数  刘伟
        public int MemberCardBrushNumber
        {
            get { return memberCardBrushNumber; }
            set { memberCardBrushNumber = value; }
        }

        private IList<Order> orderList;
        public IList<Order> OrderList
        {
            get { return orderList; }
            set { orderList = value; }
        }

        private long needPrePayOrdersCount;
        public long NeedPrePayOrdersCount
        {
            get
            {
                return needPrePayOrdersCount;
            }
            set
            {
                needPrePayOrdersCount = value;
            }
        }
		private IList<Order> orderTempList;
		public IList<Order> OrderTempList 
		{
			set { orderTempList = value; }
			get { return orderTempList; }
		}

        private IList<LabelValue> operatorList;
        public IList<LabelValue> OperatorList
        {
            get { return operatorList; }
            set { operatorList = value; }
        }

        private IList<AmountSegment> amountSegmentList;
        public IList<AmountSegment> AmountSegmentList
        {
            get { return amountSegmentList; }
            set { amountSegmentList = value; }
        }

        //Author:Cry Date 2008-12-26
        private string customerName;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        private IList<User> userList;
        public IList<User> UserList
        {
            get { return userList; }
            set { userList = value; }
        }

        private decimal cashTotal;
        public decimal CashTotal 
        {
            set { cashTotal = value; }
            get { return cashTotal; }
        }

        private decimal oweTotal;
        public decimal OweTotal 
        {
            set { oweTotal = value; }
            get { return oweTotal; }
        }

        private decimal ticketTotal;
        public decimal TicketTotal 
        {
            set { ticketTotal = value; }
            get { return ticketTotal; }
        }

        private long customerPayType;
        public long CustomerPayType 
        {
            set { customerPayType = value; }
            get { return customerPayType; }
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
    }
}
