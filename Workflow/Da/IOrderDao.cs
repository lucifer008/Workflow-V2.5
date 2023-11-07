using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;
namespace Workflow.Da
{
    /// <summary>
    /// 名    称: IOrderDao
    /// 功能概要: 订单Dao接口
    /// 作    者: 付强
    /// 创建时间: 
    /// 修正履历: 张晓林
    /// 修正时间: 2009-02-07
    ///             调整代码
    /// </summary>
    public interface IOrderDao : IDaoBase<Order>
    {
        /// <summary>
        /// 选择未结算的所有订单
        /// 付强
        /// </summary>
        /// <returns></returns>
        IList<Order> SelectDailyOrder(Order order);

        /// <summary>
        /// 选择未结算的所有订单 带分页
        /// 付强
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        IList<Order> SelectDailyOrderPager(Order order);

        /// <summary>
        /// 获取订单下实际已预付款
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        decimal GetPrePayAmount(Order order);

        void InsertOrder(Order order);

        void UpdateOrder(Order order);
        /// <summary>
        /// 获取本日订单总数
        /// 付强
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        int GetDailyOrderCount(Order order);
        /// <summary>
        /// 更改订单状态为制作中
        /// 付强
        /// </summary>
        /// <param name="strOrderNo"></param>
        void UpdateOrderStatusByOrderNo(Order order);

        void UpdatePrepayOrder(Order order);

        long SelectOrderIdByOrderNo(string OrderNo);

        Order SelectOrderInfoByOrderId(long orderId);
        /// <summary>
        /// 名    称: UpdateConbinationCustomerId
        /// 功能概要: 合并客户:将被合并客户的联系人添加到新客户名称下
        /// 作    者: liuwei
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="linkman"></param>
        /// <returns></returns>
        ///
        void UpdateConbinationCustomerId(System.Collections.Hashtable linkman);

        #region //本日订单-订单查询
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-8
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Order> SearchOrdersInfoPrint(Hashtable condition);
        long GetSearchOrderInfoCount(Hashtable condition);
        IList<Order> SearchOrdersInfo(Hashtable condition);
        #endregion

        #region //订单消费统计

        //IList<Order> SearchOrdersInfoNo(System.Collections.Hashtable condition);
		/// <summary>
		/// 订单查询(财务管理)
		/// </summary>
		/// <param name="condition">查询条件</param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: liuwei
		/// 创建时间: 2007-10-25
		/// 修正履历:
		/// 修正时间:
		/// </remarks>
		IList<Order> SearchOrdersItem(Hashtable condition);

		int SearchOrdersItemCount(Hashtable condition);

		Order SearchOrdersItemAmount(Hashtable condition);

		#endregion

        /// <summary>
        /// 通过订单号查询送货人
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-8
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        string SearchDelivery(string NO);
        /// <summary>
        /// 通过CustomerId查询在Orders中的数
        /// </summary>
        /// <param name="Id">CustoemrId</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-11
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        int SearchCustomerInOrder(long Id);
        
        /// <summary>
        /// 前台交班时加订单数据抽取
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> SelectStageHandOverOrder();


        /// <summary>
        /// 按条件（时间）对前台交班时加订单数据抽取
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-04
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> SelectFrontHandOverOrder(System.Collections.Hashtable condition);

        /// <summary>
        /// 收银交班时加订单数据抽取
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> SelectCashHandOverOrder(Hashtable condition);
        /// <summary>
        /// 查找等待结算的订单
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-16
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> SelectUnClosedOrder(Order order);
        /// <summary>
        /// 查找等待结算的订单
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2008-11-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        int SelectUnClosedOrderCount(Order order);
        /// <summary>
        /// 通过会员卡号查订单号
        /// </summary>
        /// <param name="strMemberCardNo">会员卡号</param>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2010-1-26
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        string GetOrderNoByMemberCardNo(string strMemberCardNo);
        /// <summary>
        /// 通过各种号码查询客户ID
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：付强
        /// 创建时间: 2010-1-8
        /// </remarks>
        long GetCustomerIdByNo(Order order);
        /// <summary>
        /// 结算时修改订单
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-17
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void UpdateOrderForClose(Order order);
        /// <summary>
        /// 查找有欠款的订单
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-17
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> SelectNotHaveBeenPaidOrder(Order order);

