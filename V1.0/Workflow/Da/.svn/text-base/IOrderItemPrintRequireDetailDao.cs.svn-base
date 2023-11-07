using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDER_ITEM_PRINT_REQUIRE_DETAIL 对应的Dao 接口
	/// </summary>
    public interface IOrderItemPrintRequireDetailDao : IDaoBase<OrderItemPrintRequireDetail>
    {
        IList<OrderItemPrintRequireDetail> GetOrderItemPrintRequireDetailByOrderNo(string strOrderNo);

        /// <summary>
        /// 名    称: 
        /// 功能概要: 通过订单号删除印制要求的值
        /// 作    者: 付强
        /// 创建时间: 2007-10-10
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        void DeleteOrderItemPrintRequireByOrderNo(string strOrderNo);
    }
}
