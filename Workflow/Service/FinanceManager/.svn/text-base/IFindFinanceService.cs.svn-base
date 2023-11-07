using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;

namespace Workflow.Service
{
    public interface IFindFinanceService
    {
        /// <summary>
        /// 根据查询条件获取帐龄订单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetAnalyzeDebt(Order order);
        /// <summary>
        /// 获取某部门人员
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Employee> GetCasherEmployeeList(long positionId);
        /// <summary>
        /// 根据查询条件获取帐龄订单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetAnalyzeAssistantDebt(Order order);

		#region 客户付款明细

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
		IList<Gathering> GetCustomerPayment(Order order);

		/// <summary>
		/// 查找某个客户某段时间内的付款明细
		/// </summary>
		/// <param name="condition">查询条件</param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: Cry
		/// 创建时间: 2010.1.4
		/// </remarks>
		int GetCustomerPaymentCount(Order order);

		/// <summary>
		/// 查找某个客户某段时间内的付款明细总计
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		decimal GetCustomerPaymentAmount(Order order);

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
		IList<Order> GetCustomerConsume(Order order);

		/// <summary>
		/// 获取客户消费记录数
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2007-10-24
		/// </remarks>
		int GetCustomerConsumeCount(Order order);

		/// <summary>
		/// 获取客户消费总计
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		Order GetCustomerConsumeAmount(Order order);


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
        IList<Order> GetBranchShopTurnover(Order order);
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
        IList<Order> GetCustomerArrearage(Order order);

        IList<Order> GetaAllCustomerArrearage(Order order);
        /// <summary>
        /// 获取运算符
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-26
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<LabelValue> GetOperator();
        /// <summary>
        /// 查询客户预付款情况
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-26
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetCustomerPrepay(Order order);
        /// <summary>
        /// 客户对帐表的客户信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-27
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetCustomerHistory(Order order);
		/// <summary>
		/// 客户对帐表的订单信息
		/// </summary>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-10-27
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		IList<Order> GetCustomerOrdersHistory(string memberCardNo, string customerName, int beginRow, int endRow);

		/// <summary>
		/// 客户对帐表的订单信息总计
		/// </summary>
		/// <param name="memberCardNo"></param>
		/// <param name="customerName"></param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2010-01-14
		/// </remarks>
		Order GetCustomerOrderHistoryTotalize(string memberCardNo, string customerName);

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
		int GetCustomerOrdersHistoryCount(string memberCardNo, string customerName);


		/// <summary>
		/// 获取用户信息
		/// </summary>
		/// <param name="memberCardNo">会员卡号</param>
		/// <param name="customerName">客户名称</param>
		/// <returns></returns>
		Customer GetCustomer(string memberCardNo, string customerName);

		#region 异常价格订单统计

		/// <summary>
        /// 异常价格订单统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 陈汝胤
        /// 修正时间: 2010-01-19
        /// </remarks>
        IList<Order> GetExceptionPriceOrdes(Hashtable map);

		/// <summary>
		/// 异常价格订单统计
		/// </summary>
		/// <param name="map"></param>
		/// <returns></returns>
		/// <remarks>
		/// 修正履历: 陈汝胤
		/// 修正时间: 2010-01-19
		/// </remarks>
		int GetExceptionPriceOrdesCount(Hashtable map);

		/// <summary>
		/// 异常价格订单统计总计
		/// </summary>
		/// <param name="map"></param>
		/// <returns></returns>
		Order GetExceptionPriceOrdesTotalize(Hashtable map);


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
        IList<Order> GetNewAndOldCustomerConsumeCount(Hashtable map);

        #region //异常会员客户消费统计
        /// <summary>
        /// 异常会员客户消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetExceptionMemberCustomerConsume(Order order);

        /// <summary>
        /// 异常会员客户消费统计记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月21日9:47:19
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        long GetExceptionMemberCustomerConsumeRowCount(Order order);

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
        IList<Order> GetExceptionMemberCustomerConsumePrint(Order order);
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
        IList<Order> GetExceptionConsumeCustomer(Order order);

        /// <summary>
        /// 波动客户消费统计记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年2月23日14:48:09
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        long GetExceptionConsumeCustomerRowCount(Order order);

        /// <summary>
        /// 波动客户消费统计输出数据
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年2月23日14:47:37
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetExceptionConsumeCustomerPrint(Order order);
        #endregion

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
        IList<Customer> GetWithoutConsumeCustomer(Hashtable customer);

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
        long GetWithoutConsumeCustomerRowCount(Hashtable customer);

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
        IList<Customer> GetWithoutConsumeCustomerRowPrint(Hashtable customer);

