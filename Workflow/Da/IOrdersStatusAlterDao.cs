using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDERS_STATUS_ALTER ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IOrdersStatusAlterDao : IDaoBase<OrdersStatusAlter>
    {
        /// <summary>
        ///���ݶ���Id���¶���״̬Ϊ�깤
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2008-12-23
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        void UpdateOrderStatusById(Hashtable hashCondition); 
        
         /// <summary>
        /// ��ȡ������ʽ��ӡ�Ĵ���
        /// </summary>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ��: 2010��3��2��14:57:10
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        int GetOrderPrintCountByOrderNo(string strOrderNo); 

    }
}
