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
        /// 订单中抄表数据的汇总
        /// </summary>
        /// <param name="ordersForRecordMachineSum"></param>
        /// <returns></returns>
        OrdersForRecordMachineSum SelectOrdersForRecordMachineSum(OrdersForRecordMachineSum ordersForRecordMachineSum);

        /// <summary>
        /// 获取需要抄表的订单明细Id集合
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月29日16:03:48
        /// </remarks>
        IList<long> GetOrderItemIdListNeedRecordMachine(long ordersId);

        /// <summary>
        /// 检查订单明细是否使用机器
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月29日16:03:48
        /// </remarks>
        bool CheckOrderItemIsUseMachine(long orderItemId);

        /// <summary>
        /// 获取订单明细价格因素值
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月29日16:03:48
        /// </remarks>
        OrderItemFactorValue GetOrderItemFactorValue(long orderItemId, string targetTable);
    }
}
