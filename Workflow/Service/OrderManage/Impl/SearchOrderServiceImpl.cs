using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;


namespace Workflow.Service.OrderManage
{
    /// <summary>
    /// 名    称: SearchOrderServiceImpl
    /// 功能概要: 订单管理中订单查询的Service
    /// 作    者: 付强
    /// 创建时间: 2009-1-19
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class SearchOrderServiceImpl : ISearchOrderService
    {

        #region 类成员
        private IOrderDao orderDao;
        public IOrderDao OrderDao
        {
            set { orderDao = value; }
        }
        #endregion

        #region 订单查询

        /// <summary>
        /// 名    称: SearchOrdersInfo
        /// 功能概要: 订单查询
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-8
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        public IList<Order> SearchOrdersInfo(System.Collections.Hashtable condition)
        {

            return orderDao.SearchOrdersInfo(condition);
        }
        /// <summary>
        /// 名    称: SearchOrdersInfoNo
        /// 功能概要: 订单查询(订单管理)
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-8
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>订单列表</returns>
        public IList<Order> SearchOrdersPrint(System.Collections.Hashtable condition)
        {
            return orderDao.SearchOrdersInfoPrint(condition);
        }
        /// <summary>
        /// 名    称: SearchDelivery
        /// 功能概要: 通过订单号查询送货人
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="NO"></param>
        /// <returns></returns>
        public string SearchDelivery(string NO)
        {
            return orderDao.SearchDelivery(NO);
        }
        /// <summary>
        /// 名    称: GetSearchOrderInfoCount
        /// 功能概要: 查询符合条件的订单总数
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>符合条件的订单总数</returns>
        public long GetSearchOrderInfoCount(Hashtable condition)
        {
            //int SelectId = Convert.ToInt32(condition["SelectCondition"]);
            //switch (SelectId)
            //{
            //    case 0:
            //        {
            //            condition["SelectCondition"] = "<";
            //            break;
            //        }
            //    case 1:
            //        {
            //            condition["SelectCondition"] = "<=";
            //            break;
            //        }
            //    case 2:
            //        {
            //            condition["SelectCondition"] = "=";
            //            break;
            //        }
            //    case 3:
            //        {
            //            condition["SelectCondition"] = ">=";
            //            break;
            //        }
            //    case 4:
            //        {
            //            condition["SelectCondition"] = ">";
            //            break;
            //        }
            //}
            return orderDao.GetSearchOrderInfoCount(condition);
        }
        #endregion

		#region 获取订单列表通过订单状态

		/// <summary>
		/// 获取订单列表通过订单状态
		/// </summary>
		/// <returns>OrderList</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.23
		/// </remarks>
		public IList<Order> GetOrderListByStatus(Hashtable map)
		{
			return orderDao.GetOrderListByStatus(map);
		}

		#endregion
	}
}
