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
        #region //订单中抄表数据的汇总
        /// <summary>
        /// 订单中抄表数据的汇总
        /// </summary>
        /// <param name="ordersForRecordMachineSum"></param>
        /// <returns></returns>
        public OrdersForRecordMachineSum SelectOrdersForRecordMachineSum(OrdersForRecordMachineSum ordersForRecordMachineSum)
        {
            return sqlMap.QueryForObject<OrdersForRecordMachineSum>("OrdersForRecordMachineSum.SelectOrdersForRecordMachineSum", ordersForRecordMachineSum);
        }
        #endregion

        /// <summary>
        /// 获取需要抄表的订单明细Id集合
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月29日16:03:48
        /// </remarks>
        public IList<long> GetOrderItemIdListNeedRecordMachine(long ordersId) 
        {
            OrderItem oi=new OrderItem();
            oi.OrdersId=ordersId;
            oi.CompanyId=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            oi.BranchShopId=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<long>("OrdersForRecordMachineSum.GetOrderItemIdListNeedRecordMachine",oi);
        }

        /// <summary>
        /// 检查订单明细是否使用机器
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月29日16:03:48
        /// </remarks>
        public bool CheckOrderItemIsUseMachine(long orderItemId) 
        {
            bool isExist = false;
            OrderItem oi = new OrderItem();
            oi.Id = orderItemId; ;
            oi.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            oi.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            oi.Memo = "MACHINE_TYPE";
            int count = sqlMap.QueryForObject<int>("OrdersForRecordMachineSum.CheckOrderItemIsUseMachine", oi);
            if (0 != count) isExist = true;
            return isExist;
        }

        /// <summary>
        /// 获取订单明细价格因素
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <param name="targetTable">价格因素</param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月29日16:03:48
        /// </remarks>
        public OrderItemFactorValue GetOrderItemFactorValue(long orderItemId, string targetTable) 
        {
            OrderItem oi = new OrderItem();
            oi.Id = orderItemId; ;
            oi.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            oi.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            oi.Memo = targetTable;
            return sqlMap.QueryForObject<OrderItemFactorValue>("OrdersForRecordMachineSum.GetOrderItemFactorValue", oi);
        }

    }
}
