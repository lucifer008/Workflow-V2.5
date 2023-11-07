using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table GATHERING_ORDERS ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IGatheringOrderDao : IDaoBase<GatheringOrder>
    {
        IList<GatheringOrder> GetGahteringOrderListByOrderId(long strOrderId);

    }
}
