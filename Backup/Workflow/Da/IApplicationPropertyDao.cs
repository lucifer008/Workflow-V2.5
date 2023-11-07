using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table APPLICATION_PROPERTIES ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IApplicationPropertyDao : IDaoBase<ApplicationProperty>
    {
        /// <summary>
        /// ���ݲ���Id��ȡ����ֵ
        /// </summary>
        /// <param name="key">����Id</param>
        /// <returns></returns>
        /// <remarks>
        /// ����: 
        /// ����: 
        /// ��������: ������ �ӹ�˾��ֵ��ѯ����
        /// ����ʱ��: 2010��4��26��15:47:49
        /// </remarks>
		string GetValue(string key);

        #region//Ӧ�ò���ά��
        /// <summary>
        /// ��   ��:  SearchApplictionPeroptery
        /// ���ܸ�Ҫ: ��ȡӦ�ò�����Ϣ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��10:49:29
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<ApplicationProperty> SearchApplictionPeroptery(ApplicationProperty applicationProperty);

        /// <summary>
        /// ��   ��:  SearchApplictionPeropteryRowCount
        /// ���ܸ�Ҫ: ��ȡӦ�ò�����Ϣ�б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��10:49:29
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchApplictionPeropteryRowCount(ApplicationProperty applicationProperty);

        /// <summary>
        /// ��    �ƣ�DeletePropertyData
        /// ���ܸ�Ҫ��ɾ��Ӧ�ó������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��13:52:10
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        void DeletePropertyData(string proteryId);
        #endregion


        /// <summary>
        /// ��    ��; GetItem
        /// ���ܸ�Ҫ: ��ȡ������Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2010��7��1��
        /// </summary>
        /// <param name="proteryId"></param>
        ApplicationProperty GetItem(string proteryId);
    }
}
