using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using Workflow.Da;
using Workflow.Support;
using Workflow.Da.Domain;

namespace Workflow.Service.Impl
{
    public class FindFinanceServiceImpl : IFindFinanceService
    {
        #region Dao
        private IOrderDao orderDao;
        public IOrderDao OrderDao
        {
            set { orderDao = value; }
        }
        private IEmployeeDao employeeDao;
        public IEmployeeDao EmployeeDao
        {
            set { employeeDao = value; }
        }
        private IGatheringDao gatheringDao;
        public IGatheringDao GatheringDao
        {
            set { gatheringDao = value; }
        }
        private ICustomerDao customerDao;
        public ICustomerDao CustomerDao
        {
            set { customerDao = value; }
        }
        private IOrderItemDao orderItemDao;
        public IOrderItemDao OrderItemDao
        {
            set { orderItemDao = value; }
        }
        private IApplicationPropertyDao applicationPropertyDao;
        public IApplicationPropertyDao ApplicationPropertyDao
        {
            set { applicationPropertyDao = value; }
        }

        private IPaymentConcessionDao paymentConcessionDao;
        public IPaymentConcessionDao PaymentConcessionDao 
        {
            set { paymentConcessionDao = value; }
        }

        private IOtherGatheringAndRefundmentRecordDao otherGatheringAndRefundmentRecordDao;
        public IOtherGatheringAndRefundmentRecordDao OtherGatheringAndRefundmentRecordDao 
        {
            set { otherGatheringAndRefundmentRecordDao = value; }
        }

        private IPriceFactorDao priceFactorDao;
        public IPriceFactorDao PriceFactorDao 
        {
            set { priceFactorDao = value; }
        }

        private IDailyBusionessReportItemDao dailyBusionessReportItemDao;
        public IDailyBusionessReportItemDao DailyBusionessReportItemDao 
        {
            set { dailyBusionessReportItemDao = value; }
        }

        private IDailyBusionessReportDao dailyBusionessReportDao;

        public IDailyBusionessReportDao DailyBusionessReportDao
        {
            get { return dailyBusionessReportDao; }
            set { dailyBusionessReportDao = value; }
        }

	
        #endregion

        /// <summary>
        /// 根据查询条件获取帐龄订单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetAnalyzeDebt(Order order)
        {
            return orderDao.GetAnalyzeDebt(order);
        }
        /// <summary>
        /// 获取某部门人员
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Employee> GetCasherEmployeeList(long positionId)
        {
            return employeeDao.GetCasherEmployeeList(positionId);
        }
        /// <summary>
        /// 根据查询条件获取帐龄订单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetAnalyzeAssistantDebt(Order order)
        {
            return orderDao.GetAnalyzeAssistantDebt(order);
        }
		/// <summary>
		/// 查找某个客户某段时间内的付款明细
		/// </summary>
		/// <param name="condition">查询条件</param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-10-25
		/// 修正履历:
		/// 修正时间:
		/// </remarks>
		public IList<Gathering> GetCustomerPayment(Order order)
		{
			return gatheringDao.GetCustomerPayment(order);
		}

		public int GetCustomerPaymentCount(Order order)
		{
			return gatheringDao.GetCustomerPaymentCount(order);
		}

		public decimal GetCustomerPaymentAmount(Order order)
		{
			return gatheringDao.GetCustomerPaymentAmount(order);
		}

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
		public IList<Order> GetCustomerConsume(Order order)
		{
			return orderDao.GetCustomerConsume(order);
		}

		/// <summary>
		/// 获取客户消费记录数
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2007-10-24
		/// </remarks>
		public int GetCustomerConsumeCount(Order order)
		{
			return orderDao.GetCustomerConsumeCount(order);
		}

		/// <summary>
		/// 获取客户消费总计
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		public Order GetCustomerConsumeAmount(Order order)
		{
			return orderDao.GetCustomerConsumeAmount(order);
		}

		#endregion

