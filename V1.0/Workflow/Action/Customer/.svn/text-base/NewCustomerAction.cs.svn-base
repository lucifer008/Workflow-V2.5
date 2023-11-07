using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Util;
using Workflow.Service;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.OrderManage;
using Workflow.Service.CustomerManager;
/// <summary>
/// 名    称: NewCustomerAction
/// 功能概要: 客户管理Action
/// 作    者: 张晓林
/// 创建时间: 2009-02-04
/// 修正履历: 
/// 修正时间: 
/// </summary>
namespace Workflow.Action
{
    public class NewCustomerAction
    {
        #region 注入Service
        private NewCustomerModel model = new NewCustomerModel();
        /// <summary>
        /// Gets or sets the New Customer model
        /// </summary>
        /// <value>The New Customer model.</value>
        public NewCustomerModel Model
        {
            get { return model; }
        }
        private IMasterDataService masterDataService;
        /// <summary>
        /// Gets or sets the master date service
        /// </summary>
        /// <value>The master date service</value>
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }

        private ICustomerService customerService;
        /// <summary>
        /// Gets or sets the customer service
        /// </summary>
        /// <value>The customer service</value>
        public ICustomerService CustomerService
        {
            set { customerService = value; }
        }

        private ISearchCustomerService searchCustomerService;
        public ISearchCustomerService SearchCustomerService
        {
            set{searchCustomerService=value;}
        }

        private IOrderService orderService;
        /// <summary>
        /// Gets or sets the order service
        /// </summary>
        /// <value>The order service</value>
        public IOrderService OrderService
        {
            set { orderService = value; }
        }
        #endregion

        #region  初始化页面
        /// <summary>
        /// 方法名称: Init
        /// 功能概要: 初始化页面
        /// 作    者: liuwei
        /// 创建时间: 2007-9-21
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void Init()
        {
            model.MasterTradeList = masterDataService.GetMasterTrade();
            model.SecondaryTradeList = masterDataService.GetSecondaryTrade();
            model.CustomerLevelList = masterDataService.GetCustomerLevel();
            model.CustomerTypeList = masterDataService.GetCustomerTypes();
            model.PaymentTypes = masterDataService.GetPaymentTypes(); 
        }
        public virtual void InitCustomer() 
        {
            model.MasterTradeList = masterDataService.GetMasterTrade();
            model.SecondaryTradeList = masterDataService.GetSecondaryTrade();
            model.PaymentTypes = masterDataService.GetPaymentTypes();
            model.CustomerLevelList = masterDataService.GetCustomerLevel();
        }
        public virtual void InitCutomerType() 
        {
            List<CustomerType> customerTypeList = (List<CustomerType>) masterDataService.GetCustomerTypes();
            for (int i = 0; i < customerTypeList.Count;i++ )
            {
                if (customerTypeList[i].Id == -1 || customerTypeList[i].Name == "请选择")
                {
                    customerTypeList.RemoveAt(i);
                }
            }
            model.CustomerTypeList = customerTypeList;
        }
        #endregion

        #region 插入客户,联系人
        /// <summary>
        /// 方法名称: InsertCustomer
        /// 功能概要: 新增客户
        /// 作    者: liuwei
        /// 创建时间: 2007-9-21
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void InsertCustomer()
        {
            //获取客户信息
            Workflow.Da.Domain.Customer customer = new Workflow.Da.Domain.Customer();

            customer.Name = model.Name;

            customer.SecondaryTrade = new SecondaryTrade();
            customer.SecondaryTrade.Id = model.SecondaryTradeId;

            customer.CustomerLevel = new CustomerLevel();
            customer.CustomerLevel.Id = model.CustomerLevelId;

            customer.CustomerType = new CustomerType();
            customer.CustomerType.Id = model.CustomerTypeId;
 
            customer.SimpleName = model.SimpleName;
            customer.Address = model.Address;
            customer.LastLinkMan = model.LinkManName;
            customer.LastTelNo = model.TelNo;
            customer.LinkManCount = 1;
            customer.Memo = model.Memo;
            customer.NeedTicket = model.NeedTicket;
            customer.ValidateStatus = Workflow.Support.Constants.CUSTOMER_NOT_VALIDATE_STATUS_KEY;
            customer.PayType = model.PayType;
            //获取联系人信息
            Workflow.Da.Domain.LinkMan linkMan = new LinkMan();

            linkMan.Name = model.LinkManName;
            linkMan.Sex = model.Sex;
            linkMan.Age = model.Age;
            linkMan.Position = model.Position;
            linkMan.Hobby = model.Hobby;
            linkMan.CompanyTelNo = model.TelNo;
            linkMan.MobileNo = model.MobileNo;
            linkMan.Qq = model.QQ;
            linkMan.Email = model.Email;
            linkMan.Address = model.Address;
            linkMan.Memo = model.Memo;
            //插入客户,联系人
            model.Id = customerService.InsertCustomer(customer,linkMan);
        }
        #endregion
        
