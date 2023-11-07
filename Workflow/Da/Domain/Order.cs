using System;
using System.Collections.Generic;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table ORDERS��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class Order : OrderBase
	{
		public Order()
		{
            //this.
		}
        private string customertypename;
        public string CustomerTypeName
        {
            get { return customertypename; }
            set { customertypename = value; }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string linkManName;
        public string LinkManName
        {
            get { return linkManName; }
            set { linkManName = value; }
        }
        private string lastTelNo;
        public string LastTelNo
        {
            get { return lastTelNo; }
            set { lastTelNo = value; }
        }
        private string memberCardNo;
        public string MemberCardNo
        {
            get { return memberCardNo; }
            set { memberCardNo = value; }
        }
        private long tradeId;
        public long TradeId
        {
            get { return tradeId; }
            set { tradeId = value; }
        }
        private long status1;
        public long Status1
        {
            set { status1 = value; }
            get { return status1; }
        }
        private long status2;
        public long Status2
        {
            set { status2 = value; }
            get { return status2; }
        }
        private long status3;
        public long Status3
        {
            set { status3 = value; }
            get { return status3; }
        }

        private long status4;
        public long Status4
        {
            set { status4 = value; }
            get { return status4; }
        }
        private long currentPageIndex;
        /// <summary>
        /// ��ǰҳ��
        /// </summary>
        public long CurrentPageIndex
        {
            get { return currentPageIndex; }
            set { currentPageIndex = value; }
        }

        private int everyPageCount;
        /// <summary>
        /// ÿҳ��ʾ����
        /// </summary>
        public int EveryPageCount
        {
            get { return everyPageCount; }
            set { everyPageCount = value; }
        }


        private string orderAll;
        public string OrderAll
        {
            get { return orderAll; }
            set { orderAll = value; }
        }

        private string orderNoDispatch;
        public string OrderNoDispatch
        {
            get { return orderNoDispatch; }
            set { orderNoDispatch = value; }
        }
        private string orderBlankOut;
        public string OrderBlankOut
        {
            get { return orderBlankOut; }
            set { orderBlankOut = value; }
        }
        private string orderWorking;
        public string OrderWorking
        {
            get { return orderWorking; }
            set { orderWorking = value; }

        }
        private string orderSuccessed;
        public string OrderSuccessed
        {
            get { return orderSuccessed; }
            set { orderSuccessed = value; }
        }
        private string orderFinished;
        public string OrderFinished
        {
            get { return orderFinished; }
            set { orderFinished = value; }
        }
        private string orderNoPrepay;
        public string OrderNoPrepay
        {
            get { return orderNoPrepay; }
            set { orderNoPrepay = value; }
        }
        private string orderNoClosed;
        public string OrderNoClosed
        {
            get { return orderNoClosed; }
            set { orderNoClosed = value; }
        }

        private string insertDateTimeString;
        public string InsertDateTimeString
        {
            set { insertDateTimeString = value; }
            get { return insertDateTimeString; }
        }
        private string balanceDateTimeString;
        public string BalanceDateTimeString
        {
            set { balanceDateTimeString = value; }
            get { return balanceDateTimeString; }
        }
        private decimal zero;
        public decimal Zero
        {
            set { zero = value; }
            get { return zero; }
        }
        private decimal concession;
        public decimal Concession
        {
            set { concession = value; }
            get { return concession; }
        }
        private decimal renderUp;
        public decimal RenderUp
        {
            set { renderUp = value; }
            get { return renderUp; }
        }
        private decimal giveAway;
        public decimal GiveAway
        {
            set { giveAway = value; }
            get { return giveAway; }
        }
        private long days;
        public long Days
        {
            set { days = value; }
            get { return days; }
        }
        private long orderCount;
        public long OrderCount
        {
            set { orderCount = value; }
            get { return orderCount; }
        }
        private decimal paperCount;
        public decimal PaperCount
        {
            set { paperCount = value; }
            get { return paperCount; }
        }
        private string address;
        public string Address
        {
            set { address = value; }
            get { return address; }
        }

        private decimal hasPrePaidMoney;
        public decimal HasPrePaidMoney
        {
            get
            {
                return hasPrePaidMoney;
            }
            set
            {
                hasPrePaidMoney = value;
            }
        }



        private decimal needPrePay;
        public decimal NeedPrePay
        {
            get
            {
                return needPrePay;
            }
            set
            {
                needPrePay = value;
            }
        }
        private string newOrderName;
        public string NewOrderName 
        {
            set { newOrderName = value; }
            get { return newOrderName; }
        }

        private string cashName;
        public string CashName 
        {
            set { cashName = value; }
            get { return cashName; }
        }

        private int employeeId;
        public int EmployeeId
        {
            set { employeeId = value; }
            get { return employeeId; }
        }
        private decimal sumamount;
        public decimal Sumamount 
        {
            set { sumamount = value; }
            get { return sumamount; }
        }
        //private long newOrderUserId;
        //public long NewOrderUserId
        //{
        //    set { newOrderUserId = value; }
        //    get { return newOrderUserId; }
        //}
        //private long cashUserId;
        //public long CashUserId
        //{
        //    set { cashUserId = value; }
        //    get { return cashUserId; }
        //}
        //private DateTime startTime;
        //public DateTime StartTime
        //{
        //    set { startTime = value; }
        //    get { return startTime; }
        //}

        //private DateTime endTime;
        //public DateTime EndTime
        //{
        //    set { EndTime = value; }
        //    get { return EndTime; }
        //}

		/// <summary>
		///Ӧ�տʱ��ν�� 
		/// </summary>
		private decimal accountReceviableOweMomeyTotal;
		/// <summary>
		/// ��ȡ�������� Ӧ�տʱ��ν��
		/// </summary>
		public decimal AccountReceviableOweMomeyTotal 
		{
			set { accountReceviableOweMomeyTotal = value; }
			get { return accountReceviableOweMomeyTotal; }
		}

		/// <summary>
		/// ��ѯ����Ŀ�ʼʱ��
		/// </summary>
		private string beginBalanceDate;
		/// <summary>
		/// ��ȡ�������� ��ѯ����Ŀ�ʼʱ��
		/// </summary>
		public string BeginBalanceDate 
		{
			set { beginBalanceDate = value; }
			get {  return beginBalanceDate; }
		}

		/// <summary>
		///��ѯ����� ����ʱ�� 
		/// </summary>
		private string endBalanceDate;
		/// <summary>
		/// ��ȡ�������ò�ѯ����Ľ���ʱ��
		/// </summary>
		public string EndBalanceDate 
		{
			set { endBalanceDate = value; }
			get { return endBalanceDate; }
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
        private string comporeCondition;
        public string ComporeCondition
        {
            set { comporeCondition = value; }
            get { return comporeCondition; }
        }

        private bool selected;
        public bool Selected
        {
            set { selected = value; }
            get { return selected; }
        }

        private decimal currentMoney;
        public decimal CurrentMoney
        {
            set { currentMoney = value; }
            get { return currentMoney; }
        }

        private string [] employeeArray;
        public string[] EmployeeArray 
        {
            set { employeeArray = value; }
            get { return employeeArray; }
        }

        private string currentHandOverBeginDate;
        public string CurrentHandOverBeginDate 
        {
            set { currentHandOverBeginDate = value; }
            get { return currentHandOverBeginDate; }
        }

        private string currentHandOverEndDate;
        public string CurrentHandOverEndDate
        {
            set { currentHandOverEndDate = value; }
            get { return currentHandOverEndDate; }
        }
        /// <summary>
        /// ҵ���������
        /// </summary>
        private string priceProcessName;
        /// <summary>
        /// ҵ���������
        /// </summary>
        public string PriceProcessName 
        {
            set { priceProcessName = value; }
            get { return priceProcessName; }
        }
        private long processContentId;
        public long ProcessContentId 
        {
            set { processContentId = value; }
            get { return processContentId; }
        }

        private long businessTypeId;
        public long BusinessTypeId 
        {
            set { businessTypeId = value; }
            get { return businessTypeId; }
        }

        /// <summary>
        /// ������ϸ���
        /// </summary>
        private decimal itemAmount;
        /// <summary>
        /// ������ϸ���
        /// </summary>
        public decimal ItemAmount 
        {
            set { itemAmount = value; }
            get { return itemAmount; }
        }
        /// <summary>
        /// �Ƿ�ͳ�ƻ�Ա���ѻ���
        /// </summary>
        private bool isNotStatisticsPoints;
        /// <summary>
        /// �Ƿ�ͳ�ƻ�Ա���ѻ���
        /// </summary>
        public bool IsNotStatisticsPoints 
        {
            set { isNotStatisticsPoints = value; }
            get { return isNotStatisticsPoints; }
        }
        private IList<string> statusList = new List<string>();
        public IList<string> StatusList
        {
            set { statusList = value; }
            get { return statusList; }
		}
        private IList<string> otherStatusList = new List<string>();
        public IList<string> OtherStatusList
        {
            set { otherStatusList = value; }
            get { return otherStatusList; }
        }
        private string receptionEmployee;
        public string ReceptionEmployee 
        {
            set { receptionEmployee = value; }
            get { return receptionEmployee; }
        }

        private IList<OrderItem> printOrderItemList=new List<OrderItem>();
        public IList<OrderItem> PrintOrderItemList 
        {
            set { printOrderItemList = value; }
            get { return printOrderItemList; }
        }
		#region ��ǰ�������Żݽ��

		private decimal  concessionAmount;
		/// <summary>
		/// ��ǰ�������Żݽ��
		/// </summary>
		public decimal ConcessionAmount
		{
			get { return concessionAmount; }
			set { concessionAmount = value; }
		}

		#endregion

		#region ��ʼ��

		private int beginRow;
		/// <summary>
		/// ��ʼ��
		/// </summary>
		public int BeginRow
		{
			get { return beginRow; }
			set { beginRow = value; }
		}

		#endregion

		#region ������

		private int endRow;
		/// <summary>
		/// ������
		/// </summary>
		public int EndRow
		{
			get { return endRow; }
			set { endRow = value; }
		}

		#endregion

		#region ���ʽ

		private string payKind;
		/// <summary>
		/// ���ʽ
		/// </summary>
		public string PayKind
		{
			get { return payKind; }
			set { payKind = value; }
		}

		#endregion

		#region �û����ʱ�

		private decimal zeroAmount;
		/// <summary>
		/// Ĩ��
		/// </summary>
		public decimal ZeroAmount
		{
			get { return zeroAmount; }
			set { zeroAmount = value; }
		}

		//private decimal concessionAmount;
		///// <summary>
		///// �Ż�
		///// </summary>
		//public decimal ConcessionAmount
		//{
		//    get { return concessionAmount; }
		//    set { concessionAmount = value; }
		//}

		private decimal renderupAmount;
		/// <summary>
		/// ����
		/// </summary>
		public decimal RenderupAmount
		{
			get { return renderupAmount; }
			set { renderupAmount = value; }
		}

		private decimal negtiveAmount;
		/// <summary>
		/// ��������
		/// </summary>
		public decimal NegtiveAmount
		{
			get { return negtiveAmount; }
			set { negtiveAmount = value; }
		}

		private decimal positiveAmount;
		/// <summary>
		/// �������
		/// </summary>
		public decimal PositiveAmount
		{
			get { return positiveAmount; }
			set { positiveAmount = value; }
		}




		#endregion

        //#region �����Ż���Ϣ
        //private PaymentConcession paymentConcession;
        //public PaymentConcession PaymentConcession 
        //{
        //    set { paymentConcession = value; }
        //    get { return paymentConcession; }
        //}
        //#endregion
        public class DateOptionCard 
        {

            private string text;
            /// <summary>
            /// ��ȡ�������ı�
            /// </summary>
            public string Text 
            {
                set { text = value; }
                get { return text; }
            }
            private int key;
            /// <summary>
            /// ��ȡ����������
            /// </summary>
            public int Key
            {
                set { key = value; }
                get { return key; }
            }
            private string indirectKey;
            /// <summary>
            /// ��ȡ�����ü������
            /// </summary>
            public string IndirectKey 
            {
                set { indirectKey = value; }
                get { return indirectKey; }
            }
        }
    }
}

