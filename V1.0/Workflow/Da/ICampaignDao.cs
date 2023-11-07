using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table CAMPAIGN 对应的Dao 接口
	/// </summary>
    public interface ICampaignDao : IDaoBase<Campaign>
    {
        /// <summary>
        /// 删除Campaign
        /// </summary>
        /// <param name="Id">CampaignId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-18
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void DeleteCampaignById(long Id);

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