        /// <summary>
        /// 查询门店营业额
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-26
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetBranchShopTurnover(Order order)
        {
			order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
			order.StatusList.Add(Constants.PAY_KIND_PREPAY_VALUE);
			order.StatusList.Add(Constants.PAY_KIND_RETURN_VALUE);
			order.StatusList.Add(Constants.PAY_KIND_INVALIDATE_VALUE);
			order.PayKind = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;
			IList<Order> orders = orderDao.SelectBranchShopTurnover(order);
			foreach (Order val in orders)
			{
				val.OrderCount = orderDao.GetOrderCount(order);
			}
			return orders;
        }
        /// <summary>
        /// 查询客户欠款情况
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-26
        /// 修正履历: 崔肖（加分页）
        /// 修正时间:2008-12-4
        /// </remarks>
        public IList<Order> GetCustomerArrearage(Order order)
        {
            return orderDao.SelectCustomerArrearage(order);
        }

        public IList<Order> GetaAllCustomerArrearage(Order order)
        {
            return orderDao.GetaAllCustomerArrearage(order);
        }
        /// <summary>
        /// 返回查询客户欠款的行数（用于分页）
        /// 
        /// 作    者: 崔肖
        /// 创建时间: 2008-12-4

        public long GetSelectCustomerArrearageCount(Order order)
        {
            return orderDao.GetSelectCustomerArrearageCount(order);
        }

        private IList<LabelValue> OperatorList;
        public IList<LabelValue> GetOperator()
        {
            if (OperatorList == null)
            {
                OperatorList = new List<LabelValue>();
                OperatorList.Add(new LabelValue(Constants.QUERY_CONDITION_GREATER_VALUE, Constants.QUERY_CONDITION_GREATER_TEXT));
                OperatorList.Add(new LabelValue(Constants.QUERY_CONDITION_GREATER_EQUAL_VALUE, Constants.QUERY_CONDITION_GREATER_EQUAL_TEXT));
                OperatorList.Add(new LabelValue(Constants.QUERY_CONDITION_EQUAL_VALUE, Constants.QUERY_CONDITION_EQUAL_TEXT));
                OperatorList.Add(new LabelValue(Constants.QUERY_CONDITION_LESS_VALUE, Constants.QUERY_CONDITION_LESS_TEXT));
                OperatorList.Add(new LabelValue(Constants.QUERY_CONDITION_LESS_EQUAL_VALUE, Constants.QUERY_CONDITION_LESS_EQUAL_TEXT));
                
                
                
            }
            return OperatorList;
        }
       
        /// <summary>
        /// 客户对帐表的客户信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-27
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetCustomerHistory(Order order)
        {
            return orderDao.GetCustomerHistory(order);
        }
		/// <summary>
		/// 客户对帐表的订单信息
		/// </summary>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-10-27
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public IList<Order> GetCustomerOrdersHistory(string memberCardNo, string customerName, int beginRow, int endRow)
		{
			return orderDao.GetCustomerOrdersHistory(memberCardNo, customerName, beginRow, endRow);
		}

		public Order GetCustomerOrderHistoryTotalize(string memberCardNo, string customerName)
		{
			return orderDao.GetCustomerOrderHistoryTotalize(memberCardNo, customerName);
		}

		/// <summary>
		/// 客户对帐表的订单信息数量
		/// </summary>
		/// <param name="memberCardNo"></param>
		/// <param name="customerName"></param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2010-01-14
		/// </remarks>
		public int GetCustomerOrdersHistoryCount(string memberCardNo, string customerName)
		{
			return orderDao.GetCustomerOrdersHistoryCount(memberCardNo, customerName);
		}

		#region 获取用户信息

		/// <summary>
		/// 获取用户信息
		/// </summary>
		/// <param name="memberCardNo">会员卡号</param>
		/// <param name="customerName">客户名称</param>
		/// <returns></returns>
		public Customer GetCustomer(string memberCardNo, string customerName)
		{
			return customerDao.GetCustomer(memberCardNo, customerName);
		}

		#endregion

		#region 异常价格订单统计

		/// <summary>
		/// 异常价格订单统计
		/// </summary>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-10-29
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public IList<Order> GetExceptionPriceOrdes(Hashtable map)
		{
			return orderDao.GetExceptionPriceOrdes(map);
		}

