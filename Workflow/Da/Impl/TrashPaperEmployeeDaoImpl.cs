using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table TRASH_PAPER_EMPLOYEE ��Ӧ��Dao ʵ��
	/// </summary>
    public class TrashPaperEmployeeDaoImpl : Workflow.Da.Base.DaoBaseImpl<TrashPaperEmployee>, ITrashPaperEmployeeDao
    {
        public void DeleteTrashPaperEmployeeByOrderId(long orderId)
        {
            base.sqlMap.Delete("TrashPaperEmployee.DeleteTrashPaperEmployeeByOrderId", orderId);
        }
    }
}
