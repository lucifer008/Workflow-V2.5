using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action;
namespace Workflow.Action.Finance.Model
{
    /// <summary>
    /// 名    称: FindFinanceModel
    /// 功能概要: 财务处理查询的Model
    /// 作    者: 张晓林
    /// 创建时间: 2009-02-04
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class FindFinanceModel
    {
        public FindFinanceModel() { }
        private IList<Order> orderList=new List<Order> ();
        public IList<Order> OrderList
        {
            set { orderList = value; }
            get { return orderList; }
        }
        private Order order;
        public Order Order
        {
            set { order=value; }
            get { return order; }
        }

		private IList<Order> printOrderList = new List<Order>();
		public IList<Order> PrintOrderList
		{
			set { printOrderList = value; }
			get { return printOrderList; }
		}

        private Order newOrder=new Order();
        public Order NewOrder 
        {
            set { newOrder = value; }
            get { return newOrder; }
        }
        private IList<Order> orderTempList;
        public IList<Order> OrderTempList 
        {
            set { orderTempList = value; }
            get { return orderTempList; }
        }

        private IList<Order> oList=new List<Order>();
        public IList<Order> OList
        {
            set { oList = value; }
            get { return oList; }
        }

        private IList<Workflow.Da.Domain.Employee> employeeList;
        public IList<Workflow.Da.Domain.Employee> EmployeeList
        {
            set { employeeList = value; }
            get { return employeeList; }
        }
        private IList<Workflow.Da.Domain.Employee> otherEmployeeList;
        public IList<Workflow.Da.Domain.Employee> OtherEmployeeList
        {
            set { otherEmployeeList = value; }
            get { return otherEmployeeList; }
        }
        private IList<Workflow.Da.Domain.Employee> printEmployeeList;
        public IList<Workflow.Da.Domain.Employee> PrintEmployeeList
        {
            set { printEmployeeList = value; }
            get { return printEmployeeList; }
        }
        private IList<Gathering> gatheringList=new List<Gathering>();
        public IList<Gathering> GatheringList
        {
            set { gatheringList = value; }
            get { return gatheringList; }
        }
		private IList<Gathering> printGatheringList = new List<Gathering>();
		public IList<Gathering> PrintGatheringList
		{
			set { printGatheringList = value; }
			get { return printGatheringList; }
		}

        private IList<LabelValue> operatorList;
        public IList<LabelValue> OperatorList
        {
            get { return operatorList; }
            set { operatorList = value; }
        }

        private IList<CustomerLevel> customerLevelList;
        public IList<CustomerLevel> CustomerLevelList
        {
            get { return customerLevelList; }
            set { customerLevelList = value; }
        }

        private IList<CustomerType> customerTypeList;
        public IList<CustomerType> CustomerTypeList
        {
            get { return customerTypeList; }
            set { customerTypeList = value; }
        }

        private IList<MemberCardLevel> memberCardLevelList;
        public IList<MemberCardLevel> MemberCardLevelList
        {
            get { return memberCardLevelList; }
            set { memberCardLevelList = value; }
        }

        private IList<Customer> customerList;
        public IList<Customer> CustomerList
        {
            get { return customerList; }
            set { customerList = value; }
        }
        private IList<Customer> customerPrintList;
        public IList<Customer> CustomerPrintList
        {
            get { return customerPrintList; }
            set { customerPrintList = value; }
        }
        private IList<Position> positionList;
        public IList<Position> PositionList 
        {
            set { positionList = value; }
            get { return positionList; }
        }
        private string balanceDateTimeString;
        public string BalanceDateTimeString
        {
            get { return  balanceDateTimeString; }
            set { balanceDateTimeString = value; }
        }

        private string insertDateTimeString;
        public string InsertDateTimeString
        {
            get { return insertDateTimeString; }
            set { insertDateTimeString = value; }
        }

        private string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        private long employeeId;
        public long EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        private string operator1;
        public string Operator1
        {
            get { return operator1; }
            set { operator1 = value; }
        }

        private string operator2;
        public string Operator2
        {
            get { return operator2; }
            set { operator2 = value; }
        }
        private string operator3;
        public string Operator3
        {
            get { return operator3; }
            set { operator3 = value; }
        }

        private decimal amount1;
        public decimal Amount1
        {
            get { return amount1; }
            set { amount1=value; }
        }

        private decimal amount2;
        public decimal Amount2
        {
            get { return amount2; }
            set { amount2 = value; }
        }

        private decimal amount3;
        public decimal Amount3
        {
            get { return amount3; }
            set { amount3 = value; }
        }

        private string memberCardNo;
        public string MemberCardNo
        {
            get { return memberCardNo; }
            set { memberCardNo = value;}
        }

        private IList<Order> orderPrintList;
        public IList<Order> OrderPrintList
        {
            get { return orderPrintList; }
            set { orderPrintList = value; }
        }

        #region //订单查询使用的Model
        private IList<BusinessType> businessTypeList;

        public IList<BusinessType> BusinessTypeList
        {
            get { return businessTypeList; }
            set { businessTypeList = value; }
        }

		private string businessTypeId;
		//业务类型
		public string BusinessTypeId
		{
			get { return businessTypeId; }
			set { businessTypeId = value; }
		}

		private string amountCondition;
		//查询数量条件
		public string AmountCondtition
		{
			get { return amountCondition; }
			set { amountCondition = value; }
		}

		private string amount;
		//查询数量
		public string Amount
		{
			get { return amount; }
			set { amount = value; }
		}

		private string priceCondition;
		//查询金额条件
		public string PriceCondition
		{
			get { return priceCondition; }
			set { priceCondition = value; }
		}

		private string price;
		//查询金额
		public string Price
		{
			get { return price; }
			set { price = value; }
		}

		private string beginDate;
		//查询开始时间
		public string BeginDate
		{
			get { return beginDate; }
			set { beginDate = value; }
		}

		private string endDate;
		//查询结束时间
		public string EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}

