using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Service
{
	public interface INoGenerator
	{
		/// <summary>
		/// �����ṩ�Ķ���Id��ȡ����No
		/// </summary>
		/// <param name="orderId">����Id</param>
		/// <returns>�����Ķ���No</returns>
		/// <remarks>
		/// ��    ��: ף�±�
		/// ����ʱ��: 2007-10-5
		/// ��������:
		/// ����ʱ��:
		/// </remarks>
		string GetOrderNo(long orderId,int branchShopId);
	}
}
