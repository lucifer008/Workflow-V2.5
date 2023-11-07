using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Service.CompaignManage;
using Workflow.Support;
using Workflow.Da.Domain;

/// <summary>
/// 名    称: DiscountConcessionAction
/// 功能概要: 打折活动
/// 作    者: 陈汝胤
/// 创建时间: 2009.5.9
/// </summary>
namespace Workflow.Action.Activities
{
	public class DiscountConcessionAction
	{
		#region model

		private DiscountConcessionModel model = new DiscountConcessionModel();
		public DiscountConcessionModel Model
		{
			get { return model; }
		}

		#endregion

		#region 注入 campaignService

		private ICampaignService campaignService;
		public ICampaignService CampaignService
		{
			set { campaignService = value; }
		}

		#endregion

		#region 获取分页的活动列表

		/// <summary>
		/// 获取分页的活动列表
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.9
		/// </remarks>
		public void GetPaginationDiscountConcession()
		{
			model.DiscountList = campaignService.GetAllDiscountConcession(model.BeginRow, model.EndRow);
		}

		#endregion

		#region 获取所有打折活动的记录数

		/// <summary>
		/// 获取所有打折活动的记录数
		/// </summary>
		/// <returns>记录数</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.11
		/// </remarks>
		public void GetAllDiscountConcessionCount()
		{
			model.DiscountConcessionCount = campaignService.GetAllDiscountConcessionCount();
		}

		#endregion

		#region 删除指定id的打折活动

		/// <summary>
		/// 删除指定id的打折活动
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.11
		/// </remarks>
		public void DeleteDiscountConcession()
		{
			campaignService.DeleteDiscountConcessionById(model.DiscountConcessionId);
		}

		#endregion

		#region 编辑打折活动的数据初始化

		/// <summary>
		/// 编辑打折活动的数据初始化
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.11
		/// </remarks>
		public void GetInitData()
		{
			model.CampaignList = campaignService.GetAllCampaign();
			model.MachineTypeList = campaignService.GetAllMachine();
			model.PaperList = campaignService.GetAllPaperSpecification();
			if (model.DiscountConcessionId != 0)
			{
				DiscountConcession discountConcession = campaignService.GetDiscountConcessionById(model.DiscountConcessionId);
				model.CampaignId = discountConcession.CampaignId;
				model.DiscountName = discountConcession.Name;
				model.DiscountMemo = discountConcession.Memo;
				model.ChargeAmount = discountConcession.ChargeAmount;
				IList<DiscountConcessionMachineTypePaperSpec> applyDiscount = campaignService.GetAllDiscountConcessionMachineTypePaperSpecByDiscountId(model.DiscountConcessionId);
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < applyDiscount.Count; i++)
				{
					sb.Append(applyDiscount[i].MachineTypeId);
					sb.Append(",");
					sb.Append(applyDiscount[i].MachineTypeName);
					sb.Append(",");
					sb.Append(applyDiscount[i].PaperSpecificationId);
					sb.Append(",");
					sb.Append(applyDiscount[i].PaperName);
					sb.Append(",");
					sb.Append(applyDiscount[i].Discount);
					if (i + 1 < applyDiscount.Count)
						sb.Append("|");
				}
				model.DiscountInfo = sb.ToString();
			}
		}

		#endregion

		#region 保存打折优惠活动适用机器和纸型

		/// <summary>
		/// 保存打折优惠活动适用机器和纸型
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.12
		/// </remarks>
		public void EditDiscountApplyMachineAndPaper()
		{
			DiscountConcession discountConcession=null;
			if(model.DiscountConcessionId==0)
				discountConcession=new DiscountConcession();
			else
				discountConcession = campaignService.GetDiscountConcessionById(model.DiscountConcessionId);
			discountConcession.CampaignId = model.CampaignId;
			discountConcession.Name = model.DiscountName;
			discountConcession.Memo = model.DiscountMemo;
			discountConcession.ChargeAmount = model.ChargeAmount;
			string[] discounts = model.DiscountInfo.Split('|');
			IList<DiscountConcessionMachineTypePaperSpec> applyDiscountList = new List<DiscountConcessionMachineTypePaperSpec>();
			foreach (string str in discounts)
			{
				DiscountConcessionMachineTypePaperSpec applyDiscount = new DiscountConcessionMachineTypePaperSpec();
				string[] discount = str.Split('\'');
				applyDiscount.DiscountConcessionId = model.DiscountConcessionId;
				applyDiscount.MachineTypeId = Convert.ToInt64(discount.GetValue(0));
				applyDiscount.PaperSpecificationId = Convert.ToInt64(discount.GetValue(1));
				applyDiscount.Discount = Convert.ToDecimal(discount.GetValue(2).ToString())/100;
				applyDiscountList.Add(applyDiscount);
				
			}
			if (model.DiscountConcessionId == 0)
				campaignService.SaveDiscountApplyMachineAndPaper(discountConcession, applyDiscountList);
			else
				campaignService.updateDiscountApplyMachineAndPaper(discountConcession,applyDiscountList);
		}

		#endregion

		
	}
}
