using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名    称: CampaignDaoImpl
    /// 功能概要: 营销管理Dao接口实现
    /// 作    者: 
    /// 创建时间: 
    /// 修正时间: 
    ///             
    /// </summary>
    public class CampaignDaoImpl : Workflow.Da.Base.DaoBaseImpl<Campaign>, ICampaignDao
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
        public IList<Campaign> SelectAllCampaign(Hashtable condition) 
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<Campaign>("Campaign.SelectAllCampaign", condition);
        }

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
        public long SelectAllCampaignRowCount() 
        {
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForObject<long>("Campaign.SelectAllCampaignRowCount", condition);
        }

        /// <summary>
        /// 名    称:GetConcessionMemberCardLelvelInfo
        /// 功能概要:根据优惠方案Id获取优惠的卡级别
        /// 作    者:张晓林
        /// 创建时间:2009年3月16日14:19:16
        /// 修正时间:
        /// 描    述:
        /// </summary>
        /// <returns></returns>
        public IList<MemberCardLevel> GetConcessionMemberCardLelvelInfo(long concessionId) 
        {
            Hashtable condition = new Hashtable();
            condition.Add("ConcessionId", concessionId);
            return sqlMap.QueryForList<MemberCardLevel>("Campaign.GetConcessionMemberCardLelvelInfo", condition);
        }

        /// <summary>
        /// 名    称:GetConcessionInfo
        /// 功能概要:获取优惠方案信息
        /// 作    者:张晓林
        /// 创建时间:2009年3月16日14:19:16
        /// 修正时间:
        /// 描    述:
        /// </summary>
        /// <returns></returns>
        public Concession GetConcessionInfo(long concessionId) 
        {
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("ConcessionId", concessionId);
            return sqlMap.QueryForObject<Concession>("Campaign.GetConcessionInfo", condition);
        } 
        #endregion

        #region 删除Campaign
        /// <summary>
        /// 删除该活动
        /// </summary>
        /// <param name="Id"></param>
        /// <remarks>
        /// 作    者: 
        /// 创建时间: 
        /// 修正履历:张晓林
        /// 修正时间:2009年2月16日13:22:42
        /// 将原来物理删除改为逻辑删除(deleted=1)
        /// </remarks>
        public void DeleteCampaignById(long Id)
        {
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("Id", Id);
            sqlMap.Update("Campaign.DeleteCampaignById", condition);
        }

        /// <summary>
        /// 名    称: CheckCampaignIdIsNotUse
        /// 功能概要: 检查该活动是否已经正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日17:35:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckCampaignIdIsNotUse(int campaignId) 
        {
            Hashtable condition = new Hashtable();
            condition.Add("CampaignId", campaignId);
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
           return sqlMap.QueryForObject<long>("Campaign.CheckCampaignIdIsNotUse", condition);
        }

        /// <summary>
        /// 名    称: CheckCampaignNameIsNotUse
        /// 功能概要: 检查该活动名称是否可用
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月24日17:44:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckCampaignNameIsNotUse(string campaignName) 
        {
            Hashtable condition = new Hashtable();
            condition.Add("CampaignName", campaignName);
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForObject<long>("Campaign.CheckCampaignNameIsNotUse", condition);
        }
        #endregion

    }
}
