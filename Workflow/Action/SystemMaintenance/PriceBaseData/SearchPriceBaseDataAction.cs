using System;
using System.Collections.Generic;
using Workflow.Da.Domain;
using Workflow.Service.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;
namespace Workflow.Action.SystemMaintenance.PriceBaseData
{
    /// <summary>
    /// ��   ��:  SearchPriceBaseDataAction
    /// ���ܸ�Ҫ: �����۸����ݲ�ѯAction
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��28��15:18:54
    /// ��������:
    /// ����ʱ��:
    /// </summary>
    public class SearchPriceBaseDataAction
    {
        #region //ע��Service
        private PriceBaseDataModel model = new PriceBaseDataModel();
        public PriceBaseDataModel Model
        {
            set { model = value; }
            get { return model; }
        }

        private ISearchPriceBaseService searchPriceBaseService;
        public ISearchPriceBaseService SearchPriceBaseService 
        {
            set { searchPriceBaseService = value; }
        }
        #endregion

        #region //��ȡҵ�������б�
        /// <summary>
        /// ���ƣ�GetBusniessTypeList
        /// ���ܸ�Ҫ:��ȡҵ�������б�
        /// ���ߣ�������
        /// ����ʱ��:2009��4��28��15:26:31
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void GetBusniessTypeLists()
        {
            model.BusinessTypeList = searchPriceBaseService.GetBusinessTypeList(model.BusinessType);
            model.BusinessTypeRowCount = searchPriceBaseService.GetBusinessTypeListRowCount(model.BusinessType);
        }
        #endregion

        #region //��ȡ����ҵ�������б�
        /// <summary>
        /// ��    �ƣ�GetAllBusinessTypeList
        /// ���ܸ�Ҫ: ��ȡҵ�������б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��4��30��9:45:47
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void GetAllBusinessTypeList() 
        {
            model.BusinessTypeTempList = searchPriceBaseService.GetAllBusinessTypeList();
        }
        #endregion

        #region //��ȡ�ӹ������б�
        /// <summary>
        /// ��    �ƣ�GetProcessContentList
        /// ���ܸ�Ҫ: ��ȡ�ӹ������б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��4��30��9:45:47
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void GetProcessContentList() 
        {
            model.ProcessContentList = searchPriceBaseService.GetProcessContentList(model.ProcessContent);
            model.BusinessTypeRowCount = searchPriceBaseService.GetProcessContentListRowCount(model.ProcessContent);
        }
        #endregion

        #region//��ȡ��������
        /// <summary>
        /// ��    �ƣ�SearchMachineType
        /// ���ܸ�Ҫ: ��ȡ���������б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��4��10:08:16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void SearchMachineType() 
        {
            model.MachineTypeList = searchPriceBaseService.SearchMachineType(model.MachineType);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchMachineTypeRowCount(model.MachineType);
        }
        #endregion

        #region//����
        /// <summary>
        /// ��    �ƣ�SearchMachine
        /// ���ܸ�Ҫ: ��ȡ�����б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��4��14:16:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void SearchMachine() 
        {
            model.MachineList = searchPriceBaseService.SearchMachine(model.Machine);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchMachineRowCount(model.Machine);
        }

        /// <summary>
        /// ��    �ƣ�SearchAllMachineType
        /// ���ܸ�Ҫ: ��ȡ��ȡ���л��������б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��4��14:21:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void SearchAllMachineType() 
        {
            model.MachineTypeList = searchPriceBaseService.SearchAllMachineType();
        }
        #endregion

        #region//ֽ��

        /// <summary>
        /// ��    ��: SearchPaperSecification
        /// ���ܸ�Ҫ: ��ȡֽ���б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��5��15:15:30
        /// ����ʱ��:
        /// </summary>
        public void SearchPaperSecification() 
        {
            model.PaperSecificationList = searchPriceBaseService.SearchPaperSecification(model.PaperSecification);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchPaperSecificationRowCount(model.PaperSecification);
        }
        #endregion

        #region//ֽ��
        /// <summary>
        /// ��    ��: SearchPaperType
        /// ���ܸ�Ҫ: ��ȡֽ���б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��6��9:53:28
        /// ����ʱ��:
        /// </summary>
        public void SearchPaperType() 
        {
            model.PaperTypeList = searchPriceBaseService.SearchPaperType(model.PaperType);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchPaperTypeRowCount( model.PaperType);
        }
        #endregion

        #region//�����۸����ؼ�ֵ
        /// <summary>
        /// ��    ��: GetAllPriceFactor
        /// ���ܸ�Ҫ: ��ȡ���м۸�����
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��6��15:01:35
        /// ����ʱ��:
        /// </summary>
        public void GetAllPriceFactor() 
        {
            model.PriceFactorList = searchPriceBaseService.GetAllPriceFactor();
        }

        /// <summary>
        /// ��    ��: SearchFactorValue
        /// ���ܸ�Ҫ: ��ȡ��������ֵ�б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��6��15:01:35
        /// ����ʱ��:
        /// </summary>
        public void SearchFactorValue() 
        {
            model.FactorValueList = searchPriceBaseService.SearchFactorValue(model.FactorValue);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchFactorValueRowCount(model.FactorValue);
        }

        /// <summary>
        /// ��    ��: SearchPriceFactor
        /// ���ܸ�Ҫ: ��ȡ���м۸������б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��6��17:38:56
        /// ����ʱ��:
        /// </summary>
        public void SearchPriceFactor() 
        {
            model.PriceFactorList = searchPriceBaseService.SearchPriceFactor(model.PriceFactor);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchPriceFactorRowCount(model.PriceFactor);
        }

