using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using System.Collections;
using Workflow.Support;
/// <summary>
/// 名    称: OrdersStatusAlterDaoImpl
/// 功能概要: 订单状态遍历接口IOrderStatusDao实现类
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ORDERS_STATUS_ALTER 对应的Dao 实现
	/// </summary>
    public class OrdersStatusAlterDaoImpl : Workflow.Da.Base.DaoBaseImpl<OrdersStatusAlter>, IOrdersStatusAlterDao
    {
        #region //根据订单Id更新订单状态为完工
        /// <summary>
        ///根据订单Id更新订单状态为完工
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-23
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void UpdateOrderStatusById(Hashtable hashCondition) 
        {
            hashCondition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            hashCondition.Add("BranchShopId",ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            sqlMap.Update("OrderItem.UpdateOrdersStatusById", hashCondition);
        }
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
        public int GetOrderPrintCountByOrderNo(string strOrderNo) 
        {
            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            orderStatusAlter.Memo = "修正打印订单";
            orderStatusAlter.OrderNo=strOrderNo;
            orderStatusAlter.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            orderStatusAlter.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<int>("OrdersStatusAlter.GetOrderPrintCountByOrderNo", orderStatusAlter);
        }
    }
}
