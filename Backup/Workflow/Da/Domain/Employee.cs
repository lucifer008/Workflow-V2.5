using System;
using System.Collections.Generic;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table EMPLOYEE对应的DotNet Object
	/// </summary>
	[Serializable]
	public class Employee : EmployeeBase
	{
		public Employee()
		{
		}
        private long positionid;

        public long Positionid
        {
            get { return positionid; }
            set { positionid = value; }
        }
        private long employeeid;

        public long Employeeid
        {
            get { return employeeid; }
            set { employeeid = value; }
        }
        private string positionName;

        public string PositionName
        {
            get { return positionName; }
            set { positionName = value; }
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

        private string positionIdString;
        public string PositionIdString 
        {
            set { positionIdString = value; }
            get {return positionIdString; }
        }
        /// <summary>
        /// 后期参与开单量
        /// </summary>
        private long anaphseNum;
        /// <summary>
        /// 后期参与开单量
        /// </summary>
        public long AnaphseNum 
        {
            set { anaphseNum = value; }
            get { return anaphseNum; }
        }

        /// <summary>
        /// 前期与开单量
        /// </summary>
        private decimal phophaseNum;
        /// <summary>
        /// 前期参与开单量
        /// </summary>
        public decimal PhophaseNum 
        {
            set { phophaseNum = value; }
            get { return phophaseNum; }
        }
        private string[] arrayEmployee;
        public string[] ArrayEmployee 
        {
            set { arrayEmployee = value; }
            get { return arrayEmployee; }
        }
        private DateTime balanceDateTime;
        public DateTime BalanceDateTime 
        {
            set { balanceDateTime = value; }
            get { return balanceDateTime; }
        }
        private long orderId;
        public long OrderId
        {
            set { orderId = value; }
            get { return orderId; }
        }
        private string orderNo;
        public string OrderNo
        {
            set { orderNo = value; }
            get { return orderNo; }
        }
        //private decimal orderTotal;
        //public decimal OrderTotal 
        //{
        //    set { orderTotal = value; }
        //    get { return orderTotal; }
        //}

		#region 是否是前期雇员

		private int isProphase;
		/// <summary>
		/// 是否是前期雇员
		/// </summary>
		public int IsProphase
		{
			get { return isProphase; }
			set { isProphase = value; }
		}

		#endregion
	}
}
