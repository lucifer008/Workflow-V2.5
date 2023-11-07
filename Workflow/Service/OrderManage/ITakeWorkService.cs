using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.OrderManage
{
    /// <summary>
    /// ��    ��: ITakeWorkService
    /// ���ܸ�Ҫ: ����ȡ���Service�ӿ�
    /// ��    ��: liuwei
    /// ����ʱ��: 2007-10-9
    /// �� �� ��: ��ǿ
    /// ����ʱ��: 2009-1-22
    /// ��    ��: ��������
    /// </summary>
    public  interface ITakeWorkService
    {
        #region ȡ��Ļ�������
        /// <summary>
        /// ��    ��: InsertTakeWord
        /// ���ܸ�Ҫ: ����ȡ����Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-10
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param>ȡ��ʵ��</param>
        void InsertTakeWord(TakeWork takeWork);
        /// <summary>
        /// ��    ��: DeleteTakeWork
        /// ���ܸ�Ҫ: ɾ��ȡ��
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-9
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="Id">ȡ��Id</param>
        void DeleteTakeWork(long Id);
        /// <summary>
        /// ��    ��: UpdateTakeWork
        /// ���ܸ�Ҫ: ����ȡ����Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-10
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="takeWork">ȡ��ʵ��</param>
        void UpdateTakeWork(TakeWork takeWork);
        #endregion

        #region ��ѯȡ��
        /// <summary>
        /// ��    ��: SearchTakeWorkById
        /// ���ܸ�Ҫ: ͨ��Id��ȡȡ����Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-10
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param>ȡ��Id</param>
        /// <returns>һ��ȡ��ʵ��</returns>
        TakeWork SearchTakeWorkById(long Id);
        /// <summary>
        /// ��    ��: SearchTakeWork
        /// ���ܸ�Ҫ: ��ѯ����ȡ����Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-9
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param></param>
        /// <returns>ȡ���б�</returns>
        IList<TakeWork> SearchTakeWork();
        /// <summary>
        /// ��    ��: SearchAllEmployee
        /// ���ܸ�Ҫ: ��ȡ����Ա��
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-10
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param></param>
        /// <returns>��Ա�б�</returns>
        IList<Employee> SearchAllEmployee();
        #endregion
    }
}
