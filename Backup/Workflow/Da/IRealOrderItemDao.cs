using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table REAL_ORDER_ITEM 对应的Dao 接口
	/// </summary>
    public interface IRealOrderItemDao : IDaoBase<RealOrderItem>
    {
        /// <summary>
        /// 通过OrderId删除实际订单明细
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-12
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void DeleteRealOrderItemByOrderId(long orderId);
        /// <summary>
        /// 通过OrderId获取实际订单名细
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<RealOrderItem> GetRealOrderItemByOrderId(long orderId);
        /// <summary>
        /// 通过OrderId获取实际订单明细因素的值
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<RealOrderItem> GetRealOrderItemFactorValueByOrderId(long orderId);
        /// <summary>
        /// 通过RealOrderItemId更新TrashPapers
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void UpdateTrashPapersOfRealOrderItemById(RealOrderItem realOrderItem);

    }
}
