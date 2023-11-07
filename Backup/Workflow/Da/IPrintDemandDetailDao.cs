using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
    /// <summary>
    /// ��   ��: IPrintDemandDetailDao
    /// ���ܸ�Ҫ:ӡ��Ҫ����ϸ�ӿ�
    /// ��    ��:
    /// ��������:
    /// ����ʱ��:
    /// </summary>
    public interface IPrintDemandDetailDao : IDaoBase<PrintDemandDetail>
    {
        #region//ӡ��Ҫ����ϸ

        /// <summary>
        /// ��   ��:  SearchPrintDemandDetail
        /// ���ܸ�Ҫ: ��ȡӡ��Ҫ����ϸ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<PrintDemandDetail> SearchPrintDemandDetail(PrintDemandDetail printDemandDetail);

        /// <summary>
        /// ��   ��:  SearchPrintDemandDetailRowCount
        /// ���ܸ�Ҫ: ��ȡӡ��Ҫ����ϸ�б���Ŀ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchPrintDemandDetailRowCount(PrintDemandDetail printDemandDetail);
        #endregion
    }
}
