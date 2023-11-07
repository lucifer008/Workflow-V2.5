using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// ��     ��:IPaperSpecification
    /// ���ܸ�Ҫ:IPaperSpecification�ӿ�
    /// ��    ��:
    /// ����ʱ��:
    /// ��������:
    /// ����ʱ��:
	/// </summary>
    public interface IPaperSpecificationDao : IDaoBase<PaperSpecification>
    {
        #region //��ȡֽ������
        /// <summary>
        /// ��    ��: SearchPaperSecification
        /// ���ܸ�Ҫ: ��ȡֽ���б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��5��15:15:30
        /// ����ʱ��:
        /// </summary>
        IList<PaperSpecification> SearchPaperSecification(PaperSpecification paperSpecification);

        /// <summary>
        /// ��    ��: SearchPaperSecificationRowCount
        /// ���ܸ�Ҫ: ��ȡֽ�ͼ�¼�� 
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��5��15:15:30
        /// ����ʱ��:
        /// </summary>
        long SearchPaperSecificationRowCount(PaperSpecification paperSpecification);
        #endregion

		#region ͨ��ֽ�����ƻ�ȡֽ��Id
		/// <summary>
		/// ��    ��: SelectPaperSpecificationIdByName
		/// ���ܸ�Ҫ: ͨ��ֽ�����ƻ�ȡֽ��
		/// ��    �ߣ�������
		/// ����ʱ��: 2010��5��7��
		/// ����ʱ��:
		/// </summary>
		/// <param name="name">ֽ������</param>
		long SelectPaperSpecificationIdByName(string name);
		#endregion
    }
}
