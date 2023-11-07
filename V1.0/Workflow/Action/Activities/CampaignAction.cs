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
    /// ��    ��: CampaignAction
    /// ���ܸ�Ҫ: �����Action
    /// ��    ��: 
    /// ����ʱ��: 
    /// �� �� ��: ��ǿ
    /// ����ʱ��: 2009-1-21
    /// ��    ��: ��������
    /// </summary>
    public sealed class CampaignAction
    {
        #region ���Ա
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

        #region ����Ӫ���
        /// <summary>
        /// ��    ��: InsertCampaign
        /// ���ܸ�Ҫ: ����Ӫ���
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-15
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        public void InsertCampaign()
        {
            campaignService.InsertCampaign(model.Campaign);
        }
        #endregion

        #region ��ѯ���е�Ӫ���
        /// <summary>
        /// ��    ��: SearchAllCampaign
        /// ���ܸ�Ҫ: ��������ѯ���е�Ӫ���
        /// ��    ��:������
        /// ����ʱ��: 2009��2��16��14:10:35
        /// �� �� ��: 
        /// ����ʱ��: 
        /// ��    ��: 
        /// </summary>
        public void SearchAllCampaign(int currentPageIndex)
        {
            Hashtable condition = new Hashtable();
            condition.Add("PageCount", Constants.ROW_COUNT_FOR_PAGER);
            condition.Add("PageIndex", currentPageIndex);
            model.CampaignList = searchCampaignService.SelectAllCampaign(condition);
        }

        /// <summary>
        /// ��    ��: SearchAllCampaignRowCount
        /// ���ܸ�Ҫ: ��ѯ���е�Ӫ�����¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��16��13:21:14
        /// �� �� ��: 
        /// ����ʱ��: 
        /// ��    ��: 
        /// </summary>
        public long SearchAllCampaignRowCount() 
        {
            return searchCampaignService.SelectAllCampaignRowCount();
        }

        /// <summary>
        /// ��    ��: SearchAllCampaign
        /// ���ܸ�Ҫ: ��ѯ���е�Ӫ���
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-15
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        public void SearchAllCampaign()
        {
            model.CampaignList = searchCampaignService.SelectAllCampaign();
        }
        #endregion

        #region ͨ��CampaignId��ѯCampaign Info
        /// <summary>
        /// ��    ��: SearchCampaignByCampaignId
        /// ���ܸ�Ҫ: ͨ��CampaignId��ѯCampaign Info
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-15
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        public void SearchCampaignByCampaignId()
        {
            model.Campaign = searchCampaignService.SelectCampaignByCampaignId(model.Id);
        }
        #endregion

        #region ɾ��Campaign
        /// <summary>
        /// ��    ��: DeleteCampaignById
        /// ���ܸ�Ҫ: ɾ��Campaign
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-18
        /// �� �� ��: ��ǿ
        /// ����ʱ��: 2009-1-21
        /// ��    ��: ��������
        /// </summary>
        public void DeleteCampaignById()
        {
            campaignService.DeleteCampaignById(model.Id);
        }
        #endregion

        #region ͨ��CampaignId����Campaign
        /// <summary>
        /// ��    ��: UpdateCampaign
        /// ���ܸ�Ҫ: ͨ��CampaignId����Campaign
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-19
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateCampaign()
        {
            campaignService.UpdateCampaign(model.Campaign);
        }
        #endregion
    }
}
