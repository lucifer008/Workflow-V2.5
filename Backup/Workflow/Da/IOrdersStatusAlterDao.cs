using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDERS_STATUS_ALTER 对应的Dao 接口
	/// </summary>
    public interface IOrdersStatusAlterDao : IDaoBase<OrdersStatusAlter>
    {
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
        void UpdateOrderStatusById(Hashtable hashCondition); 
        
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

    }
}
