using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table DELIVERY_ORDER ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IDeliveryOrderDao : IDaoBase<DeliveryOrder>
    {
        DeliveryOrder GetDeliveryOrderByOrdersId(long ordersId);
        int ExistsRecord(long ordersId);
    }
}
