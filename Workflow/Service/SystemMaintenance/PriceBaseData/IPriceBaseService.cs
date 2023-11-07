using System;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.SystemMaintenance.PriceBaseData
{
    /// <summary>
    /// ��    ��: IPriceBaseService
    /// ���ܸ�Ҫ: �۸��������ά���ӿ�
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��28��15:33:14
    /// �� �� ��: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public interface IPriceBaseService
    {
        #region //����ҵ������

        /// <summary>
        /// ��    ��: AddBusinessType
        /// ���ܸ�Ҫ: ���ҵ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��28��17:06:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void AddBusinessType(BusinessType businessType);
        #endregion

        #region //�޸�ҵ������
        /// <summary>
        /// ��    ��: UpdateBusinessType
        /// ���ܸ�Ҫ: �޸�ҵ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��28��17:06:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="businessTypeId"></param>
        void UpdateBusinessType(BusinessType businessType);
        #endregion

        #region //ɾ��ҵ������
        /// <summary>
        /// ��    ��: DeleteBusinessType
        /// ���ܸ�Ҫ: ɾ��ҵ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��28��17:06:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="businessTypeId"></param>
        void DeleteBusinessType(long businessTypeId);
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
        void AddProcessContent(ProcessContent processContent, ProcessContentAchievementRate processContentAchievementRate);

        /// <summary>
        /// ��    ��:UpdateProcessContent
        /// ���ܸ�Ҫ:�޸ļӹ�����
        /// ��    ��:������
        /// ����ʱ��:2009��4��30��10:23:38
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void UpdateProcessContent(ProcessContent processContent, ProcessContentAchievementRate processContentAchievementRate);

        /// <summary>
        /// ��    ��:DeleteProcessContent
        /// ���ܸ�Ҫ:ɾ���ӹ�����
        /// ��    ��:������
        /// ����ʱ��:2009��4��30��10:23:38
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void DeleteProcessContent(long processContentId); 

        /// <summary>
        /// ��    ��:GetProcessContentAchievementRate
        /// ���ܸ�Ҫ:��ȡ�ӹ����ݵ�ҵ��
        /// ��    ��:������
        /// ����ʱ��:2009��6��5��11:52:04
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        ProcessContentAchievementRate GetProcessContentAchievementRate(long processContentId); 
        #endregion

        #region//��������ά��
        /// <summary>
        /// ��    ��: AddMachineType
        /// ���ܸ�Ҫ: ������������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��4��10:31:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void AddMachineType(MachineType machineType); 

         /// <summary>
        /// ��    ��: UpdateMachineType
        /// ���ܸ�Ҫ: ���»�������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��4��10:35:23
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void UpdateMachineType(MachineType machineType);

        /// <summary>
        /// ��    ��: LogicDeleteMachineType
        /// ���ܸ�Ҫ: �߼�ɾ����������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��4��10:35:23
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void LogicDeleteMachineType(long machineTypeId);
        #endregion

        #region//����ά��
        /// <summary>
        /// ��    ��: AddMachine
        /// ���ܸ�Ҫ: ��������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��4��14:55:53
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void AddMachine(Machine machine);

        /// <summary>
        /// ��    ��: UpdateMachine
        /// ���ܸ�Ҫ: ���»���
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��4��14:56:33
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void UpdateMachine(Machine machine);

        /// <summary>
        /// ��    ��: LogicDeleteMachine
        /// ���ܸ�Ҫ: �߼�ɾ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��4��14:56:33
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void LogicDeleteMachine(long machineId);
        #endregion

        #region//ֽ��ά��

        /// <summary>
        /// ��    ��: AddPaperSpecification
        /// ���ܸ�Ҫ: ����ֽ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��5��15:31:55
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void AddPaperSpecification(PaperSpecification paperSpecification);

        /// <summary>
        /// ��    ��: UpdateSpecification
        /// ���ܸ�Ҫ: ����ֽ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��5��15:31:55
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void UpdateSpecification(PaperSpecification paperSpecification);

        /// <summary>
        /// ��    ��: LogicDeleteSpecification
        /// ���ܸ�Ҫ: �߼�ɾ��ֽ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��5��15:31:55
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void LogicDeleteSpecification(long paperSpecificationId);
        #endregion

        #region//ֽ��ά��
        /// <summary>
        /// ��    ��: AddPaperType
        /// ���ܸ�Ҫ: ����ֽ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��10:14:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void AddPaperType(PaperType paperType); 

        /// <summary>
        /// ��    ��: UpdatePaperType
        /// ���ܸ�Ҫ: �޸�ֽ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��10:14:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void UpdatePaperType(PaperType paperType); 

        /// <summary>
        /// ��    ��: LogicDeletePaperType
        /// ���ܸ�Ҫ: �߼�ɾ��ֽ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��10:14:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void LogicDeletePaperType(long paperTypeId); 
        #endregion

        #region//�����۸����ؼ�ֵά��
        /// <summary>
        /// ��    ��: AddPriceFactor
        /// ���ܸ�Ҫ: �����۸�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��16:03:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void AddPriceFactor(PriceFactor priceFactor);

        /// <summary>
        /// ��    ��: UpdatePriceFactor
        /// ���ܸ�Ҫ: �޸ļ۸�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��16:03:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void UpdatePriceFactor(PriceFactor priceFactor);

        /// <summary>
        /// ��    ��: LogicDeletePriceFactor
        /// ���ܸ�Ҫ: �߼�ɾ���۸�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��16:03:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void LogicDeletePriceFactor(long priceFactorId);

        /// <summary>
        /// ��    ��: AddFactorValue
        /// ���ܸ�Ҫ: �����۸�����ֵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��16:03:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void AddFactorValue(FactorValue factorValue);

        /// <summary>
        /// ��    ��: UpdateFactorValue
        /// ���ܸ�Ҫ: ���¼۸�����ֵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��16:03:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void UpdateFactorValue(FactorValue factorValue);

        /// <summary>
        /// ��    ��: LogicDeleteFactorValue
        /// ���ܸ�Ҫ: �߼�ɾ���۸�����ֵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��6��16:03:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void LogicDeleteFactorValue(long factorValueId);

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
        void AddBusinessTypePriceFactor(BusinessTypePriceFactor businessTypePriceFactor,string[] priceFactorIds);

         /// <summary>
        /// ��    ��: UpdateBusinessTypePriceFactor
        /// ���ܸ�Ҫ: �޸� ҵ�����Ͱ����ļ۸�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��9:23:33
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void UpdateBusinessTypePriceFactor(BusinessTypePriceFactor businessTypePriceFactor, string[] priceFactorIds);

        /// <summary>
        /// ��    ��: DeleteBusinessTypePriceFactor
        /// ���ܸ�Ҫ: ɾ�� ҵ�����Ͱ����ļ۸�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��9:23:33
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void DeleteBusinessTypePriceFactor(long businessTypePriceFactorId);

        /// <summary>
        /// ��    ��: DeleteBusinessTypePriceFactorByBusinessTypeId
        /// ���ܸ�Ҫ: ����ҵ������Idɾ����۸�����֮������� 
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��10:01:27
        /// ����������
        /// ����ʱ��:
        /// </summary>
        void DeleteBusinessTypePriceFactorByBusinessTypeId(long businessTypeId);
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
       void AddFactorRelation(FactorRelation factorRelation,string[] priceFactorIds); 

        /// <summary>
        /// ��    ��: UpdateFactorRelation
        /// ���ܸ�Ҫ: ���¼۸���������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��14��12:02:58
        /// ����������
        /// ����ʱ��:
        /// </summary>
        void UpdateFactorRelation(FactorRelation factorRelation, string[] priceFactorIds);

        /// <summary>
        /// ��    ��: LogicDeleteFactorRelation
        /// ���ܸ�Ҫ: �߼�ɾ���۸���������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��14��12:02:58
        /// ����������
        /// ����ʱ��:
        /// </summary>
        void LogicDeleteFactorRelation(FactorRelation factorRelation);
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
        void AddFactorRelationValue(FactorRelationValue factorRelationValue); 

        /// <summary>
        /// ��    ��: UpdateFactorRelationValue
        /// ���ܸ�Ҫ: ���¼۸�����������ϵֵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��18��13:24:37
        /// ����������
        /// ����ʱ��:
        /// </summary>
        void UpdateFactorRelationValue(FactorRelationValue factorRelationValue);

        /// <summary>
        /// ��    ��: LogicDeleteFactorRelationValue
        /// ���ܸ�Ҫ: �߼�ɾ���۸�����������ϵֵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��18��13:24:37
        /// ����������
        /// ����ʱ��:
        /// </summary>
        void LogicDeleteFactorRelationValue(long factorRelationValueId);
        #endregion
    }
}
