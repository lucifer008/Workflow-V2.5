using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
    /// <summary>
    /// ��    ��: ICustomerLevelDao
    /// ���ܸ�Ҫ: �ͻ�����ӿ�
    /// ��    ��: 
    /// ����ʱ��: 
    /// �� �� ��: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public interface ICustomerLevelDao : IDaoBase<CustomerLevel>
    {
        #region//�ͻ�����
        /// <summary>
        /// ��   ��:  SearchCustomerLevel
        /// ���ܸ�Ҫ: ��ȡ�ͻ������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��10:04:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<CustomerLevel> SearchCustomerLevel(CustomerLevel customerLevel);

        /// <summary>
        /// ��   ��:  SearchCustomerLevelRowCount
        /// ���ܸ�Ҫ: ��ȡ�ͻ������б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��10:04:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchCustomerLevelRowCount(CustomerLevel customerLevel);

        /// <summary>
        /// ��   ��:  CheckCustomerLevelIsUse
        /// ���ܸ�Ҫ: ���ͻ������Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��11:35:34
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long CheckCustomerLevelIsUse(long customerLevelId);
        #endregion
    }
}
