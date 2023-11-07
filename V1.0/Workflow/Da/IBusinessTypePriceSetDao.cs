using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table BUSINESS_TYPE_PRICE_SET ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IBusinessTypePriceSetDao : IDaoBase<BusinessTypePriceSet>
    {
        IList<BusinessTypePriceSet> GetBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet);
        /// <summary>
        /// ������û�����û�Ա������ҵ�۸�,��������ָ�����������. 
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        IList<BusinessTypePriceSet> GetAllBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet);
        /// <summary>
        /// �������û�Ա������ҵ�۸�,��������ָ�����������. 
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        IList<BusinessTypePriceSet> GetOnlyBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet);
        /// <summary>
        /// ��ȡBusinessTypePriceSet��Ӧ�Ļ�Ա�����������ҵ����
        /// </summary>
        /// <param name="bizPriceSet"></param>
        string GetTargetName(BusinessTypePriceSet bizPriceSet);

        /// <summary>
        /// ������û�����û�Ա������ҵ�۸�,��������ָ�����������.ȡ����
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        long GetAllBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet);
        /// <summary>
        /// �������û�Ա������ҵ�۸������
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        long GetOnlyBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet);


        BusinessTypePriceSet GetPrice(BusinessTypePriceSet businessTypePriceSet);
    }
}
