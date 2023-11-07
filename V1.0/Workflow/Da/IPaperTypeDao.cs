using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	///  ��   ��: IPaperTypeDao
    /// ���ܸ�Ҫ:ֽ�ʲ����ӿ�
    /// ��    ��:
    /// ��������:
    /// ����ʱ��:
	/// </summary>
    public interface IPaperTypeDao : IDaoBase<PaperType>
    {
        #region //ֽ��
        /// <summary>
        /// ��    ��: SearchPaperType
        /// ���ܸ�Ҫ: ��ȡֽ���б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��6��9:53:28
        /// ����ʱ��:
        /// </summary>
        IList<PaperType> SearchPaperType(PaperType paperType);

        /// <summary>
        /// ��    ��: SearchPaperTypeRowCount
        /// ���ܸ�Ҫ: ��ȡֽ�ʼ�¼��
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��6��9:53:28
        /// ����ʱ��:
        /// </summary>
        long SearchPaperTypeRowCount(PaperType paperType);

        #endregion
    }
}
