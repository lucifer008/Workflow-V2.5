using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table CHANGE_MEMBER_CARD¶ÔÓ¦µÄDotNet Object
	/// </summary>
	[Serializable]
	public class ChangeMemberCard : ChangeMemberCardBase
	{
		public ChangeMemberCard()
		{
		}

        private string customerName;
        public string CustomerName 
        {
            set { customerName = value; }
            get { return customerName; }
        }

        private long customerId;
        public long CustomerId 
        {
            set { customerId = value; }
            get { return customerId; }
        }
	}
}
