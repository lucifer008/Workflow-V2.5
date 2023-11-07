using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

/// <summary>
/// ��������ҳ��Model
/// </summary>
/// <remarks>
/// ��    ��: ����ط
/// ����ʱ��: 2009-5-18
/// </remarks>
namespace Workflow.Action.Finance
{
	public class PayForOrderModel
	{
		#region ����
		private Order order;
		/// <summary>
		/// ����
		/// </summary>
		public Order Order
		{
			get { return order; }
			set { order = value; }
		}
		#endregion

		#region Ԥ����

		private decimal prePayAmount;
		/// <summary>
		/// Ԥ����
		/// </summary>
		public decimal PrePayAmount
		{
			get { return prePayAmount; }
			set { prePayAmount = value; }
		}

		#endregion

		#region Ӧ�տ�

		private decimal needMoney;
		/// <summary>
		/// Ӧ�տ�
		/// </summary>
		public decimal NeedMoney
		{
			get { return needMoney; }
			set { needMoney = value; }
		}

		#endregion

		#region ����

		private decimal returnMoney;
		/// <summary>
		/// ����
		/// </summary>
		public decimal ReturnMoney
		{
			get { return returnMoney; }
			set { returnMoney = value; }
		}

		#endregion
	}
	/// <summary>
	/// ������ϸ���������
	/// </summary>
	/// <remarks>
	/// ��    ��: ����ط
	/// ����ʱ��: 2009-5-18
	/// </remarks>
	public class OrderItemOperation
	{
		#region ҵ������

		//private string 
		
		#endregion
	}
}
