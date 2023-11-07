using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Service.Impl;

namespace Workflow.Action.Model
{
    /// <summary>
    /// ��    ��: Workflow.Action.Model.NewCustomerModel
    /// ���ܸ�Ҫ: 
    /// ��    ��: liuwei
    /// ����ʱ��: 2007-9-20
    /// ��������: 
    /// ����ʱ��: 
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
        /// Gets or sets �ͻ�����
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
        /// Gets or sets �ͻ����
        /// </summary>
        /// <value>The simple name</value>
        public string SimpleName
        {
            get { return simpleName; }
            set { simpleName = value; }
        }
        private long secondaryTradeId;
        /// <summary>
        /// Gets or sets ��ҵ��ϸ���ݱ��
        /// </summary>
        /// <value>The secondary trade id</value>
        public long SecondaryTradeId
        {
            get { return secondaryTradeId; }
            set { secondaryTradeId = value; }
        }

        private long customerLevelId;
        /// <summary>
        /// Gets or sets �ͻ��ȼ����
        /// </summary>
        /// <value>The customer level id</value>
        public long CustomerLevelId
        {
            get { return customerLevelId; }
            set { customerLevelId = value; }
        }

        private long customerTypeId;
        /// <summary>
        /// Gets or sets �ͻ����ͱ��
        /// </summary>
        /// <value>The customer type id</value>
        public long CustomerTypeId
        {
            get { return customerTypeId; }
            set { customerTypeId = value; }
        }

        private string telNo;
        /// <summary>
        /// Gets or sets �绰
        /// </summary>
        /// <value>The tel no id</value>
        public string TelNo
        {
            get { return telNo; }
            set { telNo = value; }
        }

        private string linkManName;
        /// <summary>
        /// Gets or sets ��ϵ�˵�����
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
        /// Gets or sets ��ַ
        /// </summary>
        /// <value>The address</value>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private  string memo;
        /// <summary>
        /// Gets or sets ��ע
        /// </summary>
        /// <value>The memo</value>
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
        private string needTicket;
        /// <summary>
        /// Gets or sets ��Ʊ
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
        /// Gets or sets ��ϵ������
        /// </summary>
        /// <value>The link man count</value>
        public int LinkManCount
        {
            get { return linkManCount; }
            set { linkManCount = value; }
        }

        private string sex;
        /// <summary>
        /// Gets or sets �Ա�
        /// </summary>
        /// <value>The sex</value>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private int age;
        /// <summary>
        /// Gets or sets ����
        /// </summary>
        /// <value>The age</value>
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string hobby;
        /// <summary>
        /// Gets or sets ����
        /// </summary>
        /// <value>The hobby</value>
        public string Hobby
        {
            get { return hobby; }
            set { hobby = value; }
        }

        private string mobileNo;
        /// <summary>
        /// Gets or sets �ֻ�
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
        /// Gets or sets ְ��
        /// </summary>
        /// <value>The position</value>
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        private long id;
        /// <summary>
        /// Gets or sets �ͻ����
        /// </summary>
        /// <value>The position</value>
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string customerLevelName;
        /// <summary>
        /// Gets or sets �ͻ�����
        /// </summary>
        /// <value>The position</value>
        public string CustomerLevelName
        {
            get { return customerLevelName; }
            set { customerLevelName = value; }
        }

        private string customerTypeName;
        /// <summary>
        /// Gets or sets �ͻ�����
        /// </summary>
        /// <value>The position</value>
        public string CustomerTypeName
        {
            get { return customerTypeName; }
            set { customerTypeName = value; }
        }

        private string validateStatus;
        /// <summary>
        /// Gets or sets �ͻ�״̬
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
        /// �������� ��ǿ
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

        #region ��ǰ��ϵ�˵�id 

        private long linkManId;
        /// <summary>
        /// ��ǰ��ϵ�˵�id ����ط
        /// </summary>
        public long LinkManId
        {
            get { return linkManId; }
            set { linkManId = value; }
        }

        #endregion

        #region ֧�ֵ�ǰҳ��Ķ���

        private string action;
        /// <summary>
        /// ֧�ֵ�ǰҳ��Ķ��� ����ط

        /// </summary>
        public string Action
        {
            get
            {
                if (null == action)
                    return "����";
                return action;
            }
            set { action = value; }
        }

        #endregion

        private string identityNo;
        /// <summary>
        /// ��ȡ�����������֤��
        /// </summary>
        public string IdentityNo 
        {
            set { identityNo = value; }
            get { return identityNo; }
        }
    }
}
