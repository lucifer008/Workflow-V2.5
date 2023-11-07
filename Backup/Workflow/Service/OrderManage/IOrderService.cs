using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
using Workflow.Action.Model;

namespace Workflow.Service.OrderManage
{
    /// <summary>
    /// 名    称: IOrderService
    /// 功能概要: 订单管理Service的接口
    /// 作    者: 付强
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public interface IOrderService
    {
        #region 订单管理

        #region 保存订单
        /// <summary>
        /// 名    称: SaveOrder
        /// 功能概要: 保存订单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order">要保存的订单对象</param>
        /// <param name="orderStatusAlter">订单状态的变更履历对象</param>
        /// <param name="linkMan">联系人</param>
        /// <param name="customer">客户</param>
        void SaveOrder(Order order, OrdersStatusAlter orderStatusAlter, LinkMan linkMan, Customer customer);
        #endregion

        /// <summary>
        /// 名    称: UpdateOrder
        /// 功能概要: 更新订单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order">要更新的订单信息</param>
        void UpdateOrder(Order order);
        /// <summary>
        /// 名    称: DeleteOrder
        /// 功能概要: 通过Id删除订单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="ID">订单ID</param>
        void DeleteOrder(int id);

        #region 本日订单
        /// <summary>
        /// 名    称: SelectDailyOrderPager
        /// 功能概要: 显示近X天未完成订单 带分页
        /// 作    者: 付强
        /// 创建时间: 2008-12-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order">显示订单的过滤条件</param>
        /// <returns>返回符合条件的订单List</returns>
        IList<Order> SelectDailyOrderPager(Order order);
        /// <summary>
        /// 名    称: GetDailyOrderCount
        /// 功能概要: 获取符合条件的本日订单总数
        /// 作    者: 付强
        /// 创建时间: 2008-12-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order">传递过滤条件</param>
        /// <returns>符合过滤条件的订单总数</returns>
        int GetDailyOrderCount(Order order);

        /// <summary>
        /// 获取本日订单列表默认显示的天数
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2010年2月25日15:12:40
        /// 修正履历:
        /// 修正时间：
        /// </remarks>
        int GetDisplayOrderInnerDayCount();
        #endregion

        /// <summary>
        /// 名    称: UpdateOrderStatusByOrderNo
        /// 功能概要: 通过订单号更新订单状态
        /// 作    者: 付强
        /// 创建时间: 2008-9-26
        /// 修正履历:
        /// 修正时间:        
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="OrderStatusFlag">要更新的订单状态</param>
        void UpdateOrderStatusByOrderNo(string strOrderNo, int OrderStatusFlag);
        /// <summary>
        /// 名    称: DispatchDeleteOrderItemEmployeeByOrderNo
        /// 功能概要: 通过订单号删除订单雇员
        /// 作    者: 付强
        /// 创建时间: 2008-9-26
        /// 修正履历:
        /// 修正时间:        
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        void DispatchDeleteOrderItemEmployeeByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: SelectOldEmployee
        /// 功能概要: 获取订单明细的订单雇员
        /// 作    者: 付强
        /// 创建时间: 2008-9-11
        /// 修正履历:
        /// 修正时间:        
        /// </summary>
        /// <param name="orderItemEmployee">查询条件</param>
        /// <returns>返回订单明细的相关雇员</returns>
        IList<OrderItemEmployee> SelectOldEmployee(OrderItemEmployee orderItemEmployee);

        #region 订单返工
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
        /// <param name="strOrderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        void ReDoOrder(OrdersStatusAlter orderStatusAlter, OrdersDuty ordersDuty, IList<OrderItemEmployee> orderItemEmployee, IList<RelationEmployee> relationEmployee, IList<DutyEmployee> dutyEmployeeList, string strOrderNo, int orderStatusFlag);
        #endregion

        #region 分配订单
        /// <summary>
        /// 名    称: DispatchOrder
        /// 功能概要: 分配订单
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployeeList">订单明细的参与人员</param>
        /// <param name="orderStatusAlter">订单状态的变更履历</param>
        /// <param name="relationEmployeeList">订单状态变更的相关人员</param>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="OrderStatusFlag">订单状态</param>
        void DispatchOrder(IList<OrderItemEmployee> orderItemEmployeeList, OrdersStatusAlter orderStatusAlter, IList<RelationEmployee> relationEmployeeList, string strOrderNo, int OrderStatusFlag);

        /// <summary>
        /// 名    称: NewDispatchOrder
        /// 功能概要: 新流程-分配订单
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月7日15:06:46
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        void NewDispatchOrder(Order order,OrdersStatusAlter osa,IList<OrderItemEmployee> orderItemEmployeeList);
        #endregion

        #region //新流程-修正打印
        /// <summary>
        /// 名    称: AdmendmentPrint
        /// 功能概要: 新流程-修正打印
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月7日17:25:53
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        void AdmendmentPrint(Order order, OrdersStatusAlter osa);

        #endregion

        #region//新流程-返回订单
        /// <summary>
        /// 名    称: ReturnOrder
        /// 功能概要: 新流程-返回订单
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月8日10:05:09
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        void ReturnOrder(Order order, OrdersStatusAlter osa);//,bool isPrint,string[] orderItemIdArr);
        #endregion

        #region 订单完工
        /// <summary>
        /// 名    称: FinishOrder
        /// 功能概要: 订单完工
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployeeList">订单明细的参与人员</param>
        /// <param name="orderStatusAlter">订单状态的变更履历</param>
        /// <param name="relationEmployeeList">订单状态变更的相关人员</param>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        void FinishOrder(IList<OrderItemEmployee> orderItemEmployeeList, OrdersStatusAlter orderStatusAlter, IList<RelationEmployee> relationEmployeeList, string strOrderNo, int orderStatusFlag);
        #endregion

        #region 订单作废
        /// <summary>
        /// 名    称: BlankOutOrder
        /// 功能概要: 作废订单
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderStatusAlter">订单状态的变更履历</param>
        /// <param name="relationEmployeeList">订单状态变更的相关人员</param>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        void BlankOutOrder(OrdersStatusAlter orderStatusAlter, IList<RelationEmployee> relationEmployeeList, string strOrderNo, int orderStatusFlag);
        #endregion

        #region 订单预付
        /// <summary>
        /// 名    称: PrepayOrder
        /// 功能概要: 订单预付
        /// 作    者: 付强
        /// 创建时间: 2008-10-27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderStatusAlter">订单状态的变更履历</param>
        /// <param name="gathering">收款记录</param>
        /// <param name="gatheringOrder">订单收款记录</param>
        /// <param name="orderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        void PrepayOrder(OrdersStatusAlter orderStatusAlter, Gathering gathering, GatheringOrder gatheringOrder, string orderNo, int orderStatusFlag);
        #endregion

        #region 修正加订单
        /// <summary>
        /// 名    称: RealFactureOrder
        /// 功能概要: 修正加订单
        /// 作    者: 付强
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Order">要修正的订单</param>
        /// <param name="orderStatusAlter">订单状态变更履历</param>
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
        /// <param name="realOrderItemList">实际订单明细</param>
        /// <param name="orderStatusAlter">订单状态变更履历</param>
        /// <param name="orderNo">订单号</param>
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
        /// <param name="realOrderItemList">实际订单明细</param>
        /// <param name="trashPaperEmployeeList">雇员废张信息</param>
        /// <param name="realOrderItemTrashReasonList">实际订单明细废张原因</param>
        /// <param name="orderStatusAlter">订单状态变更履历</param>
        /// <param name="orderNo">订单号</param>
        void TrashPaperRecord(IList<RealOrderItem> realOrderItemList, IList<TrashPaperEmployee> trashPaperEmployeeList, IList<RealOrderItemTrashReason> realOrderItemTrashReasonList, OrdersStatusAlter orderStatusAlter, string orderNo);

        #endregion

        #region 订单送货
        /// <summary>
        /// 名    称: DeliveryOrder
        /// 功能概要: 订单送货
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="deliveryOrderList"></param>
        void DeliveryOrder(IList<DeliveryOrder> deliveryOrderList);
        /// <summary>
        /// 名    称: UpdateDeliveryOrder
        /// 功能概要: 核销订单  活没有送出
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="deliveryOrder"></param>
        void UpdateDeliveryOrder(DeliveryOrder deliveryOrder);
        /// <summary>
        /// 名    称:CancelAfterVerification
        /// 功能概要: 核销订单 活已经送出
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="deliveryOrder"></param>
        /// <param name="orderStatusAlter">状态变更履历</param>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        void CancelAfterVerification(DeliveryOrder deliveryOrder, OrdersStatusAlter orderStatusAlter, string strOrderNo, int orderStatusFlag);
        /// <summary>
        /// 名    称: GetDeliveryOrder
        /// 功能概要: 根据订单号获得送货状态信息
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
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
        /// <param name="orderItemList">订单价格因素列表</param>
        void GetFactorValueText(IList<OrderItem> orderItemList);
        /// <summary>
        /// 名    称: GetFactorValueText
        /// 功能概要: 返回相应的价格因素的文本值
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="realOrderItemList">实际订单价格因素列表</param>
        void GetFactorValueText(IList<RealOrderItem> realOrderItemList);
        #endregion

        #region 获取订单信息

        /// <summary>
        /// 名    称: SelectOrderIdByOrderNo
        /// 功能概要: 通过订单号查找订单ID
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns>订单ID</returns>
        long SelectOrderIdByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: GetOrderInfoByOrderNo
        /// 功能概要: 通过订单号查找订单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns>订单信息</returns>
        Order GetOrderInfoByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: GetOrderItemListByOrderNo
        /// 功能概要: 通过订单号查询订单明细信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns>订单明细</returns>
        IList<OrderItem> GetOrderItemListByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: GetOrderItemByOrderNo
        /// 功能概要: 通过订单号查询订单明细信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns>订单明细</returns>
        IList<OrderItem> GetOrderItemByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: GetOrderItemEmployeeByOrderNo
        /// 功能概要: 查找订单明细的参与人员
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
        /// 功能概要: 通过订单号查询订单明细因素的值
        /// 作    者: 付强
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns>订单明细因素值列表</returns>
        IList<OrderItem> GetOrderItemFactorValueByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: GetOrderItemPrintRequireByOrderNo
        /// 功能概要: 通过订单号查询订单明细的印制要求
        /// 作    者: 付强
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns>订单明细的印制要求</returns>
        IList<OrderItemPrintRequireDetail> GetOrderItemPrintRequireByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: 
        /// 功能概要: 查找订单明细的相关人员
        /// 作    者: 付强
        /// 创建时间: 2007-11-2
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployee"></param>
        /// <returns>订单明细雇员列表</returns>
        IList<OrderItemEmployee> SelectOrderItemEmployee(OrderItemEmployee orderItemEmployee);

        #endregion

        #region 获取实际订单信息
        /// <summary>
        /// 名    称: GetRealOrderItemByOrderId
        /// 功能概要: 通过OrderId获取实际订单名细
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <returns>实际订单明细</returns>
        IList<RealOrderItem> GetRealOrderItemByOrderId(long orderId);
        /// <summary>
        /// 名    称:GetRealOrderItemFactorValueByOrderId
        /// 功能概要: 通过OrderId获取实际订单明细因素的值
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns>实际订单明细</returns>
        IList<RealOrderItem> GetRealOrderItemFactorValueByOrderId(long orderId);
        /// <summary>
        /// 名    称: GetRealOrderItemPrintRequire
        /// 功能概要: 通过OrderId获取实际订单明细印制要求的值
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns>订单明细的印制要求</returns>
        IList<RealOrderItemPrintRequire> GetRealOrderItemPrintRequire(long orderId);
        /// <summary>
        /// 名    称: GetRealOrderItemEmployeebyOrderId
        /// 功能概要: 通过OrderId获取实际订单明细的人员
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <returns>实际订单明细的雇员</returns>
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
        ///// <returns>符合条件的订单列表</returns>
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

		#region 订单统计查询

		/// <summary>
		/// 名    称: SearchOrdersItem
		/// 功能概要: 订单查询(财务查询)
		/// 作    者: 刘伟
		/// 创建时间: 2007-10-25
		/// 修正履历: 陈汝胤
		/// 修正时间: 
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		/// 
		IList<Order> SearchOrdersItem(Hashtable condition);

		int SearchOrdersItemCount(Hashtable condition);

		Order SearchOrdersItemAmount(Hashtable condition);

		#endregion
        /// <summary>
        /// 名    称: SearchAmounts
        /// 功能概要: 通过订单号查询消费数量
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
        /// 通过OrderId获取订单名细
        /// </summary>
        /// <remarks>
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-20
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>        
        IList<OrderItem> GetCashOrderItemByOrderId(string strOrderNo);
 
        /// <summary>
        /// 通过OrderId获取订单明细因素的值
        /// </summary>
        /// <remarks>
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-20
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<OrderItem> GetCashOrderItemFactorValueByOrderId(string strOrderNo);

        /// <summary>
        /// 通过OrderId获取订单明细印制要求的值
        /// </summary>
        /// <remarks>
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-20
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<OrderItemPrintRequireDetail> GetCashOrderItemPrintRequire(string strOrderNo);

        /// <summary>
        /// 通过OrderId获取订单明细的人员
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
        /// 获取订单下实际已预付款
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        decimal GetPrePayAmount(Order order);

        /// <summary>
        /// 获取所有需要预付款的订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        IList<Order> GetAllNeedPrePayOrders(Order order);

        /// <summary>
        /// 获取所有需要预付款的订单的总数
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
        /// 获取订单的优惠
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        IList<PaymentConcession> GetOrderPaymentConcessionByOrderId(long ordersId);
        
        IList<User> GetAllUser();

        /// <summary>
        /// 获取当前订单的加工类型
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// </remarks>
        string GetProcessContent(long orderItemId);

        /// <summary>
        /// 通过订单明细id获取订单明细下所有的雇工
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

		#region 通过订单id,获取 订单明细的价格因素值

		/// <summary>
		/// 通过订单id,获取 订单明细的价格因素值
		/// </summary>
		/// <param name="orderId">订单id</param>
		/// <returns>订单明细的价格因素值列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-5-19
		/// </remarks>
		IList<OrderItemPriceFactor> GetAllOrderItemPriceFactorByOrderNo(string orderNo);

		#endregion

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
        /// 返回订单(返回到"修正"状态)
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
        /// 名    称: GetOrderItemEmployeeListByOrderNo
        /// 功能概要: 根据订单号获取订单明细雇员列表
        /// 作    者：张晓林
        /// 创建时间: 2009年11月23日13:25:42
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        IList<OrderItemEmployee> GetOrderItemEmployeeListByOrderNo(string orderNo);
 
        /// <summary>
        /// 名    称: GetOrderItemFactorValueListByOrderNO
        /// 功能概要: 根据订单号获取订单明细因素值列表
        /// 作    者：张晓林
        /// 创建时间: 2009年11月23日13:26:05
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        IList<OrderItemFactorValue> GetOrderItemFactorValueListByOrderNO(string orderNo); 

        /// <summary>
        /// 名    称: GetOrderItemMortgageByOrderNo
        /// 功能概要: 根据订单Id获取订单冲减明细
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月25日11:01:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<OrderItemMortgage> GetOrderItemMortgageByOrderNo(long orderId);

        /// <summary>
        /// 记录超过送货时间的订单
        /// </summary>
        /// <param name="orderList">condition</param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月3日11:23:10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        void RecordMaturenessOrders(IList<Order> orderList);

        /// <summary>
        /// 获取当天下单的所有未完成且未作废的订单
        /// </summary>
        /// <param name="order">condition</param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月3日15:54:39
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        IList<Order> GetAllNotSucessedOrdersList(Order order);

        /// <summary>
        /// 通过会员卡号查订单号
        /// </summary>
        /// <param name="strMemberCardNo">会员卡号</param>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2010-1-26
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        string GetOrderNoByMemberCardNo(string strMemberCardNo);

		#region 获取订单

		/// <summary>
		/// 获取订单
		/// </summary>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <param name="paymentType">支付类型</param>
		/// <returns></returns>
		IList<Order> GetOrders(DateTime beginTime, DateTime endTime, int paymentType,int orderStatus,string userName);

		#endregion

        #region//获取前期修正的订单Id
        /// <summary>
        /// 根据订单号获取前期修正的订单Id
        /// </summary>
        /// <param name="orderNo">order</param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月11日15:25:18
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long GetPhophaseOrderId(Order order);
        Order GetOrderById(long orderId); 
        #endregion

        /// <summary>
        /// 获取订单正式打印的次数
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年3月2日14:57:10
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        int GetOrderPrintCountByOrderNo(string strOrderNo);
 
         /// <summary>
        /// 获取订单明细版本最大值
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年3月5日10:19:10
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        int SelectOrderItemMaxVersion(string orderNo);

        /// <summary>
        /// 获取分配员工的所有订单信息
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年4月2日16:56:02
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        OrderItem GetEmployeeReceptionOrderInfo(long employeeId); 

        /// <summary>
        /// 获取分配员工明细
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年4月6日10:21:49
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        IList<Order> GetReceptionOrderDetail(OrderItem oi);

        /// <summary>
        /// 模糊查询订单信息，若检索到多个订单则只返回其中的一个订单
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <param name="isSucessed">是否是完成的订单</param>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年4月10日9:43:01
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        Order BluringSearchOrderByOrderNo(string orderNo, bool isSucessed);


        /// <summary>
        /// 获取当前订单明细的加工类型的前期业绩比列
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年5月11日16:23:51
        /// </remarks>
        decimal GetProcessContentAchievementRate(long orderItemId);

        /// <summary>
        /// 获取送货到期时间/到期颜色/过期颜色
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年5月20日15:59:20
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        string GetDeliverMaturityTime();

        /// <summary>
        /// 根据选择的日期计算选项卡列表
        /// </summary>
        /// <param name="currentDateTime"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年7月6日9:16:14
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Order.DateOptionCard> GetOptionCardList(int currentDateTime);

        /// <summary>
        /// 根据选择的日期计算选项卡列表
        /// </summary>
        /// <param name="currentDateTime"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年7月6日9:16:14
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        string GetCurrentDateString(DateTime dateTime);
    }
}

