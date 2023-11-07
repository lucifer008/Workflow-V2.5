using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table GATHERING_ORDERS 对应的Dao 实现
	/// </summary>
    public class GatheringOrderDaoImpl : Workflow.Da.Base.DaoBaseImpl<GatheringOrder>, IGatheringOrderDao
    {
        public IList<GatheringOrder> GetGahteringOrderListByOrderId(long strOrderId)
        {
            //User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            //GatheringOrder go = new GatheringOrder();
            //go.BranchShopId = user.BranchShopId;
            //go.CompanyId = user.CompanyId;
            //go.OrdersId = strOrderId;

            return sqlMap.QueryForList<GatheringOrder>("GatheringOrder.GetGatheringOrderByOrderId", strOrderId);
        }
    }
}
