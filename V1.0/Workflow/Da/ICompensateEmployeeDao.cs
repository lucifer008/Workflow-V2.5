using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table COMPENSATE_EMPLOYEE ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface ICompensateEmployeeDao : IDaoBase<CompensateEmployee>
    {   
        /// <summary>
        /// ͨ��������ֽIDɾ������������һ��
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-10-19
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        void DeleteByCompensateUsedPaperId(long id);
    }
}
