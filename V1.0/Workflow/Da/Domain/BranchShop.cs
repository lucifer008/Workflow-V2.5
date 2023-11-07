using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table BRANCH_SHOP¶ÔÓ¦µÄDotNet Object
	/// </summary>
	[Serializable]
	public class BranchShop : BranchShopBase
	{
		public BranchShop()
		{
		}

        private string companyName;
        public string CompanyName 
        {
            set { companyName = value; }
            get { return companyName; }
        }
	}
}
