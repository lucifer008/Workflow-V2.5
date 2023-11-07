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
    /// ��    ��: ConcessionAction
    /// ���ܸ�Ҫ: �����Action
    /// ��    ��: 
    /// ����ʱ��: 
    /// �� �� ��: ��ǿ
    /// ����ʱ��: 2009-1-21
    /// ��    ��: ��������
    /// </summary>
    public sealed class ConcessionAction
    {
        #region ���Ա
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

        #region //��ȡ����Ӫ���

        /// <summary>
        /// ��    ��: GetAllConcessionList
        /// ���ܸ�Ҫ: ��ȡ����Ӫ����б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��23��13:04:28
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void GetAllCampaignList() 
        {
            model.CampaignList = searchCampaignService.SelectAllCampaign(); 
        }
        #endregion

        #region //����������ѯ�Żݷ���
        /// <summary>
        /// ��    ��: GetAllConcessionListInfo
        /// ���ܸ�Ҫ: ��������ȡ����Ӫ���������Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��23��13:04:28
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void SearchConcession() 
        {
            model.ConcessionList = campaignService.SearchConcessionList(model.Concession);

        }
        #endregion

        #region ͨ��CampaignId��ѯConcession����Ϣ
        /// <summary>
        /// ��    ��: SearchConcessionByCampaignId
        /// ���ܸ�Ҫ: ͨ��CampaignId��ѯConcession����Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-15
        /// ��������:
        /// ����ʱ��:
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
        /// ��    ��: SearchConcessionByCampaignIdRowCount
        /// ���ܸ�Ҫ: ͨ��CampaignId��ѯConcession����Ϣ��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��23��10:05:01
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchConcessionByCampaignIdRowCount() 
        {
            Hashtable condition = new Hashtable();
            condition.Add("CampaignId", model.CampaignId);
            return searchCampaignService.SearchConcessionByCampaignIdRowCount(condition);
        }
        #endregion

        #region ��ȡ������һ��
        /// <summary>
        /// ��    ��: SearchMemberCardLevel
        /// ���ܸ�Ҫ: ��ȡ������һ��
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void SearchMemberCardLevel()
        {
            model.MemberCardLevelList = masterDataService.GetMemberCardLevels();
        }
        #endregion

        #region �����Żݻ
        /// <summary>
        /// ��    ��: InsertConcession
        /// ���ܸ�Ҫ: �����Żݻ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-17
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void InsertConcession()
        {
            campaignService.InsertConcession(model.Concession);
        }
        #endregion

        #region ɾ��Concession
        /// <summary>
        /// ��    ��: DeleteConcessionById
        /// ���ܸ�Ҫ: ɾ��Concession
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-18
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void DeleteConcessionById()
        {
            campaignService.DeleteConessionById(model.Id);
        }
        #endregion

        #region ɾ��Campaign
        /// <summary>
        /// ��    ��: DeleteCampaignById
        /// ���ܸ�Ҫ: ɾ��Campaign
        /// ��    ��: ������
        /// ����ʱ��: 2009��3��17��14:10:34
        /// �� �� ��: 
        /// ����ʱ��: 
        /// ��    ��: 
        /// </summary>
        /// <param name="campaign">Ҫɾ���Ļ��id</param>
        public void DeleteCampaignById() 
        {
            campaignService.DeleteCampaignById(model.CampaignId);
        }
        #endregion

        #region ͨ��ConcessionId��ѯ������Ϣ
        /// <summary>
        /// ��    ��: SearchConcessionById
        /// ���ܸ�Ҫ: ͨ��ConcessionId��ѯ������Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-18
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void SearchConcessionById()
        {
            model.Concession = searchCampaignService.SeleteConcessionById(model.Id);
        }

        /// <summary>
        /// ��    ��: GetConcessionMembercardLevel
        /// ���ܸ�Ҫ: ͨ��ConcessionId��ѯ�������õĿ���Ϣ 
        /// ��    ��: ������
        /// ����ʱ��: 2009��3��17��17:24:56
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<MemberCardLevel> GetConcessionMembercardLevel() 
        {
            return searchCampaignService.GetConcessionMemberCardLelvelInfo(model.Id);
        }
        #endregion

        #region ͨ��ConcessionId��ѯ������Ϣ(��Ajax�е���)
        /// <summary>
        /// ��    ��: SearchConcessionById
        /// ���ܸ�Ҫ: ͨ��ConcessionId��ѯ������Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-22
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public Concession SearchConcessionById(long Id)
        {
            return searchCampaignService.SeleteConcessionById(Id);
        }
        #endregion

        #region ����Concession
        /// <summary>
        /// ��    ��: UpdateConcession
        /// ���ܸ�Ҫ: ����Concession
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-19
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateConcession()
        {
            campaignService.UpdateConcession(model.Concession);
        }
        #endregion

        #region ͨ��ConcessionId��ѯConcessionDifferencePrice
        /// <summary>
        /// ��    ��: SearchConcessionDifferencePriceByConcessionId
        /// ���ܸ�Ҫ: ͨ��ConcessionId��ѯConcessionDifferencePrice
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-22
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void SearchConcessionDifferencePriceByConcessionId()
        {
            model.ConcessionDifferencePriceList = searchCampaignService.SearchConcessionDifferencePriceByConcessionId(model.Id);
        }
        #endregion

        #region //��������ȡ����Ӫ���������Ϣ

        /// <summary>
        /// ��    ��: GetAllConcessionListInfo
        /// ���ܸ�Ҫ: ��������ȡ����Ӫ���������Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��23��13:04:28
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void GetAllConcessionListInfo(int currentPageIndex)
        {
            Hashtable condition = new Hashtable();
            condition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            condition.Add("RowIndex", currentPageIndex - 1);
            model.ConcessionList = searchCampaignService.GetAllConcessionListInfo(condition);
        }

        /// <summary>
        /// ��    ��: GetAllConcessionListInfoRowCount
        /// ���ܸ�Ҫ: ��������ȡ����Ӫ���������Ϣ��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��23��13:04:28
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long GetAllConcessionListInfoRowCount() 
        {
            Hashtable condition = new Hashtable();
            return searchCampaignService.GetAllConcessionListInfoRowCount(condition);
        }
        #endregion
    }
}
