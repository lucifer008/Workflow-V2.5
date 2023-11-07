using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Service.Impl
{
	public class NoGeneratorImpl : INoGenerator
	{
		private string prefix = "S";

		public string Prefix
		{
			set { prefix = value; }
		}
		#region INoGenerator ³ÉÔ±

		public string GetOrderNo(long orderId,int branchShopId)
		{
            int pf = 83;
            if (branchShopId > 1)
            {
                pf = pf + branchShopId;
            }
            if (pf > 90)
                pf = pf - 26;

			return (char)pf + orderId.ToString("0000000");
		}

		#endregion

	}
}
