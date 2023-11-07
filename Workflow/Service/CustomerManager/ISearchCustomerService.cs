using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;

namespace Workflow.Service.CustomerManager
{
    public interface ISearchCustomerService
    {
        /// <summary>
        /// ��    ��: SearchCustomer
        /// ���ܸ�Ҫ: ����������ѯ�ͻ���Ϣ
        /// ��    ��: ף�±�
        /// ����ʱ��: 2007-9-19
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<Customer> SearchCustomer(System.Collections.Hashtable condition);

        /// <summary>
        /// ��    ��: SearchCustomerById
        /// ���ܸ�Ҫ: ��ѯ�ͻ���Ϣ,ͨ��Id
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-20
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Customer SearchCustomerById(long Id);
        /// <summary>
        /// ��    ��: SearchAllCustomer
        /// ���ܸ�Ҫ: ��ѯ���пͻ�
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-24
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        IList<Customer> SearchAllCustomer();
        /// <summary>
        /// ��    ��: SearchCustomerCondition
        /// ���ܸ�Ҫ: ��ѯ�ͻ�(�ͻ�һ��)
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        IList<Customer> SearchCustomerCondition(System.Collections.Hashtable condition);
        /// <summary>
        /// ��    ��: SearchLinkManByCustomerId
        /// ���ܸ�Ҫ: ��ѯ��ϵ�ˣ�ͨ��CustomerId
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        IList<LinkMan> SearchLinkManByCustomerId(long Id);

        /// <summary>
        /// ��    ��: SearchAllNotValidate
        /// ���ܸ�Ҫ: ��ѯ����δȷ�Ͽͻ�
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-27
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        IList<Customer> SearchAllNotValidate(Hashtable hashCondition);

        /// <summary>
        /// ��    ��: SearchAllNotValidateRowCount
        /// ���ܸ�Ҫ: ��ѯ����δȷ�Ͽͻ���¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009-02-09
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        long SearchAllNotValidateRowCount(Hashtable condition);

        /// <summary>
        /// ��    ��: GetCustomerCount
        /// ���ܸ�Ҫ: ��ȡ�ͻ�����
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2008-11-5
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long GetCustomerCount(Hashtable condition);

        /// <summary>
        /// ��    ��: SearchLinkManByPk
        /// ���ܸ�Ҫ: ͨ��Id��ѯlinkman
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-27
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        LinkMan SearchLinkManByPk(long Id);

        ///// <summary>
        ///// ��    ��: SearchLinkManCount
        ///// ���ܸ�Ҫ: ͨ��CustomerId��ѯ��ϵ����
        ///// ��    ��: liuwei
        ///// ����ʱ��: 2007-10-10
        ///// ��������:
        ///// ����ʱ��:
        ///// </summary>
        ///// <param name="condition"></param>
        ///// <returns></returns>
        /////
        //int SearchLinkManCount(long Id);

        /// <summary>
        /// ͨ��CustomerId��ѯ��ϵ��
        /// </summary>
        /// <param name="Id">CusotmerId</param>
        /// <returns>LinkManList</returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-15
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<LinkMan> SelectLinkManByCustomerId(long Id);

        /// <summary>
        /// ͨ��������ϸid��ȡ������ϸ�����еĹ͹�
        /// </summary>
        /// <remarks>
        /// ��    ��: ����ط
        /// ����ʱ��: 2009-1-6
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Employee> GetOrderItemEmployeeByOrderItemId(long orderItemId);

        #region ͨ��Customer_Id��ѯOrders��Ϣ
        /// <summary>
        /// ��    ��: SearchOrderByCustomerId
        /// ���ܸ�Ҫ: ͨ��Customer_Id��ѯOrders��Ϣ
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-28
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns>���������Ķ����б�</returns>
        IList<Order> SearchOrderByCustomerId(Hashtable condition);

        /// <summary>
        /// ��������: SearchOrderRowCountByCustomerId
        /// ���ܸ�Ҫ: ͨ��CustomerId��ѯOrder��Ϣ��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009-02-09
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        long SearchOrderRowCountByCustomerId(long customerId); 
        #endregion

        #region ͨ����Ա���Ų�����ؿͻ���Ϣ
        /// <summary>
        /// ��    ��: SelectCustomerInfoByMemberCardNo
        /// ���ܸ�Ҫ: ͨ����Ա���Ų�����ؿͻ���Ϣ
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-23
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <returns>���ػ�Ա��Ϣ</returns>
        MemberCard SelectCustomerInfoByMemberCardNo(string memberCardNo);
        #endregion

    }
}
