using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table TRASH_PAPER_EMPLOYEE 对应的Dao 接口
	/// </summary>
    public interface ITrashPaperEmployeeDao : IDaoBase<TrashPaperEmployee>
    {
        /// <summary>
        /// 删除废稿责任人
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-12
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void DeleteTrashPaperEmployeeByOrderId(long orderId);

    }
}
