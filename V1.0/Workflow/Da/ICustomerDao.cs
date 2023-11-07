using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;
/// <summary>
/// ��    ��: ICustomerDao
/// ���ܸ�Ҫ: �ͻ��ӿ�
/// ��    ��: 
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table CUSTOMER ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface ICustomerDao : IDaoBase<Customer>
    {
        /// <summary>
        /// ��    ��: SearchCustomer
        /// ���ܸ�Ҫ: ��ѯ�ͻ�
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-24
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        ///
        IList<Customer> SearchCustomer(System.Collections.Hashtable customer);
        /// <summary>
        /// ��    ��: SearchCustomerCondition
        /// ���ܸ�Ҫ: ��ѯ�ͻ�(�ͻ�һ��)
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        ///
        IList<Customer> SearchCustomerCondition(System.Collections.Hashtable customer);
        /// <summary>
        /// ��    ��: DeleteLinkMan
        /// ���ܸ�Ҫ: ɾ����ϵ��
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        ///
        void DeleteLinkMan(long Id);
        /// <summary>
        /// ��    ��: SearchAllNotValidate
        /// ���ܸ�Ҫ: ��ѯ����δȷ�Ͽͻ�
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-27
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        ///
        IList<Customer> SearchAllNotValidate(Hashtable condition);

         /// <summary>
        /// ��    ��: SearchAllNotValidateRowCount
        /// ���ܸ�Ҫ: ��ѯ����δȷ�Ͽͻ� �ļ�¼��Ŀ
        /// ��    ��: ������
        /// ����ʱ��: 2009-02-09
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        ///
       long SearchAllNotValidateRowCount();

        /// <summary>
        /// ��    ��: UpdateValidateStatus
        /// ���ܸ�Ҫ: ���¿ͻ�״̬
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-10
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        void UpdateValidateStatus(System.Collections.Hashtable condition);

        /// <summary>
        /// ��    ��: SelectWithoutConsumeCustomer
        /// ���ܸ�Ҫ: ��ѯû�����ѵĿͻ�
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-31
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IList<Customer> SelectWithoutConsumeCustomer(Hashtable customer);
        /// <summary>
        /// ��    ��: UpdateCustomerLinkManInfo
        /// ���ܸ�Ҫ: ͨ���ͻ�ID���¿ͻ����һ����ϵ����Ϣ����ϵ������
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-31
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        void UpdateCustomerLinkManInfo(Customer customer);

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
        /// ��    ��: SearchOrderByCustomerId
        /// ���ܸ�Ҫ: ͨ��CustomerId��ѯOrder��Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-28
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ///
        IList<Order> SelectOrderByCustomerId(Hashtable condition);

        /// <summary>
        /// ��    ��: SearchOrderByCustomerId
        /// ���ܸ�Ҫ: ͨ��CustomerId��ѯOrder��Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-28
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ///
        long SelectOrderRowCountByCustomerId(long Id);

        /// <summary>
        /// ��    ��: SavePreDeposit
        /// ���ܸ�Ҫ: ����ͻ�Ԥ���
        /// ��    ��: ������
        /// ����ʱ��: 2009��11��3��14:15:57
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        void SavePreDeposit(Customer customer);

        /// <summary>
        /// ��    ��: DiffPreDeposits
        /// ���ܸ�Ҫ: �ͻ�Ԥ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��11��4��10:47:15
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void DiffPreDeposits(Customer customer); 
    }
}
