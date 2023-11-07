using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table CONCESSION ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IConcessionDao : IDaoBase<Concession>
    {
        /// <summary>
        /// ͨ��CampaignId��ѯ�û������Ϣ
        /// </summary>
        /// <param name="Id">CampaignId</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-7
        /// ��������:
        /// ����ʱ��:
        /// </remarks>

        IList<Concession> SearchConcessionByCampaignId(Hashtable condition);

        /// <summary>
        /// ��    ��: SearchConcessionByCampaignIdRowCount
        /// ���ܸ�Ҫ: ͨ��CampaignId��ѯConcession����Ϣ��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��23��10:05:01
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchConcessionByCampaignIdRowCount(Hashtable condition);

        /// <summary>
        /// ɾ��Concession
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-18
        /// ��������:������
        /// ����ʱ��:2009��3��17��13:58:36
        /// ��������:������ɾ����Ϊ�߼�ɾ��
        /// </remarks>
        void DeleteConcessionById(long Id);

        /// <summary>
        /// ���ݻIdɾ���
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-22
        /// ��������:������
        /// ����ʱ��:2009��3��17��13:58:36
        /// ��������:������ɾ����Ϊ�߼�ɾ��
        /// </remarks>
        void DeleteCampaignById(long Id);

        /// <summary>
        /// ͨ��ConcessionId��ѯCampaignName
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-23
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        string SelectCampaignNameByConcessionId(long Id);

        /// <summary>
        /// ��    ��: GetAllConcessionListInfo
        /// ���ܸ�Ҫ: ��������ȡ����Ӫ���������Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��23��13:04:28
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<Concession> GetAllConcessionListInfo(Hashtable condition); 

        /// <summary>
        /// ��    ��: GetAllConcessionListInfoRowCount
        /// ���ܸ�Ҫ: ��������ȡ����Ӫ���������Ϣ��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��23��13:04:28
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long GetAllConcessionListInfoRowCount(Hashtable condition);

        /// <summary>
        /// ��    ��: SearchConcessionList
        /// ���ܸ�Ҫ: ����������ѯConcession��Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��3��19��18:05:47
        /// �� �� ��:
        /// ����ʱ��:
        /// ��    ��:
        /// </summary>
        /// <param name="concession"></param>
        /// <returns></returns>
        IList<Concession> SearchConcessionList(Concession concession);
    }
}
