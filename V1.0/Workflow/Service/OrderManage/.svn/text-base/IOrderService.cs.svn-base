using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;

namespace Workflow.Service.OrderManage
{
    /// <summary>
    /// 名    称: IOrderService
    /// 功能概要: 工单管理Service的接口
    /// 作    者: 付强
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public interface IOrderService
    {
        #region 工单管理

        #region 保存工单
        /// <summary>
        /// 名    称: SaveOrder
        /// 功能概要: 保存工单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order">要保存的工单对象</param>
        /// <param name="orderStatusAlter">工单状态的变更履历对象</param>
        /// <param name="linkMan">联系人</param>
        /// <param name="customer">客户</param>
        void SaveOrder(Order order, OrdersStatusAlter orderStatusAlter, LinkMan linkMan, Customer customer);
        #endregion

        /// <summary>
        /// 名    称: UpdateOrder
        /// 功能概要: 更新工单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order">要更新的工单信息</param>
        void UpdateOrder(Order order);
        /// <summary>
        /// 名    称: DeleteOrder
        /// 功能概要: 通过Id删除工单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="ID">工单ID</param>
        void DeleteOrder(int id);

        #region 本日工单
        /// <summary>
        /// 名    称: SelectDailyOrderPager
        /// 功能概要: 显示近X天未完成工单 带分页
        /// 作    者: 付强
        /// 创建时间: 2008-12-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order">显示工单的过滤条件</param>
        /// <returns>返回符合条件的工单List</returns>
        IList<Order> SelectDailyOrderPager(Order order);
        /// <summary>
        /// 名    称: GetDailyOrderCount
        /// 功能概要: 获取符合条件的本日工单总数
        /// 作    者: 付强
        /// 创建时间: 2008-12-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order">传递过滤条件</param>
        /// <returns>符合过滤条件的工单总数</returns>
        int GetDailyOrderCount(Order order);
        #endregion

        /// <summary>
        /// 名    称: UpdateOrderStatusByOrderNo
        /// 功能概要: 通过工单号更新工单状态
        /// 作    者: 付强
        /// 创建时间: 2008-9-26
        /// 修正履历:
        /// 修正时间:        
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        /// <param name="OrderStatusFlag">要更新的工单状态</param>
        void UpdateOrderStatusByOrderNo(string strOrderNo, int OrderStatusFlag);
        /// <summary>
        /// 名    称: DispatchDeleteOrderItemEmployeeByOrderNo
        /// 功能概要: 通过工单号删除工单雇员
        /// 作    者: 付强
        /// 创建时间: 2008-9-26
        /// 修正履历:
        /// 修正时间:        
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        void DispatchDeleteOrderItemEmployeeByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: SelectOldEmployee
        /// 功能概要: 获取工单明细的工单雇员
        /// 作    者: 付强
        /// 创建时间: 2008-9-11
        /// 修正履历:
        /// 修正时间:        
        /// </summary>
        /// <param name="orderItemEmployee">查询条件</param>
        /// <returns>返回工单明细的相关雇员</returns>
        IList<OrderItemEmployee> SelectOldEmployee(OrderItemEmployee orderItemEmployee);

        #region 工单返工
        /// <summary>
        /// 名    称: ReDoOrder
        /// 功能概要: 返工
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderStatusAlter">状态变更履历</param>
        /// <param name="ordersDuty">返工责任金额</param>
        /// <param name="orderItemEmployee">新的参与人员</param>
        /// <param name="relationEmployee">状态变更的相关人员</param>
        /// <param name="dutyEmployeeList">相关责任人</param>
        /// <param name="strOrderNo">工单号</param>
        /// <param name="orderStatusFlag">工单状态</param>
        void ReDoOrder(OrdersStatusAlter orderStatusAlter, OrdersDuty ordersDuty, IList<OrderItemEmployee> orderItemEmployee, IList<RelationEmployee> relationEmployee, IList<DutyEmployee> dutyEmployeeList, string strOrderNo, int orderStatusFlag);
        #endregion

        #region 分配工单
        /// <summary>
        /// 名    称: DispatchOrder
        /// 功能概要: 分配工单
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployeeList">工单明细的参与人员</param>
        /// <param name="orderStatusAlter">工单状态的变更履历</param>
        /// <param name="relationEmployeeList">工单状态变更的相关人员</param>
        /// <param name="strOrderNo">工单号</param>
        /// <param name="OrderStatusFlag">工单状态</param>
        void DispatchOrder(IList<OrderItemEmployee> orderItemEmployeeList, OrdersStatusAlter orderStatusAlter, IList<RelationEmployee> relationEmployeeList, string strOrderNo, int OrderStatusFlag);
        #endregion

        #region 工单完工
        /// <summary>
        /// 名    称: FinishOrder
        /// 功能概要: 工单完工
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployeeList">工单明细的参与人员</param>
        /// <param name="orderStatusAlter">工单状态的变更履历</param>
        /// <param name="relationEmployeeList">工单状态变更的相关人员</param>
        /// <param name="strOrderNo">工单号</param>
        /// <param name="orderStatusFlag">工单状态</param>
        void FinishOrder(IList<OrderItemEmployee> orderItemEmployeeList, OrdersStatusAlter orderStatusAlter, IList<RelationEmployee> relationEmployeeList, string strOrderNo, int orderStatusFlag);
        #endregion

        #region 工单作废
        /// <summary>
        /// 名    称: BlankOutOrder
        /// 功能概要: 作废工单
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderStatusAlter">工单状态的变更履历</param>
        /// <param name="relationEmployeeList">工单状态变更的相关人员</param>
        /// <param name="strOrderNo">工单号</param>
        /// <param name="orderStatusFlag">工单状态</param>
        void BlankOutOrder(OrdersStatusAlter orderStatusAlter, IList<RelationEmployee> relationEmployeeList, string strOrderNo, int orderStatusFlag);
        #endregion

        #region 工单预付
        /// <summary>
        /// 名    称: PrepayOrder
        /// 功能概要: 工单预付
        /// 作    者: 付强
        /// 创建时间: 2008-10-27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderStatusAlter">工单状态的变更履历</param>
        /// <param name="gathering">收款记录</param>
        /// <param name="gatheringOrder">工单收款记录</param>
        /// <param name="orderNo">工单号</param>
        /// <param name="orderStatusFlag">工单状态</param>
        void PrepayOrder(OrdersStatusAlter orderStatusAlter, Gathering gathering, GatheringOrder gatheringOrder, string orderNo, int orderStatusFlag);
        #endregion

        #region 修正加工单
        /// <summary>
        /// 名    称: RealFactureOrder
        /// 功能概要: 修正加工单
        /// 作    者: 付强
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Order">要修正的工单</param>
        /// <param name="orderStatusAlter">工单状态变更履历</param>
        void RealFactureOrder(Order order, OrdersStatusAlter orderStatusAlter);
        #endregion

        #region 拼板
        /// <summary>
        /// 名    称: PatchUpOrder
        /// 功能概要: 拼版
        /// 作    者: 付强
        /// 创建时间: 2007-10-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="realOrderItemList">实际工单明细</param>
        /// <param name="orderStatusAlter">工单状态变更履历</param>
        /// <param name="orderNo">工单号</param>
        void PatchUpOrder(IList<RealOrderItem> realOrderItemList, OrdersStatusAlter orderStatusAlter, string orderNo);
        #endregion

        #region 废张登记
        /// <summary>
        /// 名    称: TrashPaperRecord
        /// 功能概要: 废张登记
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="realOrderItemList">实际工单明细</param>
        /// <param name="trashPaperEmployeeList">雇员废张信息</param>
        /// <param name="realOrderItemTrashReasonList">实际工单明细废张原因</param>
        /// <param name="orderStatusAlter">工单状态变更履历</param>
        /// <param name="orderNo">工单号</param>
        void TrashPaperRecord(IList<RealOrderItem> realOrderItemList, IList<TrashPaperEmployee> trashPaperEmployeeList, IList<RealOrderItemTrashReason> realOrderItemTrashReasonList, OrdersStatusAlter orderStatusAlter, string orderNo);

        #endregion

        #region 工单送货
        /// <summary>
        /// 名    称: DeliveryOrder
        /// 功能概要: 工单送货
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="deliveryOrderList"></param>
        void DeliveryOrder(IList<DeliveryOrder> deliveryOrderList);
        /// <summary>
        /// 名    称: UpdateDeliveryOrder
        /// 功能概要: 核销工单  活没有送出
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="deliveryOrder"></param>
        void UpdateDeliveryOrder(DeliveryOrder deliveryOrder);
        /// <summary>
        /// 名    称:CancelAfterVerification
        /// 功能概要: 核销工单 活已经送出
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="deliveryOrder"></param>
        /// <param name="orderStatusAlter">状态变更履历</param>
        /// <param name="strOrderNo">工单号</param>
        /// <param name="orderStatusFlag">工单状态</param>
        void CancelAfterVerification(DeliveryOrder deliveryOrder, OrdersStatusAlter orderStatusAlter, string strOrderNo, int orderStatusFlag);
        /// <summary>
        /// 名    称: GetDeliveryOrder
        /// 功能概要: 根据工单号获得送货状态信息
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        DeliveryOrder GetDeliveryOrder(string strOrderNo);
        #endregion

        #region 返回价格因素的文本值
        /// <summary>
        /// 名    称: GetFactorValueText
        /// 功能概要: 返回相应的价格因素的文本值
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// </summary>
        /// <param name="orderItemList">工单价格因素列表</param>
        void GetFactorValueText(IList<OrderItem> orderItemList);
        /// <summary>
        /// 名    称: GetFactorValueText
        /// 功能概要: 返回相应的价格因素的文本值
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="realOrderItemList">实际工单价格因素列表</param>
        void GetFactorValueText(IList<RealOrderItem> realOrderItemList);
        #endregion

        #region 获取工单信息

        /// <summary>
        /// 名    称: SelectOrderIdByOrderNo
        /// 功能概要: 通过工单号查找工单ID
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        /// <returns>工单ID</returns>
        long SelectOrderIdByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: GetOrderInfoByOrderNo
        /// 功能概要: 通过工单号查找工单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        /// <returns>工单信息</returns>
        Order GetOrderInfoByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: GetOrderItemListByOrderNo
        /// 功能概要: 通过工单号查询工单明细信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        /// <returns>工单明细</returns>
        IList<OrderItem> GetOrderItemListByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: GetOrderItemByOrderNo
        /// 功能概要: 通过工单号查询工单明细信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        /// <returns>工单明细</returns>
        IList<OrderItem> GetOrderItemByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: GetOrderItemEmployeeByOrderNo
        /// 功能概要: 查找工单明细的参与人员
        /// 作    者: 付强
        /// 创建时间: 2008-11-2
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        /// <returns></returns>
        IList<OrderItemEmployee> GetOrderItemEmployeeByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: GetOrderItemFactorValueByOrderNo
        /// 功能概要: 通过工单号查询工单明细因素的值
        /// 作    者: 付强
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        /// <returns>工单明细因素值列表</returns>
        IList<OrderItem> GetOrderItemFactorValueByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: GetOrderItemPrintRequireByOrderNo
        /// 功能概要: 通过工单号查询工单明细的印制要求
        /// 作    者: 付强
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        /// <returns>工单明细的印制要求</returns>
        IList<OrderItemPrintRequireDetail> GetOrderItemPrintRequireByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: 
        /// 功能概要: 查找工单明细的相关人员
        /// 作    者: 付强
        /// 创建时间: 2007-11-2
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployee"></param>
        /// <returns>工单明细雇员列表</returns>
        IList<OrderItemEmployee> SelectOrderItemEmployee(OrderItemEmployee orderItemEmployee);

        #endregion

        #region 获取实际工单信息
        /// <summary>
        /// 名    称: GetRealOrderItemByOrderId
        /// 功能概要: 通过OrderId获取实际工单名细
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="orderId">工单Id</param>
        /// <returns>实际工单明细</returns>
        IList<RealOrderItem> GetRealOrderItemByOrderId(long orderId);
        /// <summary>
        /// 名    称:GetRealOrderItemFactorValueByOrderId
        /// 功能概要: 通过OrderId获取实际工单明细因素的值
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="orderId">工单ID</param>
        /// <returns>实际工单明细</returns>
        IList<RealOrderItem> GetRealOrderItemFactorValueByOrderId(long orderId);
        /// <summary>
        /// 名    称: GetRealOrderItemPrintRequire
        /// 功能概要: 通过OrderId获取实际工单明细印制要求的值
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="orderId">工单ID</param>
        /// <returns>工单明细的印制要求</returns>
        IList<RealOrderItemPrintRequire> GetRealOrderItemPrintRequire(long orderId);
        /// <summary>
        /// 名    称: GetRealOrderItemEmployeebyOrderId
        /// 功能概要: 通过OrderId获取实际工单明细的人员
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="orderId">工单Id</param>
        /// <returns>实际工单明细的雇员</returns>
        IList<RealOrderItemEmployee> GetRealOrderItemEmployeebyOrderId(long orderId);


        #endregion

        //#region 通过Customer_Id查询Orders信息
        ///// <summary>
        ///// 名    称: SearchOrderByCustomerId
        ///// 功能概要: 通过Customer_Id查询Orders信息
        ///// 作    者: 刘伟
        ///// 创建时间: 2007-9-28
        ///// 修正履历:
        ///// 修正时间:
        ///// </summary>
        ///// <param name="Id">CustomerId</param>
        ///// <returns>符合条件的工单列表</returns>
        //IList<Order> SearchOrderByCustomerId(long Id);
        //#endregion

        #region 通过会员卡号查找相关客户信息
        /// <summary>
        /// 名    称: SelectCustomerInfoByMemberCardNo
        /// 功能概要: 通过会员卡号查找相关客户信息
        /// 作    者: 付强
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <returns>返回会员信息</returns>
        MemberCard SelectCustomerInfoByMemberCardNo(string memberCardNo);
        #endregion

        #endregion

        /// <summary>
        /// 名    称: SearchOrdersItem
        /// 功能概要: 工单查询(财务查询)
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        IList<Order> SearchOrdersItem(System.Collections.Hashtable condition);
        /// <summary>
        /// 名    称: SearchAmounts
        /// 功能概要: 通过工单号查询消费数量
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="orderList"></param>
        /// <returns></returns>
        /// 
        string SearchAmounts(IList<Order> orderList);
        
        /// <summary>
        /// 通过CustomerId查询在Orders中的数
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-11
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        int SearchCustomerInOrder(long Id);

        /// <summary>
        /// 通过OrderId获取工单名细
        /// </summary>
        /// <remarks>
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-20
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>        
        IList<OrderItem> GetCashOrderItemByOrderId(string strOrderNo);
 
        /// <summary>
        /// 通过OrderId获取工单明细因素的值
        /// </summary>
        /// <remarks>
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-20
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<OrderItem> GetCashOrderItemFactorValueByOrderId(string strOrderNo);

        /// <summary>
        /// 通过OrderId获取工单明细印制要求的值
        /// </summary>
        /// <remarks>
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-20
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<OrderItemPrintRequireDetail> GetCashOrderItemPrintRequire(string strOrderNo);

        /// <summary>
        /// 通过OrderId获取工单明细的人员
        /// </summary>
        /// <remarks>
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-20
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<OrderItemEmployee> GetCashOrderItemEmployeebyOrderId(string strOrderNo);
 
        /// <summary>
        /// 查找某一个会员卡下的优惠活动
        /// </summary>
        /// <param name="orderId">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        IList<MemberCardConcession> SelectMemberCardConcessionByPriceIdAndConcessionId(MemberCardConcession memberCardConcession);
        /// <summary>
        /// 会员卡消费
        /// </summary>
        /// <param name="orderId">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        void UpdateMemberCardConsume(MemberCardConcession memberCardConcession, MemberCard memberCard);

        /// <summary>
        /// 计算会员卡刷卡次数
        /// </summary>
        /// <param name="MemberCardNo">MemberCardNo</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        int SearchMemberCardBrushNumber(string MemberCardNo);
 
        /// <summary>
        /// 获取工单下实际已预付款
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        decimal GetPrePayAmount(Order order);

        /// <summary>
        /// 获取所有需要预付款的工单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        IList<Order> GetAllNeedPrePayOrders(Order order);

        /// <summary>
        /// 获取所有需要预付款的工单的总数
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        long GetAllNeedPrePayOrdersCount(Order order);

        /// <summary>
        /// 合计订单总金额和预收款总金额
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月11日9:03:24
        /// 修正履历: 
        /// 修正时间: 
        ///</remarks>
        Order GetOrderPrepayAmountTotalAndSumAmountTotal(Order order);

        /// <summary>
        /// 获取客户的支付方式
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Customer GetCustomerInfoByCustomerId(long customerId);
        /// <summary>
        /// 包含时机已经预付款金额的order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order SelectOrderInfoByOrderIdPrePaid(long orderId);

		/// <summary>
		/// 名    称: 
		/// 功能概要: 按时间段和客户获取应收款信息的order(限制行数)
		/// 作    者: 张晓林
		/// 创建时间: 2008-11-26
		/// 修正履历: 
		/// 修正时间:
		/// </summary>
		IList<Order> GetAccountReceviableAccordingToTimeSectTotal(Hashtable hashtable);

		/// <summary>
		/// 名    称: 
		/// 功能概要: 获取 按时间段和客户获取应收款信息的总记录数
		/// 作    者: 张晓林
		/// 创建时间: 2008-11-28
		/// 修正履历: 
		/// 修正时间: 
		/// </summary>
		/// <param name="hashCondition"></param>
		/// <returns></returns>
		long GetSearchAccountReceviableInfoCount(Hashtable hashCondition);

		/// <summary>
		/// 名    称: 
		/// 功能概要: 按时间段和客户获取应收款信息的order(不限制行数)
		/// 作    者: 张晓林
		/// 创建时间: 2008-11-29
		/// 修正履历: 
		/// 修正时间:
		/// <summary>
		/// <param name="hashCondition"></param>
		/// <returns></returns>
		IList<Order> GetAllAccountReceiviable(Hashtable hashCondition);

		/// <summary>
		///	(按照日期查询)日报Order(限制行数的)
		/// </summary>
		/// <remarks>
		/// 作    者: 张晓林
		/// 创建时间: 2008-12-2
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		IList<Order> GetDailyPaper(Hashtable hashCondition);

		/// <summary>
		/// (按照日期查询)日报总记录数
		/// </summary>
		/// <remarks>
		/// 作    者: 张晓林
		/// 创建时间: 2008-12-2
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		long GetDailyPaperTotal(Hashtable hashCondition);

        /// <summary>
		/// (按照日期查询)日报Orders(打印)
		/// </summary>
		/// <remarks>
		/// 作    者: 张晓林
		/// 创建时间: 2008-12-4
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
        IList<Order> GetDailyPaperPrint(Hashtable hashCondition);
        /// <summary>
        /// 获取工单的优惠
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        IList<PaymentConcession> GetOrderPaymentConcessionByOrderId(long ordersId);
        
        IList<User> GetAllUser();

        /// <summary>
        /// 获取当前工单的加工类型
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// </remarks>
        string GetProcessContent(long orderItemId);

        /// <summary>
        /// 通过工单明细id获取工单明细下所有的雇工
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// </remarks>
        IList<Employee> GetOrderItemEmployeeByOrderItemId(long orderItemId);

		#region 获取未完成的订单及相关价格因素信息

		/// <summary>
		/// 获取未完成的订单及相关价格因素信息
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-2-11
		/// </remarks>
		IList<OrderItem> GetNotFinishedOrderWithInfo();
		#endregion

        /// <summary>
        /// 名    称: GetCustomerIdByCustomerName
        /// 功能概要: 根据客户名称获取客户信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月9日16:19:38
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        Customer GetCustomerInfoByName(string customerName);

        /// <summary>
        /// 名    称: GetCustomerPayTypeByCustomerId
        /// 功能概要: 根据客户Id获取客户支付方式
        /// 作    者: 张晓林
        /// 创建时间: 2009年8月24日9:30:14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long GetCustomerPayTypeByCustomerId(long customerId);

         /// <summary>
        /// 返回工单(返回到"修正"状态)
        /// </summary>
        /// <param name="orderId"></param>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间: 2009年10月12日9:49:24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        long ReurnOrderToNoblankoutrecord(long orderId);

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
        void CancelNotPaidTicket(long orderId);
	}
}

