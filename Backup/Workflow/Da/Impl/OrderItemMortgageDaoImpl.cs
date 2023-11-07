#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
#endregion

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ORDER_ITEM_MORTGAGE (订单冲减明细) 对应的Dao 实现
	/// </summary>
    public class OrderItemMortgageDaoImpl : Workflow.Da.Base.DaoBaseImpl<OrderItemMortgage>, IOrderItemMortgageDao
    {
        /// <summary>
        /// 名    称: GetOrderItemMortgageByOrderNo
        /// 功能概要: 根据订单Id获取订单冲减明细
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月25日11:01:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<OrderItemMortgage> GetOrderItemMortgageByOrderNo(long orderId) 
        {
            OrderMortgageRecord orderMortgageRecord = new OrderMortgageRecord();
            orderMortgageRecord.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            orderMortgageRecord.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            orderMortgageRecord.SrcOrderId = orderId;
            return sqlMap.QueryForList<OrderItemMortgage>("OrderItemMortgage.GetOrderItemMortgageByOrderNo", orderMortgageRecord);
        }
    }
}