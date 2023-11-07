using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
namespace Workflow.Da.Impl
{
    /// <summary>
    /// IPositionDao接口实现
    /// </summary>
    /// <remarks>
    /// 作    者: 张晓林
    /// 创建时间: 2009年2月26日10:39:43
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    public class PositionDaoImpl : Workflow.Da.Base.DaoBaseImpl<Position>, IPositionDao
    {
        #region //根据岗位获取雇员信息
        /// <summary>
        /// 根据岗位获取雇员信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月26日10:39:43
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Employee> GetEmployeeListByPositionId(Hashtable condition) 
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<Employee>("Position.GetEmployeeListByPositionId", condition);
        }
        #endregion
    }
}
