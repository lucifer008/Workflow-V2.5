using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Service.Impl;

namespace Workflow.Action.Model
{
    /// <summary>
    /// 名    称: Workflow.Action.Model.NewCustomerModel
    /// 功能概要: 
    /// 作    者: liuwei
    /// 创建时间: 2007-9-20
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class NewCustomerModel
    {
        private IList<Customer> customerList;
        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        /// <value>The customer.</value>
        public IList<Customer> CustomerList
        {
            get { return customerList; }
            set { customerList = value; }
        }
        private IList<MasterTrade> masterTradeList;
        /// <summary>
        /// Gets or sets the Master Trade 
        /// </summary>
        /// <value>The Master Trade.</value>
        public IList<MasterTrade> MasterTradeList
        {
            get { return masterTradeList; }
            set { masterTradeList = value; }
        }

        private IList<SecondaryTrade> secondaryTradeList;
        /// <summary>
        /// Gets or sets the Secondary Trade 
        /// </summary>
        /// <value>The Secondary Trade.</value>
        public IList<SecondaryTrade> SecondaryTradeList
        {
            get { return secondaryTradeList; }
            set { secondaryTradeList = value; }
        }

        private IList<CustomerLevel> customerLevelList;
        /// <summary>
        /// Gets or sets the Customer Level
        /// </summary>
        /// <value>The Customer Level.</value>
        public IList<CustomerLevel> CustomerLevelList
        {
            get { return customerLevelList; }
            set { customerLevelList = value; }
        }

        private IList<CustomerType> customerTypeList;
        /// <summary>
        /// Gets or sets the Customer Type
        /// </summary>
        /// <value>The Customer Type.</value>
        public IList<CustomerType> CustomerTypeList
        {
            get { return customerTypeList; }
            set { customerTypeList = value; }
        }

        private IList<LinkMan> linkManList;
        /// <summary>
        /// Gets or sets the link man list
        /// </summary>
        /// <value>The link man list.</value>
        public IList<LinkMan> LinkManList
        {
            get { return linkManList; }
            set { linkManList = value; }
        }

        private IList<Order> orderList;
        /// <summary>
        /// Gets or sets the order list
        /// </summary>
        /// <value>The order list.</value>
        public IList<Order> OrderList
        {
            get { return orderList; }
            set { orderList = value; }
        }

        private LinkMan linkMan;
        /// <summary>
        /// Gets or sets the link man 
        /// </summary>
        /// <value>The link man .</value>
        public LinkMan LinkMan
        {
            get { return linkMan; }
            set { linkMan = value; }
        }

        private string name;
        /// <summary>
        /// Gets or sets 客户名称
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { if(null==name)
                                return "";
            return name;}
            set { name = value; }
        }
        private string simpleName;
        /// <summary>
        /// Gets or sets 客户简称
        /// </summary>
        /// <value>The simple name</value>
        public string SimpleName
        {
            get { return simpleName; }
            set { simpleName = value; }
        }
        private long secondaryTradeId;
        /// <summary>
        /// Gets or sets 行业详细数据编号
        /// </summary>
        /// <value>The secondary trade id</value>
        public long SecondaryTradeId
        {
            get { return secondaryTradeId; }
            set { secondaryTradeId = value; }
        }

        private long customerLevelId;
        /// <summary>
        /// Gets or sets 客户等级编号
        /// </summary>
        /// <value>The customer level id</value>
        public long CustomerLevelId
        {
            get { return customerLevelId; }
            set { customerLevelId = value; }
        }

        private long customerTypeId;
        /// <summary>
        /// Gets or sets 客户类型编号
        /// </summary>
        /// <value>The customer type id</value>
        public long CustomerTypeId
        {
            get { return customerTypeId; }
            set { customerTypeId = value; }
        }

        private string telNo;
        /// <summary>
        /// Gets or sets 电话
        /// </summary>
        /// <value>The tel no id</value>
        public string TelNo
        {
            get { return telNo; }
            set { telNo = value; }
        }

        private string linkManName;
        /// <summary>
        /// Gets or sets 联系人的名字
        /// </summary>
        /// <value>The link man</value>
        public string LinkManName
        {
            get { return linkManName; }
            set { linkManName = value; }
        }

