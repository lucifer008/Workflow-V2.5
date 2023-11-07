using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Service
{
	public interface INoGenerator
	{
		/// <summary>
		/// 根据提供的订单Id获取订单No
		/// </summary>
		/// <param name="orderId">订单Id</param>
		/// <returns>产生的订单No</returns>
		/// <remarks>
		/// 作    者: 祝新宾
		/// 创建时间: 2007-10-5
		/// 修正履历:
		/// 修正时间:
		/// </remarks>
		string GetOrderNo(long orderId,int branchShopId);
	}
}
