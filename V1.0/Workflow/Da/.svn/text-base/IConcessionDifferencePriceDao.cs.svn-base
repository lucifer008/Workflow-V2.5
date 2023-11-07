using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table CONCESSION_DIFFERENCE_PRICE 对应的Dao 接口
	/// </summary>
    public interface IConcessionDifferencePriceDao : IDaoBase<ConcessionDifferencePrice>
    {
        /// <summary>
        /// 通过ConcessionId删除ConcessionDifferencePrice表中的信息
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-19
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void DeletedConcessionDifferencePriceByConcessionId(long Id);
        /// <summary>
        /// 通过CampaignId删除ConcessionDifferencePrice表中的信息
        /// </summary>
        /// <param name="Id">CampaignId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void DeleteConcessionDifferencePriceByCampaignId(long Id);
        /// <summary>
        /// 通过ConcessionId查询ConcessionDifferencePrice表中的信息
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<ConcessionDifferencePrice> SelectDifferencePriceByConcessionId(long Id);
    }
}
