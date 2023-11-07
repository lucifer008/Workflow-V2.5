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

        #region 注入Dao

		/// <summary>
		/// 工单
		/// </summary>
		private IOrderDao orderDao;
		public IOrderDao OrderDao 
		{
			set { orderDao = value; }
		}

		/// <summary>
		///岗位 
		/// </summary>
		private IEmployeePositionDao employeePositionDao;
		public IEmployeePositionDao EmployeePositionDao 
		{
			set { employeePositionDao = value; }
		}

        /// <summary>
        /// 人员
        /// </summary>
        private IEmployeeDao employeeDao;
        public IEmployeeDao EmployeeDao
        {
            set { employeeDao = value; }
        }

        /// <summary>
        /// 工单
        /// </summary>
        private IOrderItemDao orderItemDao;
        public IOrderItemDao OrderItemDao
        {
            set { orderItemDao = value; }
        }

        /// <summary>
        /// 客户类型
        /// </summary>
        private ICustomerTypeDao customerTypeDao;
        public ICustomerTypeDao CustomerTypeDao
        {
            set { customerTypeDao = value; }
        }

        /// <summary>
        /// 业务类型
        /// </summary>
        private IBusinessTypeDao businessTypeDao;
        public IBusinessTypeDao BusinessTypeDao
        {
            set { businessTypeDao = value; }
        }

        /// <summary>
        /// 客户等级
        /// </summary>
        private ICustomerLevelDao customerLevelDao;
        public ICustomerLevelDao CustomerLevelDao
        {
            set { customerLevelDao = value; }
        }

        /// <summary>
        /// 子行业
        /// </summary>
        private IMasterTradeDao masterTradeDao;
        public IMasterTradeDao MasterTradeDao
        {
            set { masterTradeDao = value; }
        }

        /// <summary>
        /// 子行业
        /// </summary>
        private ISecondaryTradeDao secondaryTradeDao;
        public ISecondaryTradeDao SecondaryTradeDao
        {
            set { secondaryTradeDao = value; }
        }

        /// <summary>
        /// 印制要求
        /// </summary>
        private IPrintDemandDao printDemandDao;
        public IPrintDemandDao PrintDemandDao
        {
            set { printDemandDao = value; }
        }

        /// <summary>
        /// 价格因素
        /// </summary>
        private IPriceFactorDao priceFactorDao;
        public IPriceFactorDao PriceFactorDao
        {
            set { priceFactorDao = value; }
        }

        /// <summary>
        /// 因素值
        /// </summary>
        private IFactorValueDao factorValueDao;
        public IFactorValueDao FactorValueDao
        {
            set { factorValueDao = value; }
        }

        /// <summary>
        /// 卡等级
        /// </summary>
        private IMemberCardLevelDao memberCardLevelDao;
        public IMemberCardLevelDao MemberCardLevelDao
        {
            set { memberCardLevelDao = value; }
        }

        private IReportLessModeDao reportLessModeDao;
        /// <summary>
        /// 挂失方式
        /// </summary>
        public IReportLessModeDao ReportLessModeDao
        {
            set { reportLessModeDao = value; }
        }

        /// <summary>
        /// 营销活动
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
        /// 职位(部门)
        /// </summary>
        private IPositionDao positionDao;
        public IPositionDao PositionDao
        {
            set { positionDao = value; }
        }

        /// <summary>
        /// 机器
        /// </summary>
        /// <returns></returns>
        private IMachineDao machineDao;
        public IMachineDao MachineDao
        {
            set { machineDao = value; }
        }
        
        /// <summary>
        /// 获得纸质一览
        /// </summary>
        /// <returns></returns>
        private IPaperTypeDao paperTypeDao;
        public IPaperTypeDao PaperTypeDao
        {
            set { paperTypeDao = value; }
        }
        /// <summary>
        /// 获得纸型一览
        /// </summary>
        /// <returns></returns>
        private IPaperSpecificationDao paperSpecificationDao;
        public IPaperSpecificationDao PaperSpecificationDao
        {
            set { paperSpecificationDao = value; }
        }

		/// <summary>
		/// 用户Dao
		/// </summary>
		private IUserDao userDao;
		public IUserDao UserDao
		{
			set { userDao = value; }
		}

		/// <summary>
		///用户角色Dao
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

        #region //营销活动的基本数据
        ///<summary>
        ///营销活动的基本数据
        ///</summary>
        ///<returns></returns>
        public IList<Campaign> GetCampaign()
        {
            return campaignDao.SelectAll();
        }
        #endregion

        #region //挂失方式的基本数据
        ///<summary>
        ///挂失方式的基本数据
        ///</summary>
        ///<returns></returns>
        public IList<ReportLessMode> GetReportLessMode()
        {
            return reportLessModeDao.SelectAll();
        }
        #endregion

        #region //业务类型的基本数据
        ///<summary>
        ///业务类型的基本数据
        ///</summary>
        ///<returns></returns>
        public IList<BusinessType> GetBusinessTypes()
        {
            return businessTypeDao.SelectAll();
        }
        #endregion

        #region //客户级别的基本数据
        ///<summary>
        ///客户级别的基本数据
        ///</summary>
        ///<returns></returns>
        public IList<CustomerLevel> GetCustomerLevel()
        {
            return customerLevelDao.SelectAll();
        }
        #endregion

        #region //客户类型的基本数据
        ///<summary>
        ///客户类型的基本数据
        ///</summary>
        ///<returns></returns>
        public IList<CustomerType> getCustomerType()
        {
            return customerTypeDao.SelectAll();
        }
        #endregion

        #region //行业信息的基本数据
        ///<summary>
        ///行业信息的基本数据
        ///</summary>
        ///<returns></returns>
        public IList<MasterTrade> GetMasterTrade()
        {
            return masterTradeDao.SelectAll();
        }
        #endregion

        #region //行业详细的基本数据
        ///<summary>
        ///行业详细的基本数据
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

        #region //获取价格因素
        /// <summary>
        /// 获取价格因素
        /// </summary>
        /// <returns></returns>
        public IList<PriceFactor> GetPriceFactors()
        {
            return priceFactorDao.SelectAll();
        }
        #endregion

        #region //获取所有雇员列表
        public IList<Employee> GetEmployeeList()
        {
            return employeeDao.GetEmployeeList();
        }
        #endregion

        public IList<OrderItem> GetOrderItemIDByOrderNo(string strOrderNo)
        {
            return orderItemDao.GetOrderItemByOrderNo(strOrderNo);
        }

        #region //获取因素值List
        /// <summary>
        /// 获取因素值List
        /// </summary>
        /// <returns></returns>
        //////////
        public string GetFactorValueText(PriceFactor priceFactor)
        {
            #region 暂时保留
            //string str;
            //List<string> lst = new List<string>();
            //for (int i = 0; i < baseBusinessTypePriceSet.Count; i++)
            //{
            //    if (baseBusinessTypePriceSet.Item(i) == 0)
            //        break;
            //    //因素ID为空,说明是固定因素,需要从固定表中取得Value
            //    if (priceFactor.PriceFactorId == 0)
            //    {
            //        //从固定的TargetTable中取得
            //        str = factorValueDao.GetFactorValueByFactorValueId(priceFactor, false);
            //    }
            //    else
            //    {
            //        //从公共的FactorValue中取得
            //        str = factorValueDao.GetFactorValueByFactorValueId(priceFactor, true);
            //    }
            //    lst.Add(str);
            //}
            //return lst;
            #endregion

            //因素值置为-1说明该业务类型下没有该因素的设置,直接返回"-"
            if (priceFactor.PriceValueId == -1)
            {
                return "-";
            }
            //因素ID为空,说明是固定因素,需要从固定表中取得Value
            if (priceFactor.PriceFactorId == 0)
            {
                //从固定的TargetTable中取得
                return factorValueDao.GetFactorValueByFactorValueId(priceFactor, false);
            }
            else
            {
                //从公共的FactorValue中取得
                return  factorValueDao.GetFactorValueByFactorValueId(priceFactor, true);
            }
        }
        #endregion 

        #region //获取卡级别一览
        /// <summary>
        /// 获取卡级别一览
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

        #region //获得职位一览
        /// <summary>
        /// 获得职位一览
        /// </summary>
        /// <returns></returns>
        public IList<Position> GetPositionList()
        {
            return positionDao.SelectAll();
        }
        #endregion

        #region //获得机器一览
        /// <summary>
        /// 获得机器一览
        /// </summary>
        /// <returns></returns>
        public IList<Machine> GetMachineList()
        {
            return machineDao.SelectAll();
        }
        #endregion

        #region //获得纸质一览
        /// <summary>
        /// 获得纸质一览
        /// </summary>
        /// <returns></returns>
        public IList<PaperType> GetPaperTypeList()
        {
            return paperTypeDao.SelectAll();
        }
        #endregion

        #region //获得纸型一览
        /// <summary>
        /// 获得纸型一览
        /// </summary>
        /// <returns></returns>
        public IList<PaperSpecification> GetPaperSpecificationList()
        {
            return paperSpecificationDao.SelectAll();
        }
        #endregion

        #region //根据公司ID获取其下所有子公司
        /// <summary>
        /// 根据公司ID获取其下所有子公司
        /// </summary>
        /// <param name="companyId"></param>
        public IList<BranchShop> GetAllBranchShopInfo(long companyId)
        {
            return branchShopDao.GetBranchShopListByCompanyId(companyId);
        }
        #endregion 

        #region //检查登陆的用户名或密码是否正确
        /// <summary>
        /// 检查登陆的用户名或密码是否正确
        /// </summary>
        /// <param name="user"></param>
        /// <returns>1:用户名或密码错误 2:用户已经登陆 3:登陆成功</returns>
        public int CheckUserNameAndPassword(User user)
        {
            //判断用户名或密码是否正确
            user = userDao.CheckUserNameAndPassword(user);
            if (null == user)
            {
                return 1;
            }
            //判断是否已经登陆
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
                return false; //没有登陆

            }
            return true;//已经登陆
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
                return 1;//用户名或密码错误
            }
            if (u.IsLogin == Constants.TRUE)
            {
                u.IsLogin=Constants.FALSE;
                LogoutUser(u);

                return 3;//注销成功
            }
            return 2;//用户未登录；
        }

        #region //按照条件 获取所有用户
        /// <summary>
        /// 按照条件 获取所有用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月12日
        /// 修正履历:
        /// 修正人:
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

        #region //获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public IList<Role> GetRoleList() 
        {
            return roleService.GetRoleList();
        }
        #endregion


        #region //获取所有雇员信息
        /// <summary>
        /// 获取所有雇员信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月8日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Employee> SelectAllEmployee() 
        {
            return employeeDao.GetEmployeeList();
        }
        #endregion 

      
        #region 获取当前正在使用的价格因素

        /// <summary>
        /// 方法名称: GetUsedPriceFactors
        /// 功能概要: 获取当前正在使用的价格因素
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-9
        /// 修正履历: 
        /// 修正时间: 
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
