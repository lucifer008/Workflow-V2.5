using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDER_ITEM_EMPLOYEE 对应的Dao 接口
	/// </summary>
    public interface IOrderItemEmployeeDao : IDaoBase<OrderItemEmployee>
    {
        /// <summary>
        /// 名    称: 
        /// 功能概要: 通过订单号删除参与人员
        /// 作    者: 付强
        /// 创建时间: 2007-9-25
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        void DeleteOrderItemEmployeeByOrderNo(OrderItemEmployee orderItemEmployee);
        /// <summary>
        /// 名    称: 
        /// 功能概要: 通过订单号删除参与人员(开单人员除外)
        /// 作    者: 付强
        /// 创建时间: 2008-12-18
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        void DispatchDeleteOrderItemEmployeeByOrderNo(string strOrderNo);
        /// <summary>
        /// 名    称: 
        /// 功能概要: 查找以前该订单明细的相关人员
        /// 作    者: 付强
        /// 创建时间: 2007-9-25
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployee"></param>
        /// <returns></returns>
        IList<OrderItemEmployee> SelectOldEmployee(OrderItemEmployee orderItemEmployee);
        /// <summary>
        /// 名    称: 
        /// 功能概要: 查找订单明细的相关人员
        /// 作    者: 付强
        /// 创建时间: 2007-11-2
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployee"></param>
        /// <returns></returns>
        IList<OrderItemEmployee> SelectOrderItemEmployee(OrderItemEmployee orderItemEmployee);

        /// <summary>
        /// 名    称: 
        /// 功能概要: 查找订单明细的参与人员
        /// 作    者: 付强
        /// 创建时间: 2008-11-2
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        /// <returns></returns>
        IList<OrderItemEmployee> GetOrderItemEmployeeByOrderNo(string strOrderNo);

        IList<OrderItemEmployee> GetOrderItemEmployeeByOrderNo2(string strOrderNo);

        /// <summary>
        /// 名    称: GetEmployeeEmployeeByOrderItemIdOrEmployeeId
        /// 功能概要: 根据EmployeeId和OrderItemId获取检查是否存在这样的OrderItemEmployee
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月7日13:38:29
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployee"></param>
        /// <returns></returns>
        bool GetEmployeeEmployeeByOrderItemIdOrEmployeeId(OrderItemEmployee orderItemEmployee);

        /// <summary>
        /// 名    称: DeleteOrderItemEmployee
        /// 功能概要: 根据OrderId删除OrderItemEmployee
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月7日13:38:29
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
       void DeleteOrderItemEmployee(long orderId);

       /// <summary>
       /// 名    称: GetOrderItemEmployeeListByOrderNo
       /// 功能概要: 根据订单号获取订单明细雇员列表
       /// 作    者：张晓林
       /// 创建时间: 2009年11月23日13:25:42
       /// 修正履历：
       /// 修正时间：
       /// </summary>
       IList<OrderItemEmployee> GetOrderItemEmployeeListByOrderNo(string orderNo);
    }
}