        #region 查询客户信息,通过Id
        /// <summary>
        /// 名    称: SearchCustomerById
        /// 功能概要: 查询客户信息，通过Id
        /// 作    者: liuwei
        /// 创建时间: 2007-9-24
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        public virtual void SearchCustomerById()
        {
            model.Customer = searchCustomerService.SearchCustomerById(model.Id);
        }
        #endregion

        #region 查询联系人信息，通过CustomerId
        /// <summary>
        /// 名    称: SearchLinkManByCustomerId
        /// 功能概要: 查询联系人信息，通过CustomerId
        /// 作    者: liuwei
        /// 创建时间: 2007-9-25
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        public virtual void SearchLinkManByCustomerId()
        {
            model.LinkManList = searchCustomerService.SearchLinkManByCustomerId(model.Id);
        }
        #endregion

        #region 查询联系人信息，通过LinkMan Id
        /// <summary>
        /// 名    称: SearchLinkManByPk
        /// 功能概要: 查询联系人信息，通过LinkMan Id
        /// 作    者: liuwei
        /// 创建时间: 2007-9-27
        /// 修正履历: 陈汝胤 model.LinkMan.Id 修改为 model.LinManId
        /// 修正时间: 2009.1.16
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        public void SearchLinkManByPk()
        {
            model.LinkMan = searchCustomerService.SearchLinkManByPk(model.LinkManId);
        }
        #endregion

        #region 通过CustomerId查询联系人信息
        /// <summary>
        /// 通过CustomerId查询联系人信息
        /// </summary>
        public virtual void SelectLinkManByCustomerId()
        {
            model.LinkManList = searchCustomerService.SelectLinkManByCustomerId(model.Id);
        }
        #endregion

        #region 新添加联系人或更改联系人
        /// <summary>
        /// 方法名称: InsertLinkMan
        /// 功能概要: 新添加联系人或更改联系人
        /// 作    者: liuwei
        /// 创建时间: 2007-9-27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void InsertLinkMan()
        {
            customerService.InsertLinkMan(model.LinkMan);
        }
        #endregion
   
        #region 查询所有客户
        /// <summary>
        /// 方法名称: SearchAllCustomer
        /// 功能概要: 查询所有客户
        /// 作    者: liuwei
        /// 创建时间: 2007-9-24
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void SearchAllCustomer()
        {
            model.CustomerList = searchCustomerService.SearchAllCustomer();
        }
        #endregion
               
        #region 查询客户(客户一览)
        /// <summary>
        /// 方法名称: SearchCustomerCondition
        /// 功能概要: 查询客户
        /// 作    者: liuwei
        /// 创建时间: 2007-9-25
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        ///
        public virtual void SearchCustomerCondition()
        {
            System.Collections.Hashtable condition = new System.Collections.Hashtable();

            if (model.Name != "")
            {
                condition.Add("Name", model.Name+"%");
            }

            if (model.LinkManName != "")
            {
                condition.Add("LinkMan", model.LinkManName);
            }

            if (!StringUtils.IsEmpty(model.LinkManName))
            {
                condition.Add("NeedLinkMan", "true");
            }
            model.CustomerList = searchCustomerService.SearchCustomerCondition(condition);
        }
        #endregion

