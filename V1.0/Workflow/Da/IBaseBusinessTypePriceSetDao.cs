using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Da
{
	/// <summary>
	/// Table BASE_BUSINESS_TYPE_PRICE_SET ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IBaseBusinessTypePriceSetDao : IDaoBase<BaseBusinessTypePriceSet>
    {
        IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetListCustomQuery(BaseBusinessTypePriceSet baseBusinessTypePriceSet);
        /// <summary>
        /// ���ӷ�ҳ���ܵ�GetBaseBusinessTypePriceSetListCustomQuery
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-11-08
        /// </remarks>
        IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetListCustomQuery_Page(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        int GetBaseBusinessTypePriceSetListCustomQueryCount(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        BaseBusinessTypePriceSet GetTheLowerestPrice(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        /// <summary>
        /// ��������: GetBaseBusinessTypePriceSetDao
        /// ���ܸ�Ҫ: �޸����м۸����õķ�ҳ
        /// ��    ��: ����ط
        /// ����ʱ��: 2008-1-9
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetDao(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

           /// <summary>
        /// ��������: SearchBaseBuinessTypeSetInfo
        /// ���ܸ�Ҫ: ������м۸�����һ��(��ҳ)
        /// ��    ��: ������
        /// ����ʱ��: 2009��3��5��13:40:53
        /// ��������: 
        /// ����ʱ��:
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        IList<BaseBusinessTypePriceSet> SearchBaseBuinessTypeSetInfo(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        /// <summary>
        /// ��������: SearchBaseBuinessTypeSetInfoRowCount
        /// ���ܸ�Ҫ: ������м۸����ü�¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��3��5��13:40:53
        /// ��������: 
        /// ����ʱ��:
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        long SearchBaseBuinessTypeSetInfoRowCount(BaseBusinessTypePriceSet baseBusinessTypePriceSet);

        /// <summary>
        /// ��ȡ��Ա�����ѵ�ҵ��������ϸ
        /// </summary>
        /// <param name="memberCardId"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��:������ 
        /// ����ʱ��: 2009��4��16��10:44:31
        /// ��������:
        /// ����ʱ��:
        /// ��    ��:
        /// </remarks>
        IList<Order> GetMemberCardBaseBusItem(MemberCard memberCard);
    }
}
