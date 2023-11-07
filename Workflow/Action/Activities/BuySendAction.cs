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
	/// 名    称: BuySendAction
    /// 功能概要: 买M送N活动Action
    /// 作    者: 
	/// 创建时间: 2010-04-15
    /// 修 正 人: 白晓宇
    /// 修正时间: 
    /// 描    述: 
    /// </summary>
	public class BuySendAction
	{
		#region 类成员
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

		#region 获取所有营销活动

		/// <summary>
		/// 名    称: GetAllConcessionList
		/// 功能概要: 获取所有营销活动列表
		/// 作    者: 白晓宇 
		/// 创建时间: 2010年4月16日
		/// 修正履历:
		/// 修正时间:
		/// </summary>
		public void GetAllCampaignList()
		{
			model.CampaignList = searchCampaignService.SelectAllCampaign();
		}
		#endregion

		#region 获取所有业务类型
		/// <summary>
		/// 名    称:GetAllBusinessType
		/// 功能概要:获取所有业务类型
		/// 作    者:白晓宇
		/// 创建时间:2010年4月16日
		/// 修正履历:
		/// 修正时间:
		/// </summary>
		public void GetAllBusinessType()
		{
			model.BusinessTypeList = masterDataService.GetBusinessTypes();
		}
		#endregion

		#region 添加新活动
		/// <summary>
		/// 名    称: AddBuySendCampaign
		/// 功能概要: 添加新活动
		/// 作    者; 白晓宇
		/// 创建时间:2010年4月16日
		/// 修正履历:
		/// 修正时间:
		/// </summary>
		public void AddBuySendCampaign()
		{
			//获取门市价格
			BaseBusinessTypePriceSet domain = priceService.GetTheMostBaseBusinessTypePrice(model.BuySend.BaseBusinessTypePriceSet);
			if (null == domain)
			{
				Workflow.Support.Log.LogHelper.WriteError("添加买一送一活动，没有获取到价格", Constants.LOGGER_NAME);
				throw new Workflow.Support.Exception.WorkflowException("没有获取到价格");
			}
			model.BuySend.BaseBusinessTypePriceSetId = domain.Id;

			campaignService.AddBuySendCampaign(model.BuySend);
		}
		#endregion

		#region 获取活动内容
		/// <summary>
		/// 名    称:GetBuySendCampaingById
		/// 功能概要:获取活动内容
		/// 作    者:白晓宇
		/// 创建时间:2010年4月16日
		/// 修正履历:
		/// 修正时间:
		public void GetBuySendCampaingById()
		{
			model.BuySend = campaignService.GetBuySendInfo(model.BuySendId);
		}
		#endregion

		#region 获取买M送N方案记录数
		/// <summary>
		/// 名    称: GetAllBuySendListInfoRowCount
		/// 功能概要: 获取买M送N方案记录数
		/// 作    者: 白晓宇
		/// 创建时间: 2010年4月19日
		/// 修 正 人: 
		/// 修正时间: 
		/// 描    述: 
		/// </summary>
		public void GetAllBuySendListInfoRowCount()
		{
			Hashtable ht = new Hashtable();
			model.RecordCount = campaignService.GetAllBuySendListInfoRowCount(ht);
		}
		#endregion

		#region 获取买M送N方案(分页)
		/// <summary>
		/// 名    称: GetAllBuySendListInfo
		/// 功能概要: 获取买M送N方案(分页)
		/// 作    者: 白晓宇
		/// 创建时间: 2010年4月19日
		/// 修 正 人: 
		/// 修正时间: 
		/// 描    述: 
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

		#region 修改买M送N方案
		
		public void EditBuySendCampaign()
		{
			//获取门市价格
			BaseBusinessTypePriceSet domain = priceService.GetTheMostBaseBusinessTypePrice(model.BuySend.BaseBusinessTypePriceSet);
			if (null == domain)
			{
				Workflow.Support.Log.LogHelper.WriteError("添加买一送一活动，没有获取到价格", Constants.LOGGER_NAME);
				throw new Workflow.Support.Exception.WorkflowException("没有获取到价格");
			}
			model.BuySend.BaseBusinessTypePriceSetId = domain.Id;

			campaignService.EditBuySendCampaing(model.BuySend);
		}
		#endregion

		#region 获取门市价格
		/// <summary>
		/// 名    称: GetBaseBusinessTypePriceSetInfo
		/// 功能概要: 获取门市价格
		/// 作    者: 白晓宇
		/// 创建时间: 2010年4月19日
		/// 修 正 人: 
		/// 修正时间: 
		/// 描    述: 
		/// </summary>
		public void GetBaseBusinessTypePriceSetInfo()
		{
			BaseBusinessTypePriceSet domain = new BaseBusinessTypePriceSet();
			domain.Id = model.BuySend.BaseBusinessTypePriceSetId;

			model.BaseBusinessTypePriceSet = priceService.GetBaseBusinessTypePriceSetById(domain);
		}
		#endregion

		#region 获取价格因素
		/// <summary>
		/// 名    称: GetPriceFactor
		/// 功能概要: 获取价格因素
		/// 作    者: 白晓宇
		/// 创建时间: 2010年4月19日
		/// 修 正 人: 
		/// 修正时间: 
		/// 描    述: 
		/// </summary>
		public void GetPriceFactor()
		{
			model.PriceFactor = priceService.GetPriceFactor();
		}
		#endregion

		#region 删除买M送N方案
		/// <summary>
		/// 名    称: RemoveBuySend
		/// 功能概要: 删除买M送N方案
		/// 作    者: 白晓宇
		/// 创建时间: 2010年4月20日
		/// 修 正 人: 
		/// 修正时间: 
		/// 描    述: 
		/// </summary>
		public void RemoveBuySend()
		{
			campaignService.RemoveBuySend(model.BuySendId);
		}
		#endregion
	}
}
