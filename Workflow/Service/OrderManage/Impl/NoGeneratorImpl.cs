using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Service.Impl
{
	public class NoGeneratorImpl : INoGenerator
	{
		private string prefix = "S";

		public string Prefix
		{
			set { prefix = value; }
		}
		#region INoGenerator ��Ա

        /// <summary>
        /// ��    ��:
        /// ���ܸ�Ҫ:
        /// ��    ��:
        /// ����ʱ��:
        /// �� �� ��; ������
        /// ��������: �������޸�Ϊ�����ֵ� ǰ��λ����ֵ�
        ///           
        /// ����ʱ��: 2010��7��8��13:22:23
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="branchShopId"></param>
        /// <returns></returns>
		public string GetOrderNo(long orderId,int branchShopId)
		{
            //int pf = 83;
            //if (branchShopId > 1)
            //{
            //    pf = pf + branchShopId;
            //}
            //if (pf > 90)
            //    pf = pf - 26;

            //return (char)pf + orderId.ToString("0000000");
            string pf = branchShopId.ToString("00");

            return pf + orderId.ToString("0000000");
		}

		#endregion

	}
}
