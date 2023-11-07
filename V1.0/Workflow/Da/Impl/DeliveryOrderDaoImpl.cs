using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table DELIVERY_ORDER 对应的Dao 实现
	/// </summary>
    public class DeliveryOrderDaoImpl : Workflow.Da.Base.DaoBaseImpl<DeliveryOrder>, IDeliveryOrderDao
    {
        public DeliveryOrder GetDeliveryOrderByOrdersId(long ordersId)
        {
            return base.sqlMap.QueryForObject<DeliveryOrder>("DeliveryOrder.SelectDeliveryOrderByOrdersID", ordersId);
        }
        public int ExistsRecord(long ordersId)
        {
            return int.Parse(base.sqlMap.QueryForObject("DeliveryOrder.ExistsRecord", ordersId).ToString());
        }
    }
}
