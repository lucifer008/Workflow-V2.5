using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDER_ITEM_FACTOR_VALUE ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IOrderItemFactorValueDao : IDaoBase<OrderItemFactorValue>
    {
        /// <summary>
        /// ��    ��: 
        /// ���ܸ�Ҫ: ͨ��������ɾ��������ϸ��ֵ
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-10
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        void DeleteOrderItemFactorValueByOrderNo(string strOrderNo);

        /// <summary>
        /// ��    ��: GetOrderItemFactorValueListByOrderNO
        /// ���ܸ�Ҫ: ���ݶ����Ż�ȡ������ϸ����ֵ�б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��11��23��13:26:05
        /// ����������
        /// ����ʱ�䣺
        /// </summary>
        IList<OrderItemFactorValue> GetOrderItemFactorValueListByOrderNO(string orderNo); 
    }
}
