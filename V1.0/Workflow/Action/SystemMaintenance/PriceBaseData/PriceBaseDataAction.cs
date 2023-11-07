using System;
using System.Collections.Generic;
using Workflow.Service.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;

namespace Workflow.Action.SystemMaintenance.PriceBaseData
{
    /// <summary>
    /// ��   ��:  PriceBaseDataAction
    /// ���ܸ�Ҫ: �����۸����ݹ���Action
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��28��15:18:54
    /// ��������:
    /// ����ʱ��:
    /// </summary>
    public class PriceBaseDataAction
    {
        #region //ע��Service
        private PriceBaseDataModel model = new PriceBaseDataModel();
        public PriceBaseDataModel Model
        {
            set { model = value; }
            get { return model; }
        }

        private IPriceBaseService priceBaseService;
        public IPriceBaseService PriceBaseService 
        {
            set { priceBaseService = value; }
        }
        #endregion

        #region //ҵ������ά��
        /// <summary>
        /// ��    �ƣ�AddBusinessType
        /// ���ܸ�Ҫ: ����ҵ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��28��17:13:34
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddBusinessType()
        {
            priceBaseService.AddBusinessType(model.BusinessType);
        }

        /// <summary>
        /// ��    �ƣ�UpdateBusinessType
        /// ���ܸ�Ҫ: �޸�ҵ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��28��17:13:34
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateBusinessType()
        {
            priceBaseService.UpdateBusinessType(model.BusinessType);
        }

        /// <summary>
        /// ��    �ƣ�DeleteBusinessType
        /// ���ܸ�Ҫ: ɾ��ҵ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��28��17:13:34
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void DeleteBusinessType()
        {
            priceBaseService.DeleteBusinessType(model.BusinessType.Id);
        }
        #endregion

        #region //�ӹ�����ά��
        /// <summary>
        /// ��    ��:AddProcessContent
        /// ���ܸ�Ҫ:�����ӹ�����
        /// ��    ��:������
        /// ����ʱ��:2009��4��30��10:23:38
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddProcessContent() 
        {
            priceBaseService.AddProcessContent(model.ProcessContent,model.ProcessContentAchievementRate);
        }

        /// <summary>
        /// ��    ��:UpdateProcessContent
        /// ���ܸ�Ҫ:�޸ļӹ�����
        /// ��    ��:������
        /// ����ʱ��:2009��4��30��10:23:38
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateProcessContent() 
        {
            priceBaseService.UpdateProcessContent(model.ProcessContent, model.ProcessContentAchievementRate);
        }

        /// <summary>
        /// ��    ��:DeleteProcessContent
        /// ���ܸ�Ҫ:ɾ���ӹ�����
        /// ��    ��:������
        /// ����ʱ��:2009��4��30��10:23:38
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void DeleteProcessContent() 
        {
            priceBaseService.DeleteProcessContent(model.ProcessContent.Id);
        }

        /// <summary>
        /// ��    ��:GetProcessContentAchievementRate
        /// ���ܸ�Ҫ:��ȡ�ӹ����ݵ�ҵ��
        /// ��    ��:������
        /// ����ʱ��:2009��6��5��11:52:04
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void GetProcessContentAchievementRate() 
        {
            model.ProcessContentAchievementRate = priceBaseService.GetProcessContentAchievementRate(model.ProcessContent.Id);
        }
        #endregion

        #region//��������
        /// <summary>
        /// ��    ��: AddMachineType
        /// ���ܸ�Ҫ: ������������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��4��10:31:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddMachineType() 
        {
            priceBaseService.AddMachineType(model.MachineType);
        }

        /// <summary>
        /// ��    ��: UpdateMachineType
        /// ���ܸ�Ҫ: ���»�������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��4��10:35:23
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateMachineType()
        {
            priceBaseService.UpdateMachineType(model.MachineType);
        }

