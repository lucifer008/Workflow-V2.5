using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table COMPENSATE_EMPLOYEE 对应的Dao 实现
	/// </summary>
    public class CompensateEmployeeDaoImpl : Workflow.Da.Base.DaoBaseImpl<CompensateEmployee>, ICompensateEmployeeDao
    {
        #region //通过补单用纸ID删除补单责任人一览
        /// <summary>
        /// 通过补单用纸ID删除补单责任人一览
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void DeleteByCompensateUsedPaperId(long id)
        {
            sqlMap.Delete("CompensateEmployee.DeleteByCompensateUsedPaperId", id);
        }
        #endregion

    }
}
