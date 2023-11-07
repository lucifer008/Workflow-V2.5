using System;
using System.Collections.Generic;
using System.Text;

using Workflow.Action.Activities.Model;
using Workflow.Service.CompaignManage;
using Workflow.Service;
using Workflow.Service.SystemManege.PriceManage;
using Workflow.Da.Domain;
using Workflow.Support;
using System.Collections;

namespace Workflow.Action.Activities
{
	/// <summary>
	/// ��    ��: BuySendAction
    /// ���ܸ�Ҫ: ��M��N�Action
    /// ��    ��: 
	/// ����ʱ��: 2010-04-15
    /// �� �� ��: ������
    /// ����ʱ��: 
    /// ��    ��: 
    /// </summary>
	public class BuySendAction
	{
		#region ���Ա
		private BuySendModel model = new BuySendModel();
		/// <summary>
		/// model
		/// </summary>
		public BuySendModel Model
		{
			get { return model; }
			set { model = value; }
		}

		private ISearchCampaignService searchCampaignService;
		/// <summary>
		/// SearchCampaignService
		/// </summary>
		public ISearchCampaignService SearchCampaignService
		{
			set { searchCampaignService = value; }
		}
		
		private IMasterDataService masterDataService;
		/// <summary>
		/// IMasterDataService
		/// </summary>
		public IMasterDataService MasterDataService
		{
			get { return masterDataService;}
			set { masterDataService = value;}
		}

		private ICampaignService campaignService;
		/// <summary>
		/// CampaignService
		/// </summary>
		public ICampaignService CampaignService
		{
			set { campaignService = value; }
		}

		private IPriceService priceService;
		/// <summary>
		/// PriceService
		/// </summary>
		public IPriceService PriceService
		{
			get { return priceService; }
			set { priceService = value; }
		}
	
		#endregion

		#region ��ȡ����Ӫ���

		/// <summary>
		/// ��    ��: GetAllConcessionList
		/// ���ܸ�Ҫ: ��ȡ����Ӫ����б�
		/// ��    ��: ������ 
		/// ����ʱ��: 2010��4��16��
		/// ��������:
		/// ����ʱ��:
		/// </summary>
		public void GetAllCampaignList()
		{
			model.CampaignList = searchCampaignService.SelectAllCampaign();
		}
		#endregion

		#region ��ȡ����ҵ������
		/// <summary>
		/// ��    ��:GetAllBusinessType
		/// ���ܸ�Ҫ:��ȡ����ҵ������
		/// ��    ��:������
		/// ����ʱ��:2010��4��16��
		/// ��������:
		/// ����ʱ��:
		/// </summary>
		public void GetAllBusinessType()
		{
			model.BusinessTypeList = masterDataService.GetBusinessTypes();
		}
		#endregion

		#region ����»
		/// <summary>
		/// ��    ��: AddBuySendCampaign
		/// ���ܸ�Ҫ: ����»
		/// ��    ��; ������
		/// ����ʱ��:2010��4��16��
		/// ��������:
		/// ����ʱ��:
		/// </summary>
		public void AddBuySendCampaign()
		{
			//��ȡ���м۸�
			BaseBusinessTypePriceSet domain = priceService.GetTheMostBaseBusinessTypePrice(model.BuySend.BaseBusinessTypePriceSet);
			if (null == domain)
			{
				Workflow.Support.Log.LogHelper.WriteError("�����һ��һ���û�л�ȡ���۸�", Constants.LOGGER_NAME);
				throw new Workflow.Support.Exception.WorkflowException("û�л�ȡ���۸�");
			}
			model.BuySend.BaseBusinessTypePriceSetId = domain.Id;

			campaignService.AddBuySendCampaign(model.BuySend);
		}
		#endregion

		#region ��ȡ�����
		/// <summary>
		/// ��    ��:GetBuySendCampaingById
		/// ���ܸ�Ҫ:��ȡ�����
		/// ��    ��:������
		/// ����ʱ��:2010��4��16��
		/// ��������:
		/// ����ʱ��:
		public void GetBuySendCampaingById()
		{
			model.BuySend = campaignService.GetBuySendInfo(model.BuySendId);
		}
		#endregion