		/// <summary>
		/// 异常价格订单统计数量
		/// </summary>
		/// <param name="map"></param>
		/// <returns></returns>
		public int GetExceptionPriceOrdesCount(Hashtable map)
		{
			return orderDao.GetExceptionPriceOrdesCount(map);
		}

		public Order GetExceptionPriceOrdesTotalize(Hashtable map)
		{
			return orderDao.GetExceptionPriceOrdesTotalize(map);
		}


		#endregion

		
        /// <summary>
        /// 新老客户消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetNewAndOldCustomerConsumeCount(Hashtable map)
        {
			return orderDao.GetNewAndOldCustomerConsumeCount(map);
        }

        #region//异常会员客户消费统计
        /// <summary>
        /// 异常会员客户消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetExceptionMemberCustomerConsume(Order order)
        {
            return orderDao.GetExceptionMemberCustomerConsume(order);
        }

        /// <summary>
        /// 异常会员客户消费统计记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月21日9:48:01
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public long GetExceptionMemberCustomerConsumeRowCount(Order order) 
        {
            return orderDao.GetExceptionMemberCustomerConsumeRowCount(order);
        }

        /// <summary>
        /// 异常会员客户消费统计输出数据
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年2月3日9:49:51
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetExceptionMemberCustomerConsumePrint(Order order) 
        {
            return orderDao.GetExceptionMemberCustomerConsumePrint(order);
        }

        #endregion

        #region //波动客户消费统计
        /// <summary>
        /// 波动客户消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetExceptionConsumeCustomer(Order order)
        {
            return orderDao.GetExceptionConsumeCustomer(order);
        }

        /// <summary>
        /// 波动客户消费统计记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年2月23日14:48:09
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public long GetExceptionConsumeCustomerRowCount(Order order) 
        {
            return orderDao.GetExceptionConsumeCustomerRowCount(order);
        }

        /// <summary>
        /// 波动客户消费统计输出数据
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年2月23日14:47:37
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetExceptionConsumeCustomerPrint(Order order) 
        {
            return orderDao.GetExceptionConsumeCustomerPrint(order);
        }
        #endregion

        #region //查询没有消费的客户
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
        public IList<Customer> GetWithoutConsumeCustomer(Hashtable customer)
        {
            return customerDao.SelectWithoutConsumeCustomer(customer);
        }

        /// <summary>
        /// 名    称: GetWithoutConsumeCustomerRowCount
        /// 功能概要: 查询没有消费的客户记录数
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月21日14:21:56
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public long GetWithoutConsumeCustomerRowCount(Hashtable customer) 
        {
            return customerDao.GetWithoutConsumeCustomerRowCount(customer);
        }

        /// <summary>
        /// 名    称: GetWithoutConsumeCustomerRowPrint
        /// 功能概要: 查询没有消费的客户输出
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月21日14:21:56
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<Customer> GetWithoutConsumeCustomerRowPrint(Hashtable customer) 
        {
            return customerDao.GetWithoutConsumeCustomerRowPrint(customer);
        }
        #endregion

        #region//查询客户预付款情况
        /// <summary>
        /// 查询客户预付款情况(分页)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-26
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetCustomerPrepay(Order order)
        {
            return orderDao.SelectCustomerPrepay(order);
        }
        /// <summary>
        /// 名    称: GetCustomerPrepayPrint
        /// 功能概要: 按照条件 获取客户预付款信息(打印)
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-24
        /// 修正履历:
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        public IList<Order> GetCustomerPrepayPrint(Order order) 
        {
            return orderDao.GetCustomerPrepayPrint(order) ;
        }

        /// <summary>
        /// 名    称: GetCustomerPrepayRowsCount
        /// 功能概要: 按照条件 获取客户预付款信息的总记录数
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-24
        /// 修正履历:
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        public int GetCustomerPrepayRowsCount(Order order) 
        {
            return orderDao.GetCustomerPrepayRowsCount(order);
        }
        #endregion

