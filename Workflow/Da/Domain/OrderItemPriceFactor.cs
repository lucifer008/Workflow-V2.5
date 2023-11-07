using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// 订单明细的价格因素值
	/// </summary>
	/// <remarks>
	/// 作    者: 陈汝胤
	/// 创建时间: 2009-5-19
	/// </remarks>
	public class OrderItemPriceFactor
	{
		#region 订单明细id
		private long orderItemId;
		/// <summary>
		/// 订单明细id
		/// </summary>
		public long OrderItemId
		{
			get { return orderItemId; }
			set { orderItemId = value; }
		}
		#endregion

		#region 相关价格因素的id

		private long priceFactorId;
		public long PriceFactorId
		{
			get { return priceFactorId; }
			set { priceFactorId = value; }
		}

		#endregion

		#region 加工内容

		private string processContent;
		/// <summary>
		/// 加工内容
		/// </summary>
		public string ProcessContent
		{
			get { return processContent; }
			set { processContent = value; }
		}

		#endregion

		#region 机器型号

		private string machineType;
		/// <summary>
		/// 机器型号
		/// </summary>
		public string MachineType
		{
			get { return machineType; }
			set { machineType = value; }
		}

		#endregion

		#region 纸质

		private string paperType;
		/// <summary>
		/// 纸质
		/// </summary>
		public string PaperType
		{
			get { return paperType; }
			set { paperType = value; }
		}

		#endregion

		#region 纸型

		private string paperSpecification;
		/// <summary>
		/// 纸型
		/// </summary>
		public string PaperSpecification
		{
			get { return paperSpecification; }
			set { paperSpecification = value; }
		}

		#endregion

		#region 发票

		private string invoice;
		/// <summary>
		/// 发票
		/// </summary>
		public string Invoice
		{
			get { return invoice; }
			set { invoice = value; }
		}

		#endregion

		#region 会员

		private string member;
		/// <summary>
		/// 会员
		/// </summary>
		public string Member
		{
			get { return member; }
			set { member = value; }
		}


		#endregion

		#region 数量

		private decimal amount;
		/// <summary>
		/// 数量
		/// </summary>
		public decimal Amount
		{
			get { return amount; }
			set { amount = value; }
		}


		#endregion

		#region 单价

		private decimal unitPrice;
		/// <summary>
		/// 单价
		/// </summary>
		public decimal UnitPrice
		{
			get { return unitPrice; }
			set { unitPrice = value; }
		}

		#endregion

		#region 总金额

		private decimal amountPrice;
		/// <summary>
		/// 总金额
		/// </summary>
		public decimal AmountPrice
		{
			get { return amountPrice; }
            set { amountPrice = value; }
		}

		#endregion

		#region 制作要求

		

		#endregion

		#region 因素名称
		
		#endregion
	}
}