		#region ��ȡ��M��N������¼��
		/// <summary>
		/// ��    ��: GetAllBuySendListInfoRowCount
		/// ���ܸ�Ҫ: ��ȡ��M��N������¼��
		/// ��    ��: ������
		/// ����ʱ��: 2010��4��19��
		/// �� �� ��: 
		/// ����ʱ��: 
		/// ��    ��: 
		/// </summary>
		public void GetAllBuySendListInfoRowCount()
		{
			Hashtable ht = new Hashtable();
			model.RecordCount = campaignService.GetAllBuySendListInfoRowCount(ht);
		}
		#endregion

		#region ��ȡ��M��N����(��ҳ)
		/// <summary>
		/// ��    ��: GetAllBuySendListInfo
		/// ���ܸ�Ҫ: ��ȡ��M��N����(��ҳ)
		/// ��    ��: ������
		/// ����ʱ��: 2010��4��19��
		/// �� �� ��: 
		/// ����ʱ��: 
		/// ��    ��: 
		/// </summary>
		/// <param name="currentPageIndex"></param>
		public void GetAllBuySendListInfo(int currentPageIndex)
		{
			Hashtable condition = new Hashtable();
			condition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
			condition.Add("RowIndex", currentPageIndex - 1);

			model.BuySendList = campaignService.GetAllBuySendListInfo(condition);
		}
		#endregion

		#region �޸���M��N����
		
		public void EditBuySendCampaign()
		{
			//��ȡ���м۸�
			BaseBusinessTypePriceSet domain = priceService.GetTheMostBaseBusinessTypePrice(model.BuySend.BaseBusinessTypePriceSet);
			if (null == domain)
			{
				Workflow.Support.Log.LogHelper.WriteError("�����һ��һ���û�л�ȡ���۸�", Constants.LOGGER_NAME);
				throw new Workflow.Support.Exception.WorkflowException("û�л�ȡ���۸�");
			}
			model.BuySend.BaseBusinessTypePriceSetId = domain.Id;

			campaignService.EditBuySendCampaing(model.BuySend);
		}
		#endregion

		#region ��ȡ���м۸�
		/// <summary>
		/// ��    ��: GetBaseBusinessTypePriceSetInfo
		/// ���ܸ�Ҫ: ��ȡ���м۸�
		/// ��    ��: ������
		/// ����ʱ��: 2010��4��19��
		/// �� �� ��: 
		/// ����ʱ��: 
		/// ��    ��: 
		/// </summary>
		public void GetBaseBusinessTypePriceSetInfo()
		{
			BaseBusinessTypePriceSet domain = new BaseBusinessTypePriceSet();
			domain.Id = model.BuySend.BaseBusinessTypePriceSetId;

			model.BaseBusinessTypePriceSet = priceService.GetBaseBusinessTypePriceSetById(domain);
		}
		#endregion

		#region ��ȡ�۸�����
		/// <summary>
		/// ��    ��: GetPriceFactor
		/// ���ܸ�Ҫ: ��ȡ�۸�����
		/// ��    ��: ������
		/// ����ʱ��: 2010��4��19��
		/// �� �� ��: 
		/// ����ʱ��: 
		/// ��    ��: 
		/// </summary>
		public void GetPriceFactor()
		{
			model.PriceFactor = priceService.GetPriceFactor();
		}
		#endregion

		#region ɾ����M��N����
		/// <summary>
		/// ��    ��: RemoveBuySend
		/// ���ܸ�Ҫ: ɾ����M��N����
		/// ��    ��: ������
		/// ����ʱ��: 2010��4��20��
		/// �� �� ��: 
		/// ����ʱ��: 
		/// ��    ��: 
		/// </summary>
		public void RemoveBuySend()
		{
			campaignService.RemoveBuySend(model.BuySendId);
		}
		#endregion
	}
}
