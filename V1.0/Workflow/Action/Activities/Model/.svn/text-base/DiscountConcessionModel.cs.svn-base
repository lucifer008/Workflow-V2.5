using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

/// <summary>
/// 名    称: DiscountConcessionModel
/// 功能概要: 打折活动
/// 作    者: 陈汝胤
/// 创建时间: 2009.5.9
/// </summary>
namespace Workflow.Action.Activities
{
	public class DiscountConcessionModel
	{

		#region 打折活动的列表
		
		private IList<DiscountConcession> discountList;
		/// <summary>
		/// 打折活动的列表
		/// </summary>
		public IList<DiscountConcession> DiscountList
		{
			get { return discountList; }
			set { discountList = value; }
		}

		#endregion

		#region 打折活动的记录数

		private int discountConcessionCount;
		/// <summary>
		/// 打折活动的记录数
		/// </summary>
		public int DiscountConcessionCount
		{
			get { return discountConcessionCount; }
			set { discountConcessionCount = value; }
		}

		#endregion

		#region 分页开始行

		private int beginRow;
		/// <summary>
		/// 分页开始行
		/// </summary>
		public int BeginRow
		{
			get { return beginRow; }
			set { beginRow = value; }
		}

		#endregion

		#region 分页结束行

		private int endRow;
		/// <summary>
		/// 分页结束行
		/// </summary>
		public int EndRow
		{
			get { return endRow; }
			set { endRow = value; }
		}

		#endregion

		#region 打折活动id

		private long discountConcessionId;
		/// <summary>
		/// 打折活动id
		/// </summary>
		public long DiscountConcessionId
		{
			get { return discountConcessionId; }
			set { discountConcessionId = value; }
		}

		#endregion

		#region 打折活动名称

		private string discountName;
		/// <summary>
		/// 打折活动名称
		/// </summary>
		public string DiscountName
		{
			get
			{
				if (null == discountName)
					return "";
				return discountName;
			}
			set { discountName = value; }
		}


		#endregion

		#region 打折活动说明

		private string discountMemo;
		/// <summary>
		/// 打折活动说明
		/// </summary>
		public string DiscountMemo
		{
			get
			{
				if (discountMemo == null)
					return "";
				return discountMemo;
			}
			set { discountMemo = value; }
		}

		#endregion

		#region 打折活动的冲值金额

		private decimal chargeAmount;
		/// <summary>
		/// 打折活动的冲值金额
		/// </summary>
		public decimal ChargeAmount
		{
			get { return chargeAmount; }
			set { chargeAmount = value; }
		}

		#endregion

		#region 营销活动列表

		private IList<Campaign> campaignList;
		/// <summary>
		/// 营销活动列表
		/// </summary>
		public IList<Campaign> CampaignList
		{
			get { return campaignList; }
			set { campaignList = value; }
		}

		#endregion

		#region 机器列表

		private IList<MachineType> machineTypeList;
		/// <summary>
		/// 机器列表
		/// </summary>
		public IList<MachineType> MachineTypeList
		{
			get { return machineTypeList; }
			set { machineTypeList = value; }
		}
		
		#endregion

		#region 纸型列表

		private IList<PaperSpecification> paperList;
		/// <summary>
		/// 纸型列表
		/// </summary>
		public IList<PaperSpecification> PaperList
		{
			get { return paperList; }
			set { paperList = value; }
		}

		#endregion

		#region 营销活动id

		private long campaignId;
		/// <summary>
		/// 营销活动id
		/// </summary>
		public long CampaignId
		{
			get { return campaignId; }
			set { campaignId = value; }
		}

		#endregion

		#region 打折活动的相关信息

		private string discountInfo;
		/// <summary>
		/// 打折活动的相关信息
		/// </summary>
		public string DiscountInfo
		{
			get
			{
				if (discountInfo == null)
					return "";
				return discountInfo;
			}
			set { discountInfo = value; }
		}

		#endregion

		#region 行为信息

		private string actionInfo;
		/// <summary>
		/// 行为信息
		/// </summary>
		public string ActionInfo
		{
			get { return actionInfo; }
			set { actionInfo = value; }
		}

		#endregion
	}
}
