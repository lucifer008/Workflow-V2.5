#region imports
using System;
using Workflow.Da.Domain.Base;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table ORDER_MORTGAGE_RECORD (订单冲减记录) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class OrderMortgageRecord : OrderMortgageRecordBase
	{
		public OrderMortgageRecord()
		{
		}

        private string srcOrderNo;
        public string SrcOrderNo 
        {
            set { srcOrderNo = value; }
            get { return srcOrderNo; }
        }

        private string orderNo;
        public string OrderNo 
        {
            set { orderNo = value; }
            get { return orderNo; }
        }

        private decimal diffAmount;
        public decimal DiffAmount 
        {
            set { diffAmount = value; }
            get { return diffAmount; }
        }
	}
}