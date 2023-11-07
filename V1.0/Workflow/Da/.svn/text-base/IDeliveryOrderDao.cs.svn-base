using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table DELIVERY_ORDER 对应的Dao 接口
	/// </summary>
    public interface IDeliveryOrderDao : IDaoBase<DeliveryOrder>
    {
        DeliveryOrder GetDeliveryOrderByOrdersId(long ordersId);
        int ExistsRecord(long ordersId);
    }
}
