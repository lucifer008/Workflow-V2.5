#region imports
using System;
using Workflow.Da.Domain.Base;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table DAILY_BUSIONESS_REPORT_ITEM (日营业报表明细) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class DailyBusionessReportItem : DailyBusionessReportItemBase
	{
		public DailyBusionessReportItem()
		{
		}
        private long orderItemId;
        public long OrderItemId 
        {
            set { orderItemId = value; }
            get { return orderItemId; }
        }
        private long priceFactorId;
        public long PriceFactorId 
        {
            set { priceFactorId = value; }
            get { return priceFactorId; }
        }
        private long priceFactorValueId;
        public long PriceFactorValueId 
        {
            set { priceFactorValueId = value; }
            get { return priceFactorValueId; }
        }

        private long branchShopId;
        public long BranchShopId 
        {
            set { branchShopId = value; }
            get { return branchShopId; }
        }
        private long companyId;
        public long CompanyId 
        {
            set { companyId = value; }
            get { return companyId; }
        }
        private string date;
        public string Date 
        {
            set { date = value; }
            get { return date; }
        }
        private long processContentId;
        public long ProcessContentId
        {
            get { return processContentId; }
            set { processContentId = value; }
        }
        private long  machineTypeId;
        public long  MachineTypeId
        {
            get { return machineTypeId; }
            set { machineTypeId = value; }
        }
        private long  paperSpacificationId;
        public long PaperSpacificationId
        {
            get { return paperSpacificationId; }
            set { paperSpacificationId = value; }
        }
        private string  fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }


	}
}