using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table POSITION ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IPositionDao : IDaoBase<Position>
    {
    	  #region //���ݸ�λ��ȡ��Ա��Ϣ
        /// <summary>
        /// ���ݸ�λ��ȡ��Ա��Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��26��10:39:43
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Employee> GetEmployeeListByPositionId(Hashtable condition);
          #endregion
    }
}
