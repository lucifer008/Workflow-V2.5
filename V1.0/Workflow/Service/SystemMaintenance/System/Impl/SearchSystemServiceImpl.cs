using System;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;

namespace Workflow.Service.SystemMaintenance.System.Impl
{
    /// <summary>
    /// ��    ��: SearchSystemServiceImpl
    /// ���ܸ�Ҫ: ��ȡϵͳ�������ݽӿ�ʵ��
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��29��17:37:08
    /// �� �� ��: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public class SearchSystemServiceImpl:ISearchSystemService
    {
      
        #region//ע��Dao
        private IIdGeneratorDao idGeneratorDao;
        public IIdGeneratorDao IdGeneratorDao 
        {
            set { idGeneratorDao = value; }
        }

        private IApplicationPropertyDao applicationPropertyDao;
        public IApplicationPropertyDao ApplicationPropertyDao
        {
            set { applicationPropertyDao = value; }
        }

        private ICompanyDao companyDao;
        public ICompanyDao CompanyDao 
        {
            set { companyDao = value; }
        }

        private IBranchShopDao branchShopDao;
        public IBranchShopDao BranchShopDao 
        {
            set { branchShopDao = value; }
        }

        private IMarkingSettingDao markingSettingDao;
        public IMarkingSettingDao MarkingSettingDao 
        {
            set { markingSettingDao = value; }
        }
        #endregion

        #region //Idά��
        /// <summary>
        /// ��   ��:  SearchIdGenerator
        /// ���ܸ�Ҫ: ��ȡId�����б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��10:42:26
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<IdGenerator> SearchIdGenerator(IdGenerator idGenerator) 
        {
            return idGeneratorDao.SearchIdGenerator(idGenerator); ;
        }

        /// <summary>
        /// ��   ��:  SearchIdGeneratorRowCount
        /// ���ܸ�Ҫ: ��ȡId�����б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��10:42:26
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchIdGeneratorRowCount(IdGenerator idGenerator) 
        {
            return idGeneratorDao.SearchIdGeneratorRowCount(idGenerator) ;
        }
        #endregion

        #region//Ӧ�ò���ά��
        /// <summary>
        /// ��   ��:  SearchApplictionPeroptery
        /// ���ܸ�Ҫ: ��ȡӦ�ò�����Ϣ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��10:49:29
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<ApplicationProperty> SearchApplictionPeroptery(ApplicationProperty applicationProperty) 
        {
            return applicationPropertyDao.SearchApplictionPeroptery(applicationProperty);
        }

        /// <summary>
        /// ��   ��:  SearchApplictionPeropteryRowCount
        /// ���ܸ�Ҫ: ��ȡӦ�ò�����Ϣ�б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��10:49:29
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchApplictionPeropteryRowCount(ApplicationProperty applicationProperty) 
        {
            return applicationPropertyDao.SearchApplictionPeropteryRowCount(applicationProperty);
        }
        #endregion

        #region//��˾��Ϣά��
        /// <summary>
        /// ��    �ƣ�SearchCompany
        /// ���ܸ�Ҫ����ȡ��˾��Ϣ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��13:24:38
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public IList<Company> SearchCompany(Company company) 
        {
            return companyDao.SearchCompany(company);
        }

        /// <summary>
        /// ��    �ƣ�SearchCompany
        /// ���ܸ�Ҫ����ȡ��˾��Ϣ�б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��13:24:38
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public long SearchCompanyRowCount(Company company) 
        {
            return companyDao.SearchCompanyRowCount(company);
        }

        /// <summary>
        /// ��    �ƣ�CheckCompanyIsUsed
        /// ���ܸ�Ҫ����鹫˾�Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��13:24:38
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public long CheckCompanyIsUsed(long companyId) 
        {
            return companyDao.CheckCompanyIsUsed(companyId);
        }
        #endregion

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
            return branchShopDao.SearchBranchShop(branchShop);
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
            return branchShopDao.SearchBranchShopRowCount(branchShop);
        }
        #endregion

        #region//��Ա��������
        /// <summary>
        /// ��   ��:  SearchMarking
        /// ���ܸ�Ҫ: ��ȡ�����б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��28��11:32:18
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<MarkingSetting> SearchMarkingSetting(MarkingSetting markingSetting) 
        {
            return markingSettingDao.SearchMarkingSetting(markingSetting);
        }

        /// <summary>
        /// ��   ��:  SearchMarkingSettingRowCount
        /// ���ܸ�Ҫ: ��ȡ�����б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��28��11:32:18
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchMarkingSettingRowCount(MarkingSetting markingSetting) 
        {
            return markingSettingDao.SearchMarkingSettingRowCount(markingSetting);
        }
        #endregion
    }
}
