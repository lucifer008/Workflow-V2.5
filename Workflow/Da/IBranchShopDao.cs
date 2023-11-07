using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table BRANCH_SHOP ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IBranchShopDao : IDaoBase<BranchShop>
    {
        /// <summary>
        /// ͨ��CompanyId��ȡ�������зֵ���Ϣ
        /// </summary>
        /// <param name="companyId">��˾ID</param>
        /// <returns></returns>
        IList<BranchShop> GetBranchShopListByCompanyId(long companyId);

        #region//�ֵ���Ϣά��
        /// <summary>
        /// ��   ��:  SearchBranchShop
        /// ���ܸ�Ҫ: ��ȡ�ֵ���Ϣ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��11��11:39:44
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<BranchShop> SearchBranchShop(BranchShop branchShop);

        /// <summary>
        /// ��   ��:  SearchBranchShopRowCount
        /// ���ܸ�Ҫ: ��ȡ�ֵ���Ϣ�б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��11��11:39:44
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchBranchShopRowCount(BranchShop branchShop);
        #endregion
    }
}
