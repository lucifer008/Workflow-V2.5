using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// 名    称: IGatheringDao
/// 功能概要: 付款明细接口
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table GATHERING 对应的Dao 接口
	/// </summary>
    public interface IGatheringDao : IDaoBase<Gathering>
    {
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
		/// 修正履历:
		/// 修正时间:
		/// </remarks>
		int GetCustomerPaymentCount(Order order);

		/// <summary>
		/// 查找某个客户某段时间内的付款明细总计
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		decimal GetCustomerPaymentAmount(Order order);
        /// <summary>
        /// 取得结款笔数/结款金额
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        CashHandOver SelectPayForAmount(Hashtable condition);

        /// <summary>
        /// 获取当日收取的税费(结算税费+应收款处理税费)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月21日12:02:58
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        decimal GetDailyScotAmount(Hashtable condition);

        IList<Gathering> SelectGatheringByOrderId(long orderId);

         /// <summary>
        /// 删除订单结算信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月12日10:20:28 
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void DeleteGatheringOrderInfo(long orderId);

        /// <summary>
        /// 获取当前用户所在班的会员卡充值金额
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月14日14:55:59
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        decimal GetCurrentHandOverMemChargeAmount(Hashtable condition);

    }
}
