#region imports
using System;
using Workflow.Da.Domain.Base;
using System.Collections.Generic;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MEMBER_CARD_DISCOUNT_CONCESSION (会员卡参加的打折优惠活动) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class MemberCardDiscountConcession : MemberCardDiscountConcessionBase
	{
		public MemberCardDiscountConcession()
		{
		}

		#region 折扣

		private decimal discount;
		/// <summary>
		/// 折扣
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.20
		/// </remarks>
		public decimal Discount
		{
			get { return discount; }
			set { discount = value; }
		}

		#endregion

		#region 机器因素

		private long machinePriceFactor;
		/// <summary>
		/// 机器因素
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.20
		/// </remarks>
		public long MachinePriceFactor
		{
			get { return machinePriceFactor; }
			set { machinePriceFactor = value; }
		}

		#endregion

		#region 纸型因素

		private long paperPriceFactor;
		/// <summary>
		/// 纸型因素s
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.20
		/// </remarks>
		public long PaperPriceFactor
		{
			get { return paperPriceFactor; }
			set { paperPriceFactor = value; }
		}

		#endregion

		#region 当前活动可用的机器和纸型的对比值中间以,号分割 的一组数组

		private IList<string> contrastValues;
		/// <summary>
		/// 当前活动可用的机器和纸型的对比值中间以,号分割 的一组数组
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.20
		/// </remarks>
		public IList<string> ContrastValues
		{
			get
			{
				if (contrastValues == null)
					contrastValues = new List<string>();
				return contrastValues;
			}
			set { contrastValues = value; }
		}

		#endregion

		#region 当前打折活动名称

		private string discountConcessionName;
		/// <summary>
		/// 当前打折活动名称
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.22
		/// </remarks>
		public string DiscountConcessionName
		{
			get { return discountConcessionName; }
			set { discountConcessionName = value; }
		}

		#endregion
	}
}