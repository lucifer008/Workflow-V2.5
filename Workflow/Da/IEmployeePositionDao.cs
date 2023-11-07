using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// ��    ��: IEmployeePositionDao
/// ���ܸ�Ҫ: ��Աְλ��ϵ�ӿ�
/// ��    ��: 
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table EMPLOYEE_POSITION ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IEmployeePositionDao : IDaoBase<EmployeePosition>
    {
        /// <summary>
        /// ��ӹ�Աְλ
        /// </summary>
        /// <param name="e"></param>
        /// <param name="strPosition"></param>
		void AddEmployeePosition(Employee e,string[] strPosition);
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

        void DeleteEmployeePositionByEmployeeId(Employee employee);

        /// <summary>
        /// ɾ����Ա��λ��Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��9��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void DeleteEmployeePosition(Employee employee);
    }
}
