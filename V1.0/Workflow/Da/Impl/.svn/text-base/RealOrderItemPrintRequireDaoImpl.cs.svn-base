using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table REAL_ORDER_ITEM_PRINT_REQUIRE 对应的Dao 实现
	/// </summary>
    public class RealOrderItemPrintRequireDaoImpl : Workflow.Da.Base.DaoBaseImpl<RealOrderItemPrintRequire>, IRealOrderItemPrintRequireDao
    {
        public void DeleteRealOrderItemPrintRequireByOrderId(long orderId)
        {
            sqlMap.Delete("RealOrderItemPrintRequire.DeleteRealOrderItemPrintRequireByOrderId", orderId);
        }
        public IList<RealOrderItemPrintRequire> GetRealOrderItemPrintRequire(long orderId)
        {
            return sqlMap.QueryForList<RealOrderItemPrintRequire>("RealOrderItemPrintRequire.SelectRealOrderItemPrintRequireByOrderNo", orderId);
        }
    }
}
