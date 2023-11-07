using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table REAL_ORDER_ITEM_PRINT_REQUIRE 对应的Dao 接口
	/// </summary>
    public interface IRealOrderItemPrintRequireDao : IDaoBase<RealOrderItemPrintRequire>
    {
        /// <summary>
        /// 通过OrderId删除实际工单明细印制要求
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-12
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void DeleteRealOrderItemPrintRequireByOrderId(long orderId);
        /// <summary>
        /// 通过OrderId获取实际工单明细印制要求的值
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<RealOrderItemPrintRequire> GetRealOrderItemPrintRequire(long orderId);
    }
}
