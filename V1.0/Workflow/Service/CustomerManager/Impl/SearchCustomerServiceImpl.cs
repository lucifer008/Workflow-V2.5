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
        #region 注入Dao
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

        #region 注入 employeeDao

        private IEmployeeDao employeeDao;
        /// <summary>
        /// Add:Cry Date:2009-1-6
        ///  注入 employeeDao
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


        #region 查询所有客户
        public IList<Customer> SearchAllCustomer()
        {
            return customerDao.SelectAll();
        }
        #endregion

        #region  选择客户中查询客户

        public IList<Customer> SearchCustomer(System.Collections.Hashtable condition)
        {
            return customerDao.SearchCustomer(condition);
        }
        #endregion

        #region 客户一览中查询客户
        public IList<Customer> SearchCustomerCondition(System.Collections.Hashtable condition)
        {
            return customerDao.SearchCustomerCondition(condition);
        }
        #endregion

        #region 查询所有未确认客户
        /// <summary>
        ///  查询所有未确认客户
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
        public IList<Customer> SearchAllNotValidate(Hashtable hashCondition)
        {
            return customerDao.SearchAllNotValidate(hashCondition);
        }

        /// <summary>
        /// 名    称: SearchAllNotValidateRowCount
        /// 功能概要: 查询所有未确认客户记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009-02-09
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// 
        public long SearchAllNotValidateRowCount() 
        {
            return customerDao.SearchAllNotValidateRowCount();
        }
        #endregion

        #region 通过Id查询客户信息
        public Customer SearchCustomerById(long Id)
        {
            return customerDao.SelectByPk(Id);
        }
        #endregion

        #region 通过CustomerId查询联系人
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

        #region 获取符合条件的客户总数
        /// <summary>
        /// 名    称: GetCustomerCount
        /// 功能概要: 获取符合条件的客户总数
        /// 作    者: 付强
        /// 创建时间: 2008-11-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long GetCustomerCount(Hashtable condition)
        {
            return customerDao.GetCustomerCount(condition);
        }
        #endregion

        #region  通过Id查询linkman
        public LinkMan SearchLinkManByPk(long Id)
        {
            return linkManDao.SelectByPk(Id);
        }
        #endregion

        //#region 通过CustomerId查询联系人数
        //public int SearchLinkManCount(long Id)
        //{
        //    return linkManDao.SelectLinkManCount(Id);
        //}
        //#endregion

        #region 通过CustomerId查询联系人
        public IList<LinkMan> SelectLinkManByCustomerId(long Id)
        {
            return linkManDao.SelectLinkManByCustomerId(Id);
        }
        #endregion

        #region 客户消费历史

        /// <summary>
        /// 名    称: SearchOrderByCustomerId
        /// 功能概要: 通过Customer_Id查询Orders信息
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns>符合条件的工单列表</returns>
        public IList<Order> SearchOrderByCustomerId(Hashtable condition)
        {
            return customerDao.SelectOrderByCustomerId(condition);
        }

        /// <summary>
        /// 方法名称: SearchOrderRowCountByCustomerId
        /// 功能概要: 通过CustomerId查询Order信息记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009-02-09
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public long SearchOrderRowCountByCustomerId(long customerId) 
        {
            return customerDao.SelectOrderRowCountByCustomerId(customerId);
        }
        #endregion

        #region 通过工单明细id获取工单明细下所有的雇工

        /// <summary>
        /// 通过工单明细id获取工单明细下所有的雇工
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Employee> GetOrderItemEmployeeByOrderItemId(long orderItemId)
        {
            return employeeDao.GetEmployeeByOrderItemId(orderItemId);
        }

        #endregion

        #region 通过会员卡号查找相关客户信息
        /// <summary>
        /// 名    称: SelectCustomerInfoByMemberCardNo
        /// 功能概要: 通过会员卡号查找相关客户信息
        /// 作    者: 付强
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <returns>返回会员信息</returns>
        public MemberCard SelectCustomerInfoByMemberCardNo(string memberCardNo)
        {
            return memberCardDao.SelectCustomerInfoByMemberCardNo(memberCardNo);
        }
        #endregion
    }
}
