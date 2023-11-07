using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table TRASH_PAPER_EMPLOYEE ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface ITrashPaperEmployeeDao : IDaoBase<TrashPaperEmployee>
    {
        /// <summary>
        /// ɾ���ϸ�������
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-12
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        void DeleteTrashPaperEmployeeByOrderId(long orderId);

    }
}
