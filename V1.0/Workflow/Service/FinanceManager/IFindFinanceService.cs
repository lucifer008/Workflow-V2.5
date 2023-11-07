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
        long GetCustomerPrepayRowsCount(Order order);

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
        /// 按照收银人查询工单收款信息(分页)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Order> SearchOrderByCashPerson(Order order);

        /// <summary>
        /// 按照收银人查询工单收款信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long SearchOrderByCashPersonRowCount(Order order);

        /// <summary>
        /// 按照收银人查询工单收款信息(打印)
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
        IList<PaymentConcession> SearchConcession(PaymentConcession paymentConcession); 

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
        IList<PaymentConcession> SearchConcessionPrint(PaymentConcession paymentConcession);
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
        #endregion
    }
}
