using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table BUSINESS_TYPE ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IBusinessTypeDao : IDaoBase<BusinessType>
    {
        //IList<PriceFactor> GetPriceFactorListByBusinessTypeId(long id);
        IList<BusinessType> SelectCustomerQueryBusinessTypeList(BusinessType businessType);
        /// <summary>
        /// �����ý�����,���ۼ۸������Ƿ�ʹ��,����ʾ
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        IList<BusinessType> SelectCustomerQueryBusinessTypeList_Set(BusinessType businessType);
        /// <summary>
        /// ָ����ŵ�ҵ�������Ƿ���ɾ��.������ܷ���BusinessType��������,����������
        /// </summary>
        /// <param name="businessId">Ҫ�����ҵ������ID</param>
        /// <returns></returns>
        /// <remarks>
        /// ����:2008-11-06
        /// �쾲��
        ///</remarks>
        IList<BusinessType> DeleteCheck(long businessId);

        /// <summary>
        /// ��    �ƣ�GetBusinessTypeList
        /// ���ܸ�Ҫ����ȡҵ�������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��28��17:26:13
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        IList<BusinessType> GetBusinessTypeList(BusinessType businessType);


        /// <summary>
        /// ��    �ƣ�GetBusinessTypeListRowCount
        /// ���ܸ�Ҫ����ȡҵ�����ͼ�¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��29��11:26:27
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        long GetBusinessTypeListRowCount(BusinessType businessType);

        /// <summary>
        /// ��    �ƣ�GetAllBusinessTypeList
        /// ���ܸ�Ҫ: ��ȡҵ�������б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��4��30��9:45:47
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<BusinessType> GetAllBusinessTypeList(); 

         /// <summary>
        /// ��    �ƣ�CheckBusinessTyIsUse
        /// ���ܸ�Ҫ: ���ҵ�������Ƿ�����ʹ��
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��4��30��15:35:42
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long CheckBusinessTyIsUse(long businessTypeId);
    }
}
