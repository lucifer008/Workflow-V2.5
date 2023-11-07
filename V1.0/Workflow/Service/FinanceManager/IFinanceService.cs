using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
using Workflow.Action.Finance.Model;
namespace Workflow.Service
{
    public interface IFinanceService
    {
        /// <summary>
        /// 通过OrderId获取工单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-15
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        Order GetOrderByOrderId(long orderId);
        /// <summary>
        /// 收预收款
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-15
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void PrepayHandler(Gathering gather, GatheringOrder gatherOrder,OrdersStatusAlter orderStatusAlter,RelationEmployee relationEmployee,string orderNo,int orderStatus);
        /// <summary>
        /// 收预收款
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-15
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void UpdateOrderStatus(Order order, int orderStatusFlag);
        /// <summary>
        /// 查找等待结算的工单
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-16
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> SelectUnClosedOrder(Order order);
        /// <summary>
        /// 查找等待结算的工单数量
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2008-11-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        int SelectUnClosedOrderCount(Order order);
        /// <summary>
        /// 工单结算
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-17
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void CloseOrder(Order order,IList<OrderItem> orderItemList, IList<OrdersForRecordMachineSum> ordersForRecordMachineSumList, Gathering gathering, GatheringOrder gatheringOrder, IList<PaymentConcession> paymentConcessionList, OrdersStatusAlter orderStatusAlter, RelationEmployee realtionEmployee, Workflow.Action.Finance.Model.FinanceModel FinanceModel);
        /// <summary>
        /// 查找有欠款的工单
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-17
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> SelectNotHaveBeenPaidOrder(Order order);
        /// <summary>
        /// 应收款处理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-18
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void ArrearageMoneyHandler(IList<Order> orderList, IList<Gathering> gatheringList, IList<GatheringOrder> gatheringOrderList, IList<PaymentConcession> paymentConcessionList,FinanceModel model);
        /// 通过ID查找加工内容的颜色
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        string GetProcessContentById(long Id);

        /// 计算某个工单下所有参与人的业绩
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-5
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void CalculateCustomerAchievement(long ordersId, IList<OrderItem> orderItemList);

        #region //返回工单
        /// <summary>
        /// 返回工单
        /// </summary>
        /// <param name="orderStatusAlter"></param>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2008-12-23
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        void ReturnOrder(OrdersStatusAlter orderStatusAlter);
        #endregion 

        #region //领取发票

        /// <summary>
        /// 按照工单号 查询欠发票Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2008-12-24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        IList<Order> SearchTicketAmountInfoByOrderNo(Order order);

        /// <summary>
        /// 按照工单号统计欠发票信息的总记录数
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2008-12-24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        long SearchTicketAmountInfoByOrderNoTotal(Order order);

        /// <summary>
        /// 领取发票
        /// </summary>
        /// <param name="order"></param>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2008-12-24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        void DrawTicket(Order order);
        #endregion

        /// <summary>
        /// 名   称:  GetAllMarkingSettingList
        /// 功能概要: 获取所有积分列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月29日13:29:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<MarkingSetting> GetAllMarkingSettingList();

        /// <summary>
        /// 名   称:  UpdateMemberCardMarkingSetting
        /// 功能概要: 更新会员积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月29日13:29:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void UpdateMemberCardMarkingSetting(long orderId);

        /// <summary>
        ///  名    称: GetCustomerPreDeposit
        ///  功能概要: 获取客户预存款
        ///  作    者: 张晓林
        ///  创建时间: 2009年11月3日11:45:39
        ///  修正履历:
        ///  修正时间:
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        decimal GetCustomerPreDeposit(long customerId); 
    }
}
