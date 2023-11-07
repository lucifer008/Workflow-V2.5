using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDER_ITEM 对应的Dao 接口
	/// </summary>
    public interface IOrderItemDao : IDaoBase<OrderItem>
    {
        IList<OrderItem> GetOrderItemByOrderNo(string strOrderNO);
        IList<OrderItem> GetOrderItemListByOrderNo(string strOrderNo);
        int GetOrderItemCount(string strOrderNo);
        IList<OrderItem> GetOrderItemFactorValueByOrderNo(string strOrderNo);

        /// <summary>
        /// 名    称: 
        /// 功能概要: 通过订单号删除订单明细
        /// 作    者: 付强
        /// 创建时间: 2007-10-10
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        void DeleteOrderItemByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: 
        /// 功能概要: 通过订单号查询订单数量
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        string SelectAmountByOrderId(long Id);

        /// <summary>
        /// 按照订单号 查询欠发票信息
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
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2008-12-24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        void DrawTicket(Order order);
        /// <summary>
        /// 结算订单时更新订单明细
        /// 作     者:付强
        /// 创建时间:2008-12-29
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        /// <param name="oi"></param>
        void UpdateOrderItemForCloseOrder(OrderItem oi);

        /// <summary>
        /// 按照收银人查询订单收款信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Order> SearchOrderByCashPerson(Order order);

        /// <summary>
        /// 按照收银人查询订单收款信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long SearchOrderByCashPersonRowCount(Order order);

        /// <summary>
        /// 按照收银人查询订单收款信息(打印)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Order> SearchOrderByCashPersonPrint(Order order);


		#region 获取未完成的订单及相关价格因素信息 Add Cry

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

    //    /// <summary>
    //    /// 更新订单明细的输出状态
    //    /// </summary>
    //    /// <param name="orderItemIdArr"></param>
    //    /// <remarks>
    //    /// 作    者：张晓林
    //    /// 创建时间：2010年3月2日16:38:15
    //    /// 修正履历：
    //    /// 修正时间：
    //    /// </remarks>
    //    void UpdateOrderItemPrintStatus(string []orderItemIdArr);

        /// <summary>
        ///获取订单下明细中的最大版本号
        /// </summary>
        /// <param name="orderNo"></param>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2010年3月3日17:00:04
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        int SelectOrderItemMaxVersion(string orderNo);

        /// <summary>
        ///插入一条订单明细
        /// </summary>
        /// <param name="orderNo"></param>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2010年3月3日17:20:56
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        void InsertOrderItem(OrderItem orderItem);

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