        #region //应收款按照时间段统计
        /// <summary>
        /// 名    称: 
        /// 功能概要: 按时间段和客户名称获取应收款信息的Order(分页)
        /// 作    者: 张晓林
        /// 创建时间: 2008-11-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="hashtable">时间段和客户条件的组合条件或者其中的单一条件</param>
        /// <returns></returns>
        public IList<Order> GetAccountReceviableAccordingToTimeSectTotal(Hashtable hashtable)
        {
            return orderDao.GetAccountReceviableAccordingToTimeSectTotal(hashtable);
        }

        /// <summary>
        /// 名    称: 
        /// 功能概要: 按时间段和客户名称获取应收款信息的总记录数
        /// 作    者: 张晓林
        /// 创建时间: 2008-11-28
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
        public long GetSearchAccountReceviableInfoCount(Hashtable hashCondition)
        {
            return orderDao.GetSearchAccountReceviableInfoCount(hashCondition);
        }

        /// <summary>
        /// 名    称: 
        /// 功能概要: 按时间段和客户名称获取应收款信息的Order(打印)
        /// 作    者: 张晓林
        /// 创建时间: 2008-11-29
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
        public IList<Order> GetAllAccountReceiviable(Hashtable hashCondition)
        {
            return orderDao.GetAccountReceviableTotal(hashCondition);
        }
        #endregion

        #region //日报
        /// <summary>
        ///	(按照日期查询)日报Order(分页)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-2
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetDailyPaper(Hashtable hashCondition)
        {
            return orderDao.GetDailyPaper(hashCondition);
        }

        /// <summary>
        /// 按照日期查询 日报总记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-2
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public long GetDailyPaperTotal(Hashtable hashCondition)
        {
            return orderDao.GetDailyPaperTotal(hashCondition);
        }

        /// <summary>
        /// (按照日期查询)日报Orders(打印)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-4
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetDailyPaperPrint(Hashtable hashCondition)
        {
            return orderDao.GetDailyPaperPrint(hashCondition);
        }

        /// <summary>
        /// 统计满足条件的税费
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月17日11:34:08
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public decimal GetDailyScotAmount(Hashtable condition) 
        {
            condition.Add("InvliDate", Constants.INVALIDATE_KEY);
            return orderDao.GetDailyScotAmount(condition);
        }
        #endregion

        #region //月报
        ///// <summary>
        ///// 名    称: GetMonthPaper
        ///// 功能概要: 统计 日报(orderList)
        ///// 作    者: 张晓林
        ///// 创建时间: 2008-12-9
        ///// 修正履历:
        ///// 修正时间:
        ///// </summary>
        ///// <param name="hashCondition"></param>
        ///// <returns></returns>
        //public IList<Order> GetMonthPaper(Hashtable hashCondition)
        //{
        //    return orderDao.GetMonthPaper(hashCondition);
        //}

