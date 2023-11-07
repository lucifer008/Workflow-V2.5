#region imports
using System;
using Workflow.Da.Domain.Base;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table OTHER_GATHERING_AND_REFUNDMENT_RECORD (其它收退款记录) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class OtherGatheringAndRefundmentRecord : OtherGatheringAndRefundmentRecordBase
	{
		public OtherGatheringAndRefundmentRecord()
		{
		}
        private long tempPayKind;
        public long TempPayKind 
        {
            set { tempPayKind = value; }
            get { return tempPayKind; }
        }

        private string customerName;
        public string CustomerName 
        {
            set { customerName = value; }
            get { return customerName; }
        }
        private string insertDateTimeString;
        public string InsertDateTimeString 
        {
            set { insertDateTimeString = value; }
            get { return insertDateTimeString; }
        }

        private string endtDateTimeString;
        public string EndDateTimeString
        {
            set { endtDateTimeString = value; }
            get { return endtDateTimeString; }
        }

        private decimal paidAmount;
        public decimal PaidAmount 
        {
            set { paidAmount = value; }
            get { return paidAmount; }
        }

        private decimal preDepositiAmount;
        public decimal PreDepositiAmount 
        {
            set { preDepositiAmount = value; }
            get { return preDepositiAmount; }
        }

        private string drawEmployee;
        public string DrawEmployee 
        {
            set { drawEmployee = value; }
            get { return drawEmployee; }
        }

        private string orderNo;
        public string OrderNo 
        {
            set { orderNo = value; }
            get { return orderNo; }
        }

        private long currentPageIndex;
        public long CurrentPageIndex 
        {
            set { currentPageIndex = value; }
            get { return currentPageIndex; }
        }

        private long rowCount;
        public long RowCount 
        {
            set { rowCount = value; }
            get { return rowCount; }
        }

        private string memberCardNo;
        public string MemberCardNo
        {
            get { return memberCardNo; }
            set { memberCardNo = value; }
        }
	}
}