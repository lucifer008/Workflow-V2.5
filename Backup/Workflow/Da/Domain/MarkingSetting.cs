#region imports
using System;
using Workflow.Da.Domain.Base;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MARKING_SETTING (积分设置) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class MarkingSetting : MarkingSettingBase
	{
		public MarkingSetting()
		{
		}

        private string processName;
        public string ProcessName
        {
            set { processName = value; }
            get { return processName; }
        }
        private long companyId;
        public long CompanyId 
        {
            set { companyId = value; }
            get { return companyId; }
        }

        private long branchShopId;
        public long BranchShopId 
        {
            set { branchShopId = value; }
            get { return branchShopId; }
        }
        private long rowCount;
        public long RowCount 
        {
            set { rowCount = value; }
            get { return rowCount; }
        }
        private long currentPageIndex;
        public long CurrentPageIndex 
        {
            set { currentPageIndex = value; }
            get { return currentPageIndex; }
        }

        private string strProcessContent;
        public string StrProcessContent 
        {
            set { strProcessContent = value; }
            get { return strProcessContent; }
        }
	}
}