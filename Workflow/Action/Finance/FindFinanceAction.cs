using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Workflow.Da;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Support.Log;
using Workflow.Action.Finance.Model;
using Workflow.Service.MemberCardManager;
using Workflow.Service.CustomerManager;
using Workflow.Service.SystemPermission.UserMangae;

/// <summary>
/// 名    称: FinanceAction
/// 功能概要: 财务查询Action
/// 作    者: 张晓林
/// 创建时间: 2009-01-23
/// 修正履历: 
/// 修正时间: 
/// </summary>
namespace Workflow.Action.Finance
{
    public class FindFinanceAction : BaseAction
	{
		#region Custom

		/// <summary>
		/// 自定义
		/// </summary>
		private Hashtable map;
		
		#endregion

		#region //Service

		private IFindFinanceService findFinanceService;
        public IFindFinanceService FindFinanceService
        {
            set { findFinanceService = value; }
        }

        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService 
        {
            set { masterDataService = value; }
        }

        private Service.OrderManage.IOrderService orderService;
        public Service.OrderManage.IOrderService OrderService 
        {
            set { orderService = value; }
        }

		private ISearchMemberCardService searchMemberCardService;
		/// <summary>
		/// 会员卡管理servie
		/// </summary>
		public ISearchMemberCardService SearchMemberCardService
		{
			set { searchMemberCardService = value; }
		}

		private ICustomerService customerService;
		/// <summary>
		/// 客户Service
		/// </summary>
		public ICustomerService CustomerService
		{
			set { customerService = value; }
		}

		private IUserService userService;
		public IUserService UserService
		{
			set { userService = value; }
		}
        #endregion

        #region Dao
        private IApplicationPropertyDao applicationPropertyDao;
        public IApplicationPropertyDao ApplicationPropertyDao
        {
            set { applicationPropertyDao = value; }
        }
        #endregion

        #region Model
        private FindFinanceModel model=new FindFinanceModel();
        public FindFinanceModel Model
        {
            set { model = value; }
            get { return model; }
        }
        private OrderModel orderModel = new OrderModel();
        public OrderModel OrderModel 
        {
            set { orderModel = value; }
            get { return orderModel; }
        }
        #endregion

        #region //根据查询条件获取帐龄订单信息
        /// <summary>
        /// 根据查询条件获取帐龄订单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void GetAnalyzeDebt()
        {
            model.OrderList=findFinanceService.GetAnalyzeDebt(model.Order);
            model.OList = findFinanceService.GetAnalyzeAssistantDebt(model.Order);
        }

        #endregion

        #region //获取某部门人员
        /// <summary>
        /// 获取某部门人员
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void GetCasherEmployeeList(long positionId)
        {
            model.EmployeeList=findFinanceService.GetCasherEmployeeList(positionId);

        }
        #endregion

        #region //应收款查询
        public void GetOperatorList()
        {
            model.OperatorList = findFinanceService.GetOperator();
        }

        /// <summary>
        /// 应收款查询(分页)
        /// </summary>
        public void GetCustomerArrearage()
        {
            model.OrderList = findFinanceService.GetCustomerArrearage(model.Order);
        }

        /// <summary>
        ///  获取应收款打印数据（打印）
        /// </summary>
        public void GetaAllCustomerArrearage()
        {
            model.OrderPrintList = findFinanceService.GetaAllCustomerArrearage(model.Order);
        }

        /// <summary>
        /// 获取应收款总记录数
        /// </summary>
        /// <returns></returns>
        public long GetSelectCustomerArrearageCount()
        {

            return findFinanceService.GetSelectCustomerArrearageCount(model.Order);
        }
        #endregion

        #region //月报
       
