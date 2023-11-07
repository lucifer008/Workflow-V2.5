using System;
using System.Collections.Generic;
using Workflow.Service.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;
using Workflow.Service.SystemMaintenance.OrderBaseData;

namespace Workflow.Action.SystemMaintenance.System
{
    /// <summary>
    /// ��   ��:  SearchSystemAction
    /// ���ܸ�Ҫ: ��ȡϵͳ��������Action
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��29��17:30:01
    /// ��������:
    /// ����ʱ��:
    /// </summary>
    public class SearchSystemAction
    {
        #region//ClassMember
        private SystemModel model = new SystemModel();
        public SystemModel Model 
        {
            set { model = value; }
            get { return model; }
        }
        private ISearchSystemService searchSystemService;
        public ISearchSystemService SearchSystemService 
        {
            set { searchSystemService = value; }
        }

        private ISearchOrderBaseDataService searchOrderBaseDataService;
        public ISearchOrderBaseDataService SearchOrderBaseDataService 
        {
            set { searchOrderBaseDataService = value; }
        }
        #endregion

        #region//Idά��
        /// <summary>
        /// ��   ��:  SearchIdGenerator
        /// ���ܸ�Ҫ: ��ȡId�����б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��10:42:26
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void SearchIdGenerator()
        {
            model.IdGeneratorList = searchSystemService.SearchIdGenerator(model.IdGenerator);
            model.RowCount = searchSystemService.SearchIdGeneratorRowCount(model.IdGenerator);
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
        public void SearchApplictionPeroptery() 
        {
            model.AppliactionPropertyList = searchSystemService.SearchApplictionPeroptery(model.ApplicationProperty);
            model.RowCount = searchSystemService.SearchApplictionPeropteryRowCount(model.ApplicationProperty);
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
        public void SearchCompany() 
        {
            model.CompanyList = searchSystemService.SearchCompany(model.Company);
            model.RowCount = searchSystemService.SearchCompanyRowCount(model.Company);
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
        public void SearchBranchShop() 
        {
            model.BranchShopList = searchSystemService.SearchBranchShop(model.BranchShop);
            model.RowCount=searchSystemService.SearchBranchShopRowCount(model.BranchShop);
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
        public void SearchMarkingSetting()
        {
            model.MarkingSettingList = searchSystemService.SearchMarkingSetting(model.MarkingSetting);
            model.RowCount = searchSystemService.SearchMarkingSettingRowCount(model.MarkingSetting);
        }
        #endregion

        /// <summary>
        /// ��   ��:  SearchProcessContentList
        /// ���ܸ�Ҫ: ��ȡ�ӹ����ݻ����б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��28��11:32:18
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void SearchProcessContentList() 
        {
            model.ProcessContentList = searchOrderBaseDataService.GetAllProcessContent();
        }
    }
}
