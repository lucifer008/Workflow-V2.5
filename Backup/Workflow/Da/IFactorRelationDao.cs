using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table FACTOR_RELATION ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IFactorRelationDao : IDaoBase<FactorRelation>
    {
        /// <summary>
        /// ��    ��: GetRelatedPriceFactorBySourcePriceFactor
        /// ���ܸ�Ҫ: ����ҵ������ID��Դ����ID��ȡ��صļ۸����ء�
        /// ��    ��: ף�±�
        /// ����ʱ��: 2007-9-16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="factorRelation">�������ָ����ҵ������ID��Դ����ID</param>
        /// <returns>FactorRelationID��PriceFactorId2��Ӧ����Ϣ</returns>
        IList<FactorRelation> GetRelatedPriceFactorBySourcePriceFactor(FactorRelation factorRelation);

        /// <summary>
        /// ��    ��: GetFactorValueListByFactorRelation
        /// ���ܸ�Ҫ: �������ؼ�����֮���Լ����ϵ��ȡĿ�����ص�ֵ��
        /// ��    ��: ף�±�
        /// ����ʱ��: 2007-9-16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="factorRelation">GetRelatedPriceFactorBySourcePriceFactor���ص�ÿһ������</param>
        /// <returns>��Ӧ������ֵ���б�</returns>
        IList<FactorValue> GetFactorValueListByFactorRelation(FactorRelation factorRelation);

        ///// <summary>
        ///// ��    ��: GetFactorRelationValueByBusinessTypeId
        ///// ���ܸ�Ҫ: ����
        ///// ��    ��: 
        ///// ����ʱ��: 
        ///// ��������:
        ///// ����ʱ��:
        ///// </summary>
        ///// <param name="factorRelation"></param>
        ///// <returns></returns>
        //IList<FactorRelation> GetFactorRelationValueByBusinessTypeId(FactorRelation factorRelation);

        #region//�۸�����֮�������

        /// <summary>
        /// ��    ��: SearchFactorRelation
        /// ���ܸ�Ҫ: ��ȡ����֮��������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��14��10:47:30
        /// ����������
        /// ����ʱ��:
        /// </summary>
        IList<FactorRelation> SearchFactorRelation(FactorRelation factorRelation);


        /// <summary>
        /// ��    ��: SearchFactorRelationRowCount
        /// ���ܸ�Ҫ: ��ȡ����֮��������б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��14��10:47:30
        /// ����������
        /// ����ʱ��:
        /// </summary>
        long SearchFactorRelationRowCount(FactorRelation factorRelation);

        /// <summary>
        /// ��    ��: CheckFactorRelationIsExist
        /// ���ܸ�Ҫ: ����Ƿ����FactorRelation
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��14��10:47:30
        /// ����������
        /// ����ʱ��:
        /// </summary>
        bool CheckFactorRelationIsExist(FactorRelation factorRelation);

        /// <summary>
        /// ��    ��: DeleteFactorRelationValue
        /// ���ܸ�Ҫ: ɾ��FactorRelationValue
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��14��15:48:02
        /// ����������
        /// ����ʱ��:
        /// </summary>
        void DeleteFactorRelationValue(long factorRelationId);

        /// <summary>
        /// ��    ��: CheckFactorRelationIsUse
        /// ���ܸ�Ҫ: ���۸�����������ϵ�Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��18��9:53:25
        /// ����������
        /// ����ʱ��:
        /// </summary>
        long CheckFactorRelationIsUse(long factorRelationId);
        #endregion
    }
}
