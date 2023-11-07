using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
/// <summary>
/// 名    称: GatheringDaoImpl
/// 功能概要: 付款明细接口IGatheringDao实现类
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table GATHERING 对应的Dao 实现
	/// </summary>
    public class GatheringDaoImpl : Workflow.Da.Base.DaoBaseImpl<Gathering>, IGatheringDao
    {
		#region //查找某个客户某段时间内的付款明细
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
			return base.sqlMap.QueryForList<Gathering>("Gathering.SelectCustomerPayment", order);
		}
		#endregion

		#region 查找某个客户某段时间内的付款明细数量

		public int GetCustomerPaymentCount(Order order)
		{
			return sqlMap.QueryForObject<int>("Gathering.SelectCustomerPaymentCount", order);
		}

		/// <summary>
		/// 查找某个客户某段时间内的付款明细总计
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		public decimal GetCustomerPaymentAmount(Order order)
		{
			return sqlMap.QueryForObject<decimal>("Gathering.SelectCustomerPaymentAmount", order);
		}

		#endregion

        #region //取得结款笔数/结款金额
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
        public CashHandOver SelectPayForAmount(Hashtable condition)
        {
            condition.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//结算款
            condition.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            condition.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
            condition.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//会员卡冲减
            condition.Add("PreDeposits",Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(结算)
            condition.Add("AccountPreDepositsDiff",Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(应收款处理)
            condition.Add("PayTypeOrderDiff",Constants.PAY_KIND_ORDER_DIFF_VALUE);//订单冲减
            condition.Add("ConcessionTypeRoundPositiveValue", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//舍入多收
            return sqlMap.QueryForObject<CashHandOver>("Gathering.SelectPayForAmount", condition);
        }
        #endregion

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
        public decimal GetCurrentHandOverMemChargeAmount(Hashtable condition) 
        {
            condition.Add("ptChargeAmount1", Constants.CAMPAIGN_TYPE_CONCESSION_CHARGE_KEY);
            condition.Add("ptChargeAmount2", Constants.CAMPAIGN_TYPE_DISCOUNT_CONCESSION_KEY);
            return sqlMap.QueryForObject<decimal>("Gathering.GetCurrentHandOverMemChargeAmount", condition);
        }

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
        public decimal GetDailyScotAmount(Hashtable condition) 
        {
            condition.Add("InvliDate", Constants.INVALIDATE_KEY);
            condition.Add("scotBalance", Constants.BALANCE_SCOT_AMOUNT_KEY);
            condition.Add("scotAccount", Constants.ACCOUNT_SCOT_AMOUNT_KEY);
            return sqlMap.QueryForObject<decimal>("Gathering.GetDailyScotAmount", condition);
        }

        public IList<Gathering> SelectGatheringByOrderId(long orderId)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            Gathering g = new Gathering();
            g.Id = orderId;
            g.CompanyId = user.CompanyId;
            g.BranchShopId = user.BranchShopId;
            return sqlMap.QueryForList<Gathering>("Gathering.SelectGatheringByOrderId",g);

        }

        /// <summary>
        /// 删除订单结算信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月12日10:20:28 
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void DeleteGatheringOrderInfo(long orderId) 
        {
            Gathering gathering = new Gathering();
            gathering.Id = orderId;
            gathering.InsertUser = Convert.ToInt32(Constants.PAY_KIND_PREPAY_VALUE);
            gathering.CompanyId=ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            gathering.BranchShopId=ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;

            sqlMap.Delete("Gathering.DeleteGatheringPaymentConcessionInfo",gathering);//优惠信息
            sqlMap.Delete("Gathering.DeleteGatheringOrderInfo", gathering);//结算关联订单信息
            sqlMap.Delete("Gathering.DeleteGatheringInfo",gathering);//结算款信息
        }
    }
}