        /// <summary>
        /// ��    ��: LogicDeleteMachineType
        /// ���ܸ�Ҫ: �߼�ɾ����������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��4��10:35:23
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteMachineType() 
        {
            priceBaseService.LogicDeleteMachineType(model.MachineType.Id);
        }
        #endregion

        #region//����
        /// <summary>
        /// ��    ��: AddMachine
        /// ���ܸ�Ҫ: ��������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��4��14:54:15
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddMachine()
        {
            priceBaseService.AddMachine(model.Machine);
        }

        /// <summary>
        /// ��    ��: UpdateMachine
        /// ���ܸ�Ҫ: ���»�������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��4��14:54:15
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateMachine()
        {
            priceBaseService.UpdateMachine(model.Machine);
        }

        /// <summary>
        /// ��    ��: LogicDeleteMachine
        /// ���ܸ�Ҫ: �߼�ɾ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��4��14:54:15
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteMachine()
        {
            priceBaseService.LogicDeleteMachine(model.Machine.Id);
        }
        #endregion

        #region//ֽ��

        /// <summary>
        /// ��    ��: AddPaperSpecification
        /// ���ܸ�Ҫ: ����ֽ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��5��15:31:55
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddPaperSpecification() 
        {
            priceBaseService.AddPaperSpecification(model.PaperSecification);
        }

        /// <summary>
        /// ��    ��: UpdateSpecification
        /// ���ܸ�Ҫ: ����ֽ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��5��15:31:55
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateSpecification() 
        {
            priceBaseService.UpdateSpecification(model.PaperSecification);
        }

        /// <summary>
        /// ��    ��: LogicDeleteSpecification
        /// ���ܸ�Ҫ: �߼�ɾ��ֽ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��5��15:31:55
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteSpecification() 
        {
            priceBaseService.LogicDeleteSpecification(model.PaperSecification.Id);
        }
        #endregion

        #region//ֽ��
        /// <summary>
        /// ��    ��: AddPaperType
        /// ���ܸ�Ҫ: ����ֽ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��10:14:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddPaperType() 
        {
            priceBaseService.AddPaperType(model.PaperType);
        }

        /// <summary>
        /// ��    ��: UpdatePaperType
        /// ���ܸ�Ҫ: �޸�ֽ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��10:14:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdatePaperType() 
        {
            priceBaseService.UpdatePaperType(model.PaperType);
        }

        /// <summary>
        /// ��    ��: LogicDeletePaperType
        /// ���ܸ�Ҫ: �߼�ɾ��ֽ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��10:14:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeletePaperType() 
        {
            priceBaseService.LogicDeletePaperType(model.PaperType.Id);
        }
        #endregion

        #region//�����۸����ؼ�ֵ
        /// <summary>
        /// ��    ��: AddPriceFactor
        /// ���ܸ�Ҫ: �����۸�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��16:03:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddPriceFactor() 
        {
            priceBaseService.AddPriceFactor(model.PriceFactor);
        }

        /// <summary>
        /// ��    ��: UpdatePriceFactor
        /// ���ܸ�Ҫ: �޸ļ۸�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��16:03:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdatePriceFactor()
        {
            priceBaseService.UpdatePriceFactor(model.PriceFactor);
        }

        /// <summary>
        /// ��    ��: LogicDeletePriceFactor
        /// ���ܸ�Ҫ: �߼�ɾ���۸�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��16:03:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeletePriceFactor()
        {
            priceBaseService.LogicDeletePriceFactor(model.PriceFactor.Id);
        }

        /// <summary>
        /// ��    ��: AddFactorValue
        /// ���ܸ�Ҫ: �����۸�����ֵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��16:03:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddFactorValue()
        {
            priceBaseService.AddFactorValue(model.FactorValue);
        }

        /// <summary>
        /// ��    ��: UpdateFactorValue
        /// ���ܸ�Ҫ: ���¼۸�����ֵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��16:03:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateFactorValue()
        {
            priceBaseService.UpdateFactorValue(model.FactorValue);
        }

