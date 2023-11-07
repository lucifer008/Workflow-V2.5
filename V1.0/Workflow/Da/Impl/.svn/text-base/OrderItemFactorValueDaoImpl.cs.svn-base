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
    }
}
