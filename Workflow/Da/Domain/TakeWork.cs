using System;
using Workflow.Da.Domain.Base;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table TAKE_WORK��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class TakeWork : TakeWorkBase
	{
		public TakeWork()
		{
           
		}

        private string deliveryName;
        //�ͻ���
        public string DeliveryName
        {
            get { return deliveryName; }
            set { deliveryName = value; }
        }

        private string customerName;
        //�ͻ�����
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
	}
}