        /// <summary>
        /// ��    ��: LogicDeleteFactorValue
        /// ���ܸ�Ҫ: �߼�ɾ���۸�����ֵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��16:03:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteFactorValue()
        {
            priceBaseService.LogicDeleteFactorValue(model.FactorValue.Id);
        }
        #endregion

        #region//ҵ�����Ͱ����ļ۸�����
        /// <summary>
        /// ��    ��: AddBusinessTypePriceFactor
        /// ���ܸ�Ҫ: ���ҵ�����Ͱ����ļ۸�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��9:23:33
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddBusinessTypePriceFactor() 
        {
            priceBaseService.AddBusinessTypePriceFactor(model.BusinessTypePriceFactor,model.PriceFactorIds);
        }

        /// <summary>
        /// ��    ��: UpdateBusinessTypePriceFactor
        /// ���ܸ�Ҫ: �޸� ҵ�����Ͱ����ļ۸�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��9:23:33
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateBusinessTypePriceFactor() 
        {
            priceBaseService.UpdateBusinessTypePriceFactor(model.BusinessTypePriceFactor,model.PriceFactorIds);
        }

        /// <summary>
        /// ��    ��: DeleteBusinessTypePriceFactor
        /// ���ܸ�Ҫ: ɾ�� ҵ�����Ͱ����ļ۸�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��9:23:33
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void DeleteBusinessTypePriceFactor() 
        {
            priceBaseService.DeleteBusinessTypePriceFactor(model.BusinessTypePriceFactor.Id);
        }

        /// <summary>
        /// ��    ��: DeleteBusinessTypePriceFactorByBusinessTypeId
        /// ���ܸ�Ҫ: ����ҵ������Idɾ����۸�����֮������� 
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��10:01:27
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void DeleteBusinessTypePriceFactorByBusinessTypeId() 
        {
            priceBaseService.DeleteBusinessTypePriceFactorByBusinessTypeId(model.BusinessTypePriceFactor.BusinessTypeId);
        }
        #endregion

        #region//�۸�����֮�������
        /// <summary>
        /// ��    ��: AddFactorRelation
        /// ���ܸ�Ҫ: �����۸���������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��14��12:02:58
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void AddFactorRelation() 
        {
            priceBaseService.AddFactorRelation(model.FactorRelation,model.PriceFactorIds);
        }

        /// <summary>
        /// ��    ��: UpdateFactorRelation
        /// ���ܸ�Ҫ: ���¼۸���������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��14��12:02:58
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void UpdateFactorRelation()
        {
            priceBaseService.UpdateFactorRelation(model.FactorRelation, model.PriceFactorIds);
        }

        /// <summary>
        /// ��    ��: LogicDeleteFactorRelation
        /// ���ܸ�Ҫ: �߼�ɾ���۸���������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��14��12:02:58
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteFactorRelation()
        {
            priceBaseService.LogicDeleteFactorRelation(model.FactorRelation);
        }
        #endregion

        #region//�۸�����������ϵֵ
        /// <summary>
        /// ��    ��: AddFactorRelationValue
        /// ���ܸ�Ҫ: ��Ӽ۸�����������ϵֵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��18��13:24:37
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void AddFactorRelationValue() 
        {
            priceBaseService.AddFactorRelationValue(model.FactorRelationValue);
        }

        /// <summary>
        /// ��    ��: UpdateFactorRelationValue
        /// ���ܸ�Ҫ: ���¼۸�����������ϵֵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��18��13:24:37
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void UpdateFactorRelationValue()
        {
            priceBaseService.UpdateFactorRelationValue(model.FactorRelationValue);
        }

        /// <summary>
        /// ��    ��: LogicDeleteFactorRelationValue
        /// ���ܸ�Ҫ: �߼�ɾ���۸�����������ϵֵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��18��13:24:37
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteFactorRelationValue()
        {
            priceBaseService.LogicDeleteFactorRelationValue(model.FactorRelationValue.Id);
        }
        #endregion
    }
}
