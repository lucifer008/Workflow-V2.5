using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Support;
using Workflow.Da.Domain;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名    称: ConcessionDaoImpl
    /// 功能概要: 营销活动优惠方案接口IConcessionDao实现类
    /// 作    者: 
    /// 创建时间: 
    /// 修正履历: 张晓林
    /// 修正时间: 2009年2月23日9:51:24
    /// </summary>
    public class ConcessionDaoImpl : Workflow.Da.Base.DaoBaseImpl<Concession>, IConcessionDao
    {
        #region 通过CampaignId查询Concession
        /// <summary>
        /// 根据条件查询优惠方案查询(分页)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-7
        /// 修正履历:张晓林
        /// 修正时间:2009年2月23日9:52:32
        /// 修正描述:增加分页功能；完善查询
        /// </remarks>
        public IList<Concession> SearchConcessionByCampaignId(Hashtable condition)
        {
            condition.Add("CompanyId",ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<Concession>("Concession.SelectConcessionByCampaignId", condition);
        }

        /// <summary>
        /// 名    称: SearchConcessionByCampaignIdRowCount
        /// 功能概要: 通过CampaignId查询Concession的信息记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日10:05:01
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchConcessionByCampaignIdRowCount(Hashtable condition) 
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForObject<long>("Concession.SelectConcessionByCampaignIdRowCount", condition);
        }
        #endregion

        #region 删除Concession
        /// <summary>
        /// 功能概要:根据方案Id删除方案
        /// 创建时间:
        /// 修正履历:张晓林
        /// 修正时间:2009年3月17日13:58:36
        /// 修正描述:将物理删除改为逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteConcessionById(long Id)
        {
            Hashtable condtion = new Hashtable();
            condtion.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condtion.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condtion.Add("Id", Id);
            sqlMap.Update("Concession.DeleteConcessionById", condtion);
        }
        #endregion

        #region 通过CampaingId删除Concession
        /// <summary>
        /// 名    称:
        /// 功能概要:根据活动Id删除活动
        /// 创建时间:
        /// 修正履历:张晓林
        /// 修正时间:2009年3月17日13:58:36
        /// 修正描述:将物理删除改为逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteCampaignById(long Id)
        {
            Hashtable condtion = new Hashtable();
            condtion.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condtion.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condtion.Add("Id", Id);
            sqlMap.Update("Concession.DeleteCampaignById", condtion);
        }
        #endregion

        #region 通过ConcessionID查询CampaignName
        public string SelectCampaignNameByConcessionId(long Id)
        {
            object obj = sqlMap.QueryForObject("Concession.SelectCampaignNameByConcessionId", Id);

            return (string)obj;
        }
        #endregion

        #region //按条件获取所有营销活动方案信息
        /// <summary>
        /// 名    称: GetAllConcessionListInfo
        /// 功能概要: 按条件获取所有营销活动方案信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日13:04:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<Concession> GetAllConcessionListInfo(Hashtable condition) 
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<Concession>("Concession.GetAllConcessionListInfo", condition);
        }

        /// <summary>
        /// 名    称: GetAllConcessionListInfoRowCount
        /// 功能概要: 按条件获取所有营销活动方案信息记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日13:04:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long GetAllConcessionListInfoRowCount(Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForObject<long>("Concession.GetAllConcessionListInfoRowCount", condition);
        }

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
        public IList<Concession> SearchConcessionList(Concession concession)
        {
            concession.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            concession.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            return sqlMap.QueryForList<Concession>("Concession.SearchConcessionList", concession);
        }
        #endregion
    }
}
