using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table REAL_ORDER_ITEM_EMPLOYEE 对应的Dao 实现
	/// </summary>
    public class RealOrderItemEmployeeDaoImpl : Workflow.Da.Base.DaoBaseImpl<RealOrderItemEmployee>, IRealOrderItemEmployeeDao
    {
        public void DeleteRealOrderItemEmployeeByOrderId(long orderId)
        {
            sqlMap.Delete("RealOrderItemEmployee.DeleteRealOrderItemEmployeeByOrderId", orderId);
        }
        public IList<RealOrderItemEmployee> GetRealOrderItemEmployeeByOrderId(long orderId)
        {
            return sqlMap.QueryForList<RealOrderItemEmployee>("RealOrderItemEmployee.SelectRealEmployee", orderId);
        }

    }
}
