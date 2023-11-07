using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;

namespace Workflow.Service.CustomerManager.Impl
{
    public class SearchCustomerServiceImpl : ISearchCustomerService
    {
        #region ע��Dao
        private ICustomerDao customerDao;
        public ICustomerDao CustomerDao
        {
            set { customerDao = value; }
        }

        private ILinkManDao linkManDao;
        public ILinkManDao LinkManDao
        {
            set { linkManDao = value; }
        }

        #region ע�� employeeDao

        private IEmployeeDao employeeDao;
        /// <summary>
        /// Add:Cry Date:2009-1-6
        ///  ע�� employeeDao
        /// </summary>
        public IEmployeeDao EmployeeDao
        {
            set { employeeDao = value; }
        }

        #endregion

        private IMemberCardDao memberCardDao;
        public IMemberCardDao MemberCardDao
        {
            set { memberCardDao = value; }
        }
        #endregion


        #region ��ѯ���пͻ�
        public IList<Customer> SearchAllCustomer()
        {
            return customerDao.SelectAll();
        }
        #endregion

        #region  ѡ��ͻ��в�ѯ�ͻ�

        public IList<Customer> SearchCustomer(System.Collections.Hashtable condition)
        {
            return customerDao.SearchCustomer(condition);
        }
        #endregion

        #region �ͻ�һ���в�ѯ�ͻ�
        public IList<Customer> SearchCustomerCondition(System.Collections.Hashtable condition)
        {
            return customerDao.SearchCustomerCondition(condition);
        }
        #endregion

        #region ��ѯ����δȷ�Ͽͻ�
        /// <summary>
        ///  ��ѯ����δȷ�Ͽͻ�
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
        public IList<Customer> SearchAllNotValidate(Hashtable hashCondition)
        {
            return customerDao.SearchAllNotValidate(hashCondition);
        }

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
        public long SearchAllNotValidateRowCount() 
        {
            return customerDao.SearchAllNotValidateRowCount();
        }
        #endregion

        #region ͨ��Id��ѯ�ͻ���Ϣ
        public Customer SearchCustomerById(long Id)
        {
            return customerDao.SelectByPk(Id);
        }
        #endregion

        #region ͨ��CustomerId��ѯ��ϵ��
        public IList<LinkMan> SearchLinkManByCustomerId(long Id)
        {
            if (customerDao.SelectByPk(Id).LinkManList != null)
            {
                return customerDao.SelectByPk(Id).LinkManList;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region ��ȡ���������Ŀͻ�����
        /// <summary>
        /// ��    ��: GetCustomerCount
        /// ���ܸ�Ҫ: ��ȡ���������Ŀͻ�����
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2008-11-5
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long GetCustomerCount(Hashtable condition)
        {
            return customerDao.GetCustomerCount(condition);
        }
        #endregion

        #region  ͨ��Id��ѯlinkman
        public LinkMan SearchLinkManByPk(long Id)
        {
            return linkManDao.SelectByPk(Id);
        }
        #endregion

        //#region ͨ��CustomerId��ѯ��ϵ����
        //public int SearchLinkManCount(long Id)
        //{
        //    return linkManDao.SelectLinkManCount(Id);
        //}
        //#endregion

        #region ͨ��CustomerId��ѯ��ϵ��
        public IList<LinkMan> SelectLinkManByCustomerId(long Id)
        {
            return linkManDao.SelectLinkManByCustomerId(Id);
        }
        #endregion

        #region �ͻ�������ʷ

        /// <summary>
        /// ��    ��: SearchOrderByCustomerId
        /// ���ܸ�Ҫ: ͨ��Customer_Id��ѯOrders��Ϣ
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-5
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns>���������Ĺ����б�</returns>
        public IList<Order> SearchOrderByCustomerId(Hashtable condition)
        {
            return customerDao.SelectOrderByCustomerId(condition);
        }

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
        public long SearchOrderRowCountByCustomerId(long customerId) 
        {
            return customerDao.SelectOrderRowCountByCustomerId(customerId);
        }
        #endregion

        #region ͨ��������ϸid��ȡ������ϸ�����еĹ͹�

        /// <summary>
        /// ͨ��������ϸid��ȡ������ϸ�����еĹ͹�
        /// </summary>
        /// <remarks>
        /// ��    ��: ����ط
        /// ����ʱ��: 2009-1-6
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Employee> GetOrderItemEmployeeByOrderItemId(long orderItemId)
        {
            return employeeDao.GetEmployeeByOrderItemId(orderItemId);
        }

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
        public MemberCard SelectCustomerInfoByMemberCardNo(string memberCardNo)
        {
            return memberCardDao.SelectCustomerInfoByMemberCardNo(memberCardNo);
        }
        #endregion
    }
}
