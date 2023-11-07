using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table ORDERS_STATUS_ALTER¶ÔÓ¦µÄDotNet Object
	/// </summary>
	[Serializable]
	public class OrdersStatusAlter : OrdersStatusAlterBase
	{
		public OrdersStatusAlter()
		{

		}
        private string orderNo;
        public string OrderNo 
        {
            set { orderNo = value; }
            get { return orderNo; }
        }
	}
}
