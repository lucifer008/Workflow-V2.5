using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table POSITION 对应的Dao 接口
	/// </summary>
    public interface IPositionDao : IDaoBase<Position>
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
        IList<Employee> GetEmployeeListByPositionId(Hashtable condition);
          #endregion
    }
}
