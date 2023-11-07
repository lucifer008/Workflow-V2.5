#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
#endregion

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ORDER_TIMEOUT_ALARM_RECORD (订单超时记录) 对应的Dao 实现
	/// </summary>
    public class OrderTimeoutAlarmRecordDaoImpl : Workflow.Da.Base.DaoBaseImpl<OrderTimeoutAlarmRecord>, IOrderTimeoutAlarmRecordDao
    {
        /// <summary>
        /// 检查订单是否存在
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2009年12月3日13:20:39
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public bool CheckOrderTimeoutAlarmRecordIsExist(long orderId) 
        {
            OrderTimeoutAlarmRecord otar = new OrderTimeoutAlarmRecord();
            otar.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            otar.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            otar.OrdersId = orderId;
            long rCount = sqlMap.QueryForObject<long>("OrderTimeoutAlarmRecord.CheckOrderTimeoutAlarmRecordIsExist", otar);
            if (0!=rCount) return true;
            return false;
        }

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
        public IList<Order> GetAllNotSucessedOrdersList(Order order) 
        {
            if (null == Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser) return null;
            order.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Order>("OrderTimeoutAlarmRecord.GetAllNotSucessedOrdersList", order);
        }
    }
}