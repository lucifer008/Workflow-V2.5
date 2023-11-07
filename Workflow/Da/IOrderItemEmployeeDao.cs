using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDER_ITEM_EMPLOYEE ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IOrderItemEmployeeDao : IDaoBase<OrderItemEmployee>
    {
        /// <summary>
        /// ��    ��: 
        /// ���ܸ�Ҫ: ͨ��������ɾ��������Ա
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-25
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        void DeleteOrderItemEmployeeByOrderNo(OrderItemEmployee orderItemEmployee);
        /// <summary>
        /// ��    ��: 
        /// ���ܸ�Ҫ: ͨ��������ɾ��������Ա(������Ա����)
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2008-12-18
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        void DispatchDeleteOrderItemEmployeeByOrderNo(string strOrderNo);
        /// <summary>
        /// ��    ��: 
        /// ���ܸ�Ҫ: ������ǰ�ö�����ϸ�������Ա
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-25
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="orderItemEmployee"></param>
        /// <returns></returns>
        IList<OrderItemEmployee> SelectOldEmployee(OrderItemEmployee orderItemEmployee);
        /// <summary>
        /// ��    ��: 
        /// ���ܸ�Ҫ: ���Ҷ�����ϸ�������Ա
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-2
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="orderItemEmployee"></param>
        /// <returns></returns>
        IList<OrderItemEmployee> SelectOrderItemEmployee(OrderItemEmployee orderItemEmployee);

        /// <summary>
        /// ��    ��: 
        /// ���ܸ�Ҫ: ���Ҷ�����ϸ�Ĳ�����Ա
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2008-11-2
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        /// <returns></returns>
        IList<OrderItemEmployee> GetOrderItemEmployeeByOrderNo(string strOrderNo);

        IList<OrderItemEmployee> GetOrderItemEmployeeByOrderNo2(string strOrderNo);

        /// <summary>
        /// ��    ��: GetEmployeeEmployeeByOrderItemIdOrEmployeeId
        /// ���ܸ�Ҫ: ����EmployeeId��OrderItemId��ȡ����Ƿ����������OrderItemEmployee
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��7��13:38:29
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="orderItemEmployee"></param>
        /// <returns></returns>
        bool GetEmployeeEmployeeByOrderItemIdOrEmployeeId(OrderItemEmployee orderItemEmployee);

        /// <summary>
        /// ��    ��: DeleteOrderItemEmployee
        /// ���ܸ�Ҫ: ����OrderIdɾ��OrderItemEmployee
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��7��13:38:29
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
       void DeleteOrderItemEmployee(long orderId);

       /// <summary>
       /// ��    ��: GetOrderItemEmployeeListByOrderNo
       /// ���ܸ�Ҫ: ���ݶ����Ż�ȡ������ϸ��Ա�б�
       /// ��    �ߣ�������
       /// ����ʱ��: 2009��11��23��13:25:42
       /// ����������
       /// ����ʱ�䣺
       /// </summary>
       IList<OrderItemEmployee> GetOrderItemEmployeeListByOrderNo(string orderNo);
    }
}
