using System;
using System.Collections.Generic;
using Workflow.Service.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;
using Workflow.Service;
using Workflow.Service.SystemManege.PriceManage;

namespace Workflow.Action.SystemMaintenance.System
{
    /// <summary>
    /// ��   ��:  SystemAction
    /// ���ܸ�Ҫ: ϵͳ�������ݹ���Action
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��29��17:30:01
    /// ��������:
    /// ����ʱ��:
    /// </summary>
    public class SystemAction
    {
        #region//ClassMember
        private SystemModel model = new SystemModel();
        public SystemModel Model 
        {
            set { model = value; }
            get { return model; }
        }
        private ISystemService systemService;
        public ISystemService SystemService 
        {
            set { systemService = value; }
        }

        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }

        private ISelectActiveFactorService selectActiveFactorService;
        public ISelectActiveFactorService SelectActiveFactorService
        {
            set { selectActiveFactorService = value; }
        }
        #endregion

        #region// Idά��

        /// <summary>
        /// ��    �ƣ�InitIdData
        /// ���ܸ�Ҫ����ʼ��Id����
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��13:46:34
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void InitIdData() 
        {
            systemService.InitIdData();
        }

        /// <summary>
        /// ��    �ƣ�UpdateIdGenerator
        /// ���ܸ�Ҫ������Id����������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��16:19:48
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void UpdateIdGenerator()
        {
            systemService.UpdateIdGenerator(model.IdGenerator);
        }

          /// <summary>
        /// ��    �ƣ�DeleteIdGenerator
        /// ���ܸ�Ҫ��ɾ��Id����������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��16:19:48
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void DeleteIdGenerator() 
        {
            systemService.DeleteIdGenerator(model.IdGenerator.Id);
        }
        #endregion

        #region//Ӧ�ó������ά��
        /// <summary>
        /// ��    �ƣ�AddApplicationProperty
        /// ���ܸ�Ҫ�����Ӧ�ó������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��13:52:10
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void AddApplicationProperty() 
        {
            systemService.AddApplicationProperty(model.ApplicationProperty);
        }

        /// <summary>
        /// ��    �ƣ�UpdateApplicationProperty
        /// ���ܸ�Ҫ������Ӧ�ó������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��13:52:10
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void UpdateApplicationProperty()
        {
            systemService.UpdateApplicationProperty(model.ApplicationProperty);
        }

        /// <summary>
        /// ��    �ƣ�LogicDeleteApplicationProperty
        /// ���ܸ�Ҫ���߼�ɾ��Ӧ�ó������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��13:52:10
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void LogicDeleteApplicationProperty()
        {
            systemService.LogicDeleteApplicationProperty(model.ApplicationProperty.Id);
        }

        /// <summary>
        /// ��    �ƣ�InitApplicationPropertyData
        /// ���ܸ�Ҫ����ʼ��Ӧ�ó������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��13:52:10
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void InitApplicationPropertyData() 
        {
            systemService.InitApplicationPropertyData();
        }
        #endregion

        #region//��˾ά��
        /// <summary>
        /// ��    �ƣ�AddCompany
        /// ���ܸ�Ҫ����ӹ�˾
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��14:31:19
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void AddCompany()
        {
            systemService.AddCompany(model.Company);
        }

        /// <summary>
        /// ��    �ƣ�UpdateCompany
        /// ���ܸ�Ҫ�����¹�˾
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��14:31:19
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void UpdateCompany()
        {
            systemService.UpdateCompany(model.Company);
        }

        /// <summary>
        /// ��    �ƣ�LogicDeleteCompany
        /// ���ܸ�Ҫ���߼�ɾ����˾
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��14:31:19
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void LogicDeleteCompany()
        {
            systemService.LogicDeleteCompany(model.Company.Id);
        }

		/// <summary>
		/// ��    �ƣ�GetCompanyInfo
		/// ���ܸ�Ҫ����ȡ��˾��Ϣ
		/// ��    ��: ������
		/// ����ʱ��: 2010��4��28��16:07:19
		/// ��������:
		/// ����ʱ�䣺
		/// </summary>
		public void GetCompanyInfo()
		{
			model.Company = systemService.GetCompanyInfo(model.CompanyId);
		}
        #endregion

        #region//�ֵ���Ϣά��
        /// <summary>
        /// ��    �ƣ�AddBranchShop
        /// ���ܸ�Ҫ����ӷֵ���Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��11��11:50:59
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void AddBranchShop() 
        {
            systemService.AddBranchShop(model.BranchShop);
        }

        /// <summary>
        /// ��    �ƣ�UpdateBranchShop
        /// ���ܸ�Ҫ���޸ķֵ���Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��11��11:50:59
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void UpdateBranchShop()
        {
            systemService.UpdateBranchShop(model.BranchShop);
        }

