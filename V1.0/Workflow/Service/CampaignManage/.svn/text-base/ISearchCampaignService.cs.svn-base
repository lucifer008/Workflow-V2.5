using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.CompaignManage
{
    /// <summary>
    /// 名    称: ISearchCompaignService
    /// 功能概要: 活动管理查询Service的接口
    /// 作    者: 付强
    /// 创建时间: 2009-1-21
    /// 修 正 人: 
    /// 修正时间: 
    /// 描    述: 代码整理
    /// </summary>
    public interface ISearchCampaignService
    {
        #region 活动查询
        /// <summary>
        /// 查询所有的营销活动
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-15
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        IList<Campaign> SelectAllCampaign();

        /// <summary>
        /// 按条件查询所有的营销活动
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-15
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        IList<Campaign> SelectAllCampaign(Hashtable condition);

        /// <summary>
        /// 查询所有的营销活动记录数
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月16日13:22:42
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        long SelectAllCampaignRowCount();

        /// <summary>
        /// 通过CampaignId查询Campaign Info
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-15
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        Campaign SelectCampaignByCampaignId(long Id);
        #endregion

        #region 活动下的优惠查询
        /// <summary>
        /// 名    称: SearchConcessionByCampaignId
        /// 功能概要: 通过CampaignId查询该活动具体信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-7
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id">CampaignId</param>
        /// <returns></returns>
        IList<Concession> SearchConcessionByCampaignId(Hashtable condition);

        /// <summary>
        /// 名    称: SearchConcessionByCampaignIdRowCount
        /// 功能概要: 通过CampaignId查询Concession的信息记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日10:05:01
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchConcessionByCampaignIdRowCount(Hashtable condition);

        /// <summary>
        /// 名    称: SeleteConcessionById
        /// 功能概要: 通过ConcessionId查询方案的信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        Concession SeleteConcessionById(long Id);

        /// <summary>
        /// 名    称: SearchConcessionDifferencePriceByConcessionId
        /// 功能概要: 通过ConcessionId查询ConcessionDifferencePrice表中的相关信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        IList<ConcessionDifferencePrice> SearchConcessionDifferencePriceByConcessionId(long Id);
        /// <summary>
        /// 名    称: 
        /// 功能概要: 通过ConcessionId查询CampaignName
        /// 作    者: liuwei
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        string SelectCampaignNameByConcessionId(long Id);

        /// <summary>
        /// 名    称: GetAllConcessionListInfo
        /// 功能概要: 按条件获取所有营销活动方案信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日13:04:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<Concession> GetAllConcessionListInfo(Hashtable condition);

        /// <summary>
        /// 名    称: GetAllConcessionListInfoRowCount
        /// 功能概要: 按条件获取所有营销活动方案信息记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日13:04:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long GetAllConcessionListInfoRowCount(Hashtable condition);

        /// <summary>
        /// 名    称: CheckCampaignIdIsNotUse
        /// 功能概要: 检查该活动是否已经正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日17:35:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckCampaignIdIsNotUse(int campaignId);

        /// <summary>
        /// 名    称: CheckCampaignNameIsNotUse
        /// 功能概要: 检查该活动名称是否可用
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月24日17:44:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long CheckCampaignNameIsNotUse(string campaignName);

        /// <summary>
        /// 名    称:GetConcessionMemberCardLelvelInfo
        /// 功能概要:根据优惠方案Id获取优惠的卡级别
        /// 作    者:张晓林
        /// 创建时间:2009年3月16日14:19:16
        /// 修正时间:
        /// 描    述:
        /// </summary>
        /// <returns></returns>
        IList<MemberCardLevel> GetConcessionMemberCardLelvelInfo(long concessionId);

        /// <summary>
        /// 名    称:GetConcessionInfo
        /// 功能概要:获取优惠方案信息
        /// 作    者:张晓林
        /// 创建时间:2009年3月16日14:19:16
        /// 修正时间:
        /// 描    述:
        /// </summary>
        /// <returns></returns>
        Concession GetConcessionInfo(long concessionId); 
        #endregion
    }
}
