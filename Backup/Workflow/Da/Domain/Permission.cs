using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table PERMISSION¶ÔÓ¦µÄDotNet Object
	/// </summary>
	[Serializable]
	public class Permission : PermissionBase
	{
		public Permission()
		{
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

        private long comId;
        public long ComId 
        {
            set { comId = value; }
            get { return comId; }
        }

        private long branId;
        public long BranId 
        {
            set { branId = value; }
            get { return branId; }
        }
	}
}
