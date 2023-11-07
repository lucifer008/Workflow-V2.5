using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// ��   ��:  SecondaryTradeDaoImpl
    /// ���ܸ�Ҫ: �ͻ�����ҵ�ӿ�ʵ��
    /// ��    ��: 
    /// ����ʱ��: 
    /// ��������:
    /// ����ʱ��:
    /// </summary>
    public class SecondaryTradeDaoImpl : Workflow.Da.Base.DaoBaseImpl<SecondaryTrade>, ISecondaryTradeDao
    {
        /// <summary>
        /// ��   ��:  SearchMasterTrade
        /// ���ܸ�Ҫ: ��ȡ�ͻ�����ҵ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��10:20:39
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<SecondaryTrade> SearchSecondaryTrade(SecondaryTrade secondaryTrade) 
        {
            secondaryTrade.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            secondaryTrade.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<SecondaryTrade>("SecondaryTrade.SearchSecondaryTrade", secondaryTrade);
        }

        /// <summary>
        /// ��   ��:  SearchMasterTradeRowCount
        /// ���ܸ�Ҫ: ��ȡ�ͻ�����ҵ�б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��10:20:39
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchSecondaryTradeRowCount(SecondaryTrade secondaryTrade) 
        {
            return sqlMap.QueryForObject<long>("SecondaryTrade.SearchSecondaryTradeRowCount", secondaryTrade);
        }
    }
}
