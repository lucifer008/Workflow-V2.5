using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Action.Employee.Model;
using Workflow.Service.SystemPermission.EmployeeManage;
/// <summary>
/// 名    称: EmployeeAction
/// 功能概要: 雇员操作Action
/// 作    者: 张晓林
/// 创建时间: 2009-01-21
/// 修正履历: 
/// 修正时间: 
/// </summary>
namespace Workflow.Action.Employee
{
    public class EmployeeAction
    {
        #region //Model

        private EmployeeModel model = new EmployeeModel();
        public EmployeeModel Model
        {
            set { model = value; }
            get { return model; }
        }
        #endregion

        #region //注入Service
        private IEmployeeService employeeService;
        public IEmployeeService EmployeeService 
        {
            set { employeeService = value; }
        }

        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }
        #endregion

        #region //添加一个雇员
        /// <summary>
        /// 添加一个雇员
        /// </summary>
        public void AddEmployee(string[] strPosition)
        {
            employeeService.AddEmployee(model.Employee, strPosition);
        }
        #endregion

        #region //按照条件查询雇员信息
        /// <summary>
        /// 按照条件查询雇员信息
        /// </summary>
        public void SearchEmployeeInfo()
        {
            model.EmployeeList = employeeService.SearechEmployeeInfo(model.Employee);
        }

        /// <summary>
        /// 获取雇员信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月9日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long SearchEmployeeInfoRowCount()
        {
            return employeeService.SearchEmployeeRowCount(model.Employee);
        }

        /// <summary>
        /// 根据雇员Id获取该雇员的所有岗位字符串
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public string[] GetEmployeePositionStringByEmployeeId(long employeeId) 
        {
            string[] emList = new string[2];
            int count = 0;
            foreach (Workflow.Da.Domain.Employee em in employeeService.SearchEmployeePositionInfo())
            {
                if(employeeId==em.Employeeid)
                {
                    if (0 == count)
                    {
                        emList[0] +=em.Positionid;
                        emList[1] += em.PositionName;
                    }
                    else 
                    {
                        emList[0] += "/" + em.Positionid;
                        emList[1] += "/"+em.PositionName;
                    }
                    count++;
                }
            }
            return emList;
        }
        #endregion

        #region //修改雇员信息
        /// <summary>
        /// 修改雇员信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月8日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void UpdateEmployee(string[] strPosition)
        {
            employeeService.UpdateEmployee(model.Employee, strPosition);
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
        public void DeleteEmployee()
        {
            employeeService.DeleteEmployee(model.Employee);
        }
        #endregion

        #region //获取所有岗位列表
        /// <summary>
        /// 获取所有岗位
        /// </summary>
        public void GetAllPosition()
        {
            model.PositionList = masterDataService.GetPositionList();
        }
        #endregion

        #region //获取所有雇员列表
        /// <summary>
        /// 获取所有雇员列表
        /// </summary>
        public void GetAllEmployee()
        {
            model.EmployeeList = employeeService.GetAllEmployee();
        }

        #endregion

    }
}