        //private IList<Order> orderList;
        ////
        //public IList<Order> OrderList
        //{
        //    get { return orderList; }
        //    set { orderList = value; }
        //}

        private string amounts;
        //查询出来的订单数量
        public string Amounts
        {
            get { return amounts; }
            set { amounts = value; }
        }

        #endregion

        private FindFinanceAction findFinanceAction;
        public FindFinanceAction FindFinanceAction
        {
            set { findFinanceAction = value; }
            get { return findFinanceAction; }
        }

        private CashHandOverAction cashHandOverAction;
        public CashHandOverAction CashHandOverAction
        {
            set { cashHandOverAction = value; }
            get { return cashHandOverAction; }
        }

        private PaymentConcession paymentConcession = new PaymentConcession();
        public PaymentConcession PaymentConcession 
        {
            set { paymentConcession = value; }
            get { return paymentConcession; }
        }

        private IList<PaymentConcession> paymentConcessionList;
        public IList<PaymentConcession> PaymentConcessionList 
        {
            set { paymentConcessionList = value; }
            get { return paymentConcessionList; }
        }

        private IList<PaymentConcession> paymentConcessionPrintList;
        public IList<PaymentConcession> PaymentConcessionPrintList
        {
            set { paymentConcessionPrintList = value; }
            get { return paymentConcessionPrintList; }
        }

        private IList<Gathering> gatheringPrintList;
        public IList<Gathering> GatheringPrintList
        {
            set { gatheringPrintList = value; }
            get { return gatheringPrintList; }
        }

        private Workflow.Da.Domain.Employee employee=new Workflow.Da.Domain.Employee();
        public Workflow.Da.Domain.Employee Employee 
        {
            set { employee = value; }
            get { return employee; }
        }
        private decimal scotAmount;
        public decimal ScotAmount
        {
            set { scotAmount = value; }
            get { return scotAmount; }
        }

        private OtherGatheringAndRefundmentRecord otherGatheringAndRefundmentRecord;
        public OtherGatheringAndRefundmentRecord OtherGathingAndRefundMentRecord
        {
            set { otherGatheringAndRefundmentRecord = value; }
            get { return otherGatheringAndRefundmentRecord; }
        }

        private IList<OtherGatheringAndRefundmentRecord> otherGatheringAndRefundmentRecordList;
        public IList<OtherGatheringAndRefundmentRecord> OtherGathingAndRefundMentRecordList 
        {
            set { otherGatheringAndRefundmentRecordList = value; }
            get { return otherGatheringAndRefundmentRecordList; }
        }

        private IList<OtherGatheringAndRefundmentRecord> otherGatheringAndRefundmentRecordPrintList;
        public IList<OtherGatheringAndRefundmentRecord> OtherGathingAndRefundMentRecordPrintList
        {
            set { otherGatheringAndRefundmentRecordPrintList = value; }
            get { return otherGatheringAndRefundmentRecordPrintList; }
        }

        private bool isPrint;
        public bool IsPrint 
        {
            set { isPrint = value; }
            get { return isPrint; }
        }

		private int recordCount;
		/// <summary>
		/// 分页总数量
		/// </summary>
		public int RecordCount
		{
			get { return recordCount; }
			set { recordCount = value; }
		}

		#region 开始行

		private int beginRow;
		/// <summary>
		/// 开始行
		/// </summary>
		public int BeginRow
		{
			get { return beginRow; }
			set { beginRow = value; }
		}

		#endregion

		#region 结束行

		private int endRow;
		/// <summary>
		/// 结束行
		/// </summary>
		public int EndRow
		{
			get { return endRow; }
			set { endRow = value; }
		}

		#endregion

		#region 订单相对应客户

		private Customer customer;
		/// <summary>
		/// 订单相对应客户
		/// </summary>
		public Customer Customer
		{
			get { return customer; }
			set { customer = value; }
		}

		#endregion

		#region 客户id

		private long customerId;
		/// <summary>
		/// 客户id
		/// </summary>
		public long CustomerId
		{
			get { return customerId; }
			set { customerId = value; }
		}

		#endregion

		#region 总计金额

		private decimal sunAmount;
		/// <summary>
		/// 总计金额
		/// </summary>
		public decimal SunAmount
		{
			get { return sunAmount; }
			set { sunAmount = value; }
		}


		#endregion
	}
}
