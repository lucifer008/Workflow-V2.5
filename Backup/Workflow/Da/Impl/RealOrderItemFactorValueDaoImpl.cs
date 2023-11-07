using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table REAL_ORDER_ITEM_FACTOR_VALUE 对应的Dao 实现
	/// </summary>
    public class RealOrderItemFactorValueDaoImpl : Workflow.Da.Base.DaoBaseImpl<RealOrderItemFactorValue>, IRealOrderItemFactorValueDao
    {
        public void DeleteRealOrderItemFactorValueByOrderId(long orderId)
        {
            base.sqlMap.Delete("RealOrderItemFactorValue.DeleteRealOrderItemFactorValueByOrderId", orderId);
        }
    }
}
