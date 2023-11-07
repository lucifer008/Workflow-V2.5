using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ORDER_ITEM_FACTOR_VALUE 对应的Dao 实现
	/// </summary>
    public class OrderItemFactorValueDaoImpl : Workflow.Da.Base.DaoBaseImpl<OrderItemFactorValue>, IOrderItemFactorValueDao
    {
        public void DeleteOrderItemFactorValueByOrderNo(string strOrderNo)
        {
            OrderItemFactorValue orderItemFactorValue = new OrderItemFactorValue();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItemFactorValue.Id = user.BranchShopId;
            orderItemFactorValue.OrderItemId = user.CompanyId;
            orderItemFactorValue.Value = strOrderNo;
            base.sqlMap.Delete("OrderItemFactorValue.DeleteOrderItemFactorValueByOrderNo", orderItemFactorValue);
        }

        /// <summary>
        /// 名    称: GetOrderItemFactorValueListByOrderNO
        /// 功能概要: 根据订单号获取订单明细因素值列表
        /// 作    者：张晓林
        /// 创建时间: 2009年11月23日13:26:05
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        public IList<OrderItemFactorValue> GetOrderItemFactorValueListByOrderNO(string orderNo) 
        {
            OrderItemFactorValue orderItemFactorValue = new OrderItemFactorValue();
            orderItemFactorValue.Value = orderNo;
            orderItemFactorValue.PriceFactorId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            orderItemFactorValue.OrderItemId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<OrderItemFactorValue>("OrderItemFactorValue.GetOrderItemFactorValueListByOrderNO", orderItemFactorValue);
        }
    }
}
