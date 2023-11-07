using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table TAKE_WORK对应的DotNet Object
	/// </summary>
	[Serializable]
	public class TakeWork : TakeWorkBase
	{
		public TakeWork()
		{
           
		}

        private string deliveryName;
        //送货人
        public string DeliveryName
        {
            get { return deliveryName; }
            set { deliveryName = value; }
        }

        private string customerName;
        //客户名称
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
	}
}
