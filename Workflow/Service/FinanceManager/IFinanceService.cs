using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Action.Finance.Model;
namespace Workflow.Service
{
    public interface IFinanceService
    {
        /// <summary>
        /// 通过OrderId获取订单信息
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
        /// 查找等待结算的订单
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
        /// 查找等待结算的订单数量
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
        /// 订单结算
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
        /// 查找有欠款的订单
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
        /// 查找有欠款的订单记录数
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月1日16:52:29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        long SelectCustomerOweMoneyDetailRowCount(Order order);

        /// <summary>
        /// 查找客户欠款的订单明细
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月2日13:33:36
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> SelectCustomerOweMoneyDetail(Order order); 

        /// <summary>
        /// 查找已经付款明细
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月1日15:52:46
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> SelectCustomerPaidAmountDetail(Order order);

        /// <summary>
        /// 查找已经付款明细记录数
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月1日15:52:46
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        long SelectCustomerPaidAmountDetailRowCount(Order order); 

        /// <summary>
        /// 查找订单付款明细
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年2月5日10:52:15
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> SelectOrderPaidAmountDetail(Order order);

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

        /// 计算某个订单下所有参与人的业绩
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-5
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void CalculateCustomerAchievement(long ordersId, IList<OrderItem> orderItemList);

        #region //返回订单
        /// <summary>
        /// 返回订单
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
        /// 按照订单号 查询欠发票Order
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
        /// 按照订单号统计欠发票信息的总记录数
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
        /// 按照订单号 查询欠发票Order(输出)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2009年11月30日15:39:16
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        IList<Order> SearchTicketAmountInfoPrintByOrderNo(Order order);


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
        void DrawTicket(IList<Order> orderList,IList<OtherGatheringAndRefundmentRecord> otherGatheAndReList);

        /// <summary>
        /// 取消欠发票
        /// </summary>
        /// <param name="orderId"></param>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年10月24日15:06:31
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        void CancelNotPaidTicket(IList<Order> orderList, IList<OtherGatheringAndRefundmentRecord> otherGatheAndReList);
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

        /// <summary>
        /// 名    称: GetAmendmentOrder
        /// 功能概要: 获取要修正的订单
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月17日13:10:40
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        Order GetAmendmentOrder(Order order);

        /// <summary>
        /// 订单修正
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月18日17:05:57
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void AmendmentOrder(Order order, IList<OrderItem> orderItemList, IList<OrdersForRecordMachineSum> ordersForRecordMachineSumList, Gathering gathering, GatheringOrder gatheringOrder, IList<PaymentConcession> paymentConcessionList, OrdersStatusAlter orderStatusAlter, RelationEmployee realtionEmployee, Workflow.Action.Finance.Model.FinanceModel FinanceModel);

        /// <summary>
        /// 名    称: OrderMortgage
        /// 功能概要: 订单冲减
        /// 作    者：张晓林
        /// 创建时间: 2009年11月23日10:51:58
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        void OrderMortgage(OrderModel orderModel); 

        /// <summary>
        /// 获取报红的订单列表按照条件
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2009年12月5日9:56:48
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        IList<Order> SearchMatureOrderList(Order order);

        /// <summary>
        /// 获取报红的订单记录数
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2009年12月5日9:56:48
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        long SearchMatureOrderListRowCount(Order order);

        /// <summary>
        /// 获取输出的报红的订单列表
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2009年12月5日9:56:48
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        IList<Order> SearchMatureOrderPrintList(Order order);

        /// <summary>
        /// 获取要输出的冲减订单信息
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2009年12月9日11:36:30
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        OrderMortgageRecord SearchMortgageOrderPrint();
        /// <summary>
        /// 通过各种号码查询客户ID
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：付强
        /// 创建时间: 2010-1-8
        /// </remarks>
        long GetCustomerIdByNo(Order order);

        /// <summary>
        ///     记录抄表数据
        /// </summary>
        /// <param name="ordersId">订单Id</param>
        /// <remarks>
        /// 作    者:张晓林
        /// 日    期:
        /// </remarks>
        void AddOrderForRecordMachine(long ordersId, DateTime balanceDateTime);

        /// <summary>
        /// 根据工单Id获取工单状态
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年6月8日15:58:20
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        int GetOrderStatusByOrderId(long orderId); 
    }
}
