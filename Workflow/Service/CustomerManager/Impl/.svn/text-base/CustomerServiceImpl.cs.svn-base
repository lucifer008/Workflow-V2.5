using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Da.Domain;
using Workflow.Support;
using Spring.Transaction.Support;
using Spring.Transaction.Interceptor;
using System.Collections;

namespace Workflow.Service.Impl
{
    public class CustomerServiceImpl:ICustomerService
    {
        #region 注入Dao
        private ICustomerDao customerDao;
        public ICustomerDao CustomerDao
        {
            set { customerDao = value;}
        }

        private ILinkManDao linkManDao;
        public ILinkManDao LinkManDao
        {
            set { linkManDao = value; }
        }

        private IMemberCardDao memberCardDao;
        public IMemberCardDao MemberCardDao
        {
            set { memberCardDao = value; }
        }

        private IOrderDao orderDao;
        public IOrderDao OrderDao
        {
            set { orderDao = value; }
        }
        #endregion

        #region 新增客户(客户插入)
        [Transaction]
        public long InsertCustomer(Customer customer, LinkMan linkMan)
        {
            customerDao.Insert(customer);
            //插入联系人
            linkMan.CustomerId = customer.Id;
            linkManDao.Insert(linkMan);

            return customer.Id;
        }
        #endregion

        #region 删除客户
        [Transaction]
        public void DeleteCustomer(long Id)
        {
            //通过CustomerId删除LinkMan
            customerDao.DeleteLinkMan(Id);
            //删除客户
            customerDao.LogicDelete(Id);
            //删除客户包含的卡(将卡的deleted更改为'1')
            memberCardDao.UpdateByCustomerId(Id);
        }
        #endregion

        #region 逻辑删除客户
        public void LogicDelete(long Id)
        {
            customerDao.LogicDelete(Id);
        }
        #endregion

        #region  更新客户(张晓林 2008-12-19 修正)
        [Transaction]
        public void Update(Customer customer)
        {
            //customer.CustomerType = new Workflow.Da.Domain.CustomerType();
            //customer.CustomerType.Id = 1;//?

            customer.ValidateStatus = Workflow.Support.Constants.CUSTOMER_VALIDATE_STATUS_KEY;
            customer.LinkManCount = linkManDao.SelectLinkManCount(customer.Id);
            customerDao.Update(customer);
        }
        #endregion

        #region 更新客户(更改客户LinkManCount)
        [Transaction]
        public void UpdateCustomer(Customer customer)
        {
            customer.LinkManCount = linkManDao.SelectLinkManCount(customer.Id);
            customerDao.Update(customer);

        }
        #endregion

        #region 更改客户的确认状态
        public void UpdateCustomerValidate(Customer customer)
        {
            System.Collections.Hashtable condition = new System.Collections.Hashtable();
            condition.Add("Id", customer.Id);
            condition.Add("ValidateStatus", Workflow.Support.Constants.CUSTOMER_VALIDATE_STATUS_KEY);
            customerDao.UpdateValidateStatus(condition);
        }
        #endregion

        #region 新添加联系人或更改联系人
        public void InsertLinkMan(LinkMan linkMan)
        {
            if (linkMan.Id == 0)
            {
                linkManDao.Insert(linkMan);
                //更改客户信息link_man_count
                Customer customer = customerDao.SelectByPk(linkMan.CustomerId);
                customer.LinkManCount = customer.LinkManCount + 1;
                customerDao.Update(customer);
            }
            else
            {
                linkManDao.Update(linkMan);
            }
        }
        #endregion

        #region 更新联系人
        public void UpdateLinkMan(LinkMan linkMan)
        {
            linkManDao.Update(linkMan);
        }
        #endregion

        #region 合并客户
        [Transaction]
        public void UpdateConbinationCustomerId(Hashtable linkman)
        {
            linkManDao.UpdateConbinationCustomerId(linkman);

            orderDao.UpdateConbinationCustomerId(linkman);

            memberCardDao.UpdateConbinationCustomerId(linkman);
        }
        #endregion

        #region 删除联系人
        public void DeleteLinkMan(long Id)
        {
            linkManDao.Delete(Id);
        }
        #endregion
    }
}
