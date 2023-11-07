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
        /// ��������: GetBusinessTypePriceSetListCustomQueryCount
        /// ���ܸ�Ҫ: ���ҵ��۸�����
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2010-3-1
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="businessTypePriceSet);"></param>
        /// <returns></returns>
        long GetBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet);

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
		/// �������û�Ա������ҵ�۸�,��������ָ�����������. (����ҳ)
		/// </summary>
		/// <param name="businessTypePriceSet"></param>
		/// <returns></returns>
		IList<BusinessTypePriceSet> GetOnlyBusinessTypePriceSetList(BusinessTypePriceSet businessTypePriceSet);

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

        #region//ɾ����Ա�۸�
        /// <summary>
        /// ��������: DeleteMembercardPrice
        /// ���ܸ�Ҫ: ɾ����Ա�۸�
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��30��10:10:40
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        void DeleteMembercardPrice(BusinessTypePriceSet businessTypePriceSet);
        #endregion

        #region//�༭��Ա�۸�
        /// <summary>
        /// ��������: UpdateMembercardPrice
        /// ���ܸ�Ҫ: �༭��Ա�۸�
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��30��15:39:54
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        void UpdateMembercardPrice(BusinessTypePriceSet businessTypePriceSet);
        #endregion

		#region �޸Ļ�Ա���۸�

		/// <summary>
		/// �޸Ļ�Ա���۸�
		/// </summary>
		/// <param name="val"></param>
		void UpdateBusinessTypePrice(BusinessTypePriceSet val);

		#endregion

		
	}
}
