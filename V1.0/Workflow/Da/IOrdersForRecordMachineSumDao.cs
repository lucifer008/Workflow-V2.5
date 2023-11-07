using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDERS_FOR_RECORD_MACHINE_SUM ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IOrdersForRecordMachineSumDao : IDaoBase<OrdersForRecordMachineSum>
    {
        /// <summary>
        /// �����г������ݵĻ���
        /// </summary>
        /// <param name="ordersForRecordMachineSum"></param>
        /// <returns></returns>
        OrdersForRecordMachineSum SelectOrdersForRecordMachineSum(OrdersForRecordMachineSum ordersForRecordMachineSum);
    }
}
