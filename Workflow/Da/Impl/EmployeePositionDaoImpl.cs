using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
/// <summary>
/// ��    ��: EmployeePositionDaoImpl
/// ���ܸ�Ҫ: ��Աְλ��ϵ�ӿ�IEmployeePositionDaoʵ����
/// ��    ��: 
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table EMPLOYEE_POSITION ��Ӧ��Dao ʵ��
	/// </summary>
    public class EmployeePositionDaoImpl : Workflow.Da.Base.DaoBaseImpl<EmployeePosition>, IEmployeePositionDao
    {
        #region //��ӹ�Ա
        /// <summary>
        /// ��ӹ�Ա
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

        #region//���ݹ�ԱIdɾ����Ա��λ��Ϣ
        /// <summary>
        /// ���ݹ�ԱIdɾ����Ա��λ��Ϣ
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="strPosition"></param>
        ///<remarks>
        /// ��     �ߣ�������
        /// ����ʱ��:2009-1-8
        /// ����������
        /// ����ʱ�䣺
        ///</remarks> 
        public void DeleteEmployeePositionByEmployeeId(Employee employee) 
        {
            sqlMap.Delete("EmployeePosition.DeleteEmplPosByEmployeeId", employee);
        }
        #endregion

        #region //ɾ����Ա��λ��Ϣ
        /// <summary>
        /// ɾ����Ա��λ��Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��9��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void DeleteEmployeePosition(Employee employee) 
        {
            sqlMap.Delete("EmployeePosition.DeleteEmployeePositionByEmployeeId", employee);
        }
        #endregion

    }
}
