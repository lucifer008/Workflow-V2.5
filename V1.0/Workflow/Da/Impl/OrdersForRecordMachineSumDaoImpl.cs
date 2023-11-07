using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ORDERS_FOR_RECORD_MACHINE_SUM 对应的Dao 实现
	/// </summary>
    public class OrdersForRecordMachineSumDaoImpl : Workflow.Da.Base.DaoBaseImpl<OrdersForRecordMachineSum>, IOrdersForRecordMachineSumDao
    {
        #region //工单中抄表数据的汇总
        /// <summary>
        /// 工单中抄表数据的汇总
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
