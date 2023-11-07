using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDER_ITEM_PRINT_REQUIRE_DETAIL ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IOrderItemPrintRequireDetailDao : IDaoBase<OrderItemPrintRequireDetail>
    {
        IList<OrderItemPrintRequireDetail> GetOrderItemPrintRequireDetailByOrderNo(string strOrderNo);

        /// <summary>
        /// ��    ��: 
        /// ���ܸ�Ҫ: ͨ��������ɾ��ӡ��Ҫ���ֵ
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-10
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        void DeleteOrderItemPrintRequireByOrderNo(string strOrderNo);
    }
}
