using System;
using Workflow.Da.Domain.Base;
using Workflow.Support;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table CUSTOMER¶ÔÓ¦µÄDotNet Object
	/// </summary>
	[Serializable]
	public class Customer : CustomerBase
	{
        private int customerTypeId;
        public int CustomerTypeId 
        {
            set { customerTypeId = value; }
            get { return customerTypeId; }
        }
		public Customer()
		{
            
		}
	}
}

