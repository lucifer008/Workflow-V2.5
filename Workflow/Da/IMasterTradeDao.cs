using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
    /// <summary>
    /// ��   ��:  IMasterTradeDao
    /// ���ܸ�Ҫ: �ͻ�����ҵ�ӿ�
    /// ��    ��: 
    /// ����ʱ��: 
    /// ��������:
    /// ����ʱ��:
    /// </summary>
    public interface IMasterTradeDao : IDaoBase<MasterTrade>
    {
        /// <summary>
        /// ��   ��:  SearchMasterTrade
        /// ���ܸ�Ҫ: ��ȡ������ҵ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��10:20:39
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<MasterTrade> SearchMasterTrade(MasterTrade masterTrade);

        /// <summary>
        /// ��   ��:  SearchMasterTradeRowCount
        /// ���ܸ�Ҫ: ��ȡ������ҵ�б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��10:20:39
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchMasterTradeRowCount(MasterTrade masterTrade);

         /// <summary>
        /// ��   ��:  CheckMasterTradeIsUse
        /// ���ܸ�Ҫ: ���ͻ��ͻ�����ҵ�Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��11:48:22
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long CheckMasterTradeIsUse(long masterTradeId); 
    }
}
