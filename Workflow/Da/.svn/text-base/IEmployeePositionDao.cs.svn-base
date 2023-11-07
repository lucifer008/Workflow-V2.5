using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// 名    称: IEmployeePositionDao
/// 功能概要: 雇员职位关系接口
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table EMPLOYEE_POSITION 对应的Dao 接口
	/// </summary>
    public interface IEmployeePositionDao : IDaoBase<EmployeePosition>
    {
        /// <summary>
        /// 添加雇员职位
        /// </summary>
        /// <param name="e"></param>
        /// <param name="strPosition"></param>
		void AddEmployeePosition(Employee e,string[] strPosition);
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

        void DeleteEmployeePositionByEmployeeId(Employee employee);

        /// <summary>
        /// 删除雇员岗位信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月9日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void DeleteEmployeePosition(Employee employee);
    }
}
