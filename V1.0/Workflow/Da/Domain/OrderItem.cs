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

        #region Add Cry

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
        /// 工单明细中的加工内容
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
    }
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
    
}
