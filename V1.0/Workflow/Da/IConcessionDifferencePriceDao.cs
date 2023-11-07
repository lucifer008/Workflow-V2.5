using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table CONCESSION_DIFFERENCE_PRICE ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IConcessionDifferencePriceDao : IDaoBase<ConcessionDifferencePrice>
    {
        /// <summary>
        /// ͨ��ConcessionIdɾ��ConcessionDifferencePrice���е���Ϣ
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-19
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void DeletedConcessionDifferencePriceByConcessionId(long Id);
        /// <summary>
        /// ͨ��CampaignIdɾ��ConcessionDifferencePrice���е���Ϣ
        /// </summary>
        /// <param name="Id">CampaignId</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-22
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void DeleteConcessionDifferencePriceByCampaignId(long Id);
        /// <summary>
        /// ͨ��ConcessionId��ѯConcessionDifferencePrice���е���Ϣ
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-22
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<ConcessionDifferencePrice> SelectDifferencePriceByConcessionId(long Id);
    }
}
