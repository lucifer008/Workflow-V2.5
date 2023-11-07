using System;
using Workflow.Da.Domain.Base;
using Workflow.Support;
using System.Collections.Generic;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table ORDER_ITEM对应的DotNet Object
	/// </summary>
	[Serializable]
	public class OrderItem : OrderItemBase
	{
		public OrderItem()
		{
		}

        private string needRecordMachine;
        public string NeedRecordMachine
        {
            get { return needRecordMachine; }
            set { needRecordMachine = value; }
        }
        private long priceFactorId;
        public long PriceFactorId
        {
            get { return priceFactorId; }
            set { priceFactorId = value; }
        }
        private string values;
        public string Values
        {
            get { return this.values; }
            set { this.values = value; }
        }
        private string businessTypeName;
        public string BusinessTypeName
        {
            get { return businessTypeName; }
            set { businessTypeName = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string targetTable;
        public string TargetTable
        {
            get { return targetTable; }
            set { targetTable = value; }
        }
        private string targetValueColumn;
        public string TargetValueColumn
        {
            get { return targetValueColumn; }
            set { targetValueColumn = value; }
        }
        private string targetTextColumn;
        public string TargetTextColumn
        {
            get { return targetTextColumn; }
            set { targetTextColumn = value; }
        }

		private string displayText;
		public string DisplayText
		{
			get { return displayText; }
			set { displayText = value; }
		}

        private decimal orderItemAchievement;
        public decimal OrderItemAchievement 
        {
            set { orderItemAchievement = value; }
            get{return orderItemAchievement;}
		}
        private IList<OrderItemEmployee> orderItemEmployeeList = new List<OrderItemEmployee>();
        public IList<OrderItemEmployee> OrderItemEmployeeList
        {
            set { orderItemEmployeeList = value; }
            get { return orderItemEmployeeList; }
        }

        private int statusSucessed;
        public int StatusSucessed 
        {
            set { statusSucessed = value; }
            get { return statusSucessed; }
        }

        private int statusSubmited;
        public int StatusSubmited
        {
            set { statusSubmited = value; }
            get { return statusSubmited; }
        }

        private int statusNotSubmited;
        public int StatusNotSubmited
        {
            set { statusNotSubmited = value; }
            get { return statusNotSubmited; }
        }

        private IList<int> orderStatusList = new List<int>();
        public IList<int> OrderStatusList
        {
            set { orderStatusList = value; }
            get { return orderStatusList; }
        }

		#region 订单明细相关的价格因素id 添加:陈汝胤

        private IList<OrderItemPrintRequireDetail> orderItemPrintRequireDetailList=new List<OrderItemPrintRequireDetail>();
        public IList<OrderItemPrintRequireDetail> OrderItemPrintRequireDetailList 
        {
            set { orderItemPrintRequireDetailList = value; }
            get { return orderItemPrintRequireDetailList; }
		}

		#endregion

		#region Add Cry

		private long baseBusinessTypePriceSetId;
		/// <summary>
		/// 订单明细相关的价格因素id
		/// </summary>
		public long BaseBusinessTypePriceSetId
		{
			get { return baseBusinessTypePriceSetId; }
			set { baseBusinessTypePriceSetId = value; }
		}

		#endregion

		#region 添加:陈汝胤

		private int itemId;
        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        /// <summary>
        /// Add Cry
        /// </summary>
        private int no;
        /// <summary>
        /// 编号
        /// </summary>
        public int No
        {
            get { return no; }
            set { no = value; }
        }

        private decimal money;
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal Money
        {
            get { return money; }
            set { money = value; }
        }

        private IList<CustomEmployee> employees;
        public IList<CustomEmployee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        private string processContentName;
        /// <summary>
        /// 订单明细中的加工内容
        /// </summary>
        public string ProcessContentName
        {
            get { return processContentName; }
            set { processContentName = value; }
        }

        

        private decimal anaphaseMoney;
        /// <summary>
        /// 后期制作的业绩平均值
        /// </summary>
        public decimal AnaphaseMoney
        {
            get { return anaphaseMoney; }
            set { anaphaseMoney = value; }
        }


        #endregion

		#region 打折活动相关价格因素 添加:陈汝胤

		#region 打折活动-----机器类型因素值

		private long machinePriceFactor;
		/// <summary>
		/// 打折活动-----机器类型因素值 添加:陈汝胤
		/// </summary>
		public long MachinePriceFactor
		{
			get { return machinePriceFactor; }
			set { machinePriceFactor = value; }
		}

		#endregion

		#region 打折活动------纸型因素值

		private long paperPriceFactor;
		/// <summary>
		/// 打折活动------纸型因素值 添加:陈汝胤
		/// </summary>
		public long PaperPriceFactor
		{
			get { return paperPriceFactor; }
			set { paperPriceFactor = value; }
		}

		#endregion

		#endregion

		#region 查询时间  添加:白晓宇
		private DateTime beginDateTime;
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime BeginDateTime
		{
			get { return beginDateTime; }
			set { beginDateTime = value; }
		}

		private DateTime endDateTime;
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndDateTime
		{
			get { return endDateTime; }
			set { endDateTime = value; }
		}
	
	
		#endregion

		#region 可冲减印章数   添加： 白晓宇
		protected decimal paperConsumeCount;
		/// <summary>
		/// 可冲减印章数
		/// </summary>
		public decimal PaperConsumeCount
		{
			get { return paperConsumeCount; }
			set { paperConsumeCount = value; }
		}
		#endregion

		#region 差价  添加：白晓宇
		private decimal diffPrice;
		/// <summary>
		///  差价
		/// </summary>
		public decimal DiffPrice
		{
			get { return diffPrice; }
			set { diffPrice = value; }
		}
		#endregion
	}
	#region CustomEmployee
	[Serializable]
    public class CustomEmployee
    {
        private string position;
        /// <summary>
        /// 工种
        /// </summary>
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        private string name;
        /// <summary>
        /// 工种名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private bool isProphase;
        //是否是前期
        public bool IsProphase
        {
            get { return isProphase; }
            set { isProphase = value; }
        }

        private long id;
        /// <summary>
        /// 员工id
        /// </summary>
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private decimal money;
        /// <summary>
        /// 业绩金额
        /// </summary>
        public decimal Money
        {
            get { return money; }
            set { money = value; }
        }

        private long positionId;
        public long PositionId 
        {
            set { positionId = value; }
            get { return positionId; }
        }
    }
	#endregion
}
