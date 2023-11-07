#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDER_TIMEOUT_ALARM_RECORD (订单超时记录)对应的Dao 接口
	/// </summary>
	public interface IOrderTimeoutAlarmRecordDao : IDaoBase<OrderTimeoutAlarmRecord>
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
        bool CheckOrderTimeoutAlarmRecordIsExist(long orderId);

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
	}
}