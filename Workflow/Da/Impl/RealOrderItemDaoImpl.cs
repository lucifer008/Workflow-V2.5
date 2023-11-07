using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table REAL_ORDER_ITEM 对应的Dao 实现
	/// </summary>
    public class RealOrderItemDaoImpl : Workflow.Da.Base.DaoBaseImpl<RealOrderItem>, IRealOrderItemDao
    {
        public void DeleteRealOrderItemByOrderId(long orderId)
        {
            sqlMap.Delete("RealOrderItem.DeleteRealOrderItemByOrderId", orderId);
        }

        public IList<RealOrderItem> GetRealOrderItemByOrderId(long orderId)
        {
            return sqlMap.QueryForList<RealOrderItem>("RealOrderItem.GetRealOrderItemByOrderId", orderId);
        }

        public IList<RealOrderItem> GetRealOrderItemFactorValueByOrderId(long orderId)
        {
            return sqlMap.QueryForList<RealOrderItem>("RealOrderItem.GetRealOrderItemFactorValueByOrderId", orderId);
        }
        public void UpdateTrashPapersOfRealOrderItemById(RealOrderItem realOrderItem)
        {
            sqlMap.Update("RealOrderItem.UpdateRealOrderItemByRealOrderItemId", realOrderItem);
        }

    }
}
