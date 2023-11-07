using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ORDERS_FOR_RECORD_MACHINE_SUM ��Ӧ��Dao ʵ��
	/// </summary>
    public class OrdersForRecordMachineSumDaoImpl : Workflow.Da.Base.DaoBaseImpl<OrdersForRecordMachineSum>, IOrdersForRecordMachineSumDao
    {
        #region //�����г������ݵĻ���
        /// <summary>
        /// �����г������ݵĻ���
        /// </summary>
        /// <param name="ordersForRecordMachineSum"></param>
        /// <returns></returns>
        public OrdersForRecordMachineSum SelectOrdersForRecordMachineSum(OrdersForRecordMachineSum ordersForRecordMachineSum)
        {
            return sqlMap.QueryForObject<OrdersForRecordMachineSum>("OrdersForRecordMachineSum.SelectOrdersForRecordMachineSum", ordersForRecordMachineSum);
        }
        #endregion
    }
}
