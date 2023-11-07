using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using System.Collections;
using Workflow.Support;
/// <summary>
/// 名    称: OrdersStatusAlterDaoImpl
/// 功能概要: 工单状态遍历接口IOrderStatusDao实现类
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
        #region //根据工单Id更新工单状态为完工
        /// <summary>
        ///根据工单Id更新工单状态为完工
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
    }
}
