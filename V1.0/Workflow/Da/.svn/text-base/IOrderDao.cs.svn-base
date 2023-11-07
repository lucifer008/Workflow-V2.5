using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;
namespace Workflow.Da
{
    /// <summary>
    /// 名    称: IOrderDao
    /// 功能概要: 工单Dao接口
    /// 作    者: 付强
    /// 创建时间: 
    /// 修正履历: 张晓林
    /// 修正时间: 2009-02-07
    ///             调整代码
    /// </summary>
    public interface IOrderDao : IDaoBase<Order>
    {
        /// <summary>
        /// 选择未结算的所有工单
        /// 付强
        /// </summary>
        /// <returns></returns>
        IList<Order> SelectDailyOrder(Order order);

        /// <summary>
        /// 选择未结算的所有工单 带分页
        /// 付强
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        IList<Order> SelectDailyOrderPager(Order order);

        /// <summary>
        /// 获取工单下实际已预付款
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        decimal GetPrePayAmount(Order order);

        void InsertOrder(Order order);

        void UpdateOrder(Order order);
        /// <summary>
        /// 获取本日工单总数
        /// 付强
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        int GetDailyOrderCount(Order order);
        /// <summary>
        /// 更改工单状态为制作中
        /// 付强
        /// </summary>
        /// <param name="strOrderNo"></param>
        void UpdateOrderStatusByOrderNo(Order order);

        void UpdatePrepayOrder(Order order);

        long SelectOrderIdByOrderNo(string OrderNo);

        Order SelectOrderInfoByOrderId(long orderId);
        /// <summary>
        /// 名    称: UpdateConbinationCustomerId
        /// 功能概要: 合并客户时更改客户Id
        /// 作    者: liuwei
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="linkman"></param>
        /// <returns></returns>
        ///
        void UpdateConbinationCustomerId(System.Collections.Hashtable linkman);

     
        /// <summary>
        /// 工单查询(工单管理)
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-8
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Order> SearchOrdersInfo(System.Collections.Hashtable condition);
        IList<Order> SearchOrdersInfoNo(System.Collections.Hashtable condition);
        /// <summary>
        /// 工单查询(财务管理)
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-25
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Order> SearchOrdersItem(System.Collections.Hashtable condition);
        /// <summary>
        /// 通过工单号查询送货人
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
        /// 前台交班时加工单数据抽取
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
        /// 按条件（时间）对前台交班时加工单数据抽取
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
        /// 收银交班时加工单数据抽取
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
        /// 查找等待结算的工单
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
        /// 查找等待结算的工单
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
        /// 结算时修改工单
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
        /// 查找有欠款的工单
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
        /// 收应收款时更新工单表
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
        /// 根据查询条件获取帐龄工单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetAnalyzeDebt(Order order);
        /// <summary>
        /// 根据查询条件获取帐龄工单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetAnalyzeAssistantDebt(Order order);
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
        /// 客户对帐表的工单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-27
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetCustomerOrdersHistory(Order order);

        /// <summary>
        /// 异常价格工单统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetExceptionPriceOrdesCount(Order order);
        /// <summary>
        /// 新老客户消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetNewAndOldCustomerConsumeCount(Order order);
        /// <summary>
        /// 异常会员客户消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Order> GetExceptionMemberCustomerConsumeCount(Order order);
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
        /// 获取所有参与工单制作的人员
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
        /// 获取所有需要预付款的工单
        /// </summary>
        /// <param name="iorder"></param>
        /// <returns></returns>
        IList<Order> GetAllNeedPrePayOrders(Order iorder);

        /// <summary>
        /// 获取所有需要预付款的工单的数量
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
        long GetSearchOrderInfoCount(Hashtable condition);
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
        /// 根据工单号查询 工单信息
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
        long GetCustomerPrepayRowsCount(Order order);

        /// <summary>
        ///根据工单号获取收银人
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
		IList<Order> GetOrderListByStatus(int status);
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
        /// 返回工单到已登记状态
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
	}
}
