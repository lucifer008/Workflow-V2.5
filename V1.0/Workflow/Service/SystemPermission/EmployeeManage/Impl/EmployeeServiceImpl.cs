using System;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using Workflow.Da;
using Workflow.Da.Domain;
namespace Workflow.Service.SystemPermission.EmployeeManage.Impl
{
    public class EmployeeServiceImpl:IEmployeeService
    {
        #region //ע��Dao
        /// <summary>
        /// ��Ա
        /// </summary>
        private IEmployeeDao employeeDao;
        public IEmployeeDao EmployeeDao
        {
            set { employeeDao = value; }
        }

        /// <summary>
        ///��λ 
        /// </summary>
        private IEmployeePositionDao employeePositionDao;
        public IEmployeePositionDao EmployeePositionDao
        {
            set { employeePositionDao = value; }
        }
        #endregion

        #region //�޸Ĺ�Ա��Ϣ
        /// <summary>
        /// �޸Ĺ�Ա��Ϣ
        /// </summary>
        /// <param name="employee">��Ա</param>
        /// <param name="strPosition">��Ա���ڵĸ�λ</param>
        /// 

        [Transaction]
        public void UpdateEmployee(Employee employee, string[] strPosition)
        {
            //ɾ���ɵĹ�Ա��λ��Ϣ
            employeePositionDao.DeleteEmployeePositionByEmployeeId(employee);
            //����µĹ�Ա��λ��Ϣ 
            employee.Id = employee.Employeeid;
            employee.No = "e" + employee.Employeeid;
            employeePositionDao.AddEmployeePosition(employee, strPosition);
            employeeDao.Update(employee);
        }
        #endregion

        #region //ɾ����Ա��Ϣ
        /// <summary>
        /// ɾ����Ա��Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��9��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        [Transaction]
        public void DeleteEmployee(Employee employee)
        {
            //�����жϹ�Աְλ�ǲ��Ƕ���һ��
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

        #region //��ѯ��Ա��Ϣ
        /// <summary>
        /// ��ѯ��Ա��Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��9��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        /// 
        public IList<Employee> SearechEmployeeInfo(Employee employee)
        {
            return employeeDao.SearechEmployeeInfo(employee);
        }
        #endregion

        #region //��ȡ��Ա��Ϣ��¼��
        /// <summary>
        /// ��ȡ��Ա��Ϣ��¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��9��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public long SearchEmployeeRowCount(Employee employee)
        {
            return employeeDao.SearchEmployeeRowCount(employee);
        }

        /// <summary>
        /// ��ѯ��Աְλ��Ϣ��Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��3��2��16:09:33
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        /// 
        public IList<Employee> SearchEmployeePositionInfo() 
        {
            return employeeDao.SearchEmployeePositionInfo();
        }
        #endregion

        #region //��ӹ�Ա����Աְλ��ϵ
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

        #region //���Ĺ�Ա�Ƿ�����ʹ��
        /// <summary>
        /// ���Ĺ�Ա�Ƿ�����ʹ��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��25��14:38:38
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public long CheckEmployeeIsNotUse(long employeeId) 
        {
            return employeeDao.CheckEmployeeIsNotUse(employeeId);
        }
        #endregion

        #region //��ȡ���й�Ա
        /// <summary>
        /// ��ȡ���й�Ա
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��25��14:38:38
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Employee> GetAllEmployee() 
        {
            return employeeDao.GetAllEmployee();
        }
        #endregion

        #region//����Ա�����Ƿ��Ѿ�����
        /// <summary>
        /// ����Ա�Ƿ��Ѿ�����
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��9��25��11:37:00
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public long checkEmployeeNameIsExist(string employeeName) 
        {
            return employeeDao.checkEmployeeNameIsExist(employeeName);
        }
        #endregion
    }
}