        ///// <summary>
        ///// 名    称: GetMonthPaperTotalCount
        ///// 功能概要: 按照月份统计 月报总记录数目
        ///// 作    者: 张晓林
        ///// 创建时间: 2008-12-9
        ///// 修正履历:
        ///// 修正时间:
        ///// </summary>
        ///// <param name="hashCondition"></param>
        ///// <returns></returns>
        //public long GetMonthPaperTotalCount(Hashtable hashCondition)
        //{
        //    return orderDao.GetMonthPaperTotal(hashCondition);
        //}
        /// <summary>
        /// 名    称: GetMonthPaperPrint
        /// 功能概要: 按照月份统计 月报(打印)
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
        public IList<Order> GetMonthPaperPrint(Hashtable hashCondition)
        {
            return orderDao.GetMonthPaperPrint(hashCondition);
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
        public IList<Order> SearchOrderByCashPerson(Order order)
        {
            //string startDate = DateTime.Now.ToString("yyyy-MM") + "-" + (DateTime.Now.Day - 1) + " " + applicationPropertyDao.GetValue(Constants.APPLICATION_START_TIME_KEY);
            //string endDate = DateTime.Now.ToShortDateString() + " " + applicationPropertyDao.GetValue(Constants.APPLICATION_END_TIME_KEY);
            //order.InsertDateTime = Convert.ToDateTime(startDate);
            //order.BalanceDateTime = Convert.ToDateTime(endDate);
            return orderItemDao.SearchOrderByCashPerson(order);
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
        public long SearchOrderByCashPersonRowCount(Order order)
        {
            //string startDate = DateTime.Now.ToString("yyyy-MM") + "-" + (DateTime.Now.Day - 1) + " " + applicationPropertyDao.GetValue(Constants.APPLICATION_START_TIME_KEY);
            //string endDate = DateTime.Now.ToShortDateString() + " " + applicationPropertyDao.GetValue(Constants.APPLICATION_END_TIME_KEY);
            //order.InsertDateTime = Convert.ToDateTime(startDate);
            //order.BalanceDateTime = Convert.ToDateTime(endDate);
            return orderItemDao.SearchOrderByCashPersonRowCount(order);
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
        public IList<Order> SearchOrderByCashPersonPrint(Order order)
        {
            //string startDate = DateTime.Now.ToString("yyyy-MM") + "-" + (DateTime.Now.Day - 1) + " " + applicationPropertyDao.GetValue(Constants.APPLICATION_START_TIME_KEY);
            //string endDate = DateTime.Now.ToShortDateString() + " " + applicationPropertyDao.GetValue(Constants.APPLICATION_END_TIME_KEY);
            //order.InsertDateTime = Convert.ToDateTime(startDate);
            //order.BalanceDateTime = Convert.ToDateTime(endDate);
            return orderItemDao.SearchOrderByCashPersonPrint(order);
        }
        #endregion

        #region//优惠查询
        /// <summary>
        /// 优惠查询
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日14:15:22
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Gathering> SearchConcession(PaymentConcession paymentConcession) 
        {
            return paymentConcessionDao.SearchConcession(paymentConcession);
        }

        /// <summary>
        /// 优惠查询记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日14:15:22
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public long SearchConcessionRowCount(PaymentConcession paymentConcession)
        {
            return paymentConcessionDao.SearchConcessionRowCount(paymentConcession);
        }

        /// <summary>
        /// 优惠查询记录(输出)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月21日11:56:54
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Gathering> SearchConcessionPrint(PaymentConcession paymentConcession) 
        {
            return paymentConcessionDao.SearchConcessionPrint(paymentConcession);
        }
        #endregion

        #region//按照人员统计开单量
        /// <summary>
        /// 名    称: SearchOrderCount
        /// 功能概要: 按照人员统计开单量
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日16:19:55
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<Employee> SearchOrderCount(Employee employee) 
        {
            return employeeDao.SearchOrderCount(employee);
        }
             
        /// <summary>
        /// 名    称: SearchOrderCountRowCount
        /// 功能概要: 按照人员统计开单量记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日16:19:48
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public long SearchOrderCountRowCount(Employee employee) 
        {
            return employeeDao.SearchOrderCountRowCount(employee);
        }

        /// <summary>
        /// 名    称: SearchOrderCountPrint
        /// 功能概要: 按照人员统计开单量)
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日16:19:48
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<Employee> SearchOrderCountPrint(Employee employee) 
        {
            return employeeDao.SearchOrderCountPrint(employee);
        }

        /// <summary>
        /// 名    称: SearchPosition
        /// 功能概要: 获取指定的部门
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月13日10:32:27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<Position> SearchPositionByCondition(Employee employee)
        {
            return employeeDao.SearchPositionByCondition(employee);
        }

        /// <summary>
        /// 名    称: SearchEmployeeByPosition
        /// 功能概要: 获取指定的部门的人员
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月13日10:32:27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<Employee> SearchEmployeeByPosition(Employee employee) 
        {
            return employeeDao.SearchEmployeeByPosition(employee);
        }

        /// <summary>
        /// 名    称: SearchPositionByEmployeeId
        /// 功能概要: 根据雇员Id获取岗位
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月16日11:07:37
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public Position SearchPositionByEmployeeId(Employee employee) 
        {
            return employeeDao.SearchPositionByEmployeeId(employee);
        }

        /// <summary>
        /// 名    称: SearchOrderCountDetail
        /// 功能概要: 按照人员统计开单量明细
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月5日10:18:03
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<Employee> SearchOrderCountDetail(Order order) 
        {
            return employeeDao.SearchOrderCountDetail(order);
        }

        /// <summary>
        /// 名    称: SearchOrderCountDetailRowCount
        /// 功能概要: 按照人员统计开单量明细记录数
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月5日10:18:03
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public long SearchOrderCountDetailRowCount(Order order) 
        {
            return employeeDao.SearchOrderCountDetailRowCount(order);
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
        public IList<OtherGatheringAndRefundmentRecord> SearchAccountRecord(Order order) 
        {
            return otherGatheringAndRefundmentRecordDao.SearchAccountRecord(order);   
        }

        /// <summary>
        /// 获取应收款记录列表记录数
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月21日15:42:10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long SearchAccountRecordRowCount(Order order) 
        {
            return otherGatheringAndRefundmentRecordDao.SearchAccountRecordRowCount(order);
        }

        /// <summary>
        /// 获取应收款记录列表(输出)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月21日15:42:10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<OtherGatheringAndRefundmentRecord> SearchAccountRecordPrint(Order order) 
        {
            return otherGatheringAndRefundmentRecordDao.SearchAccountRecordPrint(order);
        }
        #endregion

        #region//补领取发票记录
        /// <summary>
        /// 功能概要: 补领发票记录
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月30日9:50:18
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        public IList<OtherGatheringAndRefundmentRecord> SearchDrawTicketRecord(OtherGatheringAndRefundmentRecord oGatheringRecord) 
        {
            return otherGatheringAndRefundmentRecordDao.SearchDrawTicketRecord(oGatheringRecord);
        }

        /// <summary>
        /// 功能概要: 补领发票记录数目
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月30日9:50:18
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        public long SearchDrawTicketRecordRowCount(OtherGatheringAndRefundmentRecord oGatheringRecord) 
        {
            return otherGatheringAndRefundmentRecordDao.SearchDrawTicketRecordRowCount(oGatheringRecord);
        }
        /// <summary>
        /// 功能概要: 补领发票记录输出记录
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月30日9:50:18
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        public IList<OtherGatheringAndRefundmentRecord> SearchDrawTicketRecordPrint(OtherGatheringAndRefundmentRecord oGatheringRecord) 
        {
            return otherGatheringAndRefundmentRecordDao.SearchDrawTicketRecordPrint(oGatheringRecord);
        }
        #endregion

		#region 获取客户的所有订单

		/// <summary>
		/// 获取客户的所有订单
		/// </summary>
		/// <param name="customerId"></param>
		/// <returns></returns>
		public IList<Order> GetCustomerOrders(long customerId,int beginRow,int endRow)
		{
			return orderDao.GetCustomerOrders(customerId,beginRow,endRow);
		}

		public int GetCustomerOrderCount(long customerId)
		{
			return orderDao.GetCustomerOrderCount(customerId);
		}

		#endregion

        #region//日营业报表
        /// <summary>
        /// 删除营业报表
        /// </summary>
        /// <param name="columnFormat"></param>
        /// <param name="tempDailyBusionessReportItem"></param>
        /// <param name="date">统计日期</param>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月21日10:37:57
        /// </remarks>
        [Transaction]
        public void DeleteDailyBusinessReportItem(string date) 
        {
            dailyBusionessReportItemDao.DeleteDailyBusinessReportItem(date);
        }
        /// <summary>
        /// 获取日营业报表数据
        /// </summary>
        /// <param name="dailyBusionessReportItem"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月20日15:43:36
        /// </remarks>
        public IList<DailyBusionessReportItem> SearchDailyBusinessInfo(DailyBusionessReportItem dailyBusionessReportItem) 
        {
            return dailyBusionessReportItemDao.SearchDailyBusinessInfo(dailyBusionessReportItem);
        }

        /// <summary>
        /// 功  能: 统计业务类型使用情况
        /// 作  者: 张晓林
        /// 日  期: 2010年4月16日14:23:13
        /// </summary>
        [Transaction]
        public void StatisticalBusinessTypeUsed(string date, string fileName) 
        {
            IList<PriceFactor> priceFactorList = priceFactorDao.SelectAllPriceFactorList();
            IList<long> orderItemIdList = dailyBusionessReportItemDao.GetOrderItemIdList(date);
            IList<DailyBusionessReportItem> dailyBusionessReportItemList=dailyBusionessReportItemDao.GetStatisticalBusinessTypeUsed(date);
            IList<DailyBusionessReportItem> tempDailyBusionessReportItemList=new List<DailyBusionessReportItem>();
            foreach (long orderId in orderItemIdList)
            {
                DailyBusionessReportItem dailyBusinessReportItem=new DailyBusionessReportItem();
                foreach (DailyBusionessReportItem dbr in dailyBusionessReportItemList)
                {
                    if (orderId == dbr.OrderItemId)
                    {
                        dailyBusinessReportItem.Count = decimal.Round(dbr.Count * dbr.Amount,2);//消费金额
                        dailyBusinessReportItem.Amount = dbr.Amount;//数量
                        foreach(PriceFactor pf in priceFactorList)
                        {
                            if(pf.Id==dbr.PriceFactorId)
                            {
                                string strTypeName = dailyBusionessReportItemDao.GetPriceFactorValueText(dbr.PriceFactorValueId, pf);
                                if ("PROCESS_CONTENT" == pf.TargetTable.ToUpper())
                                {
                                    dailyBusinessReportItem.Name = strTypeName;
                                    dailyBusinessReportItem.ProcessContentId = dbr.PriceFactorValueId;
                                    break;
                                }
                                else if("MACHINE_TYPE"==pf.TargetTable.ToUpper())
                                {
                                    dailyBusinessReportItem.MachineTypeId = dbr.PriceFactorValueId;
                                }
                                else if ("PAPER_SPECIFICATION" == pf.TargetTable.ToUpper())
                                {
                                    dailyBusinessReportItem.PaperSpecificationName = strTypeName;
                                    dailyBusinessReportItem.PaperSpacificationId = dbr.PriceFactorValueId;
                                    break;
                                }
                            }
                        }
                    }
                }
                tempDailyBusionessReportItemList.Add(dailyBusinessReportItem);
            }
            //读取显示格式
            StreamReader streamReader = new StreamReader(fileName, Encoding.Default);
            string str = streamReader.ReadToEnd();
            streamReader.Close();
            InsertDailyBusinessReportItem(str, tempDailyBusionessReportItemList,date);
        }

        /// <summary>
        /// 处理统计数据然后插入到营业报表
        /// </summary>
        /// <param name="columnFormat">列表头格式</param>
        /// <param name="tempDailyBusionessReportItem">待合计的日报表列表</param>
        /// <param name="date">统计日期</param>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月20日11:57:29
        /// </remarks>
        public void InsertDailyBusinessReportItem(string columnFormat, IList<DailyBusionessReportItem> tempDailyBusionessReportItem,string date) 
        {
            string[] strRow = columnFormat.Split(new char[] {'\r','\n' });
            IList<DailyBusionessReportItem> columnDailyBusionessReportItemList=new List<DailyBusionessReportItem>();
            foreach (string str in strRow)
            {
                if(""!=str)
                {
                    DailyBusionessReportItem dailyBusionessReportItem = new DailyBusionessReportItem();
                    string[] strType = str.Split(',');
                    dailyBusionessReportItem.Name = strType[0];//列标题
                    dailyBusionessReportItem.FileName = strType[1];//列组合键:(加工内容:机器:纸型)
                    dailyBusionessReportItem.PaperSpecificationName = strType[2];//纸型
                    dailyBusionessReportItem.TypeSort = Convert.ToInt32(strType[3]);//纸型类型个数
                    columnDailyBusionessReportItemList.Add(dailyBusionessReportItem);
                }
            }
            IList<DailyBusionessReportItem> finalDailyBusionessReportItemList = new List<DailyBusionessReportItem>();
            int sortIndex = 1;
            foreach (DailyBusionessReportItem cdbr in columnDailyBusionessReportItemList)
            {
                DailyBusionessReportItem finalDailyBusionessReportItem = new DailyBusionessReportItem();
                string[] columnKeyArray = cdbr.FileName.Split('-');
                if (null == columnKeyArray)//单个加工内容,单个机器
                {
                    foreach (DailyBusionessReportItem tdbr in tempDailyBusionessReportItem)
                    {
                        if(cdbr.FileName==tdbr.ProcessContentId+":"+tdbr.MachineTypeId+":"+tdbr.PaperSpacificationId)
                        {
                            finalDailyBusionessReportItem.Name = cdbr.Name;
                            finalDailyBusionessReportItem.PaperSpecificationName = tdbr.PaperSpecificationName;
                            finalDailyBusionessReportItem.Amount += tdbr.Amount;//数量
                            finalDailyBusionessReportItem.Count += tdbr.Count;//金额
                        }
                    }
                }
                else//多个加工内容，多个机器                    
                {
                    foreach(string columnKey in columnKeyArray)
                    {
                        foreach (DailyBusionessReportItem tdbr in tempDailyBusionessReportItem)
                        {
                            if (columnKey == tdbr.ProcessContentId + ":" + tdbr.MachineTypeId + ":" + tdbr.PaperSpacificationId) 
                            {
                                finalDailyBusionessReportItem.Name = cdbr.Name;
                                finalDailyBusionessReportItem.PaperSpecificationName = tdbr.PaperSpecificationName;
                                finalDailyBusionessReportItem.Amount += tdbr.Amount;//数量
                                finalDailyBusionessReportItem.Count += tdbr.Count;//金额
                            }
                        }
                    }
                }
                //若当天没有消费该业务，则赋值为0
                if (null == finalDailyBusionessReportItem.Name) 
                {
                    finalDailyBusionessReportItem.Name = cdbr.Name;
                    finalDailyBusionessReportItem.PaperSpecificationName = cdbr.PaperSpecificationName;
                }
                finalDailyBusionessReportItem.TypeSort = cdbr.TypeSort;
                finalDailyBusionessReportItem.Sort = sortIndex;
                finalDailyBusionessReportItemList.Add(finalDailyBusionessReportItem);
                sortIndex++;
            }
            DailyBusionessReport dailyBusionessReport = new DailyBusionessReport();
            dailyBusionessReport.CurrentDateTime = Convert.ToDateTime(date);
            dailyBusionessReport.Memo = "";
            dailyBusionessReportDao.Insert(dailyBusionessReport);
            foreach(DailyBusionessReportItem da in finalDailyBusionessReportItemList)
            {
                da.DailyBusionessReportId = dailyBusionessReport.Id;
                if (null!=da.Name) dailyBusionessReportItemDao.Insert(da);
            }
        }

        /// <summary>
        /// 获取业务花费金额
        /// </summary>
        /// <param name="businessTypeName">业务</param>
        /// <param name="date">统计日期</param>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年5月4日14:02:41
        /// </remarks>
        public string GetPossessiveAmount(string businessTypeName, string date) 
        {
            decimal businessPossessiveAmount = 0;//该业务下所有纸型所占的金额
            decimal allBusinessAmountTotal = 0;//当天所有业务的总和
            businessPossessiveAmount = dailyBusionessReportItemDao.GetPossessiveAmount(businessTypeName, date);
            businessTypeName = null;
            allBusinessAmountTotal = dailyBusionessReportItemDao.GetPossessiveAmount(businessTypeName, date);
            decimal inverseValue = 0;
            if (0 != allBusinessAmountTotal)
            {
                inverseValue=decimal.Round(businessPossessiveAmount / allBusinessAmountTotal, 2);
            }
            return Convert.ToString(inverseValue * 100) + "%";
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
		public IList<PaymentConcession> GetPayConcessionListByUserId(PaymentConcession paymentConcession)
		{
			return paymentConcessionDao.SelectPayConcessionListByUserId(paymentConcession);
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
		public int GetPayConcessionCountByUserId(PaymentConcession paymentConcession)
		{
			return paymentConcessionDao.SelectPayConcessionCountByUserId(paymentConcession);
		}
		#endregion
    }
}
