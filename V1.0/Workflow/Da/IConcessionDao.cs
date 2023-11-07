using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table CONCESSION 对应的Dao 接口
	/// </summary>
    public interface IConcessionDao : IDaoBase<Concession>
    {
        /// <summary>
        /// 通过CampaignId查询该活动具体信息
        /// </summary>
        /// <param name="Id">CampaignId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-7
        /// 修正履历:
        /// 修正时间:
        /// </remarks>

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
        /// 删除Concession
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-18
        /// 修正履历:张晓林
        /// 修正时间:2009年3月17日13:58:36
        /// 修正描述:将物理删除改为逻辑删除
        /// </remarks>
        void DeleteConcessionById(long Id);

        /// <summary>
        /// 根据活动Id删除活动
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-22
        /// 修正履历:张晓林
        /// 修正时间:2009年3月17日13:58:36
        /// 修正描述:将物理删除改为逻辑删除
        /// </remarks>
        void DeleteCampaignById(long Id);

        /// <summary>
        /// 通过ConcessionId查询CampaignName
        /// </summary>
        /// <param name="Id">ConcessionId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
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
        /// 名    称: SearchConcessionList
        /// 功能概要: 按照条件查询Concession信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月19日18:05:47
        /// 修 正 人:
        /// 修正时间:
        /// 描    述:
        /// </summary>
        /// <param name="concession"></param>
        /// <returns></returns>
        IList<Concession> SearchConcessionList(Concession concession);
    }
}
