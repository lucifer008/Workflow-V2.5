using System;
using System.Data;
using System.Collections.Generic;

namespace Workflow.Da.Domain.Base
{
	/// <summary>
	/// Table ORDERS_DUTY ��Ӧ��DotNet Object ����
	/// ������ǻ��࣬�������޸�
	/// </summary>
	[Serializable]
	public class OrdersDutyBase : Workflow.Da.Domain.Base.MetaData 
	{
		/** ID [ID] */
		private long id;
		/** ����_ID [ORDERS_ID] */
		private long ordersId;
		/** ���ν�� [DUTY_AMOUNT] */
		private decimal dutyAmount;
		/** ��ע [MEMO] */
		private string memo;
		/** ���α�־ [DUTY_FLAG] */
		private string dutyFlag;

		public OrdersDutyBase()
		{
			
		}

		/// <summary>
		/// ID [ID]
		/// </summary>
		public virtual long Id
		{
			get { return this.id; }
			set { this.id = value; }
		}
		/// <summary>
		/// ����_ID [ORDERS_ID]
		/// </summary>
		public virtual long OrdersId
		{
			get { return this.ordersId; }
			set { this.ordersId = value; }
		}
		/// <summary>
		/// ���ν�� [DUTY_AMOUNT]
		/// </summary>
		public virtual decimal DutyAmount
		{
			get { return this.dutyAmount; }
			set { this.dutyAmount = value; }
		}
		/// <summary>
		/// ��ע [MEMO]
		/// </summary>
		public virtual string Memo
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		/// <summary>
		/// ���α�־ [DUTY_FLAG]
		/// </summary>
		public virtual string DutyFlag
		{
			get { return this.dutyFlag; }
			set { this.dutyFlag = value; }
		}


	}
}
