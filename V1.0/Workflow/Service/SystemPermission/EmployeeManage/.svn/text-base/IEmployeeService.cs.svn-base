using System;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
namespace Workflow.Service.SystemPermission.EmployeeManage
{
    public interface IEmployeeService
    {
        /// <summary>
        /// 添加雇员
        /// </summary>
        /// <param name="employee">雇员</param>
        /// <param name="strPosition">雇员所在的岗位</param>
        void AddEmployee(Employee employee, string[] strPosition);

        /// <summary>
        /// 修改雇员信息
        /// </summary>
        /// <param name="employee">雇员</param>
        /// <param name="strPosition">雇员所在的岗位</param>
        /// 
        void UpdateEmployee(Employee employee, string[] strPosition);

        /// <summary>
        /// 删除雇员信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月9日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        /// 
        void DeleteEmployee(Employee employee);

        /// <summary>
        /// 查询雇员信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月9日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        /// 
        IList<Employee> SearechEmployeeInfo(Employee employee);

        /// <summary>
        /// 查询雇员职位信息信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月2日16:09:33
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        /// 
        IList<Employee> SearchEmployeePositionInfo();

        /// <summary>
        /// 获取雇员信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月9日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long SearchEmployeeRowCount(Employee employee);

        /// <summary>
        /// 检查改雇员是否正在使用
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月25日14:38:38
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long CheckEmployeeIsNotUse(long employeeId);

        /// <summary>
        /// 获取所有雇员
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月25日14:38:38
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Employee> GetAllEmployee();


        /// <summary>
        /// 检查雇员是否已经存在
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年9月25日11:37:00
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long checkEmployeeNameIsExist(string employeeName);

    }
}
