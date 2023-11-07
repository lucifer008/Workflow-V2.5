using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDER_ITEM_FACTOR_VALUE 对应的Dao 接口
	/// </summary>
    public interface IOrderItemFactorValueDao : IDaoBase<OrderItemFactorValue>
    {
        /// <summary>
        /// 名    称: 
        /// 功能概要: 通过订单号删除因素明细的值
        /// 作    者: 付强
        /// 创建时间: 2007-10-10
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        void DeleteOrderItemFactorValueByOrderNo(string strOrderNo);

        /// <summary>
        /// 名    称: GetOrderItemFactorValueListByOrderNO
        /// 功能概要: 根据订单号获取订单明细因素值列表
        /// 作    者：张晓林
        /// 创建时间: 2009年11月23日13:26:05
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        IList<OrderItemFactorValue> GetOrderItemFactorValueListByOrderNO(string orderNo); 
    }
}
