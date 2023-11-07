using System;
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
        #endregion

        /// <summary>
        /// 根据查询条件获取帐龄工单信息
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
        /// 根据查询条件获取帐龄工单信息
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
            return orderDao.SelectBranchShopTurnover(order);
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
                OperatorList.Add(new LabelValue(Constants.QUERY_CONDITION_LESS_VALUE, Constants.QUERY_CONDITION_LESS_TEXT));
                OperatorList.Add(new LabelValue(Constants.QUERY_CONDITION_LESS_EQUAL_VALUE, Constants.QUERY_CONDITION_LESS_EQUAL_TEXT));
                OperatorList.Add(new LabelValue(Constants.QUERY_CONDITION_EQUAL_VALUE, Constants.QUERY_CONDITION_EQUAL_TEXT));
                OperatorList.Add(new LabelValue(Constants.QUERY_CONDITION_GREATER_VALUE, Constants.QUERY_CONDITION_GREATER_TEXT));
                OperatorList.Add(new LabelValue(Constants.QUERY_CONDITION_GREATER_EQUAL_VALUE,Constants.QUERY_CONDITION_GREATER_EQUAL_TEXT));
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
        /// 客户对帐表的工单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-27
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetCustomerOrdersHistory(Order order)
        {
            return orderDao.GetCustomerOrdersHistory(order);
        }

        /// <summary>
        /// 异常价格工单统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetExceptionPriceOrdesCount(Order order)
        {
            return orderDao.GetExceptionPriceOrdesCount(order);
        }
        /// <summary>
        /// 新老客户消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetNewAndOldCustomerConsumeCount(Order order)
        {
            return orderDao.GetNewAndOldCustomerConsumeCount(order);
        }
        /// <summary>
        /// 异常会员客户消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetExceptionMemberCustomerConsumeCount(Order order)
        {
            return orderDao.GetExceptionMemberCustomerConsumeCount(order);
        }
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
        public long GetCustomerPrepayRowsCount(Order order) 
        {
            return orderDao.GetCustomerPrepayRowsCount(order);
        }

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
        /// 按照收银人查询工单收款信息(分页)
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
        /// 按照收银人查询工单收款信息记录数
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
        /// 按照收银人查询工单收款信息(打印)
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
        public IList<PaymentConcession> SearchConcession(PaymentConcession paymentConcession) 
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
        public IList<PaymentConcession> SearchConcessionPrint(PaymentConcession paymentConcession) 
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
        #endregion
    }
}
