using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.CompaignManage;

namespace Workflow.Action
{
    /// <summary>
    /// 名    称: ConcessionAction
    /// 功能概要: 活动管理Action
    /// 作    者: 
    /// 创建时间: 
    /// 修 正 人: 付强
    /// 修正时间: 2009-1-21
    /// 描    述: 代码整理
    /// </summary>
    public sealed class ConcessionAction
    {
        #region 类成员
        private ConcessionModel model = new ConcessionModel();
        public ConcessionModel Model
        {
            get { return model; }
        }
        private ICampaignService campaignService;
        public ICampaignService CampaignService
        {
            set { campaignService = value; }
        }
        private ISearchCampaignService searchCampaignService;
        public ISearchCampaignService SearchCampaignService
        {
            set { searchCampaignService = value; }
        }
        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }
        #endregion

        #region //获取所有营销活动

        /// <summary>
        /// 名    称: GetAllConcessionList
        /// 功能概要: 获取所有营销活动列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日13:04:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void GetAllCampaignList() 
        {
            model.CampaignList = searchCampaignService.SelectAllCampaign(); 
        }
        #endregion

        #region //按照条件查询优惠方案
        /// <summary>
        /// 名    称: GetAllConcessionListInfo
        /// 功能概要: 按条件获取所有营销活动方案信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日13:04:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchConcession() 
        {
            model.ConcessionList = campaignService.SearchConcessionList(model.Concession);

        }
        #endregion

        #region 通过CampaignId查询Concession的信息
        /// <summary>
        /// 名    称: SearchConcessionByCampaignId
        /// 功能概要: 通过CampaignId查询Concession的信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-15
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchConcessionByCampaignId(int currentPageIndex)
        {
            Hashtable condition = new Hashtable();
            condition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            condition.Add("RowIndex", currentPageIndex - 1);
            condition.Add("CampaignId", model.CampaignId);
            model.ConcessionList = searchCampaignService.SearchConcessionByCampaignId(condition);
        }

        /// <summary>
        /// 名    称: SearchConcessionByCampaignIdRowCount
        /// 功能概要: 通过CampaignId查询Concession的信息记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日10:05:01
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchConcessionByCampaignIdRowCount() 
        {
            Hashtable condition = new Hashtable();
            condition.Add("CampaignId", model.CampaignId);
            return searchCampaignService.SearchConcessionByCampaignIdRowCount(condition);
        }
        #endregion

        #region 获取卡级别一览
        /// <summary>
        /// 名    称: SearchMemberCardLevel
        /// 功能概要: 获取卡级别一览
        /// 作    者: liuwei
        /// 创建时间: 2007-10-16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchMemberCardLevel()
        {
            model.MemberCardLevelList = masterDataService.GetMemberCardLevels();
        }
        #endregion

        #region 插入优惠活动
        /// <summary>
        /// 名    称: InsertConcession
        /// 功能概要: 插入优惠活动
        /// 作    者: liuwei
        /// 创建时间: 2007-10-17
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void InsertConcession()
        {
            campaignService.InsertConcession(model.Concession);
        }
        #endregion

        #region 删除Concession
        /// <summary>
        /// 名    称: DeleteConcessionById
        /// 功能概要: 删除Concession
        /// 作    者: liuwei
        /// 创建时间: 2007-10-18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void DeleteConcessionById()
        {
            campaignService.DeleteConessionById(model.Id);
        }
        #endregion

        #region 删除Campaign
        /// <summary>
        /// 名    称: DeleteCampaignById
        /// 功能概要: 删除Campaign
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月17日14:10:34
        /// 修 正 人: 
        /// 修正时间: 
        /// 描    述: 
        /// </summary>
        /// <param name="campaign">要删除的活动的id</param>
        public void DeleteCampaignById() 
        {
            campaignService.DeleteCampaignById(model.CampaignId);
        }
        #endregion

        #region 通过ConcessionId查询方案信息
        /// <summary>
        /// 名    称: SearchConcessionById
        /// 功能概要: 通过ConcessionId查询方案信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchConcessionById()
        {
            model.Concession = searchCampaignService.SeleteConcessionById(model.Id);
        }

        /// <summary>
        /// 名    称: GetConcessionMembercardLevel
        /// 功能概要: 通过ConcessionId查询方案适用的卡信息 
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月17日17:24:56
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<MemberCardLevel> GetConcessionMembercardLevel() 
        {
            return searchCampaignService.GetConcessionMemberCardLelvelInfo(model.Id);
        }
        #endregion

        #region 通过ConcessionId查询方案信息(在Ajax中调用)
        /// <summary>
        /// 名    称: SearchConcessionById
        /// 功能概要: 通过ConcessionId查询方案信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public Concession SearchConcessionById(long Id)
        {
            return searchCampaignService.SeleteConcessionById(Id);
        }
        #endregion

        #region 更新Concession
        /// <summary>
        /// 名    称: UpdateConcession
        /// 功能概要: 更新Concession
        /// 作    者: liuwei
        /// 创建时间: 2007-10-19
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateConcession()
        {
            campaignService.UpdateConcession(model.Concession);
        }
        #endregion

        #region 通过ConcessionId查询ConcessionDifferencePrice
        /// <summary>
        /// 名    称: SearchConcessionDifferencePriceByConcessionId
        /// 功能概要: 通过ConcessionId查询ConcessionDifferencePrice
        /// 作    者: liuwei
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchConcessionDifferencePriceByConcessionId()
        {
            model.ConcessionDifferencePriceList = searchCampaignService.SearchConcessionDifferencePriceByConcessionId(model.Id);
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
        public void GetAllConcessionListInfo(int currentPageIndex)
        {
            Hashtable condition = new Hashtable();
            condition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            condition.Add("RowIndex", currentPageIndex - 1);
            model.ConcessionList = searchCampaignService.GetAllConcessionListInfo(condition);
        }

        /// <summary>
        /// 名    称: GetAllConcessionListInfoRowCount
        /// 功能概要: 按条件获取所有营销活动方案信息记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月23日13:04:28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long GetAllConcessionListInfoRowCount() 
        {
            Hashtable condition = new Hashtable();
            return searchCampaignService.GetAllConcessionListInfoRowCount(condition);
        }
        #endregion
    }
}
