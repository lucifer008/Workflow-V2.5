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

        /// <summary>
        /// ��ȡ��Ҫ����Ķ�����ϸId����
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��  ��: ������
        /// ��  ��: 2010��4��29��16:03:48
        /// </remarks>
        IList<long> GetOrderItemIdListNeedRecordMachine(long ordersId);

        /// <summary>
        /// ��鶩����ϸ�Ƿ�ʹ�û���
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��  ��: ������
        /// ��  ��: 2010��4��29��16:03:48
        /// </remarks>
        bool CheckOrderItemIsUseMachine(long orderItemId);

        /// <summary>
        /// ��ȡ������ϸ�۸�����ֵ
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��  ��: ������
        /// ��  ��: 2010��4��29��16:03:48
        /// </remarks>
        OrderItemFactorValue GetOrderItemFactorValue(long orderItemId, string targetTable);
    }
}
