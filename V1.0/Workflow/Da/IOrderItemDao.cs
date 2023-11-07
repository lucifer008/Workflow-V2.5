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
        /// 功能概要: 通过订单号查询工单数量
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        string SelectAmountByOrderId(long Id);

        /// <summary>
        /// 按照工单号 查询欠发票信息
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
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2008-12-24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        void DrawTicket(Order order);
        /// <summary>
        /// 结算工单时更新工单明细
        /// 作     者:付强
        /// 创建时间:2008-12-29
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        /// <param name="oi"></param>
        void UpdateOrderItemForCloseOrder(OrderItem oi);

        /// <summary>
        /// 按照收银人查询工单收款信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Order> SearchOrderByCashPerson(Order order);

        /// <summary>
        /// 按照收银人查询工单收款信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long SearchOrderByCashPersonRowCount(Order order);

        /// <summary>
        /// 按照收银人查询工单收款信息(打印)
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
	}
}
