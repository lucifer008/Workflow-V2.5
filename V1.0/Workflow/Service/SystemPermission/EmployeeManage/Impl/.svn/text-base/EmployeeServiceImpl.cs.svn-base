using System;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using Workflow.Da;
using Workflow.Da.Domain;
namespace Workflow.Service.SystemPermission.EmployeeManage.Impl
{
    public class EmployeeServiceImpl:IEmployeeService
    {
        #region //注入Dao
        /// <summary>
        /// 人员
        /// </summary>
        private IEmployeeDao employeeDao;
        public IEmployeeDao EmployeeDao
        {
            set { employeeDao = value; }
        }

        /// <summary>
        ///岗位 
        /// </summary>
        private IEmployeePositionDao employeePositionDao;
        public IEmployeePositionDao EmployeePositionDao
        {
            set { employeePositionDao = value; }
        }
        #endregion

        #region //修改雇员信息
        /// <summary>
        /// 修改雇员信息
        /// </summary>
        /// <param name="employee">雇员</param>
        /// <param name="strPosition">雇员所在的岗位</param>
        /// 

        [Transaction]
        public void UpdateEmployee(Employee employee, string[] strPosition)
        {
            //删除旧的雇员岗位信息
            employeePositionDao.DeleteEmployeePositionByEmployeeId(employee);
            //添加新的雇员岗位信息 
            employee.Id = employee.Employeeid;
            employee.No = "e" + employee.Employeeid;
            employeePositionDao.AddEmployeePosition(employee, strPosition);
            employeeDao.Update(employee);
        }
        #endregion

        #region //删除雇员信息
        /// <summary>
        /// 删除雇员信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月9日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        [Transaction]
        public void DeleteEmployee(Employee employee)
        {
            //首先判断雇员职位是不是多于一个
            employee.Name = employee.Employeeid.ToString();
            //IList<Employee> employeeCount = employeeDao.SearechEmployeeInfo(employee);
            //if (employeeCount.Count == 1)
            //{
            //    
            //}
            employeeDao.DeleteEmployeeInfoByEmployee(employee);
            employeePositionDao.DeleteEmployeePosition(employee);
        }
        #endregion

        #region //查询雇员信息
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
        public IList<Employee> SearechEmployeeInfo(Employee employee)
        {
            return employeeDao.SearechEmployeeInfo(employee);
        }
        #endregion

        #region //获取雇员信息记录数
        /// <summary>
        /// 获取雇员信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月9日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long SearchEmployeeRowCount(Employee employee)
        {
            return employeeDao.SearchEmployeeRowCount(employee);
        }

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
        public IList<Employee> SearchEmployeePositionInfo() 
        {
            return employeeDao.SearchEmployeePositionInfo();
        }
        #endregion

        #region //添加雇员及雇员职位关系
        [Transaction]
        public void AddEmployee(Employee employee, string[] strPosition)
        {
            long max = 0;
            foreach (Employee em in employeeDao.SelectAll())
            {
                if (em.Id >= max)
                {
                    max = em.Id;
                }
            }
            employee.No = "e" + (max + 1);
            employeeDao.Insert(employee);
            //employee.Id = max + 1;
            foreach (string str in strPosition)
            {
                EmployeePosition employeePosition = new EmployeePosition();
                employeePosition.PositionId = Convert.ToInt64(str);
                employeePosition.EmployeeId = employee.Id;
                employeePositionDao.Insert(employeePosition);
            }
            
            //employeePositionDao.AddEmployeePosition(employee, strPosition);
        }
        #endregion 

        #region //检查改雇员是否正在使用
        /// <summary>
        /// 检查改雇员是否正在使用
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月25日14:38:38
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long CheckEmployeeIsNotUse(long employeeId) 
        {
            return employeeDao.CheckEmployeeIsNotUse(employeeId);
        }
        #endregion

        #region //获取所有雇员
        /// <summary>
        /// 获取所有雇员
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月25日14:38:38
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Employee> GetAllEmployee() 
        {
            return employeeDao.GetAllEmployee();
        }
        #endregion

        #region//检查雇员名称是否已经存在
        /// <summary>
        /// 检查雇员是否已经存在
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年9月25日11:37:00
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long checkEmployeeNameIsExist(string employeeName) 
        {
            return employeeDao.checkEmployeeNameIsExist(employeeName);
        }
        #endregion
    }
}
