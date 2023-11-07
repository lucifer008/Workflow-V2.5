using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table ORDER_ITEM_PRINT_REQUIRE_DETAIL¶ÔÓ¦µÄDotNet Object
	/// </summary>
	[Serializable]
	public class OrderItemPrintRequireDetail : OrderItemPrintRequireDetailBase
	{
		public OrderItemPrintRequireDetail()
		{
		}
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

	}
}