        /// <summary>
        /// ��    ��: GetPriceFactorDetail
        /// ���ܸ�Ҫ: ��ȡ�۸���������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��12��16:00:46
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void GetPriceFactorDetail() 
        {
            model.PriceFactor = searchPriceBaseService.GetPriceFactorDetail(model.PriceFactor.Id);
        }
        #endregion

        #region//ҵ�����Ͱ����ļ۸�����

        /// <summary>
        /// ��    ��: SearchBusinessTypePriceFactor
        /// ���ܸ�Ҫ: ��ȡҵ�����Ͱ����ļ۸������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��10:01:27
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void SearchBusinessTypePriceFactor()
        {
            model.BusinessTypePriceFactorList = searchPriceBaseService.SearchBusinessTypePriceFactor();
        }

        /// <summary>
        /// ��    ��: SearchBusinessTypePriceFactor
        /// ���ܸ�Ҫ: ��ȡҵ�����Ͱ����ļ۸������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��10:01:27
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void SearchBusinessTypePriceFactor(long businessTypeId)
        {
            model.BusinessTypePriceFactorList = searchPriceBaseService.SearchBusinessTypePriceFactor(businessTypeId);
        }

        /// <summary>
        /// ����ҵ������Id��ȡҵ�����Ͱ����ļ۸�����
        /// </summary>
        /// <remarks>
        /// �� �� ��: ������
        /// ����ʱ��: 2009��5��13��10:36:24
        /// ��������:
        /// �� �� ��:
        /// </remarks>
        public string[] GetBusniessTypePriceFactor(long businessTypeId)
        {
            string[] busniessTypeList = new string[2];
            int count = 0;
            foreach (BusinessTypePriceFactor bt in searchPriceBaseService.SearchBusinessTypePriceFactor())
            {
                if (businessTypeId == bt.BusinessTypeId)
                {
                    if (0 == count)
                    {
                        busniessTypeList[0] += bt.PriceFactorId;
                        busniessTypeList[1] += bt.PriceFactorText;
                    }
                    else
                    {
                        busniessTypeList[0] += "/" + bt.PriceFactorId;
                        busniessTypeList[1] += "/" + bt.PriceFactorText;
                    }
                    count++;
                }
            }
            return busniessTypeList;
        }
        #endregion

        #region//�۸�����֮�������
        /// <summary>
        /// ��    ��: SearchFactorRelation
        /// ���ܸ�Ҫ: ��ȡ����֮��������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��14��10:47:30
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void SearchFactorRelation() 
        {
            model.FactorRelationList=searchPriceBaseService.SearchFactorRelation(model.FactorRelation);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchFactorRelationRowCount(model.FactorRelation);
        }
        #endregion

        #region//�۸�����������ϵֵ
        /// <summary>
        /// ��    ��: GetAllFactorRelationValue
        /// ���ܸ�Ҫ: ��ȡ��������֮��������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��18��11:10:17
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void GetAllFactorRelationValue() 
        {
            model.FactorRelationList = searchPriceBaseService.GetAllFactorRelationValue();
        }

        /// <summary>
        /// ��    ��: SearchFactorRelationValue
        /// ���ܸ�Ҫ: ��ȡ���������Ĺ�ϵֵ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��18��11:10:17
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void SearchFactorRelationValue() 
        {
            model.FactorRelationValueList = searchPriceBaseService.SearchFactorRelationValue(model.FactorRelationValue);
            model.BusinessTypeRowCount = searchPriceBaseService.SearchFactorRelationValueRowCount(model.FactorRelationValue);
        }

        /// <summary>
        /// ��    ��: GetFactorRelationValueText
        /// ���ܸ�Ҫ: ��ȡ���������Ĺ�ϵֵ�ı�
        /// ��    ��: ������
        /// ����ʱ��: 2009��7��20��13:28:14
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void GetFactorRelationValueText(FactorRelationValue factorRelationValue) 
        {
            FactorRelationValueText factorRelationValueText = new FactorRelationValueText();
            FactorRelation factorRelation = searchPriceBaseService.GetFactorRelationById(factorRelationValue.FactorRelationId);
            PriceFactor priceFactor1 = searchPriceBaseService.GetPriceFactorById(factorRelation.PriceFactorId);//��������
            PriceFactor priceFactor2 = searchPriceBaseService.GetPriceFactorById(factorRelation.PriceFactor.Id);//����������
            IList<PriceFactor> priceFactorList1 = searchPriceBaseService.GetPriceFactorValueList(priceFactor1);
            IList<PriceFactor> priceFactorList2 = searchPriceBaseService.GetPriceFactorValueList(priceFactor2);
            foreach(PriceFactor priceFactor in priceFactorList1)
            {
                if(priceFactor.Id==factorRelationValue.SourceValue)
                {
                    factorRelationValueText.SourceValueId = factorRelationValue.SourceValue;
                    factorRelationValueText.SourceValueText = priceFactor.Name;
                    break;
                }
            }
            foreach (PriceFactor priceFactor in priceFactorList2)
            {
                if(priceFactor.Id==factorRelationValue.TargetValue)
                {
                    factorRelationValueText.TargetValueId = Convert.ToInt32(priceFactor.Id);
                    factorRelationValueText.TargetValueText = priceFactor.Name;
                    break;
                }
            }
            model.FactorRelationValueText = factorRelationValueText;
        }
        #endregion
    }
}
