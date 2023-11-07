#region imports
using System;
using Workflow.Da.Domain.Base;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table ORDER_ITEM_MORTGAGE (订单冲减明细) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class OrderItemMortgage : OrderItemMortgageBase
	{
		public OrderItemMortgage()
		{
            
		}
        private long orderId;
        public long OrderId 
        {
            set { orderId = value; }
            get { return orderId; }
        }
	}
}