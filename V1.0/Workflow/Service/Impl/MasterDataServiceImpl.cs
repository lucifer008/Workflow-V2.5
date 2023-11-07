using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Support.Exception;
using System.Collections;
using System.Web;
using Spring.Transaction.Interceptor;
using Workflow.Service.SystemPermission.RoleManage;

namespace Workflow.Service.Impl
{
    public class MasterDataServiceImpl : Workflow.Service.IMasterDataService
    {
        public MasterDataServiceImpl()
        {
            GetDeliveryTypes();
        }

        #region ע��Dao

		/// <summary>
		/// ����
		/// </summary>
		private IOrderDao orderDao;
		public IOrderDao OrderDao 
		{
			set { orderDao = value; }
		}

		/// <summary>
		///��λ 
		/// </summary>
		private IEmployeePositionDao employeePositionDao;
		public IEmployeePositionDao EmployeePositionDao 
		{
			set { employeePositionDao = value; }
		}

        /// <summary>
        /// ��Ա
        /// </summary>
        private IEmployeeDao employeeDao;
        public IEmployeeDao EmployeeDao
        {
            set { employeeDao = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        private IOrderItemDao orderItemDao;
        public IOrderItemDao OrderItemDao
        {
            set { orderItemDao = value; }
        }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        private ICustomerTypeDao customerTypeDao;
        public ICustomerTypeDao CustomerTypeDao
        {
            set { customerTypeDao = value; }
        }

        /// <summary>
        /// ҵ������
        /// </summary>
        private IBusinessTypeDao businessTypeDao;
        public IBusinessTypeDao BusinessTypeDao
        {
            set { businessTypeDao = value; }
        }

        /// <summary>
        /// �ͻ��ȼ�
        /// </summary>
        private ICustomerLevelDao customerLevelDao;
        public ICustomerLevelDao CustomerLevelDao
        {
            set { customerLevelDao = value; }
        }

        /// <summary>
        /// ����ҵ
        /// </summary>
        private IMasterTradeDao masterTradeDao;
        public IMasterTradeDao MasterTradeDao
        {
            set { masterTradeDao = value; }
        }

        /// <summary>
        /// ����ҵ
        /// </summary>
        private ISecondaryTradeDao secondaryTradeDao;
        public ISecondaryTradeDao SecondaryTradeDao
        {
            set { secondaryTradeDao = value; }
        }

        /// <summary>
        /// ӡ��Ҫ��
        /// </summary>
        private IPrintDemandDao printDemandDao;
        public IPrintDemandDao PrintDemandDao
        {
            set { printDemandDao = value; }
        }

        /// <summary>
        /// �۸�����
        /// </summary>
        private IPriceFactorDao priceFactorDao;
        public IPriceFactorDao PriceFactorDao
        {
            set { priceFactorDao = value; }
        }

        /// <summary>
        /// ����ֵ
        /// </summary>
        private IFactorValueDao factorValueDao;
        public IFactorValueDao FactorValueDao
        {
            set { factorValueDao = value; }
        }

        /// <summary>
        /// ���ȼ�
        /// </summary>
        private IMemberCardLevelDao memberCardLevelDao;
        public IMemberCardLevelDao MemberCardLevelDao
        {
            set { memberCardLevelDao = value; }
        }

        private IReportLessModeDao reportLessModeDao;
        /// <summary>
        /// ��ʧ��ʽ
        /// </summary>
        public IReportLessModeDao ReportLessModeDao
        {
            set { reportLessModeDao = value; }
        }

        /// <summary>
        /// Ӫ���
        /// </summary>
        private ICampaignDao campaignDao;
        public ICampaignDao CampaignDao
        {
            set { campaignDao = value; }
        }

        private ITrashReasonDao trashReasonDao;
        public ITrashReasonDao TrashReasonDao
        {
            set { trashReasonDao = value; }
        }

        /// <summary>
        /// ְλ(����)
        /// </summary>
        private IPositionDao positionDao;
        public IPositionDao PositionDao
        {
            set { positionDao = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        private IMachineDao machineDao;
        public IMachineDao MachineDao
        {
            set { machineDao = value; }
        }
        
        /// <summary>
        /// ���ֽ��һ��
        /// </summary>
        /// <returns></returns>
        private IPaperTypeDao paperTypeDao;
        public IPaperTypeDao PaperTypeDao
        {
            set { paperTypeDao = value; }
        }
        /// <summary>
        /// ���ֽ��һ��
        /// </summary>
        /// <returns></returns>
        private IPaperSpecificationDao paperSpecificationDao;
        public IPaperSpecificationDao PaperSpecificationDao
        {
            set { paperSpecificationDao = value; }
        }

		/// <summary>
		/// �û�Dao
		/// </summary>
		private IUserDao userDao;
		public IUserDao UserDao
		{
			set { userDao = value; }
		}

		/// <summary>
		///�û���ɫDao
		/// </summary>
		private IUserRoleDao userRoleDao;
		public IUserRoleDao UserRoleDao
		{
			set { userRoleDao = value; }
		}

        private IBranchShopDao branchShopDao;
        public IBranchShopDao BranchShopDao
        {
            set { branchShopDao = value; }
        }

        private IRoleService roleService;
        public IRoleService RoleService
        {
            set { roleService = value; }
        }

        #endregion

        private IList<LabelValue> deliveryTypes;
        public IList<CustomerType> GetCustomerTypes()
        {
            return customerTypeDao.SelectAll();
        }

        private IList<LabelValue> paymentTypes;
        public IList<LabelValue> GetDeliveryTypes()
        {
            if (deliveryTypes == null)
            {
                deliveryTypes = new List<LabelValue>();
                deliveryTypes.Add(new LabelValue(Constants.DELIVERY_TYPE_SELF_GET_VALUE.ToString(), Constants.DELIVERY_TYPE_SELF_GET_LABEL));
                deliveryTypes.Add(new LabelValue(Constants.DELIVERY_TYPE_WAITFOR_GET_VALUE.ToString(), Constants.DELIVERY_TYPE_WAITFOR_GET_LABEL));
                deliveryTypes.Add(new LabelValue(Constants.DELIVERY_TYPE_DELIVERY_VALUE.ToString(), Constants.DELIVERY_TYPE_DELIVERY_LABEL));
            }
            return deliveryTypes;
        }

        public IList<LabelValue> GetPaymentTypes()
        {
            if (paymentTypes == null)
            {
                paymentTypes = new List<LabelValue>();
                paymentTypes.Add(new LabelValue(Constants.PAYMENT_TYPE_CASHER_GET_VALUE.ToString(), Constants.PAYMENT_TYPE_CASHER_GET_LABEL));
                paymentTypes.Add(new LabelValue(Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE.ToString(), Constants.PAYMENT_TYPE_ACCOUNT_GET_LABEL));
            }
            return paymentTypes;
        }

        #region //Ӫ����Ļ�������
        ///<summary>
        ///Ӫ����Ļ�������
        ///</summary>
        ///<returns></returns>
        public IList<Campaign> GetCampaign()
        {
            return campaignDao.SelectAll();
        }
        #endregion

        #region //��ʧ��ʽ�Ļ�������
        ///<summary>
        ///��ʧ��ʽ�Ļ�������
        ///</summary>
        ///<returns></returns>
        public IList<ReportLessMode> GetReportLessMode()
        {
            return reportLessModeDao.SelectAll();
        }
        #endregion

        #region //ҵ�����͵Ļ�������
        ///<summary>
        ///ҵ�����͵Ļ�������
        ///</summary>
        ///<returns></returns>
        public IList<BusinessType> GetBusinessTypes()
        {
            return businessTypeDao.SelectAll();
        }
        #endregion

        #region //�ͻ�����Ļ�������
        ///<summary>
        ///�ͻ�����Ļ�������
        ///</summary>
        ///<returns></returns>
        public IList<CustomerLevel> GetCustomerLevel()
        {
            return customerLevelDao.SelectAll();
        }
        #endregion

        #region //�ͻ����͵Ļ�������
        ///<summary>
        ///�ͻ����͵Ļ�������
        ///</summary>
        ///<returns></returns>
        public IList<CustomerType> getCustomerType()
        {
            return customerTypeDao.SelectAll();
        }
        #endregion

        #region //��ҵ��Ϣ�Ļ�������
        ///<summary>
        ///��ҵ��Ϣ�Ļ�������
        ///</summary>
        ///<returns></returns>
        public IList<MasterTrade> GetMasterTrade()
        {
            return masterTradeDao.SelectAll();
        }
        #endregion

        #region //��ҵ��ϸ�Ļ�������
        ///<summary>
        ///��ҵ��ϸ�Ļ�������
        ///</summary>
        ///<returns></returns>
        public IList<SecondaryTrade> GetSecondaryTrade()
        {
            return secondaryTradeDao.SelectAll();
        }
        #endregion


        public IList<PrintDemand> GetPrintDemandList()
        {
            return printDemandDao.SelectAll();
        }

        #region //��ȡ�۸�����
        /// <summary>
        /// ��ȡ�۸�����
        /// </summary>
        /// <returns></returns>
        public IList<PriceFactor> GetPriceFactors()
        {
            return priceFactorDao.SelectAll();
        }
        #endregion

        #region //��ȡ���й�Ա�б�
        public IList<Employee> GetEmployeeList()
        {
            return employeeDao.GetEmployeeList();
        }
        #endregion

        public IList<OrderItem> GetOrderItemIDByOrderNo(string strOrderNo)
        {
            return orderItemDao.GetOrderItemByOrderNo(strOrderNo);
        }

        #region //��ȡ����ֵList
        /// <summary>
        /// ��ȡ����ֵList
        /// </summary>
        /// <returns></returns>
        //////////
        public string GetFactorValueText(PriceFactor priceFactor)
        {
            #region ��ʱ����
            //string str;
            //List<string> lst = new List<string>();
            //for (int i = 0; i < baseBusinessTypePriceSet.Count; i++)
            //{
            //    if (baseBusinessTypePriceSet.Item(i) == 0)
            //        break;
            //    //����IDΪ��,˵���ǹ̶�����,��Ҫ�ӹ̶�����ȡ��Value
            //    if (priceFactor.PriceFactorId == 0)
            //    {
            //        //�ӹ̶���TargetTable��ȡ��
            //        str = factorValueDao.GetFactorValueByFactorValueId(priceFactor, false);
            //    }
            //    else
            //    {
            //        //�ӹ�����FactorValue��ȡ��
            //        str = factorValueDao.GetFactorValueByFactorValueId(priceFactor, true);
            //    }
            //    lst.Add(str);
            //}
            //return lst;
            #endregion

            //����ֵ��Ϊ-1˵����ҵ��������û�и����ص�����,ֱ�ӷ���"-"
            if (priceFactor.PriceValueId == -1)
            {
                return "-";
            }
            //����IDΪ��,˵���ǹ̶�����,��Ҫ�ӹ̶�����ȡ��Value
            if (priceFactor.PriceFactorId == 0)
            {
                //�ӹ̶���TargetTable��ȡ��
                return factorValueDao.GetFactorValueByFactorValueId(priceFactor, false);
            }
            else
            {
                //�ӹ�����FactorValue��ȡ��
                return  factorValueDao.GetFactorValueByFactorValueId(priceFactor, true);
            }
        }
        #endregion 

        #region //��ȡ������һ��
        /// <summary>
        /// ��ȡ������һ��
        /// </summary>
        /// <returns></returns>
        public IList<MemberCardLevel> GetMemberCardLevels()
        {
            return memberCardLevelDao.SelectAll();
        }
        #endregion

        public IList<TrashReason> GetTrashReasonList()
        {
            return trashReasonDao.SelectAll();
        }

        #region //���ְλһ��
        /// <summary>
        /// ���ְλһ��
        /// </summary>
        /// <returns></returns>
        public IList<Position> GetPositionList()
        {
            return positionDao.SelectAll();
        }
        #endregion

        #region //��û���һ��
        /// <summary>
        /// ��û���һ��
        /// </summary>
        /// <returns></returns>
        public IList<Machine> GetMachineList()
        {
            return machineDao.SelectAll();
        }
        #endregion

        #region //���ֽ��һ��
        /// <summary>
        /// ���ֽ��һ��
        /// </summary>
        /// <returns></returns>
        public IList<PaperType> GetPaperTypeList()
        {
            return paperTypeDao.SelectAll();
        }
        #endregion

        #region //���ֽ��һ��
        /// <summary>
        /// ���ֽ��һ��
        /// </summary>
        /// <returns></returns>
        public IList<PaperSpecification> GetPaperSpecificationList()
        {
            return paperSpecificationDao.SelectAll();
        }
        #endregion

        #region //���ݹ�˾ID��ȡ���������ӹ�˾
        /// <summary>
        /// ���ݹ�˾ID��ȡ���������ӹ�˾
        /// </summary>
        /// <param name="companyId"></param>
        public IList<BranchShop> GetAllBranchShopInfo(long companyId)
        {
            return branchShopDao.GetBranchShopListByCompanyId(companyId);
        }
        #endregion 

        #region //����½���û����������Ƿ���ȷ
        /// <summary>
        /// ����½���û����������Ƿ���ȷ
        /// </summary>
        /// <param name="user"></param>
        /// <returns>1:�û������������ 2:�û��Ѿ���½ 3:��½�ɹ�</returns>
        public int CheckUserNameAndPassword(User user)
        {
            //�ж��û����������Ƿ���ȷ
            user = userDao.CheckUserNameAndPassword(user);
            if (null == user)
            {
                return 1;
            }
            //�ж��Ƿ��Ѿ���½
            if (user.IsLogin == Constants.TRUE)
            {
                return 2;
            }
            //user.IsLogin = "Y";
            //if (CheckUserIsLogin(user))
            //{
            //    return 2;
            //}
            ThreadLocalUtils.CurrentSession.CurrentUser = user;
            UserContext userContext = new UserContext();
            userContext.CurrentUser = ThreadLocalUtils.CurrentSession.CurrentUser;
            ThreadLocalUtils.CurrentUserContext = userContext;

            user.IsLogin = Constants.TRUE;
            LogoutUser(user);
            return 3;
        }
        #endregion

        private bool CheckUserIsLogin(User user)
        {
            if (userDao.CheckUserIsLogin(user))
            {
                return false; //û�е�½

            }
            return true;//�Ѿ���½
        }
        public void LogoutUser(User user)
        {
            userDao.UpdateUserLoginStatus(user);
        }

        public int LogoutLoginUser(User user)
        {
            User u = userDao.CheckUserNameAndPassword(user);
            if (null == u)
            {
                return 1;//�û������������
            }
            if (u.IsLogin == Constants.TRUE)
            {
                u.IsLogin=Constants.FALSE;
                LogoutUser(u);

                return 3;//ע���ɹ�
            }
            return 2;//�û�δ��¼��
        }

        #region //�������� ��ȡ�����û�
        /// <summary>
        /// �������� ��ȡ�����û�
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��12��
        /// ��������:
        /// ������:
        /// </remarks>
		 public IList<User> GetAllUser(User user) 
		{
			return userDao.GetAllUsers(user);
        }
        #endregion

        public string GetEmployeeNameByUserId(User user)
        {
            return userDao.GetEmployeeNameByUserId(user);
        }

        #region //��ȡ��ɫ�б�
        /// <summary>
        /// ��ȡ��ɫ�б�
        /// </summary>
        /// <returns></returns>
        public IList<Role> GetRoleList() 
        {
            return roleService.GetRoleList();
        }
        #endregion


        #region //��ȡ���й�Ա��Ϣ
        /// <summary>
        /// ��ȡ���й�Ա��Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��8��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Employee> SelectAllEmployee() 
        {
            return employeeDao.GetEmployeeList();
        }
        #endregion 

      
        #region ��ȡ��ǰ����ʹ�õļ۸�����

        /// <summary>
        /// ��������: GetUsedPriceFactors
        /// ���ܸ�Ҫ: ��ȡ��ǰ����ʹ�õļ۸�����
        /// ��    ��: ����ط
        /// ����ʱ��: 2009-1-9
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        public IList<PriceFactor> GetUsedPriceFactors(long businessTypeId)
        {
            return priceFactorDao.SelectUsedPriceFactor(businessTypeId);
        }
   
        #endregion       

        public void ExitLogoutUser(User user) 
        {
            userDao.ExitLogoutUser(user); 
        }
    }
}
