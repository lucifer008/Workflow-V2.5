using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.OrderManage
{
    /// <summary>
    /// ��    ��: ISearchOrderService
    /// ���ܸ�Ҫ: ���������ж�����ѯ��Service�Ľӿ�
    /// ��    ��: ��ǿ
    /// ����ʱ��: 2009-1-19
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public interface ISearchOrderService
    {
        #region ������ѯ

        /// <summary>
        /// ��    ��: SearchOrdersInfo
        /// ���ܸ�Ҫ: ������ѯ(��������)
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-8
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <returns>�����б�</returns>
        IList<Order> SearchOrdersInfo(Hashtable condition);

        /// <summary>
        /// ��    ��: SearchOrdersInfoNo
        /// ���ܸ�Ҫ: ������ѯ(��������)
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-8
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <returns>�����б�</returns>
        IList<Order> SearchOrdersPrint(Hashtable condition);

        /// <summary>
        /// ��    ��: GetSearchOrderInfoCount
        /// ���ܸ�Ҫ: ��ѯ���������Ķ�������
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-9
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <returns>���������Ķ�������</returns>
        long GetSearchOrderInfoCount(Hashtable condition);

        /// <summary>
        /// ��    ��: SearchDelivery
        /// ���ܸ�Ҫ: ͨ�������Ų�ѯ�ͻ���
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-9
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="NO">������</param>
        /// <returns>�ͻ��˵�����</returns>
        string SearchDelivery(string NO);
        #endregion

		#region ��ȡ�����б�ͨ������״̬

		/// <summary>
		/// ��ȡ�����б�ͨ������״̬
		/// </summary>
		/// <param name="status">����״̬</param>
		/// <returns>OrderList</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.4.23
		/// </remarks>
		IList<Order> GetOrderListByStatus(Hashtable map);

		#endregion
	}


}
