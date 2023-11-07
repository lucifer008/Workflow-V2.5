using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// ��     ��: IBusinessTypePriceFactorDao
    /// ���ܸ�Ҫ: ҵ�����Ͱ����ļ۸����ؽӿ�
    /// ��    ��:
    /// ����ʱ��:
    /// ��������:
    /// ����ʱ��:
	/// </summary>
    public interface IBusinessTypePriceFactorDao : IDaoBase<BusinessTypePriceFactor>
    {
        void DeleteByBusinessTypeId(long id);

        #region//ҵ�����Ͱ����ļ۸�����

        /// <summary>
        /// ��    ��: SearchBusinessTypePriceFactor
        /// ���ܸ�Ҫ: ��ȡҵ�����Ͱ����ļ۸������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��10:01:27
        /// ����������
        /// ����ʱ��:
        /// </summary>
        IList<BusinessTypePriceFactor> SearchBusinessTypePriceFactor();

        /// <summary>
        /// ��    ��: SearchBusinessTypePriceFactor
        /// ���ܸ�Ҫ: ��ȡҵ�����Ͱ����ļ۸������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��10:01:27
        /// ����������
        /// ����ʱ��:
        /// </summary>
        IList<BusinessTypePriceFactor> SearchBusinessTypePriceFactor(long businessTypeId);

        /// <summary>
        /// ��    ��: DeleteBusinessTypePriceFactorByBusinessTypeId
        /// ���ܸ�Ҫ: ����ҵ������Idɾ����۸�����֮������� 
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��10:01:27
        /// ����������
        /// ����ʱ��:
        /// </summary>
        void DeleteBusinessTypePriceFactorByBusinessTypeId(long businessTypeId);

        /// <summary>
        /// ��    ��: CheckBusinessTypePriceFactorIsExist
        /// ���ܸ�Ҫ: ����ҵ������Id�ͼ۸�����Id�Ƿ����֮������� 
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��13��14:54:39
        /// ����������
        /// ����ʱ��:
        /// </summary>
        bool CheckBusinessTypePriceFactorIsExist(BusinessTypePriceFactor businessTypePriceFactor);
        #endregion
    }
}
