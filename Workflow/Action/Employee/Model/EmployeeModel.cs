using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;
namespace Workflow.Action.Employee.Model
{
    /// <summary>
    /// 名    称: EmployeeModel
    /// 功能概要: 雇员管理Model
    /// 作    者: 张晓林
    /// 创建时间: 2009-02-04
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class EmployeeModel
    {
        private IList<Workflow.Da.Domain.Employee> employeeList;
        public IList<Workflow.Da.Domain.Employee> EmployeeList
        {
            set { employeeList = value; }
            get { return employeeList; }
        }

        private Workflow.Da.Domain.Employee employee;
        public Workflow.Da.Domain.Employee Employee 
        {
            set { employee = value; }
            get { return employee; }
        }

        private IList<Position> positionList;
        public IList<Position> PositionList
        {
            set { positionList = value; }
            get { return positionList; }
        }

        private IList<EmployeePosition> employeePositionList;
        public IList<EmployeePosition> EmployeePositionList 
        {
            set { employeePositionList = value; }
            get { return employeePositionList; }
        }

        private EmployeePosition employeePosition;
        public EmployeePosition EmployeePosition 
        {
            set { employeePosition = value; }
            get { return employeePosition; }
        }
    }
}
