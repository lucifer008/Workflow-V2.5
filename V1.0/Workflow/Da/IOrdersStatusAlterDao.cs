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
        ///���ݹ���Id���¹���״̬Ϊ�깤
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2008-12-23
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        void UpdateOrderStatusById(Hashtable hashCondition); 
        
    }
}