        /// <summary>
        /// 名    称: GetCustomerCount
        /// 功能概要: 返回根据条件查询客户欠款的行数（用于分页）
        /// 作    者: 崔肖
        /// 创建时间: 2008-12-4
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        long GetSelectCustomerArrearageCount(Order order);

        /// <summary>
        /// 名    称: GetCustomerPrepayPrint
        /// 功能概要: 按照条件 获取客户预付款信息(打印)
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-24
        /// 修正履历:
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        IList<Order> GetCustomerPrepayPrint(Order order);

        /// <summary>
        /// 名    称: GetCustomerPrepayRowsCount
        /// 功能概要: 按照条件 获取客户预付款信息的总记录数
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-24
        /// 修正履历:
        /// 修正时间: 
        /// </summary>
        /// <returns></returns>
        int GetCustomerPrepayRowsCount(Order order);

        #region //按时间段统计应收款

        /// <summary>
        /// 名    称: 
        /// 功能概要: 按时间段和客户获取应收款信息的order(分页)
        /// 作    者: 张晓林
        /// 创建时间: 2008-11-26
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        IList<Order> GetAccountReceviableAccordingToTimeSectTotal(Hashtable hashtable);

        /// <summary>
        /// 名    称: 
        /// 功能概要: 获取 按时间段和客户获取应收款信息的总记录数
        /// 作    者: 张晓林
        /// 创建时间: 2008-11-28
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
        long GetSearchAccountReceviableInfoCount(Hashtable hashCondition);

        /// <summary>
        /// 名    称: 
        /// 功能概要: 按时间段和客户获取应收款信息的order(不限制行数)
        /// 作    者: 张晓林
        /// 创建时间: 2008-11-29
        /// 修正履历: 
        /// 修正时间:
        /// <summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
        IList<Order> GetAllAccountReceiviable(Hashtable hashCondition);
        #endregion

        #region //日报
        /// <summary>
        ///(按照日期查询)日报Order(分页)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-2
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetDailyPaper(Hashtable hashCondition);

        /// <summary>
        /// (按照日期查询)日报总记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-2
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        long GetDailyPaperTotal(Hashtable hashCondition);

        /// <summary>
        /// (按照日期查询)日报Orders(打印)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-4
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetDailyPaperPrint(Hashtable hashCondition);

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
        decimal GetDailyScotAmount(Hashtable condition);
        #endregion

        #region //月报

        ///// <summary>
        ///// 名    称: GetMonthPaper
        ///// 功能概要: 统计 月报(分页)
        ///// 作    者: 张晓林
        ///// 创建时间: 2008-12-9
        ///// 修正履历:
        ///// 修正时间:
        ///// </summary>
        ///// <param name="hashCondition"></param>
        ///// <returns></returns>
        //IList<Order> GetMonthPaper(Hashtable hashCondition);

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
        IList<Order> GetMonthPaperPrint(Hashtable hashCondition);

        ///// <summary>
        ///// 名    称: GetMonthPaperTotalCount
        ///// 功能概要: 按照月份统计 月报总记录数
        ///// 作    者: 张晓林
        ///// 创建时间: 2008-12-9
        ///// 修正履历:
        ///// 修正时间:
        ///// </summary>
        ///// <param name="hashCondition"></param>
        ///// <returns></returns>
        //long GetMonthPaperTotalCount(Hashtable hashCondition);
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
        IList<Order> SearchOrderByCashPerson(Order order);

        /// <summary>
        /// 按照收银人查询订单收款信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long SearchOrderByCashPersonRowCount(Order order);

        /// <summary>
        /// 按照收银人查询订单收款信息(打印)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Order> SearchOrderByCashPersonPrint(Order order);
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
        IList<Gathering> SearchConcession(PaymentConcession paymentConcession); 

        /// <summary>
        /// 优惠查询记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日14:15:22
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        long SearchConcessionRowCount(PaymentConcession paymentConcession);

        /// <summary>
        /// 优惠查询记录(输出)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月21日11:56:54
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Gathering> SearchConcessionPrint(PaymentConcession paymentConcession);
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
        IList<Employee> SearchOrderCount(Employee employee);
        
