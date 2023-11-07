#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDER_ITEM_MORTGAGE (订单冲减明细)对应的Dao 接口
	/// </summary>
	public interface IOrderItemMortgageDao : IDaoBase<OrderItemMortgage>
	{
        /// <summary>
        /// 名    称: GetOrderItemMortgageByOrderNo
        /// 功能概要: 根据订单Id获取订单冲减明细
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月25日11:01:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<OrderItemMortgage> GetOrderItemMortgageByOrderNo(long orderId); 
	}
}