        private Customer customer;
        /// <summary>
        /// Gets or sets customer
        /// </summary>
        /// <value>The customer</value>
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private string address;
        /// <summary>
        /// Gets or sets 地址
        /// </summary>
        /// <value>The address</value>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private  string memo;
        /// <summary>
        /// Gets or sets 备注
        /// </summary>
        /// <value>The memo</value>
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
        private string needTicket;
        /// <summary>
        /// Gets or sets 发票
        /// </summary>
        /// <value>The memo</value>
        public string NeedTicket
        {
            get { return needTicket; }
            set { needTicket = value; }
        }

        private string needTicketName;
        public string NeedTicketName
        {
            get { return needTicketName; }
            set { needTicketName = value; }
        }
        private int linkManCount;
        /// <summary>
        /// Gets or sets 联系人数量
        /// </summary>
        /// <value>The link man count</value>
        public int LinkManCount
        {
            get { return linkManCount; }
            set { linkManCount = value; }
        }

        private string sex;
        /// <summary>
        /// Gets or sets 性别
        /// </summary>
        /// <value>The sex</value>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private int age;
        /// <summary>
        /// Gets or sets 年龄
        /// </summary>
        /// <value>The age</value>
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string hobby;
        /// <summary>
        /// Gets or sets 爱好
        /// </summary>
        /// <value>The hobby</value>
        public string Hobby
        {
            get { return hobby; }
            set { hobby = value; }
        }

        private string mobileNo;
        /// <summary>
        /// Gets or sets 手机
        /// </summary>
        /// <value>The mobile no</value>
        public string MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; }
        }

        private string qq;
        /// <summary>
        /// Gets or sets qq
        /// </summary>
        /// <value>The qq</value>
        public string QQ
        {
            get { return qq; }
            set { qq = value; }
        }

        private string email;
        /// <summary>
        /// Gets or sets E_MAIL
        /// </summary>
        /// <value>The E_MAIL</value>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string position;
        /// <summary>
        /// Gets or sets 职务
        /// </summary>
        /// <value>The position</value>
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        private long id;
        /// <summary>
        /// Gets or sets 客户编号
        /// </summary>
        /// <value>The position</value>
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string customerLevelName;
        /// <summary>
        /// Gets or sets 客户级别
        /// </summary>
        /// <value>The position</value>
        public string CustomerLevelName
        {
            get { return customerLevelName; }
            set { customerLevelName = value; }
        }

        private string customerTypeName;
        /// <summary>
        /// Gets or sets 客户类型
        /// </summary>
        /// <value>The position</value>
        public string CustomerTypeName
        {
            get { return customerTypeName; }
            set { customerTypeName = value; }
        }

        private string validateStatus;
        /// <summary>
        /// Gets or sets 客户状态
        /// </summary>
        /// <value>The position</value>
        public string ValidateStatus
        {
            get { return validateStatus; }
            set { validateStatus = value; }
        }

        private int payType;
        public int PayType
        {
            get { return payType; }
            set { payType = value; }
        }

        /// <summary>
        /// 付款类型 付强
        /// </summary>
        private IList<LabelValue> paymentTypes;
        public IList<LabelValue> PaymentTypes
        {
            get { return paymentTypes; }
            set { paymentTypes = value; }
        }

        private string paymentTypeString;
        public string PaymentTypeString 
        {
            set { paymentTypeString = value; }
            get { return paymentTypeString; }
        }

        #region 当前联系人的id 

        private long linkManId;
        /// <summary>
        /// 当前联系人的id 陈汝胤
        /// </summary>
        public long LinkManId
        {
            get { return linkManId; }
            set { linkManId = value; }
        }

        #endregion

        #region 支持当前页面的动作

        private string action;
        /// <summary>
        /// 支持当前页面的动作 陈汝胤

        /// </summary>
        public string Action
        {
            get
            {
                if (null == action)
                    return "新增";
                return action;
            }
            set { action = value; }
        }

        #endregion

        private string identityNo;
        /// <summary>
        /// 获取或者设置身份证号
        /// </summary>
        public string IdentityNo 
        {
            set { identityNo = value; }
            get { return identityNo; }
        }
    }
}