        /// <summary>
        /// 收应收款时更新订单表
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-17
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void UpdateOrderForArearage(Order order);
        /// <summary>
        /// 计算会员卡的刷卡次数
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-23
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        int SelectMemberCardBrushNumber(string MemberCardNo);
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
        /// 根据查询条件获取帐龄订单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetAnalyzeAssistantDebt(Order order);

		#region 客户消费情况

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
		/// <param name="order"></param>
		/// <returns></returns>
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
		/// 创建时间: 2010-01-15
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

		#region MyRegion

		/// <summary>
        /// 异常价格订单统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetExceptionPriceOrdes(Hashtable map);

		int GetExceptionPriceOrdesCount(Hashtable map);

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
        /// 获取所有参与订单制作的人员
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-5
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetOrderAllUserByOrdersId(Order order);
        /// <summary>
        /// 获取开单核收银人员
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-5
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetOrderReceptionAndCashUserByOrderId(Order order);

        #region 收银交班相关
        /// <summary>
        ///  取得预付定金/笔数
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        CashHandOver SelectDebtAmount(Hashtable condition);

        /// <summary>
        /// 取得记帐笔数/记帐金额
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        CashHandOver SelectKeepBusinessRecordAmount(Hashtable condition);

        /// <summary>
        /// 取得发票笔数/发票金额
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        CashHandOver SelectTicketAmount(Hashtable condition);
        /// <summary>
        /// 查询门店营业额
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-26
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> SelectBranchShopTurnover(Order order);
        /// <summary>
        /// 查询客户欠款情况
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-26
        /// 修正履历: 崔肖（加分页）
        /// 修正时间:
        /// </remarks>
        IList<Order> SelectCustomerArrearage(Order order);
        //不限制行数
        IList<Order> GetaAllCustomerArrearage(Order order);
       
        #endregion


        /// <summary>
        /// 获取所有需要预付款的订单
        /// </summary>
        /// <param name="iorder"></param>
        /// <returns></returns>
        IList<Order> GetAllNeedPrePayOrders(Order iorder);

        /// <summary>
        /// 获取所有需要预付款的订单的数量
        /// </summary>
        /// <param name="iorder"></param>
        /// <returns></returns>
        long GetAllNeedPrePayOrdersCount(Order iorder);

        /// <summary>
        /// 合计订单总金额和预收款总金额
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月11日9:03:24
        /// 修正履历: 
        /// 修正时间: 
        ///</remarks>
        Order GetOrderPrepayAmountTotalAndSumAmountTotal(Order order);

        /// <summary>
        /// 包含时机已经预付款金额的order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order SelectOrderInfoByOrderIdPrePaid(long orderId);
       
		/// <summary>
		/// 应收款按时间段合计(限制查询行数的)
		/// </summary>
		/// <param name="hashtable"></param>
		/// <returns></returns>
		IList<Order> GetAccountReceviableAccordingToTimeSectTotal(Hashtable hashtable);
		long GetSearchAccountReceviableInfoCount(Hashtable hashCondition);
		/// <summary>
		/// 应收款按时间段合计(没有限定行数的)
		/// </summary>
		/// <param name="hashCondition"></param>
		/// <returns></returns>
		IList<Order> GetAccountReceviableTotal(Hashtable hashCondition);

		/// <summary>
		/// (按照日期查询)日报(限制行数的)
		/// </summary>
		/// <param name="NowDate"></param>
		/// <returns></returns>
		IList<Order> GetDailyPaper(Hashtable hashCondition);

		/// <summary>
		/// (按照日期查询)日报
		/// </summary>
		/// <param name="NowDate"></param>
		/// <returns></returns>
		long GetDailyPaperTotal(Hashtable hashCondition);

        /// <summary>
        /// 按照日期查询日报(打印)
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
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

        ///// <summary>
        ///// (按照月份查询)月报(限制行数的)
        ///// </summary>
        ///// <param name="NowDate"></param>
        ///// <returns></returns>
        //IList<Order> GetMonthPaper(Hashtable hashCondition);

        /// <summary>
        /// 按照月份统计(月报)---打印
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <returns></returns>
        IList<Order> GetMonthPaperPrint(Hashtable hashCondition);

        ///// <summary>
        ///// 按照月份统计(月报)总记录数
        ///// </summary>
        ///// <param name="hashCondition"></param>
        ///// <returns></returns>
        //long GetMonthPaperTotal(Hashtable hashCondition);

