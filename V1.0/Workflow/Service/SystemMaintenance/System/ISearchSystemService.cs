using System;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.SystemMaintenance.System
{
    /// <summary>
    /// ��    ��: ISearchSystemService
    /// ���ܸ�Ҫ: ��ȡϵͳ�������ݽӿ�
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��29��17:37:08
    /// �� �� ��: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public interface ISearchSystemService
    {
        #region//Idά��
        /// <summary>
        /// ��   ��:  SearchIdGenerator
        /// ���ܸ�Ҫ: ��ȡId�����б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��10:42:26
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<IdGenerator> SearchIdGenerator(IdGenerator idGenerator);

        /// <summary>
        /// ��   ��:  SearchIdGeneratorRowCount
        /// ���ܸ�Ҫ: ��ȡId�����б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��10:42:26
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchIdGeneratorRowCount(IdGenerator idGenerator);
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
        IList<ApplicationProperty> SearchApplictionPeroptery(ApplicationProperty applicationProperty);

        /// <summary>
        /// ��   ��:  SearchApplictionPeropteryRowCount
        /// ���ܸ�Ҫ: ��ȡӦ�ò�����Ϣ�б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��10:49:29
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchApplictionPeropteryRowCount(ApplicationProperty applicationProperty);
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
        IList<Company> SearchCompany(Company company);

        /// <summary>
        /// ��    �ƣ�SearchCompany
        /// ���ܸ�Ҫ����ȡ��˾��Ϣ�б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��13:24:38
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        long SearchCompanyRowCount(Company company);

        /// <summary>
        /// ��    �ƣ�CheckCompanyIsUsed
        /// ���ܸ�Ҫ����鹫˾�Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��13:24:38
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        long CheckCompanyIsUsed(long companyId);
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

       #region//��Ա��������
        /// <summary>
        /// ��   ��:  SearchMarking
        /// ���ܸ�Ҫ: ��ȡ�����б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��28��11:32:18
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<MarkingSetting> SearchMarkingSetting(MarkingSetting markingSetting);

        /// <summary>
        /// ��   ��:  SearchMarkingSettingRowCount
        /// ���ܸ�Ҫ: ��ȡ�����б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��28��11:32:18
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchMarkingSettingRowCount(MarkingSetting markingSetting);
       #endregion 
   }
}
