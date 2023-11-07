using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table REAL_ORDER_ITEM_TRASH_REASON 对应的Dao 实现
	/// </summary>
    public class RealOrderItemTrashReasonDaoImpl : Workflow.Da.Base.DaoBaseImpl<RealOrderItemTrashReason>, IRealOrderItemTrashReasonDao
    {
        public void DeleteRealOrderItemTrashReasonByOrderId(long orderId)
        {
            base.sqlMap.Delete("RealOrderItemTrashReason.DeleteRealOrderItemTrashReasonByOrderId", orderId);
        }
    }
}
