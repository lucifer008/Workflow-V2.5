using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table REAL_ORDER_ITEM_EMPLOYEE 对应的Dao 接口
	/// </summary>
    public interface IRealOrderItemEmployeeDao : IDaoBase<RealOrderItemEmployee>
    {
        /// <summary>
        /// 通过OrderId删除RealOrderItemEmployee
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-12
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void DeleteRealOrderItemEmployeeByOrderId(long orderId);
        /// <summary>
        /// 通过OrderId获取RealOrderItemEmployee
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<RealOrderItemEmployee> GetRealOrderItemEmployeeByOrderId(long orderId);
    }
}
