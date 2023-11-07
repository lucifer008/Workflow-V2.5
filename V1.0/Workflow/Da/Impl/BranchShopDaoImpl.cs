using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table BRANCH_SHOP ��Ӧ��Dao ʵ��
	/// </summary>
    public class BranchShopDaoImpl : Workflow.Da.Base.DaoBaseImpl<BranchShop>, IBranchShopDao
    {
        /// <summary>
        /// ͨ��CompanyId��ȡ�������зֵ���Ϣ
        /// </summary>
        /// <param name="companyId">��˾ID</param>
        /// <returns></returns>
        public IList<BranchShop> GetBranchShopListByCompanyId(long companyId)
        {
            return sqlMap.QueryForList<BranchShop>("BranchShop.SelectBranchShopByCompanyId", companyId);
        }

        #region//�ֵ���Ϣά��
        /// <summary>
        /// ��   ��:  SearchBranchShop
        /// ���ܸ�Ҫ: ��ȡ�ֵ���Ϣ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��11��11:39:44
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<BranchShop> SearchBranchShop(BranchShop branchShop) 
        {
            //branchShop.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            //branchShop.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<BranchShop>("BranchShop.SearchBranchShop", branchShop);
        }

        /// <summary>
        /// ��   ��:  SearchBranchShopRowCount
        /// ���ܸ�Ҫ: ��ȡ�ֵ���Ϣ�б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��11��11:39:44
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchBranchShopRowCount(BranchShop branchShop) 
        {
            return sqlMap.QueryForObject<long>("BranchShop.SearchBranchShopRowCount", branchShop);
        }
        #endregion
    }
}
