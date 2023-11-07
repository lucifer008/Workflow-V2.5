using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
using System.Collections;
/// <summary>
/// ��    ��: CustomerDaoImpl
/// ���ܸ�Ҫ: �ͻ��ӿ�ICustomerDaoʵ����
/// ��    ��: 
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table CUSTOMER ��Ӧ��Dao ʵ��
	/// </summary>
    public class CustomerDaoImpl : Workflow.Da.Base.DaoBaseImpl<Customer>, ICustomerDao
    {
        #region ����������ѯ�ͻ�
        public IList<Customer> SearchCustomer(System.Collections.Hashtable customer)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            customer.Add("BranchShopId",user.BranchShopId);
            customer.Add("CompanyId", user.CompanyId);
            return sqlMap.QueryForList<Customer>("Customer.SearchCustomer", customer);
        }
        #endregion

        #region ���ݿͻ�һ���е���������ѯ�ͻ�
        public IList<Customer> SearchCustomerCondition(System.Collections.Hashtable customer)
        {
            return sqlMap.QueryForList<Customer>("Customer.SearchCustomerList", customer);
        }
        #endregion

        #region ��ѯ����δȷ�ϵĿͻ�
        /// <summary>
        /// ��ѯ����δȷ�ϵĿͻ�
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
        public IList<Customer> SearchAllNotValidate(Hashtable hashCondition)
        {
            hashCondition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            hashCondition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<Customer>("Customer.SelectAllNotValidate", hashCondition);
        }

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
        public long SearchAllNotValidateRowCount(Hashtable condition) 
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForObject<long>("Customer.SelectAllNotValidateRowCount", condition);
        }
        #endregion

        #region ɾ����ϵ��
        public void DeleteLinkMan(long Id)
        {
            sqlMap.Delete("Customer.DeleteLinkMan", Id);
        }
        #endregion

        #region ���¿ͻ�״̬
        public void UpdateValidateStatus(System.Collections.Hashtable condition)
        {
            sqlMap.Update("Customer.UpdateValidateStatus", condition);
        }
        #endregion

        #region //��ѯû�����ѵĿͻ�
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
        public IList<Customer> SelectWithoutConsumeCustomer(Hashtable customer)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            customer.Add("CompanyId", user.CompanyId);
            customer.Add("BranchShopId", user.BranchShopId);
            return sqlMap.QueryForList<Customer>("Customer.SelectWithoutConsumeCustomer", customer);
        }
        /// <summary>
        /// ��    ��: GetWithoutConsumeCustomerRowCount
        /// ���ܸ�Ҫ: ��ѯû�����ѵĿͻ���¼��
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��21��14:21:56
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public long GetWithoutConsumeCustomerRowCount(Hashtable customer) 
        {
            return sqlMap.QueryForObject<long>("Customer.GetWithoutConsumeCustomerRowCount", customer);
        }

        /// <summary>
        /// ��    ��: GetWithoutConsumeCustomerRowPrint
        /// ���ܸ�Ҫ: ��ѯû�����ѵĿͻ����
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��21��14:21:56
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<Customer> GetWithoutConsumeCustomerRowPrint(Hashtable customer) 
        {
            return sqlMap.QueryForList<Customer>("Customer.GetWithoutConsumeCustomerRowPrint", customer);
        }

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
        public void UpdateCustomerLinkManInfo(Customer customer)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            customer.CompanyId=user.CompanyId;
            customer.BranchShopId=user.BranchShopId;
            sqlMap.Update("Customer.UpdateCustomerLinkManInfo",customer);
        }
    
        #endregion

        #region ��ȡ�ͻ�����
        /// <summary>
        /// ��    ��: GetCustomerCount
        /// ���ܸ�Ҫ: ��ȡ�ͻ�����
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2008-11-5
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long GetCustomerCount(Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return (long)sqlMap.QueryForObject("Customer.GetCustomerCount", condition);

        }
        #endregion

        #region //��ѯ�ͻ�������ʷ
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
        public IList<Order> SelectOrderByCustomerId(Hashtable condition) 
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<Order>("Customer.SelectoOrderByCustomerId", condition);
        }

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
        public long SelectOrderRowCountByCustomerId(long Id) 
        {
            Hashtable condtion = new Hashtable();
            condtion.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condtion.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condtion.Add("CustomerId",Id);
            return sqlMap.QueryForObject<long>("Customer.SelectoOrderRowCountByCustomerId", condtion);
        }
        #endregion

        #region//����ͻ�Ԥ���
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
        public void SavePreDeposit(Customer customer) 
        {
            long cuId = Constants.scatteredClientId(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            if (cuId != customer.Id)
            {
                //customer.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
                //customer.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
                sqlMap.Update("Customer.SavePreDeposit", customer);
            }
        }
        #endregion

        #region//Ԥ�����
        /// <summary>
        /// ��    ��: DiffPreDeposits
        /// ���ܸ�Ҫ: �ͻ�Ԥ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��11��4��10:47:15
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void DiffPreDeposits(Customer customer) 
        {
            sqlMap.Update("Customer.DiffPreDeposits", customer);
        }
        #endregion

		#region ��ȡ�û���Ϣ

		public Customer GetCustomer(string memberCardNo, string customerName)
		{
			Hashtable map = new Hashtable();
			map.Add("memberCardNo", memberCardNo);
			map.Add("customerName", customerName);
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("branchShopId", user.BranchShopId);
			map.Add("companyId", user.CompanyId);
			return sqlMap.QueryForObject<Customer>("Customer.GetCustomer", map);
		}

		#endregion
    }
}
