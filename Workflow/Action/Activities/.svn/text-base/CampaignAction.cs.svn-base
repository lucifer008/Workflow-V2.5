using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.CompaignManage;
using Workflow.Service.CustomerManager;
namespace Workflow.Action
{
    /// <summary>
    /// 名    称: CampaignAction
    /// 功能概要: 活动管理Action
    /// 作    者: 
    /// 创建时间: 
    /// 修 正 人: 付强
    /// 修正时间: 2009-1-21
    /// 描    述: 代码整理
    /// </summary>
    public sealed class CampaignAction
    {
        #region 类成员
        private CampaignModel model = new CampaignModel();
        public CampaignModel Model
        {
            get { return model; }
        }
        private ISearchCampaignService searchCampaignService;
        public ISearchCampaignService SearchCampaignService
        {
            set { searchCampaignService = value; }
        }
        private ICampaignService campaignService;
        public ICampaignService CampaignService
        {
            set { campaignService = value; }
        }
        #endregion

        #region 新增营销活动
        /// <summary>
        /// 名    称: InsertCampaign
        /// 功能概要: 新增营销活动
        /// 作    者: liuwei
        /// 创建时间: 2007-10-15
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        public void InsertCampaign()
        {
            campaignService.InsertCampaign(model.Campaign);
        }
        #endregion

        #region 查询所有的营销活动
        /// <summary>
        /// 名    称: SearchAllCampaign
        /// 功能概要: 按条件查询所有的营销活动
        /// 作    者:张晓林
        /// 创建时间: 2009年2月16日14:10:35
        /// 修 正 人: 
        /// 修正时间: 
        /// 描    述: 
        /// </summary>
        public void SearchAllCampaign(int currentPageIndex)
        {
            Hashtable condition = new Hashtable();
            condition.Add("PageCount", Constants.ROW_COUNT_FOR_PAGER);
            condition.Add("PageIndex", currentPageIndex);
            model.CampaignList = searchCampaignService.SelectAllCampaign(condition);
        }

        /// <summary>
        /// 名    称: SearchAllCampaignRowCount
        /// 功能概要: 查询所有的营销活动记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月16日13:21:14
        /// 修 正 人: 
        /// 修正时间: 
        /// 描    述: 
        /// </summary>
        public long SearchAllCampaignRowCount() 
        {
            return searchCampaignService.SelectAllCampaignRowCount();
        }

        /// <summary>
        /// 名    称: SearchAllCampaign
        /// 功能概要: 查询所有的营销活动
        /// 作    者: liuwei
        /// 创建时间: 2007-10-15
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        public void SearchAllCampaign()
        {
            model.CampaignList = searchCampaignService.SelectAllCampaign();
        }
        #endregion

        #region 通过CampaignId查询Campaign Info
        /// <summary>
        /// 名    称: SearchCampaignByCampaignId
        /// 功能概要: 通过CampaignId查询Campaign Info
        /// 作    者: liuwei
        /// 创建时间: 2007-10-15
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        public void SearchCampaignByCampaignId()
        {
            model.Campaign = searchCampaignService.SelectCampaignByCampaignId(model.Id);
        }
        #endregion

        #region 删除Campaign
        /// <summary>
        /// 名    称: DeleteCampaignById
        /// 功能概要: 删除Campaign
        /// 作    者: liuwei
        /// 创建时间: 2007-10-18
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-21
        /// 描    述: 代码整理
        /// </summary>
        public void DeleteCampaignById()
        {
            campaignService.DeleteCampaignById(model.Id);
        }
        #endregion

        #region 通过CampaignId更新Campaign
        /// <summary>
        /// 名    称: UpdateCampaign
        /// 功能概要: 通过CampaignId更新Campaign
        /// 作    者: liuwei
        /// 创建时间: 2007-10-19
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateCampaign()
        {
            campaignService.UpdateCampaign(model.Campaign);
        }
        #endregion
    }
}
