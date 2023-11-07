using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
/// <summary>
/// 名    称: EmployeePositionDaoImpl
/// 功能概要: 雇员职位关系接口IEmployeePositionDao实现类
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table EMPLOYEE_POSITION 对应的Dao 实现
	/// </summary>
    public class EmployeePositionDaoImpl : Workflow.Da.Base.DaoBaseImpl<EmployeePosition>, IEmployeePositionDao
    {
        #region //添加雇员
        /// <summary>
        /// 添加雇员
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="strPosition"></param>
		public void AddEmployeePosition(Employee employee,string[] strPosition) 
		{
			EmployeePosition employeePosition = new EmployeePosition();
			foreach(string str in strPosition)
			{
				employeePosition.PositionId = Convert.ToInt32(str);
				employeePosition.EmployeeId = employee.Id;
              this.Insert(employeePosition);
			}
        }
        #endregion

        #region//根据雇员Id删除雇员岗位信息
        /// <summary>
        /// 根据雇员Id删除雇员岗位信息
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="strPosition"></param>
        ///<remarks>
        /// 作     者：张晓林
        /// 创建时间:2009-1-8
        /// 修正履历：
        /// 修正时间：
        ///</remarks> 
        public void DeleteEmployeePositionByEmployeeId(Employee employee) 
        {
            sqlMap.Delete("EmployeePosition.DeleteEmplPosByEmployeeId", employee);
        }
        #endregion

        #region //删除雇员岗位信息
        /// <summary>
        /// 删除雇员岗位信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月9日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void DeleteEmployeePosition(Employee employee) 
        {
            sqlMap.Delete("EmployeePosition.DeleteEmployeePositionByEmployeeId", employee);
        }
        #endregion

    }
}
