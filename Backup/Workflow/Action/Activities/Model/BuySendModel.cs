using System;
using System.Collections.Generic;
using System.Text;

using Workflow.Da.Domain;

namespace Workflow.Action.Activities.Model
{
	/// <summary>
	/// 名    称: BuySendModel
	/// 功能概要: 买M送N活动Model
	/// 作    者: 
	/// 创建时间: 2010-04-15
	/// 修 正 人: 白晓宇
	/// 修正时间: 
	/// 描    述: 
	/// </summary>
	public class BuySendModel
	{
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

		#region 营销活动Id
		private long campaignId;
		/// <summary>
		/// 营销活动Id
		/// </summary>
		public long CampaignId
		{
			get { return campaignId; }
			set { campaignId = value; }
		}
		#endregion

		#region 动作名称
		private string actionInfo;
		/// <summary>
		/// 动作名称
		/// </summary>
		public string ActionInfo
		{
			get { return actionInfo; }
			set { actionInfo = value; }
		}
		#endregion

		#region 活动备注
		private string buySendMemo;
		/// <summary>
		/// 活动备注
		/// </summary>
		public string BuySendMemo
		{
			get { return buySendMemo; }
			set { buySendMemo = value; }
		}
		#endregion 

		#region 活动说明
		private string  buySendDescription;
		/// <summary>
		/// 活动说明
		/// </summary>
		public string  BuySendDescription
		{
			get { return buySendDescription; }
			set { buySendDescription = value; }
		}
		#endregion

		#region 买的印章
		private long buyCount;
		/// <summary>
		/// 买的印章
		/// </summary>
		public long BuyCount
		{
			get { return buyCount; }
			set { buyCount = value; }
		}
		#endregion

		#region 送的印章
		private long sendCouint;
		/// <summary>
		/// 送的印章
		/// </summary>
		public long SendCount
		{
			get { return sendCouint; }
			set { sendCouint = value; }
		}
		#endregion

		#region 赠送总数
		private decimal paperCount;
		/// <summary>
		/// 赠送总数
		/// </summary>
		public decimal PaperCount
		{
			get { return paperCount; }
			set { paperCount = value; }
		}
		#endregion

		#region 方案名称
		private string buySendName;
		/// <summary>
		/// 方案名称
		/// </summary>
		public string BuySendName
		{
			get { return buySendName; }
			set { buySendName = value; }
		}
		#endregion

		#region 业务类型列表
		private IList<BusinessType> businessTypeList;
		/// <summary>
		/// 业务类型列表
		/// </summary>
		public IList<BusinessType> BusinessTypeList
		{
			get { return businessTypeList; }
			set { businessTypeList = value; }
		}
		#endregion

		#region 业务类型Id
		private long businessTypeId;
		/// <summary>
		/// 业务类型Id
		/// </summary>
		public long BusinessTypeId
		{
			get { return businessTypeId; }
			set { businessTypeId = value; }
		}
		#endregion

		#region 买M送N活动domain
		private BuySend buySend;
		/// <summary>
		/// 买M送N活动domain
		/// </summary>
		public BuySend BuySend
		{
			get { return buySend; }
			set { buySend = value; }
		}
		#endregion

		#region 活动Id
		private long buySendId;
		/// <summary>
		/// 活动Id
		/// </summary>
		public long BuySendId
		{
			get { return buySendId; }
			set { buySendId = value; }
		}
		#endregion

		#region 买M送N方案list
		private IList<BuySend> buySendList;
		/// <summary>
		/// 买M送N方案list
		/// </summary>
		public IList<BuySend> BuySendList
		{
			get { return buySendList; }
			set { buySendList = value; }
		}
		#endregion

		#region 获取的的记录数
		private int recordCount;
		/// <summary>
		/// 获取的的记录数
		/// </summary>
		public int RecordCount
		{
			get { return recordCount; }
			set { recordCount = value; }
		}
		#endregion

		#region 门市价格
		private BaseBusinessTypePriceSet baseBusinessTypePriceSet;
		/// <summary>
		/// BaseBusinessTypePriceSet
		/// </summary>
		public BaseBusinessTypePriceSet BaseBusinessTypePriceSet
		{
			get { return baseBusinessTypePriceSet; }
			set { baseBusinessTypePriceSet = value; }
		}
	
		#endregion

		#region 价格因素
		private IList<PriceFactor> priceFactor;
		/// <summary>
		/// 价格因素
		/// </summary>
		public IList<PriceFactor> PriceFactor
		{
			get { return priceFactor; }
			set { priceFactor = value; }
		}
		#endregion

	}
}