        /// <summary>
        /// 返回欠款客户信息的行数（用于分页）
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        long GetSelectCustomerArrearageCount(Order order);

        /// <summary>
        /// 根据订单号查询 订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order SelectOrderByOrderNo(long orderId);

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
        IList<Order> SelectCustomerPrepay(Order order);

        /// <summary>
        /// 查询客户预付款情况(打印)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetCustomerPrepayPrint(Order order);

        /// <summary>
        /// 查询客户预付款信息的总记录数
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        int GetCustomerPrepayRowsCount(Order order);

        /// <summary>
        ///根据订单号获取收银人
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        string cashUserName(string orderNo);

        /// <summary>
        /// 名    称: GetCustomerIdByCustomerName
        /// 功能概要: 根据客户名称获取客户Id
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月9日16:19:38
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        Customer GetCustomerInfoByName(string customerName);

		#region 获取订单列表通过订单状态

		/// <summary>
		/// 获取订单列表通过订单状态
		/// </summary>
		/// <returns>OrderList</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.23
		/// </remarks>
		IList<Order> GetOrderListByStatus(Hashtable map);
		#endregion

        /// <summary>
        /// 名    称: GetCustomerPayTypeByCustomerId
        /// 功能概要: 根据客户Id获取客户支付方式
        /// 作    者: 张晓林
        /// 创建时间: 2009年8月24日9:30:14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long GetCustomerPayTypeByCustomerId(long customerId);

        /// <summary>
        /// 返回订单到已登记状态
        /// </summary>
        /// <remarks>
        /// 作者:张晓林
        /// 创建时间:2009年10月12日10:57:17
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void UpdateOrderByReturnOrder(Order order);

        /// <summary>
        /// 取消欠发票
        /// </summary>
        /// <param name="orderId"></param>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年10月24日15:06:31
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        void CancelNotPaidTicket(Order order);

        /// <summary>
        /// 名    称: GetAmendmentOrder
        /// 功能概要: 获取要修正的订单
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月17日13:10:40
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        Order GetAmendmentOrder(Order order);

        /// <summary>
        /// 作废已经结算的订单
        /// </summary>
        /// <param name="order"></param>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2009年11月19日9:22:24
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        void ReturnOrderForPay(Order order);

		#region 获取需要抄表的所有订单
		
		/// <summary>
		/// 获取需要超标的所有订单
		/// </summary>
		/// <param name="lastRecordWath"></param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者：陈汝胤
		/// 创建时间: 2009年12月15日
		/// 修正履历：
		/// 修正时间:
		/// </remarks>
		IList<Order> SelectNeedRecordMachineWatch(RecordMachineWatch lastRecordWath);
		#endregion


		#region 获取订单

		/// <summary>
		/// 获取订单
		/// </summary>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <param name="paymentType">支付类型</param>
		/// <returns></returns>
		IList<Order> GetOrders(DateTime beginTime, DateTime endTime, int paymentType,int orderStatus,string userName);

		#endregion

        #region 新流程订单分配
        /// <summary>
        /// 名    称: NewDispatchOrder
        /// 功能概要: 新流程-分配订单
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月7日15:06:46
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        void NewDispatchOrder(Order order);
        #endregion


        #region //新流程-修正打印
        /// <summary>
        /// 名    称: AdmendmentPrint
        /// 功能概要: 新流程-修正打印
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月7日17:25:53
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        void AdmendmentPrint(Order order);
        #endregion

        #region//新流程-返回订单
        /// <summary>
        /// 名    称: ReturnOrder
        /// 功能概要: 新流程-返回订单
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月8日10:05:09
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        void ReturnOrder(Order order);

        /// <summary>
        /// 名    称: AddBarCodeToOrder
        /// 功能概要: 新流程-给订单添加条码
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月12日9:46:54
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        void AddBarCodeToOrder(Order order);
        #endregion

		#region 获取订单数量

		/// <summary>
		/// 获取订单数量
		/// </summary>
		/// <param name="order">订单数量</param>
		/// <returns></returns>
		long GetOrderCount(Order order);

		#endregion

		#region 获取客户的所有订单

		/// <summary>
		/// 获取客户的所有订单
		/// </summary>
		/// <param name="customerId">客户id</param>
		/// <returns></returns>
		IList<Order> GetCustomerOrders(long customerId,int beginRow,int endRow);

		int GetCustomerOrderCount(long customerId);

		#endregion
	}
}