        /// <summary>
        /// ��    �ƣ�LogicDeleteBranchShop
        /// ���ܸ�Ҫ���߼�ɾ���ֵ���Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��11��11:50:59
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void LogicDeleteBranchShop()
        {
            systemService.LogicDeleteBranchShop(model.BranchShop.Id);
        }

		/// <summary>
		/// ��    �ƣ�GetBranchShopInfo
		/// ���ܸ�Ҫ����ȡ�ֵ���Ϣ
		/// ��    ��: ������
		/// ����ʱ��: 2010��4��28��16:07:19
		/// ��������:
		/// ����ʱ�䣺
		public void GetBranchShopInfo()
		{
			model.BranchShop = systemService.GetBranchShopInfo(model.BranchShopId);
		}
        #endregion

        #region//������Ϣά��

        /// <summary>
        /// ��    �ƣ�AddMarkingSetting
        /// ���ܸ�Ҫ�����ӻ���
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��28��13:26:25
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void AddMarkingSetting() 
        {
            systemService.AddMarkingSetting(model.MarkingSetting);
        }
        /// <summary>
        /// ��    �ƣ�UpdateMarkingSetting
        /// ���ܸ�Ҫ�����»���
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��28��13:26:25
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void UpdateMarkingSetting()
        {
            systemService.UpdateMarkingSetting(model.MarkingSetting);
        }

        /// <summary>
        /// ��    �ƣ�DeleteMarkingSetting
        /// ���ܸ�Ҫ��ɾ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��28��13:26:25
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void DeleteMarkingSetting()
        {
            systemService.DeleteMarkingSetting(model.MarkingSetting);
        }
        #endregion

        #region ��ȡҵ������
        /// <summary>
        /// ��    ��; GetBusinessTypeList
        /// ���ܸ�Ҫ: ��ȡҵ������
        /// ��    ��: ������
        /// ����ʱ��: 2010��06-29 
        /// ��������: 
        /// ����ʱ��:
        /// </summary>
        public void GetBusinessTypeList()
        {
            model.BusinessTypeList = masterDataService.GetBusinessTypes();
        }
        #endregion

        #region ��ȡ�۸�����
        /// <summary>
        /// ��ȡ�۸�����
        /// </summary>
        public void GetPriceFactor()
        {
            model.PriceFactor = selectActiveFactorService.GetPriceFactor();
        }
        #endregion

        #region ��ȡ����Ĭ������
        /// <summary>
        /// ��    ��: GetDefaultData
        /// ���ܸ�Ҫ: ��ȡ����Ĭ������
        /// ��    ��: ������
        /// ����ʱ��: 2010��7��1��
        /// </summary>
        public void GetDefaultData()
        {
            model.ApplicationProperty = systemService.GetDefaultPriceFactor();
        }
        #endregion

        #region ��ȡӦ�ó������
        /// <summary>
        /// ��    ��: GetApplicationProperty
        /// ���ܸ�Ҫ: ��ȡӦ�ó������
        /// ��    ��: ������
        /// ����ʱ��: 2010��7��1��15:57:07
        /// </summary>
        /// <param name="applicationPropertyId"></param>
        public void GetApplicationProperty(long applicationPropertyId)
        {
            model.ApplicationProperty = systemService.GetApplicationProperty(applicationPropertyId);
        }
        #endregion

        #region �޸�Ӧ�ó������
        /// <summary>
        /// ��    ��: EditApplicationProperty
        /// ���ܸ�Ҫ: �޸�Ӧ�ó������
        /// ��    ��: ������ 
        /// ����ʱ��: 2010��7��2�� 9:52:57
        /// </summary>
        public void EditApplicationProperty()
        {
            systemService.EditApplicationProperty(model.ApplicationProperty);
        }
        #endregion

        #region ��ȡ���п��õļ۸�����
        /// <summary>
        /// ��    ��: GetPriceFactorList
        /// ���ܸ�Ҫ: ��ȡ���п��õļ۸����� 
        /// ��    ��: ������
        /// ����ʱ��: 2010��7��3�� 10:52:06
        /// </summary>
        /// <param name="businessTypeId"></param>
        public IList<Workflow.Da.Domain.PriceFactor> GetPriceFactorList(long businessTypeId)
        {
            return masterDataService.GetPriceFactors();
        }
        #endregion

        #region ��ȡ�۸���������
        /// <summary>
        /// ��    ��: GetFactorValueText
        /// ���ܸ�Ҫ: ��ȡ�۸��������� 
        /// ��    ��: ������
        /// ����ʱ��: 2010��7��3�� 10:59:46  
        /// </summary>
        /// <param name="priceFactor"></param>
        /// <returns></returns>
        public string GetFactorValueText(Workflow.Da.Domain.PriceFactor priceFactor)
        {
            return masterDataService.GetFactorValueText(priceFactor);
        }
        #endregion
    }
}
