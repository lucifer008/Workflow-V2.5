using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// ��    ��: CustomerLevelDaoImpl
    /// ���ܸ�Ҫ: �ͻ�����ӿ�ʵ��
    /// ��    ��: 
    /// ����ʱ��: 
    /// �� �� ��: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public class CustomerLevelDaoImpl : Workflow.Da.Base.DaoBaseImpl<CustomerLevel>, ICustomerLevelDao
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
        public IList<CustomerLevel> SearchCustomerLevel(CustomerLevel customerLevel) 
        {
            customerLevel.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            customerLevel.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<CustomerLevel>("CustomerLevel.SearchCustomerLevel", customerLevel);
        }

        /// <summary>
        /// ��   ��:  SearchCustomerLevelRowCount
        /// ���ܸ�Ҫ: ��ȡ�ͻ������б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��10:04:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchCustomerLevelRowCount(CustomerLevel customerLevel) 
        {
            return sqlMap.QueryForObject<long>("CustomerLevel.SearchCustomerLevelRowCount", customerLevel);
        }

        /// <summary>
        /// ��   ��:  CheckCustomerLevelIsUse
        /// ���ܸ�Ҫ: ���ͻ������Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��11:35:34
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long CheckCustomerLevelIsUse(long customerLevelId) 
        {
            CustomerLevel customerLevel = new CustomerLevel();
            customerLevel.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            customerLevel.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            customerLevel.Id = customerLevelId;
            return sqlMap.QueryForObject<long>("CustomerLevel.CheckCustomerLevelIsUse", customerLevel);
        }
        #endregion
    }
}
