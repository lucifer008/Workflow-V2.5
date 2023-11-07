using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.OrderManage
{
    /// <summary>
    /// 名    称: ISearchOrderService
    /// 功能概要: 工单管理中工单查询的Service的接口
    /// 作    者: 付强
    /// 创建时间: 2009-1-19
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public interface ISearchOrderService
    {
        #region 工单查询
        /// <summary>
        /// 名    称: SearchOrdersInfo
        /// 功能概要: 工单查询(工单管理)
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-8
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>工单列表</returns>
        IList<Order> SearchOrdersInfo(Hashtable condition);
        /// <summary>
        /// 名    称: SearchOrdersInfoNo
        /// 功能概要: 工单查询(工单管理)
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-8
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>工单列表</returns>
        IList<Order> SearchOrdersInfoNo(Hashtable condition);
        /// <summary>
        /// 名    称: SearchDelivery
        /// 功能概要: 通过工单号查询送货人
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="NO">工单号</param>
        /// <returns>送货人的名称</returns>
        string SearchDelivery(string NO);
        /// <summary>
        /// 名    称: GetSearchOrderInfoCount
        /// 功能概要: 查询符合条件的工单总数
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>符合条件的工单总数</returns>
        long GetSearchOrderInfoCount(Hashtable condition);

        #endregion

		#region 获取订单列表通过订单状态

		/// <summary>
		/// 获取订单列表通过订单状态
		/// </summary>
		/// <param name="status">工单状态</param>
		/// <returns>OrderList</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.23
		/// </remarks>
		IList<Order> GetOrderListByStatus(int status);

		#endregion
	}


}
