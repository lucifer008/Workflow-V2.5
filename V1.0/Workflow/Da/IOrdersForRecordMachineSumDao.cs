using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDERS_FOR_RECORD_MACHINE_SUM 对应的Dao 接口
	/// </summary>
    public interface IOrdersForRecordMachineSumDao : IDaoBase<OrdersForRecordMachineSum>
    {
        /// <summary>
        /// 工单中抄表数据的汇总
        /// </summary>
        /// <param name="ordersForRecordMachineSum"></param>
        /// <returns></returns>
        OrdersForRecordMachineSum SelectOrdersForRecordMachineSum(OrdersForRecordMachineSum ordersForRecordMachineSum);
    }
}