        #region 查询所有未确认客户
        /// <summary>
        /// 方法名称: SearchAllNotValidate
        /// 功能概要: 查询所有未确认客户
        /// 作    者: liuwei
        /// 创建时间: 2007-9-27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void SearchAllNotValidate(int currentPageIndex)
        {
            Hashtable hashCondition = new Hashtable();
            hashCondition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            hashCondition.Add("PageCount", currentPageIndex - 1);
            model.CustomerList = searchCustomerService.SearchAllNotValidate(hashCondition);
        }

        /// <summary>
        /// 名    称: SearchAllNotValidateRowCount
        /// 功能概要: 查询所有未确认客户 的记录数目
        /// 作    者: 张晓林
        /// 创建时间: 2009-02-09
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        ///
        public long SearchAllNotValidateRowCount() 
        {
            return searchCustomerService.SearchAllNotValidateRowCount();
        }
        #endregion
      
        #region 删除客户
        /// <summary>
        /// 方法名称: DeleteCustomer
        /// 功能概要: 删除客户
        /// 作    者: liuwei
        /// 创建时间: 2007-9-25
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void DeleteCustomer()
        {
            customerService.DeleteCustomer(model.Id);
        }
        #endregion

        #region 逻辑删除客户
        /// <summary>
        /// 方法名称: LogicDelete
        /// 功能概要: 逻辑删除客户
        /// 作    者: liuwei
        /// 创建时间: 2007-9-28
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void LogicDelete()
        {
            customerService.LogicDelete(model.Id);
        }
        #endregion
     
        #region 删除联系人
        /// <summary>
        /// 方法名称: DeleteLinkMan
        /// 功能概要: 删除联系人
        /// 作    者: liuwei
        /// 创建时间: 2007-9-27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void DeleteLinkMan()
        {
            customerService.DeleteLinkMan(model.LinkMan.Id);
        }
        #endregion
       
        #region 更新客户
        /// <summary>
        /// 方法名称: UpdateCustomer
        /// 功能概要: 更新客户
        /// 作    者: liuwei
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void UpdateCustomer()
        {
            customerService.UpdateCustomer(model.Customer);
        }
        #endregion

        #region 更新联系人
        /// <summary>
        /// 方法名称: UpdateLinkMan
        /// 功能概要: 更新联系人
        /// 作    者: liuwei
        /// 创建时间: 2007-9-27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void UpdateLinkMan()
        {
            customerService.UpdateLinkMan(model.LinkMan);
        }
        #endregion

        #region 更改客户确认状态
        /// <summary>
        /// 方法名称: UpdateCustomerValidate
        /// 功能概要: 更改客户确认状态
        /// 作    者: liuwei
        /// 创建时间: 2007-9-27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void UpdateCustomerValidate()
        {
            customerService.UpdateCustomerValidate(model.Customer);
        }
        #endregion

        #region 合并客户，更改客户Id
        /// <summary>
        /// 方法名称: UpdateConbinationCustomerId
        /// 功能概要: 合并客户，更改客户Id
        /// 作    者: liuwei
        /// 创建时间: 2007-9-28
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void UpdateConbinationCustomerId()
        {
            System.Collections.Hashtable linkman = new System.Collections.Hashtable();

            linkman.Add("NewCustomerId", model.LinkMan.CustomerId);
            linkman.Add("OldCustomerId", model.Id);

            customerService.UpdateConbinationCustomerId(linkman);
        }
        #endregion

        #region 通过CustomerId查询Order信息
        /// <summary>
        /// 方法名称: SearchOrderByCustomerId
        /// 功能概要: 通过CustomerId查询Order信息
        /// 作    者: liuwei
        /// 创建时间: 2007-9-28
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="model"></param>
        /// 
        public virtual void SearchOrderByCustomerId(int currentPageIndex)
        {
            Hashtable condition = new Hashtable();
            condition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            condition.Add("PageCount", currentPageIndex);
            condition.Add("CustomerId", model.Id);
            model.OrderList = searchCustomerService.SearchOrderByCustomerId(condition);
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
        public long SearchOrderRowCountByCustomerId() 
        {
            return Convert.ToInt32(searchCustomerService.SearchOrderRowCountByCustomerId(model.Id));
        }
        #endregion

    }
}