        /// <summary>
        /// 名    称: SearchOrderCountRowCount
        /// 功能概要: 按照人员统计开单量记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日16:19:48
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        long SearchOrderCountRowCount(Employee employee);

        /// <summary>
        /// 名    称: SearchOrderCountPrint
        /// 功能概要: 按照人员统计开单量)
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日16:19:48
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        IList<Employee> SearchOrderCountPrint(Employee employee); 

        /// <summary>
        /// 名    称: SearchPosition
        /// 功能概要: 获取指定的部门
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月13日10:32:27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        IList<Position> SearchPositionByCondition(Employee employee); 

        /// <summary>
        /// 名    称: SearchEmployeeByPosition
        /// 功能概要: 获取指定的部门的人员
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月13日10:32:27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        IList<Employee> SearchEmployeeByPosition(Employee employee);

        /// <summary>
        /// 名    称: SearchPositionByEmployeeId
        /// 功能概要: 根据雇员Id获取岗位
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月16日11:07:37
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        Position SearchPositionByEmployeeId(Employee employee);

        /// <summary>
        /// 名    称: SearchOrderCountDetail
        /// 功能概要: 按照人员统计开单量明细
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月5日10:18:03
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        IList<Employee> SearchOrderCountDetail(Order order);

        /// <summary>
        /// 名    称: SearchOrderCountDetailRowCount
        /// 功能概要: 按照人员统计开单量明细记录数
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月5日10:18:03
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        long SearchOrderCountDetailRowCount(Order order);

        #endregion

        #region//应收款付款记录
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
        IList<OtherGatheringAndRefundmentRecord> SearchAccountRecord(Order order);

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
        long SearchAccountRecordRowCount(Order order);

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
        IList<OtherGatheringAndRefundmentRecord> SearchAccountRecordPrint(Order order);
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
        IList<OtherGatheringAndRefundmentRecord> SearchDrawTicketRecord(OtherGatheringAndRefundmentRecord oGatheringRecord);

        /// <summary>
        /// 功能概要: 补领发票记录数目
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月30日9:50:18
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        long SearchDrawTicketRecordRowCount(OtherGatheringAndRefundmentRecord oGatheringRecord);
        /// <summary>
        /// 功能概要: 补领发票记录输出记录
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月30日9:50:18
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
       IList<OtherGatheringAndRefundmentRecord> SearchDrawTicketRecordPrint(OtherGatheringAndRefundmentRecord oGatheringRecord);
        #endregion

	    #region 获取客户的所有订单

		/// <summary>
		/// 获取客户的所有订单
		/// </summary>
		/// <param name="customerId">客户id</param>
		/// <returns></returns>
		IList<Order> GetCustomerOrders(long customerId,int beginRow,int endRow);

		/// <summary>
		/// 获取客户所有订单的数量
		/// </summary>
		/// <param name="customerId"></param>
		/// <returns></returns>
		int GetCustomerOrderCount(long customerId);

	    #endregion

        #region//日营业统计报表

        /// <summary>
        /// 获取日营业报表数据
        /// </summary>
        /// <param name="dailyBusionessReportItem"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月20日15:43:36
        /// </remarks>
        IList<DailyBusionessReportItem> SearchDailyBusinessInfo(DailyBusionessReportItem dailyBusionessReportItem);

        /// <summary>
        /// 功  能: 统计业务类型使用情况
        /// 作  者: 张晓林
        /// 日  期: 2010年4月16日14:23:13
        /// </summary>
        void StatisticalBusinessTypeUsed(string date,string fileName);

        /// <summary>
        /// 处理统计数据然后插入到营业报表
        /// </summary>
        /// <param name="columnFormat"></param>
        /// <param name="tempDailyBusionessReportItem"></param>
        /// <param name="date">统计日期</param>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月20日11:57:29
        /// </remarks>
        void InsertDailyBusinessReportItem(string columnFormat, IList<DailyBusionessReportItem> tempDailyBusionessReportItem, string date);

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
        void DeleteDailyBusinessReportItem(string date);

        /// <summary>
        /// 获取业务花费金额
        /// </summary>
        /// <param name="businessTypeName">业务</param>
        /// <param name="date">统计日期</param>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年5月4日14:02:41
        /// </remarks>
        string GetPossessiveAmount(string businessTypeName, string date);
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
		IList<PaymentConcession> GetPayConcessionListByUserId(PaymentConcession paymentConcession);
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
		int GetPayConcessionCountByUserId(PaymentConcession paymentConcession);
		#endregion
    }
}