        /// <summary>
        /// 获取月报列表(orderList)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-9
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void SearchMonthPaperOrder_ToPrint() 
        {
            Hashtable hashCondition = new Hashtable();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            hashCondition.Add("BranchShopId", user.BranchShopId);
            hashCondition.Add("CompanyId", user.CompanyId);
            hashCondition.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);
            hashCondition.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//结算款
            hashCondition.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            hashCondition.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
            hashCondition.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//会员卡冲减
            hashCondition.Add("PreDeposits", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(结算)
            hashCondition.Add("PayTypeOrderDiff", Constants.PAY_KIND_ORDER_DIFF_VALUE);// 订单沖减
            hashCondition.Add("ConcessionTypeRoundPositiveValue", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//舍入多收
            hashCondition.Add("BeginHandOverDateTime", model.NewOrder.CurrentHandOverBeginDate);
            hashCondition.Add("EndHandOverDateTime", model.NewOrder.CurrentHandOverEndDate);
            model.OrderTempList= findFinanceService.GetMonthPaperPrint(hashCondition);
            hashCondition.Add("PayKind", Constants.BALANCE_SCOT_AMOUNT_KEY);//只统计结算产生的税费
            model.ScotAmount = findFinanceService.GetDailyScotAmount(hashCondition);//计算税费
        }
        #endregion

        #region //日报
        /// <summary>
        /// 名    称: SearDailyPaper
        /// 功能概要: 查询日报(分页)
        /// 作    者: 张晓林
        /// 创建时间: 2007-12-2
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void SearchDailyPaperOrder(int currentPageIndex)
        {
            Hashtable hashCondition = new Hashtable();
            hashCondition.Clear();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            hashCondition.Add("BranchShopId", user.BranchShopId);
            hashCondition.Add("CompanyId", user.CompanyId);
            hashCondition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            hashCondition.Add("PageCount", currentPageIndex);
            hashCondition.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//订单状态为:已经完成
            hashCondition.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//结算款
            hashCondition.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            hashCondition.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//会员卡冲减
            hashCondition.Add("PreDeposits", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(结算)
            hashCondition.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
            hashCondition.Add("PayTypeOrderDiff", Constants.PAY_KIND_ORDER_DIFF_VALUE);// 订单沖减
            hashCondition.Add("ConcessionTypeRoundPositiveValue", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//舍入多收
            hashCondition.Add("BeginHandOverDateTime", orderModel.NewOrder.CurrentHandOverBeginDate);
            hashCondition.Add("EndHandOverDateTime", orderModel.NewOrder.CurrentHandOverEndDate);

            AddMoney(findFinanceService.GetDailyPaperPrint(hashCondition));//合计当前查询的记账金额，发票金额，现金 
            OrderModel.OrderTempList = findFinanceService.GetDailyPaper(hashCondition);//分页显示数据
            orderModel.NeedPrePayOrdersCount = findFinanceService.GetDailyPaperTotal(hashCondition);//满足条件的记录数
            if (orderModel.IsAccounting) OrderModel.OrderList = findFinanceService.GetDailyPaperPrint(hashCondition);
            hashCondition.Add("PayKind", Constants.BALANCE_SCOT_AMOUNT_KEY);//只统计结算产生的税费
            orderModel.ScotAmount = findFinanceService.GetDailyScotAmount(hashCondition);//计算税费
        }

        private void AddMoney(IList<Order> orderList) 
        {
            foreach(Order o in orderList)
            {
                OrderModel.CashTotal += o.PaidAmount-o.RealPaidAmount;
                OrderModel.TicketTotal += o.NotPayTicketAmount;
                OrderModel.MemberCardAmountTotal += o.RealPaidAmount;
                OrderModel.OweTotal += o.AccountReceviableOweMomeyTotal;
            }
        }
        #endregion

        #region //计算当前月有多少天
        /// <summary>
        /// 当前月有多少天
        /// </summary>
        /// <param name="y">当前年份</param>
        /// <param name="m">当前月份</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月1日9:14:16
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public int HowMonthDay(int y, int m)
        {
            int mnext;
            int ynext;
            if (m < 12)
            {
                mnext = m + 1;
                ynext = y;
            }
            else
            {
                mnext = 1;
                ynext = y + 1;
            }
            DateTime dt1 = System.Convert.ToDateTime(y + "-" + m + "-1");
            DateTime dt2 = System.Convert.ToDateTime(ynext + "-" + mnext + "-1");
            TimeSpan diff = dt2 - dt1;
            return diff.Days;
        }
        #endregion

        #region //应收款按照时间段统计

        /// <summary>
        /// 名    称: SearchAccountReceivableAccordingToTime
        /// 功能概要: 按时间段统计和客户统计 应收款(分页)
        /// 作    者: 张晓林
        /// 创建时间: 2007-11-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="currentPageIndex">当前的页码</param>
        public void SearchAccountReceivableAccordingToTime(int currentPageIndex)
        {
            Hashtable hashtable = new Hashtable();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            hashtable.Add("BranchShopId", user.BranchShopId);
            hashtable.Add("CompanyId", user.CompanyId);
            hashtable.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//统计状态为 已经结算 的订单

            if (OrderModel.NewOrder.CustomerName != null && OrderModel.NewOrder.CustomerName != "")
            {
                hashtable.Add("CustomerName", "%" + OrderModel.NewOrder.CustomerName + "%");
            }

            if (OrderModel.NewOrder.BeginBalanceDate != null && OrderModel.NewOrder.BeginBalanceDate != "")
            {
                hashtable.Add("BeginBalanceDate", OrderModel.NewOrder.BeginBalanceDate);
            }
            if (OrderModel.NewOrder.EndBalanceDate != null && OrderModel.NewOrder.EndBalanceDate != "")
            {
                hashtable.Add("EndBalanceDate", OrderModel.NewOrder.EndBalanceDate);
            }
            hashtable.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            hashtable.Add("PagerCount", currentPageIndex);
            OrderModel.OrderTempList = findFinanceService.GetAccountReceviableAccordingToTimeSectTotal(hashtable);
        }

        ///<summary>
        /// 名    称: SearchAccountReceivableAccordingToTime
        /// 功能概要: 应收款按时间段统计的总记录数
        /// 作    者: 张晓林
        /// 创建时间: 2007-11-28
        /// 修正履历: 
        /// 修正时间: 
        /// <returns></returns>
        /// </summary>
        public long GetSearchAccountReceviableInfoCount()
        {
            Hashtable hashtable = new Hashtable();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            hashtable.Add("BranchShopId", user.BranchShopId);
            hashtable.Add("CompanyId", user.CompanyId);
            hashtable.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//统计状态为 已经结算 的订单

            //OrderModel.OrderTempList = findFinanceService.GetAccountReceviableAccordingToTimeSectTotal(hashtable);
            if (OrderModel.NewOrder.CustomerName != null && OrderModel.NewOrder.CustomerName != "")
            {
                hashtable.Add("CustomerName", "%" + OrderModel.NewOrder.CustomerName + "%");
            }

            if (OrderModel.NewOrder.BeginBalanceDate != null && OrderModel.NewOrder.BeginBalanceDate != "")
            {
                hashtable.Add("BeginBalanceDate", OrderModel.NewOrder.BeginBalanceDate);
            }
            if (OrderModel.NewOrder.EndBalanceDate != null && OrderModel.NewOrder.EndBalanceDate != "")
            {
                hashtable.Add("EndBalanceDate", OrderModel.NewOrder.EndBalanceDate);
            }
            return findFinanceService.GetSearchAccountReceviableInfoCount(hashtable);
        }

        /// <summary>
        /// 名    称: SearchAccountReceivableAccordingToTime
        /// 功能概要: 按时间段统计和客户统计 应收款(打印)
        /// 作    者: 张晓林
        /// 创建时间: 2007-11-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void SearchAllAccountReceviable()
        {
            Hashtable hashtable = new Hashtable();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            hashtable.Add("BranchShopId", user.BranchShopId);
            hashtable.Add("CompanyId", user.CompanyId);
            hashtable.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//统计状态为 已经结算 的订单

            if (OrderModel.NewOrder.CustomerName != null && OrderModel.NewOrder.CustomerName != "")
            {
                hashtable.Add("CustomerName", "%" + OrderModel.NewOrder.CustomerName + "%");
            }

            if (OrderModel.NewOrder.BeginBalanceDate != null && OrderModel.NewOrder.BeginBalanceDate != "")
            {
                hashtable.Add("BeginBalanceDate", OrderModel.NewOrder.BeginBalanceDate);
            }
            if (OrderModel.NewOrder.EndBalanceDate != null && OrderModel.NewOrder.EndBalanceDate != "")
            {
                hashtable.Add("EndBalanceDate", OrderModel.NewOrder.EndBalanceDate);
            }
            OrderModel.OrderList = findFinanceService.GetAllAccountReceiviable(hashtable);
        }
        #endregion

        #region //收银当班查询

        /// <summary>
        /// 按照收银人查询订单收款信息(分页)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public void SearchOrderInfoByCashPerson()
        {
            OrderModel.OrderTempList = findFinanceService.SearchOrderByCashPerson(orderModel.NewOrder);
            AddMoney(findFinanceService.SearchOrderByCashPersonPrint(orderModel.NewOrder));//分别合计满足条件的:现金；记账:发票金额

            //只统计结算产生的税费
            Hashtable condition = new Hashtable();
            condition.Add("PayKind", Constants.BALANCE_SCOT_AMOUNT_KEY);
            condition.Add("BranchShopId", Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("CompanyId", Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("HandOverUserId", orderModel.NewOrder.EmployeeArray);
            condition.Add("BeginHandOverDateTime",orderModel.NewOrder.InsertDateTimeString);
            condition.Add("EndHandOverDateTime", orderModel.NewOrder.BalanceDateTimeString);
            OrderModel.ScotAmount = findFinanceService.GetDailyScotAmount(condition);//计算税费
        }

        /// <summary>
        /// 按照收银人查询订单收款信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public long SearchOrderInfoByCashPersonRowCount()
        {
            return findFinanceService.SearchOrderByCashPersonRowCount(orderModel.NewOrder);
        }

        /// <summary>
        /// 按照收银人查询订单收款信息(打印)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public void SearchOrderInfoByCashPersonPrint()
        {
            OrderModel.OrderList = findFinanceService.SearchOrderByCashPersonPrint(orderModel.NewOrder);
        }

        ///// <summary>
        ///// 获取查询条件字符串
        ///// </summary>
        ///// <remarks>
        ///// 作    者: 张晓林
        ///// 创建时间: 2009年1月15日
        ///// 修正履历:
        ///// 修正时间:
        ///// </remarks>	
        //public string GetQueryConditionString()
        //{
        //    string startDate = DateTime.Now.ToString("yyyy-MM") + "-" + (DateTime.Now.Day - 1) + " " + applicationPropertyDao.GetValue(Constants.APPLICATION_START_TIME_KEY);
        //    string endDate = DateTime.Now.ToShortDateString() + " " + applicationPropertyDao.GetValue(Constants.APPLICATION_END_TIME_KEY);
        //    string queryConditionString = " 开始日期：" + startDate;
        //    queryConditionString += " 截至日期:" + endDate;
        //    return queryConditionString;
        //}
        #endregion

        #region //预付款查询
		/// <summary>
		/// 查询客户预付款情况
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-10-26
		/// 修正履历: 陈汝胤
		/// 修正时间: 2010-01-13
		/// </remarks>
		public void GetCustomerPrepay()
		{
			model.RecordCount = findFinanceService.GetCustomerPrepayRowsCount(model.Order);

			model.OrderList = findFinanceService.GetCustomerPrepay(model.Order);
		}

		public void GetPrintPrepay()
		{
			model.Order.BeginRow = 1;
			model.Order.EndRow = model.RecordCount;
			model.PrintOrderList = findFinanceService.GetCustomerPrepay(model.Order);
		}

        /// <summary>
        /// 按照条件获取 预付款信息(打印)
        /// </summary>
        public void GetCustomerPrepayPrint()
        {
            if (null != model.Order.No && "" != model.Order.No)
            {
                model.Order.No = "%" + model.Order.No + "%";
            }

            if (null != model.Order.CustomerName && "" != model.Order.CustomerName)
            {
                model.Order.CustomerName = "%" + model.Order.CustomerName + "%";
            }
            model.OrderTempList = findFinanceService.GetCustomerPrepayPrint(model.Order);
        }
        #endregion

        #region //波动客户查询
        /// <summary>
        /// 功能概要：波动客户查询
        /// 作    者：
        /// 修正履历:
        /// 修正日期:
        /// </summary>
        public void GetExceptionConsumeCustomer()
        {
            model.OrderList = findFinanceService.GetExceptionConsumeCustomer(model.Order);
            model.EmployeeId = findFinanceService.GetExceptionConsumeCustomerRowCount(model.Order);
            if (model.IsPrint) model.OrderTempList = findFinanceService.GetExceptionConsumeCustomerPrint(model.Order);
        }
       
        #endregion

        #region //无消费客户查询 
        public void GetAllMasterDate()
        {
            model.MemberCardLevelList = masterDataService.GetMemberCardLevels();
            model.CustomerLevelList = masterDataService.GetCustomerLevel();
            model.CustomerTypeList = masterDataService.GetCustomerTypes();
        }
        /// <summary>
        /// 名    称: SelectWithoutConsumeCustomer
        /// 功能概要: 查询没有消费的客户
        /// 作    者: 付强
        /// 创建时间: 2007-10-31
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public void GetWithoutConsumeCustomer(Hashtable customer)
        {

            model.CustomerList = findFinanceService.GetWithoutConsumeCustomer(customer);
            model.EmployeeId = findFinanceService.GetWithoutConsumeCustomerRowCount(customer);
            if (model.IsPrint) model.CustomerPrintList = findFinanceService.GetWithoutConsumeCustomerRowPrint(customer);
        }
        #endregion

		#region 客户消费统计
		/// <summary>
		/// 获取某段时间内所有客户的消费情况
		/// </summary>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-10-24
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public void GetCustomerConsume()
		{
			model.RecordCount = findFinanceService.GetCustomerConsumeCount(model.Order);
			model.OrderList = findFinanceService.GetCustomerConsume(model.Order);
			model.Order = findFinanceService.GetCustomerConsumeAmount(model.Order);
		}
		#endregion

		#region 客户消费统计

		public void PrintCustomerConsume()
		{
			model.Order.BeginRow = 1;
			model.Order.EndRow = model.RecordCount;
			model.PrintOrderList = findFinanceService.GetCustomerConsume(model.Order);
		}
		#endregion

        #region 新老客户消费统计

		/// <summary>
		/// 新老客户消费统计
		/// </summary>
        public void GetNewAndOldCustomerConsumeCount()
        {
			map = new Hashtable();
			map.Add("status", Constants.ORDER_STATUS_SUCCESSED_VALUE);
			map.Add("beginDate",model.BalanceDateTimeString);
			map.Add("endDate", model.InsertDateTimeString);
			map.Add("operator1", GetOperatorValue(model.Operator1));
			map.Add("amount1", model.Amount1);
			map.Add("operator2", GetOperatorValue(model.Operator2));
			map.Add("amount2", model.Amount2);

            model.OrderList = findFinanceService.GetNewAndOldCustomerConsumeCount(map);
        }
        #endregion

        #region //客户付款明细
        /// <summary>
        /// 查找某个客户某段时间内的付款明细
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-25
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void GetCustomerPayment()
        {

			model.Order.PayKind = Constants.PAY_KIND_INVALIDATE_VALUE;
			model.Order.Status = Constants.ORDER_STATUS_BLANKOUT_VALUE;
            model.Order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            model.Order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
			model.RecordCount = findFinanceService.GetCustomerPaymentCount(model.Order);
			model.GatheringList = findFinanceService.GetCustomerPayment(model.Order);
			model.SunAmount = findFinanceService.GetCustomerPaymentAmount(model.Order);
        }
        #endregion

		#region 客户付款明细报表

		public void PrintCustomerPayment()
		{
			model.Order.BeginRow = 1;
			model.Order.EndRow = model.RecordCount;
            model.Order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            model.Order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
			model.PrintGatheringList = findFinanceService.GetCustomerPayment(model.Order);
		}

		#endregion

        #region //订单查询(财务查询)

        #region 业务类型
        /// <summary>
        /// 业务类型
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-25
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void GetBusinessType()
        {
            model.BusinessTypeList = masterDataService.GetBusinessTypes();
        }
        #endregion

        public void SearchOrdersItem()
        {
			System.Collections.Hashtable condition = new System.Collections.Hashtable();

			if (model.BusinessTypeId != "0")
			{
				condition.Add("BusinessTypeId", model.BusinessTypeId);
			}
			if (!String.IsNullOrEmpty(model.Amount))
			{
				condition.Add("Amount", model.Amount);
				if (model.AmountCondtition == Workflow.Support.Constants.QUERY_CONDITION_EQUAL_KEY)
				{
					model.AmountCondtition = Workflow.Support.Constants.QUERY_CONDITION_EQUAL_VALUE;
				}
				else if (model.AmountCondtition == Workflow.Support.Constants.QUERY_CONDITION_GREATER_EQUAL_KEY)
				{
					model.AmountCondtition = Workflow.Support.Constants.QUERY_CONDITION_GREATER_EQUAL_VALUE;
				}
				else if (model.AmountCondtition == Workflow.Support.Constants.QUERY_CONDITION_GREATER_KEY)
				{
					model.AmountCondtition = Workflow.Support.Constants.QUERY_CONDITION_GREATER_VALUE;
				}
				else if (model.AmountCondtition == Workflow.Support.Constants.QUERY_CONDITION_LESS_EQUAL_KEY)
				{
					model.AmountCondtition = Workflow.Support.Constants.QUERY_CONDITION_LESS_EQUAL_VALUE;
				}
				else if (model.AmountCondtition == Workflow.Support.Constants.QUERY_CONDITION_LESS_KEY)
				{
					model.AmountCondtition = Workflow.Support.Constants.QUERY_CONDITION_LESS_VALUE;
				}
				condition.Add("AmountCondition", model.AmountCondtition);
			}

			if (!String.IsNullOrEmpty(model.Price))
			{
				condition.Add("Price", model.Price);
				if (model.PriceCondition == Workflow.Support.Constants.QUERY_CONDITION_EQUAL_KEY)
				{
					model.PriceCondition = Workflow.Support.Constants.QUERY_CONDITION_EQUAL_VALUE;
				}
				else if (model.PriceCondition == Workflow.Support.Constants.QUERY_CONDITION_GREATER_EQUAL_KEY)
				{
					model.PriceCondition = Workflow.Support.Constants.QUERY_CONDITION_GREATER_EQUAL_VALUE;
				}
				else if (model.PriceCondition == Workflow.Support.Constants.QUERY_CONDITION_GREATER_KEY)
				{
					model.PriceCondition = Workflow.Support.Constants.QUERY_CONDITION_GREATER_VALUE;
				}
				else if (model.PriceCondition == Workflow.Support.Constants.QUERY_CONDITION_LESS_EQUAL_KEY)
				{
					model.PriceCondition = Workflow.Support.Constants.QUERY_CONDITION_LESS_EQUAL_VALUE;
				}
				else if (model.PriceCondition == Workflow.Support.Constants.QUERY_CONDITION_LESS_KEY)
				{
					model.PriceCondition = Workflow.Support.Constants.QUERY_CONDITION_LESS_VALUE;
				}
				condition.Add("PriceCondition", model.PriceCondition);
			}
			if (!String.IsNullOrEmpty(model.BeginDate))
				condition.Add("BeginDate", model.BeginDate);
			if (!String.IsNullOrEmpty(model.EndDate))
				condition.Add("EndDate", model.EndDate);

			//订单状态
			condition.Add("Status", Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE);
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			condition.Add("branchShopId", user.BranchShopId);
			condition.Add("companyId", user.CompanyId);
			if (model.IsPrint)
			{
				condition.Add("beginRow", 1);
				condition.Add("endRow", model.RecordCount);
				model.PrintOrderList = orderService.SearchOrdersItem(condition);
			}
			else
			{
				condition.Add("beginRow", model.BeginRow);
				condition.Add("endRow", model.EndRow);
				model.RecordCount = orderService.SearchOrdersItemCount(condition);
				model.OrderList = orderService.SearchOrdersItem(condition);
				model.Order = orderService.SearchOrdersItemAmount(condition);
			}	
        }
        #endregion

        #region //异常消费会员查询
        /// <summary>
        /// 异常消费会员查询
        /// </summary>
        /// <remarks>
        /// 作    者：
        /// 修正履历: 张晓林 增加分页功能
        /// 修正时间: 2009年12月21日9:31:36
        /// </remarks>
        public void GetExceptionConsumeMemberCount()
        {
            model.OrderList = findFinanceService.GetExceptionMemberCustomerConsume(model.Order);
            model.EmployeeId = findFinanceService.GetExceptionMemberCustomerConsumeRowCount(model.Order);
            if (model.IsPrint) model.OrderTempList = findFinanceService.GetExceptionMemberCustomerConsumePrint(model.Order);
        }
        #endregion

		#region 客户对账表

		/// <summary>
		/// 客户对账表
		/// </summary>
		/// <remarks>
		/// 时    间: 2010-01-15
		/// 作    者: 陈汝胤 
		/// </remarks>
		public void GetCustomerHistory()
		{
			model.Customer = findFinanceService.GetCustomer(model.MemberCardNo, model.CustomerName);
			model.RecordCount = findFinanceService.GetCustomerOrdersHistoryCount(model.MemberCardNo, model.CustomerName);
			model.OrderList = findFinanceService.GetCustomerOrdersHistory(model.MemberCardNo, model.CustomerName, model.BeginRow, model.EndRow);
			Model.Order = findFinanceService.GetCustomerOrderHistoryTotalize(model.MemberCardNo, model.CustomerName);
		}

		public void GetPrintCustomerHistory()
		{
			model.PrintOrderList = findFinanceService.GetCustomerOrdersHistory(model.MemberCardNo, model.CustomerName, 1, model.RecordCount);
		}

		#endregion

        #region 异常价格加订单汇总
		/// <summary>
		/// 异常价格加订单汇总
		/// </summary>
		/// <remarks>
		/// 时    间: 2010-01-19
		/// 作    者: 陈汝胤 
		/// </remarks>
        public void GetExceptionPriceOrdersCount()
        {
			map = new Hashtable();
			if (!string.IsNullOrEmpty(model.BalanceDateTimeString))
				map.Add("beginDate", model.BalanceDateTimeString);
			if (!string.IsNullOrEmpty(model.InsertDateTimeString))
				map.Add("endDate", model.InsertDateTimeString);
			if (!string.IsNullOrEmpty(model.CustomerName))
				map.Add("customerName", model.CustomerName);
			map.Add("operator1", GetOperatorValue(model.Operator1));
			map.Add("amount1", model.Amount1);
			map.Add("operator2", GetOperatorValue(model.Operator2));
			map.Add("amount2", model.Amount2);
			map.Add("operator3", GetOperatorValue(model.Operator3));
			map.Add("amount3", model.Amount3);

			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("branchShopId", user.BranchShopId);
			map.Add("companyId", user.CompanyId);

			map.Add("orderStatus", Constants.ORDER_STATUS_SUCCESSED_VALUE);
			map.Add("payKind1", Constants.PAY_KIND_PREPAY_VALUE);
			map.Add("payKind2", Constants.PAY_KIND_RETURN_VALUE);
			map.Add("payKind3", Constants.PAY_KIND_INVALIDATE_VALUE);
			map.Add("concessionType1", Constants.CONCESSION_TYPE_ZERO_VALUE);
			map.Add("concessionType2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);
			map.Add("concessionType3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);
			map.Add("concessionType4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
			map.Add("concessionType5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);
			model.RecordCount = findFinanceService.GetExceptionPriceOrdesCount(map);
			map.Add("beginRow", model.BeginRow);
			map.Add("endRow", model.EndRow);
			model.OrderList = findFinanceService.GetExceptionPriceOrdes(map);
			model.Order = findFinanceService.GetExceptionPriceOrdesTotalize(map);
        }

		/// <summary>
		/// 异常价格加订单汇总(打印)
		/// </summary>
		public void PrintExceptionPriceOrders()
		{
			if (map != null && map["beginRow"] != null && map["endRow"] != null)
			{
				map["beginRow"] = 1;
				map["endRow"] = model.RecordCount;
				model.PrintOrderList = findFinanceService.GetExceptionPriceOrdes(map);
			}
		}

        #endregion

		#region 通过操作描述获取操作的值

		/// <summary>
		/// 通过操作描述获取操作的值
		/// </summary>
		/// <param name="label"></param>
		/// <returns></returns>
		private string GetOperatorValue(string label)
		{
			string value=Constants.QUERY_CONDITION_GREATER_EQUAL_VALUE;
			switch (label)
			{ 
				case  Constants.QUERY_CONDITION_LESS_TEXT :
					value = Constants.QUERY_CONDITION_LESS_VALUE;
					break;
				case Constants.QUERY_CONDITION_LESS_EQUAL_TEXT :
					value= Constants.QUERY_CONDITION_LESS_EQUAL_VALUE;
					break;
				case Constants.QUERY_CONDITION_EQUAL_TEXT :
					value=Constants.QUERY_CONDITION_EQUAL_VALUE;
					break;
				case Constants.QUERY_CONDITION_GREATER_EQUAL_TEXT :
					value = Constants.QUERY_CONDITION_GREATER_EQUAL_VALUE;
					break;
				case Constants.QUERY_CONDITION_GREATER_TEXT:
					value = Constants.QUERY_CONDITION_GREATER_VALUE;
					break;
			}
			return value;
		}

		#endregion

		#region //门店营业额查询
		public void SelectBranShopTurnover()
        {
            model.OrderList = findFinanceService.GetBranchShopTurnover(model.Order);
        }
        #endregion

        #region//优惠查询

        /// <summary>
        /// 名    称: SearchConcession
        /// 功能概要: 查询优惠
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日14:36:50
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void SearchConcession() 
        {
            model.GatheringList = findFinanceService.SearchConcession(model.PaymentConcession);
            model.Operator1 = Convert.ToString(findFinanceService.SearchConcessionRowCount(model.PaymentConcession));
            model.GatheringPrintList = findFinanceService.SearchConcessionPrint(model.PaymentConcession);
            AddConcessionMoney(model.GatheringList);
            ////获取订单信息
            //this.GetConcessionOrderInfo(model.GatheringList);
            //this.GetConcessionOrderInfo(model.GatheringPrintList);
        }
        ///// <summary>
        ///// 获取订单信息
        ///// </summary>
        ///// <param name="paymentConcessionList"></param>
        //private void GetConcessionOrderInfo(IList<Gathering> gatheringList)
        //{
        //    MemberCard memberCard = null;
        //    Customer customer = null;

        //    foreach (Gathering p in gatheringList)
        //    {
        //        p.Order = orderService.GetOrderInfoByOrderNo(p.OrderNo);
        //    }
        //}
        private void AddConcessionMoney(IList<Gathering> gatheringingList)
        {
            foreach (Gathering p in gatheringingList)
            {
                model.Amount1 += p.ConcessionAmountTotal;
                model.Amount2 += p.MoreConcessionAmountTotal;
            }
        }
        #endregion

        #region//按照人员统计开单量
        /// <summary>
        /// 名    称: SearchOrderCount
        /// 功能概要: 按照人员统计开单量
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日10:43:07
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void SearchOrderCount() 
        {
            model.OtherEmployeeList = findFinanceService.SearchOrderCount(model.Employee);
            model.Operator1 = findFinanceService.SearchOrderCountRowCount(model.Employee).ToString();
            model.PrintEmployeeList = findFinanceService.SearchOrderCountPrint(model.Employee);
        }

        /// <summary>
        /// 名    称: SearchOrderCountDetail
        /// 功能概要: 按照人员统计开单量明细
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月5日10:18:03
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void SearchOrderCountDetail() 
        {
            model.EmployeeList = findFinanceService.SearchOrderCountDetail(model.Order);
            model.EmployeeId = findFinanceService.SearchOrderCountDetailRowCount(model.Order);
        }

        /// <summary>
        /// 名    称: SearchPositionOrEmployee
        /// 功能概要: 获取指定的部门与人员
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月13日10:32:27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void SearchPositionOrEmployee() 
        {
            model.Employee = new Workflow.Da.Domain.Employee();
            long branchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            model.Employee.PositionName = Constants.POSITION_PROPHASE_VALUE(branchShopId).ToString();//前期
            model.Employee.PositionIdString = Constants.POSITION_ANAPHASE_VALUE(branchShopId).ToString();//后加工
            model.PositionList = findFinanceService.SearchPositionByCondition(model.Employee);
            model.Employee.PositionIdString = null;
            model.EmployeeList= findFinanceService.SearchEmployeeByPosition(model.Employee);
        }

        /// <summary>
        /// 名    称: SearchPositionByEmployeeId
        /// 功能概要: 根据雇员Id获取岗位
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月16日11:07:37
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public long SearchPositionByEmployeeId(long employeeId) 
        {
            model.Employee = new Workflow.Da.Domain.Employee();
            model.Employee.Id = employeeId;
            return findFinanceService.SearchPositionByEmployeeId(model.Employee).Id;
        }
        #endregion

        #region//应收款记录
        /// <summary>
        /// 获取应收款记录列表
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月21日15:42:10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void SearchAccountRecord() 
        {
            Order order = new Order();
            order.PayType = Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE;//记账
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;//已完成
            order.Status1 = Convert.ToInt32(Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
            order.Status2 = Convert.ToInt32(Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//应收款处理：预存款冲减

            order.Status3 = Constants.ACCOUNT_SCOT_AMOUNT_KEY;//应收款税费
            order.Operator2 = Constants.BALANCE_PRE_POSITION_AMOUNT_KEY.ToString();//结算预存款
            order.CustomerTypeName = Constants.ACCOUNT_PRE_POSITION_AMOUNT_KEY.ToString();//应收款处理预存款
            order.CashName = Constants.ACCOUNT_PRE_POSITION_AMOUNT_DIFF_KEY.ToString();//应收款处理 预存款冲减
            if (null != model.MemberCardNo && "" != model.MemberCardNo) order.MemberCardNo = model.MemberCardNo;
            if (null!=model.CustomerName && "" != model.CustomerName) order.CustomerName = model.CustomerName;
            if (null != model.InsertDateTimeString && "" != model.InsertDateTimeString) order.InsertDateTimeString = model.InsertDateTimeString;
            if (null != model.BalanceDateTimeString && "" != model.BalanceDateTimeString) order.BalanceDateTimeString= model.BalanceDateTimeString;
            order.CurrentPageIndex = Convert.ToInt32(model.Operator1) - 1;
            order.BusinessTypeId = Convert.ToInt32(model.Operator2);
            model.OtherGathingAndRefundMentRecordList = findFinanceService.SearchAccountRecord(order);
            model.BusinessTypeId = findFinanceService.SearchAccountRecordRowCount(order).ToString();
            if(model.IsPrint) model.OtherGathingAndRefundMentRecordPrintList = findFinanceService.SearchAccountRecordPrint(order);
        }
        #endregion

        #region//补领发票记录
        /// <summary>
        /// 功能概要: 补领发票记录
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月30日9:50:18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void SearchDrawTicketRecord() 
        {
            model.OtherGathingAndRefundMentRecordList=findFinanceService.SearchDrawTicketRecord(model.OtherGathingAndRefundMentRecord);
            model.Operator1=Convert.ToString(findFinanceService.SearchDrawTicketRecordRowCount(model.OtherGathingAndRefundMentRecord));
            if (model.IsPrint) model.OtherGathingAndRefundMentRecordPrintList = findFinanceService.SearchDrawTicketRecordPrint(model.OtherGathingAndRefundMentRecord);
        }
        #endregion

		#region 获取用户的所有订单

		public void GetCustomerOrders()
		{
			model.RecordCount = findFinanceService.GetCustomerOrderCount(model.CustomerId);
			model.OrderList = findFinanceService.GetCustomerOrders(model.CustomerId,model.BeginRow,model.EndRow);
		}

		#endregion

		#region 按操作人统计优惠信息
		/// <summary>
		/// 名    称: SelectPayConcessionListByUserId
		/// 功能概要: 按操作人统计优惠信息
		/// 作    者: 
		/// 创建时间: 
		/// 修 正 人: 白晓宇
		/// 修正时间: 2010-05-17
		/// 描    述: 
		/// </summary>
		/// <param name="paymentConcession"></param>
		/// <returns></returns>
		public void GetPayConcessionListByUserId()
		{
			//获取操作人员
			IList<User> userList = userService.GetUserListByEmployeeName(model.Operator1);
			if (userList != null && userList.Count > 0)
			{
				model.PaymentConcession.OperateUserIdList = new List<long>();
				foreach (User item in userList)
				{
					model.PaymentConcession.OperateUserIdList.Add(item.Id);
				}
			}

			model.PaymentConcessionList = findFinanceService.GetPayConcessionListByUserId(model.PaymentConcession);

			Workflow.Da.Domain.User domain = null;

			//获取操作用户
			foreach (Workflow.Da.Domain.PaymentConcession item in model.PaymentConcessionList)
			{
				domain = userService.GetUserById(item.OperateUsersId);
				item.OperateUsers = domain;
			}
		}
		#endregion

		#region 按操作人统计优惠信息(统计记录数)
		/// <summary>
		/// 名    称: SelectPayConcessionCountByUserId
		/// 功能概要: 按操作人统计优惠信息(统计记录数)
		/// 作    者: 
		/// 创建时间: 
		/// 修 正 人: 白晓宇
		/// 修正时间: 2010-05-17
		/// 描    述: 
		/// </summary>
		/// <param name="paymentConcession"></param>
		/// <returns></returns>
		public void GetPayConcessionCountByUserId()
		{
			model.RecordCount = findFinanceService.GetPayConcessionCountByUserId(model.PaymentConcession);
		}
		#endregion
	}
}
